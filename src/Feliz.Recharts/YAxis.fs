namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type yAxis =
    static member inline minTickGap(value : int) = Interop.mkYAxisAttr "minTickGap" value 

    /// The key of data displayed in the y-axis.
    static member inline dataKey (value: string) = Interop.mkYAxisAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkYAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkYAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkYAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkYAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkYAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkYAxisAttr "dataKey" f
    /// If set true, the axis do not display in the chart.
    static member inline hide (value: bool) = Interop.mkYAxisAttr "hide" value
    /// The unique id of y-axis.
    static member inline yAxisId (value: int) = Interop.mkYAxisAttr "yAxisId" value
    /// The unique id of y-axis.
    static member inline yAxisId (value: string) = Interop.mkYAxisAttr "yAxisId" value
    /// Sets the type of the axis to `number`
    static member inline number = Interop.mkYAxisAttr "type" "number"
    /// Sets the type of the axis to `category`
    static member inline category = Interop.mkYAxisAttr "type" "category"
    /// Allow the ticks of XAxis to be decimals or not. Default is `true`.
    static member inline allowDecimals (value: bool) = Interop.mkYAxisAttr "allowDecimals" value
    /// When domain of the axis is specified and the type of the axis is 'number', if allowDataOverflow is set to be false, the domain will be adjusted when the minimum value of data is smaller than domain[0] or the maximum value of data is greater than domain[1] so that the axis displays all data values. If set to true, graphic elements (line, area, bars) will be clipped to conform to the specified domain. Default is `false`.
    static member inline allowDataOverflow (value: bool) = Interop.mkYAxisAttr "allowDataOverflow" value
    /// Allow the axis has duplicated categorys or not when the type of axis is "category".
    static member inline allowDuplicatedCategory (value: bool) = Interop.mkYAxisAttr "allowDuplicatedCategory" value
    /// The count of axis ticks. Not used if 'type' is 'category'. Default is `5`.
    static member inline tickCount (value: int) = Interop.mkYAxisAttr "tickCount" value
    static member inline tickFormatter (f: int -> string) = Interop.mkYAxisAttr "tickFormatter" f
    static member inline domain (min: IAxisDomain, max: IAxisDomain) = Interop.mkYAxisAttr "domain" [| min; max |]
    static member inline interval (value: int) = Interop.mkYAxisAttr "interval" value
    /// Specify the padding of y-axis. Default is `yAxis.padding(top=0, bottom=0)`.
    static member inline padding (?top: int, ?right: int, ?left: int, ?bottom: int) =
        let padding =
            createObj
                [ "top" ==> Option.defaultValue 0 top
                  "right" ==> Option.defaultValue 0 right
                  "left" ==> Option.defaultValue 0 left
                  "bottom" ==> Option.defaultValue 0 bottom ]

        Interop.mkYAxisAttr "padding" padding
    static member inline unit (value: string) = Interop.mkYAxisAttr "unit" value
    static member inline name (value: string) = Interop.mkYAxisAttr "name" value
    static member inline height (value: int) = Interop.mkYAxisAttr "height" value
    static member inline height (value: float) = Interop.mkYAxisAttr "height" value
    static member inline width (value: int) = Interop.mkYAxisAttr "width" value
    static member inline width (value: float) = Interop.mkYAxisAttr "width" value
    static member inline reversed (value: bool) = Interop.mkYAxisAttr "reversed" value

    static member inline label(value: int) = Interop.mkYAxisAttr "label" value
    static member inline label(?value: string, ?angle: int, ?position: Label.Position) =
        let label = createObj [
          "value" ==> value
          "angle" ==> angle
          "position" ==> position
        ]
        Interop.mkYAxisAttr "label" label
    static member inline label(?value: string, ?angle: int, ?position: label.position) =
        let label = createObj [
          "value" ==> value
          "angle" ==> angle
          "position" ==> position
        ]
        Interop.mkYAxisAttr "label" label
    static member inline children (elements: ReactElement list) = unbox<IYAxisProperty> (prop.children elements)
        
module yAxis =
    /// The orientation of axis. Default is `left`.
    [<Erase>]
    type orientation =
        static member inline left = Interop.mkYAxisAttr "orientation" "left"
        static member inline right = Interop.mkYAxisAttr "orientation" "right"

    [<Erase>]
    type interval =
        static member inline preserveStart = Interop.mkYAxisAttr "interval" "preserveStart"
        static member inline preserveEnd = Interop.mkYAxisAttr "interval" "preserveEnd"
        static member inline preserveStartEnd = Interop.mkYAxisAttr "interval" "preserveStartEnd"

    [<Erase>]
    type scale =
        static member inline auto = Interop.mkYAxisAttr "scale" "auto"
        static member inline linear = Interop.mkYAxisAttr "scale" "linear"
        static member inline pow = Interop.mkYAxisAttr "scale" "pow"
        static member inline sqrt = Interop.mkYAxisAttr "scale" "sqrt"
        static member inline log = Interop.mkYAxisAttr "scale" "log"
        static member inline identity = Interop.mkYAxisAttr "scale" "identity"
        static member inline time = Interop.mkYAxisAttr "scale" "time"
        static member inline band = Interop.mkYAxisAttr "scale" "band"
        static member inline point = Interop.mkYAxisAttr "scale" "point"
        static member inline ordinal = Interop.mkYAxisAttr "scale" "ordinal"
        static member inline quantile = Interop.mkYAxisAttr "scale" "quantile"
        static member inline quantize = Interop.mkYAxisAttr "scale" "quantize"
        static member inline utc = Interop.mkYAxisAttr "scale" "utc"
        static member inline sequential = Interop.mkYAxisAttr "scale" "sequential"
        static member inline threshold = Interop.mkYAxisAttr "scale" "threshold"

    [<Erase>]
    type type' =
        static member inline number = Interop.mkYAxisAttr "type" "number"
        static member inline category = Interop.mkYAxisAttr "type" "category"
