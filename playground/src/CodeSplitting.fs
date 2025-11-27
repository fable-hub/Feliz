module CodeSplitting

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type CodeSplitting =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent (?text: string) =
        Html.div [
            prop.testId "async-load"
            prop.text (Option.defaultValue "Loaded" text)
        ]
