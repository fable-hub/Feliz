namespace Feliz.PigeonMaps

open Feliz
open Fable.Core
open Fable.Core.JsInterop

module Interop =
    /// Creates a map marker internally (which is actually `ReactElement`)
    let createMarker : obj -> IMapMarker = import "createMarker" "./Marker.js"
    [<Emit("Object.assign({}, $0, $1)")>]
    let objectAssign (x: obj) (y: obj) = jsNative

[<Erase>]
type PigeonMaps =
    static member inline map (properties: IReactProperty list) =
        // use defaults with center at Madrid and zoom at the whole world
        // this is because pigeon maps throws an exception when center isn't provided
        let defaults = createObj [
            "center" ==> [| 40.416775; -3.703790 |]
            "zoom" ==> 3
            unbox map.provider.openStreetMap
        ]

        Interop.reactApi.createElement(import "Map" "pigeon-maps", Interop.objectAssign defaults (createObj !!properties))
    static member inline marker (properties: IReactProperty list) =
        Interop.createMarker (createObj !!properties)

    static member inline zoomControl (properties: IReactProperty list) =
        Interop.reactApi.createElement (import "ZoomControl" "pigeon-maps", obj())