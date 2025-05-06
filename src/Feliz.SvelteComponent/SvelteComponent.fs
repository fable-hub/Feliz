namespace Feliz.Svelte

open Fable
open Fable.AST
open Fable.AST.Fable
open Feliz

// Tell Fable to scan for plugins in this assembly
[<assembly:ScanForPlugins>]
do()

/// <summary>Transforms a Svelte into a React function component. Make sure the function is defined at the module level</summary>
type SvelteComponentAttribute(from:string) =
    inherit MemberDeclarationPluginAttribute()
    override _.FableMinimumVersion = "3.0"

    /// <summary>Transforms call-site into createElement calls</summary>
    override this.TransformCall(compiler, memb, expr) =
        let reactElementType = expr.Type
        let membArgs = memb.CurriedParameterGroups |> List.concat
        match expr with
        | Fable.Call(callee, info, typeInfo, range) when List.length membArgs = List.length info.Args ->
            if info.Args.Length = 1 && AstUtils.isRecord compiler info.Args.[0].Type then
                AstUtils.createElement reactElementType [callee; info.Args.[0]]
            elif info.Args.Length = 1 && info.Args.[0].Type = Fable.Type.Unit then
                // F# Component()
                // JSX <Component />
                // JS createElement(Component, null)
                AstUtils.createElement reactElementType [callee; AstUtils.nullValue]
            else
                let unprovidedArgsLength = membArgs.Length - info.Args.Length 
                let unprovidedArgs = 
                    AstUtils.emitJs "undefined" []
                    |> List.replicate unprovidedArgsLength

                let allArgs = info.Args @ unprovidedArgs
                let propsObj =
                    List.zip membArgs allArgs
                    |> List.choose (fun (arg, expr) -> arg.Name |> Option.map (fun k -> k, expr))
                    |> AstUtils.objExpr

                AstUtils.createElement reactElementType [callee; propsObj]
        | _ ->
            // return expression as is when it is not a call expression
            expr

    override this.Transform(compiler, file, decl) =
        let info = compiler.GetMember(decl.MemberRef)
        if info.IsValue || info.IsGetter || info.IsSetter then
            // Invalid attribute usage
            let errorMessage = sprintf "Expecting a function declation for %s when using [<SvelteComponent>]" decl.Name
            compiler.LogWarning(errorMessage, ?range=decl.Body.Range)
            decl
        else if not (AstUtils.isReactElement decl.Body.Type) then
            // output of a React function component must be a ReactElement
            let errorMessage = sprintf "Expected function %s to return a ReactElement when using [<SvelteComponent>]. Instead it returns %A. Consider retuning ReactElement using Html.none" decl.Name decl.Body.Type
            compiler.LogWarning(errorMessage, ?range=decl.Body.Range)
            decl
        else
            let converter = AstUtils.makeImport "default" "svelte-adapter/react"
            let importedSvelteComponent = AstUtils.makeImport "default" from
            // converter(importedSvelteComponent, {}, "div")
            let body = AstUtils.makeCall converter [
                importedSvelteComponent
                AstUtils.objExpr [ ]
                AstUtils.makeStrConst "div"
            ]
            { decl with
                // arguments go away
                Args = []
                Body = body
                // declaration becomes a value instead
                //Info = AstUtils.MemberInfo(decl.Info, isValue=true)
            }
