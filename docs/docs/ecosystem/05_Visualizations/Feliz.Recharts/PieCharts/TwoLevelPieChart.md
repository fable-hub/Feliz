# Feliz.Recharts - TwoLevelPieChart

Taken from [Recharts - TwoLevelPieChart](http://recharts.org/en-US/examples/TwoLevelPieChart)

```fsharp
open Feliz
open Feliz.Recharts

type PieSlice = { name: string; value: int }

let firstSerie = [
    { name = "Group A"; value = 400 }
    { name = "Group B"; value = 300 }
    { name = "Group C"; value = 300 }
    { name = "Group D"; value = 200 }
]

let secondSerie = [
    { name = "A1"; value = 100 }
    { name = "A2"; value = 300 }
    { name = "B1"; value = 100 }
    { name = "B2"; value = 80 }
    { name = "B3"; value = 40 }
    { name = "B4"; value = 30 }
    { name = "B5"; value = 50 }
    { name = "C1"; value = 100 }
    { name = "C2"; value = 200 }
    { name = "D1"; value = 150 }
    { name = "D2"; value = 50 }
]

[<ReactComponent>]
let PieChart() =
    Recharts.pieChart [
        pieChart.height 400
        pieChart.width 400
        pieChart.children [
            Recharts.pie [
                pie.data firstSerie
                pie.dataKey (fun point -> point.value)
                pie.cx 200
                pie.cy 200
                pie.outerRadius 60
                pie.fill "#8884d8"
            ]
            Recharts.pie [
                pie.data secondSerie
                pie.dataKey (fun point -> point.value)
                pie.cx 200
                pie.cy 200
                pie.innerRadius 70
                pie.outerRadius 90
                pie.fill "#82ca9d"
                pie.label true
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(PieChart(), document.getElementById "root")
```
