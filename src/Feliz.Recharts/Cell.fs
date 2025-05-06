namespace Feliz.Recharts

open System

open Fable.Core
open Fable.Core.JsInterop

/// Cell can be wrapped by Pie, Bar, or RadialBar to specify attributes of each child. In Pie , for example, we can specify the attributes of each child node through data, but the props of Cell have higher priority.
[<Erase>]
type cell =
    static member inline key (value: string) = Interop.mkCellAttr "key" value
    static member inline key (value: Guid) = Interop.mkCellAttr "key" (string value)
    static member inline stroke (color: string) = Interop.mkCellAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkCellAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkCellAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkCellAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkCellAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkCellAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkCellAttr "fillOpacity" value
    static member inline cursor (value: string) = Interop.mkCellAttr "cursor" value
    static member inline onClick (eventHandler: Browser.Types.MouseEvent -> unit) = Interop.mkCellAttr "onClick" eventHandler
