module CodeSplitting

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type CodeSplitting =

    [<ReactComponent>]
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

    [<ReactComponent(true)>]
    static member MyCodeSplitComponentCurried (text: string) (testId: string option) =
        Html.div [
            if testId.IsSome then
                prop.testId testId.Value
            prop.text text
        ]
