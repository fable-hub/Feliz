module UseElmishUnmountInFlightPerformTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Trigger = "trigger-perform"

    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let ResolveDeferred = "resolve-deferred"

    [<Literal>]
    let SuccessCount = "success-count"

module private PendingPerformUnmountHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = { Status: string }

    type Msg =
        | TriggerPerform
        | PromiseSucceeded of int

    let init () = { Status = "idle" }, Cmd.none

    let update (deferred: PromiseTest.Deferred<int>) (onSuccess: int -> unit) msg model =
        match msg with
        | TriggerPerform ->
            let cmd =
                Cmd.OfPromise.perform (fun (d: PromiseTest.Deferred<int>) -> d.promise) deferred PromiseSucceeded

            model, cmd
        | PromiseSucceeded value ->
            onSuccess value
            { model with Status = "success" }, Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(deferred: PromiseTest.Deferred<int>, onSuccess: int -> unit) =
            let model, dispatch = React.useElmish (init, update deferred onSuccess)

            Html.div [
                Html.h1 [ prop.text model.Status ]

                Html.button [
                    prop.testId TestIds.Trigger
                    prop.text "trigger"
                    prop.onClick (fun _ -> dispatch TriggerPerform)
                ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let successCount, setSuccessCount = React.useStateWithUpdater 0
            let deferredRef = React.useRef (PromiseTest.deferred<int> ())

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.button [
                    prop.testId TestIds.ResolveDeferred
                    prop.text "resolve"
                    prop.onClick (fun _ -> deferredRef.current.resolve 42)
                ]

                Html.h1 [ prop.testId TestIds.SuccessCount; prop.text successCount ]

                if showChild then
                    Child.Render(deferredRef.current, (fun _ -> setSuccessCount (fun previous -> previous + 1)))
            ]

describe "UseElmish unmount in-flight perform"
<| fun () ->
    testPromise "UseElmish_Unmount_InFlightPerform_IgnoresResult"
    <| fun () -> promise {
        let render = RTL.render (PendingPerformUnmountHarness.Parent.Render())

        do! userEvent.click (render.getByTestId TestIds.Trigger)
        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.Trigger |> Option.isNone).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.ResolveDeferred)
        do! RTL.act (fun () -> PromiseTest.delay 40)

        expect(render.getByTestId TestIds.SuccessCount).toHaveTextContent "0"
    }

