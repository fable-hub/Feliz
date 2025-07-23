module Example.ElmishCounterSubscription

open Fable.Core
open Feliz
open Feliz.UseElmish
open Elmish
open System
open Fable.Core.JS

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
    
        let localCount, setLocalCount = React.useState(0)
        let state, dispatch = React.useElmish(init, update, [| |])
        let subscriptionId = React.useRef(0)

        let subscribeToTimer() =

            // start the ticking
            let rec loop = fun () ->
                // dispatch Increment every second
                dispatch Increment
                console.log("Incremented count")
                let id = setTimeout loop 1000
                subscriptionId.current <- id

            loop()
            // return IDisposable with cleanup code
            { new IDisposable with member this.Dispose() = clearTimeout(subscriptionId.current) }

        React.useEffect(subscribeToTimer, [| |])

        Html.div [
            Html.h1 (state.Count + localCount)
            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> dispatch Increment)
            ]

            Html.button [
                prop.text "Decrement"
                prop.onClick (fun _ -> dispatch Decrement)
            ]

            Html.button [
                prop.text "Increment local state"
                prop.onClick (fun _ -> setLocalCount(localCount + 1))
            ]
        ]
