module Tests.ReactBindingsTests


open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Fable.ReactTestingLibrary
open Fable.Core
open Feliz.Vitest
open ReactBindings

describe "Counter (useState)" <| fun _ ->
    testPromise "increments count on button click" <| fun _ -> promise {
        let render = RTL.render (Components.ComponentUseState())
        let count = RTL.screen.getByTestId "count"
        let button = RTL.screen.getByTestId "increment"

        Expect.toBe (count.textContent) "0"

        do! RTL.userEvent.click (button)
        Expect.toBe (count.textContent) "1"

        do! RTL.userEvent.click (button)
        Expect.toBe (count.textContent) "2"

    }

describe "FragmentComponent" <| fun _ ->
    testPromise "renders multiple elements from a fragment" <| fun _ -> promise {
        RTL.render (Components.FragmentComponent())
        |> ignore

        let first = RTL.screen.getByTestId "first"
        let second = RTL.screen.getByTestId "second"

        Expect.toBe (first.textContent) "Hello"
        Expect.toBe (second.textContent) "World"
    }

describe "useCallback" <| fun _ ->

    test "should keep the same callback reference if dependencies don't change" <| fun _ ->
        let capturedFns = ResizeArray<unit -> unit>()

        let render =
            RTL.render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        render.rerender (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        Expect.toBe (capturedFns.[0]) capturedFns.[1]

    testPromise "should update callback reference if dependency changes" <| fun _ -> promise {

        let capturedFns = ResizeArray<unit -> unit>()

        let _ = RTL.render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        let incEle = RTL.screen.getByTestId "increment"

        do! RTL.userEvent.click (incEle)

        Expect.expect(capturedFns[0]).``not``.toBe (capturedFns[1])

    }

describe "React Context" <| fun _ ->
    testPromise "provides and consumes context value" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        Expect.toBe (valueDiv.textContent) "Provided value"
    }

    testPromise "updates context via consumer interaction" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        let button = RTL.screen.getByTestId "update-context"

        Expect.toBe valueDiv.textContent "Provided value"

        do! RTL.userEvent.click(button)

        Expect.toBe valueDiv.textContent "Updated value"
    }

describe "ComponentUseRef" <| fun _ ->
    testPromise "updates input value via ref" <| fun _ -> promise {
        RTL.render (Components.ComponentUseInputRef())
        |> ignore

        let input = RTL.screen.getByTestId "my-input" :?> Browser.Types.HTMLInputElement
        let button = RTL.screen.getByTestId "update-button"

        Expect.toBe input.value ""

        do! RTL.userEvent.click button

        Expect.toBe input.value "Updated via ref"
    }

    testPromise "Referencing a value with a ref stores correctly" <| fun _ -> promise {
        let render = RTL.render (Components.ComponentUseRefForValue())

        let countDisplay = RTL.screen.getByTestId "count-display"
        let incRefbutton = RTL.screen.getByTestId "increment-ref-button"
        let updateStateButton = RTL.screen.getByTestId "update-state-button"

        Expect.toBe countDisplay.textContent "0" //state starts with 0

        do! RTL.userEvent.click incRefbutton // only update ref
        Expect.toBe countDisplay.textContent "0"

        do! RTL.userEvent.click incRefbutton // only update ref
        Expect.toBe countDisplay.textContent "0"

        do! RTL.userEvent.click updateStateButton // only update ref
        Expect.toBe countDisplay.textContent "2"
    }

describe "ComponentUseMemo" <| fun _ ->
    testPromise "does not calculate memoized value when count changes" <| fun _ -> promise {
        // Render the component
        let render = RTL.render (Components.ComponentUseMemo())

        // Get elements
        let memoizedValueDiv = RTL.screen.getByTestId "memoized-value"
        let button = RTL.screen.getByTestId "increment-button"
        let count = RTL.screen.getByTestId "count"

        // Initial value should be based on count 0
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 0"

        // Click to increment the count
        do! RTL.userEvent.click button
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 0"

        // Click again, should update the memoized value
        do! RTL.userEvent.click button
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 0"
        Expect.toBe count.textContent "2"

        // Ensure the value is memoized and doesn't change until `count` changes
    }

    testPromise "does calculate memoized value when count changes" <| fun _ -> promise {
        // Render the component
        let render = RTL.render (Components.ComponentUseMemoWithDependency())

        // Get elements
        let memoizedValueDiv = RTL.screen.getByTestId "memoized-value"
        let button = RTL.screen.getByTestId "increment-button"
        let count = RTL.screen.getByTestId "count"

        // Initial value should be based on count 0
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 0"

        // Click to increment the count
        do! RTL.userEvent.click button
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 1"

        // Click again, should update the memoized value
        do! RTL.userEvent.click button
        Expect.toBe memoizedValueDiv.textContent "Memoized count: 2"
        Expect.toBe count.textContent "2"

        // Ensure the value is memoized and doesn't change until `count` changes
    }

