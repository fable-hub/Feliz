module Example.UseActionState

open Fable.Core
open Browser.Types
open Feliz

/// Pretends to update the name on a server. Rejects empty names.
let updateName (name: string) : JS.Promise<Result<string, string>> = promise {
    do! Promise.sleep 1000

    if System.String.IsNullOrWhiteSpace name then
        return Error "Please enter a name."
    else
        return Ok name
}

[<ReactComponent(true)>]
let UseActionState () =
    let message, submitAction, isPending =
        React.useActionState (
            (fun (_previousMessage: string) (formData: FormData) -> promise {
                let! result = updateName (unbox<string> (formData.get "name"))

                match result with
                | Ok name -> return $"Saved '{name}'."
                | Error error -> return error
            }),
            ""
        )

    Html.form [
        // React calls the action with the form's data and resets the input afterwards.
        prop.action submitAction
        prop.children [
            Html.input [ prop.name "name"; prop.placeholder "Your name" ]
            Html.button [
                prop.type'.submit
                prop.disabled isPending
                prop.text (if isPending then "Saving..." else "Save")
            ]
            if message <> "" then
                Html.p message
        ]
    ]
