module Example.Portal

open Feliz
open Browser.Dom

[<ReactComponent>]
let Portal(content: ReactElement) =
    ReactDOM.createPortal(content, document.body)

[<ReactComponent>]
let PortalsPopup() =
    Html.div [
        prop.style [
            style.position.fixedRelativeToWindow
            style.top 10
            style.right 10
            style.padding 10
            style.backgroundColor.lightGreen
            style.zIndex 1000
        ]
        prop.children [
            Html.p [
                prop.text "Portals can be used to escape the parent component."
            ]
        ]
    ]

[<ReactComponent(true)>]
let PortalsContainer() =
    let showBanner, setShowBanner = React.useState(true)
    Html.div [
        prop.style [
            style.padding 10
            style.overflow.hidden
        ]
        prop.children [
            Html.button [
                prop.text "Toggle Popup"
                prop.onClick (fun _ -> setShowBanner (not showBanner))
            ]
            if showBanner then
                Portal(PortalsPopup())
        ]
    ]
