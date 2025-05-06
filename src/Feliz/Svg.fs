namespace Feliz

open Browser.Types
open Fable.Core
open Feliz.Styles

type Svg =
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image xs = Interop.createSvgElement "image" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image (children: #seq<ReactElement>) = Interop.reactElementWithChildren "image" children
    /// The svg element is a container that defines a new coordinate system and viewport. It is used as the outermost element of SVG documents, but it can also be used to embed an SVG fragment inside an SVG or HTML document.
    static member inline svg xs = Interop.createSvgElement "svg" xs
    /// The svg element is a container that defines a new coordinate system and viewport. It is used as the outermost element of SVG documents, but it can also be used to embed an SVG fragment inside an SVG or HTML document.
    static member inline svg (children: #seq<ReactElement>) = Interop.reactElementWithChildren "svg" children
    static member inline circle xs = Interop.createSvgElement "circle" xs
    static member inline circle (children: #seq<ReactElement>) = Interop.reactElementWithChildren "circle" children
    static member inline clipPath xs = Interop.createSvgElement "clipPath" xs
    static member inline clipPath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "clipPath" children
    /// The <defs> element is used to store graphical objects that will be used at a later time. Objects created inside a <defs> element are not rendered directly. To display them you have to reference them (with a <use> element for example). https://developer.mozilla.org/en-US/docs/Web/SVG/Element/defs
    static member inline defs xs = Interop.createSvgElement "defs" xs
    /// The <defs> element is used to store graphical objects that will be used at a later time. Objects created inside a <defs> element are not rendered directly. To display them you have to reference them (with a <use> element for example). https://developer.mozilla.org/en-US/docs/Web/SVG/Element/defs
    static member inline defs (children: #seq<ReactElement>) = Interop.reactElementWithChildren "defs" children
    /// The <desc> element provides an accessible, long-text description of any SVG container element or graphics element.
    static member inline desc xs = Interop.createSvgElement "desc" xs
    /// The <desc> element provides an accessible, long-text description of any SVG container element or graphics element.
    static member inline desc (value: string) = Interop.reactElementWithChild "desc" value
    static member inline ellipse xs = Interop.createSvgElement "ellipse" xs
    static member inline ellipse (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ellipse" children
    static member inline feBlend xs = Interop.createSvgElement "feBlend" xs
    static member inline feBlend (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feBlend" children
    static member inline feColorMatrix xs = Interop.createSvgElement "feColorMatrix" xs
    static member inline feColorMatrix (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feColorMatrix" children
    static member inline feComponentTransfer xs = Interop.createSvgElement "feComponentTransfer" xs
    static member inline feComponentTransfer (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feComponentTransfer" children
    static member inline feComposite xs = Interop.createSvgElement "feComposite" xs
    static member inline feComposite (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feComposite" children
    static member inline feConvolveMatrix xs = Interop.createSvgElement "feConvolveMatrix" xs
    static member inline feConvolveMatrix (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feConvolveMatrix" children
    static member inline feDiffuseLighting xs = Interop.createSvgElement "feDiffuseLighting" xs
    static member inline feDiffuseLighting (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDiffuseLighting" children
    static member inline feDisplacementMap xs = Interop.createSvgElement "feDisplacementMap" xs
    static member inline feDisplacementMap (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDisplacementMap" children
    static member inline feDistantLight xs = Interop.createSvgElement "feDistantLight" xs
    static member inline feDistantLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDistantLight" children
    static member inline feDropShadow xs = Interop.createSvgElement "feDropShadow" xs
    static member inline feDropShadow (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDropShadow" children
    static member inline feFlood xs = Interop.createSvgElement "feFlood" xs
    static member inline feFlood (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFlood" children
    static member inline feFuncA xs = Interop.createSvgElement "feFuncA" xs
    static member inline feFuncA (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncA" children
    static member inline feFuncB xs = Interop.createSvgElement "feFuncB" xs
    static member inline feFuncB (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncB" children
    static member inline feFuncG xs = Interop.createSvgElement "feFuncG" xs
    static member inline feFuncG (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncG" children
    static member inline feFuncR xs = Interop.createSvgElement "feFuncR" xs
    static member inline feFuncR (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncR" children
    static member inline feGaussianBlur xs = Interop.createSvgElement "feGaussianBlur" xs
    static member inline feGaussianBlur (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feGaussianBlur" children
    static member inline feImage xs = Interop.createSvgElement "feImage" xs
    static member inline feImage (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feImage" children
    static member inline feMerge xs = Interop.createSvgElement "feMerge" xs
    static member inline feMerge (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMerge" children
    static member inline feMergeNode xs = Interop.createSvgElement "feMergeNode" xs
    static member inline feMergeNode (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMergeNode" children
    static member inline feMorphology xs = Interop.createSvgElement "feMorphology" xs
    static member inline feMorphology (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMorphology" children
    static member inline feOffset xs = Interop.createSvgElement "feOffset" xs
    static member inline feOffset (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feOffset" children
    static member inline fePointLight xs = Interop.createSvgElement "fePointLight" xs
    static member inline fePointLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "fePointLight" children
    static member inline feSpecularLighting xs = Interop.createSvgElement "feSpecularLighting" xs
    static member inline feSpecularLighting (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feSpecularLighting" children
    static member inline feSpotLight xs = Interop.createSvgElement "feSpotLight" xs
    static member inline feSpotLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feSpotLight" children
    static member inline feTile xs = Interop.createSvgElement "feTile" xs
    static member inline feTile (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feTile" children
    static member inline feTurbulence xs = Interop.createSvgElement "feTurbulence" xs
    static member inline feTurbulence (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feTurbulence" children
    static member inline filter xs = Interop.createSvgElement "filter" xs
    static member inline filter (children: #seq<ReactElement>) = Interop.reactElementWithChildren "filter" children
    static member inline foreignObject xs = Interop.createSvgElement "foreignObject" xs
    static member inline foreignObject (children: #seq<ReactElement>) = Interop.reactElementWithChildren "foreignObject" children
    /// The <g> SVG element is a container used to group other SVG elements.
    ///
    /// Transformations applied to the <g> element are performed on its child elements, and its attributes are inherited by its children. It can also group multiple elements to be referenced later with the <use> element.
    static member inline g xs = Interop.createSvgElement "g" xs
    /// The <g> SVG element is a container used to group other SVG elements.
    ///
    /// Transformations applied to the <g> element are performed on its child elements, and its attributes are inherited by its children. It can also group multiple elements to be referenced later with the <use> element.
    static member inline g (children: #seq<ReactElement>) = Interop.reactElementWithChildren "g" children
    static member inline line xs = Interop.createSvgElement "line" xs
    static member inline line (children: #seq<ReactElement>) = Interop.reactElementWithChildren "line" children
    static member inline linearGradient xs = Interop.createSvgElement "linearGradient" xs
    static member inline linearGradient (children: #seq<ReactElement>) = Interop.reactElementWithChildren "linearGradient" children
    /// The <marker> element defines the graphic that is to be used for drawing arrowheads or polymarkers on a given <path>, <line>, <polyline> or <polygon> element.
    static member inline marker xs = Interop.createSvgElement "marker" xs
    /// The <marker> element defines the graphic that is to be used for drawing arrowheads or polymarkers on a given <path>, <line>, <polyline> or <polygon> element.
    static member inline marker (children: #seq<ReactElement>) = Interop.reactElementWithChildren "marker" children
    /// The <mask> element defines an alpha mask for compositing the current object into the background. A mask is used/referenced using the mask attribute.
    static member inline mask xs = Interop.createSvgElement "mask" xs
    /// The <mask> element defines an alpha mask for compositing the current object into the background. A mask is used/referenced using the mask attribute.
    static member inline mask (children: #seq<ReactElement>) = Interop.reactElementWithChildren "mask" children
    static member inline mpath xs = Interop.createSvgElement "mpath" xs
    static member inline mpath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "mpath" children
    static member inline path xs = Interop.createSvgElement "path" xs
    static member inline path (children: #seq<ReactElement>) = Interop.reactElementWithChildren "path" children
    static member inline pattern xs = Interop.createSvgElement "pattern" xs
    static member inline pattern (children: #seq<ReactElement>) = Interop.reactElementWithChildren "pattern" children
    static member inline polygon xs = Interop.createSvgElement "polygon" xs
    static member inline polygon (children: #seq<ReactElement>) = Interop.reactElementWithChildren "polygon" children
    static member inline polyline xs = Interop.createSvgElement "polyline" xs
    static member inline polyline (children: #seq<ReactElement>) = Interop.reactElementWithChildren "polyline" children
    static member inline set xs = Interop.createSvgElement "set" xs
    static member inline set (children: #seq<ReactElement>) = Interop.reactElementWithChildren "set" children
    static member inline stop xs = Interop.createSvgElement "stop" xs
    static member inline stop (children: #seq<ReactElement>) = Interop.reactElementWithChildren "stop" children
    static member inline style xs = Interop.createSvgElement "style" xs
    static member inline style (value: string) = Interop.reactElementWithChild "style" value
    static member inline switch xs = Interop.createSvgElement "switch" xs
    static member inline switch (children: #seq<ReactElement>) = Interop.reactElementWithChildren "switch" children
    static member inline symbol xs = Interop.createSvgElement "symbol" xs
    static member inline symbol (children: #seq<ReactElement>) = Interop.reactElementWithChildren "symbol" children
    static member inline text xs = Interop.createSvgElement "text" xs
    static member inline text (content: string) = Interop.reactElementWithChild "text" content
    static member inline title xs = Interop.createSvgElement "title" xs
    static member inline title (content: string) = Interop.reactElementWithChild "title" content
    static member inline textPath xs = Interop.createSvgElement "textPath" xs
    static member inline textPath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "textPath" children
    static member inline tspan xs = Interop.createSvgElement "tspan" xs
    static member inline tspan (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tspan" children
    static member inline use' xs = Interop.createSvgElement "use" xs
    static member inline use' (children: #seq<ReactElement>) = Interop.reactElementWithChildren "use" children
    static member inline radialGradient xs = Interop.createSvgElement "radialGradient" xs
    static member inline radialGradient (children: #seq<ReactElement>) = Interop.reactElementWithChildren "radialGradient" children
    static member inline rect xs = Interop.createSvgElement "rect" xs
    static member inline rect (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rect" children
    static member inline view xs = Interop.createSvgElement "view" xs
    static member inline view (children: #seq<ReactElement>) = Interop.reactElementWithChildren "view" children

type svg =
        /// Specifies a CSS class for this element.
    static member inline className (value: string) = Interop.svgAttribute "className" value
    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `svg.className [ "one"; "two" ]`
    ///
    /// is the same as
    ///
    /// `svg.className "one two"`
    static member inline className (names: seq<string>) = Interop.svgAttribute "className" (String.concat " " names)

    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `svg.classes [ "one"; "two" ]` => `svg.className "one two"`
    static member inline classes (names: seq<string>) = Interop.svgAttribute "className" (String.concat " " names)
    static member inline id (value: string) = Interop.svgAttribute "id" value
    /// Defines the number of octaves for the noise function of the <feTurbulence> primitive.
    static member inline numOctaves (value: int) = Interop.svgAttribute "numOctaves" value

    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: float) = Interop.svgAttribute "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: ICssUnit) = Interop.svgAttribute "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: int) = Interop.svgAttribute "offset" value
    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: float) = Interop.svgAttribute "amplitude" value
    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: int) = Interop.svgAttribute "amplitude" value
    /// Indicates the name of the CSS property or attribute of the target element
    /// that is going to be changed during an animation.
    static member inline attributeName (value: string) = Interop.svgAttribute "attributeName" value
    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: float) = Interop.svgAttribute "azimuth" value
    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: int) = Interop.svgAttribute "azimuth" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: float) = Interop.svgAttribute "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: int) = Interop.svgAttribute "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: float) = Interop.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: int) = Interop.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: float) = Interop.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: int) = Interop.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    static member inline children (elements: ReactElement list) = prop.children elements |> unbox<ISvgAttribute>
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: float) = Interop.svgAttribute "cx" value
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: int) = Interop.svgAttribute "cx" value
    static member inline x (value: float) = Interop.svgAttribute "x" value
    static member inline x (value: int) = Interop.svgAttribute "x" value
    static member inline x1 (value: float) = Interop.svgAttribute "x1" value
    static member inline x1 (value: int) = Interop.svgAttribute "x1" value
    static member inline x2 (value: float) = Interop.svgAttribute "x2" value
    static member inline x2 (value: int) = Interop.svgAttribute "x2" value
    static member inline y (value: float) = Interop.svgAttribute "y" value
    static member inline y (value: int) = Interop.svgAttribute "y" value
    static member inline y1 (value: float) = Interop.svgAttribute "y1" value
    static member inline y1 (value: int) = Interop.svgAttribute "y1" value
    static member inline y2 (value: float) = Interop.svgAttribute "y2" value
    static member inline y2 (value: int) = Interop.svgAttribute "y2" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: float) = Interop.svgAttribute "cy" value
    /// The clip-path presentation attribute defines or associates a clipping path with the element it is related to.
    static member inline clipPath(value: string) = Interop.svgAttribute "clipPath" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: int) = Interop.svgAttribute "cy" value
    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: float) = Interop.svgAttribute "dx" value
    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: int) = Interop.svgAttribute "dx" value

    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: float) = Interop.svgAttribute "dy" value
    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: int) = Interop.svgAttribute "dy" value
    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> Interop.svgAttribute "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> Interop.svgAttribute "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: string) = Interop.svgAttribute "d" path

    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: float) = Interop.svgAttribute "diffuseConstant" value
    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: int) = Interop.svgAttribute "diffuseConstant" value
    /// The display attribute lets you control the rendering of graphical or container elements.
    static member inline display (value: string) = Interop.svgAttribute "display" value
    /// The divisor attribute specifies the value by which the resulting number of applying the kernelMatrix of a <feConvolveMatrix> element to the input image color value is divided to yield the destination color value. A divisor that is the sum of all the matrix values tends to have an evening effect on the overall color intensity of the result.
    static member inline divisor (value: float) = Interop.svgAttribute "divisor" value
    /// The divisor attribute specifies the value by which the resulting number of applying the kernelMatrix of a <feConvolveMatrix> element to the input image color value is divided to yield the destination color value. A divisor that is the sum of all the matrix values tends to have an evening effect on the overall color intensity of the result.
    static member inline divisor (value: int) = Interop.svgAttribute "divisor" value
    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: float) = Interop.svgAttribute "elevation" value
    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: int) = Interop.svgAttribute "elevation" value
    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (value: string) = Interop.svgAttribute "end" value
    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (values: seq<string>) = Interop.svgAttribute "end" (String.concat ";" values)

    /// Defines the exponent of the gamma function.
    static member inline exponent (value: float) = Interop.svgAttribute "exponent" value
    /// Defines the exponent of the gamma function.
    static member inline exponent (value: int) = Interop.svgAttribute "exponent" value
    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: float) = Interop.svgAttribute "fillOpacity" value
    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: int) = Interop.svgAttribute "fillOpacity" value

    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: float) = Interop.svgAttribute "fontSize" value
    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: int) = Interop.svgAttribute "fontSize" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: float) = Interop.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<float>) = Interop.svgAttribute "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: int) = Interop.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<int>) = Interop.svgAttribute "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: string) = Interop.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<string>) = Interop.svgAttribute "from" (values |> String.concat " ")

    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: float) = Interop.svgAttribute "fr" value
    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: int) = Interop.svgAttribute "fr" value

    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: float) = Interop.svgAttribute "fx" value
    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: int) = Interop.svgAttribute "fx" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: float) = Interop.svgAttribute "fy" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: int) = Interop.svgAttribute "fy" value
    /// Sets the color of an SVG shape.
    static member inline fill (color: string) = Interop.svgAttribute "fill" color
    /// Defines an optional additional transformation from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transform: ITransformProperty) =
        Interop.svgAttribute "gradientTransform" (unbox<string> transform)
    /// Defines optional additional transformation(s) from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transforms: seq<ITransformProperty>) =
        Interop.svgAttribute "gradientTransform" (unbox<seq<string>> transforms |> String.concat " ")

    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: float) = Interop.svgAttribute "height" value
    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: int) = Interop.svgAttribute "height" value
    /// Defines the position and dimension, in user space, of an SVG viewport.
    static member inline viewBox (minX: int, minY: int, width: int, height: int) =
        Interop.svgAttribute "viewBox" (
            (unbox<string> minX) + " " +
            (unbox<string> minY) + " " +
            (unbox<string> width) + " " +
            (unbox<string> height)
        )

    /// Set visible area of the SVG image.
    static member inline viewPort (x: int, y: int, height: int, width: int) =
        Interop.svgAttribute "viewport" (
            (unbox<string> x) + " " +
            (unbox<string> y) + " " +
            (unbox<string> height) + " " +
            (unbox<string> width)
        )

    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: float) = Interop.svgAttribute "markerHeight" value
    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: int) = Interop.svgAttribute "markerHeight" value
    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: ICssUnit) = Interop.svgAttribute "markerHeight" value
    
    /// The mask presentation attribute binds a given <mask> element applying it to the element the attribute belongs to.
    static member inline mask (value: string) = Interop.svgAttribute "mask" value

    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: float) = Interop.svgAttribute "markerWidth" value
    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: int) = Interop.svgAttribute "markerWidth" value
    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: ICssUnit) = Interop.svgAttribute "markerWidth" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: float) = Interop.svgAttribute "width" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: int) = Interop.svgAttribute "width" value
    /// The URL of a linked resource.
    static member inline href (value: string) = Interop.svgAttribute "href" value
    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: float) = Interop.svgAttribute "intercept" value
    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: int) = Interop.svgAttribute "intercept" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: float) = Interop.svgAttribute "k1" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: int) = Interop.svgAttribute "k1" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: float) = Interop.svgAttribute "k2" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: int) = Interop.svgAttribute "k2" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: float) = Interop.svgAttribute "k3" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: int) = Interop.svgAttribute "k3" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: float) = Interop.svgAttribute "k4" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: int) = Interop.svgAttribute "k4" value

    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<float>) = Interop.svgAttribute "kernelMatrix" (values |> unbox<seq<string>> |> String.concat " ")
    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<int>) = Interop.svgAttribute "kernelMatrix" (values |> unbox<seq<string>>  |> String.concat " ")
    /// Fires when a media event is aborted.
    static member inline onAbort (handler: Event -> unit) = Interop.svgAttribute "onAbort" handler
    /// Fires when animation is aborted.
    static member inline onAnimationCancel (handler: AnimationEvent -> unit) = Interop.svgAttribute "onAnimationCancel" handler
    /// Fires when animation ends.
    static member inline onAnimationEnd (handler: AnimationEvent -> unit) = Interop.svgAttribute "onAnimationEnd" handler
    /// Fires when animation iterates.
    static member inline onAnimationIteration (handler: AnimationEvent -> unit) = Interop.svgAttribute "onAnimationIteration" handler
    /// Fires the moment that the element loses focus.
    static member inline onBlur (handler: FocusEvent -> unit) = Interop.svgAttribute "onBlur" handler
    /// Fires when a user dismisses the current open dialog
    static member inline onCancel (handler: Event -> unit) = Interop.svgAttribute "onCancel" handler
    /// Fires when a file is ready to start playing (when it has buffered enough to begin).
    static member inline onCanPlay (handler: Event -> unit) = Interop.svgAttribute "onCanPlay" handler
    /// Fires when a file can be played all the way to the end without pausing for buffering
    static member inline onCanPlayThrough (handler: Event -> unit) = Interop.svgAttribute "onCanPlayThrough" handler
    /// Fires the moment when the value of the element is changed
    static member inline onChange (handler: Event -> unit) = Interop.svgAttribute "onChange" handler
    /// Fires on a mouse click on the element.
    static member inline onClick (handler: MouseEvent -> unit) = Interop.svgAttribute "onClick" handler
    /// Fires when a context menu is triggered.
    static member inline onContextMenu (handler: MouseEvent -> unit) = Interop.svgAttribute "onContextMenu" handler
    /// Fires when a TextTrack has changed the currently displaying cues.
    static member inline onCueChange (handler: Event -> unit) = Interop.svgAttribute "onCueChange" handler
    /// Fires when a mouse is double clicked on the element.
    static member inline onDblClick (handler: MouseEvent -> unit) = Interop.svgAttribute "onDblClick" handler
    /// Fires when the length of the media changes.
    static member inline onDurationChange (handler: Event -> unit) = Interop.svgAttribute "onDurationChange" handler
    /// Fires when the media has reached the end (a useful event for messages like "thanks for listening").
    static member inline onEnded (handler: Event -> unit) = Interop.svgAttribute "onEnded" handler
    /// Fires when an error occurs.
    static member inline onError (handler: Event -> unit) = Interop.svgAttribute "onError" handler
    /// Fires when an error occurs.
    static member inline onError (handler: UIEvent -> unit) = Interop.svgAttribute "onError" handler
    /// Fires the moment when the element gets focus.
    static member inline onFocus (handler: FocusEvent -> unit) = Interop.svgAttribute "onFocus" handler
    /// Fires when an element captures a pointer.
    static member inline onGotPointerCapture (handler: PointerEvent -> unit) = Interop.svgAttribute "onGotPointerCapture" handler
    /// Fires when an element gets user input.
    static member inline onInput (handler: Event -> unit) = Interop.svgAttribute "onInput" handler
    /// Fires when a submittable element has been checked for validaty and doesn't satisfy its constraints.
    static member inline onInvalid (handler: Event -> unit) = Interop.svgAttribute "onInvalid" handler
    /// Fires when a user presses a key.
    static member inline onKeyDown (handler: KeyboardEvent -> unit) = Interop.svgAttribute "onKeyDown" handler
    /// Fires when a user presses a key.
    static member inline onKeyDown (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> Interop.svgAttribute "onKeyDown"
    /// Fires when a user presses a key.
    static member inline onKeyPress (handler: KeyboardEvent -> unit) = Interop.svgAttribute "onKeyPress" handler
    /// Fires when a user presses a key.
    static member inline onKeyPress (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> Interop.svgAttribute "onKeyPress"
    /// Fires when a user releases a key.
    static member inline onKeyUp (handler: KeyboardEvent -> unit) = Interop.svgAttribute "onKeyUp" handler
    /// Fires when a user releases a key.
    static member inline onKeyUp (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> Interop.svgAttribute "onKeyUp"
    /// Fires after the page is finished loading.
    static member inline onLoad (handler: Event -> unit) = Interop.svgAttribute "onLoad" handler
    /// Fires when media data is loaded.
    static member inline onLoadedData (handler: Event -> unit) = Interop.svgAttribute "onLoadedData" handler
    /// Fires when meta data (like dimensions and duration) are loaded.
    static member inline onLoadedMetadata (handler: Event -> unit) = Interop.svgAttribute "onLoadedMetadata" handler
    /// Fires when a request has completed, irrespective of its success.
    static member inline onLoadEnd (handler: Event -> unit) = Interop.svgAttribute "onLoadEnd" handler
    /// Fires when the resource begins to load before anything is actually loaded.
    static member inline onLoadStart (handler: Event -> unit) = Interop.svgAttribute "onLoadStart" handler
    /// Fires when a captured pointer is released.
    static member inline onLostPointerCapture (handler: PointerEvent -> unit) = Interop.svgAttribute "onLostPointerCapture" handler
    /// Fires when a mouse button is pressed down on an element.
    static member inline onMouseDown (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseDown" handler
    /// Fires when a pointer enters an element.
    static member inline onMouseEnter (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseEnter" handler
    /// Fires when a pointer leaves an element.
    static member inline onMouseLeave (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseLeave" handler
    /// Fires when the mouse pointer is moving while it is over an element.
    static member inline onMouseMove (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseMove" handler
    /// Fires when the mouse pointer moves out of an element.
    static member inline onMouseOut (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseOut" handler
    /// Fires when the mouse pointer moves over an element.
    static member inline onMouseOver (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseOver" handler
    /// Fires when a mouse button is released while it is over an element.
    static member inline onMouseUp (handler: MouseEvent -> unit) = Interop.svgAttribute "onMouseUp" handler
    /// Fires when the media is paused either by the user or programmatically.
    static member inline onPause (handler: Event -> unit) = Interop.svgAttribute "onPause" handler
    /// Fires when the media is ready to start playing.
    static member inline onPlay (handler: Event -> unit) = Interop.svgAttribute "onPlay" handler
    /// Fires when the media actually has started playing
    static member inline onPlaying (handler: Event -> unit) = Interop.svgAttribute "onPlaying" handler
    /// Fires when there are no more pointer events.
    static member inline onPointerCancel (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerCancel" handler
    /// Fires when a pointer becomes active.
    static member inline onPointerDown (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerDown" handler
    /// Fires when a pointer is moved into an elements boundaries or one of its descendants.
    static member inline onPointerEnter (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerEnter" handler
    /// Fires when a pointer is moved out of an elements boundaries.
    static member inline onPointerLeave (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerLeave" handler
    /// Fires when a pointer moves.
    static member inline onPointerMove (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerMove" handler
    /// Fires when a pointer is no longer in an elements boundaries, such as moving it, or after a `pointerUp` or `pointerCancel` event.
    static member inline onPointerOut (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerOut" handler
    /// Fires when a pointer is moved into an elements boundaries.
    static member inline onPointerOver (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerOver" handler
    /// Fires when a pointer is no longer active.
    static member inline onPointerUp (handler: PointerEvent -> unit) = Interop.svgAttribute "onPointerUp" handler
    /// Fires when the Reset button in a form is clicked.
    static member inline onReset (handler: Event -> unit) = Interop.svgAttribute "onReset" handler
    /// Fires when the window has been resized.
    static member inline onResize (handler: UIEvent -> unit) = Interop.svgAttribute "onResize" handler
    /// Fires when an element's scrollbar is being scrolled.
    static member inline onScroll (handler: Event -> unit) = Interop.svgAttribute "onScroll" handler
    /// Fires after some text has been selected in an element.
    static member inline onSelect (handler: Event -> unit) = Interop.svgAttribute "onSelect" handler
    /// Fires after some text has been selected in the user interface.
    static member inline onSelect (handler: UIEvent -> unit) = Interop.svgAttribute "onSelect" handler
    /// Fires when a form is submitted.
    static member inline onSubmit (handler: Event -> unit) = Interop.svgAttribute "onSubmit" handler
    /// Fires when the mouse wheel rolls up or down over an element.
    static member inline onWheel (handler: WheelEvent -> unit) = Interop.svgAttribute "onWheel" handler
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<float * float>) =
        PropHelpers.createPointsFloat(coordinates)
        |> Interop.svgAttribute "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<int * int>) =
        PropHelpers.createPointsInt(coordinates)
        |> Interop.svgAttribute "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: string) = Interop.svgAttribute "points" coordinates

    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: float) = Interop.svgAttribute "pointsAtX" value
    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: int) = Interop.svgAttribute "pointsAtX" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: float) = Interop.svgAttribute "pointsAtY" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: int) = Interop.svgAttribute "pointsAtY" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: float) = Interop.svgAttribute "pointsAtZ" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: int) = Interop.svgAttribute "pointsAtZ" value

    /// Indicates how a <feConvolveMatrix> element handles alpha transparency.
    static member inline preserveAlpha (value: bool) = Interop.svgAttribute "preserveAlpha" value

    /// A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing
    /// is displayed until the first frame is available, then the first frame is shown as the poster frame.
    static member inline poster (value: string) = Interop.svgAttribute "poster" value

    /// SVG attribute to define the radius of a circle.
    static member inline r (value: float) = Interop.svgAttribute "r" value
    /// SVG attribute to define the radius of a circle.
    static member inline r (value: int) = Interop.svgAttribute "r" value

    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: float) = Interop.svgAttribute "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: int) = Interop.svgAttribute "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: float) = Interop.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: int) = Interop.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: float) = Interop.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: int) = Interop.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: float) = Interop.svgAttribute "overlinePosition" value
    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: int) = Interop.svgAttribute "overlinePosition" value

    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: float) = Interop.svgAttribute "overlineThickness" value
    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: int) = Interop.svgAttribute "overlineThickness" value

    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> Interop.svgAttribute "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> Interop.svgAttribute "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: string) = Interop.svgAttribute "path" path

    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: float) = Interop.svgAttribute "rx" value
    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: int) = Interop.svgAttribute "rx" value

    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: float) = Interop.svgAttribute "ry" value
    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: int) = Interop.svgAttribute "ry" value
    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: float) = Interop.svgAttribute "scale" value
    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: int) = Interop.svgAttribute "scale" value

    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: float) = Interop.svgAttribute "seed" value
    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: int) = Interop.svgAttribute "seed" value
    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: float) = Interop.svgAttribute "specularConstant" value
    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: int) = Interop.svgAttribute "specularConstant" value

    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: float) = Interop.svgAttribute "specularExponent" value
    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: int) = Interop.svgAttribute "specularExponent" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: float) = Interop.svgAttribute "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: int) = Interop.svgAttribute "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: float) = Interop.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: int) = Interop.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: float) = Interop.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: int) = Interop.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: float) = Interop.svgAttribute "stopOpacity" value
    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: int) = Interop.svgAttribute "stopOpacity" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: float) = Interop.svgAttribute "strikethroughPosition" value
    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: int) = Interop.svgAttribute "strikethroughPosition" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: float) = Interop.svgAttribute "strikethroughThickness" value
    /// Represents the ideal thickness of the strikethrough.
    ///
    /// The strikethrough thickness is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: int) = Interop.svgAttribute "strikethroughThickness" value

    /// SVG attribute to define the color (or any SVG paint servers like gradients or patterns) used to paint the outline of the shape.
    static member inline stroke (color: string) = Interop.svgAttribute "stroke" color
    
    /// SVG attribute to define the pattern of dashes and gaps used to paint the outline of the shape.
    static member inline strokeDasharray (value: int array) = Interop.svgAttribute "strokeDasharray" value

    /// SVG attribute to define the offset on the rendering of the associated dash array.
    static member inline strokeDashoffset (value: int) = Interop.svgAttribute "strokeDashoffset" value

    /// SVG attribute to define the  an offset on the rendering of the associated dash array
    static member inline strokeDashoffset (value: float) = Interop.svgAttribute "strokeDashoffset" value

    /// SVG attribute to define the shape to be used at the end of open subpaths when they are stroked.
    static member inline strokeLineCap (value: string) = Interop.svgAttribute "strokeLinecap" value

    /// SVG attribute to define the shape to be used at the end of open subpaths when they are stroked.
    static member inline strokeLineJoin (value: string) = Interop.svgAttribute "strokeLinejoin" value

    /// SVG attribute to define a limit on the ratio of the miter length to the stroke-width used to draw a miter join. 
    /// When the limit is exceeded, the join is converted from a miter to a bevel.
    static member inline strokeMitterLimit (value: int) = Interop.svgAttribute "strokeMiterlimit" value

    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: float) = Interop.svgAttribute "strokeWidth" value

    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: int) = Interop.svgAttribute "strokeWidth" value

    /// SVG attribute to define the opacity of the stroke to be applied to the shape.
    static member inline strokeOpacity (value: float) = Interop.svgAttribute "strokeOpacity" value

    /// SVG attribute to define the opacity of the stroke to be applied to the shape.
    static member inline strokeOpacity (value: int) = Interop.svgAttribute "strokeOpacity" value

    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: float) = Interop.svgAttribute "surfaceScale" value

    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: int) = Interop.svgAttribute "surfaceScale" value

    /// Represents a list of supported language tags.
    ///
    /// This list is matched against the language defined in the user preferences.
    static member inline systemLanguage (value: string) = Interop.svgAttribute "systemLanguage" value

    /// The `tabindex` global attribute indicates that its element can be focused,
    /// and where it participates in sequential keyboard navigation (usually with the Tab key, hence the name).
    static member inline tabIndex (index: int) = Interop.svgAttribute "tabIndex" index

    /// Controls browser behavior when opening a link.
    static member inline target (frameName: string) = Interop.svgAttribute "target" frameName

    /// Determines the positioning in horizontal direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The leftmost column of the matrix is column number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetX < orderX.
    static member inline targetX (index: int) = Interop.svgAttribute "targetX" index

    /// Determines the positioning in vertical direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The topmost row of the matrix is row number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetY < orderY.
    static member inline targetY (index: int) = Interop.svgAttribute "targetY" index

    /// A shorthand for using prop.custom("data-testid", value). Useful for referencing elements when testing React code.
    static member inline testId(value: string) = Interop.svgAttribute "data-testid" value
    static member inline text(value: string) = prop.text value |> unbox<ISvgAttribute>
    static member inline text(value: int) = prop.text value |> unbox<ISvgAttribute>
    static member inline text(value: float) = prop.text value |> unbox<ISvgAttribute>
    /// SVG attribute to indicate what color to use at a gradient stop.
    static member inline stopColor (value: string) = Interop.svgAttribute "stopColor" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: float) = Interop.svgAttribute "textLength" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: int) = Interop.svgAttribute "textLength" value

    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transform: ITransformProperty) =
        let removedUnit = (unbox<string> transform).Replace("px", "").Replace("deg", "")
        Interop.svgAttribute "transform" removedUnit
    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transforms: seq<ITransformProperty>) =
        let removedUnits =
            transforms
            |> unbox<seq<string>>
            |> Seq.map (fun transform -> transform.Replace("px", "").Replace("deg", ""))
            |> String.concat " "

        Interop.svgAttribute "transform" removedUnits
    /// Specifies the XML Namespace of the document.
    ///
    /// Default value is "http://www.w3.org/2000/svg".
    ///
    /// This is required in documents parsed with XML parsers, and optional in text/html documents.
    static member inline xmlns(ns: string) =
        Interop.svgAttribute "xmlns" ns

    /// Used to define a custom SVG attribute when one is missing.
    static member inline custom(name: string, value: 't) = Interop.svgAttribute name value

module svg =
    /// Controls whether or not an animation is cumulative.
    [<Erase>]
    type accumulate =
        /// Specifies that repeat iterations are not cumulative.
        static member inline none = Interop.svgAttribute "accumulate" "none"
        /// Specifies that each repeat iteration after the first builds upon
        /// the last value of the previous iteration.
        static member inline sum = Interop.svgAttribute "accumulate" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type additive =
        /// Specifies that the animation will override the underlying value of
        /// the attribute and other lower priority animations.
        static member inline replace = Interop.svgAttribute "additive" "replace"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline sum = Interop.svgAttribute "additive" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type alignmentBaseline =
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline alphabetic = Interop.svgAttribute "alignment-baseline" "alphabetic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline baseline = Interop.svgAttribute "alignment-baseline" "baseline"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline bottom = Interop.svgAttribute "alignment-baseline" "bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline center = Interop.svgAttribute "alignment-baseline" "center"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline central = Interop.svgAttribute "alignment-baseline" "central"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline hanging = Interop.svgAttribute "alignment-baseline" "hanging"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline ideographic = Interop.svgAttribute "alignment-baseline" "ideographic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline mathematical = Interop.svgAttribute "alignment-baseline" "mathematical"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline middle = Interop.svgAttribute "alignment-baseline" "middle"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textAfterEdge = Interop.svgAttribute "alignment-baseline" "text-after-edge"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textBeforeEdge = Interop.svgAttribute "alignment-baseline" "text-before-edge"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textBottom = Interop.svgAttribute "alignment-baseline" "text-bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textTop = Interop.svgAttribute "alignment-baseline" "text-top"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline top = Interop.svgAttribute "alignment-baseline" "top"

    /// Specifies the interpolation mode for the animation.
    [<Erase>]
    type calcMode =
        /// Specifies that the animation function will jump from one value to the next
        /// without any interpolation.
        static member inline discrete = Interop.svgAttribute "calcMode" "discrete"
        /// Simple linear interpolation between values is used to calculate the animation
        /// function. Except for <animateMotion>, this is the default value.
        static member inline linear = Interop.svgAttribute "calcMode" "linear"
        /// Defines interpolation to produce an even pace of change across the animation.
        ///
        /// This is only supported for values that define a linear numeric range, and for
        /// which some notion of "distance" between points can be calculated (e.g. position,
        /// width, height, etc.).
        ///
        /// If paced is specified, any keyTimes or keySplines will be ignored.
        ///
        /// For <animateMotion>, this is the default value.
        static member inline paced = Interop.svgAttribute "calcMode" "paced"
        /// Interpolates from one value in the values list to the next according to a time
        /// function defined by a cubic Bézier spline.
        ///
        /// The points of the spline are defined in the keyTimes attribute, and the control
        /// points for each interval are defined in the keySplines attribute.
        static member inline spline = Interop.svgAttribute "calcMode" "spline"

    /// The clipPathUnits attribute indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipPathUnits =
        static member inline userSpaceOnUse = Interop.svgAttribute "clipPathUnits" "userSpaceOnUse"
        static member inline objectBoundingBox = Interop.svgAttribute "clipPathUnits" "objectBoundingBox"

    /// Indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipRule =
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction and counting the number of path segments
        /// from the given shape that the ray crosses.
        ///
        /// If this number is odd, the point is inside; if even, the point is outside.
        static member inline evenodd = Interop.svgAttribute "clipRule" "evenodd"
        static member inline inheritFromParent = Interop.svgAttribute "clipRule" "inherit"
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction, and then examining the places where a
        /// segment of the shape crosses the ray.
        static member inline nonzero = Interop.svgAttribute "clipRule" "nonzero"

    /// Specifies the color space for gradient interpolations, color animations, and
    /// alpha compositing.
    [<Erase>]
    type colorInterpolation =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = Interop.svgAttribute "colorInterpolation" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = Interop.svgAttribute "colorInterpolation" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = Interop.svgAttribute "colorInterpolation" "sRGB"

    /// Specifies the color space for imaging operations performed via filter effects.
    [<Erase>]
    type colorInterpolationFilters =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = Interop.svgAttribute "colorInterpolationFilters" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = Interop.svgAttribute "colorInterpolationFilters" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = Interop.svgAttribute "colorInterpolationFilters" "sRGB"

    /// The cursor CSS property sets the type of cursor, if any, to show when the mouse pointer is over an element.
    /// See documentation at https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/cursor
    [<Erase>]
    type cursor =
        /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
        static member inline auto = Interop.svgAttribute "cursor" "auto"
        /// The cursor indicates an alias of something is to be created
        static member inline alias = Interop.svgAttribute "cursor" "alias"
        /// The platform-dependent default cursor. Typically an arrow.
        static member inline defaultCursor = Interop.svgAttribute "cursor" "default"
        /// No cursor is rendered.
        static member inline none = Interop.svgAttribute "cursor" "none"
        /// A context menu is available.
        static member inline contextMenu = Interop.svgAttribute "cursor" "context-menu"
        /// Help information is available.
        static member inline help = Interop.svgAttribute "cursor" "help"
        /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
        static member inline pointer = Interop.svgAttribute "cursor" "pointer"
        /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
        static member inline progress = Interop.svgAttribute "cursor" "progress"
        /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
        static member inline wait = Interop.svgAttribute "cursor" "wait"
        /// The table cell or set of cells can be selected.
        static member inline cell = Interop.svgAttribute "cursor" "cell"
        /// Cross cursor, often used to indicate selection in a bitmap.
        static member inline crosshair = Interop.svgAttribute "cursor" "crosshair"
        /// The text can be selected. Typically the shape of an I-beam.
        static member inline text = Interop.svgAttribute "cursor" "text"
        /// The vertical text can be selected. Typically the shape of a sideways I-beam.
        static member inline verticalText = Interop.svgAttribute "cursor" "vertical-text"
        /// Something is to be copied.
        static member inline copy = Interop.svgAttribute "cursor" "copy"
        /// Something is to be moved.
        static member inline move = Interop.svgAttribute "cursor" "move"
        /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
        static member inline noDrop = Interop.svgAttribute "cursor" "no-drop"
        /// The requested action will not be carried out.
        static member inline notAllowed = Interop.svgAttribute "cursor" "not-allowed"
        /// Something can be grabbed (dragged to be moved).
        static member inline grab = Interop.svgAttribute "cursor" "grab"
        /// Something is being grabbed (dragged to be moved).
        static member inline grabbing = Interop.svgAttribute "cursor" "grabbing"
        /// Something can be scrolled in any direction (panned).
        static member inline allScroll = Interop.svgAttribute "cursor" "all-scroll"
        /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
        static member inline columnResize = Interop.svgAttribute "cursor" "col-resize"
        /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
        static member inline rowResize = Interop.svgAttribute "cursor" "row-resize"
        /// Directional resize arrow
        static member inline northResize = Interop.svgAttribute "cursor" "n-resize"
        /// Directional resize arrow
        static member inline eastResize = Interop.svgAttribute "cursor" "e-resize"
        /// Directional resize arrow
        static member inline southResize = Interop.svgAttribute "cursor" "s-resize"
        /// Directional resize arrow
        static member inline westResize = Interop.svgAttribute "cursor" "w-resize"
        /// Directional resize arrow
        static member inline northEastResize = Interop.svgAttribute "cursor" "ne-resize"
        /// Directional resize arrow
        static member inline northWestResize = Interop.svgAttribute "cursor" "nw-resize"
        /// Directional resize arrow
        static member inline southEastResize = Interop.svgAttribute "cursor" "se-resize"
        /// Directional resize arrow
        static member inline southWestResize = Interop.svgAttribute "cursor" "sw-resize"
        /// Directional resize arrow
        static member inline eastWestResize = Interop.svgAttribute "cursor" "ew-resize"
        /// Directional resize arrow
        static member inline northSouthResize = Interop.svgAttribute "cursor" "ns-resize"
        /// Directional resize arrow
        static member inline northEastSouthWestResize = Interop.svgAttribute "cursor" "nesw-resize"
        /// Directional resize arrow
        static member inline northWestSouthEastResize = Interop.svgAttribute "cursor" "nwse-resize"
        /// Something can be zoomed (magnified) in
        static member inline zoomIn = Interop.svgAttribute "cursor" "zoom-in"
        /// Something can be zoomed out
        static member inline zoomOut = Interop.svgAttribute "cursor" "zoom-out"

    /// Indicates the directionality of the element's text.
    [<Erase>]
    type direction =
        /// Left to right - for languages that are written from left to right.
        static member inline ltr = Interop.svgAttribute "direction" "ltr"
        /// Right to left - for languages that are written from right to left.
        static member inline rtl = Interop.svgAttribute "direction" "rtl"

    /// The `dominantBaseline` attribute specifies the dominant baseline, which is the baseline used to align the box’s text
    /// and inline-level contents. It also indicates the default alignment baseline of any boxes participating in baseline
    /// alignment in the box’s alignment context. It is used to determine or re-determine a scaled-baseline-table. A
    /// scaled-baseline-table is a compound value with three components: a baseline-identifier for the dominant-baseline, a
    /// baseline-table and a baseline-table font-size. Some values of the property re-determine all three values; other only
    /// re-establish the baseline-table font-size. When the initial value, auto, would give an undesired result, this property
    /// can be used to explicitly set the desired scaled-baseline-table.
    /// If there is no baseline table in the nominal font or if the baseline table lacks an entry for the desired baseline,
    /// then the browser may use heuristics to determine the position of the desired baseline.
    [<Erase>]
    type dominantBaseline =
        /// The baseline-identifier for the dominant-baseline is set to be alphabetic, the derived baseline-table is constructed
        /// using the alphabetic baseline-table in the font, and the baseline-table font-size is changed to the value of the
        /// font-size attribute on this element.
        static member inline alphabetic = Interop.svgAttribute "dominantBaseline" "alphabetic"
        /// If this property occurs on a <text> element, then the computed value depends on the value of the writing-mode attribute.
        ///
        /// If the writing-mode is horizontal, then the value of the dominant-baseline component is alphabetic, else if the writing-mode
        /// is vertical, then the value of the dominant-baseline component is central.
        ///
        /// If this property occurs on a <tspan>, <tref>,
        /// <altGlyph> or <textPath> element, then the dominant-baseline and the baseline-table components remain the same as those of
        /// the parent text content element.
        ///
        /// If the computed baseline-shift value actually shifts the baseline, then the baseline-table
        /// font-size component is set to the value of the font-size attribute on the element on which the dominant-baseline attribute
        /// occurs, otherwise the baseline-table font-size remains the same as that of the element.
        ///
        /// If there is no parent text content
        /// element, the scaled-baseline-table value is constructed as above for <text> elements.
        static member inline auto = Interop.svgAttribute "dominantBaseline" "auto"
        /// The baseline-identifier for the dominant-baseline is set to be central. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order of
        /// baseline-table names: ideographic, alphabetic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline central = Interop.svgAttribute "dominantBaseline" "central"
        /// The baseline-identifier for the dominant-baseline is set to be hanging, the derived baseline-table is constructed using the
        /// hanging baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size attribute on
        /// this element.
        static member inline hanging = Interop.svgAttribute "dominantBaseline" "hanging"
        /// The baseline-identifier for the dominant-baseline is set to be ideographic, the derived baseline-table is constructed using
        /// the ideographic baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline ideographic = Interop.svgAttribute "dominantBaseline" "ideographic"
        /// The baseline-identifier for the dominant-baseline is set to be mathematical, the derived baseline-table is constructed using
        /// the mathematical baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline mathematical = Interop.svgAttribute "dominantBaseline" "mathematical"
        /// The baseline-identifier for the dominant-baseline is set to be middle. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order
        /// of baseline-table names: alphabetic, ideographic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline middle = Interop.svgAttribute "dominantBaseline" "middle"
        /// The baseline-identifier for the dominant-baseline is set to be text-after-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which font baseline-table to use from the
        /// baseline-tables in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline textAfterEdge = Interop.svgAttribute "dominantBaseline" "text-after-edge"
        /// The baseline-identifier for the dominant-baseline is set to be text-before-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which baseline-table to use from the baseline-tables
        /// in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size attribute on this element.
        static member inline textBeforeEdge = Interop.svgAttribute "dominantBaseline" "text-before-edge"
        /// This value uses the top of the em box as the baseline.
        static member inline textTop = Interop.svgAttribute "dominantBaseline" "text-top"

    /// Indicates the simple duration of an animation.
    [<Erase>]
    type dur =
        /// This value specifies the length of the simple duration.
        static member inline clockValue (duration: System.TimeSpan) =
            PropHelpers.createClockValue(duration)
            |> Interop.svgAttribute "dur"
        /// This value specifies the simple duration as indefinite.
        static member inline indefinite = Interop.svgAttribute "dur" "indefinite"
        /// This value specifies the simple duration as the intrinsic media duration.
        ///
        /// This is only valid for elements that define media.
        static member inline media = Interop.svgAttribute "dur" "media"

    /// Determines how to extend the input image as necessary with color values so
    /// that the matrix operations can be applied when the kernel is positioned at
    /// or near the edge of the input image.
    [<Erase>]
    type edgeMode =
        /// Indicates that the input image is extended along each of its borders as
        /// necessary by duplicating the color values at the given edge of the input image.
        static member inline duplicate = Interop.svgAttribute "edgeMode" "duplicate"
        /// Indicates that the input image is extended with pixel values of zero for
        /// R, G, B and A.
        static member inline none = Interop.svgAttribute "edgeMode" "none"
        /// Indicates that the input image is extended by taking the color values
        /// from the opposite edge of the image.
        static member inline wrap = Interop.svgAttribute "edgeMode" "wrap"

    /// The gradientUnits attribute defines the coordinate system used for attributes specified on the gradient elements. Two elements are using this attribute: <linearGradient> and <radialGradient>
    [<Erase>]
    type gradientUnits =
        static member inline userSpaceOnUse = Interop.svgAttribute "gradientUnits" "userSpaceOnUse"
        static member inline objectBoundingBox = Interop.svgAttribute "gradientUnits" "objectBoundingBox"

    /// The `text-anchor` attribute is used to align (start-, middle- or
    /// end-alignment) a string of pre-formatted text or auto-wrapped text where
    /// the wrapping area is determined from the `inline-size` property relative
    /// to a given point. It is not applicable to other types of auto-wrapped
    /// text. For those cases you should use `text-align`. For multi-line text,
    /// the alignment takes place for each line.
    ///
    /// The `text-anchor` attribute is applied to each individual text chunk
    /// within a given `<text>` element. Each text chunk has an initial current
    /// text position, which represents the point in the user coordinate system
    /// resulting from (depending on context) application of the `x` and `y`
    /// attributes on the `<text>` element, any `x` or `y` attribute values on a
    /// `<tspan>`, `<tref>` or `<altGlyph>` element assigned explicitly to the
    /// first rendered character in a text chunk, or determination of the
    /// initial current text position for a `<textPath>` element.
    [<Erase>]
    type textAnchor =
        /// The rendered characters are shifted such that the end of the
        /// resulting rendered text (final current text position before applying
        /// the `text-anchor` property) is at the initial current text position.
        /// For an element with a `direction` property value of `ltr` (typical
        /// for most European languages), the right side of the text is rendered
        /// at the initial text position. For an element with a `direction`
        /// property value of `rtl` (typical for Arabic and Hebrew), the left
        /// side of the text is rendered at the initial text position. For an
        /// element with a vertical primary text direction (often typical for
        /// Asian text), the bottom of the text is rendered at the initial text
        /// position.
        static member inline endOfText = Interop.svgAttribute "textAnchor" "end"
        /// The rendered characters are aligned such that the middle of the text
        /// string is at the current text position. (For text on a path,
        /// conceptually the text string is first laid out in a straight line.
        /// The midpoint between the start of the text string and the end of the
        /// text string is determined. Then, the text string is mapped onto the
        /// path with this midpoint placed at the current text position.)
        static member inline middle = Interop.svgAttribute "textAnchor" "middle"
        /// The rendered characters are aligned such that the start of the text
        /// string is at the initial current text position. For an element with
        /// a `direction` property value of `ltr` (typical for most European
        /// languages), the left side of the text is rendered at the initial
        /// text position. For an element with a `direction` property value of
        /// `rtl` (typical for Arabic and Hebrew), the right side of the text is
        /// rendered at the initial text position. For an element with a
        /// vertical primary text direction (often typical for Asian text), the
        /// top side of the text is rendered at the initial text position.
        static member inline startOfText = Interop.svgAttribute "textAnchor" "start"

    [<Erase>]
    type textDecoration =
        static member inline none = Interop.svgAttribute "textDecoration" "none"
        static member inline underline = Interop.svgAttribute "textDecoration" "underline"
        static member inline overline = Interop.svgAttribute "textDecoration" "overline"
        static member inline lineThrough = Interop.svgAttribute "textDecoration" "line-through"

    [<Erase>]
    type transform =
        /// Defines that there should be no transformation.
        static member inline none = Interop.svgAttribute "transform" "none"
        /// Defines a 2D transformation, using a matrix of six values.
        static member inline matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
            Interop.svgAttribute "transform" (
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
            Interop.svgAttribute "transform" (
                "translate(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )

        /// Defines a 3D translation.
        static member inline translate3D(x: int, y: int, z: int) =
            Interop.svgAttribute "transform" (
                "translate3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: int) =
            Interop.svgAttribute "transform" ("translateX(" + (unbox<string> x) + ")")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: int) =
            Interop.svgAttribute "transform" ("translateY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: int) =
            Interop.svgAttribute "transform" ("translateZ(" + (unbox<string> z) + ")")
        /// Defines a 2D scale transformation.
        static member inline scale(x: int, y: int) =
            Interop.svgAttribute "transform" (
                "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )
        /// Defines a scale transformation.
        static member inline scale(n: int) =
            Interop.svgAttribute "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a scale transformation.
        static member inline scale(n: float) =
            Interop.svgAttribute "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a 3D scale transformation
        static member inline scale3D(x: int, y: int, z: int) =
            Interop.svgAttribute "transform" (
                "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a scale transformation by giving a value for the X-axis.
        static member inline scaleX(x: int) =
            Interop.svgAttribute "transform" ("scaleX(" + (unbox<string> x) + ")")

        /// Defines a scale transformation by giving a value for the Y-axis.
        static member inline scaleY(y: int) =
            Interop.svgAttribute "transform" ("scaleY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline scaleZ(z: int) =
            Interop.svgAttribute "transform" ("scaleZ(" + (unbox<string> z) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: int) =
            Interop.svgAttribute "transform" ("rotate(" + (unbox<string> deg) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: float) =
            Interop.svgAttribute "transform" ("rotate(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: float) =
            Interop.svgAttribute "transform" ("rotateX(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: int) =
            Interop.svgAttribute "transform" ("rotateX(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: float) =
            Interop.svgAttribute "transform" ("rotateY(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: int) =
            Interop.svgAttribute "transform" ("rotateY(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: float) =
            Interop.svgAttribute "transform" ("rotateZ(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: int) =
            Interop.svgAttribute "transform" ("rotateZ(" + (unbox<string> deg) + ")")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: int, yAngle: int) =
            Interop.svgAttribute "transform" ("skew(" + (unbox<string> xAngle) + "," + (unbox<string> yAngle) + ")")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: float, yAngle: float) =
            Interop.svgAttribute "transform" ("skew(" + (unbox<string> xAngle) + "," + (unbox<string> yAngle) + ")")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: int) =
            Interop.svgAttribute "transform" ("skewX(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: float) =
            Interop.svgAttribute "transform" ("skewX(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: int) =
            Interop.svgAttribute "transform" ("skewY(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: float) =
            Interop.svgAttribute "transform" ("skewY(" + (unbox<string> xAngle) + ")")
        /// Defines a perspective view for a 3D transformed element
        static member inline perspective(n: int) =
            Interop.svgAttribute "transform" ("perspective(" + (unbox<string> n) + ")")

    /// Indicates which color channel from in2 to use to displace the pixels in in along the x-axis.
    [<Erase>]
    type xChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the x-axis.
        static member inline A = Interop.svgAttribute "xChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline B = Interop.svgAttribute "xChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline G = Interop.svgAttribute "xChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline R = Interop.svgAttribute "xChannelSelector" "R"

    /// Indicates which color channel from in2 to use to displace the pixels in in along the y-axis.
    [<Erase>]
    type yChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the y-axis.
        static member inline A = Interop.svgAttribute "yChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline B = Interop.svgAttribute "yChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline G = Interop.svgAttribute "yChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline R = Interop.svgAttribute "yChannelSelector" "R"

    [<Erase>]
    type x =
        static member inline percentage(value: float) = Interop.svgAttribute "x" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.svgAttribute "x" (unbox<string> value + "%")

    [<Erase>]
    type y =
        static member inline percentage(value: float) = Interop.svgAttribute "y" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.svgAttribute "y" (unbox<string> value + "%")
