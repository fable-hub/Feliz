module SubscriptionTests

open Feliz
open UseElmish
open Vitest


module Subscriber =
    open Elmish
    open Fable.Core.JS

    type Model = {
        Count: int
        SubscriberTicks: int
    }

    type Msg =
        | Increment
        | SubscriberTick

    let init initialValue =
        {
            Count = initialValue
            SubscriberTicks = 0
        },
        Cmd.none

    let update msg (model: Model) =
        match msg with
        | Increment ->
            { model with Count = model.Count + 1 }, Cmd.none
        | SubscriberTick ->
            { model with SubscriberTicks = model.SubscriberTicks + 1 }, Cmd.none

    let subscribeToTimer dispatch =
        let subscriptionId =
            setInterval
                (fun _ -> dispatch SubscriberTick)
                100
        { new System.IDisposable with member _.Dispose() = clearInterval subscriptionId }

    let subscribe _model =
        [ ["timer"], subscribeToTimer ]

    [<ReactComponent>]
    let Render (initialValue: int) =
        let model, dispatch = React.useElmish((fun () -> init initialValue), update, subscribe, [||])

        Html.div [
            Html.h1 [
                prop.testId "count"
                prop.text model.Count
            ]

            Html.h1 [
                prop.testId "subscriber-ticks"
                prop.text model.SubscriberTicks
            ]

            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> dispatch Increment)
                prop.testId "increment"
            ]
        ]

describe "UseElmish with subscriptions" <| fun () ->
    testPromise "Elmish subscriptions work correctly" <| fun () -> promise {
        let render = RTL.render(Subscriber.Render 0)

        expect(render.getByTestId("count")).toHaveTextContent "0" //"Should start with initial count"
        expect(render.getByTestId("subscriber-ticks")).toHaveTextContent "0" //"Should start with 0 subscriber ticks"

        // Wait for subscriber to tick a few times
        do! RTL.act(fun () -> Promise.sleep 350)

        do!
            RTL.waitFor (fun () ->
                let ticks = render.getByTestId("subscriber-ticks").textContent |> int
                expect(ticks >= 3).toBeTruthy() //"Subscriber should have ticked at least 3 times"
            )

        // Click increment button
        render.getByTestId("increment").click()

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId("count")).toHaveTextContent "1" //"Count should have been incremented"
            )
    }
