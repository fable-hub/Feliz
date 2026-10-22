module CodeSplitting

open Fable.Core.JsInterop
open Feliz

[<ReactComponent(true)>]
let MyCodeSplitComponent () =
    Html.div [ prop.testId "async-load"; prop.text "Loaded" ]
