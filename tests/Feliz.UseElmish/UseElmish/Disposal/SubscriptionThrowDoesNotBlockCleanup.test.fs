module UseElmishDisposalSubscriptionThrowTests

open System
open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let ChildMounted = "child-mounted"

    [<Literal>]
    let FirstDisposeAttempts = "first-dispose-attempts"

    [<Literal>]
    let SecondDisposeCount = "second-dispose-count"

    [<Literal>]
    let ModelDisposeCount = "model-dispose-count"

    [<Literal>]
    let ErrorCount = "error-count"

module DisposalThrowHarness =
    open Elmish
    open Feliz.UseElmish

    type Model(onDispose: unit -> unit) =
        interface IDisposable with
            member _.Dispose() = onDispose ()

    type Msg = | Noop

    let init (onModelDispose: unit -> unit) () = new Model(onModelDispose), Cmd.none

    let update _msg (model: Model) = model, Cmd.none

    let subscribe (onFirstDisposeAttempt: unit -> unit) (onSecondDispose: unit -> unit) (_model: Model) : Sub<Msg> = [
        [ "first-throws" ],
        (fun _dispatch ->
            { new IDisposable with
                member _.Dispose() =
                    onFirstDisposeAttempt ()
                    failwith "first subscription dispose failed"
            }
        )

        [ "second-ok" ],
        (fun _dispatch ->
            { new IDisposable with
                member _.Dispose() = onSecondDispose ()
            }
        )
    ]

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render
            (
                onFirstDisposeAttempt: unit -> unit,
                onSecondDispose: unit -> unit,
                onModelDispose: unit -> unit,
                onError: (string * exn) -> unit
            ) =
            let _, _ =
                React.useElmish (
                    init onModelDispose,
                    update,
                    subscribe onFirstDisposeAttempt onSecondDispose,
                    onError = onError
                )

            Html.h1 [ prop.testId TestIds.ChildMounted; prop.text "mounted" ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let firstDisposeAttempts, setFirstDisposeAttempts = React.useStateWithUpdater 0
            let secondDisposeCount, setSecondDisposeCount = React.useStateWithUpdater 0
            let modelDisposeCount, setModelDisposeCount = React.useStateWithUpdater 0
            let errorCount, setErrorCount = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.h2 [
                    prop.testId TestIds.FirstDisposeAttempts
                    prop.text firstDisposeAttempts
                ]
                Html.h2 [
                    prop.testId TestIds.SecondDisposeCount
                    prop.text secondDisposeCount
                ]
                Html.h2 [
                    prop.testId TestIds.ModelDisposeCount
                    prop.text modelDisposeCount
                ]
                Html.h2 [ prop.testId TestIds.ErrorCount; prop.text errorCount ]

                if showChild then
                    Child.Render(
                        (fun () -> setFirstDisposeAttempts (fun previous -> previous + 1)),
                        (fun () -> setSecondDisposeCount (fun previous -> previous + 1)),
                        (fun () -> setModelDisposeCount (fun previous -> previous + 1)),
                        (fun _ -> setErrorCount (fun previous -> previous + 1))
                    )
            ]

describe "UseElmish disposal robustness for throwing subscription dispose"
<| fun () ->
    testPromise "UseElmish_Disposal_SubscriptionThrow_DoesNotBlockRemainingCleanup"
    <| fun () -> promise {
        let render = RTL.render (DisposalThrowHarness.Parent.Render())

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ChildMounted).toHaveTextContent "mounted")

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildMounted |> Option.isNone).toBeTruthy ())
        do! RTL.act (fun () -> PromiseTest.delay 50)

        expect(render.getByTestId TestIds.FirstDisposeAttempts).toHaveTextContent "1"
        expect(render.getByTestId TestIds.SecondDisposeCount).toHaveTextContent "1"
        expect(render.getByTestId TestIds.ModelDisposeCount).toHaveTextContent "1"

        let errorCount = render.getByTestId(TestIds.ErrorCount).textContent |> int
        expect(errorCount >= 1).toBeTruthy ()
    }
