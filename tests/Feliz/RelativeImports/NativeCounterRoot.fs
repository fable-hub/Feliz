module NativeCounterRoot

open Feliz

[<ReactComponent("Counter", "./Counter")>]
let Equal() = React.Imported()

[<ReactComponent("Counter", "./NF1/NF2/NF3/Counter")>]
let Below3() = React.Imported()

[<ReactComponent("Counter", "./NF1/NF2/Counter")>]
let Below2() = React.Imported()

[<ReactComponent("Counter", "./NF1/Counter")>]
let Below1() = React.Imported()
