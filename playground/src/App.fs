module App

open Feliz
open Browser.Dom
open Fable.Core

let App() =
    Html.div [
        prop.children [
            Components.Components.Counter()
        ]
    ]
