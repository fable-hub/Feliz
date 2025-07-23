module Example.HoverAnimations

open System
open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Main =

    [<ReactComponent>]
    static member AnimationsOnHover(content: ReactElement list) =
        let (hovered, setHovered) = React.useState(false)
        Html.div [
            prop.style [
                style.padding 10
                style.transitionDuration (TimeSpan.FromMilliseconds 1000.0)
                style.transitionProperty [
                    transitionProperty.backgroundColor
                    transitionProperty.color
                ]

                if hovered then
                    style.backgroundColor.lightBlue
                    style.color.black
                else
                    style.backgroundColor.limeGreen
                    style.color.white
            ]
            prop.onMouseEnter (fun _ -> setHovered(true))
            prop.onMouseLeave (fun _ -> setHovered(false))
            prop.children content
        ]


    [<ReactComponent(true)>]
    static member Main() =
        Html.div [
            Main.AnimationsOnHover [ Html.span "Hover me!" ]
            Main.AnimationsOnHover [ Html.p "So smooth" ]
        ]
