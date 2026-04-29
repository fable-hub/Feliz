module UseElmishNextStrictModeInFlightPromiseIsolationTests

open System.Collections.Generic
open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Count = "count"

    [<Literal>]
    let EffectCount = "effect-count"

module StrictModePromiseIsolationHarness =
    open Elmish
    open Feliz.UseElmishNext

    let private pendingDeferreds = ResizeArray<PromiseTest.Deferred<int>>()

    let reset () = pendingDeferreds.Clear()

    let deferredCount () = pendingDeferreds.Count

    let resolveAt index value = pendingDeferreds[index].resolve value

    type Model = { Count: int }

    type Msg = PromiseSucceeded of int

    let init () =
        let deferred = PromiseTest.deferred<int> ()
        pendingDeferreds.Add deferred
        { Count = 0 }, Cmd.OfPromise.perform (fun (d: PromiseTest.Deferred<int>) -> d.promise) deferred PromiseSucceeded

    let update (onEffect: int -> unit) msg model =
        match msg with
        | PromiseSucceeded value ->
            onEffect value

            {
                model with
                    Count = model.Count + value
            },
            Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(onEffect: int -> unit) =
            let model, _ = React.useElmishNext (init, update onEffect)

            Html.h1 [ prop.testId TestIds.Count; prop.text model.Count ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let effectCount, setEffectCount = React.useStateWithUpdater 0

            Html.div [
                Html.h1 [ prop.testId TestIds.EffectCount; prop.text effectCount ]

                Child.Render(fun _ -> setEffectCount (fun previous -> previous + 1))
            ]

describe "UseElmishNext strict mode in-flight promise isolation"
<| fun () ->
    testPromise "UseElmishNext_StrictMode_InFlightPromise_NoGhostSideEffects"
    <| fun () -> promise {
        StrictModePromiseIsolationHarness.reset ()

        let render =
            RTL.render (React.StrictMode [ StrictModePromiseIsolationHarness.Parent.Render() ])

        do! RTL.waitFor (fun () -> expect(StrictModePromiseIsolationHarness.deferredCount () >= 2).toBeTruthy ())

        StrictModePromiseIsolationHarness.resolveAt 0 1
        do! RTL.act (fun () -> PromiseTest.delay 40)

        expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
        expect(render.getByTestId TestIds.EffectCount).toHaveTextContent "0"

        let activeIndex = StrictModePromiseIsolationHarness.deferredCount () - 1
        StrictModePromiseIsolationHarness.resolveAt activeIndex 1

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.EffectCount).toHaveTextContent "1"
            )
    }
