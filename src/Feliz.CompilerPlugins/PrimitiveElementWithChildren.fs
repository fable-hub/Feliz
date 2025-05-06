namespace Feliz

open Fable
open Fable.AST

//type PrimitiveElementWithChildrenAttribute(tagName:string) =
//    inherit MemberDeclarationPluginAttribute()
//    override _.FableMinimumVersion = "4.0"
//
//    member this.TransformChildren(args) =
//        let element = AstUtils.makeStrConst tagName
//        let reactChildren = AstUtils.makeImport "Children" "react"
//        let toArrayGetter = Fable.ByKey(Fable.ExprKey(AstUtils.makeStrConst "toArray"))
//        let toArray = Fable.Get(reactChildren, toArrayGetter, Fable.Any, None)
//
//        AstUtils.makeCall (AstUtils.makeImport "createElement" "react") [
//            element
//            AstUtils.objExpr [
//                "children", AstUtils.makeCall toArray [
//                    AstUtils.emitJs "Array.from($0)" args
//                ]
//            ]
//        ]
//
//    override this.TransformCall(logger, memb, expr) =
//        match expr with
//        | Fable.Call(callee, info, typeInfo, range) when info.Args.Length = 1 ->
//            match info.Args.[0] with
//            | Fable.Expr.Value(value, range) ->
//
//                match value with
//                | Fable.ValueKind.NewList (Some (head, tail), listType) ->
//                    let element = AstUtils.makeStrConst tagName
//                    AstUtils.makeCall (AstUtils.makeImport "createElement" "react") [
//                        element
//                        AstUtils.nullValue
//                        yield! AstUtils.flattenList head tail
//                    ]
//
//                | Fable.ValueKind.NewArray (expressions, arrayType) ->
//                    let element = AstUtils.makeStrConst tagName
//                    AstUtils.makeCall (AstUtils.makeImport "createElement" "react") [
//                        element
//                        AstUtils.nullValue
//                        yield! expressions
//                    ]
//
//                | _ ->
//                    this.TransformChildren [ info.Args.[0] ]
//
//            | _ ->
//                this.TransformChildren [ info.Args.[0] ]
//        | _ ->
//            expr
//
//    override this.Transform(logger, decl) = decl