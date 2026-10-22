module Main

open Feliz
open App
open Browser.Dom

Fable.Core.JsInterop.importSideEffects "./tailwind.css"

let root = ReactDOM.createRoot (document.getElementById "feliz-app")
root.render (Components.Counter())