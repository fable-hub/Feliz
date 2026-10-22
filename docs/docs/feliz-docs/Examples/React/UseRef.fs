module Example.UseRef

open Feliz
open Fable.Core

[<ReactComponent(true)>]
let UseRef () =
    let timeoutRef = React.useRef (None)
    let message, setMessage = React.useState ("No timeout started.")

    Html.div [
        Html.button [
            prop.text "Start Timeout"
            prop.onClick (fun _ ->
                // Clear any existing timeout
                match timeoutRef.current with
                | Some id -> JS.clearTimeout id
                | None -> ()
                // Start a new timeout
                let id =
                    JS.setTimeout
                        (fun _ ->
                            timeoutRef.current <- None
                            setMessage ("Timeout finished!")
                        )
                        3000

                timeoutRef.current <- Some id
                setMessage ("Timeout started. Will finish in 3 seconds.")
            )
        ]
        Html.button [
            prop.text "Cancel Timeout"
            prop.onClick (fun _ ->
                match timeoutRef.current with
                | Some id ->
                    JS.clearTimeout id
                    timeoutRef.current <- None
                    setMessage ("Timeout cancelled.")
                | None -> setMessage ("No timeout to cancel.")
            )
        ]
        Html.p [ prop.text message ]
    ]
