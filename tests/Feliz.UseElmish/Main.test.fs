module DelayTests

open Fable.Core
open Feliz
open Browser
open Feliz.Vitest
open Fable.ReactTestingLibrary
open Feliz.Vitest
open UseElmish

module UseElmish =
    open Elmish
    open Feliz.UseElmish

    type State =
        { Count: int }

        interface System.IDisposable with
            member _.Dispose () = ()

    type Msg =
        | Increment
        | IncrementAgain

    let init = 0, Cmd.none

    let update msg state =
        match msg with
        | Increment -> state + 1, Cmd.none
        | IncrementAgain -> state + 1, Cmd.ofMsg Increment

    let render = React.functionComponent(fun (props: {| subtitle: string |}) ->
        let state, dispatch = React.useElmish(init, update, [|box props.subtitle|])

        Html.div [
            Html.h1 [
                prop.testId "count"
                prop.text state
            ]

            Html.h2 props.subtitle

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

        ])

    let wrapper = React.functionComponent(fun () ->
        let count, setCount = React.useState 0
        Html.div [
            Html.button [
                prop.text "Increment wrapper"
                prop.onClick (fun _ -> count + 1 |> setCount)
                prop.testId "increment-wrapper"
            ]
            render {| subtitle = if count < 2 then "foo" else "bar" |}
        ])

describe "UseElmish" <| fun () ->
    testPromise "useElmish works" <| fun () -> promise {
        let render = RTL.render(UseElmish.render {| subtitle = "foo" |})

        Expect.toHaveTextContent (render.getByTestId("count")) "0" //"Should be initial state"

        do! RTL.userEvent.click(render.getByTestId("increment"))

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "1" // "Should have been incremented"
        }

    // See https://github.com/fable-compiler/fable-promise/issues/24#issuecomment-934328900
    testPromise "useElmish works with commands" <| fun () -> promise {
        let render = RTL.render(UseElmish.render {| subtitle = "foo" |})

        Expect.toHaveTextContent (render.getByTestId("count")) "0" // "Should be initial state"

        render.getByTestId("increment-again").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "2" //"Should have been incremented twice"

    }

    testPromise "useElmish works with dependencies" <| fun () -> promise {
        let render = RTL.render(UseElmish.wrapper())

        Expect.toHaveTextContent (render.getByTestId("count")) "0" //"Should be initial state"

        render.getByTestId("increment").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "1" //"Should have been incremented"


        render.getByTestId("increment-wrapper").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "1" //"State should be same because dependency hasn't changed"


        render.getByTestId("increment-wrapper").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "0" //"State should have been reset because dependency has changed"

    }

    testPromise "useElmish works with React.strictMode" <| fun () -> promise {
        let render = RTL.render(React.strictMode[ UseElmish.wrapper() ])

        Expect.toHaveTextContent (render.getByTestId("count")) "0" //"Should be initial state"

        render.getByTestId("increment").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "1" //"Should have been incremented"


        render.getByTestId("increment-wrapper").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "1" //"State should be same because dependency hasn't changed"


        render.getByTestId("increment-wrapper").click()

        do!
            RTL.waitFor <| fun () ->
                Expect.toHaveTextContent (render.getByTestId("count")) "0" //"State should have been reset because dependency has changed"

    }
