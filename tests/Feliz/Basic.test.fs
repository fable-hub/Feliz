module Tests.BasicTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Fable.Core
open Vitest
open Basic

describe "Simple createElement calls" <| fun _ ->

    test "Html.div children" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    Html.h1 "Hello, World!"
                    Html.p "This is a simple div component."
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()
        let p = render.getByText "This is a simple div component."
        expect(p).toBeInTheDocument()

    test "JSX.div children" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    JSX.Html.h1 "Hello, World!"
                    JSX.Html.p "This is a simple div component."
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()
        let p = render.getByText "This is a simple div component."
        expect(p).toBeInTheDocument()

    test "Html.div child" <| fun _ ->
        let render = 
            RTL.render(
                Html.div (Html.h1 "Hello, World!")
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()

    test "JSX.Html.div child" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div (JSX.Html.h1 "Hello, World!")
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()

    test "Html.div [prop.children children]" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    prop.testId "simpleDiv"
                    prop.children [
                        Html.h1 "Hello, World!"
                        Html.p "This is a simple div component."
                    ]
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()
        let p = render.getByText "This is a simple div component."
        expect(p).toBeInTheDocument()

    test "JSX.Html.div [prop.children children]" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    prop.testId "simpleDiv"
                    prop.children [
                        JSX.Html.h1 "Hello, World!"
                        JSX.Html.p "This is a simple div component."
                    ]
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()
        let p = render.getByText "This is a simple div component."
        expect(p).toBeInTheDocument()

    test "Html.div [prop.children child]" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    prop.testId "simpleDiv"
                    prop.children (Html.h1 "Hello, World!")
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()

    test "JSX.Html.div [prop.children child]" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    prop.testId "simpleDiv"
                    prop.children (JSX.Html.h1 "Hello, World!")
                ]
            )

        let h1 = render.getByText "Hello, World!"
        expect(h1).toBeInTheDocument()

    test "Html.div [prop.text string]" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    prop.testId "simpleDiv"
                    prop.text "Hello, World!"
                ]
            )

        let text = render.getByText "Hello, World!"
        expect(text).toBeInTheDocument()

    test "JSX.Html.div [prop.text string]" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    prop.testId "simpleDiv"
                    prop.text "Hello, World!"
                ]
            )

        let text = render.getByText "Hello, World!"
        expect(text).toBeInTheDocument()

    test "Html.div [prop.text int]" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    prop.testId "simpleDiv"
                    prop.text 42
                ]
            )

        let text = render.getByText "42"
        expect(text).toBeInTheDocument()

    test "JSX.Html.div [prop.text int]" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    prop.testId "simpleDiv"
                    prop.text 42
                ]
            )

        let text = render.getByText "42"
        expect(text).toBeInTheDocument()

    test "Html.div [prop.text float]" <| fun _ ->
        let render = 
            RTL.render(
                Html.div [
                    prop.testId "simpleDiv"
                    prop.text 42.42
                ]
            )

        let text = render.getByText "42.42"
        expect(text).toBeInTheDocument()

    test "JSX.Html.div [prop.text float]" <| fun _ ->
        let render = 
            RTL.render(
                JSX.Html.div [
                    prop.testId "simpleDiv"
                    prop.text 42.42
                ]
            )

        let text = render.getByText "42.42"
        expect(text).toBeInTheDocument()

describe "Single Tuple Input Tests #644" <| fun _ ->

    test "Component with single tuple input passes args correctly" <| fun _ ->
        let guid = System.Guid.NewGuid()
        RTL.render(
            Components.SingleTupleInput1((42, "Test", guid))
        ) |> ignore

        expect(RTL.screen.getByTestId "int").toHaveTextContent("42")
        expect(RTL.screen.getByTestId "string").toHaveTextContent("Test")
        expect(RTL.screen.getByTestId "guid").toHaveTextContent(guid.ToString())

    test "Component with single tuple input passes args correctly and with different argument name" <| fun _ ->
        let guid = System.Guid.NewGuid()
        RTL.render(
            Components.SingleTupleInput2((42, "Test", guid))
        ) |> ignore

        expect(RTL.screen.getByTestId "int").toHaveTextContent("42")
        expect(RTL.screen.getByTestId "string").toHaveTextContent("Test")
        expect(RTL.screen.getByTestId "guid").toHaveTextContent(guid.ToString())

describe "Basic Tests" <| fun _ ->

    test "Html elements can be rendered" <| fun _ ->
        RTL.render(
            Components.DivWithClassesAndChildren()
        ) |> ignore

        let div = RTL.screen.getByTestId "simpleDiv"

        expect(div).toBeInTheDocument()

describe "Tests for specific style elements" <| fun _ ->

    test "style.fontsize._" <| fun _ ->
        RTL.render(
            Html.div [
                prop.testId "fontSizeTest"
                prop.style [style.fontSize.small]
                prop.text "This is small font size"
            ]
        ) |> ignore

        let div = RTL.screen.getByTestId "fontSizeTest"

        expect(div).toBeInTheDocument()
        expect(div).toHaveStyle("font-size: small")
