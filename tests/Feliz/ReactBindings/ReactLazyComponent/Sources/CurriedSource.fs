module Tests.ReactBindings.ReactLazyComponent.Sources.CurriedSource

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Exports =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponentCurried (text: string) (testId: string option) =
        Html.div [
            prop.testId "curried-root"
            prop.children [
                Html.span [ prop.testId "curried-text"; prop.text text ]

                Html.span [
                    prop.testId "curried-testid"
                    prop.text (defaultArg testId "none")
                ]
            ]
        ]
