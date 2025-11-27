module Tests.ReactBindings.UseLayoutEffectTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =
    [<ReactComponent>]
    static member ComponentUseLayoutEffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffect(
            (fun () ->
                effect()
                fun () -> disposeEffect()
            )
        )

        Html.div [

        ]

    [<ReactComponent>]
    static member ComponentUseLayoutEffectIDisposable(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffectOnce(
            (fun () ->
                effect()
                FsReact.createDisposable(disposeEffect)
            )
        )

        Html.div [

        ]

describe "useLayoutEffect" <| fun _ ->
    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> ())
        let dispose: unit -> unit = vi.fn(fun () -> ())

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseLayoutEffectWithUnmount(effect, dispose)
        )

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls effect on mount and IDisposable.Dispose() on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> ())
        let dispose: unit -> unit = vi.fn(fun () -> ())

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseLayoutEffectIDisposable(effect, dispose)
        )

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }
