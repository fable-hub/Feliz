# Feliz.Recharts - TinyAreaChart

Taken from [Recharts - TinyAreaChart](http://recharts.org/en-US/examples/TinyAreaChart)

```fsharp
module App

open Feliz
open Feliz.Recharts

type Point = { name: string; uv: int; pv: int; amt: int }

let data = [
    { name = "Page A"; uv = 4000; pv = 2400; amt = 2400 }
    { name = "Page B"; uv = 3000; pv = 1398; amt = 2210 }
    { name = "Page C"; uv = 2000; pv = 9800; amt = 2290 }
    { name = "Page D"; uv = 2780; pv = 3908; amt = 2000 }
    { name = "Page E"; uv = 1890; pv = 4800; amt = 2181 }
    { name = "Page F"; uv = 2390; pv = 3800; amt = 2500 }
    { name = "Page G"; uv = 3490; pv = 4300; amt = 2100 }
]

[<ReactComponent>]
let Chart() =
    Recharts.areaChart [
        areaChart.width 200
        areaChart.height 60
        areaChart.data data
        areaChart.margin(top=5, bottom=5)
        areaChart.children [
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
