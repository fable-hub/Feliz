module Example.UseContext

open Feliz

// Define a context for shared state
// This can should be placed in a separate file for reuse
let CounterContext = React.createContext (None: (int * (int -> unit)) option)

[<ReactComponent>]
let CounterProvider (children: ReactElement list) =
    let count, setCount = React.useState (0)
    CounterContext.Provider(Some(count, setCount), children)

[<ReactComponent>]
let CounterDisplay () =
    let ctx = React.useContext (CounterContext)

    match ctx with
    | Some(count, _) -> Html.p [ prop.text $"Current count: {count}" ]
    | None -> Html.p [ prop.text "No context available" ]

[<ReactComponent>]
let CounterControls () =
    let ctx = React.useContext (CounterContext)

    match ctx with
    | Some(count, setCount) ->
        Html.div [
            Html.button [
                prop.text "+"
                prop.onClick (fun _ -> setCount (count + 1))
            ]
            Html.button [
                prop.text "-"
                prop.onClick (fun _ -> setCount (count - 1))
            ]
        ]
    | None -> Html.p [ prop.text "No context available" ]

[<ReactComponent(true)>]
let UseContext () =
    CounterProvider [
        Html.h3 [ prop.text "Shared Counter" ]
        CounterDisplay()
        CounterControls()
    ]
