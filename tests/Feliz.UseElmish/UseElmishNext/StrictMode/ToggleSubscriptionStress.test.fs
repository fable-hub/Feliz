module UseElmishNextStrictModeToggleSubscriptionStressTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("window.addEventListener($0, $1)")>]
let private addEventListener (eventName: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.removeEventListener($0, $1)")>]
let private removeEventListener (eventName: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.dispatchEvent(new CustomEvent($0))")>]
let private dispatchCustomEvent (eventName: string) : unit = jsNative

[<Emit("new Promise(function(resolve) { setTimeout(resolve, $0); })")>]
let private delay (milliseconds: int) : JS.Promise<unit> = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ToggleChild = "toggle-child"

    [<Literal>]
    let FireEvent = "fire-event"

    [<Literal>]
    let ParentCount = "parent-count"

    [<Literal>]
    let ChildCount = "child-count"

module StrictModeToggleStressHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = { ChildCount: int }

    type Msg = | GotEvent

    let init () = { ChildCount = 0 }, Cmd.none

    let update (onParentEvent: unit -> unit) msg model =
        match msg with
        | GotEvent ->
            onParentEvent ()

            {
                model with
                    ChildCount = model.ChildCount + 1
            },
            Cmd.none

    let subscribe (_model: Model) : Sub<Msg> = [
        [ "strict-toggle-event-subscription" ],
        (fun dispatch ->
            let handler = fun (_: obj) -> dispatch GotEvent
            addEventListener "strict-toggle-event" handler

            { new System.IDisposable with
                member _.Dispose() =
                    removeEventListener "strict-toggle-event" handler
            }
        )
    ]

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(onParentEvent: unit -> unit) =
            let model, _ = React.useElmishNext (init, update onParentEvent, subscribe)

            Html.h1 [
                prop.testId TestIds.ChildCount
                prop.text model.ChildCount
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let parentCount, setParentCount = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChild
                    prop.text "toggle"
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.button [
                    prop.testId TestIds.FireEvent
                    prop.text "fire"
                    prop.onClick (fun _ -> dispatchCustomEvent "strict-toggle-event")
                ]

                Html.h1 [ prop.testId TestIds.ParentCount; prop.text parentCount ]

                if showChild then
                    Child.Render(fun () -> setParentCount (fun previous -> previous + 1))
            ]

describe "UseElmishNext strict mode toggle stress"
<| fun () ->
    testPromise "UseElmishNext_StrictMode_RepeatMountUnmount_NoZombieSubscriptions"
    <| fun () -> promise {
        let render =
            RTL.render (React.StrictMode [ StrictModeToggleStressHarness.Parent.Render() ])

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ParentCount).toHaveTextContent "1")

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildCount |> Option.isNone).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.FireEvent)
        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.ParentCount).toHaveTextContent "1"

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildCount |> Option.isSome).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ParentCount).toHaveTextContent "2")

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildCount |> Option.isNone).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.FireEvent)
        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.ParentCount).toHaveTextContent "2"

        do! userEvent.click (render.getByTestId TestIds.ToggleChild)

        do! RTL.waitFor (fun () -> expect(render.queryByTestId TestIds.ChildCount |> Option.isSome).toBeTruthy ())

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ParentCount).toHaveTextContent "3")
    }
