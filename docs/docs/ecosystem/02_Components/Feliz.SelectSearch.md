---
title: Feliz.SelectSearch
---

# Feliz.SelectSearch [![Nuget](https://img.shields.io/nuget/v/Feliz.SelectSearch.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.SelectSearch)

A binding for [react-select-search](https://github.com/tbleckert/react-select-search) that implements a searchable and customizable dropdown for Feliz applications.

### Installation

Using [Femto](https://github.com/Zaid-Ajaj/Femto)

```
femto install Feliz.SelectSearch
```

This library assumes you have a working CSS loader enabled because it imports the CSS assets internally.

### Basic drop down example

```fsharp
open Feliz
open Feliz.SelectSearch

[<ReactComponent>]
let BasicDropdown() =
    let (selectedValue, setSelectedValue) = React.useState<string option>(None)
    Html.div [
        prop.style [ style.width 400 ]
        prop.children [
            SelectSearch.selectSearch [
                selectSearch.placeholder "Select a language"
                selectSearch.onChange (fun value -> setSelectedValue(Some value))
                selectSearch.options [
                    { value = "en-GB"; name = "English"; disabled = false }
                    { value = "fr-FR"; name = "French"; disabled = false }
                    { value = "nl-NL"; name = "Dutch"; disabled = false }
                ]
            ]

            match selectedValue with
            | None -> Html.h3 "No value selected"
            | Some value -> Html.h3 (sprintf "Selected value '%s'" value)
        ]
    ]
```

### Searchable drop down

Use `selectSearch.search true` to enable searching.

```fsharp
SelectSearch.selectSearch [
    selectSearch.placeholder "Select a language"
    selectSearch.search true
    selectSearch.onChange (fun value -> setSelectedValue(Some value))
    selectSearch.options [
        { value = "en-GB"; name = "English"; disabled = false }
        { value = "fr-FR"; name = "French"; disabled = false }
        { value = "nl-NL"; name = "Dutch"; disabled = false }
    ]
]
```

### Make some of the items disabled

Disabled items cannot be selected

```fsharp
SelectSearch.selectSearch [
    selectSearch.placeholder "Select a language"
    selectSearch.search true
    selectSearch.onChange (fun value -> setSelectedValue(Some value))
    selectSearch.options [
        { value = "en-GB"; name = "English"; disabled = true }
        { value = "fr-FR"; name = "French"; disabled = false }
        { value = "nl-NL"; name = "Dutch"; disabled = false }
    ]
]
```

### Customized search predicate in dropdown:

By default, the built-in search functionality will filter the items of which the `name` (the display value of the option) contains the input search query in case-insensitive fashion.

You can provide your own filtering function for example to also exclude disabled items from the search and only return the items of which the `name` _starts with_ the search query as follows.

Use the `selectSearch.filterOptions` attribute to control the search predicate as follows:

```fsharp
SelectSearch.selectSearch [
    selectSearch.placeholder "Select a language"
    selectSearch.search true
    selectSearch.onChange (fun value -> setSelectedValue(Some value))
    selectSearch.filterOptions (fun item searchQuery -> not item.disabled && item.name.StartsWith searchQuery)
    selectSearch.options [
        { value = "en-GB"; name = "English"; disabled = true }
        { value = "fr-FR"; name = "French"; disabled = false }
        { value = "nl-NL"; name = "Dutch"; disabled = false }
    ]
]
```

### Selecting multiple values

Using `searchSelect.multiple true` in combination with `selectSearch.printOptions.onFocus`. See other `printOptions` if you for example want to make the menu stay visible after selecting an option:

This example uses the component in controlled form

```fsharp
let (selectedValues, setSelectedValues) = React.useState<string list> [ ]

SelectSearch.selectSearch [
    selectSearch.value selectedValues
    selectSearch.placeholder "Select a language"
    selectSearch.multiple true
    selectSearch.printOptions.onFocus
    selectSearch.onChange (fun (values: string list) -> setSelectedValues values)
    selectSearch.options [
        { value = "en-GB"; name = "English"; disabled = false }
        { value = "fr-FR"; name = "French"; disabled = false }
        { value = "nl-NL"; name = "Dutch"; disabled = false }
    ]
]
```

### Grouped options

```fsharp
SelectSearch.selectSearch [
    selectSearch.placeholder "Choose food category"
    selectSearch.search true
    selectSearch.options [
        SelectOption.Group {
            name = "Asian"
            items = [
                { value = "sushi"; name = "Sushi"; disabled = false }
                { value = "ramen"; name = "Ramen"; disabled = false }
            ]
        }
        SelectOption.Group {
            name = "Italian"
            items = [
                { value = "pasta"; name = "Pasta"; disabled = false }
                { value = "pizza"; name = "Pizza"; disabled = false }
            ]
        }
    ]
]
```

### Customized buttons in dropdown

You can use `selectSearch.renderOption` to customize how each option is rendered. The example below extends the dropdown and adds images to it. Feel free to play with stying to make it work for your app.

You don't _have_ to use the provided `className` from the properties. Instead, you can make your own and use it in the button.

```fsharp
SelectSearch.selectSearch [
    selectSearch.placeholder "Choose food category"
    selectSearch.search true
    selectSearch.options [
        SelectOption.Group {
            name = "Asian"
            items = [
                { value = "sushi"; name = "Sushi"; disabled = false }
                { value = "ramen"; name = "Ramen"; disabled = false }
            ]
        }
        SelectOption.Group {
            name = "Italian"
            items = [
                { value = "pasta"; name = "Pasta"; disabled = false }
                { value = "pizza"; name = "Pizza"; disabled = false }
            ]
        }
    ]
    selectSearch.renderOption (fun properties ->
        Html.button [
            yield! properties.attributes
            prop.className properties.className
            prop.children [
                Html.img [
                    prop.height 32
                    prop.width 38
                    prop.style [ style.marginRight 10 style.borderRadius 16 ]
                    prop.src (imageUrlByValue properties.option.value)
                ]
                Html.span properties.option.name
            ]
        ]
    )
]
```
