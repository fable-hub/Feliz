module Example.CreatePortal

open Feliz
open Fable.Core.JsInterop

[<ReactComponent>]
let Modal (close: _ -> unit) =
    Html.div [
        prop.style [
            style.position.fixedRelativeToWindow
            style.top 0
            style.left 0
            style.right 0
            style.bottom 0
            style.backgroundColor "rgba(0,0,0,0.5)"
            style.display.flex
            style.alignItems.center
            style.justifyContent.center
            style.zIndex 1000
        ]
        prop.onClick close
        prop.children [
            Html.div [
                prop.style [
                    style.backgroundColor.white
                    style.color.black
                    style.padding 20
                    style.borderRadius 8
                ]
                prop.onClick (fun e -> e.stopPropagation ()) // Prevent closing when clicking inside the modal
                prop.children [
                    Html.div "This is a modal rendered using a portal!"
                    Html.div [
                        Html.text "Use rightclick and inspect element to see it positioned in "
                        Html.code "document.body"
                        Html.text "."
                    ]
                    Html.button [ prop.text "Close"; prop.onClick close ]
                ]
            ]
        ]
    ]


[<ReactComponent(true)>]
let PortalDemo () =
    let show, setShow = React.useState (false)

    Html.div [
        Html.p
            "This example demonstrates React portals. Click the button to open a modal rendered outside this components DOM hierarchy."
        Html.button [
            prop.text (if show then "Hide Portal" else "Show Portal")
            prop.onClick (fun _ -> setShow (not show))
        ]
        if show then
            ReactDOM.createPortal (Modal(fun _ -> setShow (false)), Browser.Dom.document.body)
    ]
