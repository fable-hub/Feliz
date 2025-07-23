# Feliz.Recharts - SimpleAreaChart

Taken from [Recharts - SimpleAreaChart](http://recharts.org/en-US/examples/SimpleAreaChart)

```fsharp
module Main

open Feliz
open Feliz.Recharts

type Point = { name: string; uv: int; pv: int }

let data = [
    { name = "Page A"; uv = 4000; pv = 2400 }
    { name = "Page B"; uv = 3000; pv = 1398 }
    { name = "Page C"; uv = 2000; pv = 9800 }
    { name = "Page D"; uv = 2780; pv = 3908 }
    { name = "Page E"; uv = 1890; pv = 4800 }
    { name = "Page F"; uv = 2390; pv = 3800 }
    { name = "Page G"; uv = 3490; pv = 4300 }
]

[<ReactComponent>]
let Chart() =
    Recharts.areaChart [
        areaChart.width 500
        areaChart.height 400
        areaChart.data data
        areaChart.margin(top=10, right=30)
        areaChart.children [
            Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
            Recharts.yAxis [ ]
            Recharts.tooltip [ ]
            Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
            Recharts.area [
                area.monotone
                area.dataKey (fun point -> point.uv)
                area.stroke "#8884d8"
                area.fill "#8884d8"
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(Chart(), document.getElementById "root")
```
