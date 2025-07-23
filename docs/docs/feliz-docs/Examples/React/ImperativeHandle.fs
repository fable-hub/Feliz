module Example.ImperativeHandle

open Feliz

let ForwardRefImperativeChild = React.forwardRef(fun ((), ref) ->
    let divText,setDivText = React.useState ""
    let inputRef = React.useInputRef()

    React.useImperativeHandle(ref, fun () ->
        inputRef.current
        |> Option.map(fun innerRef ->
            {| focus = fun () -> setDivText innerRef.className |})
    )

    Html.div [
        Html.input [
            prop.className "Howdy!"
            prop.type'.text
            prop.ref inputRef
        ]
        Html.div [
            prop.text divText
        ]
    ])

[<ReactComponent(true)>]
let ForwardRefImperativeParent() =
    let ref = React.useRef<{| focus: unit -> unit |} option>(None)

    Html.div [
        ForwardRefImperativeChild((), ref)
        Html.button [
            prop.text "Focus Input"
            prop.onClick <| fun ev ->
                ref.current
                |> Option.iter (fun elem -> elem.focus())
        ]
    ]
