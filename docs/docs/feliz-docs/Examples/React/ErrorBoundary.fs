module Example.ErrorBoundary

open Browser
open Feliz

[<ReactComponent>]
let FragileCounter () =
    let count, setCount = React.useState 0

    if count >= 3 then
        failwith "The counter crashed at 3!"

    Html.button [ prop.onClick (fun _ -> setCount (count + 1)); prop.text $"Count: {count} (crashes at 3)" ]

[<ReactComponent(true)>]
let ErrorBoundary () =
    React.ErrorBoundary(
        [ FragileCounter() ],
        (fun props ->
            Html.div [
                Html.p $"Something went wrong: {props.error.Message}"
                // Renders the children again; FragileCounter starts over at 0.
                Html.button [ prop.onClick (fun _ -> props.reset ()); prop.text "Try again" ]
            ]
        ),
        onError = fun error info -> console.warn ("Caught by ErrorBoundary:", error.Message, info.componentStack)
    )
