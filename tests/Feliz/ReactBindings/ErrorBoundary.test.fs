module Tests.ReactBindings.ErrorBoundaryTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =
    [<ReactComponent>]
    static member Bomb(shouldThrow: bool) =
        if shouldThrow then
            failwith "boom"

        Html.p [ prop.testId "content"; prop.text "content" ]

    /// Throws while `isThrowing` returns true; the flag lives outside React so `reset` can render the children again.
    [<ReactComponent>]
    static member Recoverable(isThrowing: unit -> bool) =
        if isThrowing () then
            failwith "recoverable"

        Html.p [ prop.testId "content"; prop.text "recovered" ]

    [<ReactComponent>]
    static member ResetByKey() =
        let attempt, setAttempt = React.useState 0

        Html.div [
            Html.button [
                prop.testId "retry"
                prop.onClick (fun _ -> setAttempt (attempt + 1))
                prop.text "Retry"
            ]
            React.ErrorBoundary(
                [ Components.Bomb((attempt = 0)) ],
                Html.p [ prop.testId "fallback"; prop.text "failed" ],
                resetKeys = [| box attempt |]
            )
        ]

/// React logs every caught error with `console.error`; keep the test output readable.
let private silenceConsoleError () =
    let spy = vi.spyOn (console, "error")
    spy?mockImplementation (fun () -> ()) |> ignore
    spy

describe "ErrorBoundary"
<| fun _ ->
    test "renders the children when nothing throws"
    <| fun _ ->
        RTL.render (React.ErrorBoundary([ Components.Bomb(false) ], Html.p "fallback"))
        |> ignore

        expect(RTL.screen.getByTestId "content").toHaveTextContent "content"

    test "renders the fallback element when a child throws"
    <| fun _ ->
        let spy = silenceConsoleError ()

        RTL.render (
            React.ErrorBoundary([ Components.Bomb(true) ], Html.p [ prop.testId "fallback"; prop.text "failed" ])
        )
        |> ignore

        expect(RTL.screen.getByTestId "fallback").toHaveTextContent "failed"
        expect(RTL.screen.queryByTestId "content" |> Option.isNone).toBe true
        spy?mockRestore () |> ignore

    test "passes the error to a fallback function"
    <| fun _ ->
        let spy = silenceConsoleError ()

        RTL.render (
            React.ErrorBoundary(
                [ Components.Bomb(true) ],
                (fun props -> Html.p [ prop.testId "fallback"; prop.text props.error.Message ])
            )
        )
        |> ignore

        expect(RTL.screen.getByTestId "fallback").toHaveTextContent "boom"
        spy?mockRestore () |> ignore

    test "calls onError with the error and the component stack"
    <| fun _ ->
        let spy = silenceConsoleError ()
        let mutable caught: (string * string) option = None

        RTL.render (
            React.ErrorBoundary(
                [ Components.Bomb(true) ],
                Html.p "fallback",
                onError = fun error info -> caught <- Some(error.Message, info.componentStack)
            )
        )
        |> ignore

        match caught with
        | Some(message, componentStack) ->
            expect(message).toBe "boom"
            expect(componentStack).toContain "Bomb"
        | None -> failwith "onError was not called"

        spy?mockRestore () |> ignore

    testPromise "renders the children again after reset"
    <| fun _ -> promise {
        let spy = silenceConsoleError ()
        let mutable throwing = true
        let onReset: unit -> unit = vi.fn (fun () -> ())

        RTL.render (
            React.ErrorBoundary(
                [ Components.Recoverable(fun () -> throwing) ],
                (fun props ->
                    Html.button [
                        prop.testId "reset"
                        prop.onClick (fun _ -> props.reset ())
                        prop.text "Try again"
                    ]
                ),
                onReset = onReset
            )
        )
        |> ignore

        throwing <- false
        do! userEvent.click (RTL.screen.getByTestId "reset")

        expect(RTL.screen.getByTestId "content").toHaveTextContent "recovered"
        expect(onReset).toHaveBeenCalledTimes 1
        spy?mockRestore () |> ignore
    }

    testPromise "resets when resetKeys change"
    <| fun _ -> promise {
        let spy = silenceConsoleError ()

        RTL.render (Components.ResetByKey()) |> ignore
        expect(RTL.screen.getByTestId "fallback").toHaveTextContent "failed"

        do! userEvent.click (RTL.screen.getByTestId "retry")

        expect(RTL.screen.getByTestId "content").toHaveTextContent "content"
        spy?mockRestore () |> ignore
    }
