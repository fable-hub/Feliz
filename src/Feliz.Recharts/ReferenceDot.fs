namespace Feliz.Recharts


open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type referenceDot =
    static member inline xAxisId(value: string) = Interop.mkReferenceDotAttr "xAxisId" value
    static member inline xAxisId(value: int) = Interop.mkReferenceDotAttr "xAxisId" value
    static member inline xAxisId(value: float) = Interop.mkReferenceDotAttr "xAxisId" value
    static member inline yAxisId(value: string) = Interop.mkReferenceDotAttr "yAxisId" value
    static member inline yAxisId(value: int) = Interop.mkReferenceDotAttr "yAxisId" value
    static member inline yAxisId(value: float) = Interop.mkReferenceDotAttr "yAxisId" value
    static member inline stroke (color: string) = Interop.mkReferenceDotAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkReferenceDotAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkReferenceDotAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkReferenceDotAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkReferenceDotAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkReferenceDotAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkReferenceDotAttr "fillOpacity" value
    static member inline x(value: string) = Interop.mkReferenceDotAttr "x" value
    static member inline x(value: int) = Interop.mkReferenceDotAttr "x" value
    static member inline x(value: float) = Interop.mkReferenceDotAttr "x" value
    static member inline y(value: string) = Interop.mkReferenceDotAttr "y" value
    static member inline y(value: int) = Interop.mkReferenceDotAttr "y" value
    static member inline y(value: float) = Interop.mkReferenceDotAttr "y" value
    static member inline r(value: int) = Interop.mkReferenceDotAttr "r" value
    static member inline r(value: float) = Interop.mkReferenceDotAttr "r" value
    static member inline alwaysShow (value: bool) = Interop.mkReferenceDotAttr "alwaysShow" value
    static member inline inFront (value: bool) = Interop.mkReferenceDotAttr "inFront" value
    static member inline label (value: string) = Interop.mkReferenceDotAttr "label" value
    static member inline label (value: int) = Interop.mkReferenceDotAttr "label" value
    static member inline label (value: float) = Interop.mkReferenceDotAttr "label" value