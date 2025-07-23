# Feliz.Recharts - Responsive Full Width

Charts are usually rendered with a fixed size given a `width` and `height` property but a lot of the times you want the chart to be responsive: resize according to the size of the parent which is what `Recharts.responsiveContainer` is for. Here follows an example of how to use a full width chart.

```fsharp
module App

open Feliz
open Feliz.Recharts

type Point = { name: string; uv: int; pv: int; }

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
let ResponsiveChart() =
    let responsiveChart =
        Recharts.lineChart [
            lineChart.data data
            lineChart.margin(top=5, right=30)
            lineChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.legend [ ]
                Recharts.line [
                    line.monotone
                    line.dataKey (fun point -> point.pv)
                    line.stroke "#8884d8"
                ]
                Recharts.line [
                    line.monotone
                    line.dataKey (fun point -> point.uv)
                    line.stroke "#82ca9d"
                ]
            ]
        ]

    Recharts.responsiveContainer [
        responsiveContainer.width (length.percent 100)
        responsiveContainer.height 300
        responsiveContainer.chart responsiveChart
    ]

open Browser.Dom

ReactDOM.render(ResponsiveChart(), document.getElementById "root")
```
