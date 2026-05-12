module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

[<ReactLazyComponent>]
let LazyCounter (texti, id) =
    CodeSplitting.CodeSplitting.MyCodeSplitComponent(texti, id)


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
                        Html.h1 "Hello from the main app!"
                        LazyCounter("This is a lazily loaded component", "My Id")
                    ],
                    Html.div "Loading..."
                )
        ]
    ]
