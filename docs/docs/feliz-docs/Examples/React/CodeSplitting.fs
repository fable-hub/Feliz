module Example.CodeSplitting

open Fable.Core
open Feliz

let MyNonCodeSplitComponent() =
    Html.div [
        prop.text "I was loaded synchronously!"
    ]

let asyncComponent : JS.Promise<unit -> ReactElement> = JsInterop.importDynamic "./Counter.fs"

[<ReactComponent(true)>]
let CodeSplitting(delay: int option) =

    Html.div [
        prop.children [
            MyNonCodeSplitComponent()
            if delay.IsSome then
                Html.div [
                    prop.text $"I will be loaded after {delay.Value} milliseconds!"
                ]
            React.suspense(
                [
                    Html.div [
                        React.lazy'((fun () ->
                            promise {
                                if delay.IsSome then
                                    do! Promise.sleep (delay.Value)
                                return! asyncComponent
                            }
                        ),())
                    ]
                ], 
                Html.div [
                    prop.text "Loading..."
                ]
            )
        ]
    ]
