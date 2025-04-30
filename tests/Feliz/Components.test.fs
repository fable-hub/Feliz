module Tests


open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Fable.ReactTestingLibrary
open Fable.Core
open Feliz.Vitest
open Components

[<Erase>]
type RTL =
    [<ImportMember("@testing-library/react")>]
    static member render (ele: ReactElement) : Bindings.Render<Types.HTMLElement,Types.HTMLElement> = jsNative

    [<ImportMember("@testing-library/react")>]
    static member screen: Bindings.QueriesForElement = jsNative

    [<Import("userEvent", "@testing-library/user-event")>]
    static member userEvent: Bindings.UserEventImport = jsNative

describe "Feliz Tests" <| fun _ ->

    test "Html elements can be rendered" <| fun _ ->
        RTL.render(Html.div [
            Html.h1 [
                prop.testId "header"
                prop.text "Hello world"
            ]
        ])
        |> ignore

        let container = RTL.screen.getByTestId(!^"header")
        Expect.toHaveTextContent container "Hello world"

    // test "Verify correct clean up" <| fun _ ->
    //     RTL.render(Html.div [
    //         Html.h1 [
    //             prop.testId "header"
    //             prop.text "Hello world"
    //         ]
    //     ])
    //     |> ignore

    //     let header = RTL.screen.getByTestId !^"header"
    //     Expect.toHaveTextContent header "Hello world"  

    // test "Parsing standard dates works" <| fun _ ->
    //     let validDates = [
    //         "2020-01"
    //         "2020-01-01"
    //         "2020-01-01T20:20"
    //         "2020-01-01T00:00"
    //         "2020-01-01T59:59"
    //     ]

    //     let invalidDates = [
    //         ""
    //         "2020"
    //         "2020-13-01"
    //         "2020-01-35"
    //         "2020-01-01T70:00"
    //         "2020-01-01T20:60"
    //     ]

    //     let allValid =
    //         validDates
    //         |> List.map Feliz.DateParsing.parse
    //         |> List.forall (fun parsedDate -> parsedDate.IsSome)

    //     let allInvalid =
    //         invalidDates
    //         |> List.map Feliz.DateParsing.parse
    //         |> List.forall (fun parsedDate -> parsedDate.IsNone)

    //     Expect.toBeTruthy allValid //"Parsing worked in all cases where the date was valid"
    //     Expect.toBeTruthy allInvalid //"Parsing did not work in all cases where the date was invalid"

    // testPromise "React function component works: counter example" <| fun _ -> promise {
    //     RTL.render(counter {| initialCount = 10 |}) |> ignore
    //     let count = RTL.screen.getByTestId !^"count"
    //     let increment = RTL.screen.getByTestId !^"increment"
    //     Expect.toHaveTextContent count "10" // "Initial count is rendered"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "11" //"After one click, the count becomes 11"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "12" //"After another click, the count becomes 12"
    // }

    // testPromise "React function component works: counter example with debug value" <| fun _ -> promise {
    //     let render = RTL.render(counterWithDebugValue())
    //     let count = RTL.screen.getByTestId !^"count"
    //     let increment = RTL.screen.getByTestId !^"increment"
    //     Expect.toHaveTextContent count "0"  //"Initial count is rendered"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "1" //"After one click, the count becomes 11"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "2" //"After another click, the count becomes 12"
    // }

    // test "React portal works" <| fun _ ->
    //     let portalContainer = document.createElement("div")
    //     let portalId = System.Guid.NewGuid().ToString()
    //     portalContainer.setAttribute("id", portalId)
    //     document.body.appendChild(portalContainer) |> ignore
    //     Expect.toEqual 0 portalContainer.children.length //"Portal container starts empty"
    //     let count = counter {| initialCount = 10 |}
    //     let render = RTL.render(portal {| child = count; id = portalId |})
    //     let count = render.getByTestId !^"count"
    //     Expect.toHaveTextContent count "10" //"Initial count is rendered"
    //     Expect.toEqual 1 portalContainer.children.length //"Portal container contains component"

    // testPromise "React.useEffectOnce(unit -> unit) executes" <| fun _ -> promise {
    //     let mutable effectCount = 0
    //     let render = RTL.render(effectOnceComponent {| effectTriggered = fun () -> effectCount <- effectCount + 1 |})
    //     let count = render.getByTestId !^"count"
    //     let increment = render.getByTestId !^"increment"
    //     Expect.toEqual 1 effectCount //"Effect has been been executed once when the component has been rendered"
    //     Expect.toHaveTextContent count "0" //"Count has initial value of zero"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "1" //"Component has been updated/re-rendered"
    //     Expect.toEqual 1 effectCount //"Effect count stays the same"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "2" //"Component has been updated/re-rendered again"
    //     Expect.toEqual 1 effectCount //"Effect count stays the same"
    // }

    // testPromise "React.useLayoutEffect(unit -> unit) executes on each (re)render" <| fun _ -> promise {
    //     let mutable effectCount = 0
    //     let render = RTL.render(useLayoutEffectEveryRender {| effectTriggered = fun () -> effectCount <- effectCount + 1 |})
    //     let count = render.getByTestId !^"count"
    //     let increment = render.getByTestId !^"increment"
    //     Expect.toEqual 1 effectCount //"Effect has been been executed when the component has been rendered"
    //     Expect.toHaveTextContent count "0" //"Count has initial value of zero"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "1" //"Component has been updated/re-rendered"
    //     Expect.toEqual 2 effectCount //"Effect count has increased to two"
    //     do! RTL.userEvent.click(increment)
    //     Expect.toHaveTextContent count "2" //"Component has been updated/re-rendered again"
    //     Expect.toEqual 3 effectCount //"Effect count has increased three"
    // }

    // testPromise "Focusing input element works with React refs" <| fun _ -> promise {
    //     let render = RTL.render(focusInputExample())
    //     let focusedInput = render.getByTestId !^"focused-input"
    //     let focusInputButton = render.getByTestId !^"focus-input"
    //     Expect.toBeFalsy (focusedInput = unbox document.activeElement) //"Input is not focused yet before clicking button"
    //     do! RTL.userEvent.click(focusInputButton)
    //     Expect.toBeTruthy (focusedInput = unbox document.activeElement) //"Input is now active"
    // }

    // test "Styles are rendered correctly" <| fun _ ->
    //     let render = RTL.render(Html.div [
    //         prop.style [
    //             style.color.red
    //             style.margin 20
    //             style.fontSize 22
    //             style.fontStyle.italic
    //         ]

    //         prop.testId "styled-div"
    //     ])

    //     let container = RTL.screen.getByTestId !^"styled-div"
    //     Expect.toHaveStyle container "color: rgb(255, 0, 0)" //"Text color is red"
    //     Expect.toHaveStyle container "margin: 20px" //"Margin is used correctly"
    //     Expect.toHaveStyle container "font-size: 22px" //"Font size is used correctly"
    //     Expect.toHaveStyle container "font-style: italic" //"Font style is used correctly"

    // test "Individual translate(int) functions render correctly" <| fun _ ->
    //     let render = RTL.render(Html.div [
    //         Html.div [
    //             prop.testId "test-translateX"
    //             prop.style [ style.transform.translateX 1 ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translateY"
    //             prop.style [ style.transform.translateY 2 ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translateZ"
    //             prop.style [ style.transform.translateZ 3 ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translate"
    //             prop.style [ style.transform.translate(11, 22) ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translate3D"
    //             prop.style [ style.transform.translate3D(111, 222, 333) ]
    //         ]
    //     ])

    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateX") "transform: translateX(1px)" // "translateX should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateY") "transform: translateY(2px)" // "translateY should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateZ") "transform: translateZ(3px)" // "translateZ should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translate") "transform: translate(11px,22px)" // "translate should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translate3D") "transform: translate3d(111px,222px,333px)" // "translate3D should render"


    // test "Individual translate(ICssUnit) functions render correctly" <| fun _ ->
    //     let render = RTL.render(Html.div [
    //         Html.div [
    //             prop.testId "test-translateX"
    //             prop.style [ style.transform.translateX (length.em 1) ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translateY"
    //             prop.style [ style.transform.translateY (length.em 2) ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translateZ"
    //             prop.style [ style.transform.translateZ (length.em 3) ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translate"
    //             prop.style [ style.transform.translate(length.em 11, length.em 22) ]
    //         ]
    //         Html.div [
    //             prop.testId "test-translate3D"
    //             prop.style [ style.transform.translate3D(length.em 111, length.em 222, length.em 333) ]
    //         ]
    //     ])

    //     // let getTransform (id:string) = getStyle<string> "transform" (render.getByTestId id)
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateX") "transform: translateX(1em)" // "translateX should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateY") "transform: translateY(2em)" // "translateY should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translateZ") "transform: translateZ(3em)" // "translateZ should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translate") "transform: translate(11em,22em)" // "translate should render"
    //     Expect.toHaveStyle (RTL.screen.getByTestId !^"test-translate3D") "transform: translate3d(111em,222em,333em)" // "translate3D should render"

    // test "Combined translate functions render correctly for style.transform" <| fun _ ->
    //     let render = RTL.render(Html.div [
    //         prop.testId "test-combined-translate"
    //         prop.style [
    //             style.transform [
    //                 transform.translateX 1
    //                 transform.translateY 2.2
    //                 transform.translateZ (length.em 3.3)
    //                 transform.translate(11,22)
    //                 transform.translate3D(111,222,333)
    //             ]
    //         ]
    //     ])
    //     let ele = RTL.screen.getByTestId !^"test-combined-translate"
    //     Expect.toHaveStyle ele "transform: translateX(1px) translateY(2.2px) translateZ(3.3em) translate(11px,22px) translate3d(111px,222px,333px)" // "Combined transform should render"

    // test "Combined translate(int) functions render correctly for prop.transform" <| fun _ ->
    //     let render = RTL.render(
    //         Svg.svg [
    //             Svg.g [
    //                 svg.testId "test-combined-translate"
    //                 svg.transform [
    //                     transform.translateX 1
    //                     transform.translateY 2
    //                     transform.translateZ (length.px 3)
    //                     transform.translate(11, 22)
    //                     transform.translate3D(111, 222, 333)
    //                 ]
    //             ]
    //         ]
    //     )
    //     let ele = RTL.screen.getByTestId !^"test-combined-translate"
    //     Expect.toHaveAttribute ele "transform" "translateX(1) translateY(2) translateZ(3) translate(11,22) translate3d(111,222,333)" // "Combined transform should render"

    // test "Combined translate(float) functions render correctly for prop.transform" <| fun _ ->
    //     let render = RTL.render(
    //         Svg.svg [
    //             Svg.g [
    //             svg.testId "test-combined-translate"
    //             svg.transform [
    //                 transform.translateX 1.1
    //                 transform.translateY 2.2
    //                 transform.translateZ (length.px 3.3)
    //                 transform.translate(11.1, 22.2)
    //                 transform.translate3D(111.1, 222.2, 333.3)
    //             ]
    //         ]
    //     ])

    //     let ele = RTL.screen.getByTestId !^"test-combined-translate"
    //     Expect.toHaveAttribute ele "transform" "translateX(1.1) translateY(2.2) translateZ(3.3) translate(11.1,22.2) translate3d(111.1,222.2,333.3)" // "Combined transform should render"

    // test "Combined translate(ICssUnit) functions render correctly" <| fun _ ->
    //     let render = RTL.render(Html.div [
    //         prop.testId "test-combined-translate"
    //         prop.style [
    //             style.transform [
    //                 transform.translateX (length.em 1)
    //                 transform.translateY (length.em 2)
    //                 transform.translateZ (length.em 3)
    //                 transform.translate(length.em 11, length.em 22)
    //                 transform.translate3D(length.em 111, length.em 222, length.em 333)
    //             ]
    //         ]
    //     ])

    //     let ele = RTL.screen.getByTestId !^"test-combined-translate"
    //     Expect.toHaveStyle ele "transform: translateX(1em) translateY(2em) translateZ(3em) translate(11em,22em) translate3d(111em,222em,333em)" // "Combined transform should render"

    // testPromise "useCallbackRef gets updated values without re-rendering" <| fun () -> promise {
    //     let render = RTL.render(callbackRef())
    //     let buttonField = RTL.screen.getByTestId !^"Button"
    //     let parentField = RTL.screen.getByTestId !^"Main"
    //     let mainField = RTL.screen.getByTestId !^"callbackRef"
    //     let buttonRef = RTL.screen.getByTestId !^"callbackRefButton"

    //     do! Promise.sleep 1000

    //     // do! RTL.waitFor(fun () -> RTL.userEvent.click(buttonRef)) |> Async.AwaitPromise
    //     do! RTL.userEvent.click(buttonRef)
    //     Expect.toHaveTextContent buttonField "1" //"Child component has not re-rendered"
    //     Expect.toHaveTextContent parentField "1" //"Parent component has not re-rendered"
    //     Expect.expect(parentField).``not``.toHaveTextContent(System.Text.RegularExpressions.Regex("/^1$/")) //"Count was updated by child component"
    //     Expect.expect(mainField).``not``.toHaveTextContent(System.Text.RegularExpressions.Regex("/^1$/")) //"Count was updated by child component"
    // }

    // testPromise "forwardRef works correctly" <| fun () -> promise {
    //     let render = RTL.render(forwardRefParent())
    //     let button = render.getByTestId !^"focus-button"
    //     let input = render.getByTestId !^"focus-input"

    //     Expect.toBeFalsy (input = unbox document.activeElement) //"Input is not focused yet before clicking button"
    //     do! RTL.userEvent.click(button)
    //     Expect.toBeTruthy (input = unbox document.activeElement) //"Input is now active"
    // }

    // testPromise "lazy and suspense works" <| fun () -> promise {
    //     let render = RTL.render(codeSplitting())
    //     let loader = render.getByTestId("loading")

    //     Expect.toHaveTextContent loader "Loading" // "Loading element is displayed"
    //     Expect.toBeTruthy (render.queryByTestId("async-load", [ queryOption.exact true ]).IsNone) // "Code-split element is not displayed"

    //     do!
    //         RTL.waitForElementToBeRemoved((fun () -> render.queryByTestId("loading")), [
    //             waitForOption.timeout 5000
    //         ])

    //     Expect.toBeTruthy (render.queryByTestId("loading").IsNone) //"Loading element is not displayed"

    //     do!
    //         RTL.waitFor(fun () ->
    //             Expect.toBeTruthy (render.queryByTestId("async-load").IsSome) //"Code-split element is displayed"
    //         )
    // }

    // testPromise "useImperativeHandle works correctly" <| fun () -> promise {
    //     let render = RTL.render(forwardRefImperativeParent())
    //     let button = render.getByTestId !^"focus-button"
    //     let text = render.getByTestId !^"focus-text"

    //     Expect.toHaveTextContent text "" // (text.innerText <> "") // "Div has empty text value"
    //     do! RTL.userEvent.click(button)
    //     Expect.toHaveTextContent text "Howdy!" // "Div has text value set"
    // }
    // test "funcComps work correctly" <| fun _ ->
    //     let render = RTL.render(funcCompTestDiff())
    //     let renderCount = render.getByTestId !^"funcCompTest"

    //     Expect.toHaveTextContent renderCount "2" //"2" "Renders twice"

    // test "funcComps withKey work correctly" <| fun _ ->
    //     let render = RTL.render(funcCompTestWithKeyDiff())
    //     let renderCount = render.getByTestId !^"funcCompTestWithKey"

    //     Expect.toHaveTextContent renderCount "1" // "Renders once due to static key"

    // test "memoComps work correctly" <| fun _ ->
    //     let render = RTL.render(memoCompTestDiff())
    //     let renderCount = render.getByTestId !^"memoCompTest"

    //     Expect.toHaveTextContent renderCount "2" // "Renders twice"

    // test "memoComps withKey work correctly" <| fun _ ->
    //     let render = RTL.render(memoCompTestWithKeyDiff())
    //     let renderCount = render.getByTestId !^"memoCompTestWithKey"

    //     Expect.toHaveTextContent renderCount "1" // "Renders once due to static key"

    // test "memoComps areEqual work correctly" <| fun _ ->
    //     let render = RTL.render(memoCompTestAreEqualDiff())
    //     let renderCount = render.getByTestId !^"memoCompTestAreEqual"

    //     Expect.toHaveTextContent renderCount "1" // "Renders once due to areEqual eval"

    // testPromise "memoComps withKey areEqual work correctly" <| fun () -> promise {
    //     let render = RTL.render(memoCompTestAreEqualWithKeyDiff())
    //     let renderCount = render.getByTestId !^"memoCompTestAreEqualWithKey"

    //     do! Promise.sleep 100

    //     do!
    //         RTL.waitFor <| fun () ->
    //             Expect.toHaveTextContent renderCount "3" // "Renders three times due to areEqual and withKey evals"
    // }

    // testPromise "can handle select multiple with defaultValue" <| fun _ -> promise {
    //     let render = RTL.render(selectMultipleWithDefault({| isDefaultValue = true; isValue = false; isValueOrDefault = false |}))
    //     let select = render.getByTestId !^"select-multiple"

    //     Expect.toBeTruthy (RTL.screen.getByTestId( !^"val3") |> unbox<Browser.Types.HTMLOptionElement>).selected // "val3 is set via default value"

    //     do! select.userEvent.selectOptions(["1";"2"])

    //     Expect.toBeTruthy (RTL.screen.getByTestId(!^"val1") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Correctly sets val1 option"
    //     Expect.toBeTruthy (RTL.screen.getByTestId(!^"val2") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Correctly sets val2 option"
    //     Expect.toBeTruthy (RTL.screen.getByTestId(!^"val3") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Does not set val3 option"
    // }
    // testPromise "can handle select multiple with value" <| fun _ -> promise {
    //     let render = RTL.render(selectMultipleWithDefault({| isDefaultValue = false; isValue = true; isValueOrDefault = false |}))
    //     let select = render.getByTestId(!^"select-multiple")

    //     Expect.toBeTruthy (RTL.screen.getByTestId(!^"val3") |> unbox<Browser.Types.HTMLOptionElement>).selected //"val3 is set via default value"

    //     do! select.userEvent.selectOptions(["1";"2"])

    //     Expect.toBeFalsy (RTL.screen.getByTestId(!^"val1") |> unbox<Browser.Types.HTMLOptionElement>).selected // "Setting val1 option is ignored"
    //     Expect.toBeFalsy (RTL.screen.getByTestId(!^"val2") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Setting val2 option is ignored"
    //     Expect.toBeTruthy (RTL.screen.getByTestId(!^"val3") |> unbox<Browser.Types.HTMLOptionElement>).selected // "Does not set val3 option"
    // }
    // testPromise "can handle select multiple with valueOrDefault" <| fun _ -> promise {
    //     let render = RTL.render(selectMultipleWithDefault({| isDefaultValue = false; isValue = false; isValueOrDefault = true |}))
    //     let select = render.getByTestId("select-multiple")

    //     Expect.toBeTruthy (RTL.screen.getByTestId("val3") |> unbox<Browser.Types.HTMLOptionElement>).selected // "val3 is set via default value"

    //     do! select.userEvent.selectOptions(["1";"2"])

    //     Expect.toBeTruthy (RTL.screen.getByTestId("val1") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Correctly sets val1 option"
    //     Expect.toBeTruthy (RTL.screen.getByTestId("val2") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Correctly sets val2 option"
    //     Expect.toBeTruthy (RTL.screen.getByTestId("val3") |> unbox<Browser.Types.HTMLOptionElement>).selected //"Does not set val3 option"
    // }
    // test "can use string format as prop" <| fun _ ->
    //     let input = {| str = "hello"; i = 1 |}
    //     let render = RTL.render(textfComp input)

    //     Expect.toHaveTextContent (render.getByTestId("textf-str")) (sprintf "Hello! %s" input.str) //"Correctly accepts single string parameter"
    //     Expect.toHaveTextContent (render.getByTestId("textf-int")) (sprintf "Hello! %i" input.i) //"Correctly accepts single int parameter"
    //     Expect.toHaveTextContent (render.getByTestId("textf-two")) (sprintf "Hello! %s %i" input.str input.i) // "Correctly accepts two parameters"
    //     Expect.toHaveTextContent (render.getByTestId("textf-three")) (sprintf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))) // "Correctly accepts three parameters"

    // test "can use string format directly from Html" <| fun _ ->
    //     let input = {| str = "hello"; i = 1 |}
    //     let render = RTL.render(htmlTextfComp input)

    //     Expect.toHaveTextContent (render.getByTestId("textf-str")) (sprintf "Hello! %s" input.str) //"Correctly accepts single string parameter"
    //     Expect.toHaveTextContent (render.getByTestId("textf-int")) (sprintf "Hello! %i" input.i) //"Correctly accepts single int parameter"
    //     Expect.toHaveTextContent (render.getByTestId("textf-two")) (sprintf "Hello! %s %i" input.str input.i) // "Correctly accepts two parameters"
    //     Expect.toHaveTextContent (render.getByTestId("textf-three")) (sprintf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))) // "Correctly accepts three parameters"

    // testPromiseTodo "useCancellationToken works correctly" <| fun () -> promise {
    //     let render = RTL.render(TokenCancellation.main({| failTest = false |}))

    //     do! Promise.sleep 600

    //     do!
    //         RTL.waitFor <| fun () ->
    //             Expect.toHaveTextContent (render.getByTestId "useTokenCancellation") "Disposed" // "Cancels all subsequent re-renders and calls the disposal function"
    // }

    // testPromise "useCancellationToken works correctly - failure case" <| fun () -> promise {
    //     let render = RTL.render(TokenCancellation.main({| failTest = true |}))

    //     do! Promise.sleep 600

    //     do!
    //         RTL.waitFor <| fun () ->
    //             Expect.toHaveTextContent (render.getByTestId "useTokenCancellation") "Failed" // "Cancels all subsequent re-renders and calls the disposal function"
    // }

    // // https://github.com/fable-hub/Feliz/issues/654
    // testPromiseTodo "Can dispose of optional IDisposables" <| fun () -> promise {
    //     let render = RTL.render(OptionalDispose.render {| isSome = true |})

    //     Expect.toHaveTextContent (render.getByTestId("was-disposed")) "false" // "Should not be disposed yet"

    //     do! RTL.userEvent.click(render.getByTestId("dispose-button"))

    //     do!
    //         RTL.waitFor <| fun () ->
    //             Expect.toHaveTextContent (render.getByTestId("was-disposed")) "true" //"Should have been disposed"
    // }

    // testPromise "Does not dispose of optional IDisposables that are None" <| fun () -> promise {
    //     let render = RTL.render(OptionalDispose.render {| isSome = false |})

    //     Expect.toHaveTextContent (render.getByTestId("was-disposed")) "false" // "Should not be disposed yet"

    //     do! RTL.userEvent.click(render.getByTestId("dispose-button"))

    //     let innerElem = render.queryByTestId("dispose-inner")

    //     if innerElem.IsSome then
    //         do!
    //             RTL.waitForElementToBeRemoved(fun () -> render.queryByTestId("dispose-inner"))

    //     Expect.toHaveTextContent (render.getByTestId("was-disposed")) "false" // "Should not have been disposed"
    // }

    // // https://github.com/fable-hub/Feliz/issues/654
    // testPromiseTodo "Can dispose of multiple IDisposable option refs" <| fun () -> promise {
    //     let render = RTL.render(RefDispose.render())

    //     Expect.toHaveTextContent (render.getByTestId("disposed-count")) "0" // "Should not be disposed yet"

    //     do! RTL.userEvent.click(render.getByTestId("dispose-button"))

    //     do!
    //         RTL.waitFor <| fun () ->
    //             Expect.toHaveTextContent (render.getByTestId("disposed-count")) "2" // "Should have been disposed"
    // }



