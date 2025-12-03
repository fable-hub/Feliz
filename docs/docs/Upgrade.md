---
title: Upgrade from 2.x to 3.x
displayed_sidebar: docsSidebar
sidebar_position: 999
---

A lot fo F# wrapper magic was removed. React bindings now behave as close as possible to actual React functionality.

## Update Fable Version

Get the latest fable version (currently pre-release).

```bash
# cmd
dotnet tool update fable --prerelease
```

## Update .NET Framework

Recommended is the use of .NET 8.

```bash
# cmd
dotnet --version
```

## React.memo

React.memo is used to meoize the rendering of your components and prevent unnecessary rerenders. The recommended usecase is the attribute [<ReactMemoComponent>] but you can also use [React.memo](https://fable-hub.github.io/Feliz/next/api-docs/react/apis/memo) to define a component for memo. When doing so, the component of React.lazy' must be bind with let and be called with React.lazyRender to render it.

```fsharp
open Feliz
open Browser.Dom

[<ReactComponent>]
let RenderTextWithEffect (text: string) =
    React.useEffect (fun () -> console.log("Rerender!", text) )
    Html.div [ 
        prop.text text; 
        prop.testId "memo-attribute" 
    ]

let MemoFunction =
    React.memo<{|text: string|}> (fun props ->
        RenderTextWithEffect(props.text)
    )

[<ReactComponent(true)>]
let Main () =
    let isDark, setIsDark = React.useState(false)
    let text, setText = React.useState("Hello, world!")
    let fgColor = if isDark then color.white else color.black
    let bgColor = if isDark then color.black else color.white
    Html.div [
        prop.style [style.border(1, borderStyle.solid, fgColor); style.padding 20; style.color fgColor; style.backgroundColor bgColor]
        prop.children [
            Html.h3 "Check the output in the browser console"
            Html.button [
                prop.text "Toggle Dark Mode"
                prop.onClick (fun _ -> setIsDark(not isDark))
            ]
            Html.input [
                prop.value text
                prop.onChange setText
            ]
            React.memoRender(MemoFunction, {| text = text |})
        ]
    ]
```

## React.lazy'

React.lazy' is used to call components dynamically, also only when needed, in order to reduce the required performance. The recommended usecase is the attribute [<ReactLazyComponent>] but you can also define a lazy loaded comonent using [React.lazy'](https://fable-hub.github.io/Feliz/next/api-docs/react/apis/lazy). When doing so, the component of React.lazy' must be bind with let and be called with React.lazyRender to render it.

```fsharp
open Feliz
open Fable.Core

/// Lazy load with delay to simulate large component
/// 
/// Note: Prefer using `[<ReactLazyComponent>]` instead of this approach!
let LazyHello: LazyComponent<unit> =
    React.lazy'(fun () ->
        promise {
            do! Promise.sleep 2000
            return! JsInterop.importDynamic "./Counter"
        }
    )

[<ReactComponent(true)>]
let SuspenseDemo() =
    let load, setLoad = React.useState(false)
    Html.div [
        Html.h3 [ prop.text "Suspense Example" ]
        Html.p "Loading the component will take 2 seconds. Then the component will be cached and future reruns will be instant."
        if load then
            React.Suspense([ 
                    React.lazyRender(LazyHello, ()) 
                ],
                Html.div [ prop.text "Loading..." ]
            )
        else
            Html.button [
                prop.text (if load then "Hide Lazy Component" else "Load Lazy Component")
                prop.onClick (fun _ -> setLoad(not load))
            ]
    ]
```

## React.context

React.createContext enables the user to create a context for a component in react. That way, values are shared automatically between a component and all its children, without inserting them. In order to use [React.createContext](https://fable-hub.github.io/Feliz/next/api-docs/react/apis/createContext), you must define a reactcontext with a let binding. Then you can call that context in a provider, which inserts the values to be shared in the defined context.Provider and the child components.

```fsharp
open Feliz
open Browser.Dom

open Feliz

// Define a context for shared state
// This can should be placed in a separate file for reuse
let CounterContext = React.createContext(None: (int * (int -> unit)) option)

[<ReactComponent>]
let CounterProvider(children: ReactElement list) =
    let count, setCount = React.useState(0)
    CounterContext.Provider(Some(count, setCount), children)

[<ReactComponent>]
let CounterDisplay() =
    let ctx = React.useContext(CounterContext)
    match ctx with
    | Some(count, _) -> Html.p [ prop.text $"Current count: {count}" ]
    | None -> Html.p [ prop.text "No context available" ]

[<ReactComponent>]
let CounterControls() =
    let ctx = React.useContext(CounterContext)
    match ctx with
    | Some(count, setCount) ->
        Html.div [
            Html.button [
                prop.text "+"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
            Html.button [
                prop.text "-"
                prop.onClick (fun _ -> setCount(count - 1))
            ]
        ]
    | None -> Html.p [ prop.text "No context available" ]

[<ReactComponent(true)>]
let UseContext() =
    CounterProvider [
        Html.h3 [ prop.text "Shared Counter" ]
        CounterDisplay()
        CounterControls()
    ]

```

## FsReact

All f# functions to help with react interop have been moved to FsReact namespace. 

```
FsReact.createDisposable
FsReact.useDisposable
FsReact.useCancellationToken
```

## Components use PascalCase

According to react best practices, components are written in PascalCase instead of camelCase. This has been updated for React.

`React.Fragment, React.KeyedFragment, React.Imported, React.DynamicImported, React.StrictMode, React.Suspense, React.Provider, React.Consumer`
