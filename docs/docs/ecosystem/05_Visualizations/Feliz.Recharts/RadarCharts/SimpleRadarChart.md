# Feliz.Recharts - SimpleBarChart

Taken from [Recharts - SimpleBarChart](https://recharts.org/en-US/examples/SimpleRadarChart)

```fsharp
module App

open Feliz
open Feliz.Recharts

type Point = { subject: string; a: int; b: int; fullMark: int }

let data = [
    { subject = "Math"; a = 120; b = 110; fullMark = 150 }
    { subject = "Chinese"; a = 98; b = 130; fullMark = 150 }
    { subject = "English"; a = 86; b = 130; fullMark = 150 }
    { subject = "Geography"; a = 99; b = 100; fullMark = 150 }
    { subject = "Physics"; a = 85; b = 90; fullMark = 150 }
    { subject = "History"; a = 65; b = 85; fullMark = 150 }
]

[<ReactComponent>]
let Chart() =
    Recharts.radarChart [
        radarChart.data data
        radarChart.width 400
        radarChart.height 300
        radarChart.children [
            Recharts.polarGrid []
            Recharts.polarAngleAxis [
                polarAngleAxis.dataKey (fun point -> point.subject)
            ]
            Recharts.polarRadiusAxis []
            Recharts.radar [
                radar.dataKey (fun point -> point.a)
                radar.stroke "#8884d8"
                radar.fill "#8884d8"
                radar.fillOpacity 0.6
            ]
        ]
    ]


open Browser.Dom

ReactDOM.render(Chart(), document.getElementById "root")
```
