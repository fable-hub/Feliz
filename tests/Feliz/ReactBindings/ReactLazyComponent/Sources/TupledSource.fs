module Tests.ReactBindings.ReactLazyComponent.Sources.TupledSource

open Browser.Types
open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Exports =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent
        (text: string, ?testId: string, ?className: string, ?onClick: MouseEvent -> unit)
        =
        Html.div [
            prop.testId "tupled-root"

            if className.IsSome then
                prop.className className.Value
            prop.children [
                Html.span [ prop.testId "tupled-text"; prop.text text ]

                Html.span [
                    prop.testId "tupled-testid"
                    prop.text (defaultArg testId "none")
                ]

                Html.button [
                    prop.testId "tupled-button"
                    prop.text "Tupled click"

                    if onClick.IsSome then
                        prop.onClick onClick.Value
                ]
            ]
        ]
