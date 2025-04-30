namespace Feliz.Recharts

open Feliz
open Fable.Core

[<Erase>]
type polarRadiusAxis =
    static member inline angle (value:int) = Interop.mkPolarRadiusAxisAttr "angle" value
    static member inline allowDuplicatedCategory (value:bool) = Interop.mkPolarRadiusAxisAttr "allowDuplicatedCategory" value
    static member inline domain (min: IAxisDomain, max: IAxisDomain) = Interop.mkPolarRadiusAxisAttr "domain" [| min; max |]
    static member inline tick (value:bool) = Interop.mkPolarRadiusAxisAttr "tick" value
    static member inline axisLine (value:bool) = Interop.mkPolarRadiusAxisAttr "axisLine" value
    static member inline tickCount (value:int) = Interop.mkPolarRadiusAxisAttr "tickCount" value
    static member inline cx(value: int) = Interop.mkPolarRadiusAxisAttr "cx" value
    static member inline cy(value: int) = Interop.mkPolarRadiusAxisAttr "cy" value
    static member inline tickFormatter (f: 'a -> int -> string) = Interop.mkPolarRadiusAxisAttr "tickFormatter" f

module polarRadiusAxis =
    [<Erase>]
    type type' =
        static member inline number = Interop.mkPolarRadiusAxisAttr "type" "number"
        static member inline category = Interop.mkPolarRadiusAxisAttr "type" "category"

    [<Erase>]
    type orientation =
        static member inline left = Interop.mkPolarRadiusAxisAttr "orientation" "left"
        static member inline right = Interop.mkPolarRadiusAxisAttr "orientation" "right"
        static member inline middle = Interop.mkPolarRadiusAxisAttr "orientation" "middle"

    [<Erase>]
    type scale =
        static member inline auto = Interop.mkPolarRadiusAxisAttr "scale" "auto"
        static member inline linear = Interop.mkPolarRadiusAxisAttr "scale" "linear"
        static member inline pow = Interop.mkPolarRadiusAxisAttr "scale" "pow"
        static member inline sqrt = Interop.mkPolarRadiusAxisAttr "scale" "sqrt"
        static member inline log = Interop.mkPolarRadiusAxisAttr "scale" "log"
        static member inline identity = Interop.mkPolarRadiusAxisAttr "scale" "identity"
        static member inline time = Interop.mkPolarRadiusAxisAttr "scale" "time"
        static member inline band = Interop.mkPolarRadiusAxisAttr "scale" "band"
        static member inline point = Interop.mkPolarRadiusAxisAttr "scale" "point"
        static member inline ordinal = Interop.mkPolarRadiusAxisAttr "scale" "ordinal"
        static member inline quantile = Interop.mkPolarRadiusAxisAttr "scale" "quantile"
        static member inline quantize = Interop.mkPolarRadiusAxisAttr "scale" "quantize"
        static member inline utc = Interop.mkPolarRadiusAxisAttr "scale" "utc"
        static member inline sequential = Interop.mkPolarRadiusAxisAttr "scale" "sequential"
        static member inline threshold = Interop.mkPolarRadiusAxisAttr "scale" "threshold"