module Tests.ReactBindings.ReactLazyComponent.InputArgsTests

open Browser.Types
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

describe "ReactLazyComponent input arguments"
<| fun _ ->

    testPromise "forwards tupled args and callback by reference"
    <| fun _ -> promise {
        let onClick = vi.fn (fun (_: MouseEvent) -> ())

        do!
            renderAndLoad (fun () ->
                RefLazy.Tupled(text = "tupled-ref", testId = "ref-id", className = "ref-class", onClick = onClick)
            )

        let! tupledRoot = screen.findByTestId "tupled-root"
        expect(tupledRoot).toHaveAttribute ("class", "ref-class")
        expect(screen.getByTestId "tupled-testid").toHaveTextContent "ref-id"

        do! userEvent.click (screen.getByTestId "tupled-button")
        expect(onClick).toHaveBeenCalledTimes 1
    }

    testPromise "forwards tupled args and callback by path"
    <| fun _ -> promise {
        let onClick = vi.fn (fun (_: MouseEvent) -> ())

        do!
            renderAndLoad (fun () ->
                PathLazy.Tupled(text = "tupled-path", testId = "path-id", className = "path-class", onClick = onClick)
            )

        let! tupledRoot = screen.findByTestId "tupled-root"
        expect(tupledRoot).toHaveAttribute ("class", "path-class")
        expect(screen.getByTestId "tupled-testid").toHaveTextContent "path-id"

        do! userEvent.click (screen.getByTestId "tupled-button")
        expect(onClick).toHaveBeenCalledTimes 1
    }

    testPromise "forwards curried args by reference"
    <| fun _ -> promise {
        do! renderAndLoad (fun () -> RefLazy.Curried ("curried-ref") (Some "curried-id"))

        let! loaded = screen.findByTestId "curried-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "curried-text").toHaveTextContent "curried-ref"
        expect(screen.getByTestId "curried-testid").toHaveTextContent "curried-id"
    }

    testPromise "forwards curried args by path"
    <| fun _ -> promise {
        do! renderAndLoad (fun () -> PathLazy.Curried ("curried-path") (None))

        let! loaded = screen.findByTestId "curried-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "curried-text").toHaveTextContent "curried-path"
        expect(screen.getByTestId "curried-testid").toHaveTextContent "none"
    }

    testPromise "forwards anonymous record arg by reference"
    <| fun _ -> promise {
        do! renderAndLoad (fun () -> RefLazy.AnonymousRecord({| id = 123 |}))

        let! loaded = screen.findByTestId "anon-root"
        expect(loaded).toBeInTheDocument ()
        expect(loaded).toHaveTextContent "123"
    }

    testPromise "forwards anonymous record arg by path"
    <| fun _ -> promise {
        do! renderAndLoad (fun () -> PathLazy.AnonymousRecord({| id = 321 |}))

        let! loaded = screen.findByTestId "anon-root"
        expect(loaded).toBeInTheDocument ()
        expect(loaded).toHaveTextContent "321"
    }

    testPromise "forwards mixed record and class payload by reference"
    <| fun _ -> promise {
        let payload = Models.createDemoRecord 10 (Some "record-ref") 88 "owner-ref"
        do! renderAndLoad (fun () -> RefLazy.RecordAndClass(payload))

        let! loaded = screen.findByTestId "record-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "record-id").toHaveTextContent "10"
        expect(screen.getByTestId "record-name").toHaveTextContent "record-ref"
        expect(screen.getByTestId "record-score").toHaveTextContent "88"
        expect(screen.getByTestId "record-owner").toHaveTextContent "owner-ref"
    }

    testPromise "forwards mixed record and class payload by path"
    <| fun _ -> promise {
        let payload = Models.createDemoRecord 11 None 99 "owner-path"
        do! renderAndLoad (fun () -> PathLazy.RecordAndClass(payload))

        let! loaded = screen.findByTestId "record-root"
        expect(loaded).toBeInTheDocument ()
        expect(screen.getByTestId "record-id").toHaveTextContent "11"
        expect(screen.getByTestId "record-name").toHaveTextContent "none"
        expect(screen.getByTestId "record-score").toHaveTextContent "99"
        expect(screen.getByTestId "record-owner").toHaveTextContent "owner-path"
    }
