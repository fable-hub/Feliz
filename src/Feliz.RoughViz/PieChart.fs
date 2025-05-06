namespace Feliz.RoughViz

open Fable.Core
open Fable.Core.JsInterop

type IPieChartProperty = interface end

type pieChart =
    static member data(points: (string * float) seq) =
        let labels = [| for (label, value) in points -> label |]
        let values = [| for (label, value) in points -> value |]
        let result = toPlainJsObj {| labels = labels; values = values; |}
        unbox<IPieChartProperty> ("data", result)

    /// Array of colors for each arc. Default: ['coral', 'skyblue', '#66c2a5', 'tan', '#8da0cb', '#e78ac3', '#a6d854', '#ffd92f', 'tan', 'orange'].
    static member inline colors(colorNames: string[]) = unbox<IPieChartProperty> ("colors", colorNames)
    static member inline height(value: int) = unbox<IPieChartProperty> ("height", value)
    static member inline height(value: float) = unbox<IPieChartProperty> ("height", value)
    /// Chart bowing. Default = 0
    static member inline bowing(value: float) = unbox<IPieChartProperty> ("bowing", value)
    /// Weight of inner paths' color. Default: 0.5
    static member inline fillWeight(value: float) = unbox<IPieChartProperty> ("fillWeight", value)
    /// Font family to use
    static member inline font(fontFamily: string) = unbox<IPieChartProperty> ("font", fontFamily)
    /// Color for each bar on hover
    static member inline highlight(colorName: string) = unbox<IPieChartProperty> ("highlight", colorName)
    static member inline strokeWidth(width: int) = unbox<IPieChartProperty> ("strokeWidth", width)
    static member inline title(chartTitle: string) = unbox<IPieChartProperty> ("title", chartTitle)
    static member inline titleFontSize(fontSize:int) = unbox<IPieChartProperty> ("titleFontSize", unbox<string> fontSize + "px")
    static member inline titleFontSize(fontSize:float) = unbox<IPieChartProperty> ("titleFontSize", unbox<string> fontSize + "px")
    static member inline titleFontSize(fontSize: string) = unbox<IPieChartProperty> ("titleFontSize", fontSize)
    static member inline tooltipFontSize(fontSize:int) = unbox<IPieChartProperty> ("tooltipFontSize", unbox<string> fontSize + "px")
    static member inline tooltipFontSize(fontSize:float) = unbox<IPieChartProperty> ("tooltipFontSize", unbox<string> fontSize + "px")
    static member inline tooltipFontSize(fontSize: string) = unbox<IPieChartProperty> ("tooltipFontSize", fontSize)
    static member inline roughness(value: int) = unbox<IPieChartProperty> ("roughness", abs value)
    /// Whether or not chart is interactive. True by default.
    static member inline interactive (value: bool) = unbox<IPieChartProperty> ("interactive", value)
    /// Whether or not to add legend. Default: 'true'.
    static member inline legend (value: bool) = unbox<IPieChartProperty> ("legend", value)
    /// Chart simplification. Default is 0.2.
    static member inline simplification(value: float) = unbox<IPieChartProperty> ("simplification", value)
    /// Padding between bars. Default: 0.1.
    static member inline padding(value: float) = unbox<IPieChartProperty>("padding", value)
    /// Margin of the chart. By default => margin(top=50, right=20, left=100, bottom=70)
    static member margin(?top: int, ?right: int, ?left: int, ?bottom: int) =
        let margin = createObj [
            "top" ==> Option.defaultValue 50 top
            "right" ==> Option.defaultValue 20 right
            "left" ==> Option.defaultValue 100 left
            "bottom" ==> Option.defaultValue 70 bottom
        ]

        unbox<IPieChartProperty> ("margin", margin)

[<Erase>]
module pieChart =
    [<Erase>]
    type fillStyle =
        static member inline hachure = unbox<IPieChartProperty> ("fillStyle", "hachure")
        static member inline crossHatch = unbox<IPieChartProperty> ("fillStyle", "cross-hatch")
        static member inline zigzag = unbox<IPieChartProperty> ("fillStyle", "zigzag")
        static member inline dashed = unbox<IPieChartProperty> ("fillStyle", "dashed")
        static member inline solid = unbox<IPieChartProperty> ("fillStyle", "solid")
        static member inline zigzagLine = unbox<IPieChartProperty> ("fillStyle", "zigzag-line")