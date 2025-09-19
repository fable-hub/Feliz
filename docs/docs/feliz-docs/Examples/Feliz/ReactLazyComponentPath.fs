module Examples.Feliz.ReactLazyComponentPath

open Feliz

[<ReactLazyComponent>]
let private LazyLists(list: int list option) = React.DynamicImported "./RenderingLists"

[<ReactLazyComponent>]
let private LazyListsNoArg() = React.DynamicImported "./RenderingLists"

[<Fable.Core.Erase; Fable.Core.Mangle(false)>]
type Examples =
    
    [<ReactLazyComponent>]
    static member LazyList(?list: int list) = React.DynamicImported "./RenderingLists"

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

