module ReactTestingLibrary.Tests

open Fable.Core
open Feliz

[<Literal>]
let CountDisplayTestId = "count-display"

[<Erase; Mangle(false)>]
type Component =
    [<ReactComponent>]
    static member Counter(?init: int) = 
        let count, setCount = React.useStateWithUpdater(init |> Option.defaultValue 0)
        Html.div [
            Html.button [
                prop.testId "increase-button"
                prop.onClick (fun _ -> setCount (fun count -> count + 1))
            ]
            Html.button [
                prop.testId "decrease-button"
                prop.onClick (fun _ -> setCount (fun count -> count - 1))
            ]
            Html.p [
                prop.testId CountDisplayTestId
                prop.text (sprintf "Count: %d" count)
            ]
        ]

    [<ReactComponent>]
    static member TextTestComponent() =
        let showAsync, setShowAsync = React.useState(false)
        React.useEffectOnce(fun () ->
            async {
                do! Async.Sleep 500
                setShowAsync true
            } |> Async.StartImmediate
        )

        Html.div [
            Html.h1 "Welcome"
            Html.p "Message"
            Html.p "Message"
            if showAsync then
                Html.span "Loaded asynchronously"
        ]

    [<ReactComponent>]
    static member JestDomTest() =
        let active, setActive = React.useState(false)

        Html.div [
            Html.button [
                prop.testId "toggle-button"
                prop.onClick (fun _ -> setActive (not active))
                prop.className [
                    "btn"
                    if active then "btn-active" else "btn-inactive"
                ]
                prop.text "Toggle"
            ]
            if active then
                Html.p [
                    prop.testId "active-text"
                    prop.className "status-text visible"
                    prop.text "Active!"
                ]
        ]

    [<ReactComponent>]
    static member DelayedToggle() =
        let visible, setVisible = React.useState(false)

        let handleClick = fun _ -> Fable.Core.JS.setTimeout (fun () -> setVisible true) 500 |> ignore

        Html.div [
            Html.button [
                prop.testId "toggle-button"
                prop.onClick handleClick
                prop.text "Show"
            ]
            if visible then
                Html.p [
                    prop.testId "delayed-text"
                    prop.text "Now visible!"
                ]
        ]

open Vitest

Vitest.describe("render", fun () ->
    Vitest.test("props", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let countdisplay = reactElement.getByTestId(CountDisplayTestId)
        Vitest.expect(countdisplay.textContent).toBe("Count: 0")
    })
)

open Fable.Core.JsInterop

Vitest.describe("Query tests", fun () ->
    Vitest.test("getByText string", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let countDisplay = RTL.screen.getByText("Count: 0")
        Vitest.expect(countDisplay.textContent).toBe("Count: 0")
    })

    Vitest.test("getByText regex", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let countDisplay = RTL.screen.getByText(System.Text.RegularExpressions.Regex("Count: \\d+"))
        Vitest.expect(countDisplay.textContent).toBe("Count: 0")
    })

    Vitest.test("getByText function", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let countDisplay = RTL.screen.getByText((fun text _ -> text.StartsWith("Count: ")))
        Vitest.expect(countDisplay.textContent).toBe("Count: 0")
    })

    Vitest.describe("getByText variants", fun () ->
        Vitest.test("getByText - finds unique static text", fun () -> 
            let _ = RTL.render(Component.TextTestComponent())
            Vitest.expect(RTL.screen.getByText("Welcome")).toBeInTheDocument()
        )

        Vitest.test("getAllByText - finds multiple static texts", fun () -> 
            let _ = RTL.render(Component.TextTestComponent())
            let messages = RTL.screen.getAllByText("Message");
            Vitest.expect(messages).toHaveLength(2)
        )

        Vitest.test("queryByText - returns null for missing text", fun () -> 
            let _ = RTL.render(Component.TextTestComponent())
            let messages = RTL.screen.queryByText("Nonexistent");
            Vitest.expect(messages).toBeNull()
        )

        Vitest.test("queryAllByText - returns empty array for missing text", fun () -> 
            let _ = RTL.render(Component.TextTestComponent())
            let messages = RTL.screen.queryAllByText("Nonexistent");
            Vitest.expect(messages).toHaveLength(0)
        )

        Vitest.test("findByText - resolves when async text appears", fun () -> promise {
            let _ = RTL.render(Component.TextTestComponent())
            let! asyncText = RTL.screen.findByText("Loaded asynchronously");
            Vitest.expect(asyncText).toBeInTheDocument()
        })

        Vitest.test("findAllByText - resolves when multiple texts appear (use existing)", fun () -> promise {
            let _ = RTL.render(Component.TextTestComponent())
            let! asyncTexts = RTL.screen.findAllByText("Loaded asynchronously");
            Vitest.expect(asyncTexts).toHaveLength(1)
        })
    )
)

