module Example.UseInsertionEffect

open Browser
open Feliz

let private insertedRules = System.Collections.Generic.HashSet<string>()

/// A tiny CSS-in-JS helper: inserts a `<style>` rule once per class name, before any layout effect reads the DOM.
let useCss (className: string) (css: string) =
    React.useInsertionEffect (
        (fun () ->
            if insertedRules.Add className then
                let styleElement = document.createElement "style"
                styleElement.textContent <- $".{className} {{ {css} }}"
                document.head.appendChild styleElement |> ignore
        ),
        [| box className; box css |]
    )

    className

[<ReactComponent(true)>]
let UseInsertionEffect () =
    let className =
        useCss "feliz-insertion-demo" "padding: 8px; border: 2px dashed rebeccapurple; border-radius: 6px;"

    Html.div [
        prop.className className
        prop.text "Styled by a rule inserted with useInsertionEffect."
    ]
