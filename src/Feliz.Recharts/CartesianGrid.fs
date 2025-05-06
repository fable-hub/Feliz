namespace Feliz.Recharts

open System

open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type cartesianGrid =
    static member inline strokeDasharray([<ParamArray>] values: int []) = Interop.mkCartesianGridAttr "strokeDasharray" (values |> Array.map string |> String.concat " ")
    static member inline stroke (value: string) = Interop.mkCartesianGridAttr "stroke" value
    static member inline strokeOpacity (opacity: int) = Interop.mkCartesianGridAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkCartesianGridAttr "strokeOpacity" opacity
    /// When set to false, no horizontal grid lines will be drawn. Default is `true`.
    static member inline horizontal (value: bool) = Interop.mkCartesianGridAttr "horizontal" value
    /// When set to false, no v grid lines will be drawn. Default is `true`.
    static member inline vertical (value: bool) = Interop.mkCartesianGridAttr "vertical" value
    /// The x-coordinate of grid.
    static member inline x(value: int) = Interop.mkCartesianGridAttr "x" value
    /// The x-coordinate of grid.
    static member inline x(value: float) = Interop.mkCartesianGridAttr "x" value
    /// The y-coordinate of grid.
    static member inline y(value: int) = Interop.mkCartesianGridAttr "y" value
    /// The y-coordinate of grid.
    static member inline y(value: float) = Interop.mkCartesianGridAttr "y" value