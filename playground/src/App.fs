module App

open Feliz
open Browser.Dom
open Fable.Core
open Fable.Core.JsInterop
open Shared

[<ReactComponent>]
let App() =
    Html.div [
        Components.Test(null)
        Components.Test("Hello")
    ]
