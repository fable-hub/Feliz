module Main

open Feliz
open Browser.Dom

let private root = ReactDOM.createRoot(document.getElementById "root")
root.render(App.App())
