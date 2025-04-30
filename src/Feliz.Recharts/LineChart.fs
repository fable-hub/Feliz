namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type lineChart =
    /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
    static member inline syncId (value: string) = Interop.mkLineChartAttr "syncId" value
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkLineChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkLineChartAttr "height" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkLineChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkLineChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkLineChartAttr "data" values
    static member inline children (elements: ReactElement list) = unbox<ILineChartProperty> (prop.children elements)
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

        Interop.mkLineChartAttr "margin" margin

    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLineChartAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLineChartAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLineChartAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkLineChartAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLineChartAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLineChartAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

module lineChart =

    /// The layout of area in the chart.
    type layout =
        static member inline horizontal = Interop.mkLineChartAttr "layout" "horizontal"
        static member inline vertical = Interop.mkLineChartAttr "layout" "vertical"

