module UseElmishStrictModeInitCmdOfEffectTests

open Feliz
open Vitest
open UseElmish

module StrictModeInitCmdOfEffectHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = { Count: int }
    type Msg = | EffectTick

    let init () =
        { Count = 0 }, Cmd.ofEffect (fun dispatch -> dispatch EffectTick)

    let update msg model =
        match msg with
        | EffectTick -> { model with Count = model.Count + 1 }, Cmd.none

    [<Feliz.ReactComponent>]
    let Render () =
        let model, _ = React.useElmish (init, update)

        Html.h1 [
            prop.testId "strict-init-cmd-count"
            prop.text model.Count
        ]

describe "UseElmish strict mode init Cmd.ofEffect"
<| fun () ->
    testPromise "UseElmish_StrictMode_InitCmdOfEffect_FiresExactlyOnce"
    <| fun () -> promise {
        let render =
            RTL.render (React.StrictMode [ StrictModeInitCmdOfEffectHarness.Render() ])

        do! RTL.waitFor (fun () -> expect(render.getByTestId "strict-init-cmd-count").toHaveTextContent "1")

        // Give extra time for any ghost dispatch to arrive.
        do! RTL.act (fun () -> PromiseTest.delay 60)

        expect(render.getByTestId "strict-init-cmd-count").toHaveTextContent "1"
    }
