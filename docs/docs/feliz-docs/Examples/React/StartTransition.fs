module Example.StartTransition

open Fable.Core
open Feliz

/// Takes about 1 ms to render, so a list of 300 of them is noticeably slow.
[<ReactComponent>]
let SlowItem (text: string) =
    let start = JS.Constructors.Date.now ()

    while JS.Constructors.Date.now () - start < 1.0 do
        ()

    Html.text text

/// Memoized, so urgent re-renders of the parent (typing) skip the slow list when the query is unchanged.
[<ReactMemoComponent>]
let SlowList (query: string) =
    Html.ul [
        for index in 1..300 do
            let text = $"Item {index}"

            if text.Contains query then
                Html.li [ prop.key index; prop.children [ SlowItem text ] ]
    ]

[<ReactComponent(true)>]
let StartTransition () =
    let text, setText = React.useState ""
    let query, setQuery = React.useState ""

    Html.div [
        Html.input [
            prop.value text
            prop.placeholder "Filter, e.g. 12"
            prop.onChange (fun (value: string) ->
                // Urgent: the input updates immediately.
                setText value
                // Not urgent: the slow list may lag behind.
                React.startTransition (fun () -> setQuery value)
            )
        ]
        SlowList query
    ]
