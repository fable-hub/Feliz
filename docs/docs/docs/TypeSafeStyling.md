--- 
title: Type-Safe Styling
sidebar_position: 5
---

# Type-Safe Styling

Feliz aims to provide a fully type-safe API around CSS and React styling such that the only possible values you can use are those that are valid but also these values will be very easy to find under the `style` module:

```fsharp
let exampleDiv =
    Html.div [
        prop.style [
            style.display.flex
            style.display.none
            style.fontSize 20
            style.borderRadius 15
            style.textAlign.center
            style.alignContent.flexStart
            style.textDecorationColor.blue
            style.visibility.hidden
            style.textDecoration.lineThrough
            style.position.sticky
            style.borderBottomWidth 20
            style.borderBottomWidth (length.em 10)
            style.borderBottomColor color.red
            style.borderBottomStyle borderStyle.dashed
            style.borderStyle.dotted
            style.margin(length.em 1, length.em 0)
            style.marginBottom 10
            style.marginBottom (length.em 1)
            style.boxShadow(10, 10, color.black)
            style.boxShadow(10, 10, 10, color.black)
            style.boxShadow(0, 0, 10, color.black)
            style.boxShadow(0, 0, 10, 10, color.darkGray)
            style.boxShadow.none
            style.height length.auto
            style.borderRadius 20
            style.borderRadius (length.rem 10)
            style.margin 10
            style.backgroundRepeat.repeatX
            style.backgroundPosition.fixedNoScroll
            style.margin (length.px 10)
            style.margin(10, 10, 10, 20)
            style.margin(10, 10, 10)
            style.margin(10, 10)
            style.width 10
            style.height 100
            style.height (length.vh 50)
            style.height (length.percent 100)
            style.backgroundColor.fuchsia
            style.backgroundColor "#FFFFFF"
            style.border(3, borderStyle.dashed, color.crimson)
            style.borderColor.blue
            style.transform.scale3D(20, 20, 20)
            style.transform.translateX(100)
            style.transform.translateY(100)
            style.transform.translateZ(100)
            style.textTransform.capitalize
            style.textTransform.lowercase
            style.fontStretch.extraCondensed
            style.fontVariant.smallCaps
            style.fontStyle.italic
            style.fontSize 20
            style.fontSize (length.em 2)
            style.color.crimson
            style.color "#000000"
        ]
    ]
```

# Conditional Styling

Now with F# 4.7 it is even easier without this overload as you omit the `yield` keyword:

```fsharp
Html.div [
    prop.style [
        style.margin 10
        style.borderRadius 15
        if state.Errored
        then style.color.red
        else style.color.green
    ]
]
```
