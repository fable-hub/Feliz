namespace Feliz

open Fable
open Fable.AST

//type PrimitiveElementAttribute(tagName:string) =
//    inherit MemberDeclarationPluginAttribute()
//    override _.FableMinimumVersion = "4.0"
//
//    override _.TransformCall(logger, memb, expr) =
//        match expr with
//        | Fable.Call(callee, info, typeInfo, range) when info.Args.Length = 1 ->
//            let element = AstUtils.makeStrConst tagName
//            AstUtils.makeCall (AstUtils.makeImport "createElement" "react") [element; AstUtils.nullValue; info.Args.[0]]
//        | _ ->
//            expr
//
//    override this.Transform(logger, decl) = decl
