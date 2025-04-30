namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type pieChart =
    /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
    static member inline syncId (value: string) = Interop.mkPieChartAttr "syncId" value
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkPieChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkPieChartAttr "height" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkPieChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkPieChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkPieChartAttr "data" values
    static member inline children (elements: ReactElement list) = unbox<IPieChartProperty> (prop.children elements)

    /// The sizes of whitespace around the container.
    ///
    /// Default value `{ top: 5, right: 5, bottom: 5, left: 5 }`
    static member inline margin (?top: int, ?right: int, ?left: int, ?bottom: int) =
        let margin =
            createObj
                [ "top" ==> Option.defaultValue 0 top
                  "right" ==> Option.defaultValue 0 right
                  "left" ==> Option.defaultValue 0 left
                  "bottom" ==> Option.defaultValue 0 bottom ]

        Interop.mkPieChartAttr "margin" margin