module Example.AddTransitionType

open Feliz

let private css =
    """
::view-transition-old(.feliz-forward) { animation: 250ms ease-in both feliz-out-left; }
::view-transition-new(.feliz-forward) { animation: 250ms ease-out both feliz-in-right; }
::view-transition-old(.feliz-backward) { animation: 250ms ease-in both feliz-out-right; }
::view-transition-new(.feliz-backward) { animation: 250ms ease-out both feliz-in-left; }
@keyframes feliz-out-left { to { opacity: 0; transform: translateX(-40px); } }
@keyframes feliz-out-right { to { opacity: 0; transform: translateX(40px); } }
@keyframes feliz-in-right { from { opacity: 0; transform: translateX(40px); } }
@keyframes feliz-in-left { from { opacity: 0; transform: translateX(-40px); } }
"""

let private pages = [| "Page 1"; "Page 2"; "Page 3"; "Page 4" |]

[<ReactComponent(true)>]
let AddTransitionType () =
    let index, setIndex = React.useState 0

    let navigate (transitionType: string) (nextIndex: int) =
        React.startTransition (fun () ->
            // Tells the ViewTransition below which animation to use.
            React.addTransitionType transitionType
            setIndex nextIndex
        )

    let isFirst = index = 0
    let isLast = index = pages.Length - 1

    Html.div [
        Html.style [ prop.text css ]
        Html.button [
            prop.disabled isFirst
            prop.onClick (fun _ -> navigate "backward" (index - 1))
            prop.text "Previous"
        ]
        Html.button [
            prop.disabled isLast
            prop.onClick (fun _ -> navigate "forward" (index + 1))
            prop.text "Next"
        ]
        React.ViewTransition [
            viewTransition.update [ "forward", "feliz-forward"; "backward", "feliz-backward"; "default", "none" ]
            viewTransition.children [
                Html.h3 [ prop.style [ style.display.inlineBlock ]; prop.text pages[index] ]
            ]
        ]
    ]
