module Example.HydrateRoot

open Feliz
open Fable.Core.JsInterop

// This example assumes you have server-rendered HTML with id "root" in your HTML
let root =
    ReactDOM.hydrateRoot (Browser.Dom.document.getElementById ("root"), Example.UseId.UseId())
