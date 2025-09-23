---
title: Use with Elmish
sidebar_position: 8
---

# Use with Elmish

Like any React binding, Feliz can be used in existing Elmish applications easily. You can use it in your `render` because functions in the `Html` module from Feliz return a compatible `ReactElement` that Elmish understands. Here is how a counter application looks like with Feliz and Elmish:

```fsharp
module App

open Feliz
open Elmish

type State = { Count: int }

type Msg =
    | Increment
    | Decrement

let init() = { Count = 0 }, Cmd.none

let update (msg: Msg) (state: State) =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }, Cmd.none
    | Decrement -> { state with Count = state.Count - 1 }, Cmd.none

let render (state: State) (dispatch: Msg -> unit) =
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch Increment)
            prop.text "Increment"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch Decrement)
            prop.text "Decrement"
        ]

        Html.h1 state.Count
    ]
```
