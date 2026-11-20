module Example.Profiler

open Feliz

[<ReactComponent>]
let Counter () =
    let count, setCount = React.useState 0
    Html.button [ prop.onClick (fun _ -> setCount (count + 1)); prop.text $"Clicked {count} times" ]

[<ReactComponent(true)>]
let Profiler () =
    let lastCommit = React.useRef "nothing measured yet"
    let report, setReport = React.useState ""

    Html.div [
        React.Profiler(
            "counter",
            (fun info ->
                // Don't set state here: onRender runs after every commit, so that would loop.
                lastCommit.current <- $"{info.phase} took {System.Math.Round(info.actualDuration, 2)} ms"
            ),
            [ Counter() ]
        )
        Html.button [ prop.onClick (fun _ -> setReport lastCommit.current); prop.text "Show last commit" ]
        Html.p report
    ]
