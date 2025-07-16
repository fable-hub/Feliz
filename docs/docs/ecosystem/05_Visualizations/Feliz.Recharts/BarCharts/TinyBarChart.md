# Feliz.Recharts - TinyBarChart

Taken from [Recharts - TinyBarChart](http://recharts.org/en-US/examples/TinyBarChart)

```fsharp
module App

open Feliz
open Feliz.Recharts

type Point = { name: string; uv: int }

let data = [
    { name = "Page A"; uv = 4000; }
    { name = "Page B"; uv = 3000; }
    { name = "Page C"; uv = 2000; }
    { name = "Page D"; uv = 2780; }
    { name = "Page E"; uv = 1890; }
    { name = "Page F"; uv = 2390; }
    { name = "Page G"; uv = 3490; }
]


let chart = React.functionComponent(fun () ->
    Recharts.barChart [
        barChart.width 150
        barChart.height 40
        barChart.data data
        barChart.children [
            Recharts.bar [
                bar.dataKey (fun point -> point.uv)
                bar.fill "#8884d8"
            ]
        ]
    ])

open Browser.Dom

ReactDOM.render(chart, document.getElementById "root")
```
