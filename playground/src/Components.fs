module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

// [<ReactLazyComponent>]
// let LazyCounter (a: int, b: float) : ReactElement =
//     CodeSplitting.CodeSplitting.MyCodeSplitComponentTupledWithPrimitives(a, b)

type JSX = JSX.Html

type TEST_DU =
    | Case1
    | Case2 of int
    | Case3 of string * bool

[<Erase; Mangle(false)>]
type JSXCases =
    [<ReactComponent>]
    static member SimpleChildren() =
        JSX.div [
            JSX.h1 "This is a simple heading."
            JSX.p "This is a simple paragraph."
        ]

    [<ReactComponent>]
    static member SimpleChildrenWithProp() =
        JSX.div [
            prop.children [
                JSX.h1 "This is a simple heading."
                JSX.p "This is a simple paragraph."
            ]
        ]

    [<ReactComponent>]
    static member NestedChildren() =
        JSX.div [
            JSX.div [
                JSX.h2 "Nested Heading"
                JSX.p "This is a nested paragraph."
            ]
        ]

    [<ReactComponent>]
    static member Empty() = JSX.div []

    [<ReactComponent>]
    static member EmptyJSXNone() = JSX.none

    [<ReactComponent>]
    static member ConditionalChildren(condition: bool) =
        JSX.div [
            JSX.textf "Conditional children example: %b" condition
            if condition then
                JSX.p "This paragraph is conditionally rendered."
        ]

    [<ReactComponent>]
    static member ChildrenConditionalMatch(condition: bool) =
        JSX.div [
            match condition with
            | true -> JSX.p "This paragraph is conditionally rendered."
            | false -> JSX.none
        ]

    [<ReactComponent>]
    static member TestDUExample(value: TEST_DU) =
        JSX.div [
            match value with
            | Case1 -> JSX.p "Case1"
            | Case2 i -> JSX.p (sprintf "Case2 with value %d" i)
            | Case3(s, b) -> JSX.p (sprintf "Case3 with values %s and %b" s b)
        ]

    [<ReactComponent>]
    static member Properties() =
        JSX.div [
            prop.className "my-class"
            prop.style [ style.color "red" ]
            prop.id "my-id"
            prop.title "This is a tooltip"
            prop.hidden false
            prop.tabIndex 0
            prop.children [ JSX.p "This is a component with properties." ]
        ]

    [<ReactComponent>]
    static member ConditionalStylePropertyInValue(condition: bool) =
        JSX.div [
            // if condition then // this fails!
            //     prop.style [ style.color "blue" ]
            prop.style [ style.color (if condition then "blue" else null) ]
            prop.text (sprintf "ConditionalStylePropertyInValue example: %b" condition)
        ]

    [<JSX.Component>]
    static member ConditionalStylePropertyInStyleList(condition: bool) =
        JSX.div [
            // if condition then // this fails!
            //     prop.style [ style.color "blue" ]
            // prop.style [ style.color (if condition then "blue" else null) ]
            prop.style [
                if condition then
                    style.color "red"
            ]
            prop.text (sprintf "ConditionalStylePropertyInStyleList example: %b" condition)
        ]

    // [<ReactComponent>]
    // static member PropertyTextf() =
    //     JSX.div [ prop.textf "PropertyTextf example: %s" "Hello, world!" ] // not working due to kprintf

    [<ReactComponent>]
    static member Main() =
        JSX.div [
            JSXCases.SimpleChildren()
            JSXCases.SimpleChildrenWithProp()
            JSXCases.NestedChildren()
            JSXCases.Empty()
            JSXCases.EmptyJSXNone()
            JSXCases.ConditionalChildren(true)
            JSXCases.ConditionalChildren(false)
            JSXCases.ChildrenConditionalMatch(true)
            JSXCases.ChildrenConditionalMatch(false)
            JSXCases.Properties()
            JSXCases.ConditionalStylePropertyInValue(true)
            JSXCases.ConditionalStylePropertyInValue(false)
            JSXCases.ConditionalStylePropertyInStyleList(true)
            JSXCases.ConditionalStylePropertyInStyleList(false)
            JSXCases.TestDUExample(Case1)
            JSXCases.TestDUExample(Case2 42)
            JSXCases.TestDUExample(Case3("Hello", true))
        ]
