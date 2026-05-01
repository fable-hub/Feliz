module CodeSplitting

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type CodeSplitting =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent
        (text: string, ?testId: string, ?className: string, ?onClick: Browser.Types.MouseEvent -> unit)
        =
        Html.div [
            if testId.IsSome then
                prop.testId testId.Value
            if className.IsSome then
                prop.className className.Value
            if onClick.IsSome then
                prop.onClick onClick.Value
            prop.text text
        ]
