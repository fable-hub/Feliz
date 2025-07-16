# Feliz.Recharts - AreaChartFillByValue

Taken from [Recharts - AreaChartFillByValue](http://recharts.org/en-US/examples/AreaChartFillByValue)

```fsharp
module App

open Feliz
open Feliz.Recharts
open Fable.Core.Experimental

type Point = { name: string; uv: int; pv: int }

let data = [
    { name = "Page A"; uv = 4000; pv = 2400 }
    { name = "Page B"; uv = 3000; pv = 1398 }
    { name = "Page C"; uv = -1000; pv = 9800 }
    { name = "Page D"; uv = 500; pv = 3908 }
    { name = "Page E"; uv = -2000; pv = 4800 }
    { name = "Page F"; uv = -250; pv = 3800 }
    { name = "Page G"; uv = 3490; pv = 4300 }
]

let getOffset (data: Point list) =
    match data with
    | [ ] -> 0.0
    | points ->
        let dataMax = points |> List.maxBy (fun point -> point.uv)
        let dataMin = points |> List.minBy (fun point -> point.uv)

        if dataMax.uv <= 0
        then 0.0
        elif dataMin.uv >= 0
        then 1.0
        else float dataMax.uv / (float dataMax.uv - float dataMin.uv)

let getGradientDefinition (gradientId: string) (data: Point list) =
    let offset = getOffset data
    Html.defs [
        Html.linearGradient [
            prop.id gradientId
            prop.x1 0; prop.x2 0
            prop.y1 0; prop.y2 1
            prop.children [
                Html.stop [
                    prop.offset offset
                    prop.stopColor "green"
                    prop.stopOpacity 1.0
                ]

                Html.stop [
                    prop.offset offset
                    prop.stopColor "red"
                    prop.stopOpacity 1.0
                ]
            ]
        ]
    ]

[<ReactComponent>]
let Chart() =
    Recharts.areaChart [
        areaChart.height 400
        areaChart.width 500
        areaChart.data data
        areaChart.margin(top=10, right=30)
        areaChart.children [
            Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
            Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
            Recharts.yAxis [ ]
            Recharts.tooltip [ ]
            getGradientDefinition "splitColor" data
            Recharts.area [
                area.monotone
                area.dataKey (fun point -> point.uv)
                area.stroke color.black
                area.fill "url(#splitColor)"
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(Chart(), document.getElementById "root")
```
