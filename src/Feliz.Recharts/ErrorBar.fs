namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type errorBar =
    static member inline dataKey (value: string) = Interop.mkErrorBarAttr "dataKey" value
    static member inline dataKey (value: int) = Interop.mkErrorBarAttr "dataKey" value
    static member inline width (value: int) = Interop.mkErrorBarAttr "width" value
    static member inline strokeWidth (value: int) = Interop.mkErrorBarAttr "strokeWidth" value
    static member inline stroke (color: string) = Interop.mkErrorBarAttr "stroke" color
    static member inline direction (value: string) = Interop.mkErrorBarAttr "direction" value