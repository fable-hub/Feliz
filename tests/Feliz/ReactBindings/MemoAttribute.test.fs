
module Tests.ReactBindings.MemoAttributeTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module Components =

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

    let private RenderArrayWithEffectEquals (a: {|fruitArray: string[]|}) (b: {|fruitArray: string[]|}) =
        a = b

    [<ReactMemoComponent(areEqual = "Components_RenderArrayWithEffectEquals")>]
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
        let render = RTL.render (Components.MemoAttribute("Hello", onRender))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (Components.MemoAttribute("Hello", onRender))
        expect(onRender).toHaveBeenCalledTimes 1
        render.rerender (Components.MemoAttribute("World", onRender))
        expect(onRender).toHaveBeenCalledTimes 2
    }

    testPromise "prevents re-rendering when props do not change (attribute array with fsharp areEqual)" <| fun _ -> promise {
        let onRender = vi.fn(fun () -> ())
        let render = RTL.render (Components.MemoAttributeAreEqualFsEqualWrapper onRender)
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
        let render = RTL.render (Components.MemoAttributeAreEqualJsEqualWrapper (onRender))
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
