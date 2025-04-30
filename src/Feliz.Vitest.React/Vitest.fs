namespace Feliz.Vitest

open Fable.Core

[<AutoOpen>]
module Vitest =

    /// Alias "it"
    [<Import("test", from = "vitest")>]
    let test (name: string) (test: unit -> unit) = jsNative

    [<Import("test", from = "vitest")>]
    let testPromise (name: string) (test: unit -> JS.Promise<unit>) = jsNative

    [<Import("test", from = "vitest")>]
    let testWithOption (name: string) (option: obj) (test: unit -> unit) = jsNative

    [<Import("test", from = "vitest")>]
    let testWithOptionPromise (name: string) (option: obj) (test: unit -> JS.Promise<unit>) = jsNative

    let inline testSkip name test = testWithOption name {|skip = true|} test

    let inline testPromiseSkip name test =
        testWithOptionPromise name {|skip = true|} test

    let inline testOnly name test = testWithOption name {|only = true|} test

    let testPromiseTodo name test =
        testWithOptionPromise name {|todo = true|} test

    let inline testPromiseOnly name test =
        testWithOptionPromise name {|only = true|} test

    let inline testSkipIf name skipIf test =
        testWithOption name {|skip = skipIf|} test

    let inline testRunIf name runIf test =
        testWithOption name {|run = runIf|} test

    let inline testTodo name test =
        testWithOption name {|todo = true|} test

    let inline testFails name test =
        testWithOption name {|fails = true|} test

    [<Import("describe", from = "vitest")>]
    let describe(name: string) (testSuit: unit -> unit)  = jsNative 

    module Expect =
    
        [<AttachMembers; Global>]
        type IMatcherResult =
            member this.toBe(value: obj) : unit = jsNative
            member this.toEqual(value: obj) : unit = jsNative
            member this.toMatchObject(value: obj) : unit = jsNative
            member this.toHaveBeenCalled() : unit = jsNative
            member this.toHaveBeenCalledWith(value: obj) : unit = jsNative
            member this.toHaveBeenCalledTimes(value: int) : unit = jsNative
            member this.toBeInTheDocument() : unit = jsNative
            member this.toHaveTextContent(value: string, ?options: obj) : unit = jsNative
            member this.toHaveTextContent(value: System.Text.RegularExpressions.Regex, ?options: obj) : unit = jsNative
            member this.toHaveClass(value: string) : unit = jsNative
            member this.toHaveStyle(value: string) : unit = jsNative
            member this.toHaveAttribute(attribute: string, value: string) : unit = jsNative
            member this.toHaveProperty(property: string) : unit = jsNative
            member this.toHaveValue(value: string) : unit = jsNative
            member this.toHaveFocus() : unit = jsNative
            member this.toHaveFormValues(value: obj) : unit = jsNative
            member this.toHaveLength(value: int) : unit = jsNative
            member this.toBeDisabled() : unit = jsNative
            member this.toBeEnabled() : unit = jsNative
            member this.toBeVisible() : unit = jsNative
            member this.toBeEmpty() : unit = jsNative
            member this.toBeChecked() : unit = jsNative
            member this.toBeSelected() : unit = jsNative
            member this.toBeTruthy() : unit = jsNative
            member this.toBeFalsy() : unit = jsNative
            member this.toBeNull() :unit = jsNative
            member this.toBeUndefined() :unit = jsNative
            member this.toBeNaN() : unit = jsNative
            member this.toBeGreaterThan(value: obj) : unit = jsNative
            member this.toBeLessThan(value: obj) : unit = jsNative
            member this.toBeGreaterThanOrEqual(value: obj) : unit = jsNative
            member this.toBeLessThanOrEqual(value: obj) : unit = jsNative
            member this.toBeCloseTo(value: obj) : unit = jsNative
            member this.toBeDefined() : unit = jsNative

            member this.``not``: IMatcherResult = jsNative

        [<Import("expect", from = "vitest")>]
        let expect(value: obj): IMatcherResult = jsNative

        let toBe (actual: obj) (expected: obj) =
            expect(actual).toBe(expected)

        let toEqual (actual: obj) (expected: obj) =
            expect(actual).toEqual(expected)

        let toMatchObject (actual: obj) (expected: obj) =
            expect(actual).toMatchObject(expected)

        let toHaveBeenCalled (actual: obj) =
            expect(actual).toHaveBeenCalled()

        let toHaveBeenCalledWith (actual: obj) (expected: obj) =
            expect(actual).toHaveBeenCalledWith(expected)

        let toHaveBeenCalledTimes (actual: obj) (expected: int) =
            expect(actual).toHaveBeenCalledTimes(expected)

        let toBeInTheDocument (value: obj) =
            expect(value).toBeInTheDocument()
        let toHaveTextContent (value: Browser.Types.HTMLElement) (text: string) =
            expect(value).toHaveTextContent(text)
        let toHaveClass (value: obj) (className: string) =
            expect(value).toHaveClass(className)
        let toHaveStyle (value: Browser.Types.HTMLElement) (style: string) =
            expect(value).toHaveStyle(style)
        let toHaveAttribute (ele: Browser.Types.HTMLElement) (attribute: string) (value: string) =
            expect(ele).toHaveAttribute(attribute, value)
        let toHaveProperty (value: obj) (property: string) =
            expect(value).toHaveProperty(property)
        let toHaveValue (value: obj) (expected: string) =
            expect(value).toHaveValue(expected)
        let toHaveFocus (value: obj) =
            expect(value).toHaveFocus()
        let toHaveFormValues (value: obj) (expected: obj) =
            expect(value).toHaveFormValues(expected)
        let toHaveLength (value: obj) (expected: int) =
            expect(value).toHaveLength(expected)
        let toBeDisabled (value: obj) =
            expect(value).toBeDisabled()
        let toBeEnabled (value: obj) =
            expect(value).toBeEnabled()
        let toBeVisible (value: obj) =
            expect(value).toBeVisible()
        let toBeEmpty (value: obj) =
            expect(value).toBeEmpty()
        let toBeChecked (value: obj) =
            expect(value).toBeChecked()
        let toBeSelected (value: obj) =
            expect(value).toBeSelected()
        let toBeTruthy (value: bool) =
            expect(value).toBeTruthy()
        let toBeFalsy (value: bool) =
            expect(value).toBeFalsy()
        let toBeNull (value: obj) =
            expect(value).toBeNull()
        let toBeUndefined (value: obj) =
            expect(value).toBeUndefined()
        let toBeNaN (value: obj) =
            expect(value).toBeNaN()
        let toBeGreaterThan (value: obj) (expected: obj) =
            expect(value).toBeGreaterThan(expected)
        let toBeLessThan (value: obj) (expected: obj) =
            expect(value).toBeLessThan(expected)
        let toBeGreaterThanOrEqual (value: obj) (expected: obj) =
            expect(value).toBeGreaterThanOrEqual(expected)
        let toBeLessThanOrEqual (value: obj) (expected: obj) =
            expect(value).toBeLessThanOrEqual(expected)
        let toBeCloseTo (value: obj) (expected: obj) =
            expect(value).toBeCloseTo(expected)

    
