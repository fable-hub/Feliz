module UseElmishProgramOnErrorBehaviorTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

[<RequireQualifiedAccess>]
module TestIds =
    [<Literal>]
    let TriggerError = "trigger-error"

    [<Literal>]
    let ProgramErrorCount = "program-error-count"

module ProgramOnErrorBehaviorHarness =
    open Elmish
    open Feliz.UseElmish

    type Model = unit

    type Msg = | TriggerError

    let init () = (), Cmd.none

    let update msg model =
        match msg with
        | TriggerError -> model, Cmd.ofEffect (fun _ -> failwith "boom")

    [<Erase>]
    type Root =
        [<ReactComponent>]
        static member Render() =
            let programErrorCount, setProgramErrorCount = React.useStateWithUpdater 0

            let programFactory () =
                Program.mkProgram init update (fun _ _ -> ())
                |> Program.withErrorHandler (fun _ -> setProgramErrorCount (fun previous -> previous + 1))

            // Program overload intentionally relies on Program.withErrorHandler for error routing.
            let _, dispatch = React.useElmish (programFactory, ())

            Html.div [
                Html.button [
                    prop.testId TestIds.TriggerError
                    prop.text "trigger"
                    prop.onClick (fun _ -> dispatch TriggerError)
                ]

                Html.h1 [
                    prop.testId TestIds.ProgramErrorCount
                    prop.text programErrorCount
                ]
            ]

describe "UseElmish program overload onError behavior"
<| fun () ->
    testPromise "UseElmish_ProgramOverload_UsesProgramErrorHandler"
    <| fun () -> promise {
        let render = RTL.render (ProgramOnErrorBehaviorHarness.Root.Render())

        do! userEvent.click (render.getByTestId TestIds.TriggerError)

        do! RTL.waitFor (fun () -> expect(render.getByTestId TestIds.ProgramErrorCount).toHaveTextContent "1")
    }
