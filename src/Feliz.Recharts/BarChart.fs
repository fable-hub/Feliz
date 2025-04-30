namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type barChart =
    /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
    static member inline syncId (value: string) = Interop.mkBarChartAttr "syncId" value
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkBarChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkBarChartAttr "height" value
    /// The source data, in which each element is an object.
    ///
    /// Format
    ///```
    /// [{ name: 'a', value: 12 }]
    /// [{ name: 'a', value: [5, 12] }]
    ///```
    static member inline data (values: seq<'a>) = Interop.mkBarChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    ///
    /// Format
    ///```
    /// [{ name: 'a', value: 12 }]
    /// [{ name: 'a', value: [5, 12] }]
    ///```
    static member inline data (values: 'a list) = Interop.mkBarChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    ///
    /// Format
    ///```
    /// [{ name: 'a', value: 12 }]
    /// [{ name: 'a', value: [5, 12] }]
    ///```
    static member inline data (values: 'a array) = Interop.mkBarChartAttr "data" values
    static member inline children (elements: ReactElement list) = unbox<IBarChartProperty> (prop.children elements)

    /// The sizes of whitespace around the container.
    ///
    /// Default value `{ top: 5, right: 5, bottom: 5, left: 5 }`
    static member inline margin(?top: int, ?right: int, ?left: int, ?bottom: int) =
        let margin = createObj [
            "top" ==> Option.defaultValue 0 top
            "right" ==> Option.defaultValue 0 right
            "left" ==> Option.defaultValue 0 left
            "bottom" ==> Option.defaultValue 0 bottom
        ]

        Interop.mkBarChartAttr "margin" margin
    /// The gap between two bar categories.
    static member inline barCategoryGap (value: int) = Interop.mkBarChartAttr "barCategoryGap" value
    /// The gap between two bar categories
    static member inline barCategoryGap (value: float) = Interop.mkBarChartAttr "barCategoryGap" value
    /// The gap between two bar categories
    static member inline barCategoryGapPercentage (value: int) = Interop.mkBarChartAttr "barCategoryGap" (unbox<string>value + "%")
    /// The gap between two bars in the same category. Default is 4.
    static member inline barGap (value: int) = Interop.mkBarChartAttr "barGap" value
    static member inline barGap (value: float) = Interop.mkBarChartAttr "barGap" value
    /// The gap between two bars in the same category.
    static member inline barGapPercentage (value: int) = Interop.mkBarChartAttr "barGap" (unbox<string>value + "%")
    static member inline barGapPercentage (value: float) = Interop.mkBarChartAttr "barGap" (unbox<string>value + "%")
    static member inline barSize (value: int) = Interop.mkBarChartAttr "barSize" value
    static member inline barSize (value: float) = Interop.mkBarChartAttr "barSize" value
    /// The maximum width of all the bars in a horizontal BarChart, or maximum height in a vertical BarChart.
    static member inline maxBarSize (value: int) = Interop.mkBarChartAttr "maxBarSize" value
    /// If false set, stacked items will be rendered left to right. If true set, stacked items will be rendered right to left. (Render direction affects SVG layering, not x position.)
    static member inline reverseStackOrder (value: bool) = Interop.mkBarChartAttr "reverseStackOrder" value
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarChartAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarChartAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarChartAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkBarChartAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarChartAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarChartAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs
    
    static member inline style (properties: #IStyleAttribute list) = Interop.mkBarChartAttr "style" (createObj !!properties)

module barChart =
    /// The layout of area in the chart.
    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkBarChartAttr "layout" "horizontal"
        static member inline vertical = Interop.mkBarChartAttr "layout" "vertical"

    /// The type of offset function used to generate the lower and upper values in the series array.  Default is `none`.
    [<Erase>]
    type stackOffset =
        static member inline expand = Interop.mkBarChartAttr "stackOffset" "expand"
        static member inline none = Interop.mkBarChartAttr "stackOffset" "none"
        static member inline wiggle = Interop.mkBarChartAttr "stackOffset" "wiggle"
        static member inline silhouette = Interop.mkBarChartAttr "stackOffset" "silhouette"
        static member inline sign = Interop.mkBarChartAttr "stackOffset" "sign"
