module UseElmishCmdOfEffectTests

open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Count = "count"

    [<Literal>]
    let Status = "status"

    [<Literal>]
    let TriggerSingle = "trigger-single"

    [<Literal>]
    let TriggerBatch = "trigger-batch"

    [<Literal>]
    let TriggerThrow = "trigger-throw"

    [<Literal>]
    let TriggerManual = "trigger-manual"

module EffectHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = { Count: int; Status: string }

    type Msg =
        | TriggerSingle
        | TriggerBatch
        | TriggerThrow
        | TriggerManual
        | EffectTick

    let init () =
        { Count = 0; Status = "idle" }, Cmd.none

    let initWithEffect () =
        { Count = 0; Status = "idle" }, Cmd.ofEffect (fun dispatch -> dispatch EffectTick)

    let update msg state =
        match msg with
        | TriggerSingle -> state, Cmd.ofEffect (fun dispatch -> dispatch EffectTick)
        | TriggerBatch ->
            state,
            Cmd.ofEffect (fun dispatch ->
                dispatch EffectTick
                dispatch EffectTick
            )
        | TriggerThrow -> state, Cmd.ofEffect (fun _ -> failwith "effect boom")
        | TriggerManual ->
            {
                state with
                    Count = state.Count + 1
                    Status = "manual"
            },
            Cmd.none
        | EffectTick ->
            {
                state with
                    Count = state.Count + 1
                    Status = "effect"
            },
            Cmd.none

    [<ReactComponent>]
    let Render () =
        let model, dispatch = React.useElmish (init, update)

        Html.div [
            Html.h1 [ prop.testId TestIds.Count; prop.text model.Count ]

            Html.h2 [ prop.testId TestIds.Status; prop.text model.Status ]

            Html.button [
                prop.testId TestIds.TriggerSingle
                prop.text "single"
                prop.onClick (fun _ -> dispatch TriggerSingle)
            ]

            Html.button [
                prop.testId TestIds.TriggerBatch
                prop.text "batch"
                prop.onClick (fun _ -> dispatch TriggerBatch)
            ]

            Html.button [
                prop.testId TestIds.TriggerThrow
                prop.text "throw"
                prop.onClick (fun _ -> dispatch TriggerThrow)
            ]

            Html.button [
                prop.testId TestIds.TriggerManual
                prop.text "manual"
                prop.onClick (fun _ -> dispatch TriggerManual)
            ]
        ]

    [<ReactComponent>]
    let RenderWithInitEffect () =
        let model, _ = React.useElmish (initWithEffect, update)

        Html.div [
            Html.h1 [ prop.testId TestIds.Count; prop.text model.Count ]

            Html.h2 [ prop.testId TestIds.Status; prop.text model.Status ]
        ]

describeTags "UseElmish Cmd.ofEffect" [ "activeDev" ]
<| fun () ->
    testPromise "Cmd.ofEffect dispatches one message"
    <| fun () -> promise {
        let render = RTL.render (EffectHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.TriggerSingle)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "effect"
            )
    }

    testPromise "Cmd.ofEffect can dispatch multiple messages"
    <| fun () -> promise {
        let render = RTL.render (EffectHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.TriggerBatch)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "2"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "effect"
            )
    }

    testPromise "Cmd.ofEffect exception does not break later updates"
    <| fun () -> promise {
        let render = RTL.render (EffectHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.TriggerThrow)
        do! userEvent.click (render.getByTestId TestIds.TriggerManual)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "manual"
            )
    }

    testPromise "Cmd.ofEffect in init executes on mount"
    <| fun () -> promise {
        let render = RTL.render (EffectHarness.RenderWithInitEffect())

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "effect"
            )
    }

