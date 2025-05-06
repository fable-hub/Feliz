namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type labelList =
    /// Specifies data key for the label list 
    /// 
    /// ie: labelList.dataKey (fun (d:{| name : string; data : int64 |}) -> d.name)
    static member inline dataKey (f: 'a -> string) = Interop.mkLabelListAttr "dataKey" (System.Func<_,_> f)
    static member inline style (properties: #IStyleAttribute list) = Interop.mkLabelListAttr "style" (createObj !!properties)
    static member inline formatter (f: 'a -> string -> 'b -> 'c) = Interop.mkLabelListAttr "formatter" (System.Func<_,_,_,_> f)
    static member inline offset (value: int) = Interop.mkLabelListAttr "offset" value
    static member inline clockWise (value: string) = Interop.mkLabelListAttr "clockWise" value
    static member inline id (value: string) = Interop.mkLabelListAttr "id" value

module labelList =
    [<Erase>]
    type position =
        static member inline top = Interop.mkLabelListAttr "position" "top"
        static member inline left = Interop.mkLabelListAttr "position" "left"
        static member inline right = Interop.mkLabelListAttr "position" "right"
        static member inline bottom = Interop.mkLabelListAttr "position" "bottom"
        static member inline inside = Interop.mkLabelListAttr "position" "inside"
        static member inline outside = Interop.mkLabelListAttr "position" "outside"
        static member inline insideLeft = Interop.mkLabelListAttr "position" "insideLeft"
        static member inline insideRight = Interop.mkLabelListAttr "position" "insideRight"
        static member inline insideTop = Interop.mkLabelListAttr "position" "insideTop"
        static member inline insideBottom = Interop.mkLabelListAttr "position" "insideBottom"
        static member inline insideTopLeft = Interop.mkLabelListAttr "position" "insideTopLeft"
        static member inline insideBottomLeft = Interop.mkLabelListAttr "position" "insideBottomLeft"
        static member inline insideTopRight = Interop.mkLabelListAttr "position" "insideTopRight"
        static member inline insideBottomRight = Interop.mkLabelListAttr "position" "insideBottomRight"
        static member inline insideStart = Interop.mkLabelListAttr "position" "insideStart"
        static member inline insideEnd = Interop.mkLabelListAttr "position" "insideEnd"
        static member inline end' = Interop.mkLabelListAttr "position" "end"
        static member inline center = Interop.mkLabelListAttr "position" "center"