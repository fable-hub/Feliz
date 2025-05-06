namespace Feliz.Recharts

open System
open Feliz
open Fable.Core

[<Erase>]
type line =
    static member inline strokeWidth(value : int) = Interop.mkLineAttr "strokeWidth" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkLineAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkLineAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkLineAttr "data" values

    static member inline name(value: string) = Interop.mkLineAttr "name" value
    static member inline dataKey (value: string) = Interop.mkLineAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkLineAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkLineAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkLineAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkLineAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkLineAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkLineAttr "dataKey" f
    static member inline stroke (value: string) = Interop.mkLineAttr "stroke" value
    static member inline strokeOpacity (value: float) = Interop.mkLineAttr "stroke-opacity" value
    static member inline fill (value: string) = Interop.mkLineAttr "fill" value
    static member inline xAxisId (value: string) = Interop.mkLineAttr "xAxisId" value
    static member inline yAxisId (value: string) = Interop.mkLineAttr "yAxisId" value
    static member inline xAxisId (value: int) = Interop.mkLineAttr "xAxisId" value
    static member inline yAxisId (value: int) = Interop.mkLineAttr "yAxisId" value
    static member inline strokeDasharray([<ParamArray>] values: int []) = Interop.mkLineAttr "strokeDasharray" (values |> Array.map string |> String.concat " ")
    static member inline monotone = Interop.mkLineAttr "type" "monotone"
    static member inline basis = Interop.mkLineAttr "type" "basis"
    static member inline basisClosed = Interop.mkLineAttr "type" "basisClosed"
    static member inline basisOpen = Interop.mkLineAttr "type" "basisOpen"
    static member inline linear = Interop.mkLineAttr "type" "linear"
    static member inline linearClosed = Interop.mkLineAttr "type" "linearClosed"
    static member inline natural = Interop.mkLineAttr "type" "natural"
    static member inline monotoneX = Interop.mkLineAttr "type" "monotoneX"
    static member inline step = Interop.mkLineAttr "type" "step"
    static member inline stepBefore = Interop.mkLineAttr "type" "stepBefore"
    static member inline stepAfter = Interop.mkLineAttr "type" "stepAfter"
    static member inline monotoneY = Interop.mkLineAttr "type" "monotoneY"
    static member inline connectNulls (value : bool) = Interop.mkLineAttr "connectNulls" value
    static member inline dot(value: bool) = Interop.mkLineAttr "dot" value
    static member inline dot(render: IDotProperties<'a> -> ReactElement) = Interop.mkLineAttr "dot" render
    static member inline activeDot(value: bool) = Interop.mkLineAttr "activeDot" value
    static member inline activeDot(render: IDotProperties<'a> -> ReactElement) = Interop.mkLineAttr "activeDot" render
    static member inline label(value: string) = Interop.mkLineAttr "label" value
    static member inline label(value: int) = Interop.mkLineAttr "label" value
    static member inline label(value: float) = Interop.mkLineAttr "label" value
    static member inline label(value: ReactElement) = Interop.mkLineAttr "label" value
    static member inline label(value: ILabelProperties -> ReactElement) = Interop.mkLineAttr "label" value
    /// If set false, animation of area will be disabled.
    static member inline isAnimationActive (value: bool) = Interop.mkLineAttr "isAnimationActive" value
    /// Specifies when the animation should begin, the unit of this option is ms.
    static member inline animationBegin (value: int) = Interop.mkLineAttr "animationBegin" value
    /// Specifies the duration of animation, the unit of this option is ms. Default is `1500ms`.
    static member inline animationDuration (value: int) = Interop.mkLineAttr "animationDuration" value
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkLineAttr "animationDuration" value.TotalMilliseconds

[<Erase>]
module line =
    [<Erase>]
    type legendType =
        static member inline line = Interop.mkLineAttr "legendType" "line"
        static member inline square = Interop.mkLineAttr "legendType" "square"
        static member inline rect = Interop.mkLineAttr "legendType" "rect"
        static member inline circle = Interop.mkLineAttr "legendType" "circle"
        static member inline cross = Interop.mkLineAttr "legendType" "cross"
        static member inline diamond = Interop.mkLineAttr "legendType" "diamond"
        static member inline star = Interop.mkLineAttr "legendType" "star"
        static member inline triangle = Interop.mkLineAttr "legendType" "triangle"
        static member inline wye = Interop.mkLineAttr "legendType" "wye"
        static member inline none = Interop.mkLineAttr "legendType" "none"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkLineAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkLineAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkLineAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkLineAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkLineAttr "animationEasing" "linear"
