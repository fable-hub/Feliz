module Example.StrictMode

open Feliz

[<ReactComponent(true)>]
let StrictModeDemo () =
    React.StrictMode [
        Html.h3 [ prop.text "This is rendered inside React.StrictMode" ]
        Html.p [
            prop.text "StrictMode helps highlight potential problems in your application during development."
        ]
    ]
