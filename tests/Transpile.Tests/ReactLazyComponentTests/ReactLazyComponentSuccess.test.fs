module ReactLazyComponentSuccessTests

open System
open System.IO
open Expecto
open TranspileUtils

let private renderingListsSource =
    """
module Examples.Feliz.RenderingLists

open Feliz

type RenderingLists =

    [<ReactComponent(true)>]
    static member Example(?list: int list) =

        let items = defaultArg list [ 0 .. 5 ] //any list/seq/array

        Html.div [
            Html.h2 "List rendering using for loop"
            Html.ul [
                Html.li "Static item 1"
                for item in items do // f# for loop, nicely combinable with other children
                    Html.li [
                        prop.key item
                        prop.text (sprintf "Item %i" item)
                    ]
            ]

            Html.h2 "List rendering using List.map"
            items // f# pipe style
            |> List.map (fun item ->
                Html.li [
                    prop.key item
                    prop.text (sprintf "Item %i" item)
                ])
            |> Html.ol

        ]
"""

let private reactLazyComponentSource =
    """
module Examples.Feliz.ReactLazyComponent

open Feliz

[<ReactLazyComponent>]
let private LazyLists(list: int list option) = Examples.Feliz.RenderingLists.RenderingLists.Example(?list = list)

[<ReactLazyComponent>]
let private LazyListsNoArg = Examples.Feliz.RenderingLists.RenderingLists.Example

[<Fable.Core.Erase; Fable.Core.Mangle(false)>]
type Examples =

    [<ReactLazyComponent>]
    static member LazyList(?list: int list) = Examples.Feliz.RenderingLists.RenderingLists.Example(?list = list)

    [<ReactComponent(true)>]
    static member Main() =
        Html.div [
            Html.h1 "ReactLazyComponent Example"
            Html.h2 "With argument"
            LazyLists(Some [1;2;3;4;5])
            Html.h2 "Without argument"
            LazyListsNoArg()
            Html.h2 "Using static member"
            Examples.LazyList([10;20;30])
        ]
"""

let private createIsolatedExampleSpec testName =
    createSnippet
        testName
        """
module Snippet

let value = 1
"""
    |> withAdditionalFile "Examples/Feliz/RenderingLists.fs" renderingListsSource
    |> withAdditionalFile "Examples/Feliz/ReactLazyComponent.fs" reactLazyComponentSource

let private tryFindReactLazyComponentOutput (emittedFiles: string list) =
    emittedFiles
    |> List.tryFind (fun (filePath: string) ->
        filePath.EndsWith("ReactLazyComponent.jsx", StringComparison.OrdinalIgnoreCase)
    )

[<Tests>]
let reactLazyComponentSuccessTests =
    testList "docs ReactLazyComponent success transpilation" [
        test "transpiles docs ReactLazyComponent example" {
            let spec = createIsolatedExampleSpec "react-lazy-component-success"

            withTranspileSuccess
                spec
                (fun success ->
                    Expect.isTrue (success.EmittedFiles.Length > 0) "Expected transpilation to emit output files."

                    let maybeReactLazyOutput = tryFindReactLazyComponentOutput success.EmittedFiles

                    Expect.isTrue maybeReactLazyOutput.IsSome "Expected ReactLazyComponent.jsx to be emitted."

                    match maybeReactLazyOutput with
                    | Some outputPath ->
                        let output = File.ReadAllText(outputPath)

                        Expect.stringContains
                            output
                            "ReactLazyComponent Example"
                            "Expected docs heading text in transpiled ReactLazyComponent output."
                    | None -> ()
                )
        }
    ]
