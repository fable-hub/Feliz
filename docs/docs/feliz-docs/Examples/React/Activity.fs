module Example.Activity

open Feliz

[<ReactComponent>]
let Draft (label: string) =
    let text, setText = React.useState ""

    Html.div [
        Html.p label
        Html.textarea [ prop.value text; prop.onChange setText; prop.placeholder "Type something" ]
    ]

[<ReactComponent(true)>]
let Activity () =
    let showDrafts, setShowDrafts = React.useState true

    let mode =
        if showDrafts then
            ActivityMode.Visible
        else
            ActivityMode.Hidden

    Html.div [
        Html.button [
            prop.onClick (fun _ -> setShowDrafts (not showDrafts))
            prop.text (if showDrafts then "Hide drafts" else "Show drafts")
        ]
        // Hidden with Activity: the text is kept while hidden.
        React.Activity(mode, Draft "Inside Activity")
        // Hidden with `if`: the component unmounts and the text is lost.
        if showDrafts then
            Draft "Conditionally rendered"
    ]
