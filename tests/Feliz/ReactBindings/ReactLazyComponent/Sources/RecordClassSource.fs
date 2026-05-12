module Tests.ReactBindings.ReactLazyComponent.Sources.RecordClassSource

open Fable.Core
open Feliz
open Tests.ReactBindings.ReactLazyComponent.Fixtures.Models

[<Erase; Mangle(false)>]
type Exports =

    [<ReactComponent(true)>]
    static member MyRecordComponent(props: DemoRecord) =
        Html.div [
            prop.testId "record-root"
            prop.children [
                Html.span [ prop.testId "record-id"; prop.text (string props.Id) ]

                Html.span [
                    prop.testId "record-name"
                    prop.text (defaultArg props.Name "none")
                ]

                Html.span [
                    prop.testId "record-score"
                    prop.text (string props.Meta.score)
                ]

                Html.span [ prop.testId "record-owner"; prop.text props.Owner.Label ]
            ]
        ]
