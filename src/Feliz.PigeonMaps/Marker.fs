namespace Feliz.PigeonMaps

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type marker =
    static member inline anchor(latitude: float, longitude: float) =
        PropHelper.mkAttr "anchor" [| latitude; longitude |]
    static member inline offsetLeft (offset: int) =
        PropHelper.mkAttr "offsetLeft" offset
    static member inline offsetTop (offset: int) =
        PropHelper.mkAttr "offsetTop" offset
    static member inline onClick (handler: MarkerClickEventArgs -> unit) =
        PropHelper.mkAttr "onClick" handler
    static member inline onMouseOver (handler: MarkerClickEventArgs -> unit) =
        PropHelper.mkAttr "onMouseOver" handler
    static member inline onMouseOut (handler: MarkerClickEventArgs -> unit) =
        PropHelper.mkAttr "onMouseOut" handler
    static member inline onContextMenu (handler: MarkerClickEventArgs -> unit) =
        PropHelper.mkAttr "onContextMenu" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement) =
        PropHelper.mkAttr "render" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement list) =
        PropHelper.mkAttr "render" (handler >> React.Fragment)

[<Erase>]
type marker<'t> =
    static member inline anchor(latitude: float, longitude: float) =
        PropHelper.mkAttr "anchor" [| latitude; longitude |]
    static member inline payload (value: 't) =
        PropHelper.mkAttr "payload" value
    static member inline onClick (handler: MarkerClickEventArgs<'t> -> unit) =
        PropHelper.mkAttr "onClick" handler
    static member inline onMouseOver (handler: MarkerClickEventArgs<'t> -> unit) =
        PropHelper.mkAttr "onMouseOver" handler
    static member inline onMouseOut (handler: MarkerClickEventArgs<'t> -> unit) =
        PropHelper.mkAttr "onMouseOut" handler
    static member inline onContextMenu (handler: MarkerClickEventArgs<'t> -> unit) =
        PropHelper.mkAttr "onContextMenu" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement) =
        PropHelper.mkAttr "render" handler
    static member inline render (handler: IMarkerRenderProperties -> Fable.React.ReactElement list) =
        PropHelper.mkAttr "render" (handler >> React.Fragment)
    static member inline offsetLeft (offset: int) =
        PropHelper.mkAttr "offsetLeft" offset
    static member inline offsetTop (offset: int) =
        PropHelper.mkAttr "offsetTop" offset
