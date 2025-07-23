---
title: Feliz.Kawaii
---

# Feliz.Kawaii [![Nuget](https://img.shields.io/nuget/v/Feliz.Kawaii.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.Kawaii)

Feliz binding for [react-kawaii](https://github.com/miukimiu/react-kawaii) which contains lovely SVG components

> This binding only works with Fable 3+

### Installation

Using [Femto](https://github.com/Zaid-Ajaj/Femto)
```
femto install Feliz.Kawaii
```

### Using the library

```fsharp
open Feliz
open Feliz.Kawaii

Html.div [
    Kawaii.Mug()
    Kawaii.Mug(size=200)
    Kawaii.Mug(size=200, mood=Mood.Happy)
    Kawaii.Mug(size=200, mood=Mood.Happy, color=color.lightBlue)
]
```
All the components under `Kawaii` such as `Mug`, `Planet`, `Ghost` etc. take these three optional parameters
