# Feliz.Recharts - Straight Angle

Taken from [Recharts - StraightAnglePieChart](http://recharts.org/en-US/examples/StraightAnglePieChart).

```fsharp
module App

open Feliz
open Feliz.Recharts

type PieSlice = { name: string; value: int }

let data = [
    { name = "Group A"; value = 400 }
    { name = "Group B"; value = 300 }
    { name = "Group C"; value = 300 }
    { name = "Group D"; value = 200 }
    { name = "Group E"; value = 278 }
    { name = "Group F"; value = 189 }
]

[<ReactComponent>]
let PieChart() =
    Recharts.pieChart [
        pieChart.width 400
        pieChart.height 400
        pieChart.children [
            Recharts.pie [
                pie.data data
                pie.dataKey (fun point -> point.value)
                pie.startAngle 180
                pie.endAngle 0
                pie.cx 200
                pie.cy 200
                pie.outerRadius 80
                pie.fill "#8884d8"
                pie.label true
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(PieChart(), document.getElementById "root")
```
