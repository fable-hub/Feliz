module Example.FlushSync

open Feliz

[<ReactComponent(true)>]
let FlushSync () =
    let items, setItems = React.useState [ 1..5 ]
    let listRef = React.useElementRef ()

    Html.div [
        Html.button [
            prop.onClick (fun _ ->
                ReactDOM.flushSync (fun () -> setItems (items @ [ items.Length + 1 ]))
                // The new item is already in the DOM here, so scrolling reaches it.
                listRef.current |> Option.iter (fun list -> list.scrollTop <- list.scrollHeight)
            )
            prop.text "Add item and scroll to it"
        ]
        Html.ul [
            prop.ref listRef
            prop.style [ style.height 120; style.overflowY.auto ]
            prop.children [ for item in items -> Html.li [ prop.key item; prop.text $"Item {item}" ] ]
        ]
    ]
