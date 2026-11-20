module Example.RequestFormReset

open Fable.Core.JsInterop
open Browser.Types
open Feliz

[<ReactComponent(true)>]
let RequestFormReset () =
    let notes, setNotes = React.useState ([]: string list)

    Html.div [
        Html.form [
            // A plain submit handler instead of a form action, so React doesn't reset the form by itself.
            prop.onSubmit (fun ev ->
                ev.preventDefault ()
                let form = unbox<HTMLFormElement> ev.currentTarget
                // Named form controls are properties of the form element.
                let note: string = form?note?value

                React.startTransition (fun () ->
                    setNotes (notes @ [ note ])
                    ReactDOM.requestFormReset form
                )
            )
            prop.children [
                Html.input [ prop.name "note"; prop.defaultValue "A new note" ]
                Html.button [ prop.type'.submit; prop.text "Add note" ]
            ]
        ]
        Html.ul [ for index, note in List.indexed notes -> Html.li [ prop.key index; prop.text note ] ]
    ]