describe "useEffect" <| fun _ ->
    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseEffectWithUnmount(effect, dispose)
        )

        // Check that effect was called once on mount
        Expect.toHaveBeenCalledTimes effect 1 //"Effect should be called once on mount"
        Expect.toHaveBeenCalledTimes dispose 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        Expect.toHaveBeenCalledTimes effect 1
        Expect.toHaveBeenCalledTimes dispose 1
    }

    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseEffectWithUnmount(effect, dispose)
        )

        // Check that effect was called once on mount
        Expect.toHaveBeenCalledTimes effect 1 //"Effect should be called once on mount"
        Expect.toHaveBeenCalledTimes dispose 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        Expect.toHaveBeenCalledTimes effect 1
        Expect.toHaveBeenCalledTimes dispose 1
    }

    testPromise "IDisposable return calls Dispose() function" <| fun _ -> promise {
            RTL.render (Components.EffectfulTimer())
            |> ignore

            let value = RTL.screen.getByTestId("timer-value")
            let button = RTL.screen.getByTestId("pause-button")

            do! Promise.sleep 2200
            let initial = int value.textContent
            Expect.toBeGreaterThan initial 0

            do! RTL.userEvent.click(button) // Pause

            do! Promise.sleep 2000
            let afterPause = int value.textContent
            Expect.toBe afterPause initial
        }

describe "useLayoutEffect" <| fun _ ->
    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseLayoutEffectWithUnmount(effect, dispose)
        )

        // Check that effect was called once on mount
        Expect.toHaveBeenCalledTimes effect 1 //"Effect should be called once on mount"
        Expect.toHaveBeenCalledTimes dispose 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        Expect.toHaveBeenCalledTimes effect 1
        Expect.toHaveBeenCalledTimes dispose 1
    }

    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseLayoutEffectWithUnmount(effect, dispose)
        )

        // Check that effect was called once on mount
        Expect.toHaveBeenCalledTimes effect 1 //"Effect should be called once on mount"
        Expect.toHaveBeenCalledTimes dispose 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        Expect.toHaveBeenCalledTimes effect 1
        Expect.toHaveBeenCalledTimes dispose 1
    }

// describe "useCancellationToken" <| fun _ ->
//     testPromise "updates text after cancellation" <| fun _ -> promise {
//         RTL.render (Components.ComponentUseCancelationToken())
//         |> ignore

//         let tokenDiv = RTL.screen.getByTestId "cancellation-token"
//         let button = RTL.screen.getByTestId "unmount-button"

//         // Initially: not cancelled
//         Expect.toBe tokenDiv.textContent "Not Cancelled" //"Token should not be cancelled initially"

//         // Click to unmount subcomponent
//         do! RTL.userEvent.click(button)

//         // Give React a tick to rerender
//         do! RTL.waitFor(fun () ->
//             Expect.toBe tokenDiv.textContent "Cancelled" //"Token should be cancelled after unmount"
//         )
//     }

describe "lazy" <| fun _ ->
    testPromise "loads lazy component with typed text after checkbox is checked" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoad())

        // Ensure loading message is not present initially
        Expect.toBeNull (RTL.screen.queryByText("Loading..."))

        // Type into the input field
        // let input = RTL.screen.getByTestId("input")
        // do! RTL.userEvent.clear(input)
        // do! RTL.userEvent.type'(input, "hello", 50)

        // Click the checkbox to load the lazy component
        let checkbox = RTL.screen.getByTestId("checkbox")
        do! RTL.userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement option>(fun () ->
            RTL.screen.queryByText("Loading...")
            // promise {
            //     let! loading = 
            //     Expect.toHaveTextContent loading "Loadin2g..."
            // }
        )

        Expect.expect(loading).``not``.toBeNull()

        do! RTL.waitFor(fun () ->
            promise {
                // Wait for the lazy component to appear
                let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
                Expect.expect(lazyText).``not``.toBeNull()
            }
            |> Promise.start
        )
    }

    testPromise "loads lazy static member component with typed text after checkbox is checked" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadStaticMember())

        // Ensure loading message is not present initially
        Expect.toBeNull (RTL.screen.queryByText("Loading..."))

        // Type into the input field
        // let input = RTL.screen.getByTestId("input")
        // do! RTL.userEvent.clear(input)
        // do! RTL.userEvent.type'(input, "hello", 50)

        // Click the checkbox to load the lazy component
        let checkbox = RTL.screen.getByTestId("checkbox")
        do! RTL.userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement option>(fun () ->
            RTL.screen.queryByText("Loading...")
            // promise {
            //     let! loading = 
            //     Expect.toHaveTextContent loading "Loadin2g..."
            // }
        )

        Expect.expect(loading).``not``.toBeNull()

        do! RTL.waitFor(fun () ->
            promise {
                // Wait for the lazy component to appear
                let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
                Expect.expect(lazyText).``not``.toBeNull()
            }
            |> Promise.start
        )
    }


describe "Strict Mode with Effect" <| fun _ ->
    testPromise "calls effect once on mount in StrictMode" <| fun _ -> promise {
        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let render = RTL.render (React.StrictMode [
            Components.ComponentStrictWithEffect(effect)
        ])

        // Check that effect was called once on mount
        Expect.toHaveBeenCalledTimes effect 2 //"Effect should be called once on mount"
    }
