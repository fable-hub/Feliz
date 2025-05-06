namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Recharts

[<Erase>]
type radialBar =
    static member inline minAngle(value: int) = Interop.mkRadialBarAttr "minAngle" value
    static member inline minAngle(value: float) = Interop.mkRadialBarAttr "minAngle" value
    static member inline isAnimationActive (value: bool) = Interop.mkRadialBarAttr "isAnimationActive" value
    static member inline children (elements: ReactElement seq) = Interop.mkRadialBarAttr "children" (prop.children elements)
    static member inline children (elements: ReactElement list) = Interop.mkRadialBarAttr "children" (prop.children elements)

    static member inline dataKey (value: string) = Interop.mkRadialBarAttr "dataKey" value
    static member inline dataKey (f: 'a -> string) = Interop.mkRadialBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int) = Interop.mkRadialBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float) = Interop.mkRadialBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> string option) = Interop.mkRadialBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> int option) = Interop.mkRadialBarAttr "dataKey" f
    static member inline dataKey (f: 'a -> float option) = Interop.mkRadialBarAttr "dataKey" f

    static member inline stroke (color: string) = Interop.mkRadialBarAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkRadialBarAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkRadialBarAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkRadialBarAttr "strokeOpacity" opacity
    static member inline fill (color: string) = Interop.mkRadialBarAttr "fill" color
    static member inline fillOpacity (value: int) = Interop.mkRadialBarAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkRadialBarAttr "fillOpacity" value

    static member inline label(value: bool) = Interop.mkRadialBarAttr "label" value
    static member inline label(?position:Label.Position,?fill:string) =
        let label = createObj [
          "position" ==> position
          "fill" ==> fill
        ]
        Interop.mkRadialBarAttr "label" label

    static member inline label(?position:label.position,?fill:string) =
        let label = createObj [
          "position" ==> position
          "fill" ==> fill
        ]
        Interop.mkRadialBarAttr "label" label