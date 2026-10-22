module Example.PassingProps

open Feliz

[<Fable.Core.Erase>]
type Components =


    [<ReactComponent>]
    static member MyButton(children: ReactElement, onClick: unit -> unit, ?props: IReactProperty list) =
        let props = defaultArg props []

        Html.button [
            prop.style [
                style.backgroundColor.skyBlue
                style.color "white"
                style.padding (8, 12)
                style.textAlign.center
                style.textDecoration.none
                style.display.flex
                style.margin (4, 2)
                style.cursor.pointer
            ]
            prop.onClick (fun _ -> onClick ())
            prop.children children
            yield! props // same as `...props` in JSX. Can overwrite existing props
        ]


[<ReactComponent(true)>]
let Example () =
    Html.div [
        Components.MyButton(Html.text "Click Me", (fun () -> Browser.Dom.console.log ("Button clicked!")))
        Components.MyButton(
            Html.div [ Html.span "Custom Styled Button"; Html.i " 🚀" ],
            (fun () -> Browser.Dom.console.log ("Custom button clicked!")),
            [
                prop.style [
                    style.backgroundColor.orange
                    style.fontWeight.bold
                    style.color.black
                    style.padding 8
                ]
                prop.title "This is a custom styled button"
            ]
        )

    ]
