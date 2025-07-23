module Example.EffectfulTimer

open System
open Feliz
open Fable.Core.JS

[<ReactComponent(true)>]
let EffectfulTimer() =
    let (paused, setPaused) = React.useState(false)
    // using useStateWithUpdater instead of useState
    // to avoid stale closures in React.useEffect
    let (value, setValue) = React.useStateWithUpdater(0)

    let subscribeToTimer() =
        // start the timer
        let subscriptionId = setInterval (fun _ -> if not paused then setValue (fun prev -> prev + 1)) 1000
        // return IDisposable with cleanup code that stops the timer
        { new IDisposable with member this.Dispose() = clearInterval(subscriptionId) }

    React.useEffect(subscribeToTimer, [| box paused |])

    Html.div [
        Html.h1 value

        Html.button [
            prop.style [
                if paused then
                    style.backgroundColor "yellow"
                else
                    style.backgroundColor "green"
            ]

            prop.onClick (fun _ -> setPaused(not paused))
            prop.text (if paused then "Resume" else "Pause")
        ]
    ]
