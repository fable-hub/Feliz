module Tests.ReactBindings.MemoAreEqualFnTests

open Feliz
open Browser
open Vitest

module Components =

    // Memo using F# structural equality (deep equality)
    [<ReactMemoComponent(AreEqualFn.FsEquals)>]
    let MemoFsEquals (values: int list) =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-fs-count"; prop.text (string renderCount.current) ]

    // Memo using shallow (JS) equality
    [<ReactMemoComponent()>]
    let MemoShallow (values: int list) =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-shallow-count"; prop.text (string renderCount.current) ]

    // Memo using F# equality and a function prop (for testing function handling)
    [<ReactMemoComponent(AreEqualFn.FsEquals)>]
    let MemoFsEqualsWithFn (values: int list, fn: int -> int) =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-fs-fn-count"; prop.text (string renderCount.current) ]

    // Memo using F# equality but ignoring function properties
    [<ReactMemoComponent(AreEqualFn.FsEqualsButFunctions)>]
    let MemoFsEqualsButFunctions (values: int list, fn: int -> int) =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-fs-bf-count"; prop.text (string renderCount.current) ]

    // Parent components used by tests to trigger re-renders with new prop instances
    [<ReactComponent>]
    let ParentListFsEquals() =
        let state, setState = React.useState 0
        let values = [ 1; 2 ] // recreated each render (new instance)
        Html.div [
            Html.button [ prop.testId "btn-list-fs"; prop.onClick (fun _ -> setState(state + 1)); prop.text "Tick" ]
            MemoFsEquals values
        ]

    [<ReactComponent>]
    let ParentListShallow() =
        let state, setState = React.useState 0
        let values = [ 1; 2 ]
        Html.div [
            Html.button [ prop.testId "btn-list-shallow"; prop.onClick (fun _ -> setState(state + 1)); prop.text "Tick" ]
            MemoShallow values
        ]

    [<ReactComponent>]
    let ParentWithFnFs() =
        let state, setState = React.useState 0
        // create a new function each render (captures state) so its reference is different
        let fn = fun x -> x + state
        let values = [ 1; 2 ]
        Html.div [
            Html.button [ prop.testId "btn-fn-fs"; prop.onClick (fun _ -> setState(state + 1)); prop.text "Tick" ]
            MemoFsEqualsWithFn (values, fn)
        ]

    [<ReactComponent>]
    let ParentWithFnFsButFunctions() =
        let state, setState = React.useState 0
        let fn = fun x -> x + state
        let values = [ 1; 2 ]
        Html.div [
            Html.button [ prop.testId "btn-fn-bf"; prop.onClick (fun _ -> setState(state + 1)); prop.text "Tick" ]
            MemoFsEqualsButFunctions (values, fn)
        ]


describe "React memo equality strategies" <| fun _ ->

    testPromise "FsEquals prevents re-render for structurally equal props" <| fun _ -> promise {
        let render = RTL.render (Components.ParentListFsEquals())
        let count = RTL.screen.getByTestId "memo-fs-count"
        let btn = RTL.screen.getByTestId "btn-list-fs"

        expect(count).toHaveTextContent "1"

        do! userEvent.click (btn)
        // With F# equality the child should NOT re-render because the list contents are structurally equal
        expect(count).toHaveTextContent "1"
    }

    testPromise "Shallow memo (default) re-renders when new prop instance provided" <| fun _ -> promise {
        let render = RTL.render (Components.ParentListShallow())
        let count = RTL.screen.getByTestId "memo-shallow-count"
        let btn = RTL.screen.getByTestId "btn-list-shallow"

        expect(count).toHaveTextContent "1"

        do! userEvent.click (btn)
        // With shallow JS equality a new list instance triggers re-render
        expect(count).toHaveTextContent "2"
    }

    testPromise "FsEquals re-renders when function prop changes" <| fun _ -> promise {
        // FsEquals should re-render because the function reference changes between renders
        let renderFs = RTL.render (Components.ParentWithFnFs())
        let countFs = RTL.screen.getByTestId "memo-fs-fn-count"
        let btnFs = RTL.screen.getByTestId "btn-fn-fs"

        expect(countFs).toHaveTextContent "1"
        do! userEvent.click (btnFs)
        expect(countFs).toHaveTextContent "2"

    }

    testPromise "FsEqualsButFunctions ignores function prop changes and does not re-render" <| fun _ -> promise {
        // FsEqualsButFunctions should NOT re-render when only the function prop changes
        let renderBf = RTL.render (Components.ParentWithFnFsButFunctions())
        let countBf = RTL.screen.getByTestId "memo-fs-bf-count"
        let btnBf = RTL.screen.getByTestId "btn-fn-bf"

        expect(countBf).toHaveTextContent "1"
        do! userEvent.click (btnBf)
        expect(countBf).toHaveTextContent "1"
    }
    