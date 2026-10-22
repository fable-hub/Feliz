module Example.UseInputRef

open Feliz

[<ReactComponent(true)>]
let UseRef () =
    let inputRef = React.useInputRef ()
    let value, setValue = React.useState ("")

    Html.div [
        Html.input [
            prop.ref inputRef
            prop.type'.text
            prop.value value
            prop.onChange setValue
            prop.placeholder "Type something..."
        ]
        Html.button [
            prop.text "Focus input"
            prop.onClick (fun _ ->
                match inputRef.current with
                | Some el -> el.focus ()
                | None -> ()
            )
        ]
        Html.p [ prop.text $"Current value: {value}" ]
    ]
