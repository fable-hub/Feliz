# Feliz.Recharts - Customized Label Line Chart

Taken from [Recharts - CustomizedLabelLineChart](http://recharts.org/en-US/examples/CustomizedLabelLineChart)

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

let renderCustomLabel (input: ILabelProperties) =
    Svg.text [
        svg.x(input.x)
        svg.y(input.y)
        svg.textAnchor.middle
        svg.dy(-4)
        svg.fontSize 10
        svg.fill color.black
        svg.text input.value
    ]

[<ReactComponent>]
let CustomizedLabelChart() =
    Recharts.lineChart [
        lineChart.width 500
        lineChart.height 300
        lineChart.data data
        lineChart.margin(top=20, right=30, left=20, bottom=10)
        lineChart.children [
            Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
            Recharts.xAxis [ xAxis.dataKey (fun point -> point.name) ]
            Recharts.yAxis [ ]
            Recharts.tooltip [ ]
            Recharts.legend [ ]
            Recharts.line [
                line.monotone
                line.dataKey (fun point -> point.pv)
                line.label renderCustomLabel
                line.stroke "#8884d8"
            ]

            Recharts.line [
                line.monotone
                line.dataKey (fun point -> point.uv)
                line.stroke "#82ca9d"
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(CustomizedLabelChart(), document.getElementById "root")
```
