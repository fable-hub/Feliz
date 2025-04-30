namespace Feliz.RoughViz

open Fable.Core
open Fable.Core.JsInterop

type IBarChartProperty = interface end

type barChart =
    static member data(points: (string * float) seq) =
        let labels = [| for (label, value) in points -> label |]
        let values = [| for (label, value) in points -> value |]
        let result = toPlainJsObj {| labels = labels; values = values; |}
        unbox<IBarChartProperty> ("data", result)

    /// Color for each bar. Default is "skyblue"
    static member inline color(colorName: string) = unbox<IBarChartProperty> ("color", colorName)
    static member inline height(value: int) = unbox<IBarChartProperty> ("height", value)
    static member inline height(value: float) = unbox<IBarChartProperty> ("height", value)
    static member inline axisFontSize(fontSize: string) = unbox<IBarChartProperty> ("axisFontSize", fontSize)
    static member inline axisFontSize(fontSize: int) = unbox<IBarChartProperty> ("axisFontSize", unbox<string> fontSize + "px")
    static member inline axisFontSize(fontSize: float) = unbox<IBarChartProperty> ("axisFontSize", unbox<string> fontSize + "px")
    /// Roughness for x & y axes. Default = 0.0
    static member inline axisRoughness(roughness: float) = unbox<IBarChartProperty> ("axisRoughness", roughness)
    /// Stroke-width for x & y axes. Default = 0.5
    static member inline axisStrokeWidth(strokeWidth: float) = unbox<IBarChartProperty> ("axisStrokeWidth", strokeWidth)
    /// Chart bowing. Default = 0
    static member inline bowing(value: float) = unbox<IBarChartProperty> ("bowing", value)
    /// Weight of inner paths' color. Default: 0.5
    static member inline fillWeight(value: float) = unbox<IBarChartProperty> ("fillWeight", value)
    /// Font family to use
    static member inline font(fontFamily: string) = unbox<IBarChartProperty> ("font", fontFamily)
    /// Color for each bar on hover
    static member inline highlight(colorName: string) = unbox<IBarChartProperty> ("highlight", colorName)
    /// Color of bars' stroke. Default: black.
    static member inline stroke(colorName: string) = unbox<IBarChartProperty> ("stroke", colorName)
    static member inline strokeWidth(width: int) = unbox<IBarChartProperty> ("strokeWidth", width)
    static member inline innerStrokeWidth(width: int) = unbox<IBarChartProperty> ("innerStrokeWidth", width)
    static member inline title(chartTitle: string) = unbox<IBarChartProperty> ("title", chartTitle)
    static member inline titleFontSize(fontSize:int) = unbox<IBarChartProperty> ("titleFontSize", unbox<string> fontSize + "px")
    static member inline titleFontSize(fontSize:float) = unbox<IBarChartProperty> ("titleFontSize", unbox<string> fontSize + "px")
    static member inline titleFontSize(fontSize: string) = unbox<IBarChartProperty> ("titleFontSize", fontSize)
    static member inline tooltipFontSize(fontSize:int) = unbox<IBarChartProperty> ("tooltipFontSize", unbox<string> fontSize + "px")
    static member inline tooltipFontSize(fontSize:float) = unbox<IBarChartProperty> ("tooltipFontSize", unbox<string> fontSize + "px")
    static member inline tooltipFontSize(fontSize: string) = unbox<IBarChartProperty> ("tooltipFontSize", fontSize)
    static member inline xLabel(label: string) = unbox<IBarChartProperty> ("xLabel", label)
    static member inline yLabel(label: string) = unbox<IBarChartProperty> ("yLabel", label)
    static member inline roughness(value: int) = unbox<IBarChartProperty> ("roughness", abs value)
    ///  Whether or not chart is interactive. True by default.
    static member inline interactive (value: bool) = unbox<IBarChartProperty> ("interactive", value)
    /// Chart simplification. Default is 0.2
    static member inline simplification(value: float) = unbox<IBarChartProperty> ("simplification", value)
    /// Padding between bars. Default: 0.1.
    static member inline padding(value: float) = unbox<IBarChartProperty>("padding", value)
    /// Margin of the chart. By default => margin(top=50, right=20, left=100, bottom=70)
    static member margin(?top: int, ?right: int, ?left: int, ?bottom: int) =
        let margin = createObj [
            "top" ==> Option.defaultValue 50 top
            "right" ==> Option.defaultValue 20 right
            "left" ==> Option.defaultValue 100 left
            "bottom" ==> Option.defaultValue 70 bottom
        ]

        unbox<IBarChartProperty> ("margin", margin)

    static member inline barClicked (handler: int -> unit) = unbox<IBarChartProperty>("barClicked", handler)

[<Erase>]
module barChart =
    [<Erase>]
    type fillStyle =
        static member inline hachure = unbox<IBarChartProperty> ("fillStyle", "hachure")
        static member inline crossHatch = unbox<IBarChartProperty> ("fillStyle", "cross-hatch")
        static member inline zigzag = unbox<IBarChartProperty> ("fillStyle", "zigzag")
        static member inline dashed = unbox<IBarChartProperty> ("fillStyle", "dashed")
        static member inline solid = unbox<IBarChartProperty> ("fillStyle", "solid")
        static member inline zigzagLine = unbox<IBarChartProperty> ("fillStyle", "zigzag-line")