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

Recommended is the use of .NET 8. You can check your local .NET version with `dotnet --version` and update your .fsproj files with

```xml
<TargetFramework>net8.0</TargetFramework>
```

## React.memo

`React.memo` behavior was reworked to improve compatibility with React devtools. It now **requires** to be called with `React.memoRenderer`. Check out the [docs](./api-docs/react/apis/memo) for more info and alternatives!

```fsharp
let MemoFunction =
    React.memo<{|text: string|}> (fun props ->
        // some component
    )

[<ReactComponent>]
let Main () =
    Html.div [
        React.memoRender(MemoFunction, {| text = text |})
    ]
```

## React.lazy'

`React.lazy'` behavior was reworked. It now **requires** to be called with `React.lazyRenderer`. Check out the [docs](./api-docs/react/apis/lazy) for more info and alternatives!

```fsharp
let LazyHello: LazyComponent<unit> =
    React.lazy'(fun () ->
        promise {
            do! Promise.sleep 2000
            return! JsInterop.importDynamic "./Counter"
        }
    )

[<ReactComponent>]
let SuspenseDemo() =
    Html.div [
        React.Suspense([ 
                React.lazyRender(LazyHello, ()) 
            ],
            Html.div [ prop.text "Loading..." ]
        )
    ]
```

## React.context

Using context with React was reworked to more closely align with React functionality.

```fsharp
// Define a context for shared state
// This can should be placed in a separate file for reuse
let CounterContext = React.createContext(None: (int * (int -> unit)) option)

[<ReactComponent>]
let CounterDisplay() =
    let ctx = React.useContext(CounterContext)
    match ctx with
    | Some(count, _) -> Html.p [ prop.text $"Current count: {count}" ]
    | None -> Html.p [ prop.text "No context available" ]

[<ReactComponent(true)>]
let UseContext() =
    let count, setCount = React.useState(0)
    CounterContext.Provider(
        (Some (count, setCount)),
        CounterDisplay()
    )

```

## FsReact

All F# functions to help with React interop have been moved to FsReact namespace. 

* `FsReact.createDisposable`
* `FsReact.useDisposable`
* `FsReact.useCancellationToken`

## Components use PascalCase

According to React best practices, components are written in PascalCase instead of camelCase. This has been updated for React.

* `React.Fragment`
* `React.KeyedFragment`
* `React.Imported`
* `React.DynamicImported`
* `React.StrictMode`
* `React.Suspense`
* `React.Provider`
* `React.Consumer`
