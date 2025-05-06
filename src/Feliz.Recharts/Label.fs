namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Obsolete "Label.Position is deprecated. Please use label.position instead. Ie- label.position.top instead of Label.Position.Top">]
module Label =
    [<StringEnum;RequireQualifiedAccess>]
    type Position =
        | Top
        | Left
        | Right
        | Bottom
        | Inside
        | Outside
        | InsideLeft
        | InsideRight
        | InsideTop
        | InsideBottom
        | InsideTopLeft
        | InsideBottomLeft
        | InsideTopRight
        | InsideBottomRight
        | InsideStart
        | InsideEnd
        | End
        | Center

[<Erase>]
type label =

    static member inline viewBox (value: string) = Interop.mkLabelAttr "viewBox" value
    static member inline viewBox (value: int) = Interop.mkLabelAttr "viewBox" value
    static member inline value (value: string) = Interop.mkLabelAttr "value" value
    static member inline value (value: int) = Interop.mkLabelAttr "value" value
    static member inline offset (value: int) = Interop.mkLabelAttr "offset" value
    static member inline id (value: string) = Interop.mkLabelAttr "id" value

module label =
    [<Erase>]
    type position =
        static member inline top = Interop.mkLabelAttr "position" "top"
        static member inline left = Interop.mkLabelAttr "position" "left"
        static member inline right = Interop.mkLabelAttr "position" "right"
        static member inline bottom = Interop.mkLabelAttr "position" "bottom"
        static member inline inside = Interop.mkLabelAttr "position" "inside"
        static member inline outside = Interop.mkLabelAttr "position" "outside"
        static member inline insideLeft = Interop.mkLabelAttr "position" "insideLeft"
        static member inline insideRight = Interop.mkLabelAttr "position" "insideRight"
        static member inline insideTop = Interop.mkLabelAttr "position" "insideTop"
        static member inline insideBottom = Interop.mkLabelAttr "position" "insideBottom"
        static member inline insideTopLeft = Interop.mkLabelAttr "position" "insideTopLeft"
        static member inline insideBottomLeft = Interop.mkLabelAttr "position" "insideBottomLeft"
        static member inline insideTopRight = Interop.mkLabelAttr "position" "insideTopRight"
        static member inline insideBottomRight = Interop.mkLabelAttr "position" "insideBottomRight"
        static member inline insideStart = Interop.mkLabelAttr "position" "insideStart"
        static member inline insideEnd = Interop.mkLabelAttr "position" "insideEnd"
        static member inline end' = Interop.mkLabelAttr "position" "end"
        static member inline center = Interop.mkLabelAttr "position" "center"
