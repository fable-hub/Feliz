namespace Feliz.Recharts

open System
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type brush =
    static member inline dataKey (key: string) = Interop.mkBrushAttr "dataKey" key
    static member inline dataKey (key: int) = Interop.mkBrushAttr "dataKey" key
    static member inline dataKey (f: 'a -> string) = Interop.mkBrushAttr "dataKey" (f (unbox null))
    static member inline stroke (color: string) = Interop.mkBrushAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkBrushAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkBrushAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkBrushAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkBrushAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkBrushAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkBrushAttr "fillOpacity" value
    /// The height of brush. Default is 40.
    static member inline height (value: int) = Interop.mkBrushAttr "height" value
    /// The width of brush.
    static member inline width (value: int) = Interop.mkBrushAttr "width" value
    /// The default start index of brush. If the option is not set, the start index will be 0.
    static member inline startIndex (index: int) = Interop.mkBrushAttr "startIndex" index
    /// The default end index of brush. If the option is not set, the end index will be calculated by the length of data.
    static member inline endIndex (index: int) = Interop.mkBrushAttr "endIndex" index
    /// The data with gap of refreshing chart. If the option is not set, the chart will be refreshed every time. Default 1.
    static member inline gap(value: int) = Interop.mkBrushAttr "gap" value
    /// The data with gap of refreshing chart. If the option is not set, the chart will be refreshed every time. Default 1.
    static member inline gap(value: float) = Interop.mkBrushAttr "gap" value
    /// The x-coordinate of brush.
    static member inline x(value: int) = Interop.mkBrushAttr "x" value
    /// The y-coordinate of brush.
    static member inline y(value: int) = Interop.mkBrushAttr "y" value
    /// The x-coordinate of brush.
    static member inline x(value: float) = Interop.mkBrushAttr "x" value
    /// The y-coordinate of brush.
    static member inline y(value: float) = Interop.mkBrushAttr "y" value