module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

type jsx = JSX.Html

[<ReactMemoComponent(true)>]
let ToggleThemeButton (theme: string, setTheme: string -> unit) =
    Html.button [
        prop.text "Toggle Theme"
        prop.onClick (fun _ -> 
            if theme = "light" then setTheme "dark"
            else setTheme "light"
        )
    ]

[<ReactComponent>]
let Main () =
    let fruitArray, setFruitArray = React.useState ([| "Apple"; "Banana"; "Orange" |]) // This stays the same array
    let sortedFruits = Array.sort fruitArray // this creates a new array instance on each render
    let theme, setTheme = React.useState "light"
    Html.div [
        Svg.svg [
            svg.width 300
            svg.height 120
            svg.viewBox "0 0 300 120"
            svg.children [
                Svg.path [
                    svg.d "M60,10 L60,110
              M30,10 L300,10
              M30,65 L300,65
              M30,110 L300,110"
                    svg.stroke "black"
                    svg.strokeWidth 2
                ]
                Svg.text [
                    svg.x 60
                    svg.y 10
                    svg.alignmentBaseline.hanging
                    svg.text "A hanging"
                ]
                Svg.text [
                    svg.x 60
                    svg.y 65
                    svg.alignmentBaseline.middle
                    svg.text "A middle"
                ]
                Svg.text [
                    svg.x 60
                    svg.y 110
                    svg.alignmentBaseline.baseline
                    svg.text "A baseline"
                ]
            ]
        ]
    ]
