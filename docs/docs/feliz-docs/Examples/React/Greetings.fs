module Example.Greetings

open Feliz

[<ReactComponent(true)>] // true defines this as default export
let Greetings() = 
    Html.div [
        prop.className "content"
        prop.children [
            Greeting.Greeting (Some "John")
            Greeting.Greeting None
        ]
    ]
