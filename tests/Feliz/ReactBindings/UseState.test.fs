
module Tests.ReactBindings.UseStateTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =
    [<ReactComponent>]
    static member ComponentUseState(?init: int) =
        let count, setCount = React.useState 0

        Html.div [
            Html.p [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.testId "increment"
                prop.text "Increment"
            ]
        ]


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
