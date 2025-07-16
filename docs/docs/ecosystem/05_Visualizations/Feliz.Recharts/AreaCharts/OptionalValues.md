# Feliz.Recharts - Area Chart with Optional Values

Taken from [Recharts - AreaChartConnectNulls](https://recharts.org/en-US/examples/AreaChartConnectNulls)

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
let Chart() =
    React.fragment [
        Recharts.areaChart [
            areaChart.width 600
            areaChart.height 200
            areaChart.data data
            areaChart.margin(top=10)
            areaChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.area [
                    area.monotone
                    area.connectNulls false
                    area.dataKey (fun point -> point.uv)
                    area.stroke "#8884d8"
                    area.fill "#8884d8"
                ]
            ]
        ]
        Recharts.areaChart [
            areaChart.width 600
            areaChart.height 200
            areaChart.data data
            areaChart.margin(top=20)
            areaChart.children [
                Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
                Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
                Recharts.yAxis [ ]
                Recharts.tooltip [ ]
                Recharts.area [
                    area.monotone
                    area.connectNulls true
                    area.dataKey (fun point -> point.uv)
                    area.stroke "#8884d8"
                    area.fill "#8884d8"
                ]
            ]
        ]
    ]


open Browser.Dom

ReactDOM.render(Chart(), document.getElementById "root")
```
