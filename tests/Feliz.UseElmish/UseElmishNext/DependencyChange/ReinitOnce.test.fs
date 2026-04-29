module UseElmishNextDependencyChangeReinitOnceTests

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
    let CurrentDependency = "current-dependency"

    [<Literal>]
    let InitRuns = "init-runs"

    [<Literal>]
    let ChangeDependency = "change-dependency"

module DependencyResetSingleInitHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Model = { Dependency: int; InitRuns: int }

    type Msg = | InitRan

    let init dependencyValue =
        {
            Dependency = dependencyValue
            InitRuns = 0
        },
        Cmd.ofMsg InitRan

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
        static member Render(dependencyValue: int) =
            let model, _ =
                React.useElmishNext (init, update, dependencyValue, dependencies = [| box dependencyValue |])

            Html.div [
                Html.h1 [
                    prop.testId TestIds.CurrentDependency
                    prop.text model.Dependency
                ]
                Html.h2 [ prop.testId TestIds.InitRuns; prop.text model.InitRuns ]
            ]

    [<Erase>]
    type Parent =
        [<ReactComponent>]
        static member Render() =
            let dependencyValue, setDependencyValue = React.useState 0

            Html.div [
                Html.button [
                    prop.testId TestIds.ChangeDependency
                    prop.text "change"
                    prop.onClick (fun _ -> setDependencyValue 1)
                ]

                Child.Render(dependencyValue)
            ]

describe "UseElmishNext dependency change reinit once"
<| fun () ->
    testPromise "UseElmishNext_DependencyChange_ReinitRunsOnce_NewInstanceOnly"
    <| fun () -> promise {
        let render = RTL.render (DependencyResetSingleInitHarness.Parent.Render())

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.CurrentDependency).toHaveTextContent "0"
                expect(render.getByTestId TestIds.InitRuns).toHaveTextContent "1"
            )

        do! userEvent.click (render.getByTestId TestIds.ChangeDependency)

        do!
            RTL.waitFor (fun () ->
                expect(render.getByTestId TestIds.CurrentDependency).toHaveTextContent "1"
                expect(render.getByTestId TestIds.InitRuns).toHaveTextContent "1"
            )

        do! RTL.act (fun () -> delay 40)

        expect(render.getByTestId TestIds.InitRuns).toHaveTextContent "1"
    }
