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
        prop.style [ 
            if theme = "light" then 
                style.backgroundColor "white"
                style.color "black"
            else 
                style.backgroundColor "black"
                style.color "white"
        ]
        prop.children [
            Html.h1 "Fruit List"
            Html.button [
                prop.text "Add Grape"
                prop.onClick (fun _ -> setFruitArray (Array.append fruitArray [| "Grape" |]))
            ]
            ToggleThemeButton (theme, setTheme)
        ]
    ]
