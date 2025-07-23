---
title: Type-Safe CSS
sidebar_position: 6
---

# Type-Safe CSS

When you are working with a CSS framework such as [Bootstrap](https://getbootstrap.com/), [Bulma](https://bulma.io/), [FontAwesome](https://fontawesome.com/) or others, you often have to learn and remember a large number CSS class names to be able to use them in your application, for example to make a primary-colored button using Bulma, you write:

```fsharp
Html.button [
    prop.className [ "button"; "is-primary" ]
    prop.text "Click"
]
```

It would be nice if there was a way to browse through and discover these class names directly from your IDE. Of course, you could write a reusable module with these class names built-in:

```fsharp
module Bulma =
    let [<Literal>] Button = "button"
    let [<Literal>] IsPrimary = "is-primary"
    // etc.
```

This requires _a lot_ of work and an unsustainable amount of maintenance because you have to write a module per CSS framework and update it whenever the module changes.

### Typed CSS Classes to the rescue!

Luckily for all of us, [@zanaptak](https://github.com/zanaptak) has built an amazing and really useful type provider specifically to solve this issue: enter [zanaptak/TypedCssClasses](https://github.com/zanaptak/TypedCssClasses), a type provider that generates types CSS class names directly from their sources and makes them available for use from within our application directly while writing the code. Here is an example of using CSS class names from FontAwesome:

```fsharp
open Feliz
open Zanaptak.TypedCssClasses

type Icon = CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>

let centeredSpinner =
    Html.div [
        prop.style [
            style.textAlign.center
            style.marginLeft length.auto
            style.marginRight length.auto
            style.marginTop 50
        ]
        prop.children [
            Html.li [
                prop.className [
                    Icon.Fa
                    Icon.FaRefresh
                    Icon.FaSpin
                    Icon.Fa3X
                ]
            ]
        ]
    ]
```

### Include the CSS yourself.

The `TypedCssClasses` type provider only brings the class names into your application in a type-safe manner, not the actual CSS library which means you have to include the CSS library yourself. You can do that either by a specifying the CSS link in your `index.html` or use the varius webpack loaders to import the libraries from npm packages.
