module UseElmishModelDisposablePostUnmountDispatchTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("setTimeout($0, $1)")>]
let private scheduleTimeout (callback: unit -> unit) (delay: int) : unit = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let DisposeCount = "dispose-count"

    [<Literal>]
    let ChildMounted = "child-mounted"

module PostUnmountDispatchHarness =
    open Elmish
    open Feliz.UseElmish

    // Non-idempotent: counts every Dispose() call regardless of prior calls.
    // A correct implementation must never call Dispose() more than once.
    type CountingDisposable(onDispose: unit -> unit) =
        interface System.IDisposable with
            member _.Dispose() = onDispose ()

    type Model = CountingDisposable

    type Msg = | DelayedMsg

    // Init schedules a delayed dispatch so it fires after the component unmounts.
    let init (onDispose: unit -> unit) (scheduleDelay: int) () =
        new CountingDisposable(onDispose),
        Cmd.ofEffect (fun dispatch -> scheduleTimeout (fun () -> dispatch DelayedMsg) scheduleDelay)

    let update _msg (model: Model) = model, Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(onDispose: unit -> unit, scheduleDelay: int) =
            let _model, _dispatch = React.useElmish (init onDispose scheduleDelay, update)

            Html.h1 [ prop.testId TestIds.ChildMounted; prop.text "mounted" ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render(onDispose: unit -> unit, scheduleDelay: int) =
            let showChild, setShowChild = React.useState true

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                if showChild then
                    Child.Render(onDispose, scheduleDelay)
            ]

    [<Erase>]
    type Root =
        [<ReactComponent>]
        static member Render() =
            let disposeCount, setDisposeCount = React.useStateWithUpdater 0

            Html.div [
                Html.h2 [ prop.testId TestIds.DisposeCount; prop.text disposeCount ]

                Parent.Render((fun () -> setDisposeCount (fun prev -> prev + 1)), 200)
            ]

describe "UseElmish disposable post-unmount dispatch"
<| fun () ->
    testPromise "UseElmish_ModelDisposable_PostUnmountDispatch_DisposedExactlyOnce"
    <| fun () -> promise {
        let render = RTL.render (PostUnmountDispatchHarness.Root.Render())

        // Wait for child to fully mount and subscribe.
        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ChildMounted).toHaveTextContent "mounted")

        // Unmount the child — DisposeOnUnmount fires, disposeLatestModel() increments count to 1.
        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildMounted |> Option.isNone).toBeTruthy ())

        // disposeLatestModel already ran; disposeCount should be 1 at this point.
        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.DisposeCount).toHaveTextContent "1")

        // Wait for the delayed dispatch to fire (delay=200ms) and settle.
        do! RTL.act (fun () -> PromiseTest.delay 300)

        // The delayed dispatch must NOT trigger a second Dispose().
        expect(render.getByTestId TestIds.DisposeCount).toHaveTextContent "1"
    }
