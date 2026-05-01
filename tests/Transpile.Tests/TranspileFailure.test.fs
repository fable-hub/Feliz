module TranspileFailureTests

open Expecto
open TranspileUtils

let private failingSystemIoSnippet =
    """
module Snippet

open Fable.Core
open Feliz
open Feliz.JSX
open System.IO

[<Erase; Mangle(false)>]
type Components =

    [<JSX.Component>]
    static member FailsDuringTranspile() =
        let fileContents = File.ReadAllText(42)
        Html.div fileContents
"""

[<Tests>]
let transpileFailureTests =
    testList "transpilation failure diagnostics" [
        test "captures overall transpilation error for invalid System.IO.File usage" {
            let spec = createSnippet "system-io-file-failure" failingSystemIoSnippet

            withTranspileFailure
                spec
                (fun failure ->
                    expectDiagnosticContains "ReadAllText" failure
                    expectDiagnosticMentionsSourceFile failure
                    expectDiagnosticHasLocation failure
                )
        }
    ]
