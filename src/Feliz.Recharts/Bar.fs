namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type bar =
    static member inline name(value: string) = Interop.mkBarAttr "name" value
    static member inline name(value: int) = Interop.mkBarAttr "name" value
    static member inline dataKey (value: string) = Interop.mkBarAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkBarAttr "dataKey" f
    static member inline stroke (color: string) = Interop.mkBarAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkBarAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkBarAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkBarAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkBarAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkBarAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkBarAttr "fillOpacity" value
    static member inline stackId (value: string) = Interop.mkBarAttr "stackId" value
    static member inline xAxisId (value: string) = Interop.mkBarAttr "xAxisId" value
    static member inline yAxisId (value: string) = Interop.mkBarAttr "yAxisId" value
    static member inline xAxisId (value: int) = Interop.mkBarAttr "xAxisId" value
    static member inline yAxisId (value: int) = Interop.mkBarAttr "yAxisId" value
    static member inline children (elements: ReactElement list) = Interop.mkBarAttr "children" (prop.children elements)
    static member inline children (elements: ReactElement seq) = Interop.mkBarAttr "children" (prop.children elements)
    static member inline isAnimationActive (value: bool) = Interop.mkBarAttr "isAnimationActive" value
    static member inline barSize (value: int) = Interop.mkBarAttr "barSize" value
    static member inline maxBarSize (value: int) = Interop.mkBarAttr "maxBarSize" value
    static member inline minPointSize (value: int) = Interop.mkBarAttr "minPointSize" value
    static member inline unit (value: string) = Interop.mkBarAttr "unit" value
    static member inline unit (value: int) = Interop.mkBarAttr "unit" value
    static member inline animationDuration (value: int) = Interop.mkBarAttr "animationDuration" value
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkBarAttr "animationDuration" value.TotalMilliseconds
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkBarAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkBarAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

module bar =
    [<Erase>]
    type legendType =
        static member inline line = Interop.mkBarAttr "legendType" "line"
        static member inline square = Interop.mkBarAttr "legendType" "square"
        static member inline rect = Interop.mkBarAttr "legendType" "rect"
        static member inline circle = Interop.mkBarAttr "legendType" "circle"
        static member inline cross = Interop.mkBarAttr "legendType" "cross"
        static member inline diamond = Interop.mkBarAttr "legendType" "diamond"
        static member inline star = Interop.mkBarAttr "legendType" "star"
        static member inline triangle = Interop.mkBarAttr "legendType" "triangle"
        static member inline wye = Interop.mkBarAttr "legendType" "wye"
        static member inline none = Interop.mkBarAttr "legendType" "none"

    /// The layout of area in the chart.
    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkBarAttr "layout" "horizontal"
        static member inline vertical = Interop.mkBarAttr "layout" "vertical"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkBarAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkBarAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkBarAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkBarAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkBarAttr "animationEasing" "linear"
