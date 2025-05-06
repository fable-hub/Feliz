namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type funnel =
    /// The source data, in which each element is an object.
    static member inline data (values: seq<'a>) = Interop.mkFunnelAttr "data" (Seq.toArray values) 
    /// The source data, in which each element is an object.
    static member inline data (values: 'a list) = Interop.mkFunnelAttr "data" (List.toArray values) 
    /// The source data, in which each element is an object.
    static member inline data (values: 'a array) = Interop.mkFunnelAttr "data" values 
    static member inline dataKey (value: string) = Interop.mkFunnelAttr "dataKey" value
    static member inline dataKey (value: int) = Interop.mkFunnelAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkFunnelAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkFunnelAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkFunnelAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkFunnelAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkFunnelAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkFunnelAttr "dataKey" f
    static member inline nameKey (value: string) = Interop.mkFunnelAttr "nameKey" value
    static member inline trapezoids (?x: int, ?y: int, ?upperWidth: int, ?lowerWidth: int, ?height: int) = 
        let coordinates = 
            createObj [   
                "x" ==> Option.defaultValue 0 x
                "y" ==> Option.defaultValue 0 y
                "upperWidth" ==> Option.defaultValue 0 upperWidth
                "lowerWidth" ==> Option.defaultValue 0 lowerWidth 
                "height" ==> Option.defaultValue 0 height ]
            
        Interop.mkFunnelAttr "trapezoids" coordinates
    static member inline isAnimationActive (value: bool) = Interop.mkFunnelAttr "isAnimationActive" value
    /// Specifies when the animation should begin, the unit of this option is ms.
    static member inline animationBegin (value: int) = Interop.mkFunnelAttr "animationBegin" value
    /// Specifies the duration of animation, the unit of this option is ms. Default is `1500ms`.
    static member inline animationDuration (value: int) = Interop.mkFunnelAttr "animationDuration" value
    /// Specifies the duration of animation. Default is `1500ms`.
    static member inline animationDuration (value: TimeSpan) = Interop.mkFunnelAttr "animationDuration" value.TotalMilliseconds
    static member inline id (value: string) = Interop.mkFunnelAttr "id" value
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkFunnelAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkFunnelAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkFunnelAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkFunnelAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkFunnelAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkFunnelAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

module funnel = 
    [<Erase>]
    type legendType =
        static member inline line = Interop.mkFunnelAttr "legendType" "line"
        static member inline plainline = Interop.mkFunnelAttr "legendType" "plainline"
        static member inline square = Interop.mkFunnelAttr "legendType" "square"
        static member inline rect = Interop.mkFunnelAttr "legendType" "rect"
        static member inline circle = Interop.mkFunnelAttr "legendType" "circle"
        static member inline cross = Interop.mkFunnelAttr "legendType" "cross"
        static member inline diamond = Interop.mkFunnelAttr "legendType" "diamond"
        static member inline star = Interop.mkFunnelAttr "legendType" "star"
        static member inline triangle = Interop.mkFunnelAttr "legendType" "triangle"
        static member inline wye = Interop.mkFunnelAttr "legendType" "wye"
        static member inline none = Interop.mkFunnelAttr "legendType" "none"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkFunnelAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkFunnelAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkFunnelAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkFunnelAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkFunnelAttr "animationEasing" "linear"
