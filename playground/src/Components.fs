module Components 

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<ReactComponent>]
let Test(input: string | null) =
    Html.div [
        match input with
        | null -> prop.text "Input is null"
        | notNull ->
            prop.text (notNull + " from F#")
    ]
