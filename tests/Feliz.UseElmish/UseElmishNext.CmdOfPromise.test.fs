module UseElmishNextCmdOfPromiseTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("Promise.resolve($0)")>]
let private promiseResolve<'T> (value: 'T) : JS.Promise<'T> = jsNative

[<Emit("Promise.reject(new Error('boom'))")>]
let private promiseReject<'T> () : JS.Promise<'T> = jsNative

[<Emit("new Promise(function(resolve) { setTimeout(resolve, $0); })")>]
let private delay (milliseconds: int) : JS.Promise<unit> = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let Count = "count"

    [<Literal>]
    let Status = "status"

    [<Literal>]
    let Perform = "trigger-perform"

    [<Literal>]
    let EitherSuccess = "trigger-either-success"

    [<Literal>]
    let EitherFailure = "trigger-either-failure"

    [<Literal>]
    let AttemptSuccess = "trigger-attempt-success"

    [<Literal>]
    let AttemptFailure = "trigger-attempt-failure"

module PromiseHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = { Count: int; Status: string }

    type Msg =
        | TriggerPerform
        | TriggerEitherSuccess
        | TriggerEitherFailure
        | TriggerAttemptSuccess
        | TriggerAttemptFailure
        | PromiseSucceeded of int
        | PromiseFailed of string

    let init () =
        { Count = 0; Status = "idle" }, Cmd.none

    let private resolveTask (arg: int) = promiseResolve (arg + 1)

    let private rejectTask (_: int) = promiseReject<int> ()

    let private resolveAttemptTask () = promiseResolve ()

    let private rejectAttemptTask () = promiseReject<unit> ()

    let update msg state =
        match msg with
        | TriggerPerform -> state, Cmd.OfPromise.perform resolveTask state.Count PromiseSucceeded
        | TriggerEitherSuccess ->
            state, Cmd.OfPromise.either resolveTask state.Count PromiseSucceeded (fun _ -> PromiseFailed "either-error")
        | TriggerEitherFailure ->
            state, Cmd.OfPromise.either rejectTask state.Count PromiseSucceeded (fun _ -> PromiseFailed "either-error")
        | TriggerAttemptSuccess ->
            state, Cmd.OfPromise.attempt resolveAttemptTask () (fun _ -> PromiseFailed "attempt-error")
        | TriggerAttemptFailure ->
            state, Cmd.OfPromise.attempt rejectAttemptTask () (fun _ -> PromiseFailed "attempt-error")
        | PromiseSucceeded value ->
            {
                state with
                    Count = value
                    Status = "success"
            },
            Cmd.none
        | PromiseFailed reason -> { state with Status = reason }, Cmd.none

    [<ReactComponent>]
    let Render () =
        let model, dispatch = React.useElmishNext (init, update)

        Html.div [
            Html.h1 [ prop.testId TestIds.Count; prop.text model.Count ]

            Html.h2 [ prop.testId TestIds.Status; prop.text model.Status ]

            Html.button [
                prop.testId TestIds.Perform
                prop.text "perform"
                prop.onClick (fun _ -> dispatch TriggerPerform)
            ]

            Html.button [
                prop.testId TestIds.EitherSuccess
                prop.text "either-success"
                prop.onClick (fun _ -> dispatch TriggerEitherSuccess)
            ]

            Html.button [
                prop.testId TestIds.EitherFailure
                prop.text "either-failure"
                prop.onClick (fun _ -> dispatch TriggerEitherFailure)
            ]

            Html.button [
                prop.testId TestIds.AttemptSuccess
                prop.text "attempt-success"
                prop.onClick (fun _ -> dispatch TriggerAttemptSuccess)
            ]

            Html.button [
                prop.testId TestIds.AttemptFailure
                prop.text "attempt-failure"
                prop.onClick (fun _ -> dispatch TriggerAttemptFailure)
            ]
        ]

describeTags "UseElmishNext Cmd.OfPromise" [ "activeDev" ]
<| fun () ->
    testPromise "Cmd.OfPromise.perform maps success"
    <| fun () -> promise {
        let render = RTL.render (PromiseHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.Perform)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "success"
            )
    }

    testPromise "Cmd.OfPromise.either maps success"
    <| fun () -> promise {
        let render = RTL.render (PromiseHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.EitherSuccess)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "1"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "success"
            )
    }

    testPromise "Cmd.OfPromise.either maps error"
    <| fun () -> promise {
        let render = RTL.render (PromiseHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.EitherFailure)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "either-error"
            )
    }

    testPromise "Cmd.OfPromise.attempt maps rejection"
    <| fun () -> promise {
        let render = RTL.render (PromiseHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.AttemptFailure)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
                expect(render.getByTestId TestIds.Status).toHaveTextContent "attempt-error"
            )
    }

    testPromise "Cmd.OfPromise.attempt ignores successful promise"
    <| fun () -> promise {
        let render = RTL.render (PromiseHarness.Render())

        do! userEvent.click (render.getByTestId TestIds.AttemptSuccess)
        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.Count).toHaveTextContent "0"
        expect(render.getByTestId TestIds.Status).toHaveTextContent "idle"
    }
