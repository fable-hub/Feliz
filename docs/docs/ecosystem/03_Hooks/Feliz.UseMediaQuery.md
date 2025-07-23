---
title: Feliz.UseMediaQuery
---

# Feliz.UseMediaQuery [![Nuget](https://img.shields.io/nuget/v/Feliz.UseMediaQuery.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.UseMediaQuery)

Build React components with responsive behavior for different devices.

## UseMediaQuery

UseMediaQuery allows you to pass in all kinds of media queries as string.

```fsharp
[<ReactComponent>]
let UseMediaQueryExample() =
    let matches = React.useMediaQuery("(max-width: 850px)")
    Html.div [
        let text =
            if matches then
                "850px or less"
            else
                "More than 850px"

        prop.children [
            Html.h1 text
            Html.p "Resize your screen to get the media query hook to re-render the component with updated information."
        ]
    ]
```
## UseResponsive

UseResponsive allows you to pass in a record type with the
breakpoints in px. Use the default ones or define them yourself.

```fsharp
[<ReactComponent>]
let UseResponsiveExample() =
    // defaults = {MobileLandscape = 576; Tablet = 768; Desktop = 1024; WideScreen = 1216}
    let width = React.useResponsive()
    Html.div [
        let text =
            match width with
            | ScreenSize.Mobile -> "Mobile"
            | ScreenSize.MobileLandscape -> "MobileLandscape"
            | ScreenSize.Tablet -> "Tablet"
            | ScreenSize.Desktop -> "Desktop"
            | ScreenSize.WideScreen -> "WideScreen"
        prop.children [
            Html.h1 text
            Html.p "Resize your screen to get the media query hook to re-render the component with updated information."
        ]
    ]
```

To define custom breakpoints, just pass in a breakpoints record with your preferred widths.

```fsharp
[<ReactComponent>]
let UseResponsiveCustomBreakpointsExample() =
    let customBreakpoints = {
        MobileLandscape = 600
        Tablet = 960
        Desktop = 1280
        WideScreen = 1920
    }

    let width = React.useResponsive(customBreakpoints)

    Html.div [
        let text =
            match width with
            | ScreenSize.Mobile -> "Mobile"
            | ScreenSize.MobileLandscape -> "MobileLandscape"
            | ScreenSize.Tablet -> "Tablet"
            | ScreenSize.Desktop -> "Desktop"
            | ScreenSize.WideScreen -> "WideScreen"
        prop.children [
            Html.h1 text
            Html.p "Resize your screen to get the media query hook to re-render the component with updated information."
        ]
    ]
```
