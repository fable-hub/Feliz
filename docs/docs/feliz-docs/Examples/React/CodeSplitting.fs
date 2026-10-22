module Example.CodeSplitting

open Fable.Core
open Feliz

let MyNonCodeSplitComponent () =
    Html.div [ prop.text "I was loaded synchronously!" ]

let asyncComponent: JS.Promise<unit -> ReactElement> =
    JsInterop.importDynamic "./Counter.fs"

let LazyLoadComponent: LazyComponent<unit> =
    React.lazy' (fun () -> promise {
        do! Promise.sleep 2000
        return! JsInterop.importDynamic "./Counter.fs"
    })

[<ReactComponent(true)>]
let CodeSplitting (delay: int option) =

    Html.div [
        prop.children [
            MyNonCodeSplitComponent()
            if delay.IsSome then
                Html.div [
                    prop.text $"I will be loaded after {delay.Value} milliseconds!"
                ]
            React.Suspense(
                [ Html.div [ React.lazyRender (LazyLoadComponent, ()) ] ],
                Html.div [ prop.text "Loading..." ]
            )
        ]
    ]
