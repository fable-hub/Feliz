module UseElmishDependencyStableParentRerenderInitCmdTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Vitest
open UseElmish

[<Emit("new Promise(function(resolve) { setTimeout(resolve, $0); })")>]
let private delay (milliseconds: int) : JS.Promise<unit> = jsNative

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let ParentRerender = "parent-rerender"

    [<Literal>]
    let ParentTicks = "parent-ticks"

    [<Literal>]
    let InitRuns = "init-runs"

module StableDependencyInitCmdHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = { InitRuns: int }

    type Msg = | InitRan

    let init () = { InitRuns = 0 }, Cmd.ofMsg InitRan

    let update msg model =
        match msg with
        | InitRan ->
            {
                model with
                    InitRuns = model.InitRuns + 1
            },
            Cmd.none

    [<Erase>]
    type Child =
        [<ReactComponent>]
        static member Render(dependencyValue: string) =
            let model, _ =
                React.useElmish (init, update, dependencies = [| box dependencyValue |])

            Html.h1 [ prop.testId TestIds.InitRuns; prop.text model.InitRuns ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let ticks, setTicks = React.useStateWithUpdater 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ParentRerender
                    prop.text "rerender"
                    prop.onClick (fun _ -> setTicks (fun previous -> previous + 1))
                ]

                Html.h2 [ prop.testId TestIds.ParentTicks; prop.text ticks ]

                Child.Render("stable-dependency")
            ]

describe "UseElmish stable dependency parent rerender"
<| fun () ->
    testPromise "UseElmish_DependencyStable_ParentRerender_DoesNotReplayInitCmd"
    <| fun () -> promise {
        let render = RTL.render (StableDependencyInitCmdHarness.Parent.Render())

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.InitRuns).toHaveTextContent "1")

        do! userEvent.click (render.getByTestId TestIds.ParentRerender)
        do! userEvent.click (render.getByTestId TestIds.ParentRerender)
        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.ParentTicks).toHaveTextContent "2"
        expect(render.getByTestId TestIds.InitRuns).toHaveTextContent "1"
    }

