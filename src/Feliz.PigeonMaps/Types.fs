namespace Feliz.PigeonMaps

open Fable.Core

[<Erase>]
type MarkerClickEventArgs =
    abstract anchor : float * float

[<Erase>]
type MarkerClickEventArgs<'t> =
    abstract anchor : float * float
    abstract payload: 't

type IMapMarker = interface end

[<Erase>]
type IMapMouseEvent =
    abstract latLng : (float * float)
    abstract pixel : (float * float)
    abstract event : Browser.Types.MouseEvent

[<Erase>]
type IMapBounds =
    /// North-East Bounds
    abstract ne : (float * float)
    /// South-West bounds
    abstract sw : (float * float)

[<Erase>]
type IMapBoundsChangedArgs =
    abstract zoom : float
    abstract initial : bool
    abstract center : (float * float)
    abstract bounds : IMapBounds

[<Erase>]
type IMarkerRenderProperties =
    abstract anchor : float * float
    abstract hovered : bool