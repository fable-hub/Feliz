module UseElmishNextDependencyChangeOldPromiseIsolationTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Instance = "instance"

    [<Literal>]
    let Count = "count"

    [<Literal>]
    let ReportCount = "report-count"

    [<Literal>]
    let LastSource = "last-source"

    [<Literal>]
    let Trigger = "trigger"

    [<Literal>]
    let SwapDependency = "swap-dependency"

    [<Literal>]
    let ResolveOld = "resolve-old"

    [<Literal>]
    let ResolveCurrent = "resolve-current"

module private DependencySwapPromiseIsolationHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = { Count: int; Instance: int }

    type Msg =
        | Trigger
        | PromiseSucceeded of int

    let init (instance: int) =
        { Count = 0; Instance = instance }, Cmd.none

    let update (getDeferred: int -> PromiseTest.Deferred<int>) (reportSource: int -> unit) msg model =
        match msg with
        | Trigger ->
            model,
            Cmd.OfPromise.perform
                (fun (deferred: PromiseTest.Deferred<int>) -> deferred.promise)
                (getDeferred model.Instance)
                PromiseSucceeded
        | PromiseSucceeded value ->
            reportSource model.Instance

            {
                model with
                    Count = model.Count + value
            },
            Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(instance: int, getDeferred: int -> PromiseTest.Deferred<int>, reportSource: int -> unit) =
            let model, dispatch =
                React.useElmishNext (init, update getDeferred reportSource, instance, dependencies = [| box instance |])

            Html.div [
                Html.h1 [ prop.testId TestIds.Instance; prop.text model.Instance ]

                Html.h2 [ prop.testId TestIds.Count; prop.text model.Count ]

                Html.button [
                    prop.testId TestIds.Trigger
                    prop.text "trigger"
                    prop.onClick (fun _ -> dispatch Trigger)
                ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let instance, setInstance = React.useState 0
            let reportCount, setReportCount = React.useStateWithUpdater 0
            let lastSource, setLastSource = React.useState "none"
            let deferredA = React.useRef (PromiseTest.deferred<int> ())
            let deferredB = React.useRef (PromiseTest.deferred<int> ())

            let getDeferred i =
                if i = 0 then deferredA.current else deferredB.current

            let reportSource source =
                setReportCount (fun previous -> previous + 1)
                setLastSource (string source)

            Html.div [
                Html.button [
                    prop.testId TestIds.SwapDependency
                    prop.text "swap"
                    prop.onClick (fun _ -> setInstance 1)
                ]

                Html.button [
                    prop.testId TestIds.ResolveOld
                    prop.text "resolve-old"
                    prop.onClick (fun _ -> deferredA.current.resolve 1)
                ]

                Html.button [
                    prop.testId TestIds.ResolveCurrent
                    prop.text "resolve-current"
                    prop.onClick (fun _ -> (getDeferred instance).resolve 1)
                ]

                Html.h1 [ prop.testId TestIds.ReportCount; prop.text reportCount ]

                Html.h2 [ prop.testId TestIds.LastSource; prop.text lastSource ]

                Child.Render(instance, getDeferred, reportSource)
            ]

describe "UseElmishNext dependency reset promise isolation"
<| fun () ->
    testPromise "UseElmishNext_DependencyChange_OldPromiseCompletion_DoesNotTouchNewInstance"
    <| fun () -> promise {
        let render = RTL.render (DependencySwapPromiseIsolationHarness.Parent.Render())

        do! userEvent.click (render.getByTestId TestIds.Trigger)
        do! userEvent.click (render.getByTestId TestIds.SwapDependency)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Instance).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
            )

        do! userEvent.click (render.getByTestId TestIds.ResolveOld)
        do! RTL.act (fun () -> PromiseTest.delay 40)

        expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
        expect(render.getByTestId TestIds.ReportCount).toHaveTextContent "0"

        do! userEvent.click (render.getByTestId TestIds.Trigger)
        do! userEvent.click (render.getByTestId TestIds.ResolveCurrent)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.ReportCount).toHaveTextContent "1"
                expect(render.getByTestId TestIds.LastSource).toHaveTextContent "1"
            )
    }
