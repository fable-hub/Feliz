module [<RequireQualifiedAccess>] Feliz.Interop

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz.ReactApi

let reactApi : IReactApi = importDefault "react"
#if FABLE_COMPILER_3 || FABLE_COMPILER_4
let inline reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
#else
let reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
#endif
let inline mkAttr (key: string) (value: obj) : IReactProperty = unbox (key, value)
[<Emit "undefined">]
let undefined : obj = jsNative
let inline mkStyle (key: string) (value: obj) : IStyleAttribute = unbox (key, value)
let inline svgAttribute (key: string) (value: obj) : ISvgAttribute = unbox (key, value)
let inline reactElementWithChild (name: string) (child: 'a) =
    reactElement name (createObj [ "children" ==> ResizeArray [| child |] ])
let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) =
    reactElement name (createObj [ "children" ==> reactApi.Children.toArray (Array.ofSeq children) ])
let inline createElement name (properties: IReactProperty list) : ReactElement =
    reactElement name (createObj !!properties)
let inline createSvgElement name (properties: ISvgAttribute list) : ReactElement =
    reactElement name (createObj !!properties)

[<Emit "typeof $0 === 'number'">]
let isTypeofNumber (x: obj) : bool = jsNative
