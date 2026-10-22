module Example.CreateRoot

open Feliz
open Fable.Core.JsInterop


[<ReactComponent>]
let private App () = Html.h1 "Hello, Feliz!"

let private root = ReactDOM.createRoot (Browser.Dom.document.getElementById "root")
root.render (App())
