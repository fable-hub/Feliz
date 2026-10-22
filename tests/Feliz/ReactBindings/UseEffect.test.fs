module Tests.ReactBindings.UseEffectTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module Components =

    type UseEffect =

        [<ReactComponent>]
        static member EffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
            React.useEffect (
                (fun () ->
                    effect ()
                    fun () -> disposeEffect ()
                )
            )

            Html.div [

                ]

        /// #714
        [<ReactComponent>]
        static member OnlyCleanup(disposeEffect: unit -> unit) =
            React.useEffect ((fun () -> fun () -> disposeEffect ()), [||])

            Html.div [

                ]

        [<ReactComponent>]
        static member EffectfulTimer() =
            let (paused, setPaused) = React.useState (false)
            // using useStateWithUpdater instead of useState
            // to avoid stale closures in React.useEffect
            let (value, setValue) = React.useStateWithUpdater (0)

            let subscribeToTimer () =
                // start the timer
                let subscriptionId =
                    Fable.Core.JS.setInterval
                        (fun _ ->
                            if not paused then
                                setValue (fun prev -> prev + 1)
                        )
                        1000
                // return IDisposable with cleanup code that stops the timer
                {
                    new System.IDisposable with
                        member this.Dispose() =
                            Fable.Core.JS.clearInterval (subscriptionId)
                }

            React.useEffect (subscribeToTimer, [| box paused |])

            Html.div [
                Html.h1 [ prop.testId "timer-value"; prop.text value ]

                Html.button [
                    prop.testId "pause-button"
                    prop.style [
                        if paused then
                            style.backgroundColor "yellow"
                        else
                            style.backgroundColor "green"
                    ]

                    prop.onClick (fun _ -> setPaused (not paused))
                    prop.text (if paused then "Resume" else "Pause")
                ]
            ]


    type UseEffectOnce =

        [<ReactComponent>]
        static member EffectWithIDisposableCleanup(effect: unit -> unit, disposeEffect: unit -> unit) =
            React.useEffectOnce (
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
            React.useEffectOnce ((fun () -> fun () -> disposeEffect ()))

            Html.div [

                ]


describe "useEffect"
<| fun _ ->
    testPromise "calls effect on mount and disposeEffect on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseEffect.EffectWithUnmount(effect, dispose))

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
        let renderResult = RTL.render (Components.UseEffect.OnlyCleanup(dispose))

        // Check that effect was called once on mount
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "IDisposable return calls Dispose() function"
    <| fun _ -> promise {
        RTL.render (Components.UseEffect.EffectfulTimer()) |> ignore

        let value = RTL.screen.getByTestId ("timer-value")
        let button = RTL.screen.getByTestId ("pause-button")

        do! RTL.act (fun () -> promise { do! Promise.sleep 2200 })

        let initial = int value.textContent
        expect(initial).toBeGreaterThan 0

        do! userEvent.click (button) // Pause

        do! RTL.act (fun () -> promise { do! Promise.sleep 2000 })

        let afterPause = int value.textContent
        expect(afterPause).toBe initial
    }

describe "useEffectOnce"
<| fun _ ->

    testPromise "calls effect on mount and IDisposable.Dispose() on unmount"
    <| fun _ -> promise {

        let effect: unit -> unit = vi.fn (fun () -> ())
        let dispose: unit -> unit = vi.fn (fun () -> ())

        // Render the component
        let renderResult =
            RTL.render (Components.UseEffectOnce.EffectWithIDisposableCleanup(effect, dispose))

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
        let renderResult = RTL.render (Components.UseEffectOnce.OnlyCleanup(dispose))

        // Check that effect was called once on mount
        expect(dispose).toHaveBeenCalledTimes 0

        // Unmount the component
        renderResult.unmount ()

        // Check that disposeEffect was called once on unmount
        expect(dispose).toHaveBeenCalledTimes 1
    }
