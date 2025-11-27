
module Tests.ReactBindings.MemoTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module MemoComponents =

    [<ReactMemoComponent>]
    let MemoAttribute(text: string, onRender: unit -> unit) =
        React.useEffect (
            fun () ->
                onRender()
        )
        Html.div [
            prop.text text
            prop.testId "memo-attribute"
        ]

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

    let private RenderArrayWithEffectEquals (a: {|fruitArray: string[]|}) (b: {|fruitArray: string[]|}) =
        a = b

    [<ReactMemoComponent(areEqual = "MemoComponents_RenderArrayWithEffectEquals")>]
    let private MemoAttributeAreEqualFsEqual (fruitArray: string [], onRender: unit -> unit) =
        React.useEffect (onRender)
        Html.div [ 
            prop.text (String.concat ", " fruitArray); 
            prop.testId "memo-attribute" 
        ]

    [<ReactComponent>]
    let MemoAttributeAreEqualFsEqualWrapper (onRender: unit -> unit) =
        let fruitArray, setFruitArray = React.useState [| "Apple"; "Banana"; "Orange" |]
        let theme, setTheme = React.useState "light"
        Html.div [
            prop.style [ 
                if theme = "light" then 
                    style.backgroundColor "white"
                    style.color "black"
                else 
                    style.backgroundColor "black"
                    style.color "white"
            ]
            prop.children [
                Html.button [
                    prop.testId "change-fruit-array"
                    prop.text "Change Fruit Array"
                    prop.onClick (fun _ -> setFruitArray [| "Apple"; "Banana"; "Orange"; "Cherry" |])
                ]
                Html.button [
                    prop.testId "change-theme"
                    prop.text "Change Theme"
                    prop.onClick (fun _ -> 
                        if theme = "light" then 
                            setTheme "dark" 
                        else 
                            setTheme "light")
                ]
                MemoAttributeAreEqualFsEqual (fruitArray, onRender)
            ]
        ]

    [<ReactMemoComponent(areEqual = "(a, b) => { return a.fruitArray === b.fruitArray; }")>]
    let private MemoAttributeAreEqualJsEqual (fruitArray: string [], onRender: unit -> unit) =
        React.useEffect (onRender)
        Html.div [ 
            prop.text (String.concat ", " fruitArray); 
            prop.testId "memo-attribute" 
        ]

    [<ReactComponent>]
    let MemoAttributeAreEqualJsEqualWrapper (onRender: unit -> unit) =
        let fruitArray, setFruitArray = React.useState [| "Apple"; "Banana"; "Orange" |]
        let theme, setTheme = React.useState "light"
        Html.div [
            prop.style [ 
                if theme = "light" then 
                    style.backgroundColor "white"
                    style.color "black"
                else 
                    style.backgroundColor "black"
                    style.color "white"
            ]
            prop.children [
                Html.button [
                    prop.testId "change-fruit-array"
                    prop.text "Change Fruit Array"
                    prop.onClick (fun _ -> setFruitArray [| "Apple"; "Banana"; "Orange"; "Cherry" |])
                ]
                Html.button [
                    prop.testId "change-theme"
                    prop.text "Change Theme"
                    prop.onClick (fun _ -> 
                        if theme = "light" then 
                            setTheme "dark" 
                        else 
                            setTheme "light")
                ]
                MemoAttributeAreEqualJsEqual (fruitArray, onRender)
            ]
        ]

