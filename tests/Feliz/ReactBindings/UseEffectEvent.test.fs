module Tests.ReactBindings.UseEffectEventTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Browser.Types
open Vitest

let private fireTestEvent () =
    window.dispatchEvent (emitJsExpr () "new Event('feliz-effect-event')") |> ignore

type Components =
    [<ReactComponent>]
    static member EffectEvent(onLog: string -> unit, onEffectRun: unit -> unit) =
        let text, setText = React.useState "first"
        let logLatest = React.useEffectEvent (fun () -> onLog text)

        // Subscribes once; the effect event still sees the latest `text`.
        React.useEffect (
            (fun () ->
                onEffectRun ()
                let handler = fun (_: Event) -> logLatest ()
                window.addEventListener ("feliz-effect-event", handler)
                fun () -> window.removeEventListener ("feliz-effect-event", handler)
            ),
            [||]
        )

        Html.button [
            prop.testId "update"
            prop.onClick (fun _ -> setText "second")
            prop.text text
        ]

    [<ReactComponent>]
    static member EffectEventWithArgument(onLog: string -> unit) =
        let prefix, setPrefix = React.useState "a"
        let log = React.useEffectEvent (fun (value: int) -> onLog (prefix + string value))

        React.useEffect (
            (fun () ->
                let handler = fun (_: Event) -> log 1
                window.addEventListener ("feliz-effect-event", handler)
                fun () -> window.removeEventListener ("feliz-effect-event", handler)
            ),
            [||]
        )

        Html.button [
            prop.testId "update"
            prop.onClick (fun _ -> setPrefix "b")
            prop.text prefix
        ]

describe "useEffectEvent"
<| fun _ ->
    testPromise "reads the latest state without re-running the effect"
    <| fun _ -> promise {
        let onLog: string -> unit = vi.fn (fun _ -> ())
        let onEffectRun: unit -> unit = vi.fn (fun () -> ())

        RTL.render (Components.EffectEvent(onLog, onEffectRun)) |> ignore

        fireTestEvent ()
        expect(onLog).toHaveBeenCalledWith [| "first" |]

        do! userEvent.click (RTL.screen.getByTestId "update")
        expect(RTL.screen.getByTestId "update").toHaveTextContent "second"

        fireTestEvent ()
        expect(onLog).toHaveBeenCalledWith [| "second" |]
        expect(onEffectRun).toHaveBeenCalledTimes 1
    }

    testPromise "passes arguments through"
    <| fun _ -> promise {
        let onLog: string -> unit = vi.fn (fun _ -> ())

        RTL.render (Components.EffectEventWithArgument(onLog)) |> ignore

        fireTestEvent ()
        expect(onLog).toHaveBeenCalledWith [| "a1" |]

        do! userEvent.click (RTL.screen.getByTestId "update")

        fireTestEvent ()
        expect(onLog).toHaveBeenCalledWith [| "b1" |]
    }
