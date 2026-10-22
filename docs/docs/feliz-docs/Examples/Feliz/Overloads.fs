module Example.Overloads

open Feliz

[<ReactComponent(true)>]
let Example () =
    Html.div [
        Html.div "Test" // overload 1: single child `ReactElement`, also works for float/int
        Html.div [ // overload 2: list of properties `IProp list`
            prop.id "my-div"
            prop.text "Test" // shorthand for `prop.children [ Html.text "Test" ]`
        ]
        Html.div [ // overload 2: list of properties `IProp list`
            prop.id "my-div"
            prop.children [ // `prop.children` to pass more complex children
                Html.text "Test"
            ]
        ]
        Html.div [ // overload 1: list of children `ReactElement list`
            Html.text "Test"
        ]
    ]
