module Example.UseAsyncTransition

open Fable.Core
open Feliz

/// Pretends to save the name on a server.
let saveName (name: string) : JS.Promise<string> = promise {
    do! Promise.sleep 1500
    return name.Trim()
}

[<ReactComponent(true)>]
let UseAsyncTransition () =
    let name, setName = React.useState ""
    let savedName, setSavedName = React.useState "nobody"
    let isPending, startTransition = React.useAsyncTransition ()

    Html.div [
        Html.input [ prop.value name; prop.onChange setName; prop.placeholder "Your name" ]
        Html.button [
            prop.disabled (isPending || name = "")
            prop.onClick (fun _ ->
                startTransition (fun () -> promise {
                    let! saved = saveName name
                    // Updates after `let!` are not part of the transition anymore, so wrap them again.
                    React.startTransition (fun () -> setSavedName saved)
                })
            )
            prop.text (if isPending then "Saving..." else "Save")
        ]
        Html.p $"Saved name: {savedName}"
    ]
