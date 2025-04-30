namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type xAxis =
    /// The key of data displayed in the x-axis.
    static member inline dataKey (value: string) = Interop.mkXAxisAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkXAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkXAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkXAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkXAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkXAxisAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkXAxisAttr "dataKey" f
    /// If set true, the axis do not display in the chart.
    static member inline hide (value: bool) = Interop.mkXAxisAttr "hide" value
    /// The unique id of x-axis.
    static member inline xAxisId (value: int) = Interop.mkXAxisAttr "xAxisId" value
    /// The unique id of x-axis.
    static member inline xAxisId (value: string) = Interop.mkXAxisAttr "xAxisId" value
    /// Sets the type of the axis to `number`
    static member inline number = Interop.mkXAxisAttr "type" "number"
    /// Sets the type of the axis to `category`
    static member inline category = Interop.mkXAxisAttr "type" "category"
    /// If set true, flips ticks around the axis line, displaying the labels inside the chart instead of outside.
    /// Default is `false`.
    static member inline mirror (value: bool) = Interop.mkXAxisAttr "mirror" value
    /// Allow the ticks of XAxis to be decimals or not. Default is `true`.
    static member inline allowDecimals (value: bool) = Interop.mkXAxisAttr "allowDecimals" value
    /// When domain of the axis is specified and the type of the axis is 'number', if allowDataOverflow is set to be false, the domain will be adjusted when the minimum value of data is smaller than domain[0] or the maximum value of data is greater than domain[1] so that the axis displays all data values. If set to true, graphic elements (line, area, bars) will be clipped to conform to the specified domain. Default is `false`.
    static member inline allowDataOverflow (value: bool) = Interop.mkXAxisAttr "allowDataOverflow" value
    /// Allow the axis has duplicated categorys or not when the type of axis is "category".
    static member inline allowDuplicatedCategory (value: bool) = Interop.mkXAxisAttr "allowDuplicatedCategory" value
    /// The count of axis ticks. Not used if 'type' is 'category'. Default is `5`.
    static member inline tickCount (value: int) = Interop.mkXAxisAttr "tickCount" value
    static member inline domain (min : IAxisDomain, max: IAxisDomain) = Interop.mkXAxisAttr "domain" [| min; max |]
    static member inline interval (value: int) = Interop.mkXAxisAttr "interval" value
    static member inline angle (value: float) = Interop.mkXAxisAttr "angle" value
    /// Specify the padding of x-axis. Default is `xAxis.padding(left=0, right=0)`.
    static member inline padding(?top: int, ?right: int, ?left: int, ?bottom: int) =
        let padding = createObj [
            "top" ==> Option.defaultValue 0 top
            "right" ==> Option.defaultValue 0 right
            "left" ==> Option.defaultValue 0 left
            "bottom" ==> Option.defaultValue 0 bottom
        ]

        Interop.mkXAxisAttr "padding" padding
    static member inline tickMargin (value: int) = Interop.mkXAxisAttr "tickMargin" value
    static member inline tickMargin (value: float) = Interop.mkXAxisAttr "tickMargin" value
    static member inline tickLine (value: bool) = Interop.mkXAxisAttr "tickLine" value
    static member inline unit (value: string) = Interop.mkXAxisAttr "unit" value
    static member inline name (value: string) = Interop.mkXAxisAttr "name" value
    static member inline tick (tickRenderer : IXAxisTickProperties -> ReactElement) = Interop.mkXAxisAttr "tick" tickRenderer
    static member inline tick (value : obj) = Interop.mkXAxisAttr "tick" value
    static member inline height (value: int) = Interop.mkXAxisAttr "height" value
    static member inline height (value: float) = Interop.mkXAxisAttr "height" value
    static member inline width (value: int) = Interop.mkXAxisAttr "width" value
    static member inline width (value: float) = Interop.mkXAxisAttr "width" value
    static member inline reversed (value: bool) = Interop.mkXAxisAttr "reversed" value

    static member inline label(value: int) = Interop.mkXAxisAttr "label" value
    static member inline label(?value: string, ?angle: int, ?position: Label.Position) =
        let label = createObj [
          "value" ==> value
          "angle" ==> angle
          "position" ==> position
        ]
        Interop.mkXAxisAttr "label" label
    static member inline label(?value: string, ?angle: int, ?position: label.position) =
        let label = createObj [
          "value" ==> value
          "angle" ==> angle
          "position" ==> position
        ]
        Interop.mkXAxisAttr "label" label
    static member inline children (elements: ReactElement list) = unbox<IXAxisProperty> (prop.children elements)
        
module xAxis =
    /// The orientation of axis. Default is `bottom`.
    [<Erase>]
    type orientation =
        static member inline top = Interop.mkXAxisAttr "orientation" "top"
        static member inline bottom = Interop.mkXAxisAttr "orientation" "bottom"

    [<Erase>]
    type interval =
        static member inline preserveStart = Interop.mkXAxisAttr "interval" "preserveStart"
        static member inline preserveEnd = Interop.mkXAxisAttr "interval" "preserveEnd"
        static member inline preserveStartEnd = Interop.mkXAxisAttr "interval" "preserveStartEnd"
        
    [<Erase>]
    type textAnchor =
        static member inline textAnchorStart = Interop.mkXAxisAttr "textAnchor" "start"
        static member inline textAnchorEnd = Interop.mkXAxisAttr "textAnchor" "end"
        static member inline textAnchorMiddle = Interop.mkXAxisAttr "textAnchor" "middle"

    [<Erase>]
    type type' =
        static member inline number = Interop.mkXAxisAttr "type" "number"
        static member inline category = Interop.mkXAxisAttr "type" "category"

    [<Erase>]
    type scale =
        static member inline auto = Interop.mkXAxisAttr "scale" "auto"
        static member inline linear = Interop.mkXAxisAttr "scale" "linear"
        static member inline pow = Interop.mkXAxisAttr "scale" "pow"
        static member inline sqrt = Interop.mkXAxisAttr "scale" "sqrt"
        static member inline log = Interop.mkXAxisAttr "scale" "log"
        static member inline identity = Interop.mkXAxisAttr "scale" "identity"
        static member inline time = Interop.mkXAxisAttr "scale" "time"
        static member inline band = Interop.mkXAxisAttr "scale" "band"
        static member inline point = Interop.mkXAxisAttr "scale" "point"
        static member inline ordinal = Interop.mkXAxisAttr "scale" "ordinal"
        static member inline quantile = Interop.mkXAxisAttr "scale" "quantile"
        static member inline quantize = Interop.mkXAxisAttr "scale" "quantize"
        static member inline utc = Interop.mkXAxisAttr "scale" "utc"
        static member inline sequential = Interop.mkXAxisAttr "scale" "sequential"
        static member inline threshold = Interop.mkXAxisAttr "scale" "threshold"