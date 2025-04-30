namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type radar =
    static member inline name(value: string) = Interop.mkRadarAttr "name" value
    static member inline dataKey (value: string) = Interop.mkRadarAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkRadarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkRadarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkRadarAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkRadarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkRadarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkRadarAttr "dataKey" f
    static member inline stroke (color: string) = Interop.mkRadarAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkRadarAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkRadarAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkRadarAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkRadarAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkRadarAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkRadarAttr "fillOpacity" value
    static member inline children (elements: ReactElement list) = Interop.mkRadarAttr "children" (prop.children elements)
    static member inline children (elements: ReactElement seq) = Interop.mkRadarAttr "children" (prop.children elements)
    static member inline isAnimationActive (value: bool) = Interop.mkRadarAttr "isAnimationActive" value