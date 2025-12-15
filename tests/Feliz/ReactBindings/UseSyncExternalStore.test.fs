module Tests.ReactBindings.UseSyncExternalStoreTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Browser.Types
open Vitest
open System


type Components =
    [<ReactComponent>]
    static member ComponentUseSyncExternalStoreWithUnmount(subscribe: unit -> unit, snapshot: unit -> unit, dispose: unit -> unit) =
        React.useSyncExternalStore(
            (fun (_) ->
                subscribe()
                dispose
            ),
            snapshot
        )
        

        Html.div [

        ]

    [<ReactComponent>]
    static member ComponentUseSyncExternalStoreIDisposable(subscribe: unit  -> unit, snapshot: unit -> unit, dispose: unit -> unit) =
        React.useSyncExternalStore(
            (fun (_) ->
                subscribe()
                FsReact.createDisposable(dispose)
            ),
            snapshot
        )
        

        Html.div [

        ]

       
    [<ReactComponent>]
    static member ComponentUseSyncExternalStoreWidth(subscribe: (unit -> unit) -> #IDisposable, snapshot: unit -> 't) =
        let value = React.useSyncExternalStore(
            subscribe,
            snapshot
        )
        
        Html.div [
            Html.h1 [
                prop.testId "width-value"
                prop.text (value.ToString())
            ]
        ]

describe "useSyncExternalStore" <| fun _ ->
    testPromise "calls subscribe and snapshot on mount and dispose on unmount" <| fun _ -> promise {

        let subscribe: unit -> unit = vi.fn(fun () -> ())
        let snapshot: unit -> unit = vi.fn(fun () -> ())
        let dispose: unit -> unit = vi.fn(fun () -> ())

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseSyncExternalStoreWithUnmount(subscribe, snapshot, dispose)
        )

        // Check that effect was called once on mount
        expect(subscribe).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(snapshot).toHaveBeenCalled()
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(subscribe).toHaveBeenCalledTimes 1
        expect(snapshot).toHaveBeenCalled()
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls subscribe and snapshot on mount and IDisposable.Dispose() on unmount" <| fun _ -> promise {

        let subscribe: unit -> unit = vi.fn(fun () -> ())
        let snapshot: unit -> unit = vi.fn(fun () -> ())
        let dispose: unit -> unit = vi.fn(fun () -> ())

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseSyncExternalStoreIDisposable(subscribe, snapshot, dispose)
        )

        // Check that effect was called once on mount
        expect(subscribe).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(snapshot).toHaveBeenCalled()
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(subscribe).toHaveBeenCalledTimes 1
        expect(snapshot).toHaveBeenCalled()
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "updates external store using browser events" <| fun _ -> promise {

        let subscribe = fun (callback: unit -> unit) -> 
            let handler = fun (_: Browser.Types.Event) -> callback()
            window.addEventListener("resize", handler)
            FsReact.createDisposable(fun () -> window.removeEventListener("resize", handler))
        
        let snapshot: unit -> float = fun () -> window.innerWidth

        // Set the window width to a known value
        window.innerWidth <- 600

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseSyncExternalStoreWidth(subscribe, snapshot)
        )

        let value = RTL.screen.getByTestId("width-value")
        expect(value).toHaveTextContent "600"

        // Change the window width
        window.innerWidth <- 900

        // Trigger the resize event
        do! RTL.act(fun () -> promise {
            let event = Event.Create("resize")
            window.dispatchEvent(event) |> ignore
        })

        // Check that the value has been updated
        do! RTL.waitFor((fun () -> 
            expect(value).toHaveTextContent "900"
        ), RTLWaitForOptions(timeout=100))

    }

