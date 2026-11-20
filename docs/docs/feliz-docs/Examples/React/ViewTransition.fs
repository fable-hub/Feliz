module Example.ViewTransition

open Feliz

/// React adds the class to the view transition; the `::view-transition-*` pseudo-elements animate it.
let private css =
    """
::view-transition-old(.feliz-slide) { animation: 250ms ease-in both feliz-slide-out; }
::view-transition-new(.feliz-slide) { animation: 250ms ease-out both feliz-slide-in; }
@keyframes feliz-slide-out { to { opacity: 0; transform: translateX(-40px); } }
@keyframes feliz-slide-in { from { opacity: 0; transform: translateX(40px); } }
"""

let private fruits = [| "Apple"; "Banana"; "Cherry"; "Date" |]

[<ReactComponent(true)>]
let ViewTransition () =
    let index, setIndex = React.useState 0

    Html.div [
        Html.style [ prop.text css ]
        Html.button [
            // Only updates inside a transition animate.
            prop.onClick (fun _ -> React.startTransition (fun () -> setIndex ((index + 1) % fruits.Length)))
            prop.text "Next fruit"
        ]
        React.ViewTransition [
            viewTransition.update "feliz-slide"
            viewTransition.children [
                Html.h3 [ prop.style [ style.display.inlineBlock ]; prop.text fruits[index] ]
            ]
        ]
    ]
