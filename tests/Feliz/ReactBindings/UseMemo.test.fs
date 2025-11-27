module Tests.ReactBindings.UseMemoTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =
    [<ReactComponent>]
    static member ComponentUseMemo () =
        // Simple memoized value based on count
        let count, setCount = React.useState 0
        let memoizedValue = React.useMemo((fun () -> $"Memoized count: {count}"))

        Html.div [
            Html.div [
                prop.testId "memoized-value"
                prop.text memoizedValue
            ]
            Html.div [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.testId "increment-button"
                prop.text "Increment"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseMemoWithDependency () =
        // Simple memoized value based on count
        let count, setCount = React.useState 0
        let memoizedValue = React.useMemo((fun () -> $"Memoized count: {count}"), [|box count|])

        Html.div [
            Html.div [
                prop.testId "memoized-value"
                prop.text memoizedValue
            ]
            Html.div [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.testId "increment-button"
                prop.text "Increment"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
        ]


describe "useMemo" <| fun _ ->
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
        expect(count).not.toHaveTextContent "3"

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
