module Examples.Guides.JSXModule

open Feliz
open Feliz.JSX

[<ReactComponent(true)>]
let TestComponent() =
    let counter, setCounter = React.useState(0)

    Html.div [
        prop.id "my-div"
        prop.className "container"
        prop.children [
            Html.h1 "Hello from JSX!"
            Html.p "This is a paragraph inside a div."
            Html.div [
                Html.h1 "Counter - Reactivity Test"
                Html.button [
                    prop.text "Increment"
                    prop.onClick (fun _ -> setCounter(counter + 1))
                ]
                Html.ul [
                    if counter = 0 then
                        Html.li "No items"
                    else
                        for i in 1..counter do
                            Html.li [
                                prop.key i 
                                prop.text (sprintf "Item %d" i) 
                            ]
                ]
            ]
        ]
    ]
