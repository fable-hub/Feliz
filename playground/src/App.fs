module App

open Feliz
open Browser.Dom

let App() =
    Html.div [
        prop.children [
            Components.Components.Testing()
            Html.div "Test"
        ]
    ]
