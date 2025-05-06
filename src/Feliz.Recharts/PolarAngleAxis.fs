namespace Feliz.Recharts

open Feliz
open Fable.Core

[<Erase>]
type polarAngleAxis =
  static member inline dataKey (value: string) = Interop.mkPolarAngleAxisAttr "dataKey" value
  static member inline dataKey (f: 'a -> string) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline dataKey (f: 'a -> int) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline dataKey (f: 'a -> float) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline dataKey (f: 'a -> string option) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline dataKey (f: 'a -> int option) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline dataKey (f: 'a -> float option) = Interop.mkPolarAngleAxisAttr "dataKey" f
  static member inline cx(value: float) = Interop.mkPolarAngleAxisAttr "cx" value
  static member inline cy(value: float) = Interop.mkPolarAngleAxisAttr "cy" value
  static member inline cx(value: int) = Interop.mkPolarAngleAxisAttr "cx" value
  static member inline cy(value: int) = Interop.mkPolarAngleAxisAttr "cy" value
  static member inline radius(value: float) = Interop.mkPolarAngleAxisAttr "radius" value
  static member inline radius(value: int) = Interop.mkPolarAngleAxisAttr "radius" value
  static member inline axisLine(value: bool) = Interop.mkPolarAngleAxisAttr "axisLine" value
  static member inline tickLine(value: bool) = Interop.mkPolarAngleAxisAttr "tickLine" value
  static member inline tick (tickRenderer : IXAxisTickProperties -> ReactElement) = Interop.mkPolarAngleAxisAttr "tick" tickRenderer
  static member inline tick (value: bool) = Interop.mkPolarAngleAxisAttr "tick" value
  static member inline tick (value: ReactElement) = Interop.mkPolarAngleAxisAttr "tick" value
  static member inline tickFormatter (f: 'a -> int -> string) = Interop.mkPolarAngleAxisAttr "tickFormatter" f
  static member inline allowDuplicatedCategory (value: bool) =  Interop.mkPolarAngleAxisAttr "allowDuplicatedCategory" value

module polarAngleAxis =
    [<Erase>]
    type orient =
        static member inline outer = Interop.mkPolarAngleAxisAttr "orient" "outer"
        static member inline inner = Interop.mkPolarAngleAxisAttr "orient" "inner"

    [<Erase>]
    type axisLineType =
        static member inline circle = Interop.mkPolarAngleAxisAttr "axisLineType" "circle"
        static member inline polygon = Interop.mkPolarAngleAxisAttr "axisLineType" "polygon"

    [<Erase>]
    type type' =
        static member inline number = Interop.mkPolarAngleAxisAttr "type" "number"
        static member inline category = Interop.mkPolarAngleAxisAttr "type" "category"