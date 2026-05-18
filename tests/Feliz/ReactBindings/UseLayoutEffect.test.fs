module Tests.ReactBindings.UseLayoutEffectTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module Components =

    type UseLayoutEffect =
        [<ReactComponent>]
        static member EffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
            React.useLayoutEffect (
                (fun () ->
                    effect ()
                    fun () -> disposeEffect ()
                )
            )

            Html.div [

            ]

        [<ReactComponent>]
        static member EffectWithIDisposable(effect: unit -> unit, disposeEffect: unit -> unit) =
            React.useLayoutEffect (
                (fun () ->
                    effect ()
                    FsReact.createDisposable (disposeEffect)
                )
            )

            Html.div [

            ]

        /// #714
        [<ReactComponent>]
        static member OnlyCleanup(disposeEffect: unit -> unit) =
            React.useLayoutEffect ((fun () -> fun () -> disposeEffect ()), [||])

            Html.div [

            ]

    type UseLayoutEffectOnce =

        [<ReactComponent>]
        static member EffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
            let setup: unit -> (unit -> unit) =
                fun () ->
                    effect ()
                    fun () -> disposeEffect ()

            React.useLayoutEffectOnce (setup)

            Html.div [

            ]

        [<ReactComponent>]
        static member EffectWithIDisposable(effect: unit -> unit, disposeEffect: unit -> unit) =
            React.useLayoutEffectOnce (
                (fun () ->
                    effect ()
                    FsReact.createDisposable (disposeEffect)
                )
            )

            Html.div [

            ]

        /// #714
        [<ReactComponent>]
        static member OnlyCleanup(disposeEffect: unit -> unit) =
            React.useLayoutEffectOnce ((fun () -> fun () -> disposeEffect ()))

            Html.div [

            ]

describe "useLayoutEffect"
<| fun _ ->
    testPromise "calls effect on mount and disposeEffect on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseLayoutEffect.EffectWithUnmount(effect, dispose))

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls effect on mount and IDisposable.Dispose() on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseLayoutEffect.EffectWithIDisposable(effect, dispose))

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls cleanup function on unmount with no function body #714"
    <| fun _ -> promise {

        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult = RTL.render (Components.UseLayoutEffect.OnlyCleanup(dispose))

        // Check that effect was called once on mount
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(dispose).toHaveBeenCalledTimes 1
    }


describe "useLayoutEffectOnce"
<| fun _ ->
    testPromise "cleanup function runs on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseLayoutEffectOnce.EffectWithUnmount(effect, dispose))

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that cleanup was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "IDisposable.Dispose() runs on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseLayoutEffectOnce.EffectWithIDisposable(effect, dispose))

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls cleanup function on unmount with no function body #714"
    <| fun _ -> promise {

        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult = RTL.render (Components.UseLayoutEffectOnce.OnlyCleanup(dispose))

        // Check that effect was called once on mount
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(dispose).toHaveBeenCalledTimes 1
    }
