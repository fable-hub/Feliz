namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type legend =
    static member inline width (value: int) = Interop.mkLegendAttr "width" value
    static member inline height (value: int) = Interop.mkLegendAttr "height" value
    static member inline iconSize (value: int) = Interop.mkLegendAttr "iconSize" value
    static member inline chartWidth (value: int) = Interop.mkLegendAttr "chartWidth" value
    static member inline chartHeight (value: int) = Interop.mkLegendAttr "chartHeight" value
    static member inline margin (?top: int, ?left: int, ?right: int, ?bottom: int) = 
        let margin = 
            createObj [ 
                "top" ==> Option.defaultValue 0 top
                "left" ==> Option.defaultValue 0 left
                "right" ==> Option.defaultValue 0 right
                "bottom" ==> Option.defaultValue 0 bottom ]

        Interop.mkLegendAttr "margin" margin
    static member inline formatter (f: string -> 'a -> int -> ReactElement) = Interop.mkLegendAttr "formatter" (System.Func<_,_,_,_> f)
    static member inline wrapperStyle (properties: #IStyleAttribute list) = Interop.mkLegendAttr "wrapperStyle" (createObj !!properties)
    static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLegendAttr "onClick" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLegendAttr "onMouseEnter" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseMove (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLegendAttr "onMouseMove" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseLeave (handler: unit -> unit) = Interop.mkLegendAttr "onMouseLeave" handler
    static member inline onMouseUp (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLegendAttr "onMouseUp" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs

    static member inline onMouseDown (handler: ChartMouseEvent<'label, 'payload> -> unit) =
        Interop.mkLegendAttr "onMouseDown" <|
            fun eventArgs ->
                if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
                then ignore()
                else handler eventArgs


module legend =

    [<Erase>]
    type verticalAlign =
        static member inline top = Interop.mkLegendAttr "verticalAlign" "top"
        static member inline bottom = Interop.mkLegendAttr "verticalAlign" "bottom"
        static member inline left = Interop.mkLegendAttr "verticalAlign" "left"
        static member inline middle = Interop.mkLegendAttr "verticalAlign" "middle"

    [<Erase>]
    type iconType =
        static member inline line = Interop.mkLegendAttr "iconType" "line"
        static member inline plainline = Interop.mkLegendAttr "iconType" "plainline"
        static member inline square = Interop.mkLegendAttr "iconType" "square"
        static member inline rect = Interop.mkLegendAttr "iconType" "rect"
        static member inline circle = Interop.mkLegendAttr "iconType" "circle"
        static member inline cross = Interop.mkLegendAttr "iconType" "cross"
        static member inline diamond = Interop.mkLegendAttr "iconType" "diamond"
        static member inline star = Interop.mkLegendAttr "iconType" "star"
        static member inline triangle = Interop.mkLegendAttr "iconType" "triangle"
        static member inline wye = Interop.mkLegendAttr "iconType" "wye"

    [<Erase>]
    type align =
        static member inline left = Interop.mkLegendAttr "align" "left"
        static member inline center = Interop.mkLegendAttr "align" "center"
        static member inline right = Interop.mkLegendAttr "align" "right"

    [<Erase>]
    type layout =
        static member inline horizontal = Interop.mkLegendAttr "layout" "horizontal"
        static member inline vertical = Interop.mkLegendAttr "layout" "vertical"
