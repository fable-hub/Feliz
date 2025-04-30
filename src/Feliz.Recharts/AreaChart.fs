namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type areaChart =
    /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
    static member inline syncId (value: string) = Interop.mkAreaChartAttr "syncId" value
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkAreaChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkAreaChartAttr "height" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkAreaChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkAreaChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkAreaChartAttr "data" values
    /// The base value of area.
    static member inline baseValue (value: int) = Interop.mkAreaChartAttr "baseValue" value
    /// The base value of area.
    static member inline baseValue (value: float) = Interop.mkAreaChartAttr "baseValue" value
    static member inline children (elements: ReactElement list) = unbox<IAreaChartProperty> (prop.children elements)

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

        Interop.mkAreaChartAttr "margin" margin

    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkAreaChartAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkAreaChartAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkAreaChartAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkAreaChartAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkAreaChartAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkAreaChartAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

module areaChart =
    /// The type of offset function used to generate the lower and upper values in the series array. The four types are built-in offsets in d3-shape. Default is `none`.
    [<Erase>]
    type stackOffset =
        static member inline expand = Interop.mkAreaChartAttr "stackOffset" "expand"
        static member inline none = Interop.mkAreaChartAttr "stackOffset" "none"
        static member inline wiggle = Interop.mkAreaChartAttr "stackOffset" "wiggle"
        static member inline silhouette = Interop.mkAreaChartAttr "stackOffset" "silhouette"

    /// The base value of area. Default is `auto`.
    [<Erase>]
    type baseValue =
        static member inline dataMin = Interop.mkAreaChartAttr "baseValue" "dataMin"
        static member inline dataMax = Interop.mkAreaChartAttr "baseValue" "dataMax"
        static member inline auto = Interop.mkAreaChartAttr "baseValue" "auto"

    /// The layout of area in the chart.
    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkAreaChartAttr "layout" "horizontal"
        static member inline vertical = Interop.mkAreaChartAttr "layout" "vertical"