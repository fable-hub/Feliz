module Tests.FsReactTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

module TokenCancellation =

    /// <summary>
    /// A component that uses a cancellation token to cancel an async operation when unmounted.
    /// </summary>
    [<ReactComponent>]
    let private CancelAsyncWithUnmountElement (callback: unit -> unit) =
        let token = FsReact.useCancellationToken()

        React.useEffectOnce(fun () ->
            async {
                do! Async.Sleep 500
                callback()
            }
            |> fun a -> Async.StartImmediate(a,token.current)
        )

        Html.none

    [<ReactComponent>]
    let Main (unmount: bool) =
        let renderChild,setRenderChild = React.useState true
        let resultText,setResultText = React.useState "Initial"

        let setTextCallback = React.useCallback <| fun () -> setResultText "Async Completed"

        React.useLayoutEffectOnce(fun () ->
            async {
                do! Async.Sleep 100

                if unmount then
                    setResultText "Disposed"
                    setRenderChild false
            }
            |> Async.StartImmediate
        )

        Html.div [
            if renderChild then
                CancelAsyncWithUnmountElement(setTextCallback)
            Html.div [
                prop.testId "result-text"
                prop.text resultText
            ]
        ]

describe "TokenCancellation" <| fun _ ->
    testPromise "Do not cancel, let async complete" <| fun _ -> promise {
        let render = RTL.render (TokenCancellation.Main(false))
        let resultText = RTL.screen.getByTestId "result-text"

        expect(resultText).toHaveTextContent "Initial"
        do! RTL.waitFor((fun () ->
            expect(resultText).toHaveTextContent "Async Completed"
        ), RTLWaitForOptions(timeout=2000))
    }

    testPromise "Cancel, stop async complete" <| fun _ -> promise {
        let render = RTL.render (TokenCancellation.Main(true))
        let resultText = RTL.screen.getByTestId "result-text"

        expect(resultText).toHaveTextContent "Initial"
        do! RTL.waitFor((fun () ->
            let resultText = RTL.screen.getByTestId "result-text"
            expect(resultText).toHaveTextContent "Disposed"
        ), RTLWaitForOptions(timeout=2000))

        do! RTL.act(fun () ->
            Promise.sleep 1000
        )

        do! RTL.waitFor((fun () ->
            let resultText = RTL.screen.getByTestId "result-text"
            expect(resultText).not.toHaveTextContent "Async Completed"
        ), RTLWaitForOptions(timeout=2000))
    }
