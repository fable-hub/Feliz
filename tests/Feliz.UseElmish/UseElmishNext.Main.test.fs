module UseElmishNextMainTests

open Fable.Core
open Feliz
open Vitest
open UseElmish

module UseElmishNextHarness =
    open Elmish
    open Feliz.UseElmishNext

    type Msg =
        | Increment
        | IncrementAgain

    let init () = 0, Cmd.none

    let update msg state =
        match msg with
        | Increment -> state + 1, Cmd.none
        | IncrementAgain -> state + 1, Cmd.ofMsg Increment

    [<ReactComponent>]
    let Render (subtitle: string) =
        let state, dispatch =
            React.useElmishNext (init, update, dependencies = [| box subtitle |])

        Html.div [
            Html.h1 [ prop.testId "count"; prop.text state ]

            Html.h2 [ prop.text subtitle ]

            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> dispatch Increment)
                prop.testId "increment"
            ]

            Html.button [
                prop.text "Increment again"
                prop.onClick (fun _ -> dispatch IncrementAgain)
                prop.testId "increment-again"
            ]
        ]

    [<ReactComponent>]
    let Wrapper () =
        let count, setCount = React.useState 0

        Html.div [
            Html.button [
                prop.text "Increment wrapper"
                prop.onClick (fun _ -> count + 1 |> setCount)
                prop.testId "increment-wrapper"
            ]

            Render(if count < 2 then "foo" else "bar")
        ]

describe "UseElmishNext"
<| fun () ->
    testPromise "useElmishNext works"
    <| fun () -> promise {
        let render = RTL.render (UseElmishNextHarness.Render "foo")

        expect(render.getByTestId ("count")).toHaveTextContent "0"

        do! userEvent.click (render.getByTestId ("increment"))

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("count")).toHaveTextContent "1")
    }

    testPromise "useElmishNext works with commands"
    <| fun () -> promise {
        let render = RTL.render (UseElmishNextHarness.Render "foo")

        expect(render.getByTestId ("count")).toHaveTextContent "0"

        render.getByTestId("increment-again").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("count")).toHaveTextContent "2")
    }

    testPromise "useElmishNext works with dependencies"
    <| fun () -> promise {
        let render = RTL.render (UseElmishNextHarness.Wrapper())

        expect(render.getByTestId ("count")).toHaveTextContent "0"

        render.getByTestId("increment").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("count")).toHaveTextContent "1")

        render.getByTestId("increment-wrapper").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("count")).toHaveTextContent "1")

        render.getByTestId("increment-wrapper").click ()

        do! RTL.waitFor (fun () -> expect(render.getByTestId ("count")).toHaveTextContent "0")
    }
