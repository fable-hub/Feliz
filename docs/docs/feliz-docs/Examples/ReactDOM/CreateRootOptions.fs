module Example.CreateRootOptions

open Browser
open Feliz

[<ReactComponent>]
let private App () = Html.h1 "Hello, Feliz!"

let private root =
    ReactDOM.createRoot (
        document.getElementById "root",
        RootOptions(
            // Prefix for IDs from React.useId, e.g. when several React roots share a page.
            identifierPrefix = "app-",
            // An error boundary caught an error (it already rendered its fallback).
            onCaughtError = (fun error info -> console.warn ("Caught:", error.Message, info.componentStack)),
            // No error boundary caught the error; React unmounted the app. Report it.
            onUncaughtError = (fun error info -> console.error ("Uncaught:", error.Message, info.componentStack)),
            // React recovered on its own, e.g. after a hydration mismatch.
            onRecoverableError = (fun error _ -> console.warn ("Recovered:", error.Message))
        )
    )

root.render (App())
