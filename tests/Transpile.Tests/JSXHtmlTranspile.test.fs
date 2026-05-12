module JSXHtmlTranspileTests

open Expecto
open TranspileUtils

let private jsxHtmlSnippet =
    """
module Snippet

open Fable.Core
open Feliz
open Feliz.JSX

[<Erase; Mangle(false)>]
type Components =

    [<JSX.Component>]
    static member SimpleDiv() =
        Html.div [
            prop.className "simple-div"
            prop.testId "simpleDiv"
            prop.text "Hello from JSX"
        ]
"""

[<Tests>]
let jsxHtmlTranspileTests =
    testList "Feliz.JSX.Html transpilation" [
        test "transpiles minimal JSX component and emits stable code markers" {
            let spec = createSnippet "jsx-html-success" jsxHtmlSnippet

            withTranspileSuccess
                spec
                (fun success ->
                    let output = readSourceOutput success

                    Expect.stringContains
                        output
                        "export function SimpleDiv("
                        "Expected exported JSX component function."

                    Expect.stringContains
                        output
                        "className=\"simple-div\""
                        "Expected className assignment in transpiled JSX."

                    Expect.stringContains
                        output
                        "data-testid=\"simpleDiv\""
                        "Expected test id assignment in transpiled JSX."

                    Expect.stringContains output "<div" "Expected JSX div node in transpiled output."

                    Expect.isFalse
                        (output.Contains("HtmlHelper_createElement"))
                        "Expected direct JSX output instead of HtmlHelper_createElement fallback."
                )
        }
    ]