describe "memo" <| fun _ ->
    testPromise "prevents re-rendering when props do not change (attribute)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())  
        let render = RTL.render (MemoComponents.MemoAttribute("Hello", onRender))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (MemoComponents.MemoAttribute("Hello", onRender))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (MemoComponents.MemoAttribute("World", onRender))
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (attribute array with fsharp areEqual)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())
        let render = RTL.render (MemoComponents.MemoAttributeAreEqualFsEqualWrapper onRender)
        expect(onRender).toHaveBeenCalledTimes 1
        let changeFruitArrayBtn = render.getByTestId("change-fruit-array")
        let changeThemeBtn = render.getByTestId("change-theme")
        // Changing theme should **not** trigger re-render of memoized component
        do! userEvent.click changeThemeBtn
        expect(onRender).toHaveBeenCalledTimes 1
        // Changing fruit array should trigger re-render of memoized component
        do! userEvent.click changeFruitArrayBtn
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (attribute array with js areEqual)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())
        let render = RTL.render (MemoComponents.MemoAttributeAreEqualJsEqualWrapper (onRender))
        expect(onRender).toHaveBeenCalledTimes 1
        let changeFruitArrayBtn = render.getByTestId("change-fruit-array")
        let changeThemeBtn = render.getByTestId("change-theme")
        // Changing theme should **not** trigger re-render of memoized component
        do! userEvent.click changeThemeBtn
        expect(onRender).toHaveBeenCalledTimes 1
        // Changing fruit array should trigger re-render of memoized component
        do! userEvent.click changeFruitArrayBtn
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (function)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())  
        let render = RTL.render (React.memoRender(MemoComponents.MemoFunction, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(MemoComponents.MemoFunction, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(MemoComponents.MemoFunction, {| text = "World"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (function unit)" <| fun _ -> promise {
        let render = RTL.render (React.memoRender(MemoComponents.MemoFunctionUnit))
        let text = render.getByTestId("text")
        expect(text).toBeInTheDocument()
        expect(text).toHaveTextContent("")
        render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit)) // rerender should not change anything, because of memo
        render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit))
        render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit))
        render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit))
        let btn = render.getByTestId("btn")
        do! userEvent.click btn
        expect(text).toHaveTextContent("1") // state change triggers rerender increasing counter
        do! userEvent.click btn
        expect(text).toHaveTextContent("2")
    }

    testPromise "prevents re-rendering when props do not change (function areEqual)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())  
        let render = RTL.render (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "World"; onRender = onRender |}))
        expect(onRender).toHaveBeenCalledTimes 2
        let onRender2 = vi.fn(fun () -> ())
        render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "World"; onRender = onRender2 |}))
        expect(onRender).toHaveBeenCalledTimes 2 // should not rerender because areEqual says props are equal
        expect(onRender2).toHaveBeenCalledTimes 0 // new onRender was never called, because it was actually never passed into rendered component
    }

    describe "withKey" <| fun _ ->

        testPromise "prevents re-rendering when props do not change (function)" <| fun _ -> promise {
            let onRender = vi.fn(fun () -> ())  
            let render = RTL.render (React.memoRender(MemoComponents.MemoFunction, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(MemoComponents.MemoFunction, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(MemoComponents.MemoFunction, {| text = "World"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2
        }

        testPromise "prevents re-rendering when props do not change (function unit)" <| fun _ -> promise {
            let render = RTL.render (React.memoRender(MemoComponents.MemoFunctionUnit, withKey = "unique-key"))
            let text = render.getByTestId("text")
            expect(text).toBeInTheDocument()
            expect(text).toHaveTextContent("")
            render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit, withKey = "unique-key")) // rerender should not change anything, because of memo
            render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit, withKey = "unique-key"))
            render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit, withKey = "unique-key"))
            render.rerender (React.memoRender(MemoComponents.MemoFunctionUnit, withKey = "unique-key"))
            let btn = render.getByTestId("btn")
            do! userEvent.click btn
            expect(text).toHaveTextContent("1") // state change triggers rerender increasing counter
            do! userEvent.click btn
            expect(text).toHaveTextContent("2")
        }

        testPromise "prevents re-rendering when props do not change (function areEqual)" <| fun _ -> promise {
            let onRender = vi.fn(fun () -> ())  
            let render = RTL.render (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "Hello"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 1
            render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "World"; onRender = onRender |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2
            let onRender2 = vi.fn(fun () -> ())
            render.rerender (React.memoRender(MemoComponents.MemoFunctionAreEqual, {| text = "World"; onRender = onRender2 |}, withKey = fun s -> s.text))
            expect(onRender).toHaveBeenCalledTimes 2 // should not rerender because areEqual says props are equal
            expect(onRender2).toHaveBeenCalledTimes 0 // new onRender was never called, because it was actually never passed into rendered component
        }
