# What is this strange folder?

Feliz offers to use `[<ReactComponent(member, path)>]` for imports. The `Feliz.CompilerPlugins` package will in this case transform the **call site** of such an import to import and reference. 

<details>

<summary>Call Site vs Ref File</summary>

```fsharp
// File A = Ref File
module NativeCounter

open Feliz

[<ReactComponent("Counter", "./Counter")>]
let NativeCounter() = React.Imported()
```

```fsharp
// File B = Call Site
module Test

open Feliz

[<ReactComponent>]
let Test() = 
  Html.div [
    NativeCounter.NativeCounter()
  ]
```

</details>

If Call Site and Ref File are not on the same level of relative imports, the relative path in the Ref File will be incorrect. Therefore we resolve this on fable compile time via plugin. This folder structure is built to test this scenario.


