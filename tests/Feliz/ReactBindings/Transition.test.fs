module Tests.ReactBindings.TransitionTests

open Fable.Core
open Feliz
open Vitest
open Vitest.PromiseTest

type Components =
    [<ReactComponent>]
    static member TransitionCounter() =
        let count, setCount = React.useState 0
        let isPending, startTransition = React.useTransition ()

        Html.div [
            Html.p [ prop.testId "count"; prop.text count ]
            Html.p [ prop.testId "pending"; prop.text (string isPending) ]
            Html.button [
                prop.testId "increment"
                prop.onClick (fun _ -> startTransition (fun () -> setCount (count + 1)))
                prop.text "Increment"
            ]
        ]

    [<ReactComponent>]
    static member AsyncTransition(work: JS.Promise<unit>) =
        let status, setStatus = React.useState "idle"
        let isPending, startTransition = React.useAsyncTransition ()

        Html.div [
            Html.p [ prop.testId "pending"; prop.text (string isPending) ]
            Html.p [ prop.testId "status"; prop.text status ]
            Html.button [
                prop.testId "start"
                prop.onClick (fun _ ->
                    startTransition (fun () -> promise {
                        do! work
                        React.startTransition (fun () -> setStatus "done")
                    })
                )
                prop.text "Start"
            ]
        ]

    [<ReactComponent>]
    static member StaticStartTransition() =
        let text, setText = React.useState "before"

        Html.div [
            Html.p [ prop.testId "text"; prop.text text ]
            Html.button [
                prop.testId "update"
                prop.onClick (fun _ ->
                    React.startTransition (fun () ->
                        React.addTransitionType "next"
                        setText "after"
                    )
                )
                prop.text "Update"
            ]
        ]

    [<ReactComponent>]
    static member StaticAsyncStartTransition(work: JS.Promise<unit>) =
        let text, setText = React.useState "before"

        Html.div [
            Html.p [ prop.testId "text"; prop.text text ]
            Html.button [
                prop.testId "update"
                prop.onClick (fun _ ->
                    React.startTransition (fun () -> promise {
                        do! work
                        React.startTransition (fun () -> setText "after")
                    })
                )
                prop.text "Update"
            ]
        ]

    [<ReactComponent>]
    static member DeferredValue(value: string) =
        let deferred = React.useDeferredValue value
        Html.p [ prop.testId "deferred"; prop.text deferred ]

    [<ReactComponent>]
    static member DeferredValueWithInitial(value: string) =
        let deferred = React.useDeferredValue (value, "initial")
        Html.p [ prop.testId "deferred"; prop.text deferred ]

describe "useTransition"
<| fun _ ->
    testPromise "applies the state update and is not pending afterwards"
    <| fun _ -> promise {
        RTL.render (Components.TransitionCounter()) |> ignore

        expect(RTL.screen.getByTestId "pending").toHaveTextContent "false"

        do! userEvent.click (RTL.screen.getByTestId "increment")

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "count").toHaveTextContent "1")
        expect(RTL.screen.getByTestId "pending").toHaveTextContent "false"
    }

describe "useAsyncTransition"
<| fun _ ->
    testPromise "is pending until the promise settles"
    <| fun _ -> promise {
        let work = deferred<unit>()
        RTL.render (Components.AsyncTransition(work.promise)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "start")

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "pending").toHaveTextContent "true")
        expect(RTL.screen.getByTestId "status").toHaveTextContent "idle"

        work.resolve ()

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "pending").toHaveTextContent "false")
        expect(RTL.screen.getByTestId "status").toHaveTextContent "done"
    }

describe "startTransition"
<| fun _ ->
    testPromise "applies a sync transition and accepts transition types"
    <| fun _ -> promise {
        RTL.render (Components.StaticStartTransition()) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "update")

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "text").toHaveTextContent "after")
    }

    testPromise "runs an async transition"
    <| fun _ -> promise {
        let work = deferred<unit>()
        RTL.render (Components.StaticAsyncStartTransition(work.promise)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "update")
        expect(RTL.screen.getByTestId "text").toHaveTextContent "before"

        work.resolve ()

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "text").toHaveTextContent "after")
    }

describe "useDeferredValue"
<| fun _ ->
    testPromise "eventually renders the latest value"
    <| fun _ -> promise {
        let result = RTL.render (Components.DeferredValue("a"))
        expect(RTL.screen.getByTestId "deferred").toHaveTextContent "a"

        result.rerender (Components.DeferredValue("b"))

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "deferred").toHaveTextContent "b")
    }

    testPromise "switches from the initial value to the value"
    <| fun _ -> promise {
        RTL.render (Components.DeferredValueWithInitial("value")) |> ignore

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "deferred").toHaveTextContent "value")
    }
