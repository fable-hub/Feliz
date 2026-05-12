module Tests.ReactBindings.ReactLazyComponent.Wrappers.ByReference

open Browser.Types
open Fable.Core
open Feliz
open Tests.ReactBindings.ReactLazyComponent.Fixtures.Models

[<Erase; Mangle(false)>]
type Components =

    [<ReactLazyComponent>]
    static member Tupled(text: string, ?testId: string, ?className: string, ?onClick: MouseEvent -> unit) =
        Tests.ReactBindings.ReactLazyComponent.Sources.TupledSource.Exports.MyCodeSplitComponent(
            text = text,
            ?testId = testId,
            ?className = className,
            ?onClick = onClick
        )

    [<ReactLazyComponent>]
    static member Curried (text: string) (testId: string option) =
        Tests.ReactBindings.ReactLazyComponent.Sources.CurriedSource.Exports.MyCodeSplitComponentCurried (text) (testId)

    [<ReactLazyComponent>]
    static member AnonymousRecord(props: {| id: int |}) =
        Tests.ReactBindings.ReactLazyComponent.Sources.AnonRecordSource.Exports.MyComp(props)

    [<ReactLazyComponent>]
    static member RecordAndClass(props: DemoRecord) =
        Tests.ReactBindings.ReactLazyComponent.Sources.RecordClassSource.Exports.MyRecordComponent(props)
