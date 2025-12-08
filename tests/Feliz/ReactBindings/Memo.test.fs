
module Tests.ReactBindings.MemoTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module Components =

    let MemoFunction = React.memo<{| text: string; onRender: unit -> unit |}>(fun (props) ->
        React.useEffect (
            fun () ->
                props.onRender()
        )
        Html.div [
            prop.text props.text
            prop.testId "memo-function"
        ]
    )

    let MemoFunctionUnit = React.memo(fun () ->
        let ref = React.useRef(0)
        let text, setText = React.useState("") 
        React.useEffect (
            fun () ->
                ref.current <- ref.current + 1
        )
        Html.div [
            Html.button [
                prop.testId "btn"
                prop.text "Update Text"
                prop.onClick (fun _ -> setText (string ref.current))
            ]
            Html.div [
                prop.text text
                prop.testId "text"
            ]
        ]
    )

    let MemoFunctionAreEqual = React.memo<{| text: string; onRender: unit -> unit |}>(
        (fun props ->
            React.useEffect (
                fun () ->
                    props.onRender()
            )
            Html.div [
                prop.text props.text
                prop.testId "memo-function"
            ]),
        (fun prevProps nextProps -> prevProps.text = nextProps.text)
    )


describe "memo" <| fun _ ->

    testPromise "prevents re-rendering when props do not change (function)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())  
        let render = RTL.render (React.memoRender(Components.MemoFunction, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(Components.MemoFunction, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(Components.MemoFunction, {| text = "World"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (function unit)" <| fun _ -> promise {
        let render = RTL.render (React.memoRender(Components.MemoFunctionUnit))
        let text = render.getByTestId("text")
        expect(text).toBeInTheDocument()
        expect(text).toHaveTextContent("")
        render.rerender (React.memoRender(Components.MemoFunctionUnit)) // rerender should not change anything, because of memo
        render.rerender (React.memoRender(Components.MemoFunctionUnit))
        render.rerender (React.memoRender(Components.MemoFunctionUnit))
        render.rerender (React.memoRender(Components.MemoFunctionUnit))
        let btn = render.getByTestId("btn")
        do! userEvent.click btn
        expect(text).toHaveTextContent("1") // state change triggers rerender increasing counter
        do! userEvent.click btn
        expect(text).toHaveTextContent("2")
    }

    testPromise "prevents re-rendering when props do not change (function areEqual)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())  
        let render = RTL.render (React.memoRender(Components.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "World"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 2
        let onRender2 = vi.fn(fun () -> ())
        render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "World"; onRender = onRender2 |}))
        expect(onRender).toHaveBeenCalledTimes 2 // should not rerender because areEqual says props are equal
        expect(onRender2).toHaveBeenCalledTimes 0 // new onRender was never called, because it was actually never passed into rendered component
    }

    describe "withKey" <| fun _ ->

        testPromise "prevents re-rendering when props do not change (function)" <| fun _ -> promise {
            let onRender = vi.fn(fun () -> ())  
            let render = RTL.render (React.memoRender(Components.MemoFunction, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(Components.MemoFunction, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(Components.MemoFunction, {| text = "World"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2
        }

        testPromise "prevents re-rendering when props do not change (function unit)" <| fun _ -> promise {
            let render = RTL.render (React.memoRender(Components.MemoFunctionUnit, withKey = "unique-key"))
            let text = render.getByTestId("text")
            expect(text).toBeInTheDocument()
            expect(text).toHaveTextContent("")
            render.rerender (React.memoRender(Components.MemoFunctionUnit, withKey = "unique-key")) // rerender should not change anything, because of memo
            render.rerender (React.memoRender(Components.MemoFunctionUnit, withKey = "unique-key"))
            render.rerender (React.memoRender(Components.MemoFunctionUnit, withKey = "unique-key"))
            render.rerender (React.memoRender(Components.MemoFunctionUnit, withKey = "unique-key"))
            let btn = render.getByTestId("btn")
            do! userEvent.click btn
            expect(text).toHaveTextContent("1") // state change triggers rerender increasing counter
            do! userEvent.click btn
            expect(text).toHaveTextContent("2")
        }

        testPromise "prevents re-rendering when props do not change (function areEqual)" <| fun _ -> promise {
            let onRender = vi.fn(fun () -> ())  
            let render = RTL.render (React.memoRender(Components.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "World"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2
            let onRender2 = vi.fn(fun () -> ())
            render.rerender (React.memoRender(Components.MemoFunctionAreEqual, {| text = "World"; onRender = onRender2 |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2 // should not rerender because areEqual says props are equal
            expect(onRender2).toHaveBeenCalledTimes 0 // new onRender was never called, because it was actually never passed into rendered component
        }
