module UseElmishDispatchStabilityTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("$0 === $1")>]
let private jsStrictEq (a: obj) (b: obj) : bool = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let DispatchChanged = "dispatch-changed"

    [<Literal>]
    let ParentRerender = "parent-rerender"

    [<Literal>]
    let ParentTicks = "parent-ticks"

module DispatchStabilityHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = unit
    type Msg = | Noop

    let init () = (), Cmd.none
    let update _msg _model = (), Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(dependencyValue: string) =
            // React.useRef lets us compare dispatch across renders without causing re-renders.
            let prevDispatchRef = React.useRef<(Msg -> unit) option> None
            let dispatchChangedRef = React.useRef false

            let _model, dispatch =
                React.useElmish (init, update, dependencies = [| box dependencyValue |])

            match prevDispatchRef.current with
            | None -> prevDispatchRef.current <- Some dispatch
            | Some prev ->
                if not (jsStrictEq (box prev) (box dispatch)) then
                    dispatchChangedRef.current <- true

            prevDispatchRef.current <- Some dispatch

            Html.div [
                prop.testId TestIds.DispatchChanged
                prop.text (string dispatchChangedRef.current)
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let ticks, setTicks = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ParentRerender
                    prop.text "rerender"
                    prop.onClick (fun _ -> setTicks (fun prev -> prev + 1))
                ]

                Html.h2 [ prop.testId TestIds.ParentTicks; prop.text ticks ]

                Child.Render("stable-dep")
            ]

describe "UseElmish dispatch stability"
<| fun () ->
    testPromise "UseElmish_DispatchRef_StableAcrossParentRerenders"
    <| fun () -> promise {
        let render = RTL.render (DispatchStabilityHarness.Parent.Render())

        do! userEvent.click (render.getByTestId TestIds.ParentRerender)
        do! userEvent.click (render.getByTestId TestIds.ParentRerender)
        do! userEvent.click (render.getByTestId TestIds.ParentRerender)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ParentTicks).toHaveTextContent "3")

        expect(render.getByTestId TestIds.DispatchChanged).toHaveTextContent "false"
    }
