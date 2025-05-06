namespace Feliz

open Fable
open Fable.AST

/// <summary>Applies to custom defined React hooks to ensure the generated code starts with "use" in order for fast-refresh to pick it up</summary>
type HookAttribute() =
    inherit MemberDeclarationPluginAttribute()
    override _.FableMinimumVersion = "4.0"

    /// <summary>Transforms call-site into createElement calls</summary>
    override _.TransformCall(compiler, memb, expr) =
        let membArgs = memb.CurriedParameterGroups |> List.concat
        match expr with
        | Fable.Call(callee, info, typeInfo, range) ->
            let callee =
                match callee with
                | Fable.Expr.IdentExpr ident ->
                    if not (ident.Name.StartsWith "use") then
                        Fable.Expr.IdentExpr { ident with Name = "use" + ident.Name }
                    else 
                        callee
                | Fable.Expr.Import(importInfo, fableType, sourceLocation) ->
                    // apply prefix "use" from hook imports from different modules/files
                    let selector = 
                        if not (importInfo.Selector.StartsWith "use") then
                            "use" + importInfo.Selector
                        else 
                            importInfo.Selector
                    let modifiedImportInfo = { importInfo with Selector = selector }
                    Fable.Expr.Import(modifiedImportInfo, fableType, sourceLocation)
                | _ ->
                    callee

            Fable.Call(callee, info, typeInfo, range)

        | _ ->
            expr

    override this.Transform(compiler, file, decl) =
        let info = compiler.GetMember(decl.MemberRef)
        if info.IsValue || info.IsGetter || info.IsSetter then
            // Invalid attribute usage
            let errorMessage = sprintf "Expecting a function declation for %s when using [<Hook>]" decl.Name
            compiler.LogWarning(errorMessage, ?range=decl.Body.Range)
            decl
        else
            if not (decl.Name.StartsWith "use") then 
                // only apply "use" prefix if the declaration doesn't already have it
                { decl with Name = "use" + decl.Name }
            else 
                // hook function already start with "use", keep it as-is
                decl