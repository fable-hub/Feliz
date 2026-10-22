module Examples.Guides.UnboxStringEnum

open Fable.Core
open Feliz

open Fable.Core.JsInterop // open this to use the `!!` operator

[<StringEnum; RequireQualifiedAccess>]
type Theme =
    | Light
    | Dark
    | System

let setTheme (theme: Theme) =
    // We can do either `unbox<string> theme` or `unbox theme`
    // `unbox theme` works because the compiler can infer the target type from the context of the function call
    Browser.Dom.document.documentElement.setAttribute ("data-theme", unbox<string> theme)
    Browser.Dom.window.localStorage.setItem ("theme", unbox<string> theme)
    // We can also use the `!!` operator to unbox. It works the same way as `unbox` by type inference
    // It can be used after `open Fable.Core.JsInterop`.
    Browser.Dom.window.sessionStorage.setItem ("theme", !!theme)
