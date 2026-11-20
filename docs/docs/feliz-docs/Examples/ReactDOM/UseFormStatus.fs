module Example.UseFormStatus

open Fable.Core
open Browser.Types
open Feliz

/// Reads the status of the form it is rendered in; no props needed.
[<ReactComponent>]
let SubmitButton () =
    let status = ReactDOM.useFormStatus ()

    Html.button [
        prop.type'.submit
        prop.disabled status.pending
        prop.text (
            match status.data with
            | Some data when status.pending ->
                let message = unbox<string> (data.get "message")
                $"Sending '{message}'..."
            | _ -> "Send"
        )
    ]

[<ReactComponent(true)>]
let UseFormStatus () =
    let lastMessage, setLastMessage = React.useState ""

    Html.form [
        prop.action (fun (formData: FormData) -> promise {
            do! Promise.sleep 1500
            React.startTransition (fun () -> setLastMessage (unbox<string> (formData.get "message")))
        })
        prop.children [
            Html.input [ prop.name "message"; prop.placeholder "Message" ]
            SubmitButton()
            if lastMessage <> "" then
                Html.p $"Sent: {lastMessage}"
        ]
    ]
