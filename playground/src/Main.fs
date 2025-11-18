module Main

open Feliz
open Browser.Dom

let private root = ReactDOM.createRoot(document.getElementById "root")
root.render(
    React.StrictMode [
        App.App()
    ]
)
