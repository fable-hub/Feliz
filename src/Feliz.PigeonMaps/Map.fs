namespace Feliz.PigeonMaps

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type map =
    /// Coordinates of the map center in the format [lat, lng]. Use if the component is controlled, e.g. you'll be listening to onBoundsChanged and passing a new center when the bounds change.
    static member inline center(latitude: float, longitude: float) =
        PropHelper.mkAttr "center" (ResizeArray [| latitude; longitude |])
    /// Current zoom level, e.g. 12, use for controlled components and update when onBoundsChanged give you a new value.
    static member inline zoom(value: int) = PropHelper.mkAttr "zoom" value
    /// Current zoom level, e.g. 12, use for controlled components and update when onBoundsChanged give you a new value.
    static member inline zoom(value: float) = PropHelper.mkAttr "zoom" value
    static member inline provider (handler: (float -> float -> float -> int -> string)) =
        let uncurried = System.Func<float, float, float, int, string>(fun x y z dpr -> handler x y z dpr)
        PropHelper.mkAttr "provider" uncurried
    /// Height of the component in pixels. Defaults to 100% of the parent div if not set.
    static member inline height(value: int) = PropHelper.mkAttr "height" value
    /// Width of the component in pixels. Defaults to 100% of the parent div if not set.
    static member inline width(value: int) = PropHelper.mkAttr "width" value
    /// Enables or disables animations while spanning from place to another or while zooming in or out.
    static member inline animate (value: bool) = PropHelper.mkAttr "animate" value
    /// Snap to discrete zoom increments (14, 15, 16, etc) when scrolling with the mouse or pinching with touch events, Defaults to true.
    static member inline zoomSnap (value: bool) = PropHelper.mkAttr "zoomSpan" value
    /// What to show as an attribution. React element or false to hide.
    static member inline attribution (value: bool) = PropHelper.mkAttr "attribution" value
    /// What to show as an attribution. React element or false to hide.
    static member inline attribution (value: string) = PropHelper.mkAttr "attribution" value
    /// What to show as an attribution. React element or false to hide.
    static member inline attribution (value: Fable.React.ReactElement) = PropHelper.mkAttr "attribution" value
    /// Prefix before attribution. React element or false to hide.
    static member inline attributionPrefix (value: bool) = PropHelper.mkAttr "attributionPrefix" value
    /// Prefix before attribution. React element or false to hide.
    static member inline attributionPrefix (value: string) = PropHelper.mkAttr "attributionPrefix" value
    /// Prefix before attribution. React element or false to hide.
    static member inline attributionPrefix (value: Fable.React.ReactElement) = PropHelper.mkAttr "attributionPrefix" value
    /// The lowest zoom level possible. Defaults to 1.
    static member inline minZoom (value: int) = PropHelper.mkAttr "minZoom" value
    /// The highest zoom level possible. Defaults to 18.
    static member inline maxZoom (value: int) = PropHelper.mkAttr "maxZoom" value
    /// An array of devicePixelRatios that your tile provider supports. Defaults to []. Pass an array like [1, 2] and the numbers here will be sent to provider as the 4th argument. The responses will be combined into an <img srcset> attribute, which modern browsers use to select tiles with the [right resolution](https://developer.mozilla.org/en-US/docs/Learn/HTML/Multimedia_and_embedding/Responsive_images#Resolution_switching_Same_size_different_resolutions).
    static member inline devicePixelRatios(values: int list) = PropHelper.mkAttr "dprs" (Array.ofList values)
    /// An array of devicePixelRatios that your tile provider supports. Defaults to []. Pass an array like [1, 2] and the numbers here will be sent to provider as the 4th argument. The responses will be combined into an <img srcset> attribute, which modern browsers use to select tiles with the [right resolution](https://developer.mozilla.org/en-US/docs/Learn/HTML/Multimedia_and_embedding/Responsive_images#Resolution_switching_Same_size_different_resolutions).
    static member inline devicePixelRatios([<System.ParamArray>]values: int []) = PropHelper.mkAttr "dprs" values
    /// Defines the children of the component. Alias for `map.markers`.
    static member inline children (children: IMapMarker list) = prop.children (unbox<ReactElement list> children)
    /// Defines the map markers
    static member inline markers (children: IMapMarker list) = prop.children (unbox<ReactElement list> children)
    /// Can the user interact with the map with the mouse? Defaults to true.
    static member inline mouseEvents (value: bool) = PropHelper.mkAttr "mouseEvents" value
    /// Can the user interact with the map by touching it? Defaults to true.
    static member inline touchEvents (value: bool) = PropHelper.mkAttr "touchEvents" value
    /// Zooming with the mouse wheel only works when you hold down the meta (cmd/win) key. Defaults to false.
    static member inline metaWheelZoom (value: bool) = PropHelper.mkAttr "metaWheelZoom" value
    /// Warning text to show if scrolling on a map with metaWheelZoom enabled, but without the meta key. Defaults to Use META+wheel to zoom!, where META is automatically replaced with either "⌘" or "⊞", depending on Mac vs non-Mac. Set to null to disable.
    static member inline metaWheelZoomWarning (value: string) = PropHelper.mkAttr "metaWheelZoomWarning" value
    /// Moving the map requires touching with two fingers. Defaults to false.
    static member inline twoFingerDrag (value: bool) = PropHelper.mkAttr "twoFingerDrag" value
    /// Warning to show when twoFingerDrag and you try to move the map with one finger. Defaults to Use two fingers to move the map. Set to null to disable.
    static member inline twoFingerDragWarning (value: string) = PropHelper.mkAttr "twoFingerDragWarning" value
    /// The z-index value for the meta warning. Defaults to 100
    static member inline warningZIndex (value: int) = PropHelper.mkAttr "warningZIndex" value
    static member inline onAnimationStart (handler: unit -> unit) = PropHelper.mkAttr "onAnimationStart" handler
    [<Obsolete("Use onAnimationStop instead")>]
    static member inline onAnimationEnd (handler: unit -> unit) = PropHelper.mkAttr "onAnimationEnd" handler
    static member inline onAnimationStop (handler: unit -> unit) = PropHelper.mkAttr "onAnimationStop" handler
    static member inline onClick (handler: IMapMouseEvent -> unit) = PropHelper.mkAttr "onClick" handler
    static member inline onBoundsChanged (handler: IMapBoundsChangedArgs -> unit) = PropHelper.mkAttr "onBoundsChanged" handler

module map =
    [<Emit "String.fromCharCode(97 + ($0 % 3))">]
    let internal fromCharCode (n: float) : string = jsNative

    type provider =
        static member openStreetMap : IReactProperty =
            "provider" ==> fun x y z dpr ->
                let s = fromCharCode (x + y + z)

                "https://" + s + ".tile.openstreetmap.org/" + 
                (unbox<string> z) + "/" + (unbox<string> x) + 
                "/" + (unbox<string> y) + ".png"
            |> unbox

        static member stamenToner : IReactProperty =
            "provider" ==> fun x y z dpr ->
                let size = if dpr >= 2 then "@2x" else ""

                "https://stamen-tiles.a.ssl.fastly.net/toner/" + 
                (unbox<string> z) + "/" + (unbox<string> x) + "/" + 
                (unbox<string> y) + size + ".png"
            |> unbox

        static member stamenTerrain : IReactProperty =
            "provider" ==> fun x y z dpr ->
                let size = if dpr >= 2 then "@2x" else ""

                "https://stamen-tiles.a.ssl.fastly.net/terrain/" + 
                (unbox<string> z) + "/" + (unbox<string> x) + "/" + 
                (unbox<string> y) + size + ".png"
            |> unbox
