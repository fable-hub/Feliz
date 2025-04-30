namespace Feliz.Recharts

open System
open Fable.Core
open Feliz
open Fable.Core.JsInterop

[<Erase>]
type area =
    static member inline dataKey (value: string) = Interop.mkAreaAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkAreaAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkAreaAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkAreaAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkAreaAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkAreaAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkAreaAttr "dataKey" f
    static member inline stroke (color: string) = Interop.mkAreaAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkAreaAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkAreaAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkAreaAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkAreaAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkAreaAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkAreaAttr "fillOpacity" value
    /// Whether to connect a graph area across null points. Default is `false`.
    static member inline connectNulls (value: bool) = Interop.mkAreaAttr "connectNulls" value
    /// The unit of data. This option will be used in tooltip.
    static member inline unit (value: string) = Interop.mkAreaAttr "unit" value
    /// The name of data. This option will be used in tooltip and legend to represent a area. If no value was set to this option, the value of `dataKey` will be used alternatively.
    static member inline name (value: string) = Interop.mkAreaAttr "name" value
    /// The unique id of this component, which will be used to generate unique clip path id internally.
    static member inline id(value: string) = Interop.mkAreaAttr "id" value
    /// If set false, animation of area will be disabled.
    static member inline isAnimationActive (value: bool) = Interop.mkAreaAttr "isAnimationActive" value
    /// Specifies when the animation should begin, the unit of this option is ms.
    static member inline animationBegin (value: int) = Interop.mkAreaAttr "animationBegin" value
    /// Specifies the duration of animation, the unit of this option is ms. Default is `1500ms`.
    static member inline animationDuration (value: int) = Interop.mkAreaAttr "animationDuration" value
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkAreaAttr "animationDuration" value.TotalMilliseconds
    static member inline strokeDasharray([<ParamArray>] values: int []) = Interop.mkAreaAttr "strokeDasharray" (values |> Array.map string |> String.concat " ")
    static member inline monotone = Interop.mkAreaAttr "type" "monotone"
    static member inline basis = Interop.mkAreaAttr "type" "basis"
    static member inline basisClosed = Interop.mkAreaAttr "type" "basisClosed"
    static member inline basisOpen = Interop.mkAreaAttr "type" "basisOpen"
    static member inline linear = Interop.mkAreaAttr "type" "linear"
    static member inline linearClosed = Interop.mkAreaAttr "type" "linearClosed"
    static member inline natural = Interop.mkAreaAttr "type" "natural"
    static member inline monotoneX = Interop.mkAreaAttr "type" "monotoneX"
    static member inline step = Interop.mkAreaAttr "type" "step"
    static member inline stepBefore = Interop.mkAreaAttr "type" "stepBefore"
    static member inline stepAfter = Interop.mkAreaAttr "type" "stepAfter"
    static member inline monotoneY = Interop.mkAreaAttr "type" "monotoneY"
    static member inline stackId(value: string) = Interop.mkAreaAttr "stackId" value
    static member inline dot(value: bool) = Interop.mkAreaAttr "dot" value
    static member inline dot(render: IDotProperties<'a> -> ReactElement) = Interop.mkAreaAttr "dot" render

[<Erase>]
module area =
    [<Erase>]
    type legendType =
        static member inline line = Interop.mkAreaAttr "legendType" "line"
        static member inline square = Interop.mkAreaAttr "legendType" "square"
        static member inline rect = Interop.mkAreaAttr "legendType" "rect"
        static member inline circle = Interop.mkAreaAttr "legendType" "circle"
        static member inline cross = Interop.mkAreaAttr "legendType" "cross"
        static member inline diamond = Interop.mkAreaAttr "legendType" "diamond"
        static member inline star = Interop.mkAreaAttr "legendType" "star"
        static member inline triangle = Interop.mkAreaAttr "legendType" "triangle"
        static member inline wye = Interop.mkAreaAttr "legendType" "wye"
        static member inline none = Interop.mkAreaAttr "legendType" "none"

    /// The layout of area in the chart.
    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkAreaAttr "layout" "horizontal"
        static member inline vertical = Interop.mkAreaAttr "layout" "vertical"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkAreaAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkAreaAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkAreaAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkAreaAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkAreaAttr "animationEasing" "linear"
