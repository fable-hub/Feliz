namespace Feliz

open Fable.Core
open Feliz.Styles

[<Erase>]
type origin =
    static member inline left : ITransformOrigin = unbox "left"
    static member inline center : ITransformOrigin = unbox "center"
    static member inline right : ITransformOrigin = unbox "right"
    static member inline top : ITransformOrigin = unbox "top"
    static member inline bottom : ITransformOrigin = unbox "bottom"

    static member inline percentage (value: int) : ITransformOrigin =
        unbox (unbox<string> value + "%")
    static member inline percentage (value: float) : ITransformOrigin =
        unbox (unbox<string> value + "%") 
