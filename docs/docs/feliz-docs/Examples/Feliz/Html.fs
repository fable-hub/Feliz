module Example.Html

open Feliz

[<ReactComponent(true)>]
let Example () =
    Html.div [
        prop.id "main-container"
        prop.children [
            Html.h1 "Hello, Feliz!"
            Html.p "This is a simple example of using Feliz to create HTML elements in F#."
            Html.button [
                prop.onClick (fun _ -> Browser.Dom.window.alert ("Button clicked!"))
                prop.text "Submit"
                prop.style [
                    style.color.whiteSmoke
                    style.backgroundColor.steelBlue
                    style.borderWidth 0
                    style.padding (length.em 0.5, length.em 1)
                    style.display.flex
                    style.alignItems.center
                    style.justifyContent.center
                    style.borderRadius 5
                    style.cursor.pointer
                    style.fontWeight.bold
                    style.letterSpacing (length.em 0.1)
                ]
            ]
        ]
    ]
