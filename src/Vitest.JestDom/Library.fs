namespace Vitest

open Fable.Core

// [<AutoOpen>]
// module JestDom =

//     open System.Runtime.CompilerServices

//     type IAssertion<'a> with
//         [<Emit("$0.toBeInTheDocument()")>]
//         member this.toBeInTheDocument(): unit = jsNative

open Fable.Core

type StringOrRegex = U2<string, System.Text.RegularExpressions.Regex>

[<AutoOpen>]
module JestDom =

    type IAssertion<'a> with

        [<Emit("$0.toBeDisabled()")>]
        member this.toBeDisabled() : unit = jsNative

        [<Emit("$0.toBeEnabled()")>]
        member this.toBeEnabled() : unit = jsNative

        [<Emit("$0.toBeEmptyDOMElement()")>]
        member this.toBeEmptyDOMElement() : unit = jsNative

        [<Emit("$0.toBeInTheDocument()")>]
        member this.toBeInTheDocument() : unit = jsNative

        [<Emit("$0.toBeInvalid()")>]
        member this.toBeInvalid() : unit = jsNative

        [<Emit("$0.toBeRequired()")>]
        member this.toBeRequired() : unit = jsNative

        [<Emit("$0.toBeValid()")>]
        member this.toBeValid() : unit = jsNative

        [<Emit("$0.toBeVisible()")>]
        member this.toBeVisible() : unit = jsNative

        [<Emit("$0.toContainElement($1)")>]
        member this.toContainElement(element: Browser.Types.HTMLElement) : unit = jsNative

        [<Emit("$0.toContainHTML($1)")>]
        member this.toContainHTML(htmlText: string) : unit = jsNative


        [<Emit("$0.toHaveAccessibleDescription()")>]
        member this.toHaveAccessibleDescription() : unit = jsNative

        [<Emit("$0.toHaveAccessibleDescription($1)")>]
        member this.toHaveAccessibleDescription(expectedAccessibleDescription: string) : unit = jsNative

        [<Emit("$0.toHaveAccessibleDescription($1)")>]
        member this.toHaveAccessibleDescription
            (expectedAccessibleDescription: System.Text.RegularExpressions.Regex)
            : unit =
            jsNative


        [<Emit("$0.toHaveAccessibleErrorMessage()")>]
        member this.toHaveAccessibleErrorMessage() : unit = jsNative

        [<Emit("$0.toHaveAccessibleErrorMessage($1)")>]
        member this.toHaveAccessibleErrorMessage(expectedAccessibleDescription: string) : unit = jsNative

        [<Emit("$0.toHaveAccessibleErrorMessage($1)")>]
        member this.toHaveAccessibleErrorMessage
            (expectedAccessibleDescription: System.Text.RegularExpressions.Regex)
            : unit =
            jsNative


        [<Emit("$0.toHaveAccessibleName()")>]
        member this.toHaveAccessibleName() : unit = jsNative

        [<Emit("$0.toHaveAccessibleName($1)")>]
        member this.toHaveAccessibleName(expectedAccessibleDescription: string) : unit = jsNative

        [<Emit("$0.toHaveAccessibleName($1)")>]
        member this.toHaveAccessibleName(expectedAccessibleDescription: System.Text.RegularExpressions.Regex) : unit =
            jsNative

        [<Emit("$0.toHaveAttribute($1, $2)")>]
        member this.toHaveAttribute(attributeName: string, ?expectedValue: obj) : unit = jsNative

        [<Emit("$0.toHaveClass(...$1, $2)")>]
        member this.toHaveClass(classNames: string[], ?options: {| exact: bool |}) : unit = jsNative

        [<Emit("$0.toHaveClass($1, $2)")>]
        member this.toHaveClass(className: string, ?options: {| exact: bool |}) : unit = jsNative

        [<Emit("$0.toHaveClass($1, $2)")>]
        member this.toHaveClass(className: System.Text.RegularExpressions.Regex, ?options: {| exact: bool |}) : unit =
            jsNative

        [<Emit("$0.toHaveClass(...$1, $2)")>]
        member this.toHaveClass
            (classNames: System.Text.RegularExpressions.Regex[], ?options: {| exact: bool |})
            : unit =
            jsNative

        [<Emit("$0.toHaveClass(...$1, $2)")>]
        member this.toHaveClass(classNames: StringOrRegex[], ?options: {| exact: bool |}) : unit = jsNative

        [<Emit("$0.toHaveFocus()")>]
        member this.toHaveFocus() : unit = jsNative

        [<Emit("$0.toHaveFormValues()")>]
        member this.toHaveFormValues(expectedValues: obj) : unit = jsNative

        [<Emit("$0.toHaveStyle($1)")>]
        member this.toHaveStyle(css: string) : unit = jsNative

        [<Emit("$0.toHaveStyle($1)")>]
        member this.toHaveStyle(css: obj) : unit = jsNative

        [<Emit("$0.toHaveTextContent($1, $2)")>]
        member this.toHaveTextContent(text: string, ?options: {| normalizeWhitespace: bool |}) : unit = jsNative

        [<Emit("$0.toHaveTextContent($1, $2)")>]
        member this.toHaveTextContent
            (text: System.Text.RegularExpressions.Regex, ?options: {| normalizeWhitespace: bool |})
            : unit =
            jsNative

        [<Emit("$0.toHaveValue($1)")>]
        member this.toHaveValue(value: string) : unit = jsNative

        [<Emit("$0.toHaveValue($1)")>]
        member this.toHaveValue(value: string[]) : unit = jsNative

        [<Emit("$0.toHaveValue($1)")>]
        member this.toHaveValue(value: int) : unit = jsNative

        [<Emit("$0.toHaveDisplayValue($1)")>]
        member this.toHaveDisplayValue(value: string) : unit = jsNative

        [<Emit("$0.toHaveDisplayValue($1)")>]
        member this.toHaveDisplayValue(value: System.Text.RegularExpressions.Regex) : unit = jsNative

        [<Emit("$0.toHaveDisplayValue($1)")>]
        member this.toHaveDisplayValue(value: string[]) : unit = jsNative

        [<Emit("$0.toHaveDisplayValue($1)")>]
        member this.toHaveDisplayValue(value: StringOrRegex[]) : unit = jsNative

        [<Emit("$0.toBeChecked()")>]
        member this.toBeChecked() : unit = jsNative

        [<Emit("$0.toBePartiallyChecked()")>]
        member this.toBePartiallyChecked() : unit = jsNative

        [<Emit("$0.toHaveRole($1)")>]
        member this.toHaveRole(expectedRole: string) : unit = jsNative

        [<Emit("$0.toHaveErrorMessage($1)")>]
        member this.toHaveErrorMessage(text: string) : unit = jsNative

        [<Emit("$0.toHaveErrorMessage($1)")>]
        member this.toHaveErrorMessage(text: System.Text.RegularExpressions.Regex) : unit = jsNative
