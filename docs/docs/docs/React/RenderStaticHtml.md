---
sidebar_position: 11
---

# Render Static Html

Using Feliz, you can render static HTML as a string from a `ReactElement` using the `ReactDOMServer` API.


### `ReactDOMServer.renderToString()`

```fsharp
[<ReactComponent>]
let StaticHtml() =
    let html = Html.div [
        prop.style [ style.padding 20 ]
        prop.children [
            Html.h1 "Html content"
            Html.br [ ]
        ]
    ]

    Html.pre [
        Html.text (ReactDOMServer.renderToString html)
    ]
```

### `ReactDOMServer.renderToStaticMarkup()`

```fsharp
[<ReactComponent>]
let StaticMarkup() =
    let html = Html.div [
        prop.style [ style.padding 20 ]
        prop.children [
            Html.h1 "Html content"
            Html.br [ ]
        ]
    ]

    Html.pre [
        Html.text (ReactDOMServer.renderToStaticMarkup html)
    ]
```
