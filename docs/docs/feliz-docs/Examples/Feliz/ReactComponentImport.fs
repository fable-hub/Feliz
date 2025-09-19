module Examples.Feliz.ReactComponentImport

open Feliz


type Component = 

    [<ReactComponent("Counter", "./NativeCounter")>]
    static member Counter(?init: int) = React.Imported()

    [<ReactComponent(true)>]
    static member Example() =
        Html.div [
            Component.Counter()
            Component.Counter(10)
        ]
