namespace Feliz

open Fable
open Fable.AST
open Fable.AST.Fable

// Tell Fable to scan for plugins in this assembly
[<assembly: ScanForPlugins>]
do ()

module internal ReactComponentHelpers =
    let (|ReactLazyMemo|_|) =
        function
        | Import({ Selector = "memo"; Path = "react" }, _, _) as e -> Some e
        | Import({ Selector = "lazy"; Path = "react" }, _, _) as e -> Some e
        | Get(Import({ Path = "react" }, _, _), kind, _, _) as e ->
            match kind with
            | ExprGet(Value(StringConstant "memo", _)) -> Some e
            | FieldGet i when i.Name = "memo" -> Some e
            | ExprGet(Value(StringConstant "lazy", _)) -> Some e
            | FieldGet i when i.Name = "lazy" -> Some e
            | _ -> None
        | _ -> None

    let injectReactImport body =
        let body =
            match body with
            | Sequential body -> body
            | _ -> [ body ]

        Sequential [ AstUtils.makeImport "default as React" "react"; yield! body ]

    let (|IsCreateElement|_|) =
        function
        | Import({
                     Selector = "createElement"
                     Path = "react"
                 },
                 _,
                 _) as e -> Some e
        | _ -> None

    let mkImportPath (fsharpSourcePath: string) (compilerInfo: PluginHelper) =
        let extensionIndex = fsharpSourcePath.LastIndexOf "."
        fsharpSourcePath.Remove(extensionIndex) + compilerInfo.Options.FileExtension

    let getPathInfo (args: List<Expr>) compilerInfo = [
        for arg in args do
            match arg with
            | Import({ Path = path }, _, _) ->
                let path = mkImportPath path compilerInfo
                Value(StringConstant path, None)
            | _ -> ()

    ]

    let rec transformToDynImport compilerInfo body =
        match body with
        | Call(IsCreateElement _, info, t, r) ->
            let relativeImport =
                IdentExpr {
                    Name = "import"
                    Type = Any
                    IsMutable = false
                    IsThisArgument = false
                    IsCompilerGenerated = true
                    Range = None
                }

            let pathInfo = getPathInfo info.Args compilerInfo
            let info = { info with Args = pathInfo }

            let t =
                DeclaredType(
                    {
                        FullName = "Fable.Core.JS.Promise`1"
                        Path = CoreAssemblyName "Fable.Core"
                    },
                    [ AnonymousRecordType([| "default" |], [ Type.Any ], false) ]
                )

            Call(relativeImport, info, t, r)
        | Sequential body ->
            let next = body |> List.map (transformToDynImport compilerInfo)
            Sequential next
        // | Delegate(args, body, name, tags) ->
        | Let(_, _, body) -> // This case is relevant when props are used to hint at optional parameters
            // Example:
            // ```fsharp
            // [<ReactLazyComponent>]
            // let LazyCounter(init) = Counter.Counter.Counter(init)
            // ```
            transformToDynImport compilerInfo body
        | TypeCast(body, _) -> transformToDynImport compilerInfo body
        | _ -> body

    let applyImportOrMemoOrLazy import from memo (lazy': bool option) (compiler: PluginHelper) (decl: MemberDecl) =
        match import, from, memo, lazy' with
        | Some _, Some _, _, _ ->
            let reactElType = decl.Body.Type
            // imported component doesn't need to emit any JS
            let tags = "remove-declaration" :: decl.Tags

            {
                decl with
                    Body = AstUtils.emptyReactElement reactElType
                    Tags = tags
            }

        | _, _, Some true, _ ->
            let memoFn = AstUtils.makeImport "memo" "react"

            let body =
                decl.Body
                |> injectReactImport
                |> fun body -> [ Delegate(decl.Args, body, None, Tags.empty) ]
                |> AstUtils.makeCall memoFn
            // Change declaration kind from function to value
            let info =
                AstUtils.memberName decl.MemberRef
                |> AstUtils.makeMemberInfo false body.Type
                |> GeneratedValue
                |> GeneratedMemberRef

            {
                decl with
                    MemberRef = info
                    Args = []
                    Body = body
            }

        | _, _, _, Some true ->
            let lazyFn = AstUtils.makeImport "lazy" "react"

            let body =
                decl.Body
                |> injectReactImport
                |> fun body ->

                    let dynImport =
                        // Transform createElement call to dynamic import to file of the component
                        transformToDynImport compiler body

                    let args = [ Delegate([], dynImport, None, Tags.empty) ]
                    args
                |> AstUtils.makeCall lazyFn
            // Change declaration kind from function to value
            let info =
                AstUtils.memberName decl.MemberRef
                |> AstUtils.makeMemberInfo false body.Type
                |> GeneratedValue
                |> GeneratedMemberRef

            {
                decl with
                    MemberRef = info
                    Args = []
                    Body = body
            }

        | _ -> {
            decl with
                Body = injectReactImport decl.Body
          }

open ReactComponentHelpers

/// <summary>Transforms a function into a React function component. Make sure the function is defined at the module level</summary>
type ReactComponentAttribute(?exportDefault: bool, ?import: string, ?from: string, ?memo: bool, ?lazy': bool) =
    inherit MemberDeclarationPluginAttribute()
    override _.FableMinimumVersion = "5.0"
    new() = ReactComponentAttribute(exportDefault = false)
    new(exportDefault: bool) = ReactComponentAttribute(exportDefault = exportDefault, ?import = None, ?from = None)
    new(import: string, from: string) = ReactComponentAttribute(exportDefault = false, import = import, from = from)

    /// <summary>Transforms call-site into createElement calls</summary>
    override this.TransformCall(compiler, memb, expr) =
        let reactElType = expr.Type
        let membArgs = memb.CurriedParameterGroups |> List.concat

        match expr with
        | Call(callee, info, _typeInfo, _range) ->
            let reactComponent =
                match import, from with
                | Some importedMember, Some externalModule -> // This is `[<ReactComponent(member, path)>]`.
                    // For relative imports `[<ReactComponent(member, "./NativeCounter")>]`
                    // The call might come from file XX.fs, but the component import is defined in file YY.
                    // Relative component import path is relative to file YY. Therefore we need to resolve relative path from XX to YY and YY to `externalModule`
                    let fsharpSourcePath =
                        match callee with
                        | Import({ Selector = _; Path = fsharpPath }, _, _) -> Some fsharpPath
                        | _ -> None

                    match fsharpSourcePath with
                    | Some fsp ->
                        /// returns resolved relative path or input if not relative (exmp: `[<ReactComponent(member, "my-awesome-lib")>]`)
                        let resolvedPath = PathUtils.resolveReactComponentPaths fsp externalModule
                        AstUtils.makeImport importedMember resolvedPath
                    | None -> AstUtils.makeImport importedMember externalModule
                | _ -> callee

            if
                List.length membArgs = info.Args.Length
                && info.Args.Length = 1
                && AstUtils.isRecord compiler info.Args[0].Type
            then
                // F# Component { Value = 1 }
                // JSX <Component Value={1} />
                // JS createElement(Component, { Value: 1 })
                if AstUtils.recordHasField "Key" compiler info.Args[0].Type then
                    // When the key property is upper-case (which is common in record fields)
                    // then we should rewrite it
                    let modifiedRecord =
                        AstUtils.emitJs "(($value) => { $value.key = $value.Key; return $value; })($0)" [ info.Args[0] ]

                    AstUtils.createElement reactElType [ reactComponent; modifiedRecord ]
                else
                    AstUtils.createElement reactElType [ reactComponent; info.Args[0] ]
            elif info.Args.Length = 1 && info.Args[0].Type = Type.Unit then
                // F# Component()
                // JSX <Component />
                // JS createElement(Component, null)
                AstUtils.createElement reactElType [ reactComponent; AstUtils.nullValue ]
            else
                let mutable keyBinding = None
                let mutable tupleArgBinding = 0

                let propsObj =
                    List.zip (List.take info.Args.Length membArgs) info.Args
                    |> List.collect (fun (arg, expr) ->
                        match arg.Name, expr with
                        | Some "key", IdentExpr _ -> [ "key", expr; "$key", expr ]
                        | Some "key", _ ->
                            let keyIdent = AstUtils.makeUniqueIdent "key"
                            keyBinding <- Some(keyIdent, expr)
                            [ "key", IdentExpr keyIdent; "$key", IdentExpr keyIdent ]
                        | Some name, _ -> [ name, expr ]
                        | None, _ -> [ // we currently assume this only hits for single tupled arguments
                            let name = sprintf "tuple_%d" tupleArgBinding // `.Transform` will create names starting with `tuple_` for a single tuple argument; see #644
                            tupleArgBinding <- tupleArgBinding + 1
                            name, expr
                        ]) // if input is a single tupled argument, we don't have names
                    |> AstUtils.objExpr

                let reactEl = AstUtils.createElement reactElType [ reactComponent; propsObj ]

                let expr =
                    match keyBinding with
                    | None -> reactEl
                    | Some(ident, value) -> Let(ident, value, reactEl)

                match [| memo, lazy', callee |] with
                // If the call is memo or lazy and the function has an identifier, we can set the displayName
                | [| (Some true), _, (IdentExpr i) |]
                | [| _, (Some true), (IdentExpr i) |] ->
                    Sequential [
                        (AstUtils.makeSet (IdentExpr(i)) "displayName" (AstUtils.makeStrConst i.Name))
                        expr
                    ]
                | _ -> expr
        | _ ->
            // return expression as is when it is not a call expression
            expr

    override this.Transform(compiler, file, decl) =

        let info = compiler.GetMember(decl.MemberRef)

        if memo.IsSome && lazy'.IsSome && memo.Value && lazy'.Value then
            let errorMessage =
                sprintf "Cannot use both memo and lazy options in [<ReactComponent>] for %s" decl.Name

            compiler.LogWarning(errorMessage, ?range = decl.Body.Range)
            decl
        else if info.IsValue || info.IsGetter || info.IsSetter then
            // Invalid attribute usage
            let errorMessage =
                sprintf "Expecting a function declaration for %s when using [<ReactComponent>]" decl.Name

            compiler.LogWarning(errorMessage, ?range = decl.Body.Range)
            decl
        else if not (AstUtils.isReactElement decl.Body.Type) then
            // output of a React function component must be a ReactElement
            let errorMessage =
                sprintf
                    "Expected function %s to return a ReactElement when using [<ReactComponent>]. Instead it returns %A"
                    decl.Name
                    decl.Body.Type

            compiler.LogWarning(errorMessage, ?range = decl.Body.Range)
            decl
        else
            if (AstUtils.isCamelCase decl.Name) then
                compiler.LogWarning(
                    sprintf
                        "React function component '%s' is written in camelCase format. Please consider declaring it in PascalCase (i.e. '%s') to follow conventions of React applications and allow tools such as react-refresh to pick it up."
                        decl.Name
                        (AstUtils.capitalize decl.Name)
                )

            let decl =
                match exportDefault with
                | Some true -> {
                    decl with
                        Tags = "export-default" :: decl.Tags
                  }
                | Some false
                | None -> decl

            // do not rewrite components accepting records as input
            if decl.Args.Length = 1 && AstUtils.isRecord compiler decl.Args[0].Type then
                // check whether the record type is defined in this file
                // trigger warning if that is case
                let definedInThisFileAndIsUpperCase =
                    file.Declarations
                    |> List.tryPick (fun declaration ->
                        match declaration with
                        | Declaration.ClassDeclaration classDecl ->
                            let classEntity = compiler.GetEntity(classDecl.Entity)

                            match decl.Args[0].Type with
                            | Type.DeclaredType(entity, _genericArgs) ->
                                let declaredEntity = compiler.GetEntity(entity)

                                if
                                    classEntity.IsFSharpRecord
                                    && declaredEntity.FullName = classEntity.FullName
                                    && (System.Char.IsUpper declaredEntity.CompiledName.[0])
                                then
                                    Some declaredEntity.FullName
                                else
                                    None

                            | _ -> None

                        | Declaration.ActionDeclaration _action -> None
                        | _ -> None)

                match definedInThisFileAndIsUpperCase with
                | Some recordTypeName ->
                    let errorMsg =
                        String.concat "" [
                            sprintf
                                "Function component '%s' is using a record type '%s' as an input parameter. "
                                decl.Name
                                recordTypeName
                            "This happens to break React tooling like react-refresh and hot module reloading. "
                            "To fix this issue, consider using instead: a lowercased record type, an anonymous record or multiple simpler values as input parameters (can be tupled). "
                            "Future versions of [<ReactComponent>] might not emit this warning anymore, in which case you can assume that the issue is fixed. "
                            "To learn more about the issue, see https://github.com/pmmmwh/react-refresh-webpack-plugin/issues/258"
                        ]

                    compiler.LogWarning(errorMsg, ?range = decl.Body.Range)

                | None ->
                    // nothing to report
                    ()

                decl |> applyImportOrMemoOrLazy import from memo lazy' compiler
            else if decl.Args.Length = 1 && decl.Args[0].Type = Type.Unit then
                // remove arguments from functions requiring unit as input
                { decl with Args = [] }
                |> applyImportOrMemoOrLazy import from memo lazy' compiler
            else
                // rewrite all other arguments into getters of a single props object

                /// Single tuple argument is compiled as multiple arguments:
                /// let Test2(testing: (int * string * System.Guid)) = ...
                /// becomes:
                /// decl.Args: [
                ///     {Name = "testing_"; Type = System.Int32; IsCompilerGenerated = true}, 
                ///     {Name = "testing__1"; Type = System.String; IsCompilerGenerated = true}, 
                ///     {Name = "testing__2"; Type = System.Guid; IsCompilerGenerated = true}
                /// ]
                let isPredictedTuple = // https://github.com/fable-hub/Feliz/issues/644
                    decl.Args.Length > 1 &&
                    decl.Args.[0].IsCompilerGenerated &&
                    decl.Args.[0].Name.EndsWith("_") && // e.g.: testing_
                    decl.Args.[1].IsCompilerGenerated &&
                    decl.Args.[1].Name.Contains(decl.Args.[0].Name) // e.g.: testing__1

                if isPredictedTuple then
                    let warningMsg =
                        String.concat "" [
                            sprintf
                                "Function component '%s' is using a single tupled argument as input parameter. This can create issues with correct transpilation. "
                                decl.Name
                            "To fix this issue, consider spreading the arguments or using a (anonymous) record type."
                        ]
                    compiler.LogWarning(warningMsg, ?range = decl.Body.Range)

                let propsArg =
                    let type_ =
                        let fieldNames, genericArgs =
                            decl.Args 
                            |> List.mapi (fun i arg -> 
                                if isPredictedTuple then
                                    "tuple_" + string i, arg.Type
                                else
                                    arg.DisplayName, arg.Type
                            ) 
                            |> List.unzip

                        Fable.Type.AnonymousRecordType(Array.ofList fieldNames, genericArgs, false)
                    // let name = sprintf "%sInputProps" (AstUtils.camelCase decl.Name)
                    let name = "props"
                    AstUtils.makeIdent type_ name

                let propBindings =
                    ([], decl.Args)
                    ||> List.fold (fun bindings arg ->
                        let getterKey = if arg.DisplayName = "key" then "$key" else arg.DisplayName
                        let getterKind = ExprGet(AstUtils.makeStrConst getterKey)
                        let getter = Get(IdentExpr propsArg, getterKind, Any, None)
                        (arg, getter) :: bindings)
                    |> List.rev

                let body =
                    match decl.Body with
                    // If the body is surrounded by a memo call we put the bindings within the call
                    // because Fable will later move the surrounding function into memo
                    | Call(ReactLazyMemo reactMemo, ({ Args = arg :: restArgs } as callInfo), t, r) ->
                        let arg = propBindings |> List.fold (fun body (k, v) -> Let(k, v, body)) arg
                        Call(reactMemo, { callInfo with Args = arg :: restArgs }, t, r)
                    | _ -> propBindings |> List.fold (fun body (k, v) -> Let(k, v, body)) decl.Body

                {
                    decl with
                        Args = [ propsArg ]
                        Body = body
                }
                |> applyImportOrMemoOrLazy import from memo lazy' compiler

type ReactMemoComponentAttribute(?exportDefault: bool) =
    inherit
        ReactComponentAttribute(
            ?exportDefault = exportDefault,
            ?import = None,
            ?from = None,
            memo = true,
            lazy' = false
        )

    new() = ReactMemoComponentAttribute(exportDefault = false)

type ReactLazyComponentAttribute() =
    inherit ReactComponentAttribute(false, ?import = None, ?from = None, memo = false, lazy' = true)
