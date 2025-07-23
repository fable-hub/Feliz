module Tests.ReactBindingsTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest
open ReactBindings


describe "Counter (useState)" <| fun _ ->
    testPromise "increments count on button click" <| fun _ -> promise {
        let render = RTL.render (Components.ComponentUseState())
        let count = RTL.screen.getByTestId "count"
        let button = RTL.screen.getByTestId "increment"

        expect(count).toHaveTextContent "0"

        do! userEvent.click (button)
        expect(count).toHaveTextContent "1"

        do! userEvent.click (button)
        expect(count).toHaveTextContent "2"
    }

describe "FragmentComponent" <| fun _ ->
    testPromise "renders multiple elements from a fragment" <| fun _ -> promise {
        RTL.render (Components.FragmentComponent())
        |> ignore

        let first = RTL.screen.getByTestId "first"
        let second = RTL.screen.getByTestId "second"

        expect(first).toHaveTextContent "Hello"
        expect(second).toHaveTextContent "World"
    }

describe "useCallback" <| fun _ ->

    test "should keep the same callback reference if dependencies don't change" <| fun _ ->
        let capturedFns = ResizeArray<unit -> unit>()

        let render =
            RTL.render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        render.rerender (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        expect(capturedFns.[0]).toBe capturedFns.[1]

    testPromise "should update callback reference if dependency changes" <| fun _ -> promise {

        let capturedFns = ResizeArray<unit -> unit>()

        let _ = render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        let incEle = screen.getByTestId "increment"

        do! userEvent.click (incEle)

        expect(capturedFns[0]).not.toBe (capturedFns[1])

    }

describe "React Context" <| fun _ ->
    testPromise "provides and consumes context value" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        expect(valueDiv).toHaveTextContent "Provided value"
    }

    testPromise "updates context via consumer interaction" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        let button = RTL.screen.getByTestId "update-context"

        expect(valueDiv).toHaveTextContent "Provided value"

        do! userEvent.click(button)

        expect(valueDiv).toHaveTextContent "Updated value"
    }

describe "ComponentUseRef" <| fun _ ->
    testPromise "updates input value via ref" <| fun _ -> promise {
        RTL.render (Components.ComponentUseInputRef())
        |> ignore

        let input = RTL.screen.getByTestId "my-input" :?> Browser.Types.HTMLInputElement
        let button = RTL.screen.getByTestId "update-button"

        expect(input).toHaveValue ""

        do! userEvent.click button

        expect(input).toHaveValue "Updated via ref"
    }

    testPromise "Referencing a value with a ref stores correctly" <| fun _ -> promise {
        let render = render (Components.ComponentUseRefForValue())

        let countDisplay = screen.getByTestId "count-display"
        let incRefbutton = screen.getByTestId "increment-ref-button"
        let updateStateButton = screen.getByTestId "update-state-button"

        expect(countDisplay).toHaveTextContent "0" //state starts with 0

        do! userEvent.click incRefbutton // only update ref
        expect(countDisplay).toHaveTextContent "0"

        do! userEvent.click incRefbutton // only update ref
        expect(countDisplay).toHaveTextContent "0"

        do! userEvent.click updateStateButton // update state by ref
        expect(countDisplay).toHaveTextContent "2"
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
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 0"

        // Click to increment the count
        do! userEvent.click button
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 0"

        // Click again, should update the memoized value
        do! userEvent.click button
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 0"
        expect(count).toHaveTextContent "2"

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
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 0"

        // Click to increment the count
        do! userEvent.click button
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 1"

        // Click again, should update the memoized value
        do! userEvent.click button
        expect(memoizedValueDiv).toHaveTextContent "Memoized count: 2"
        expect(count).toHaveTextContent "2"

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
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

        // Render the component
        let renderResult = RTL.render (
            Components.ComponentUseEffectWithUnmount(effect, dispose)
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

    ftestPromise "IDisposable return calls Dispose() function" <| fun _ -> promise {
        RTL.render (Components.EffectfulTimer())
        |> ignore

        let value = RTL.screen.getByTestId("timer-value")
        let button = RTL.screen.getByTestId("pause-button")

        do! Promise.sleep 2200

        let initial = int value.textContent
        expect(initial).toBeGreaterThan 0

        do! userEvent.click(button) // Pause

        do! Promise.sleep 2000
        let afterPause = int value.textContent
        expect(afterPause).toBe initial
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
        expect(effect).toHaveBeenCalledTimes 1 //"Effect should be called once on mount"
        expect(dispose).toHaveBeenCalledTimes 0 

        // Unmount the component
        renderResult.unmount()

        // Check that disposeEffect was called once on unmount
        expect(effect).toHaveBeenCalledTimes 1
        expect(dispose).toHaveBeenCalledTimes 1
    }

    testPromise "calls effect on mount and disposeEffect on unmount" <| fun _ -> promise {

        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let dispose: unit -> unit = vi.fn(fun () -> console.log("Dispose called"))

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
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Type into the input field
        // let input = RTL.screen.getByTestId("input")
        // do! RTL.userEvent.clear(input)
        // do! RTL.userEvent.type'(input, "hello", 50)

        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).not.toBeNull()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))
    }

    testPromise "loads lazy static member component with typed text after checkbox is checked" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadStaticMember())

        // Ensure loading message is not present initially
        expect(screen.queryByText("Loading...")).toBeNull()

        // Type into the input field
        // let input = RTL.screen.getByTestId("input")
        // do! RTL.userEvent.clear(input)
        // do! RTL.userEvent.type'(input, "hello", 50)

        // Click the checkbox to load the lazy component
        let checkbox = RTL.screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        do! RTL.waitFor<unit>(fun () -> promise {
            let! loading = RTL.screen.findByTestId("loading")
            expect(loading).not.toBeNull()
        })


        let! lazyText = 
            RTL.waitFor<Browser.Types.HTMLElement>((fun () -> promise {
                // Wait for the lazy component to appear
                return! RTL.screen.findByText("Component loaded after 2 seconds")
            }), RTLWaitForOptions(timeout = 3000))

        expect(lazyText).not.toBeNull()
    }


describe "Strict Mode with Effect" <| fun _ ->
    testPromise "calls effect once on mount in StrictMode" <| fun _ -> promise {
        let effect: unit -> unit = vi.fn(fun () -> console.log("Effect called"))
        let render = RTL.render (React.StrictMode [
            Components.ComponentStrictWithEffect(effect)
        ])

        // Check that effect was called once on mount
        expect(effect).toHaveBeenCalledTimes 2 //"Effect should be called once on mount"
    }
