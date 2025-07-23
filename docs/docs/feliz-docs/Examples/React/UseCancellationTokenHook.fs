module Example.UseCancellationTokenHook

open Feliz
open Fable.Core

[<Erase; Mangle(false)>]
type Main =

    [<ReactComponent>]
    static member private UseToken (failedCallback: unit -> unit) =
        let token = React.useCancellationToken ()

        React.useEffect (fun () ->
            async {
                do! Async.Sleep 4000
                failedCallback ()
            }
            |> fun a -> Async.StartImmediate(a, token.current))

        Html.none

    [<ReactComponent(true)>]
    static member Main () =
        let renderChild, setRenderChild = React.useState true
        let resultText, setResultText = React.useState "Pending..."

        let setFailed =
            React.useCallback (fun () -> setResultText "You didn't cancel me in time!")

        let isDisabled = resultText = "Disposed"

        Html.div [
            if renderChild then
                Main.UseToken(setFailed)
            Html.div resultText
            Html.button [
                prop.disabled isDisabled
                prop.text "Dispose"
                prop.onClick (fun _ ->
                    async {
                        setResultText "Disposed"
                        setRenderChild false
                    }
                    |> Async.StartImmediate)
            ]

            Html.button [
                prop.disabled (renderChild && resultText = "Pending...")
                prop.text "Reset"
                prop.onClick (fun _ ->
                    async {
                        setResultText "Pending..."
                        setRenderChild true
                    }
                    |> Async.StartImmediate)
            ]
        ]
