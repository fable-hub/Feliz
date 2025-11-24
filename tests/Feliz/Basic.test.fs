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

describe "Record Type Input Tests #606, #603" <| fun _ ->

    test "Component with record type input passes args correctly" <| fun _ ->
        RTL.render(
            RecordTypeInputTesting.RecordTypeContainer()
        ) |> ignore

        expect(RTL.screen.getByTestId "single-greet").toHaveTextContent("Hello, my name is Alice and I work as a Developer.")
        expect(RTL.screen.getByTestId "single-exists").toHaveTextContent("true")

describe "Props Aliasing Tests #687" <| fun _ ->

    test "Component with input arg called props should be correctly aliased" <| fun _ ->
        RTL.render(
            PropsAliasingTesting.ArgsPropsAliasing([prop.style [ style.padding 20; style.backgroundColor.blanchedAlmond ]; prop.testId "main-component"])
        ) |> ignore

        let components = RTL.screen.getAllByTestId "main-component"
        expect(components).toHaveLength(2)
        for c in components do
            expect(c).toBeInTheDocument()

    test "Component inner let binding called props, should be correctly aliased" <| fun _ ->
        RTL.render(
            PropsAliasingTesting.InnerLetBindingPropsAliasing("test", 0)
        ) |> ignore

        let c = RTL.screen.getByTestId "props-aliasing"
        expect(c).toBeInTheDocument()

describe "Nullness Tests" <| fun _ ->

    test "Component with nullable prop handles null correctly" <| fun _ ->
        RTL.render(
            NullnessTesting.NullishPropComponent(null)
        ) |> ignore

        let noText = RTL.screen.getByTestId "no-text"
        expect(noText).toBeInTheDocument()
        expect(noText).toHaveTextContent("No text provided.")

    test "Component with nullable prop handles non-null correctly" <| fun _ ->

        RTL.render(
            NullnessTesting.NullishPropComponent("Hello, Nullable!")
        ) |> ignore

        let hasText = RTL.screen.getByTestId "has-text"
        expect(hasText).toBeInTheDocument()
        expect(hasText).toHaveTextContent("Hello, Nullable!")
