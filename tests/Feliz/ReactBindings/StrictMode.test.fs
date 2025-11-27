module Tests.ReactBindings.StrictModeTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =

    [<ReactComponent>]
    static member ComponentStrictWithEffect(onInit: unit -> unit) =
        React.useEffect((fun () -> onInit()), [||])

        Html.div [
            prop.testId "strict-effect"
            prop.text "This component uses StrictMode with an effect"
        ]

describe "Strict Mode with Effect" <| fun _ ->
    testPromise "calls effect once on mount in StrictMode" <| fun _ -> promise {
        let effect: unit -> unit = vi.fn(fun () -> ())
        let render = RTL.render (React.StrictMode [
            Components.ComponentStrictWithEffect(effect)
        ])

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 2 //"Effect should be called once on mount"
    }
