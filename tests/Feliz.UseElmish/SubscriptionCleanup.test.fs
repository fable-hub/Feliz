module UseElmishSubscriptionCleanupTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("window.addEventListener($0, $1)")>]
let private addEventListener (event: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.removeEventListener($0, $1)")>]
let private removeEventListener (event: string) (handler: obj -> unit) : unit = jsNative

[<Emit("window.dispatchEvent(new CustomEvent($0))")>]
let private dispatchCustomEvent (name: string) : unit = jsNative

[<Emit("new Promise(function(resolve) { setTimeout(resolve, $0); })")>]
let private delay (milliseconds: int) : JS.Promise<unit> = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ParentCounter = "parent-counter"

    [<Literal>]
    let ChildCounter = "child-counter"

    [<Literal>]
    let ChildIncrementButton = "child-increment"

    [<Literal>]
    let ToggleChildButton = "toggle-child"

    [<Literal>]
    let FireWindowEventButton = "fire-window-event"

module CleanupHarness =
    open Elmish
    open Feliz.UseElmish

    type State = { Count: int }

    type Msg =
        | Increment
        | GotWindowEvent

    let init () = { Count = 0 }, Cmd.none

    let update msg state =
        match msg with
        | Increment -> { state with Count = state.Count + 1 }, Cmd.none
        | GotWindowEvent -> { state with Count = state.Count + 1 }, Cmd.none

    let subscribe (setParentCounter: (int -> int) -> unit) (_model: State) : Sub<Msg> = [
        [ "my-custom-event" ],
        (fun dispatch ->
            let handler =
                fun (_: obj) ->
                    dispatch GotWindowEvent
                    setParentCounter (fun prev -> prev + 1)

            addEventListener "my-custom-event" handler

            { new System.IDisposable with
                member _.Dispose() =
                    removeEventListener "my-custom-event" handler
            }
        )
    ]

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(setParentCounter: (int -> int) -> unit) =
            let state, dispatch = React.useElmish (init, update, subscribe setParentCounter)

            Html.div [
                Html.h1 [ prop.testId TestIds.ChildCounter; prop.text state.Count ]

                Html.button [
                    prop.text "Increment"
                    prop.onClick (fun _ -> dispatch Increment)
                    prop.testId TestIds.ChildIncrementButton
                ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let showChild, setShowChild = React.useState true
            let parentCounter, setParentCounter = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ToggleChildButton
                    prop.text (if showChild then "Unmount child" else "Mount child")
                    prop.onClick (fun _ -> setShowChild (not showChild))
                ]

                Html.button [
                    prop.testId TestIds.FireWindowEventButton
                    prop.text "Fire window event"
                    prop.onClick (fun _ -> dispatchCustomEvent "my-custom-event")
                ]

                Html.h1 [
                    prop.testId TestIds.ParentCounter
                    prop.text parentCounter
                ]

                if showChild then
                    Child.Render(setParentCounter)
            ]

describe "UseElmish subscription cleanup"
<| fun () ->
    testPromise "window-event side effects stop after child unmount"
    <| fun () -> promise {
        let render = RTL.render (CleanupHarness.Parent.Render())

        let getParentCounter () =
            render.getByTestId TestIds.ParentCounter

        expect(getParentCounter ()).toHaveTextContent "0"

        do! userEvent.click (render.getByTestId TestIds.FireWindowEventButton)

        do!
            RTL.waitFor (fun () ->
                expectMsg(getParentCounter (), "Parent counter after window event").toHaveTextContent "1"
            )

        do! userEvent.click (render.getByTestId TestIds.ToggleChildButton)

        do!
            RTL.waitFor (fun () ->
                expectMsg(render.queryByTestId TestIds.ChildCounter |> Option.isNone, "Child counter after toggle")
                    .toBeTruthy ()
            )

        do! userEvent.click (render.getByTestId TestIds.FireWindowEventButton)
        do! RTL.act (fun () -> delay 50)

        expectMsg(getParentCounter (), "Parent counter after window event after child unmount").toHaveTextContent "1"
    }

    testPromise "cleanup stays safe through React.strictMode mount cycles"
    <| fun () -> promise {
        let render = RTL.render (React.StrictMode [ CleanupHarness.Parent.Render() ])

        expect(render.getByTestId ("parent-counter")).toHaveTextContent "0"

        render.getByTestId("fire-window-event").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("parent-counter")).toHaveTextContent "1")

        render.getByTestId("toggle-child").click ()

        do! RTL.waitFor (fun () -> expect(render.queryByTestId "child-counter" |> Option.isNone).toBeTruthy ())

        render.getByTestId("fire-window-event").click ()
        do! RTL.act (fun () -> delay 50)

        expect(render.getByTestId ("parent-counter")).toHaveTextContent "1"

        render.getByTestId("toggle-child").click ()

        do! RTL.waitFor (fun () -> expect(render.queryByTestId "child-counter" |> Option.isSome).toBeTruthy ())

        render.getByTestId("fire-window-event").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("parent-counter")).toHaveTextContent "2")

        render.getByTestId("toggle-child").click ()

        do! RTL.waitFor (fun () -> expect(render.queryByTestId "child-counter" |> Option.isNone).toBeTruthy ())

        render.getByTestId("fire-window-event").click ()
        do! RTL.act (fun () -> delay 50)

        expect(render.getByTestId ("parent-counter")).toHaveTextContent "2"
    }
