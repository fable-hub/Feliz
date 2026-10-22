module Example.UseReducer

open Feliz

type State = { Count: int }

type Msg =
    | Increment
    | Decrement

let initialState = { Count = 0 }

let update (state: State) (msg: Msg) =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }
    | Decrement -> { state with Count = state.Count - 1 }


[<ReactComponent(true)>]
let UseReducer () =
    let (state, dispatch) = React.useReducer (update, initialState)

    Html.div [
        Html.p [ prop.text $"Count: {state.Count}" ]
        Html.button [
            prop.text "+"
            prop.onClick (fun _ -> dispatch Increment)
        ]
        Html.button [
            prop.text "-"
            prop.onClick (fun _ -> dispatch Decrement)
        ]
        Html.p [
            prop.text "useReducer is useful for complex state logic."
        ]
    ]
