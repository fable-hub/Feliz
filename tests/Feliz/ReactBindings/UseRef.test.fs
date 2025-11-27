module Tests.ReactBindings.UseRefTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

[<Erase; Mangle(false)>]
type Components =

    [<ReactComponent>]
    static member ComponentUseInputRef () =
        let inputRef = React.useInputRef()

        let handleClick () =
            match inputRef.current with
            | Some el -> el.value <- "Updated via ref"
            | None -> ()

        Html.div [
            Html.input [
                prop.testId "my-input"
                prop.ref inputRef
            ]
            Html.button [
                prop.testId "update-button"
                prop.text "Update input"
                prop.onClick (fun _ -> handleClick())
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseRefForValue () =
        // Ref is used to store a value
        let countRef = React.useRef(0)
        let state, setState = React.useState(0)

        let handleIncrement () =
            countRef.current <- countRef.current + 1

        Html.div [
            Html.div [
                prop.testId "count-display"
                prop.text state
            ]
            Html.button [
                prop.testId "increment-ref-button"
                prop.text "Increment ref"
                prop.onClick (fun _ -> handleIncrement())
            ]
            Html.button [
                prop.testId "update-state-button"
                prop.text "Increment state"
                prop.onClick (fun _ -> setState countRef.current)
            ]
        ]

describe "useRef" <| fun _ ->
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
