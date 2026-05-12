module ReactLazyImportByRefSuccessTests

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

let private assertSuccess spec = withTranspileSuccess spec (fun _ -> ())

[<Tests>]
let reactLazyImportByRefSuccessTests =
    testList "ReactLazyComponent import-by-ref arg name matching - success" [
        test "tupled optional args with matching names transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-tupled"
                    [ "Source.fs", TupledInput.sourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyTupled
    (text: string, testId: string, className: string, onClick: Browser.Types.MouseEvent -> unit)
    =
    Source.Source.MyCodeSplitComponent(
        text = text,
        testId = testId,
        className = className,
        onClick = onClick
    )
"""

            assertSuccess spec
        }

        test "tupled primitives with matching names transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-primitive-tupled"
                    [ "Source.fs", TupledInput.primitiveSourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyPrimitiveTupled(x: int, y: float) =
    Source.Source.MyCodeSplitComponent(x, y)
"""

            assertSuccess spec
        }

        test "curried strings/options with matching names transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-curried"
                    [ "Source.fs", CurriedInput.sourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyCurried(text: string) (testId: string option) =
    Source.Source.MyCodeSplitComponent text testId
"""

            assertSuccess spec
        }

        test "curried primitives with matching names transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-primitive-curried"
                    [ "Source.fs", CurriedInput.primitiveSourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyPrimitiveCurried(x: int) (y: int) =
    Source.Source.MyCodeSplitComponent x y
"""

            assertSuccess spec
        }

        test "record payload with matching arg name transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-record"
                    [
                        "Types.fs", RecordTypeInput.types
                        "Source.fs", RecordTypeInput.sourceCode
                    ]
                    """
module Caller

open Fable.Core
open Feliz
open Types

[<ReactLazyComponent>]
let LazyRecord(props: PayloadRecord) =
    Source.Source.MyCodeSplitComponent(props)
"""

            assertSuccess spec
        }

        test "class payload with matching arg name transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-class"
                    [
                        "Types.fs", ClassInput.types
                        "Source.fs", ClassInput.sourceCode
                    ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyClass(owner: Types.PayloadClass) =
    Source.Source.MyCodeSplitComponent(owner)
"""

            assertSuccess spec
        }

        test "anonymous record payload with matching arg name transpiles" {
            let spec =
                createSpec
                    "react-lazy-import-by-ref-success-anon-record"
                    [ "Source.fs", AnonRecordTypeInput.sourceCode ]
                    """
module Caller

open Fable.Core
open Feliz

[<ReactLazyComponent>]
let LazyAnonRecord(props: {| id: int |}) =
    Source.Source.MyCodeSplitComponent(props)
"""

            assertSuccess spec
        }
    ]
