module ParallelIsolationTests

open System.Threading.Tasks
open Expecto
open TranspileUtils

let private createParallelSnippet index =
    $"""
module Snippet

open Fable.Core
open Feliz
open Feliz.JSX

[<Erase; Mangle(false)>]
type Components =

    [<JSX.Component>]
    static member Parallel{index}() =
        Html.div [
            prop.testId "parallel-{index}"
            prop.text "Parallel-{index}"
        ]
"""

[<Tests>]
let parallelIsolationTests =
    testList "parallel transpilation isolation" [
        test "concurrent transpile requests do not fail from file access conflicts" {
            let runTranspile index =
                Task.Run(fun () ->
                    let spec = createSnippet (sprintf "parallel-%d" index) (createParallelSnippet index)

                    withTranspileSuccess
                        spec
                        (fun success ->
                            let output = readSourceOutput success

                            Expect.stringContains
                                output
                                (sprintf "parallel-%d" index)
                                "Expected snippet-specific marker in transpiled output."
                        )
                )

            let jobs = [| 1; 2; 3 |] |> Array.map runTranspile

            Task.WhenAll(jobs).GetAwaiter().GetResult()
        }
    ]
