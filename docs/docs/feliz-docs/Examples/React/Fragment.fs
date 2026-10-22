module Example.Fragment

open Feliz

[<ReactComponent(true)>]
let FragmentDemo () =
    React.Fragment [
        Html.h3 [ prop.text "This is a heading inside a fragment" ]
        Html.p [
            prop.text "Fragments let you group multiple elements without adding extra nodes to the DOM."
        ]
        Html.button [ prop.text "Click me" ]
        Html.p [
            prop.text "Rightclick and inspect me to see I do not have a parent."
        ]
    ]
