namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type composedChart =
    /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
    static member inline syncId (value: string) = Interop.mkComposedChartAttr "syncId" value
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkComposedChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkComposedChartAttr "height" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkComposedChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkComposedChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkComposedChartAttr "data" values
    static member inline children (elements: ReactElement list) = unbox<IComposedChartProperty> (prop.children elements)

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

        Interop.mkComposedChartAttr "margin" margin
    /// The gap between two bar categories.
    static member inline barCategoryGap (value: int) = Interop.mkComposedChartAttr "barCategoryGap" value
    /// The gap between two bar categories
    static member inline barCategoryGap (value: float) = Interop.mkComposedChartAttr "barCategoryGap" value
    /// The gap between two bar categories
    static member inline barCategoryGapPercentage (value: int) = Interop.mkComposedChartAttr "barCategoryGap" (unbox<string>value + "%")
    /// The gap between two bars in the same category. Default is 4.
    static member inline barGap (value: int) = Interop.mkComposedChartAttr "barGap" value
    static member inline barGap (value: float) = Interop.mkComposedChartAttr "barGap" value
    /// The gap between two bars in the same category.
    static member inline barGapPercentage (value: int) = Interop.mkComposedChartAttr "barGap" (unbox<string>value + "%")
    static member inline barGapPercentage (value: float) = Interop.mkComposedChartAttr "barGap" (unbox<string>value + "%")
    static member inline barSize (value: int) = Interop.mkComposedChartAttr "barSize" value
    static member inline barSize (value: float) = Interop.mkComposedChartAttr "barSize" value
    /// If false set, stacked items will be rendered left to right. If true set, stacked items will be rendered right to left. (Render direction affects SVG layering, not x position.)
    static member inline reverseStackOrder (value: bool) = Interop.mkComposedChartAttr "reverseStackOrder" value
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkComposedChartAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkComposedChartAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkComposedChartAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkComposedChartAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkComposedChartAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkComposedChartAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs
[<Erase>]
module composedChart =
    /// The layout of area in the chart.
    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkComposedChartAttr "layout" "horizontal"
        static member inline vertical = Interop.mkComposedChartAttr "layout" "vertical"