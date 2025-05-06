namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type referenceLine =
    /// The id of x-axis which is corresponding to the data.
    static member inline xAxisId (value: string) = Interop.mkReferenceLineAttr "xAxisId" value
    /// The id of x-axis which is corresponding to the data.
    static member inline xAxisId (value: int) = Interop.mkReferenceLineAttr "xAxisId" value
    /// The id of y-axis which is corresponding to the data.
    static member inline yAxisId (value: string) = Interop.mkReferenceLineAttr "yAxisId" value
    static member inline stroke (color: string) = Interop.mkReferenceLineAttr "stroke" color
    static member inline strokeWidth (width: int) = Interop.mkReferenceLineAttr "strokeWidth" width
    static member inline strokeOpacity (opacity: int) = Interop.mkReferenceLineAttr "strokeOpacity" opacity
    static member inline strokeOpacity (opacity: float) = Interop.mkReferenceLineAttr "strokeOpacity" opacity
    static member inline strokeDasharray([<System.ParamArray>] values: int []) = Interop.mkReferenceLineAttr "strokeDasharray" (values |> Array.map string |> String.concat " ")
    /// The id of y-axis which is corresponding to the data.
    static member inline yAxisId (value: int) = Interop.mkReferenceLineAttr "yAxisId" value
    /// If set a string or a number, a vertical line perpendicular to the x-axis specified by xAxisId will be drawn. If the specified x-axis is a number axis, the type of x must be Number. If the specified x-axis is a category axis, the value of x must be one of the categorys, otherwise no line will be drawn.
    static member inline x(value: string) = Interop.mkReferenceLineAttr "x" value
    /// If set a string or a number, a vertical line perpendicular to the x-axis specified by xAxisId will be drawn. If the specified x-axis is a number axis, the type of x must be Number. If the specified x-axis is a category axis, the value of x must be one of the categorys, otherwise no line will be drawn.
    static member inline x(value: int) = Interop.mkReferenceLineAttr "x" value
    /// If set a string or a number, a vertical line perpendicular to the x-axis specified by xAxisId will be drawn. If the specified x-axis is a number axis, the type of x must be Number. If the specified x-axis is a category axis, the value of x must be one of the categorys, otherwise no line will be drawn.
    static member inline x(value: float) = Interop.mkReferenceLineAttr "x" value
    /// If set a string or a number, a horizontal line perpendicular to the y-axis specified by yAxisId will be drawn. If the specified y-axis is a number axis, the type of y must be Number. If the specified y-axis is a category axis, the value of y must be one of the categorys, otherwise no line will be drawn.
    static member inline y(value: string) = Interop.mkReferenceLineAttr "y" value
    /// If set a string or a number, a horizontal line perpendicular to the y-axis specified by yAxisId will be drawn. If the specified y-axis is a number axis, the type of y must be Number. If the specified y-axis is a category axis, the value of y must be one of the categorys, otherwise no line will be drawn.
    static member inline y(value: int) = Interop.mkReferenceLineAttr "y" value
    /// If set a string or a number, a horizontal line perpendicular to the y-axis specified by yAxisId will be drawn. If the specified y-axis is a number axis, the type of y must be Number. If the specified y-axis is a category axis, the value of y must be one of the categorys, otherwise no line will be drawn.
    static member inline y(value: float) = Interop.mkReferenceLineAttr "y" value
    /// If the corresponding axis is a number axis and this option is set true, the value of reference line will be take into account when calculate the domain of corresponding axis, so that the reference line will always show.
    ///
    /// Default is `false`.
    ///
    /// See example at [A LineChart with alwaysShow ReferenceLine](https://jsfiddle.net/alidingling/uqtuc1mp/)
    static member inline alwaysShow(value: bool) = Interop.mkReferenceLineAttr "alwaysShow" value
    /// If set true, the line will be rendered in front of bars in BarChart, etc.
    ///
    /// Default is `false`.
    static member inline isFront (value: bool) = Interop.mkReferenceLineAttr "isFront" value
    static member inline label(value: string) = Interop.mkReferenceLineAttr "label" value
    static member inline label(value: int) = Interop.mkReferenceLineAttr "label" value
    static member inline label(value: float) = Interop.mkReferenceLineAttr "label" value
    static member inline label(value: ReactElement) = Interop.mkReferenceLineAttr "label" value
    static member inline label(value: ILabelProperties -> ReactElement) = Interop.mkReferenceLineAttr "label" value