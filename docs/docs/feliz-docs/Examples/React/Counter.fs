module Example.React

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Counter =

    [<ReactComponent(true)>]
    static member Counter() =
    
        let (count, setCount) = React.useState 0

        Html.div [
            Html.h1 count
            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
        ]
