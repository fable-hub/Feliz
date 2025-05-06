namespace Feliz.PigeonMaps

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type marker =
    static member inline anchor(latitude: float, longitude: float) =
        Interop.mkAttr "anchor" [| latitude; longitude |]
    static member inline offsetLeft (offset: int) =
        Interop.mkAttr "offsetLeft" offset
    static member inline offsetTop (offset: int) =
        Interop.mkAttr "offsetTop" offset
    static member inline onClick (handler: MarkerClickEventArgs -> unit) =
        Interop.mkAttr "onClick" handler
    static member inline onMouseOver (handler: MarkerClickEventArgs -> unit) =
        Interop.mkAttr "onMouseOver" handler
    static member inline onMouseOut (handler: MarkerClickEventArgs -> unit) =
        Interop.mkAttr "onMouseOut" handler
    static member inline onContextMenu (handler: MarkerClickEventArgs -> unit) =
        Interop.mkAttr "onContextMenu" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement) =
        Interop.mkAttr "render" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement list) =
        Interop.mkAttr "render" (handler >> React.fragment)

[<Erase>]
type marker<'t> =
    static member inline anchor(latitude: float, longitude: float) =
        Interop.mkAttr "anchor" [| latitude; longitude |]
    static member inline payload (value: 't) =
        Interop.mkAttr "payload" value
    static member inline onClick (handler: MarkerClickEventArgs<'t> -> unit) =
        Interop.mkAttr "onClick" handler
    static member inline onMouseOver (handler: MarkerClickEventArgs<'t> -> unit) =
        Interop.mkAttr "onMouseOver" handler
    static member inline onMouseOut (handler: MarkerClickEventArgs<'t> -> unit) =
        Interop.mkAttr "onMouseOut" handler
    static member inline onContextMenu (handler: MarkerClickEventArgs<'t> -> unit) =
        Interop.mkAttr "onContextMenu" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement) =
        Interop.mkAttr "render" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement list) =
        Interop.mkAttr "render" (handler >> React.fragment)
    static member inline offsetLeft (offset: int) =
        Interop.mkAttr "offsetLeft" offset
    static member inline offsetTop (offset: int) =
        Interop.mkAttr "offsetTop" offset