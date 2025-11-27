module Tests.ReactBindings.FragmentTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =

    [<ReactComponent>]
    static member FragmentComponent () =
        React.Fragment [
            Html.p [ prop.testId "first"; prop.text "Hello" ]
            Html.p [ prop.testId "second"; prop.text "World" ]
        ]

describe "FragmentComponent" <| fun _ ->
    testPromise "renders multiple elements from a fragment" <| fun _ -> promise {
        RTL.render (Components.FragmentComponent())
        |> ignore

        let first = RTL.screen.getByTestId "first"
        let second = RTL.screen.getByTestId "second"

        expect(first).toHaveTextContent "Hello"
        expect(second).toHaveTextContent "World"
    }
