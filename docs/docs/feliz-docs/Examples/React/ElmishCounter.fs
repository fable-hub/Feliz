module Example.ElmishCounter

open Fable.Core
open Feliz
open Feliz.UseElmish
open Elmish

type Msg =
    | Increment
    | Decrement

type State = { Count : int }

let init() = { Count = 0 }, Cmd.none

let update msg state =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrement -> { state with Count = state.Count - 1 }, Cmd.none

[<Erase; Mangle(false)>]
type Main =

    [<ReactComponent(true)>]
    static member Main() =
    
        let state, dispatch = React.useElmish(init, update, [| |])
        Html.div [
            Html.h1 state.Count
            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> dispatch Increment)
            ]

            Html.button [
                prop.text "Decrement"
                prop.onClick (fun _ -> dispatch Decrement)
            ]
        ]
