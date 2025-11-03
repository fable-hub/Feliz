---
title: Feliz.PigeonMaps
---

# Feliz.PigeonMaps [![Nuget](https://img.shields.io/nuget/v/Feliz.PigeonMaps.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.PigeonMaps)

Feliz-style bindings for [pigeon-maps](https://github.com/mariusandra/pigeon-maps), React maps without external dependencies. This binding includes it's own custom `PigeonMaps.marker` component to build map markers manually.

```fsharp
open Feliz
open Feliz.PigeonMaps

let pigeonMap = PigeonMaps.map [
    map.center(50.879, 4.6997)
    map.zoom 12
    map.height 350
    map.markers [
        PigeonMaps.marker [
            marker.anchor(50.879, 4.6997)
            marker.offsetLeft 15
            marker.offsetTop 30
            marker.render (fun marker -> [
                Html.i [
                    if marker.hovered
                    then prop.style [ style.color.red; style.cursor.pointer ]
                    prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                ]
            ])
        ]
    ]
]
```

### Using event handlers: Map and Markers

In the following example, you can click on the visible markers to change the `center` of the map. The `zoom` state is also kept track of with every re-render cycle.

```fsharp
open Feliz
open Feliz.PigeonMaps

type City = {
    Name: string
    Latitude: float
    Longitude: float
}

let cities = [
    { Name = "Utrecht"; Latitude = 52.090736; Longitude = 5.121420 }
    { Name = "Nijmegen"; Latitude = 51.812565; Longitude = 5.837226 }
    { Name = "Amsterdam"; Latitude = 52.370216; Longitude = 4.895168 }
    { Name = "Rotterdam"; Latitude = 51.924419; Longitude = 4.477733 }
]

let renderMarker (city: City) clicked =
    PigeonMaps.marker [
        marker.anchor(city.Latitude, city.Longitude)
        marker.offsetLeft 15
        marker.offsetTop 30
        marker.render (fun marker -> Html.i [
            if marker.hovered
            then prop.style [ style.color.red; style.cursor.pointer ]
            prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
            prop.onClick (fun _ -> clicked (city.Latitude, city.Longitude))
        ])
    ]

let initialCenter =
    cities
    |> List.tryHead
    |> Option.map (fun city -> city.Latitude, city.Longitude)
    |> Option.defaultValue (51.812565, 5.837226)

let citiesMap = React.functionComponent(fun () ->
    let (center, setCenter) = React.useState initialCenter
    let (zoom, setZoom) = React.useState 8
    PigeonMaps.map [
        map.center center
        map.zoom zoom
        map.height 350
        map.onBoundsChanged (fun args -> setZoom (int args.zoom); setCenter (args.center))
        map.markers [ for city in cities -> renderMarker city setCenter ]
    ])
```

### Marker with overlay content on hover

Hover over the markers to show the overlay with the name of the city.

```fsharp
open Feliz
open Feliz.Popover

type City = {
    Name: string
    Latitude: float
    Longitude: float
}

let cities = [
    { Name = "Utrecht"; Latitude = 52.090736; Longitude = 5.121420 }
    { Name = "Nijmegen"; Latitude = 51.812565; Longitude = 5.837226 }
    { Name = "Amsterdam"; Latitude = 52.370216; Longitude = 4.895168 }
    { Name = "Rotterdam"; Latitude = 51.924419; Longitude = 4.477733 }
]

type MarkerProps = {
    City: City
    Hovered: bool
}

let markerWithPopover (marker: MarkerProps)  =
    Popover.popover [
        popover.body [
            Html.div [
                prop.text marker.City.Name
                prop.style [
                    style.backgroundColor.black
                    style.padding 10
                    style.borderRadius 5
                    style.color.lightGreen
                ]
            ]
        ]
        popover.isOpen marker.Hovered
        popover.enterExitTransitionDurationMs 0
        popover.disableTip
        popover.children [
            Html.i [
                prop.key marker.City.Name
                prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                if marker.Hovered then prop.style [
                    style.cursor.pointer
                    style.color.red
                ]
            ]
        ]
    ]

let renderMarker city =
    PigeonMaps.marker [
        marker.anchor(city.Latitude, city.Longitude)
        marker.offsetLeft 15
        marker.offsetTop 30
        marker.render (fun marker -> [
            markerWithPopover {
                City = city
                Hovered = marker.hovered
            }
        ])
    ]

let initialCenter =
    cities
    |> List.tryHead
    |> Option.map (fun city -> city.Latitude, city.Longitude)
    |> Option.defaultValue (51.812565, 5.837226)

let citiesMap = React.functionComponent(fun () ->
    let (zoom, setZoom) = React.useState 8
    let (center, setCenter) = React.useState initialCenter
    PigeonMaps.map [
        map.center center
        map.zoom zoom
        map.height 350
        map.onBoundsChanged (fun args -> setZoom (int args.zoom); setCenter args.center)
        map.markers [ for city in cities -> renderMarker city ]
    ])
```

### Marker with overlay content on click

Click on the markers to show the overlay with the name of the city.
```fsharp
open Feliz
open Feliz.PigeonMaps
open Feliz.Popover

type City = {
    Name: string
    Latitude: float
    Longitude: float
}

let cities = [
    { Name = "Utrecht"; Latitude = 52.090736; Longitude = 5.121420 }
    { Name = "Nijmegen"; Latitude = 51.812565; Longitude = 5.837226 }
    { Name = "Amsterdam"; Latitude = 52.370216; Longitude = 4.895168 }
    { Name = "Rotterdam"; Latitude = 51.924419; Longitude = 4.477733 }
]

type MarkerProps = {
    City: City
    Hovered: bool
}

let markerWithPopover = React.functionComponent(fun (marker: MarkerProps) ->
    let (popoverOpen, toggleOpen) = React.useState false
    Popover.popover [
        popover.body [
            Html.div [
                prop.text marker.City.Name
                prop.style [
                    style.backgroundColor.black
                    style.padding 10
                    style.borderRadius 5
                    style.color.lightGreen
                ]
            ]
        ]
        popover.isOpen popoverOpen
        popover.enterExitTransitionDurationMs 0
        popover.disableTip
        popover.onOuterAction (fun _ -> toggleOpen(false))
        popover.children [
            Html.i [
                prop.key marker.City.Name
                prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                prop.onClick (fun _ -> toggleOpen(not popoverOpen))
                prop.style [
                    if marker.Hovered then style.cursor.pointer
                    if popoverOpen then style.color.red
                ]
            ]
        ]
    ])

let renderMarker city =
    PigeonMaps.marker [
        marker.anchor(city.Latitude, city.Longitude)
        marker.offsetLeft 15
        marker.offsetTop 30
        marker.render (fun marker -> [
            markerWithPopover {
                City = city
                Hovered = marker.hovered
            }
        ])
    ]

let initialCenter =
    cities
    |> List.tryHead
    |> Option.map (fun city -> city.Latitude, city.Longitude)
    |> Option.defaultValue (51.812565, 5.837226)

let citiesMap = React.functionComponent(fun () ->
    let (zoom, setZoom) = React.useState 8
    let (center, setCenter) = React.useState initialCenter
    PigeonMaps.map [
        map.center center
        map.zoom zoom
        map.height 350
        map.onBoundsChanged (fun args -> setZoom (int args.zoom); setCenter args.center)
        map.markers [ for city in cities -> renderMarker city ]
    ])
```

### Markers with Close buttons

You can choose when to close the popover of the marker by adding event handlers to elements inside of it that close it instead of the popover being arbitrarily closed when the user clicks somewhere outside of the popover or marker:

```fsharp
open Feliz
open Feliz.Popover

type City = {
    Name: string
    Latitude: float
    Longitude: float
}

let cities = [
    { Name = "Utrecht"; Latitude = 52.090736; Longitude = 5.121420 }
    { Name = "Nijmegen"; Latitude = 51.812565; Longitude = 5.837226 }
    { Name = "Amsterdam"; Latitude = 52.370216; Longitude = 4.895168 }
    { Name = "Rotterdam"; Latitude = 51.924419; Longitude = 4.477733 }
]

type MarkerProps = {
    City: City
    Hovered: bool
}

let markerWithPopover = React.functionComponent(fun (marker: MarkerProps) ->
    let (popoverOpen, toggleOpen) = React.useState false
    Popover.popover [
        popover.body [
            Html.div [
                prop.style [
                    style.backgroundColor.black
                    style.padding 10
                    style.borderRadius 5
                ]
                prop.children [
                    Html.span [
                        Html.i [
                            prop.className [ "fa"; "fa-times" ]
                            prop.style [ style.marginRight 10; style.cursor.pointer; style.color.red ]
                            prop.onClick (fun _ -> toggleOpen(false))
                        ]
                    ]
                    Html.span [
                        prop.style [ style.color.lightGreen ]
                        prop.text marker.City.Name
                    ]
                ]
            ]
        ]
        popover.isOpen popoverOpen
        popover.disableTip
        popover.children [
            Html.i [
                prop.key marker.City.Name
                prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                prop.onClick (fun _ -> toggleOpen(not popoverOpen))
                prop.style [
                    if marker.Hovered then style.cursor.pointer
                    if popoverOpen then style.color.red
                ]
            ]
        ]
    ])

let renderMarker city =
    PigeonMaps.marker [
        marker.anchor(city.Latitude, city.Longitude)
        marker.offsetLeft 15
        marker.offsetTop 30
        marker.render (fun marker -> [
            markerWithPopover {
                City = city
                Hovered = marker.hovered
            }
        ])
    ]

let initialCenter =
    cities
    |> List.tryHead
    |> Option.map (fun city -> city.Latitude, city.Longitude)
    |> Option.defaultValue (51.812565, 5.837226)

let citiesMap = React.functionComponent(fun () ->
    let (zoom, setZoom) = React.useState 8
    let (center, setCenter) = React.useState initialCenter
    PigeonMaps.map [
        map.center center
        map.zoom zoom
        map.height 350
        map.onBoundsChanged (fun args -> setZoom (int args.zoom); setCenter args.center)
        map.markers [ for city in cities -> renderMarker city ]
    ])
```

# Custom Tiles Provider

It is possible to use different tile providers for the map. Currently the default provider is open streets map but you could change it to show tiles from another provider. For that you can use the `map.provider` property to customize the provider.

```fsharp
open Feliz
open Feliz.PigeonMaps

let stamenTerrain x y z dpr =
    sprintf "https://stamen-tiles.a.ssl.fastly.net/terrain/%A/%A/%A.png" z x y

let pigeonMap = PigeonMaps.map [
    map.center(50.879, 4.6997)
    map.zoom 12
    map.height 350
    map.provider stamenTerrain
    map.markers [
        PigeonMaps.marker [
            marker.anchor(50.879, 4.6997)
            marker.offsetLeft 15
            marker.offsetTop 30
            marker.render (fun marker -> [
                Html.i [
                    if marker.hovered
                    then prop.style [ style.color.red; style.cursor.pointer ]
                    prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                ]
            ])
        ]
    ]
]
```

### Paid Custom Tiles Provider

A nice options seems to be [MapTiler](https://www.maptiler.com/cloud), Their maps look good and their free plan provides up to 100k tile loads per month. You will need to sign up for an account and pass your API key and map id to the following provider

You can enable load their tiles by making an account and optaining a _API key_, then after selecting a map and getting its _map identifier_, you can build configure the tiles provider as follows:

```fsharp
let mapTilerKey = "YOUR-KEY-HERE"
let mapTilerId = "SOME-MAP-ID"

let mapTilerProvider x y z dpr =
    sprintf "https://api.maptiler.com/maps/%s/256/%A/%A/%A.png?key=%s" mapTilerId z x y mapTilerKey

let pigeonMap = PigeonMaps.map [
    map.center(50.879, 4.6997)
    map.zoom 12
    map.height 350
    map.provider mapTilerProvider
    map.markers [
        PigeonMaps.marker [
            marker.anchor(50.879, 4.6997)
            marker.offsetLeft 15
            marker.offsetTop 30
            marker.render (fun marker -> [
                Html.i [
                    if marker.hovered
                    then prop.style [ style.color.red; style.cursor.pointer ]
                    prop.className [ "fa"; "fa-map-marker"; "fa-2x" ]
                ]
            ])
        ]
    ]
]
```
