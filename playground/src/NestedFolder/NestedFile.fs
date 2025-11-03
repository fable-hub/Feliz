module NativeCounter

open Feliz

[<ReactComponent(import = "Counter", from = "../Counter")>]
let NativeCounter() = React.Imported()
