module Example.UseSyncExternalStore

open System
open Feliz
open Browser

let getSnapshot() = 
    window.innerWidth

let subscribe callback =
    let handler = fun (_: Browser.Types.Event) -> callback()
    window.addEventListener("resize", handler)
    { new IDisposable with
        member _.Dispose() =
            window.removeEventListener("resize", handler)
    }   

[<ReactComponent(true)>]
let CurrentWidth() =

    let currentWidth = React.useSyncExternalStore(subscribe, getSnapshot)

    Html.h1 $"Window width: {currentWidth}px"
    