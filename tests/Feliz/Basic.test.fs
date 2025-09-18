module Tests.BasicTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Fable.Core
open Vitest
open Basic

describe "Basic Tests" <| fun _ ->

    test "Html elements can be rendered" <| fun _ ->
        RTL.render(
            Components.DivWithClassesAndChildren()
        ) |> ignore

        let div = RTL.screen.getByTestId "simpleDiv"

        expect(div).toBeInTheDocument()
