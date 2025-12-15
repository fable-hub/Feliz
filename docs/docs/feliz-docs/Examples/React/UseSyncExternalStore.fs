module Example.UseSyncExternalStore

open Feliz
open Browser

let getSnapshot() = 
    window.innerWidth

let getServerSnapshot() = 
    1024.0 // Default server width

let subscribe callback =
    let handler = fun (_: Browser.Types.Event) -> callback()
    window.addEventListener("resize", handler)
    fun () -> window.removeEventListener("resize", handler)

[<ReactComponent(true)>]
let UseSyncExternalStoreDisposable() =
    let currentWidth = React.useSyncExternalStore(subscribe, getSnapshot, getServerSnapshot)

    Html.h3 $"Window width: {currentWidth}px"
    