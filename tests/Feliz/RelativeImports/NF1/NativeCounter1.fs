module NativeCounter1

open Feliz

[<ReactComponent("Counter", "../Counter")>]
let Above1() = React.Imported()

[<ReactComponent("Counter", "./Counter")>]
let Equal() = React.Imported()

[<ReactComponent("Counter", "./NF2/Counter")>]
let Below1() = React.Imported()

[<ReactComponent("Counter", "./NF2/NF3/Counter")>]
let Below2() = React.Imported()
