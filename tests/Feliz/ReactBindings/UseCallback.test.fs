module Tests.ReactBindings.UseCallbackTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

type Components =
    [<ReactComponent>]
    static member ComponentUseCallback(onCreate: (unit -> unit) -> unit) =
        let count, setCount = React.useState 0

        let handleClick = React.useCallback(
            (fun () ->
                Browser.Dom.console.log("Clicked", count)
            ),
            [| box count |]
        )

        onCreate handleClick

        Html.button [
            prop.onClick (fun _ -> setCount(count + 1))
            prop.testId "increment"
            prop.text $"Count: {count}"
        ]

describe "useCallback" <| fun _ ->

    test "should keep the same callback reference if dependencies don't change" <| fun _ ->
        let capturedFns = ResizeArray<unit -> unit>()

        let render =
            RTL.render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        render.rerender (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        expect(capturedFns.[0]).toBe capturedFns.[1]

    testPromise "should update callback reference if dependency changes" <| fun _ -> promise {

        let capturedFns = ResizeArray<unit -> unit>()

        let _ = render (Components.ComponentUseCallback(fun fn -> capturedFns.Add(fn)))

        let incEle = screen.getByTestId "increment"

        do! userEvent.click (incEle)

        expect(capturedFns[0]).not.toBe (capturedFns[1])

    }
