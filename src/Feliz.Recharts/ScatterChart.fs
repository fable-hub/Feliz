namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type scatterChart =
    /// The width of chart container.
    static member inline width (value: int) = Interop.mkScatterChartAttr "width" value
    /// The height of chart container.
    static member inline height (value: int) = Interop.mkScatterChartAttr "height" value
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkScatterChartAttr "data" (Seq.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkScatterChartAttr "data" (List.toArray values)
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkScatterChartAttr "data" values
    static member inline children (elements: ReactElement list) = unbox<IScatterChartProperty> (prop.children elements)
    
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

        Interop.mkScatterChartAttr "margin" margin
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkScatterChartAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkScatterChartAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkScatterChartAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkScatterChartAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkScatterChartAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkScatterChartAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

[<Erase>]
type scatter =
    static member inline name (value : string) = Interop.mkScatterAttr "name" value 
    static member inline xAxisId (value: string) = Interop.mkScatterAttr "xAxisId" value 
    static member inline yAxisId (value: string) = Interop.mkScatterAttr "yAxisId" value 
    static member inline xAxisId (value: int) = Interop.mkScatterAttr "xAxisId" value 
    static member inline yAxisId (value: int) = Interop.mkScatterAttr "yAxisId" value 
    ///// The source data, in which each element is an object.
    //static member inline points (points: seq<'a>) = Interop.mkScatterAttr "points" (Seq.toArray points)
    ///// The source data, in which each element is an object.
    //static member inline points (points: 'a list) = Interop.mkScatterAttr "points" (List.toArray points)
    ///// The source data, in which each element is an object.
    //static member inline porints (points: 'a array) = Interop.mkScatterAttr "points" points
    ///// If set false, animation of area will be disabled.
    static member inline isAnimationActive (value: bool) = Interop.mkScatterAttr "isAnimationActive" value 
    /// Specifies when the animation should begin, the unit of this option is ms.
    static member inline animationBegin (value: int) = Interop.mkScatterAttr "animationBegin" value 
    /// Specifies the duration of animation, the unit of this option is ms. Default is `1500ms`.
    static member inline animationDuration (value: int) = Interop.mkScatterAttr "animationDuration" value 
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkScatterAttr "animationDuration" value.TotalMilliseconds
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkScatterAttr "data" (Seq.toArray values) 
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkScatterAttr "data" (List.toArray values) 
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkScatterAttr "data" values 
    static member inline fill (color: string) = Interop.mkScatterAttr "fill" color 
    static member inline children (elements: ReactElement list) = unbox<IScatterProperty> (prop.children elements)
    static member inline margin (?top: int, ?right: int, ?bottom: int, ?left: int) = 
        let margin = 
            createObj [ 
            "top" ==> Option.defaultValue 0 top
            "right" ==> Option.defaultValue 0 right
            "bottom" ==> Option.defaultValue 0 bottom
            "left" ==> Option.defaultValue 0 left ]

        Interop.mkScatterAttr "margin" margin

[<Erase>]
module scatter =

    [<Erase>]
    type legendType =
        static member inline line = Interop.mkScatterAttr "legendType" "line"
        static member inline square = Interop.mkScatterAttr "legendType" "square"
        static member inline rect = Interop.mkScatterAttr "legendType" "rect"
        static member inline circle = Interop.mkScatterAttr "legendType" "circle"
        static member inline cross = Interop.mkScatterAttr "legendType" "cross"
        static member inline diamond = Interop.mkScatterAttr "legendType" "diamond"
        static member inline star = Interop.mkScatterAttr "legendType" "star"
        static member inline triangle = Interop.mkScatterAttr "legendType" "triangle"
        static member inline wye = Interop.mkScatterAttr "legendType" "wye"
        static member inline none = Interop.mkScatterAttr "legendType" "none"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkScatterAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkScatterAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkScatterAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkScatterAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkScatterAttr "animationEasing" "linear"


