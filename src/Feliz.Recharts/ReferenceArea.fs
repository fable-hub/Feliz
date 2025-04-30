namespace Feliz.Recharts


open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type referenceArea =
    /// The id of x-axis which is corresponding to the data.
    static member inline xAxisId (value: string) = Interop.mkReferenceAreaAttr "xAxisId" value
    /// The id of x-axis which is corresponding to the data.
    static member inline xAxisId (value: int) = Interop.mkReferenceAreaAttr "xAxisId" value
    /// The id of y-axis which is corresponding to the data.
    static member inline yAxisId (value: string) = Interop.mkReferenceAreaAttr "yAxisId" value
    static member inline stroke (value: string) = Interop.mkReferenceAreaAttr "stroke" value
    static member inline strokeOpacity (value: int) = Interop.mkReferenceAreaAttr "strokeOpacity" value
    static member inline strokeOpacity (value: float) = Interop.mkReferenceAreaAttr "strokeOpacity" value
    static member inline fill (value: string) = Interop.mkReferenceAreaAttr "fill" value
    static member inline fillOpacity (value: int) = Interop.mkReferenceAreaAttr "fillOpacity" value
    static member inline fillOpacity (value: float) = Interop.mkReferenceAreaAttr "fillOpacity" value
    /// The id of y-axis which is corresponding to the data.
    static member inline yAxisId (value: int) = Interop.mkReferenceAreaAttr "yAxisId" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x1 (value: int) = Interop.mkReferenceAreaAttr "x1" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x1 (value: float) = Interop.mkReferenceAreaAttr "x1" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x1 (value: string) = Interop.mkReferenceAreaAttr "x1" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x2 (value: int) = Interop.mkReferenceAreaAttr "x2" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x2 (value: float) = Interop.mkReferenceAreaAttr "x2" value
    /// A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number.
    /// If the specified x-axis is a category axis, the value of x must be one of the categorys.
    /// If one of x1 or x2 is invalidate, the area will cover along x-axis.
    static member inline x2 (value: string) = Interop.mkReferenceAreaAttr "x2" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y1 (value: int) = Interop.mkReferenceAreaAttr "y1" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y1 (value: float) = Interop.mkReferenceAreaAttr "y1" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y1 (value: string) = Interop.mkReferenceAreaAttr "y1" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y2 (value: int) = Interop.mkReferenceAreaAttr "y2" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y2 (value: float) = Interop.mkReferenceAreaAttr "y2" value
    /// A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number.
    /// If the specified y-axis is a category axis, the value of y must be one of the categorys.
    /// If one of y1 or y2 is invalidate, the area will cover along y-axis.
    static member inline y2 (value: string) = Interop.mkReferenceAreaAttr "y2" value
    static member inline alwaysShow (value: bool) = Interop.mkReferenceAreaAttr "alwaysShow" value
    static member inline inFront (value: bool) = Interop.mkReferenceAreaAttr "inFront" value
    static member inline label (value: string) = Interop.mkReferenceAreaAttr "label" value
    static member inline label (value: int) = Interop.mkReferenceAreaAttr "label" value
    static member inline label (value: float) = Interop.mkReferenceAreaAttr "label" value
