namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type pie =
    static member inline name(value: string) = Interop.mkPieAttr "name" value
    static member inline dataKey (value: string) = Interop.mkPieAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkPieAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkPieAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkPieAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkPieAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkPieAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkPieAttr "dataKey" f
    static member inline stroke (color: string) = Interop.mkPieAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkPieAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkPieAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkPieAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkPieAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkPieAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkPieAttr "fillOpacity" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkPieAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkPieAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkPieAttr "data" values
    /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
    static member inline cy(value: float) = Interop.mkPieAttr "cy" value
    /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
    static member inline cy(value: int) = Interop.mkPieAttr "cy" value
    /// /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
    static member inline cx(value: float) = Interop.mkPieAttr "cx" value
    /// /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
    static member inline cx(value: int) = Interop.mkPieAttr "cx" value
    static member inline innerRadius(value: float) = Interop.mkPieAttr "innerRadius" value
    static member inline innerRadius(value: int) = Interop.mkPieAttr "innerRadius" value
    static member inline outerRadius(value: float) = Interop.mkPieAttr "outerRadius" value
    static member inline outerRadius(value: int) = Interop.mkPieAttr "outerRadius" value
    static member inline startAngle (value: int) = Interop.mkPieAttr "startAngle" value
    static member inline startAngle (value: float) = Interop.mkPieAttr "startAngle" value
    static member inline endAngle (value: int) = Interop.mkPieAttr "endAngle" value
    static member inline endAngle (value: float) = Interop.mkPieAttr "endAngle" value
    static member inline minAngle (value: int) = Interop.mkPieAttr "minAngle" value
    static member inline minAngle (value: float) = Interop.mkPieAttr "minAngle" value
    /// The key of each sector's name. Default is `name`.
    static member inline nameKey (value: string) = Interop.mkPieAttr "nameKey" value
    static member inline label(value: bool) = Interop.mkPieAttr "label" value
    static member inline label(value: IPieLabelProperties -> ReactElement) = Interop.mkPieAttr "label" value
    static member inline labelLine(value: bool) = Interop.mkPieAttr "labelLine" value
    static member inline labelLine(value: IPieLabelProperties -> ReactElement) = Interop.mkPieAttr "labelLine" value
    static member inline activeIndex (value: int) = Interop.mkPieAttr "activeIndex" value
    static member inline activeIndex (value: int list) = Interop.mkPieAttr "activeIndex" (List.toArray value)
    static member inline activeIndex (value: int []) = Interop.mkPieAttr "activeIndex" value
    /// If set false, animation of area will be disabled.
    static member inline isAnimationActive (value: bool) = Interop.mkPieAttr "isAnimationActive" value
    /// Specifies when the animation should begin, the unit of this option is ms.
    static member inline animationBegin (value: int) = Interop.mkPieAttr "animationBegin" value
    /// Specifies the duration of animation, the unit of this option is ms. Default is `1500ms`.
    static member inline animationDuration (value: int) = Interop.mkPieAttr "animationDuration" value
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkPieAttr "animationDuration" value.TotalMilliseconds
    static member inline children (elements: ReactElement list) = Interop.mkPieAttr "children" (prop.children elements)
    static member inline children (elements: ReactElement seq) = Interop.mkPieAttr "children" (prop.children elements)

module pie =

    [<Erase>]
    type cy =
        /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
        static member inline percentage(value: float) = Interop.mkPieAttr "cy" (unbox<string> value + "%")
        /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
        static member inline percentage(value: int) = Interop.mkPieAttr "cy" (unbox<string> value + "%")

    [<Erase>]
    type innerRadius =
        static member inline percentage(value: float) = Interop.mkPieAttr "innerRadius" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.mkPieAttr "innerRadius" (unbox<string> value + "%")

    [<Erase>]
    type outerRadius =
        static member inline percentage(value: float) = Interop.mkPieAttr "outerRadius" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.mkPieAttr "outerRadius" (unbox<string> value + "%")

    [<Erase>]
    type cx =
        /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
        static member inline percentage(value: float) = Interop.mkPieAttr "cx" (unbox<string> value + "%")
        /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
        static member inline percentage(value: int) = Interop.mkPieAttr "cx" (unbox<string> value + "%")

    [<Erase>]
    type legendType =
        static member inline line = Interop.mkPieAttr "legendType" "line"
        static member inline square = Interop.mkPieAttr "legendType" "square"
        static member inline rect = Interop.mkPieAttr "legendType" "rect"
        static member inline circle = Interop.mkPieAttr "legendType" "circle"
        static member inline cross = Interop.mkPieAttr "legendType" "cross"
        static member inline diamond = Interop.mkPieAttr "legendType" "diamond"
        static member inline star = Interop.mkPieAttr "legendType" "star"
        static member inline triangle = Interop.mkPieAttr "legendType" "triangle"
        static member inline wye = Interop.mkPieAttr "legendType" "wye"
        static member inline none = Interop.mkPieAttr "legendType" "none"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkPieAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkPieAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkPieAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkPieAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkPieAttr "animationEasing" "linear"
