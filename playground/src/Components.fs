module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

[<ReactLazyComponent>]
let LazyCounter (a: int, b: float) : ReactElement =
    CodeSplitting.CodeSplitting.MyCodeSplitComponentTupledWithPrimitives(a, b)


[<ReactComponent(true)>]
let Main () =
    let render, setRender = React.useState false

    Html.div [
        prop.testId "main-app"
        prop.children [
            Html.h1 "Hello from the main app!"
            Html.button [
                prop.text "Load lazy component"
                prop.onClick (fun _ -> setRender true)
            ]

            if render then
                React.Suspense(
                    [
                        Html.div [
                            prop.style [ style.border (1, borderStyle.solid, color.red) ]
                            prop.children [
                                Html.text "Below you can find the lazy loaded component:"
                                LazyCounter(42, 3.14)
                            ]
                        ]
                    ],
                    Html.div "Loading..."
                )
        ]
    ]
