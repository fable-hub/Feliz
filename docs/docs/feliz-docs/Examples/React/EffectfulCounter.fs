module Example.EffectfulCounter

open Feliz

[<ReactComponent(true)>]
let TabCounter() =
    let (count, setCount) = React.useState(0)
    // execute this effect on every render cycle
    React.useEffect(fun () -> Browser.Dom.document.title <- sprintf "Count = %d" count)

    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount(count + 1))
        ]
    ]
