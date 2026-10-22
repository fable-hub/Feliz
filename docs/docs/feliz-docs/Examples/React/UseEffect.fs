module Example.UseEffect

open Feliz

[<ReactComponent(true)>]
let UseEffect () =
    let count, setCount = React.useState (0)
    // useEffect: run side effect when count changes
    React.useEffect (
        (fun () ->
            Fable.Core.JS.console.log ($"Count changed to {count}")
            // Optional cleanup function
            fun () -> Fable.Core.JS.console.log ("Cleanup effect")
        ),
        [| box count |]
    )

    Html.div [
        Html.button [
            prop.text $"Clicked {count} times"
            prop.onClick (fun _ -> setCount (count + 1))
        ]
        Html.p [
            prop.text "Open the browser console to see useEffect logs when count changes."
        ]
    ]
