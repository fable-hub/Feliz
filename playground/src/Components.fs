module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

// [<ReactLazyComponent>]
// let LazyCounter (a: int, b: float) : ReactElement =
//     CodeSplitting.CodeSplitting.MyCodeSplitComponentTupledWithPrimitives(a, b)

type JSX = JSX.Html

[<ReactComponent>]
let MyComponent () =
    React.useEffect (fun () -> (fun () -> console.log "Cleaning up MyComponent 1"))

    React.useEffect (fun () ->
        console.log "Setting up MyComponent 2" // No-op, added so there's something in the body
        (fun () -> console.log "Cleaning up MyComponent 2")
    )

    JSX.div [ JSX.h1 "MyComponent" ]

[<ReactComponent(true)>]
let Main () =
    let render, setRender = React.useState true

    JSX.div [
        JSX.button [
            prop.text "Toggle MyComponent"
            prop.onClick (fun _ -> setRender (not render))
        ]

        if render then
            MyComponent()
    ]
