# Feliz.Recharts - Customized Label Pie Chart

Taken from [Recharts - PieChartWithCustomizedLabel](http://recharts.org/en-US/examples/PieChartWithCustomizedLabel)

```fsharp
open Feliz
open Feliz.Recharts

type PieSlice = { name: string; value: int }

let data = [
    { name = "Group A"; value = 400 }
    { name = "Group B"; value = 300 }
    { name = "Group C"; value = 300 }
    { name = "Group D"; value = 200 }
]

let bgColors = [|
    "#0088FE"
    "#00C49F"
    "#FFBB28"
    "#FF8042"
|]

let renderCustomLabel (input: IPieLabelProperties) =
    let radius = input.innerRadius + (input.outerRadius - input.innerRadius) * 0.5;
    let radian = System.Math.PI / 180.
    let x = (input.cx + radius * cos (-input.midAngle * radian))
    let y = (input.cy + radius * sin (-input.midAngle * radian))

    Svg.text [
        svg.fill color.white
        svg.x x
        svg.y y
        svg.dominantBaseline.central
        if x > input.cx then svg.textAnchor.startOfText else svg.textAnchor.endOfText
        svg.text (sprintf "%.0f%%" (100. * input.percent))
    ]

[<ReactComponent>]
let PieChart() =
    let cells =
        data
        |> List.mapi (fun index _ ->
            Recharts.cell [
                cell.fill bgColors.[ index % bgColors.Length ]
            ])

    Recharts.pieChart [
        pieChart.width 800
        pieChart.height 400
        pieChart.children [
            Recharts.pie [
                pie.data data
                pie.cx 300
                pie.cy 200
                pie.labelLine false
                pie.label renderCustomLabel
                pie.outerRadius 80
                pie.fill "#8884d8"
                pie.children cells
            ]
        ]
    ]

open Browser.Dom

ReactDOM.render(PieChart(), document.getElementById "root")
```
