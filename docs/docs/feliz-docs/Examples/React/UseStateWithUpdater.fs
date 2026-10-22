module Example.UseStateWithUpdater

open Feliz

[<ReactComponent(true)>]
let UseStateWithUpdater () =
    let results, setResults = React.useStateWithUpdater ([]: string list)

    let asyncAddResult (text: string) (sleep: int) =
        async {
            do! Async.Sleep sleep
            // Use the updater function to append to the list
            setResults (fun current -> current @ [ text ])
        }
        |> Async.StartImmediate

    Html.div [
        if results.IsEmpty then
            Html.button [
                prop.text "Run"
                prop.onClick (fun _ ->
                    // Simulate async work
                    asyncAddResult "First" 1000
                    asyncAddResult "Second" 500
                    asyncAddResult "Third" 1500
                    asyncAddResult "Fourth" 2000
                )
            ]
        else
            for i in 0 .. results.Length - 1 do
                Html.div [ prop.key i; prop.text results.[i] ]
    ]
