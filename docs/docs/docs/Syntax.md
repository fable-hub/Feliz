---
title: Syntax
sidebar_position: 3
---

# Syntax

Elements can take simple values as their only input such a string, a number, a single child element or a list of child elements.

Learn how the standard HTML can be written in Feliz syntax using [Html2Feliz](https://thisfunctionaltom.github.io/Html2Feliz/)

```fsharp
Html.h1 42

Html.div "Hello there!"

Html.div [ Html.h1 "So lightweight" ]

Html.ul [
  Html.li "One"
  Html.li [ Html.strong "Two" ]
  Html.li [ Html.em "Three" ]
]
```

You could also expand the attribute:

```fsharp
Html.h1 [
    prop.className "title"
    prop.children [
        Html.text "Hello there"
    ]
]
```

Note that you can't mix attributes and child elements. If you use the component overload taking `IReactProperty list`, you must use `prop.children` to specify the child elements, as shown above.

However, in the specific case of a single `Html.text` child, you can also use the `prop.text` alias. The code above is the same as this:

```fsharp
Html.h1 [
    prop.className "title"
    prop.text "Hello there"
]
```

Single element child works too as input:

```fsharp
Html.h1 (Html.strong "I am bold")

// same as

Html.h1 [ Html.strong "I am bold" ]

// same as

Html.h1 [
    prop.children [ Html.strong "I am bold" ]
]
```

### Form Inputs

Input elements are dead simple to work with:

```fsharp
Html.input [
    prop.className "input"
    prop.value state.Crendentials.Password // string
    prop.onChange (SetPassword >> dispatch) // (string -> unit)
    prop.type'.password
]

Html.input [
    prop.className "input checkbox"
    prop.value state.RememberMe // boolean
    prop.onChange (SetRememberMe >> dispatch) // (bool -> unit)
    prop.type'.checkbox
]
```

Here the `onChange` property is overloaded with the following types

```fsharp
// generic onChange event
type onChange = Event -> unit
// onChange for textual input boxes
type onChange = string -> unit
// onChange for boolean input boxes, i.e. checkbox
type onChange = bool -> unit
// onChange for single file uploads
type onChange = File -> unit
// onChange for multiple file upload when prop.multiple true
type onChange = File list -> unit
// onChange for input elements where type=date or type=dateTimeLocal
type onChange = DateTime -> unit
```

### The empty element

To render the empty element, i.e. instructing React to render nothing, use `Html.none`

```fsharp
match state with
| None -> Html.none
| Some data -> render data
```

### Specifying class names

```fsharp
prop.className "button" // => "button"
prop.className [ "btn"; "btn-primary" ] // => "btn btn-primary"
```

The property `className` has overloads to combine a list of classes into a single class, convenient when your classes are bound to values so that you do not need to concatenate them yourself.

### Enhanced keyboard events

The events `prop.onKeyUp`, `prop.onKeyDown` and `onKeyPressed` are all of type `KeyboardEvent -> unit` which is correct. The input `KeyboardEvent` will contain information about the key that was pressed, its char code and whether it was pressed in combination with CTRL or SHIFT (or both). Alongside these default handlers, Feliz provides enhanced handlers that make it even _simpler_ to handle certain key presses. For example, if you have a login form and you want to dispacch `Login` message when the user hits `Enter` (very common scenario), you can do it like this:

```fsharp
Html.input [
    prop.onKeyUp (key.enter, fun _ -> dispatch Login)
    prop.onChange (UsernameChanged >> dispatch)
    prop.value state.Username
]
```

Notice the first properties `prop.onKeyUp (key.enter, fun _ -> dispatch Login)`. It takes two parameters: one is the key we are matching against and another which is of the same type as the default handlers, namely: `KeyboardEvent -> unit`. This enhanced API also allows you to easily match against combinations of keys such with `CTRL` and `SHIFT` as follows:

```fsharp
// Enter only
prop.onKeyUp (key.enter, fun _ -> dispatch Login)
// Enter + CTRL
prop.onKeyUp (key.ctrl(key.enter), fun _ -> dispatch Login)
// Enter + SHIFT
prop.onKeyUp (key.shift(key.enter), fun _ -> dispatch Login)
// Enter + CTRL + SHIFT
prop.onKeyUp (key.ctrlAndShift(key.enter), fun _ -> dispatch Login)
```
