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

