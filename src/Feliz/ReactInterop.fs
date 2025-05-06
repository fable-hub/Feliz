namespace Feliz

open Fable.Core

module ReactInterop =
    [<Import("useDebugValue", "./ReactInterop.js")>]
    let useDebugValueWithFormatter<'t>(value: 't, formatter: 't -> string) : unit = jsNative

    [<Import("useEffect", "./ReactInterop.js")>]
    let useEffect (effect: obj) : unit =  jsNative

    [<Import("useEffectWithDeps", "./ReactInterop.js")>]
    let useEffectWithDeps (effect:  obj) (deps: obj) : unit = jsNative

    [<Import("useLayoutEffect", "./ReactInterop.js")>]
    let useLayoutEffect (effect: obj) : unit = jsNative

    [<Import("useLayoutEffectWithDeps", "./ReactInterop.js")>]
    let useLayoutEffectWithDeps (effect:  obj) (deps: obj) : unit = jsNative

