module Examples.Guides.JSXModuleAlias

open Feliz

type JSX = Feliz.JSX.Html

[<ReactComponent(true)>]
let TestComponent() =
    let counter, setCounter = React.useState(0)

    JSX.div [
        prop.id "my-div"
        prop.className "container"
        prop.children [
            JSX.h1 "Hello from JSX!"
            JSX.p "This is a paragraph inside a div."
            JSX.div [
                JSX.h1 "Counter - Reactivity Test"
                JSX.button [
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
