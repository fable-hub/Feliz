module Example.UseDeferredValue

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
let UseDeferredValue () =
    let query, setQuery = React.useState ""
    let deferredQuery = React.useDeferredValue query
    let isStale = query <> deferredQuery

    Html.div [
        Html.input [ prop.value query; prop.placeholder "Filter, e.g. 12"; prop.onChange setQuery ]
        Html.div [
            // Dim the list while it shows results for an older query.
            prop.style [ style.opacity (if isStale then 0.5 else 1.0) ]
            prop.children [ SlowList deferredQuery ]
        ]
    ]
