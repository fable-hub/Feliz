[<RequireQualifiedAccess>]
module Feliz.Interop

open Fable.Core
open Fable.React

// let reactApi : IReactApi = importDefault "react"
// #if FABLE_COMPILER_3 || FABLE_COMPILER_4
// let inline reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
// #else
// let reactElement (name: string) (props: 'a) : ReactElement = import "createElement" "react"
// #endif


[<Emit "undefined">]
let undefined: obj = jsNative

let inline svgAttribute (key: string) (value: obj) : ISvgAttribute = unbox (key, value)

[<Emit "typeof $0 === 'number'">]
let isTypeofNumber (x: obj) : bool = jsNative

[<Emit("typeof $0[Symbol.iterator] === 'function'")>]
let isIterable (x: obj): bool = jsNative