Vitest.describe("userEvent", fun () ->
    Vitest.test("fireEvent[event]", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let incrementButton = RTL.screen.getByTestId("increase-button")
        do! UserEvent.userEvent.click(incrementButton)
        let countDisplay = RTL.screen.getByTestId(CountDisplayTestId)
        Vitest.expect(countDisplay.textContent).toBe("Count: 1")
    })
)

Vitest.describe("fireEvent", fun () ->
    Vitest.test("fireEvent[event]", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let incrementButton = RTL.screen.getByTestId("increase-button")
        RTL.fireEvent.custom("click", incrementButton)
        let countDisplay = RTL.screen.getByTestId(CountDisplayTestId)
        Vitest.expect(countDisplay.textContent).toBe("Count: 1")
    })

    Vitest.test("createEvent[click]", fun () -> promise {
        let reactElement = RTL.render(Component.Counter())
        let input = RTL.screen.getByTestId("increase-button")
        let myEvent = RTL.createEvent("click", input)
        RTL.fireEventWith(input, myEvent)
        let countDisplay = RTL.screen.getByTestId(CountDisplayTestId)
        Vitest.expect(countDisplay.textContent).toBe("Count: 1")
    })
)

Vitest.describe("jest-dom", fun () ->
    Vitest.test("toBeDisabled", fun () -> promise {
        let _ = RTL.render(Component.Counter())
        let incrementButton = RTL.screen.getByTestId("increase-button")
        RTL.fireEvent.custom("click", incrementButton)
        let countDisplay = RTL.screen.getByTestId(CountDisplayTestId)
        Vitest.expect(countDisplay).toBeEnabled()
    })

    Vitest.test("initial state has inactive class", fun () -> 
        let _ = RTL.render(Component.JestDomTest())
        let toggleButton = RTL.screen.getByTestId("toggle-button")
        Vitest.expect(toggleButton).toBeInTheDocument()
        Vitest.expect(toggleButton).toHaveClass([| "btn"; "btn-inactive" |])
        Vitest.expect(toggleButton).not.toHaveClass("btn-active")
    )

    Vitest.test("clicking toggles active class and shows text", fun () -> promise {
        let _ = RTL.render(Component.JestDomTest())
        let toggleButton = RTL.screen.getByTestId("toggle-button")

        do! UserEvent.userEvent.click(toggleButton)

        Vitest.expect(toggleButton).toHaveClass([| "btn"; "btn-active" |])
        Vitest.expect(toggleButton).not.toHaveClass("btn-inactive")

        let text = RTL.screen.getByTestId("active-text")
        Vitest.expect(text).toBeInTheDocument()
        Vitest.expect(text).toBeVisible()
        Vitest.expect(text).toHaveTextContent("Active!")
        Vitest.expect(text).toHaveClass([|"status-text"; "visible"|])
    })
)

describe "waitFor" <| fun _ -> (
    testPromise "shows text after delay using waitFor" <| fun () -> promise {
        let reactElement = RTL.render(Component.DelayedToggle())
        let toggleButton = RTL.screen.getByTestId("toggle-button")
        
        do! userEvent.click(toggleButton)

        expect(screen.queryByTestId("delayed-text")).toBeNull(); 

        do! RTL.waitFor(fun () ->
            expect(screen.getByTestId("delayed-text")).toBeInTheDocument();
        )
    }

    testPromise "test promise" <| fun () -> promise {
        let mypromise = fun () -> promise {
            do! Promise.sleep 500;
            return 42
        }

        let! number = RTL.waitFor<int>(
            fun () -> promise {
                return! mypromise()
            }
        )

        expect(number).toBe(42)
    }

    testPromise "test promise" <| fun () -> promise {
        let mypromise = fun () -> promise {
            do! Promise.sleep 1500;
            return 42
        }

        let! number = RTL.waitFor<int>(
            (fun () -> promise {
                return! mypromise()
            }),
            RTLWaitForOptions(timeout = 2000)
        )

        expect(number).toBe(42)
    }

    testPromise "test async" <| fun () -> promise {
        let myasync = async {
            do! Async.Sleep 500;
            return 42
        }

        let! number = RTL.waitFor<int>(myasync)

        expect(number).toBe(42)
    }

    testPromise "test async" <| fun () -> promise {
        let myasync = async {
            do! Async.Sleep 1500;
            return 42
        }

        let! number = RTL.waitFor<int> (myasync, RTLWaitForOptions(timeout = 2000))

        expect(number).toBe(42)
    }
)
