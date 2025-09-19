module Feliz.AstUtils

open Fable
open Fable.AST
open System
open System.Linq
open System.Text.RegularExpressions

let cleanFullDisplayName str =
    Regex.Replace(str, @"`\d+", "").Replace(".", "_")

let makeIdent _type name: Fable.Ident =
    { Name = name
      Type = _type
      IsCompilerGenerated = true
      IsThisArgument = false
      IsMutable = false
      Range = None }

let makeUniqueIdent (name: string) =
    let hashToString (i: int) =
        if i < 0
        then "Z" + (abs i).ToString("X")
        else i.ToString("X")
    "$" + name + (Guid.NewGuid().GetHashCode() |> hashToString) |> makeIdent Fable.Type.Any

let makeValue r value =
    Fable.Value(value, r)

let makeStrConst (x: string) =
    Fable.StringConstant x
    |> makeValue None

let nullValue = Fable.Expr.Value(Fable.ValueKind.Null(Fable.Type.Any), None)

let makeCallInfo args: Fable.CallInfo = {
    ThisArg = None
    Args = args
    SignatureArgTypes = []
    GenericArgs = []
    MemberRef = None
    Tags = []
}

let emitJs macro args  =
    let callInfo = makeCallInfo args

    let emitInfo : Fable.AST.Fable.EmitInfo =
        { Macro = macro
          IsStatement = false
          CallInfo = callInfo }

    Fable.Expr.Emit(emitInfo, Fable.Type.Any, None)

let rec flattenList (head: Fable.Expr) (tail: Fable.Expr) =
    [
        yield head;
        match tail with
        | Fable.Expr.Value (value, range) ->
            match value with
            | Fable.ValueKind.NewList(Some(nextHead, nextTail), listType) ->
                yield! flattenList nextHead nextTail
            | Fable.ValueKind.NewList(None, listType) ->
                yield! [ ]
            | _ ->
                yield! [ Fable.Expr.Value (value, range) ]

        | _ ->
            yield! [ ]
    ]

let makeImport (selector: string) (path: string) =
    Fable.Import({ Selector = selector.Trim()
                   Path = path.Trim()
                   Kind = Fable.UserImport(false) }, Fable.Any, None)

let isRecord (compiler: PluginHelper) (fableType: Fable.Type) =
    match fableType with
    | Fable.Type.AnonymousRecordType _ -> true
    | Fable.Type.DeclaredType (entity, genericArgs) -> compiler.GetEntity(entity).IsFSharpRecord
    | _ -> false

let isPropertyList (compiler: PluginHelper) (fableType: Fable.Type) =
    match fableType with
    | Fable.Type.List(genericArg) ->
        match genericArg with
        | Fable.Type.DeclaredType (entity, genericArgs) -> entity.FullName.EndsWith "IReactProperty"
        | _ -> false
    | _ -> false

let isPascalCase (input: string) = not (String.IsNullOrWhiteSpace input) && List.contains input.[0] ['A' .. 'Z']
let isCamelCase (input: string) = not (isPascalCase input)

let isAnonymousRecord (fableType: Fable.Type) =
    match fableType with
    | Fable.Type.AnonymousRecordType  _ -> true
    | _ -> false

let isReactElement (fableType: Fable.Type) =
    match fableType with
    | Fable.Type.DeclaredType (entity, genericArgs) -> entity.FullName.EndsWith "ReactElement"
    | _ -> false

let recordHasField name (compiler: PluginHelper) (fableType: Fable.Type) =
    match fableType with
    | Fable.Type.AnonymousRecordType (fieldNames, genericArgs, _isStruct) ->
        fieldNames
        |> Array.exists (fun field -> field = name)

    | Fable.Type.DeclaredType (entity, genericArgs) ->
        compiler.GetEntity(entity).FSharpFields
        |> List.exists (fun field -> field.Name = name)

    | _ ->
        false

let memberName = function
    | Fable.MemberRef(_,m) -> m.CompiledName
    | Fable.GeneratedMemberRef m -> m.Info.Name

let makeCall callee args =
    Fable.Call(
        callee, 
        makeCallInfo args, 
        Fable.Any, // This must be adjusted to change the return type of the function
        None)


let makeSet target fieldName value =
    Fable.Set(target, Fable.SetKind.FieldSet(fieldName), Fable.Type.String, value, None)

let createElement reactElementType args =
    let callee = makeImport "createElement" "react"
    Fable.Call(callee, makeCallInfo args, reactElementType, None)

let emptyReactElement reactElementType =
    Fable.Expr.Value(Fable.Null(reactElementType), None)

let makeMemberInfo isInstance typ name: Fable.GeneratedMemberInfo = {
    Name = name
    ParamTypes = []
    ReturnType = typ
    IsInstance = isInstance
    HasSpread = false
    IsMutable = false
    DeclaringEntity = None
}

let objValue (k, v): Fable.ObjectExprMember =
    {
        Name = k
        Args = []
        Body = v
        MemberRef =
            makeMemberInfo true v.Type k
            |> Fable.GeneratedValue
            |> Fable.GeneratedMemberRef
        IsMangled = false
    }

let objExpr kvs = Fable.ObjectExpr(List.map objValue kvs, Fable.Any, None)

let capitalize (input: string) =
    if String.IsNullOrWhiteSpace input
    then ""
    else input.First().ToString().ToUpper() + String.Join("", input.Skip(1))

let camelCase (input: string) =
    if String.IsNullOrWhiteSpace input
    then ""
    else input.First().ToString().ToLower() + String.Join("", input.Skip(1))

let withTag tag =
    function
    | Fable.Call(e, i, t, r) -> Fable.Call(e, { i with Tags = tag :: i.Tags }, t, r)
    | Fable.Get(e, Fable.FieldGet i, t, r) -> Fable.Get(e, Fable.FieldGet { i with Tags = tag :: i.Tags }, t, r)
    | Fable.Operation(op, tags, t, r) -> Fable.Operation(op, tag :: tags, t, r)
    | e -> e

let withJSXTag =
    withTag "jsx"
