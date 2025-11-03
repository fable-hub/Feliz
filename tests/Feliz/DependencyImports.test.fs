module DependencyImportTests

open Feliz
open Vitest

type private DependencyImports =
    
    [<ReactComponent("Counter", from="test-counter")>]
    static member Counter(?testId: string, ?props: obj) = React.Imported()

describe """[<ReactComponent("Counter", from="test-counter")>]""" <| fun _ ->
    test "exists" <| fun _ ->
        let render = 
            RTL.render(
                DependencyImports.Counter()
            )

        let counter = render.getByTestId "counter"
        expect(counter).toBeInTheDocument()

    test "settable testId" <| fun _ ->
        let render = 
            RTL.render(
                DependencyImports.Counter(testId = "custom-counter")
            )

        let counter = render.getByTestId "custom-counter"
        expect(counter).toBeInTheDocument()
