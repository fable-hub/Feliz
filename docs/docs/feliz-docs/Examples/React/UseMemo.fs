module Example.UseMemo

open Feliz
open Fable.Core
open Fable.Core.JS

[<StringEnum>]
type Theme =
    | Light
    | Dark

type IPerformance =
    abstract now: unit -> int

[<Global>]
let performance: IPerformance = jsNative

let artificiallySlowMultiply (numbers: int list) (factor: int) =
    let startTime = performance.now ()

    while performance.now () - startTime < 500 do
        () // Busy wait for 500ms to simulate a heavy computation

    numbers |> List.map (fun n -> n * factor)


[<ReactComponent(true)>]
let UseMemo () =
    let theme, setTheme = React.useState (Theme.Light)
    let numbers, setNumbers = React.useState ([ 1..10 ])
    let factor, setFactor = React.useState (2)
    // useMemo: memoize expensive calculation
    let multiplied =
        React.useMemo ((fun () -> artificiallySlowMultiply numbers factor), [| box numbers; box factor |])

    Html.div [
        prop.style [
            match theme with
            | Theme.Light ->
                style.backgroundColor.white
                style.color.black
            | Theme.Dark ->
                style.backgroundColor.black
                style.color.white
        ]
        prop.children [
            Html.button [
                prop.text "Switch theme"
                prop.onClick (fun _ -> setTheme (if theme = Theme.Light then Theme.Dark else Theme.Light))
            ]
            Html.button [
                prop.textf "Increment factor: %d" factor
                prop.onClick (fun _ -> setFactor (factor + 1))
            ]
            Html.p [
                prop.text
                    "The multiplied list is memoized and only recalculated when numbers or factor change. You can change theme without retriggering calculation"
            ]
            Html.p [ prop.textf "Multiplied: %A" multiplied ]
        ]
    ]
