module NativeCounter2

open Feliz

[<ReactComponent("Counter", "../Counter")>]
let Above1() = React.Imported()

[<ReactComponent("Counter", "../../Counter")>]
let Above2() = React.Imported()

[<ReactComponent("Counter", "./Counter")>]
let Equal() = React.Imported()

[<ReactComponent("Counter", "./NF3/Counter")>]
let Below1() = React.Imported()
