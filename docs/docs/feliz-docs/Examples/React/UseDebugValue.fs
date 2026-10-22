module Example.UseDebugValue

open Feliz

// Custom hook that uses useDebugValue
[<Hook>]
let useOnlineStatus () =
    let isOnline, setIsOnline = React.useState (true)
    React.useDebugValue (if isOnline then "Online" else "Offline")
    // Simulate status change for demo
    React.useEffect (
        (fun () ->
            let timer = Fable.Core.JS.setTimeout (fun _ -> setIsOnline (not isOnline)) 2000
            fun () -> Fable.Core.JS.clearTimeout timer
        ),
        [| box isOnline |]
    )

    isOnline

[<ReactComponent(true)>]
let UseDebugValue () =
    let isOnline = useOnlineStatus ()

    Html.div [
        Html.p [
            prop.text $"""Status: {(if isOnline then "Online" else "Offline")}"""
        ]
        Html.p [
            prop.text "Open React DevTools to see the debug value for this hook."
        ]
    ]
