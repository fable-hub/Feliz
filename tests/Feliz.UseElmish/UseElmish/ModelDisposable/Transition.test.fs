module UseElmishModelDisposableTransitionTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let PromoteDisposable = "promote-disposable"

    [<Literal>]
    let ModelKind = "model-kind"

    [<Literal>]
    let DisposeCount = "dispose-count"

module DisposableTransitionHarness =
    open Elmish
    open Feliz.UseElmish

    type TransitionDisposable(onDispose: unit -> unit) =
        let mutable disposed = false

        interface System.IDisposable with
            member _.Dispose() =
                if not disposed then
                    disposed <- true
                    onDispose ()

    type Model =
        | Plain
        | Disposable of TransitionDisposable

    type Msg = | PromoteToDisposable

    let init () = Plain, Cmd.none

    let update (onDispose: unit -> unit) msg model =
        match msg with
        | PromoteToDisposable ->
            match model with
            | Plain -> Disposable(new TransitionDisposable(onDispose)), Cmd.none
            | Disposable _ -> model, Cmd.none

    let modelKind model =
        match model with
        | Plain -> "plain"
        | Disposable _ -> "disposable"

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(onDispose: unit -> unit) =
            let model, dispatch = React.useElmish (init, update onDispose)

            Html.div [
                Html.button [
                    prop.testId TestIds.PromoteDisposable
                    prop.text "promote"
                    prop.onClick (fun _ -> dispatch PromoteToDisposable)
                ]

                Html.h1 [
                    prop.testId TestIds.ModelKind
                    prop.text (modelKind model)
                ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let disposeCount, setDisposeCount = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.h2 [ prop.testId TestIds.DisposeCount; prop.text disposeCount ]

                if showChild then
                    Child.Render(fun () -> setDisposeCount (fun previous -> previous + 1))
            ]

describe "UseElmish disposable transition"
<| fun () ->
    testPromise "UseElmish_ModelDisposable_TransitionToDisposable_DisposedOnUnmount"
    <| fun () -> promise {
        let render = RTL.render (DisposableTransitionHarness.Parent.Render())

        expect(render.getByTestId TestIds.DisposeCount).toHaveTextContent "0"

        do! userEvent.click (render.getByTestId TestIds.PromoteDisposable)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ModelKind).toHaveTextContent "disposable")

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do!
            RTL.waitFor (fun () ->
                expect(render.queryByTestId TestIds.PromoteDisposable |> Option.isNone).toBeTruthy ()
            )

        expect(render.getByTestId TestIds.DisposeCount).toHaveTextContent "1"
    }

