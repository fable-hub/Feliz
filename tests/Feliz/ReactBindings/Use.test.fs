module Tests.ReactBindings.UseTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open Vitest.PromiseTest

let ThemeContext = React.createContext "light"

[<Import("act", "react")>]
let private reactAct (callback: unit -> JS.Promise<unit>) : obj = jsNative

/// React 19 requires an awaited `act` when a component suspends on its first render. `act` returns a bare
/// thenable that doesn't chain, so it is wrapped in a real promise for the `promise { }` builder.
let private act (callback: unit -> JS.Promise<unit>) : JS.Promise<unit> =
    emitJsExpr (reactAct callback) "Promise.resolve($0)"

type Components =
    [<ReactComponent>]
    static member Message(messagePromise: JS.Promise<string>) =
        let message = React.use' messagePromise
        Html.p [ prop.testId "message"; prop.text message ]

    [<ReactComponent>]
    static member SuspendedMessage(messagePromise: JS.Promise<string>) =
        React.Suspense(
            [ Components.Message(messagePromise) ],
            Html.p [ prop.testId "fallback"; prop.text "Loading..." ]
        )

    [<ReactComponent>]
    static member ConditionalTheme(readTheme: bool) =
        // `use'` may be called conditionally, unlike `useContext`.
        if readTheme then
            let theme = React.use' ThemeContext
            Html.p [ prop.testId "theme"; prop.text theme ]
        else
            Html.p [ prop.testId "theme"; prop.text "not read" ]

describe "use'"
<| fun _ ->
    testPromise "suspends until the promise resolves"
    <| fun _ -> promise {
        let message = deferred<string>()

        do! act (fun () -> promise { RTL.render (Components.SuspendedMessage(message.promise)) |> ignore })

        expect(RTL.screen.getByTestId "fallback").toHaveTextContent "Loading..."

        do! act (fun () -> promise { message.resolve "Hello from a promise" })

        expect(RTL.screen.getByTestId "message").toHaveTextContent "Hello from a promise"
    }

    testPromise "lets the nearest error boundary handle a rejected promise"
    <| fun _ -> promise {
        let consoleSpy = vi.spyOn (Browser.Dom.console, "error")
        consoleSpy?mockImplementation (fun () -> ()) |> ignore
        let message = deferred<string>()

        do!
            act (fun () -> promise {
                RTL.render (
                    React.ErrorBoundary(
                        [ Components.SuspendedMessage(message.promise) ],
                        (fun props -> Html.p [ prop.testId "error"; prop.text props.error.Message ])
                    )
                )
                |> ignore
            })

        do! act (fun () -> promise { message.rejectExn (exn "request failed") })

        expect(RTL.screen.getByTestId "error").toHaveTextContent "request failed"
        consoleSpy?mockRestore () |> ignore
    }

    test "reads a context conditionally"
    <| fun _ ->
        RTL.render (ThemeContext.Provider("dark", Components.ConditionalTheme(true)))
        |> ignore

        expect(RTL.screen.getByTestId "theme").toHaveTextContent "dark"

    test "skips reading a context"
    <| fun _ ->
        RTL.render (ThemeContext.Provider("dark", Components.ConditionalTheme(false)))
        |> ignore

        expect(RTL.screen.getByTestId "theme").toHaveTextContent "not read"
