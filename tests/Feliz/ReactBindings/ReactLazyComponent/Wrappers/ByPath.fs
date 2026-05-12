module Tests.ReactBindings.ReactLazyComponent.Wrappers.ByPath

open Browser.Types
open Fable.Core
open Feliz
open Tests.ReactBindings.ReactLazyComponent.Fixtures.Models

[<Erase; Mangle(false)>]
type Components =

    [<ReactLazyComponent>]
    static member Tupled(text: string, ?testId: string, ?className: string, ?onClick: MouseEvent -> unit) =
        React.DynamicImported "../Sources/TupledSource.jsx"

    [<ReactLazyComponent>]
    static member Curried (text: string) (testId: string option) =
        React.DynamicImported "../Sources/CurriedSource.jsx"

    [<ReactLazyComponent>]
    static member AnonymousRecord(props: {| id: int |}) =
        React.DynamicImported "../Sources/AnonRecordSource.jsx"

    [<ReactLazyComponent>]
    static member RecordAndClass(props: DemoRecord) =
        React.DynamicImported "../Sources/RecordClassSource.jsx"
