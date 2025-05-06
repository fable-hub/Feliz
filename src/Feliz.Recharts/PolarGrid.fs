namespace Feliz.Recharts

open Feliz
open Fable.Core

[<Erase>]
type polarGrid =
    static member inline cx(value: float) = Interop.mkPolarGridAttr "cx" value
    static member inline cy(value: float) = Interop.mkPolarGridAttr "cy" value
    static member inline cx(value: int) = Interop.mkPolarGridAttr "cx" value
    static member inline cy(value: int) = Interop.mkPolarGridAttr "cy" value
    static member inline innerRadius(value: int) = Interop.mkPolarGridAttr "innerRadius" value
    static member inline innerRadius(value: float) = Interop.mkPolarGridAttr "innerRadius" value
    static member inline outerRadius(value: int) = Interop.mkPolarGridAttr "outerRadius" value
    static member inline outerRadius(value: float) = Interop.mkPolarGridAttr "outerRadius" value
    static member inline polarAngles(angles: float seq) = Interop.mkPolarGridAttr "polarAngles" (angles |> Seq.toArray)
    static member inline polarRadius(radius: float seq) = Interop.mkPolarGridAttr "polarRadius" (radius |> Seq.toArray)

module polarGrid =
    [<Erase>]
    type gridType =
        static member inline polygon = Interop.mkPolarGridAttr "gridType" "polygon"
        static member inline circle = Interop.mkPolarGridAttr "gridType" "circle"
