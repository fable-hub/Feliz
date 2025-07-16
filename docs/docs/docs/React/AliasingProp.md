# Aliasing `prop`

Some people don't seem to like the abbreviation `prop` when writing code or don't agree that it is the *"right"* name for the Html properties/attributes. In that case, you can easily provide a global *alias* to use throughout your application. Start by adding the following file to your project and make sure it is referenced early on so that it can be used from other files:

```fsharp
[<AutoOpen>]
module FelizExtensions

open Feliz

type attr = prop
```

That's it! Now you can use `attr` instead of `prop` without doing anything else in the consuming file:

```fsharp
module App

open Feliz

[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        Html.h1 count
        Html.button [
            attr.text "Increment"
            attr.onClick (fun _ -> setCount(count + 1))
        ]
    ]
```
