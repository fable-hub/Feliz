module Example.ForwardRef

open Feliz

let ForwardRefChild = React.forwardRef(fun ((), ref) ->
    Html.input [
        prop.type'.text
        prop.ref ref
    ])

[<ReactComponent(true)>]
let ForwardRefParent() =
    let inputRef = React.useInputRef()

    Html.div [
        ForwardRefChild((), inputRef)
        Html.button [
            prop.text "Focus Input"
            prop.onClick <| fun ev ->
                inputRef.current
                |> Option.iter (fun elem -> elem.focus())
        ]
    ]
