
module Tests.ReactBindings.LazyTests


open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

[<Erase; Mangle(false)>]
module TestLazyComponent =

    let LazyLoadComponent = 
        React.lazy'<{|text: string|}>(fun () ->
            promise {
                do! Promise.sleep 2000
                return! Fable.Core.JsInterop.importDynamic "../CodeSplitting.jsx"
            }
        )

    [<ReactLazyComponent>]
    let LazyLoadComponentAttributeFromPath(text: string) = React.DynamicImported "../CodeSplitting.jsx"

    [<ReactLazyComponent>]
    let LazyLoadComponentAttribute(text: string) = CodeSplitting.CodeSplitting.MyCodeSplitComponent(text)

[<Erase; Mangle(false)>]
type TestLazyComponentClass =

    [<ReactLazyComponent>]
    static member LazyLoadComponent(?text: string) = CodeSplitting.CodeSplitting.MyCodeSplitComponent(?text = text)

    [<ReactLazyComponent>]
    static member LazyLoadComponentFromPath(?text: string) = React.DynamicImported "../CodeSplitting.jsx"

type Components =
    [<ReactComponent>]
    static member LazyLoad() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        React.lazyRender(TestLazyComponent.LazyLoadComponent, {|text = text|})
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeLet() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponent.LazyLoadComponentAttribute(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeClass() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponentClass.LazyLoadComponent(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeLetFromPath() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponent.LazyLoadComponentAttributeFromPath(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeClassFromPath() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponentClass.LazyLoadComponentFromPath(text)
                    ]
                )
        ]

describe "lazy" <| fun _ ->
    testPromise "loads lazy component with typed text after checkbox is checked" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoad())

        // Ensure loading message is not present initially
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).toBeTruthy()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))

        let input = RTL.screen.getByTestId("input")
        do! userEvent.clear(input)
        do! userEvent.``type``(input, "hello")

        let! lazyText = RTL.screen.findByText("hello")
        expect(lazyText).not.toBeNull()
        let loading = RTL.screen.queryByTestId("loading")
        expect(loading).toBeNull()
    }

    testPromise "loads lazy component with attribute from let binding" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadLazyComponentAttributeLet())

        // Ensure loading message is not present initially
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Type into the input field


        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).not.toBeNull()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))

        let input = RTL.screen.getByTestId("input")
        do! userEvent.clear(input)
        do! userEvent.``type``(input, "hello")

        let! lazyText = RTL.screen.findByText("hello")
        expect(lazyText).not.toBeNull()
        let loading = RTL.screen.queryByTestId("loading")
        expect(loading).toBeNull()
    }

    testPromise "loads lazy component with attribute from static member" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadLazyComponentAttributeClass())

        // Ensure loading message is not present initially
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Type into the input field


        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).not.toBeNull()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))

        let input = RTL.screen.getByTestId("input")
        do! userEvent.clear(input)
        do! userEvent.``type``(input, "hello")

        let! lazyText = RTL.screen.findByText("hello")
        expect(lazyText).not.toBeNull()
        let loading = RTL.screen.queryByTestId("loading")
        expect(loading).toBeNull()
    }

    testPromise "loads lazy component with attribute from let binding from path" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadLazyComponentAttributeLetFromPath())

        // Ensure loading message is not present initially
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Type into the input field


        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).not.toBeNull()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))

        let input = RTL.screen.getByTestId("input")
        do! userEvent.clear(input)
        do! userEvent.``type``(input, "hello")

        let! lazyText = RTL.screen.findByText("hello")
        expect(lazyText).not.toBeNull()
        let loading = RTL.screen.queryByTestId("loading")
        expect(loading).toBeNull()
    }

    testPromise "loads lazy component with attribute from static member from path" <| fun _ -> promise {
        let render = RTL.render (Components.LazyLoadLazyComponentAttributeClassFromPath())

        // Ensure loading message is not present initially
        expect(RTL.screen.queryByText("Loading...")).toBeNull()

        // Type into the input field


        // Click the checkbox to load the lazy component
        let checkbox = screen.getByTestId("checkbox")
        do! userEvent.click(checkbox)

        // Wait for loading indicator
        let! loading = RTL.waitFor<Types.HTMLElement>(fun () -> promise {
            return! screen.findByTestId("loading")
        })

        expect(loading).not.toBeNull()

        do! RTL.waitFor<unit>((fun () -> promise {
            // Wait for the lazy component to appear
            let! lazyText = RTL.screen.findByText("Component loaded after 2 seconds")
            expect(lazyText).not.toBeNull()
        }), RTLWaitForOptions(timeout = 3000))

        let input = RTL.screen.getByTestId("input")
        do! userEvent.clear(input)
        do! userEvent.``type``(input, "hello")

        let! lazyText = RTL.screen.findByText("hello")
        expect(lazyText).not.toBeNull()
        let loading = RTL.screen.queryByTestId("loading")
        expect(loading).toBeNull()
    }
