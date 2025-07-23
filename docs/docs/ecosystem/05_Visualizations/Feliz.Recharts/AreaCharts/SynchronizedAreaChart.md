# Feliz.Recharts - SynchronizedAreaChart.md

Taken from [Recharts - SynchronizedAreaChart](http://recharts.org/en-US/examples/SynchronizedAreaChart)

```fsharp
module App

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
    Html.div [
        Html.h4 "A demo of synchronized AreaCharts"
        Recharts.areaChart [
            areaChart.width 500
            areaChart.height 200
            areaChart.data data
            areaChart.syncId "anyId"
            areaChart.margin(top=10, right=30)
            areaChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.area [
                    area.monotone
                    area.dataKey (fun point -> point.uv)
                    area.stroke "#8884d8"
                    area.fill "#8884d8"
                ]
            ]
        ]

        Html.p "Maybe some other content"

        Recharts.areaChart [
            areaChart.width 500
            areaChart.height 200
            areaChart.data data
            areaChart.syncId "anyId"
            areaChart.margin(top=10, right=30)
            areaChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.area [
                    area.monotone
                    area.dataKey (fun point -> point.pv)
                    area.stroke "#82ca9d"
                    area.fill "#82ca9d"
                ]
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(Chart(), document.getElementById "root")
```
