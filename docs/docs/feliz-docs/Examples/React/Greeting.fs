module Example.Greeting

open Feliz

[<ReactComponent>]
let Greeting(name: string option) : ReactElement =
    Html.div [
        Html.span "Hello, "
        Html.span (Option.defaultValue "World" name)
    ]
