# Feliz.Recharts - Line Chart with Optional Values

Taken from [Recharts - LineChartConnectNulls](https://recharts.org/en-US/examples/LineChartConnectNulls)

```fsharp
open Feliz
open Feliz.Recharts

type Point = { name: string; uv: int option }

let data = [
    { name = "Page A"; uv = Some 4000 }
    { name = "Page B"; uv = Some 3000 }
    { name = "Page C"; uv = Some 2000 }
    { name = "Page D"; uv = None }
    { name = "Page E"; uv = Some 1890 }
    { name = "Page F"; uv = Some 2390 }
    { name = "Page G"; uv = Some 3490 }
]

[<ReactComponent>]
let OptionalValuesChart() =
    React.fragment [
        Recharts.lineChart [
            lineChart.width 500
            lineChart.height 300
            lineChart.data data
            lineChart.margin(top=10)
            lineChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.line [
                    line.monotone
                    line.connectNulls false
                    line.dataKey (fun point -> point.uv)
                    line.stroke "#8884d8"
                    line.fill "#8884d8"
                ]
            ]
        ]
        Recharts.lineChart [
            lineChart.width 500
            lineChart.height 300
            lineChart.data data
            lineChart.margin(top=20)
            lineChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.line [
                    line.monotone
                    line.connectNulls true
                    line.dataKey (fun point -> point.uv)
                    line.stroke "#8884d8"
                    line.fill "#8884d8"
                ]
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(OptionalValuesChart(), document.getElementById "root")
```
