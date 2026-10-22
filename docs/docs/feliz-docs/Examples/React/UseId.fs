module Example.UseId

open Feliz

[<ReactComponent(true)>]
let UseId () =
    let id: string = React.useId ()

    Html.div [
        Html.label [ prop.htmlFor id; prop.text "Enter your name:" ]
        Html.input [ prop.id id; prop.type'.text ]
        Html.p [ prop.text $"Generated id: {id}" ]
    ]
