module Example.FragmentRef

open Feliz

[<ReactComponent(true)>]
let FragmentRef () =
    let fieldsRef = React.useRef<FragmentInstance option> None

    Html.div [
        Html.button [
            // Focuses the first focusable element inside the Fragment.
            prop.onClick (fun _ -> fieldsRef.current |> Option.iter (fun fields -> fields.focus ()))
            prop.text "Focus first field"
        ]
        Html.div [
            // No wrapper element: the inputs are direct children of this div.
            React.Fragment(
                fieldsRef,
                [
                    Html.input [ prop.placeholder "First name" ]
                    Html.input [ prop.placeholder "Last name" ]
                ]
            )
        ]
    ]
