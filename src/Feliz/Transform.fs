namespace Feliz

open Feliz.Styles
open Fable.Core

/// The transform CSS property lets you rotate, scale, skew, or translate an element.
/// It modifies the coordinate space of the CSS [visual formatting model](https://developer.mozilla.org/en-US/docs/Web/CSS/Visual_formatting_model)
[<Erase>]
type transform =
    /// Defines that there should be no transformation.
    static member inline none = unbox<ITransformProperty> "none"
    /// Defines a 2D transformation, using a matrix of six values.
    static member inline matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
        unbox<ITransformProperty> (
            "matrix(" +
            (unbox<string> x1) + "," +
            (unbox<string> y1) + "," +
            (unbox<string> z1) + "," +
            (unbox<string> x2) + "," +
            (unbox<string> y2) + "," +
            (unbox<string> z2) + ")"
        )

    /// Defines a 2D translation.
    static member inline translate(x: int, y: int) =
        unbox<ITransformProperty> (
            "translate(" + (unbox<string> x) + "px," + (unbox<string> y) + "px)"
        )
    /// Defines a 2D translation.
    static member inline translate(x: float, y: float) =
        unbox<ITransformProperty> (
            "translate(" + (unbox<string> x) + "px," + (unbox<string> y) + "px)"
        )
    /// Defines a 2D translation.
    static member inline translate(x: ICssUnit, y: ICssUnit) =
        unbox<ITransformProperty> (
            "translate(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
        )

    /// Defines a 3D translation.
    static member inline translate3D(x: int, y: int, z: int) =
        unbox<ITransformProperty> (
            "translate3d(" + (unbox<string> x) + "px," + (unbox<string> y) + "px," + (unbox<string> z) + "px)"
        )
    /// Defines a 3D translation.
    static member inline translate3D(x: float, y: float, z: float) =
        unbox<ITransformProperty> (
            "translate3d(" + (unbox<string> x) + "px," + (unbox<string> y) + "px," + (unbox<string> z) + "px)"
        )
    /// Defines a 3D translation.
    static member inline translate3D(x: ICssUnit, y: ICssUnit, z: ICssUnit) =
        unbox<ITransformProperty> (
            "translate3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
        )

    /// Defines a translation, using only the value for the X-axis.
    static member inline translateX(x: int) =
        unbox<ITransformProperty> ("translateX(" + (unbox<string> x) + "px)")
    /// Defines a translation, using only the value for the X-axis.
    static member inline translateX(x: float) =
        unbox<ITransformProperty> ("translateX(" + (unbox<string> x) + "px)")
    /// Defines a translation, using only the value for the X-axis.
    static member inline translateX(x: ICssUnit) =
        unbox<ITransformProperty> ("translateX(" + (unbox<string> x) + ")")
    /// Defines a translation, using only the value for the Y-axis.
    static member inline translateY(y: int) =
        unbox<ITransformProperty> ("translateY(" + (unbox<string> y) + "px)")
    /// Defines a translation, using only the value for the Y-axis.
    static member inline translateY(y: float) =
        unbox<ITransformProperty> ("translateY(" + (unbox<string> y) + "px)")
    /// Defines a translation, using only the value for the Y-axis.
    static member inline translateY(y: ICssUnit) =
        unbox<ITransformProperty> ("translateY(" + (unbox<string> y) + ")")
    /// Defines a 3D translation, using only the value for the Z-axis.
    static member inline translateZ(z: int) =
        unbox<ITransformProperty> ("translateZ(" + (unbox<string> z) + "px)")
    /// Defines a 3D translation, using only the value for the Z-axis.
    static member inline translateZ(z: float) =
        unbox<ITransformProperty> ("translateZ(" + (unbox<string> z) + "px)")
    /// Defines a 3D translation, using only the value for the Z-axis.
    static member inline translateZ(z: ICssUnit) =
        unbox<ITransformProperty> ("translateZ(" + (unbox<string> z) + ")")

    /// Defines a 2D scale transformation.
    static member inline scale(x: int, y: int) =
        unbox<ITransformProperty> (
            "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
        )
    /// Defines a 2D scale transformation.
    static member inline scale(x: float, y: float) =
        unbox<ITransformProperty> (
            "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
        )

    /// Defines a scale transformation.
    static member inline scale(n: int) =
        unbox<ITransformProperty> (
            "scale(" + (unbox<string> n) + ")"
        )

    /// Defines a scale transformation.
    static member inline scale(n: float) =
        unbox<ITransformProperty> (
            "scale(" + (unbox<string> n) + ")"
        )

    /// Defines a 3D scale transformation.
    static member inline scale3D(x: int, y: int, z: int) =
        unbox<ITransformProperty> (
            "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
        )
    /// Defines a 3D scale transformation.
    static member inline scale3D(x: float, y: float, z: float) =
        unbox<ITransformProperty> (
            "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
        )

    /// Defines a scale transformation by giving a value for the X-axis.
    static member inline scaleX(x: int) =
        unbox<ITransformProperty> ("scaleX(" + (unbox<string> x) + ")")

    /// Defines a scale transformation by giving a value for the X-axis.
    static member inline scaleX(x: float) =
        unbox<ITransformProperty> ("scaleX(" + (unbox<string> x) + ")")
    /// Defines a scale transformation by giving a value for the Y-axis.
    static member inline scaleY(y: int) =
        unbox<ITransformProperty> ("scaleY(" + (unbox<string> y) + ")")
    /// Defines a scale transformation by giving a value for the Y-axis.
    static member inline scaleY(y: float) =
        unbox<ITransformProperty> ("scaleY(" + (unbox<string> y) + ")")
    /// Defines a 3D translation, using only the value for the Z-axis.
    static member inline scaleZ(z: int) =
        unbox<ITransformProperty> ("scaleZ(" + (unbox<string> z) + ")")
    /// Defines a 3D translation, using only the value for the Z-axis.
    static member inline scaleZ(z: float) =
        unbox<ITransformProperty> ("scaleZ(" + (unbox<string> z) + ")")
    /// Defines a 2D rotation, the angle is specified in the parameter.
    static member inline rotate(deg: int) =
        unbox<ITransformProperty> ("rotate(" + (unbox<string> deg) + "deg)")
    /// Defines a 2D rotation, the angle is specified in the parameter.
    static member inline rotate(deg: float) =
        unbox<ITransformProperty> ("rotate(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the X-axis.
    static member inline rotateX(deg: float) =
        unbox<ITransformProperty> ("rotateX(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the X-axis.
    static member inline rotateX(deg: int) =
        unbox<ITransformProperty> ("rotateX(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the Y-axis.
    static member inline rotateY(deg: float) =
        unbox<ITransformProperty> ("rotateY(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the Y-axis.
    static member inline rotateY(deg: int) =
        unbox<ITransformProperty> ("rotateY(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the Z-axis.
    static member inline rotateZ(deg: float) =
        unbox<ITransformProperty> ("rotateZ(" + (unbox<string> deg) + "deg)")
    /// Defines a 3D rotation along the Z-axis.
    static member inline rotateZ(deg: int) =
        unbox<ITransformProperty> ("rotateZ(" + (unbox<string> deg) + "deg)")
    /// Defines a 2D skew transformation along the X- and the Y-axis.
    static member inline skew(xAngle: int, yAngle: int) =
        unbox<ITransformProperty> ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
    /// Defines a 2D skew transformation along the X- and the Y-axis.
    static member inline skew(xAngle: float, yAngle: float) =
        unbox<ITransformProperty> ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
    /// Defines a 2D skew transformation along the X-axis.
    static member inline skewX(xAngle: int) =
        unbox<ITransformProperty> ("skewX(" + (unbox<string> xAngle) + "deg)")
    /// Defines a 2D skew transformation along the X-axis.
    static member inline skewX(xAngle: float) =
        unbox<ITransformProperty> ("skewX(" + (unbox<string> xAngle) + "deg)")
    /// Defines a 2D skew transformation along the Y-axis.
    static member inline skewY(xAngle: int) =
        unbox<ITransformProperty> ("skewY(" + (unbox<string> xAngle) + "deg)")
    /// Defines a 2D skew transformation along the Y-axis.
    static member inline skewY(xAngle: float) =
        unbox<ITransformProperty> ("skewY(" + (unbox<string> xAngle) + "deg)")
    /// Defines a perspective view for a 3D transformed element.
    static member inline perspective(n: int) =
        unbox<ITransformProperty> ("perspective(" + (unbox<string> n) + ")")
