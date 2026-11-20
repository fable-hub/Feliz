module Example.UseTransition

open Fable.Core
open Feliz

/// Takes about 1 ms to render, so a list of 300 of them is noticeably slow.
[<ReactComponent>]
let SlowPost (index: int) =
    let start = JS.Constructors.Date.now ()

    while JS.Constructors.Date.now () - start < 1.0 do
        ()

    Html.text $"Post #{index}"

/// Memoized, so re-renders of the parent (e.g. showing the pending state) skip it.
[<ReactMemoComponent>]
let PostsTab () =
    Html.ul [
        for index in 1..300 -> Html.li [ prop.key index; prop.children [ SlowPost index ] ]
    ]

[<ReactComponent(true)>]
let UseTransition () =
    let tab, setTab = React.useState "about"
    let isPending, startTransition = React.useTransition ()

    Html.div [
        Html.div [
            for name in [ "about"; "posts"; "contact" ] ->
                let isActive = tab = name

                Html.button [
                    prop.key name
                    prop.style [ style.marginRight 8 ]
                    prop.disabled isActive
                    // Rendering the posts tab is slow. As a transition it doesn't block the buttons.
                    prop.onClick (fun _ -> startTransition (fun () -> setTab name))
                    prop.text name
                ]
        ]
        if isPending then
            Html.p [ prop.style [ style.color "gray" ]; prop.text "Loading..." ]
        match tab with
        | "posts" -> PostsTab()
        | "contact" -> Html.p "You can find us on GitHub."
        | _ -> Html.p "Click 'posts' and then quickly 'contact': the slow render is interrupted."
    ]
