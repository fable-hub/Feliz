module ReactLazyImportByRefFailureTests

open Expecto
open ReactLazyImportByRefFixtures
open TranspileUtils

let private snippetSource =
    """
module Snippet

let value = 1
"""

let private createSpec (testName: string) (additionalFiles: (string * string) list) (callerModule: string) =
    additionalFiles
    |> List.fold
        (fun spec (fileName, fileContents) -> withAdditionalFile fileName fileContents spec)
        (createSnippet testName snippetSource)
    |> withAdditionalFile "Caller.fs" callerModule

let private expectLazyArgMismatch (lazyComponentName: string) (failure: TranspileFailure) =
    expectDiagnosticContains
        "Argument names used in the lazy component call do not match with the ones in the source component."
        failure

    expectDiagnosticContains (sprintf "lazy component `%s`" lazyComponentName) failure
    expectDiagnosticContains "Source component" failure
    expectDiagnosticHasLocation failure

[<Tests>]
let reactLazyImportByRefFailureTests =
    testList "ReactLazyComponent import-by-ref arg name matching - failure" [
        test "tupled optional args with renamed wrapper args fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-tupled"
                    [ "Source.fs", TupledInput.sourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyTupled
    (texti: string, ?id: string, ?cls: string, ?tap: Browser.Types.MouseEvent -> unit)
    =
    Source.Source.MyCodeSplitComponent(
        text = texti,
        ?testId = id,
        ?className = cls,
        ?onClick = tap
    )
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyTupled")
        }

        test "tupled primitives with renamed wrapper args fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-primitive-tupled"
                    [ "Source.fs", TupledInput.primitiveSourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyPrimitiveTupled(a: int, b: float) =
    Source.Source.MyCodeSplitComponent(a, b)
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyPrimitiveTupled")
        }

        test "curried strings/options with renamed wrapper args fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-curried"
                    [ "Source.fs", CurriedInput.sourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyCurried(label: string) (id: string option) =
    Source.Source.MyCodeSplitComponent label id
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyCurried")
        }

        test "curried primitives with renamed wrapper args fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-primitive-curried"
                    [ "Source.fs", CurriedInput.primitiveSourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyPrimitiveCurried(a: int) (b: int) =
    Source.Source.MyCodeSplitComponent a b
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyPrimitiveCurried")
        }

        test "record payload with renamed wrapper arg fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-record"
                    [
                        "Types.fs", RecordTypeInput.types
                        "Source.fs", RecordTypeInput.sourceCode
                    ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyRecord(myProps: Types.PayloadRecord) =
    Source.Source.MyCodeSplitComponent(myProps)
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyRecord")
        }

        test "class payload with renamed wrapper arg fails" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-failure-class"
                    [
                        "Types.fs", ClassInput.types
                        "Source.fs", ClassInput.sourceCode
                    ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyClass(instance: Types.PayloadClass) =
    Source.Source.MyCodeSplitComponent(instance)
"""

            withTranspileFailure spec (expectLazyArgMismatch "LazyClass")
        }

    ]
