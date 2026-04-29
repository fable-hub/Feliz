module UseElmishNextSubscriptionDependencySwapTests

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

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let CurrentDependency = "current-dependency"

    [<Literal>]
    let SwapDependency = "swap-dependency"

    [<Literal>]
    let FireEvent = "fire-event"

    [<Literal>]
    let EventCount = "event-count"

    [<Literal>]
    let LastSource = "last-source"

module SubscriptionDependencySwapHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = { Dependency: int }

    type Msg = ExternalEvent of int

    let init dependencyValue =
        { Dependency = dependencyValue }, Cmd.none

    let update (onEvent: int -> unit) msg model =
        match msg with
        | ExternalEvent source ->
            onEvent source
            model, Cmd.none

    let subscribe dependencyValue (_model: Model) : Sub<Msg> = [
        [ "dependency-event"; string dependencyValue ],
        (fun dispatch ->
            let handler = fun (_: obj) -> dispatch (ExternalEvent dependencyValue)
            addEventListener "dependency-swap-event" handler

            { new System.IDisposable with
                member _.Dispose() =
                    removeEventListener "dependency-swap-event" handler
            }
        )
    ]

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(dependencyValue: int, onEvent: int -> unit) =
            let _, _ =
                React.useElmishNext (
                    init,
                    update onEvent,
                    subscribe dependencyValue,
                    dependencyValue,
                    dependencies = [| box dependencyValue |]
                )

            Html.none

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let dependencyValue, setDependencyValue = React.useState 0
            let eventCount, setEventCount = React.useStateWithUpdater 0
            let lastSource, setLastSource = React.useState "none"

            let onEvent source =
                setEventCount (fun previous -> previous + 1)
                setLastSource (string source)

            Html.div [
                Html.button [
                    prop.testId TestIds.SwapDependency
                    prop.text "swap"
                    prop.onClick (fun _ -> setDependencyValue 1)
                ]

                Html.button [
                    prop.testId TestIds.FireEvent
                    prop.text "fire"
                    prop.onClick (fun _ -> dispatchCustomEvent "dependency-swap-event")
                ]

                Html.h1 [
                    prop.testId TestIds.CurrentDependency
                    prop.text dependencyValue
                ]
                Html.h2 [ prop.testId TestIds.EventCount; prop.text eventCount ]
                Html.h3 [ prop.testId TestIds.LastSource; prop.text lastSource ]

                Child.Render(dependencyValue, onEvent)
            ]

describe "UseElmishNext subscription dependency swap"
<| fun () ->
    testPromise "UseElmishNext_Subscription_DependencyResubscribe_ReplacesListener"
    <| fun () -> promise {
        let render = RTL.render (SubscriptionDependencySwapHarness.Parent.Render())

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.EventCount).toHaveTextContent "1"
                expect(render.getByTestId TestIds.LastSource).toHaveTextContent "0"
            )

        do! userEvent.click (render.getByTestId TestIds.SwapDependency)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.CurrentDependency).toHaveTextContent "1")

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.EventCount).toHaveTextContent "2"
                expect(render.getByTestId TestIds.LastSource).toHaveTextContent "1"
            )

        do! userEvent.click (render.getByTestId TestIds.FireEvent)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.EventCount).toHaveTextContent "3"
                expect(render.getByTestId TestIds.LastSource).toHaveTextContent "1"
            )
    }
