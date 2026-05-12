module Tests.ReactBindings.ReactLazyComponent.LoadingTests

open Fable.Core
open Fable.Core.JsInterop
open Vitest

type RefLazy = Tests.ReactBindings.ReactLazyComponent.Wrappers.ByReference.Components
type PathLazy = Tests.ReactBindings.ReactLazyComponent.Wrappers.ByPath.Components
type LoadWrapper = Tests.ReactBindings.ReactLazyComponent.Fixtures.LazyLoadWrapper.Components
module Models = Tests.ReactBindings.ReactLazyComponent.Fixtures.Models

let private renderAndLoad renderLazy = promise {
    RTL.render (LoadWrapper.LoadOnSwitch(renderLazy)) |> ignore
    let switchButton = screen.getByTestId "load-switch"
    do! userEvent.click switchButton
}

describe "ReactLazyComponent loading"
<| fun _ ->

    testPromise "loads by-reference tupled component when switch is clicked"
    <| fun _ -> promise {
        do! renderAndLoad (fun () -> RefLazy.Tupled(text = "tupled-ref", testId = "ref-id", className = "ref-class"))

        let! loaded = screen.findByTestId "tupled-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "tupled-text").toHaveTextContent "tupled-ref"
    }

    testPromise "loads by-path tupled component when switch is clicked"
    <| fun _ -> promise {
        do!
            renderAndLoad (fun () ->
                PathLazy.Tupled(text = "tupled-path", testId = "path-id", className = "path-class")
            )

        let! loaded = screen.findByTestId "tupled-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "tupled-text").toHaveTextContent "tupled-path"
    }

    testPromise "loads by-reference record and class payload when switch is clicked"
    <| fun _ -> promise {
        let payload = Models.createDemoRecord 7 (Some "record-name") 33 "owner-ref"
        do! renderAndLoad (fun () -> RefLazy.RecordAndClass(payload))

        let! loaded = screen.findByTestId "record-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "record-owner").toHaveTextContent "owner-ref"
    }

    testPromise "loads by-path record and class payload when switch is clicked"
    <| fun _ -> promise {
        let payload = Models.createDemoRecord 8 (Some "record-path") 44 "owner-path"
        do! renderAndLoad (fun () -> PathLazy.RecordAndClass(payload))

        let! loaded = screen.findByTestId "record-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "record-owner").toHaveTextContent "owner-path"
    }
