---
title: Feliz.Delay
---

# Feliz.Delay [![Nuget](https://img.shields.io/nuget/v/Feliz.Delay.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.Delay)

An easy to use abstraction for delaying rendering components set periods of time.

### React.delay

Delays rendering the children of this component for a given period of time.

By default the fallback is `Html.none` and the `waitFor` value is 100 miliseconds.

Here you can see that after about a couple seconds the div is then rendered:

```fsharp
open Feliz
open Feliz.Delay

[<ReactComponent>]
let UseDelayExample() =
    React.delay [
        delay.waitFor 2000

        delay.children [
            Html.text "Here I am!"
        ]
    ]
```

You can also specify your own fallback such as a loader:

```fsharp
open Feliz
open Feliz.Delay

[<ReactComponent>]
let DelayWithFallback() =
    React.delay [
        delay.waitFor 2000

        delay.children [
            Html.text "Here I am!"
        ]

        delay.fallback centeredSpinner
    ]
```

In addition you can compose delayed components for customized handling based on time intervals:

```fsharp
open Feliz
open Feliz.Delay

[<ReactComponent>]
let DelayWithCustomFallback() =
    React.delay [
        delay.waitFor 2000

        delay.children [
            Html.text "Here I am!"
        ]

        delay.fallback centeredSpinner
    ]

[<ReactComponent>]
let AnotherDelayWithCustomFallback() =
    React.delay [
        delay.waitFor 2000

        delay.children [
            delayWithCustomFallback()
        ]

        delay.fallback [
            Html.text "Hanging out for a little bit..."
        ]
    ]
```

### React.delaySuspense

`React.suspense` that uses the `React.delay` component as the fallback.

This is useful when you code split components that on a fast connection will usually
render quickly, but want to display a loader if it exceeds what you consider to be fast.

Here you can see that the loader will not show until 500ms have passed:

```fsharp
open Feliz
open Feliz.Delay

[<ReactComponent>]
let DelaySuspense() =
    React.delaySuspense [
        delaySuspense.delay [
            delay.waitFor 500

            delay.children [
                centeredSpinner
            ]
        ]

        delaySuspense.children [
            slowImport()
        ]
    ]
```

### React.Templates.delay

Helper function that allows you to create a custom React.delay component via currying.

When you expect to use a `React.delay` component across your application, this provides a helper function
that can be accessed if you open the `Feliz.Delay.Templates` namespace.

Here's an example of how this works:

```fsharp
open Feliz
open Feliz.Delay
open Feliz.Delay.Templates

let myDelay =
    React.Templates.delay [
        delay.waitFor 2000
        delay.fallback [
            Html.text "Delay template!"
        ]
    ]

[<ReactComponent>]
let CustomDelay() = myDelay [
    Html.div "Here I am from the template!"
]
```

### React.Templates.delaySuspense

Helper function that allows you to create a custom React.delaySuspense component via currying.

When you expect to use a `React.delaySuspense` component across your application, this provides a helper function
that can be accessed if you open the `Feliz.Delay.Templates` namespace.

Here's an example of how this works:

```fsharp
open Feliz
open Feliz.Delay
open Feliz.Delay.Templates

let myDelaySuspense =
    React.Templates.delaySuspense [
        delay.waitFor 500

        delay.fallback [
            Html.text "Delay template!"
        ]

        delay.children [
            centeredSpinner
        ]
    ]

[<ReactComponent>]
let CustomDelay() = myDelaySuspense [
    slowImport()
]
```
