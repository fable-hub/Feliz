module UseElmishNextSubscriptionDynamicIdsDiffTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("window.addEventListener($0, $1)")>]
let private addEventListener (eventName: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.removeEventListener($0, $1)")>]
let private removeEventListener (eventName: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.dispatchEvent(new CustomEvent($0))")>]
let private dispatchCustomEvent (eventName: string) : unit = jsNative

[<Emit("new Promise(function(resolve) { setTimeout(resolve, $0); })")>]
let private delay (milliseconds: int) : JS.Promise<unit> = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let CountA = "count-a"

    [<Literal>]
    let CountB = "count-b"

    [<Literal>]
    let StopA = "stop-a"

    [<Literal>]
    let FireA = "fire-a"

    [<Literal>]
    let FireB = "fire-b"

module DynamicSubscriptionDiffHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = {
        ListenA: bool
        CountA: int
        CountB: int
    }

    type Msg =
        | StopA
        | GotA
        | GotB

    let init () =
        {
            ListenA = true
            CountA = 0
            CountB = 0
        },
        Cmd.none

    let update msg model =
        match msg with
        | StopA -> { model with ListenA = false }, Cmd.none
        | GotA -> { model with CountA = model.CountA + 1 }, Cmd.none
        | GotB -> { model with CountB = model.CountB + 1 }, Cmd.none

    let subscribe model : Sub<Msg> = [
        if model.ListenA then
            [ "listener-a" ],
            (fun dispatch ->
                let handler = fun (_: obj) -> dispatch GotA
                addEventListener "dynamic-sub-a" handler

                { new System.IDisposable with
                    member _.Dispose() =
                        removeEventListener "dynamic-sub-a" handler
                }
            )

        [ "listener-b" ],
        (fun dispatch ->
            let handler = fun (_: obj) -> dispatch GotB
            addEventListener "dynamic-sub-b" handler

            { new System.IDisposable with
                member _.Dispose() =
                    removeEventListener "dynamic-sub-b" handler
            }
        )
    ]

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render() =
            let model, dispatch = React.useElmishNext (init, update, subscribe)

            Html.div [
                Html.button [
                    prop.testId TestIds.StopA
                    prop.text "stop-a"
                    prop.onClick (fun _ -> dispatch StopA)
                ]

                Html.button [
                    prop.testId TestIds.FireA
                    prop.text "fire-a"
                    prop.onClick (fun _ -> dispatchCustomEvent "dynamic-sub-a")
                ]

                Html.button [
                    prop.testId TestIds.FireB
                    prop.text "fire-b"
                    prop.onClick (fun _ -> dispatchCustomEvent "dynamic-sub-b")
                ]

                Html.h1 [ prop.testId TestIds.CountA; prop.text model.CountA ]
                Html.h2 [ prop.testId TestIds.CountB; prop.text model.CountB ]
            ]

describe "UseElmishNext dynamic subscription diff"
<| fun () ->
    testPromise "UseElmishNext_Subscription_DynamicIds_StopRemovedSubOnly"
    <| fun () -> promise {
        let render = RTL.render (DynamicSubscriptionDiffHarness.Child.Render())

        do! userEvent.click (render.getByTestId TestIds.FireA)
        do! userEvent.click (render.getByTestId TestIds.FireB)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.CountA).toHaveTextContent "1"
                expect(render.getByTestId TestIds.CountB).toHaveTextContent "1"
            )

        do! userEvent.click (render.getByTestId TestIds.StopA)
        do! userEvent.click (render.getByTestId TestIds.FireA)
        do! userEvent.click (render.getByTestId TestIds.FireB)
        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.CountA).toHaveTextContent "1"
        expect(render.getByTestId TestIds.CountB).toHaveTextContent "2"
    }
