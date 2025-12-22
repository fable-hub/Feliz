# Feliz [![Nuget](https://img.shields.io/nuget/v/Feliz.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz)

A fresh retake of the React API in Fable, optimized for happiness.

Here is how it looks like:

```fsharp
module App

open Feliz

[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        Html.button [
            prop.style [ style.marginRight 5 ]
            prop.onClick (fun _ -> setCount(count + 1))
            prop.text "Increment"
        ]

        Html.button [
            prop.style [ style.marginLeft 5 ]
            prop.onClick (fun _ -> setCount(count - 1))
            prop.text "Decrement"
        ]

        Html.h1 count
    ]

open Browser.Dom

let root = ReactDOM.createRoot (document.getElementById "root")
root.render (Counter())
```

### ✨ Features

 - Flexible **API design**: Combine the reliability of F# type safety with the flexibility to interop easily with native JavaScript.
 - Discoverable **attributes** with no more functions, `Html` attributes or CSS properties globally available so they are easy to find.
 - Proper **documentation**: each attribute and CSS property
 - Full **React API** support: Feliz aims to support the React API for building components using hooks, context and more.
 - Fully **Type-safe**: no more `Margin of obj` but instead utilizing a plethora of overloaded functions to account for the overloaded nature of `CSS` attributes, covering 90%+ of the CSS styles, values and properties.
 - **Compatible** with [Femto](https://github.com/Zaid-Ajaj/Femto).
 - Approximately **Zero** bundle size increase where everything function body is erased from the generated JavaScript unless you actually use said function.

### 🚀 Quick Start

```bash
# install the template (if you haven't already)
dotnet new -i Feliz.Template
# create a new Feliz project from the installed template
dotnet new feliz -n MyProject
# navigate to the created project folder
cd MyProject
# install the npm dependencies
npm install
# install .NET tools
dotnet tool restore
# start the development server
npm start
```

### 📚 Documentation

Explore the full docs at [https://fable-hub.github.io/Feliz/](https://fable-hub.github.io/Feliz/) — packed with live examples and practical guidance. Highlights:

- Feliz syntax: comprehensive reference for `Html`, `prop`, `style`, React hooks, and more. Browse: https://fable-hub.github.io/Feliz/category/feliz
- Guides: curated walkthroughs and best practices — from getting started to advanced patterns. Start here: https://fable-hub.github.io/Feliz/category/guides
- Ecosystem: discover community libraries and official add‑ons (UI, components, hooks, testing, tooling). Explore: https://fable-hub.github.io/Feliz/ecosystem
  - Feliz.UseElmish: integrate Elmish state machines with React components. Learn more: https://fable-hub.github.io/Feliz/ecosystem/Hooks/Feliz.UseElmish
  - Vitest: testing library for Feliz components. Learn more: https://fable-hub.github.io/Feliz/ecosystem/Testing/Feliz.Vitest

If anything’s unclear or you’re missing an example, please open an issue or discussion — contributions are very welcome!

### ⌚ Changelog

Each project in Feliz has its own changelog file in the `src` folder. Check them out for the latest changes!

Here is a direct link to the [Feliz changelog](src/Feliz/CHANGELOG.md).
