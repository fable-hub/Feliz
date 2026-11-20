module Example.UseEffectEvent

open Fable.Core
open Feliz

[<ReactComponent(true)>]
let UseEffectEvent () =
    let count, setCount = React.useStateWithUpdater 0
    let step, setStep = React.useState 1

    // Always reads the current `step`, but is not a dependency of the effect below.
    let onTick = React.useEffectEvent (fun () -> setCount (fun count -> count + step))

    // The interval is created once. Changing `step` doesn't restart it.
    React.useEffectOnce (fun () ->
        let intervalId = JS.setInterval (fun () -> onTick ()) 1000
        fun () -> JS.clearInterval intervalId
    )

    Html.div [
        Html.p $"Count: {count}"
        Html.button [ prop.onClick (fun _ -> setStep (step + 1)); prop.text $"Step: {step} (click to increase)" ]
    ]
