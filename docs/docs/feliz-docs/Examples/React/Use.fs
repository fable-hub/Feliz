module Example.Use

open Fable.Core
open Feliz

/// Pretends to fetch a quote from a server.
let fetchQuote (id: int) : JS.Promise<string> = promise {
    do! Promise.sleep 1000
    return $"Quote #{id}: Talk is cheap. Show me the code."
}

[<ReactComponent>]
let Quote (quotePromise: JS.Promise<string>) =
    // Suspends until the promise resolves.
    let quote = React.use' quotePromise
    Html.p [ prop.style [ style.fontStyle.italic ]; prop.text quote ]

[<ReactComponent(true)>]
let Use () =
    let nextId, setNextId = React.useState 1
    // The promise is created in the click handler and stored in state, never during render.
    let quotePromise, setQuotePromise = React.useState (None: JS.Promise<string> option)

    Html.div [
        Html.button [
            prop.onClick (fun _ ->
                setQuotePromise (Some(fetchQuote nextId))
                setNextId (nextId + 1)
            )
            prop.text "Load a quote"
        ]
        match quotePromise with
        | Some quotePromise -> React.Suspense([ Quote quotePromise ], Html.p "Loading quote...")
        | None -> Html.p "No quote loaded yet."
    ]
