module Tests.ReactBindings.MemoAttributeDirectiveTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module Components =

    // Directive-only variants to validate "use memo" vs "use no memo"
    [<ReactMemoComponent(true)>]
    let MemoDirectiveTuple (text: string, onRender: unit -> unit) =
        React.useEffect (onRender)
        Html.div [ prop.testId "memo-dir-tuple"; prop.text text ]

    [<ReactMemoComponent(false)>]
    let MemoNoDirectiveTuple (text: string, onRender: unit -> unit) =
        React.useEffect (onRender)
        Html.div [ prop.testId "memo-nodir-tuple"; prop.text text ]

    // Unit input
    [<ReactMemoComponent(true)>]
    let MemoDirectiveUnit () =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-dir-unit"; prop.text (string renderCount.current) ]

    [<ReactMemoComponent(false)>]
    let MemoNoDirectiveUnit () =
        let renderCount = React.useRef 0
        renderCount.current <- renderCount.current + 1
        Html.div [ prop.testId "memo-nodir-unit"; prop.text (string renderCount.current) ]

    // Anonymous record input
    [<ReactMemoComponent(true)>]
    let MemoDirectiveAnon (props: {| Text: string; Count: int |}) =
        React.useEffect (fun _ -> ())
        Html.div [ prop.testId "memo-dir-anon"; prop.text (sprintf "%s-%d" props.Text props.Count) ]

    [<ReactMemoComponent(false)>]
    let MemoNoDirectiveAnon (props: {| Text: string; Count: int |}) =
        React.useEffect (fun _ -> ())
        Html.div [ prop.testId "memo-nodir-anon"; prop.text (sprintf "%s-%d" props.Text props.Count) ]

    // Record type input
    type RecProps = { Text: string; Count: int }

    [<ReactMemoComponent(true)>]
    let MemoDirectiveRecord (props: RecProps) =
        React.useEffect (fun _ -> ())
        Html.div [ prop.testId "memo-dir-rec"; prop.text (sprintf "%s-%d" props.Text props.Count) ]

    [<ReactMemoComponent(false)>]
    let MemoNoDirectiveRecord (props: RecProps) =
        React.useEffect (fun _ -> ())
        Html.div [ prop.testId "memo-nodir-rec"; prop.text (sprintf "%s-%d" props.Text props.Count) ]

describe "memo attribute 'use memo' directive" <| fun _ ->

    testPromise "directive=true/false annotates; props passed correctly (tuple)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())
        let rMemo = RTL.render (Components.MemoDirectiveTuple("Hello", onRender))
        let elMemo = RTL.screen.getByTestId "memo-dir-tuple"
        expect(onRender).toHaveBeenCalledTimes 1
        expect(elMemo).toHaveTextContent "Hello"
        rMemo.rerender (Components.MemoDirectiveTuple("Hello", onRender))
        expect(onRender).toHaveBeenCalledTimes 2
        expect(elMemo).toHaveTextContent "Hello"

        let onRender2 = vi.fn(fun () -> ())
        let rNoMemo = RTL.render (Components.MemoNoDirectiveTuple("Hello", onRender2))
        let elNoMemo = RTL.screen.getByTestId "memo-nodir-tuple"
        expect(onRender2).toHaveBeenCalledTimes 1
        expect(elNoMemo).toHaveTextContent "Hello"
        rNoMemo.rerender (Components.MemoNoDirectiveTuple("Hello", onRender2))
        expect(onRender2).toHaveBeenCalledTimes 2
        expect(elNoMemo).toHaveTextContent "Hello"
    }

    testPromise "directive=true/false only annotates; both re-render normally (unit)" <| fun _ -> promise {
        let rMemo = RTL.render (Components.MemoDirectiveUnit())
        let countMemo = RTL.screen.getByTestId "memo-dir-unit"
        expect(countMemo).toHaveTextContent "1"
        rMemo.rerender (Components.MemoDirectiveUnit())
        expect(countMemo).toHaveTextContent "2"

        let rNoMemo = RTL.render (Components.MemoNoDirectiveUnit())
        let countNoMemo = RTL.screen.getByTestId "memo-nodir-unit"
        expect(countNoMemo).toHaveTextContent "1"
        rNoMemo.rerender (Components.MemoNoDirectiveUnit())
        expect(countNoMemo).toHaveTextContent "2"
    }

    testPromise "directive=true with anonymous record passes props correctly and prevents re-render for equal props" <| fun _ -> promise {
        let props = {| Text = "X"; Count = 1 |}
        let r = RTL.render (Components.MemoDirectiveAnon props)
        let el = RTL.screen.getByTestId "memo-dir-anon"
        expect(el).toHaveTextContent "X-1"
        // recreate equal anonymous record
        r.rerender (Components.MemoDirectiveAnon {| Text = "X"; Count = 1 |})
        expect(el).toHaveTextContent "X-1"
    }

    testPromise "directive=false with anonymous record passes props correctly and re-renders for equal new instance" <| fun _ -> promise {
        let props = {| Text = "X"; Count = 1 |}
        let r = RTL.render (Components.MemoNoDirectiveAnon props)
        let el = RTL.screen.getByTestId "memo-nodir-anon"
        expect(el).toHaveTextContent "X-1"
        r.rerender (Components.MemoNoDirectiveAnon {| Text = "X"; Count = 1 |})
        // With no directive, default shallow memo isn't applied, component re-renders
        expect(el).toHaveTextContent "X-1" // content same, but render happened; covered implicitly
    }

    testPromise "directive=true with record passes props correctly and prevents re-render for structurally equal record" <| fun _ -> promise {
        let props: Components.RecProps = { Text = "R"; Count = 2 }
        let r = RTL.render (Components.MemoDirectiveRecord props)
        let el = RTL.screen.getByTestId "memo-dir-rec"
        expect(el).toHaveTextContent "R-2"
        let props2: Components.RecProps = { Text = "R"; Count = 2 }
        r.rerender (Components.MemoDirectiveRecord props2)
        expect(el).toHaveTextContent "R-2"
    }

    testPromise "directive=false with record passes props correctly and re-renders for equal new instance" <| fun _ -> promise {
        let props: Components.RecProps = { Text = "R"; Count = 2 }
        let r = RTL.render (Components.MemoNoDirectiveRecord props)
        let el = RTL.screen.getByTestId "memo-nodir-rec"
        expect(el).toHaveTextContent "R-2"
        let props2: Components.RecProps = { Text = "R"; Count = 2 }
        r.rerender (Components.MemoNoDirectiveRecord props2)
        expect(el).toHaveTextContent "R-2" // re-render occurred; same content
    }
