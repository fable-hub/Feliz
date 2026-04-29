module Main

open Feliz
open Browser.Dom

let private root = ReactDOM.createRoot (document.getElementById "root")

// root.render (React.StrictMode [ UseElmishExample.CleanupHarness.Parent.Render() ])
root.render (UseElmishExample.CleanupHarness.Parent.Render())
