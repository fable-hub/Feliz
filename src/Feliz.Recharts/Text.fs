namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type text =
    static member inline scaleToFit (value: bool) = Interop.mkTextAttr "scaleToFit" value
    static member inline angle (value: int) = Interop.mkTextAttr "angle" value
    static member inline width (value: int) = Interop.mkTextAttr "width" value

module text =

    [<Erase>]
    type textAnchor =
        static member inline start = Interop.mkTextAttr "textAnchor" "start"
        static member inline middle = Interop.mkTextAttr "textAnchor" "middle"
        static member inline end' = Interop.mkTextAttr "textAnchor" "end"
        static member inline inherit' = Interop.mkTextAttr "textAnchor" "inherit"

    [<Erase>]
    type verticalAnchor =
        static member inline start = Interop.mkTextAttr "verticalAnchor" "start"
        static member inline middle = Interop.mkTextAttr "verticalAnchor" "middle"
        static member inline end' = Interop.mkTextAttr "verticalAnchor" "end"