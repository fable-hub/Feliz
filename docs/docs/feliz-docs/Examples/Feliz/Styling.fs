module Example.Styling

open Feliz

[<ReactComponent(true)>]
let Example () =
    Html.div [
        prop.style [
            style.display.flex
            style.width (length.percent 100)
            style.justifyContent.center
            style.alignItems.center
            style.height 40 // overload for px
            style.backgroundColor.dodgerBlue
            style.color (color.rgba (255, 255, 255, 0.9))
            style.borderRadius 99
            style.border (2, borderStyle.solid, color.white)
            style.fontWeight.bold
            style.fontSize 20 // overload for px
            style.cursor.notAllowed
        ]
        prop.text "Test"
    ]
