module Tests.ReactBindings.ReactLazyComponent.Sources.AnonRecordSource

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Exports =

    [<ReactComponent(true)>]
    static member MyComp(props: {| id: int |}) =
        Html.div [ prop.testId "anon-root"; prop.text (string props.id) ]
