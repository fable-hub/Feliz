module UseElmishUnmountInFlightEitherErrorTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Trigger = "trigger-either"

    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let RejectDeferred = "reject-deferred"

    [<Literal>]
    let ErrorCount = "error-count"

module private PendingEitherErrorUnmountHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = { Status: string }

    type Msg =
        | TriggerEither
        | PromiseSucceeded of int
        | PromiseFailed of string

    let init () = { Status = "idle" }, Cmd.none

    let update (deferred: PromiseTest.Deferred<int>) (onError: string -> unit) msg model =
        match msg with
        | TriggerEither ->
            model,
            Cmd.OfPromise.either
                (fun (d: PromiseTest.Deferred<int>) -> d.promise)
                deferred
                PromiseSucceeded
                (fun _ -> PromiseFailed "either-error")
        | PromiseSucceeded _ ->
            {
                model with
                    Status = "unexpected-success"
            },
            Cmd.none
        | PromiseFailed reason ->
            onError reason
            { model with Status = reason }, Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(deferred: PromiseTest.Deferred<int>, onError: string -> unit) =
            let model, dispatch = React.useElmish (init, update deferred onError)

            Html.div [
                Html.h1 [ prop.text model.Status ]

                Html.button [
                    prop.testId TestIds.Trigger
                    prop.text "trigger"
                    prop.onClick (fun _ -> dispatch TriggerEither)
                ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let errorCount, setErrorCount = React.useStateWithUpdater 0
            let deferredRef = React.useRef (PromiseTest.deferred<int> ())

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.button [
                    prop.testId TestIds.RejectDeferred
                    prop.text "reject"
                    prop.onClick (fun _ -> deferredRef.current.rejectExn (System.Exception "boom"))
                ]

                Html.h1 [ prop.testId TestIds.ErrorCount; prop.text errorCount ]

                if showChild then
                    Child.Render(deferredRef.current, (fun _ -> setErrorCount (fun previous -> previous + 1)))
            ]

describe "UseElmish unmount in-flight either error"
<| fun () ->
    testPromise "UseElmish_Unmount_InFlightEitherError_IgnoresErrorPath"
    <| fun () -> promise {
        let render = RTL.render (PendingEitherErrorUnmountHarness.Parent.Render())

        do! userEvent.click (render.getByTestId TestIds.Trigger)
        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.Trigger |> Option.isNone).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.RejectDeferred)
        do! RTL.act (fun () -> PromiseTest.delay 40)

        expect(render.getByTestId TestIds.ErrorCount).toHaveTextContent "0"
    }

