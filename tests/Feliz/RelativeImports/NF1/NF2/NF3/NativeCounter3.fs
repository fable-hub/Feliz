module NativeCounter3

open Feliz

[<ReactComponent("Counter", "../Counter")>]
let Above1() = React.Imported()

[<ReactComponent("Counter", "../../Counter")>]
let Above2() = React.Imported()

[<ReactComponent("Counter", "../../../Counter")>]
let Above3() = React.Imported()

[<ReactComponent("Counter", "./Counter")>]
let Equal() = React.Imported()

