---
title: Feliz.Popover
---

# Feliz.Popover [![Nuget](https://img.shields.io/nuget/v/Feliz.Popover.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.Popover)

Feliz-style bindings for [react-popover](https://github.com/littlebits/react-popover).

### Installation

Install the dotnet package
```
dotnet add package Feliz.Popover
```
Install the npm package
```
npm install --save react-popover
```

### Installation with Femto

Use [Femto](https://github.com/Zaid-Ajaj/Femto), then it can install everything for you in one go
```
cd ./project
femto install Feliz.Popover
```

### Usage

The `Popover` component can easily used in a React stateful component that keeps track on whether the popover is opened or not but otherwise in Elmish application the same ideas hold.

```fsharp
open Feliz
open Feliz.Popover

let popoverWithText' = React.functionComponent(fun (input: {| content: string |}) ->
    let (popoverOpen, toggleOpen) = React.useState false
    Popover.popover [
        popover.body [
            // the body is the content of the pop over when it is opened
            Html.div [
                prop.text input.content
                prop.style [
                    style.backgroundColor.white
                    style.padding 20
                    style.borderRadius 10
                    style.boxShadow(0, 0, 10, color.black)
                ]
            ]
        ]
        popover.isOpen popoverOpen
        popover.place.above
        popover.disableTip
        popover.onOuterAction (fun _ -> toggleOpen(false))
        popover.children [
            /// The content that this popover will orient itself around.
            Html.button [
                prop.text "Open popover"
                prop.onClick (fun _ -> toggleOpen(not popoverOpen))
            ]
        ]
    ])

let sample = Html.div [
    popoverWithText' {| content = "Popover Content" |}
    popoverWithText' {| content = "Another Popover" |}
]
```
