namespace Feliz

open Browser.Types
open Fable.Core
open Feliz.Styles



module SvgHelper =

    let inline createElementWithChild (tag: string) (children: obj) =
        ReactLegacy.createElement(tag, children = unbox<ReactElement> children)

    let inline createElementWithChildren (tag: string) (children: seq<ReactElement>) =
        ReactLegacy.createElement(tag, children = children)

    let createSvgElement (name: string) (properties: ISvgAttribute list) : ReactElement =
        match unbox<(string*obj) list> properties |> List.partition (fun (key, _) -> key <> "children") with
        | props, ["children", children] ->
            ReactLegacy.createElement(
                name, 
                Fable.Core.JsInterop.createObj props,
                unbox<ReactElement list> children
            )
        | props, _ -> 
            ReactLegacy.createElement(
                name,
                Fable.Core.JsInterop.createObj props
            )

    let inline svgAttribute (key: string) (value: obj) : ISvgAttribute = unbox (key, value)

type Svg =
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image xs = SvgHelper.createSvgElement "image" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "image" children
    /// The svg element is a container that defines a new coordinate system and viewport. It is used as the outermost element of SVG documents, but it can also be used to embed an SVG fragment inside an SVG or HTML document.
    static member inline svg xs = SvgHelper.createSvgElement "svg" xs
    /// The svg element is a container that defines a new coordinate system and viewport. It is used as the outermost element of SVG documents, but it can also be used to embed an SVG fragment inside an SVG or HTML document.
    static member inline svg (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "svg" children
    static member inline circle xs = SvgHelper.createSvgElement "circle" xs
    static member inline circle (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "circle" children
    static member inline clipPath xs = SvgHelper.createSvgElement "clipPath" xs
    static member inline clipPath (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "clipPath" children
    /// The <defs> element is used to store graphical objects that will be used at a later time. Objects created inside a <defs> element are not rendered directly. To display them you have to reference them (with a <use> element for example). https://developer.mozilla.org/en-US/docs/Web/SVG/Element/defs
    static member inline defs xs = SvgHelper.createSvgElement "defs" xs
    /// The <defs> element is used to store graphical objects that will be used at a later time. Objects created inside a <defs> element are not rendered directly. To display them you have to reference them (with a <use> element for example). https://developer.mozilla.org/en-US/docs/Web/SVG/Element/defs
    static member inline defs (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "defs" children
    /// The <desc> element provides an accessible, long-text description of any SVG container element or graphics element.
    static member inline desc xs = SvgHelper.createSvgElement "desc" xs
    /// The <desc> element provides an accessible, long-text description of any SVG container element or graphics element.
    static member inline desc (value: string) = SvgHelper.createElementWithChild "desc" value
    static member inline ellipse xs = SvgHelper.createSvgElement "ellipse" xs
    static member inline ellipse (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "ellipse" children
    static member inline feBlend xs = SvgHelper.createSvgElement "feBlend" xs
    static member inline feBlend (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feBlend" children
    static member inline feColorMatrix xs = SvgHelper.createSvgElement "feColorMatrix" xs
    static member inline feColorMatrix (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feColorMatrix" children
    static member inline feComponentTransfer xs = SvgHelper.createSvgElement "feComponentTransfer" xs
    static member inline feComponentTransfer (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feComponentTransfer" children
    static member inline feComposite xs = SvgHelper.createSvgElement "feComposite" xs
    static member inline feComposite (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feComposite" children
    static member inline feConvolveMatrix xs = SvgHelper.createSvgElement "feConvolveMatrix" xs
    static member inline feConvolveMatrix (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feConvolveMatrix" children
    static member inline feDiffuseLighting xs = SvgHelper.createSvgElement "feDiffuseLighting" xs
    static member inline feDiffuseLighting (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feDiffuseLighting" children
    static member inline feDisplacementMap xs = SvgHelper.createSvgElement "feDisplacementMap" xs
    static member inline feDisplacementMap (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feDisplacementMap" children
    static member inline feDistantLight xs = SvgHelper.createSvgElement "feDistantLight" xs
    static member inline feDistantLight (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feDistantLight" children
    static member inline feDropShadow xs = SvgHelper.createSvgElement "feDropShadow" xs
    static member inline feDropShadow (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feDropShadow" children
    static member inline feFlood xs = SvgHelper.createSvgElement "feFlood" xs
    static member inline feFlood (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feFlood" children
    static member inline feFuncA xs = SvgHelper.createSvgElement "feFuncA" xs
    static member inline feFuncA (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feFuncA" children
    static member inline feFuncB xs = SvgHelper.createSvgElement "feFuncB" xs
    static member inline feFuncB (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feFuncB" children
    static member inline feFuncG xs = SvgHelper.createSvgElement "feFuncG" xs
    static member inline feFuncG (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feFuncG" children
    static member inline feFuncR xs = SvgHelper.createSvgElement "feFuncR" xs
    static member inline feFuncR (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feFuncR" children
    static member inline feGaussianBlur xs = SvgHelper.createSvgElement "feGaussianBlur" xs
    static member inline feGaussianBlur (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feGaussianBlur" children
    static member inline feImage xs = SvgHelper.createSvgElement "feImage" xs
    static member inline feImage (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feImage" children
    static member inline feMerge xs = SvgHelper.createSvgElement "feMerge" xs
    static member inline feMerge (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feMerge" children
    static member inline feMergeNode xs = SvgHelper.createSvgElement "feMergeNode" xs
    static member inline feMergeNode (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feMergeNode" children
    static member inline feMorphology xs = SvgHelper.createSvgElement "feMorphology" xs
    static member inline feMorphology (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feMorphology" children
    static member inline feOffset xs = SvgHelper.createSvgElement "feOffset" xs
    static member inline feOffset (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feOffset" children
    static member inline fePointLight xs = SvgHelper.createSvgElement "fePointLight" xs
    static member inline fePointLight (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "fePointLight" children
    static member inline feSpecularLighting xs = SvgHelper.createSvgElement "feSpecularLighting" xs
    static member inline feSpecularLighting (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feSpecularLighting" children
    static member inline feSpotLight xs = SvgHelper.createSvgElement "feSpotLight" xs
    static member inline feSpotLight (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feSpotLight" children
    static member inline feTile xs = SvgHelper.createSvgElement "feTile" xs
    static member inline feTile (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feTile" children
    static member inline feTurbulence xs = SvgHelper.createSvgElement "feTurbulence" xs
    static member inline feTurbulence (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "feTurbulence" children
    static member inline filter xs = SvgHelper.createSvgElement "filter" xs
    static member inline filter (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "filter" children
    static member inline foreignObject xs = SvgHelper.createSvgElement "foreignObject" xs
    static member inline foreignObject (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "foreignObject" children
    /// The <g> SVG element is a container used to group other SVG elements.
    ///
    /// Transformations applied to the <g> element are performed on its child elements, and its attributes are inherited by its children. It can also group multiple elements to be referenced later with the <use> element.
    static member inline g xs = SvgHelper.createSvgElement "g" xs
    /// The <g> SVG element is a container used to group other SVG elements.
    ///
    /// Transformations applied to the <g> element are performed on its child elements, and its attributes are inherited by its children. It can also group multiple elements to be referenced later with the <use> element.
    static member inline g (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "g" children
    static member inline line xs = SvgHelper.createSvgElement "line" xs
    static member inline line (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "line" children
    static member inline linearGradient xs = SvgHelper.createSvgElement "linearGradient" xs
    static member inline linearGradient (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "linearGradient" children
    /// The <marker> element defines the graphic that is to be used for drawing arrowheads or polymarkers on a given <path>, <line>, <polyline> or <polygon> element.
    static member inline marker xs = SvgHelper.createSvgElement "marker" xs
    /// The <marker> element defines the graphic that is to be used for drawing arrowheads or polymarkers on a given <path>, <line>, <polyline> or <polygon> element.
    static member inline marker (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "marker" children
    /// The <mask> element defines an alpha mask for compositing the current object into the background. A mask is used/referenced using the mask attribute.
    static member inline mask xs = SvgHelper.createSvgElement "mask" xs
    /// The <mask> element defines an alpha mask for compositing the current object into the background. A mask is used/referenced using the mask attribute.
    static member inline mask (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "mask" children
    static member inline mpath xs = SvgHelper.createSvgElement "mpath" xs
    static member inline mpath (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "mpath" children
    static member inline path xs = SvgHelper.createSvgElement "path" xs
    static member inline path (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "path" children
    static member inline pattern xs = SvgHelper.createSvgElement "pattern" xs
    static member inline pattern (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "pattern" children
    static member inline polygon xs = SvgHelper.createSvgElement "polygon" xs
    static member inline polygon (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "polygon" children
    static member inline polyline xs = SvgHelper.createSvgElement "polyline" xs
    static member inline polyline (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "polyline" children
    static member inline set xs = SvgHelper.createSvgElement "set" xs
    static member inline set (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "set" children
    static member inline stop xs = SvgHelper.createSvgElement "stop" xs
    static member inline stop (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "stop" children
    static member inline style xs = SvgHelper.createSvgElement "style" xs
    static member inline style (value: string) = SvgHelper.createElementWithChild "style" value
    static member inline switch xs = SvgHelper.createSvgElement "switch" xs
    static member inline switch (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "switch" children
    static member inline symbol xs = SvgHelper.createSvgElement "symbol" xs
    static member inline symbol (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "symbol" children
    static member inline text xs = SvgHelper.createSvgElement "text" xs
    static member inline text (content: string) = SvgHelper.createElementWithChild "text" content
    static member inline title xs = SvgHelper.createSvgElement "title" xs
    static member inline title (content: string) = SvgHelper.createElementWithChild "title" content
    static member inline textPath xs = SvgHelper.createSvgElement "textPath" xs
    static member inline textPath (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "textPath" children
    static member inline tspan xs = SvgHelper.createSvgElement "tspan" xs
    static member inline tspan (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "tspan" children
    static member inline use' xs = SvgHelper.createSvgElement "use" xs
    static member inline use' (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "use" children
    static member inline radialGradient xs = SvgHelper.createSvgElement "radialGradient" xs
    static member inline radialGradient (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "radialGradient" children
    static member inline rect xs = SvgHelper.createSvgElement "rect" xs
    static member inline rect (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "rect" children
    static member inline view xs = SvgHelper.createSvgElement "view" xs
    static member inline view (children: #seq<ReactElement>) = SvgHelper.createElementWithChildren "view" children

type svg =
    /// Specifies a CSS class for this element.
    static member inline className (value: string) = SvgHelper.svgAttribute "className" value
    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `svg.className [ "one"; "two" ]`
    ///
    /// is the same as
    ///
    /// `svg.className "one two"`
    static member inline className (names: seq<string>) = SvgHelper.svgAttribute "className" (String.concat " " names)

    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `svg.classes [ "one"; "two" ]` => `svg.className "one two"`
    static member inline classes (names: seq<string>) = SvgHelper.svgAttribute "className" (String.concat " " names)
    static member inline id (value: string) = SvgHelper.svgAttribute "id" value
    /// Defines the number of octaves for the noise function of the <feTurbulence> primitive.
    static member inline numOctaves (value: int) = SvgHelper.svgAttribute "numOctaves" value

    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: float) = SvgHelper.svgAttribute "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: ICssUnit) = SvgHelper.svgAttribute "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: int) = SvgHelper.svgAttribute "offset" value
    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: float) = SvgHelper.svgAttribute "amplitude" value
    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: int) = SvgHelper.svgAttribute "amplitude" value
    /// Indicates the name of the CSS property or attribute of the target element
    /// that is going to be changed during an animation.
    static member inline attributeName (value: string) = SvgHelper.svgAttribute "attributeName" value
    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: float) = SvgHelper.svgAttribute "azimuth" value
    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: int) = SvgHelper.svgAttribute "azimuth" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: float) = SvgHelper.svgAttribute "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: int) = SvgHelper.svgAttribute "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: float) = SvgHelper.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: int) = SvgHelper.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: float) = SvgHelper.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: int) = SvgHelper.svgAttribute "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    static member inline children (elements: ReactElement list) = SvgHelper.svgAttribute "children" elements
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: float) = SvgHelper.svgAttribute "cx" value
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: int) = SvgHelper.svgAttribute "cx" value
    static member inline x (value: float) = SvgHelper.svgAttribute "x" value
    static member inline x (value: int) = SvgHelper.svgAttribute "x" value
    static member inline x1 (value: float) = SvgHelper.svgAttribute "x1" value
    static member inline x1 (value: int) = SvgHelper.svgAttribute "x1" value
    static member inline x2 (value: float) = SvgHelper.svgAttribute "x2" value
    static member inline x2 (value: int) = SvgHelper.svgAttribute "x2" value
    static member inline y (value: float) = SvgHelper.svgAttribute "y" value
    static member inline y (value: int) = SvgHelper.svgAttribute "y" value
    static member inline y1 (value: float) = SvgHelper.svgAttribute "y1" value
    static member inline y1 (value: int) = SvgHelper.svgAttribute "y1" value
    static member inline y2 (value: float) = SvgHelper.svgAttribute "y2" value
    static member inline y2 (value: int) = SvgHelper.svgAttribute "y2" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: float) = SvgHelper.svgAttribute "cy" value
    /// The clip-path presentation attribute defines or associates a clipping path with the element it is related to.
    static member inline clipPath(value: string) = SvgHelper.svgAttribute "clipPath" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: int) = SvgHelper.svgAttribute "cy" value
    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: float) = SvgHelper.svgAttribute "dx" value
    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: int) = SvgHelper.svgAttribute "dx" value

    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: float) = SvgHelper.svgAttribute "dy" value
    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: int) = SvgHelper.svgAttribute "dy" value
    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> SvgHelper.svgAttribute "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> SvgHelper.svgAttribute "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: string) = SvgHelper.svgAttribute "d" path

    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: float) = SvgHelper.svgAttribute "diffuseConstant" value
    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: int) = SvgHelper.svgAttribute "diffuseConstant" value
    /// The display attribute lets you control the rendering of graphical or container elements.
    static member inline display (value: string) = SvgHelper.svgAttribute "display" value
    /// The divisor attribute specifies the value by which the resulting number of applying the kernelMatrix of a <feConvolveMatrix> element to the input image color value is divided to yield the destination color value. A divisor that is the sum of all the matrix values tends to have an evening effect on the overall color intensity of the result.
    static member inline divisor (value: float) = SvgHelper.svgAttribute "divisor" value
    /// The divisor attribute specifies the value by which the resulting number of applying the kernelMatrix of a <feConvolveMatrix> element to the input image color value is divided to yield the destination color value. A divisor that is the sum of all the matrix values tends to have an evening effect on the overall color intensity of the result.
    static member inline divisor (value: int) = SvgHelper.svgAttribute "divisor" value
    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: float) = SvgHelper.svgAttribute "elevation" value
    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: int) = SvgHelper.svgAttribute "elevation" value
    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (value: string) = SvgHelper.svgAttribute "end" value
    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (values: seq<string>) = SvgHelper.svgAttribute "end" (String.concat ";" values)

    /// Defines the exponent of the gamma function.
    static member inline exponent (value: float) = SvgHelper.svgAttribute "exponent" value
    /// Defines the exponent of the gamma function.
    static member inline exponent (value: int) = SvgHelper.svgAttribute "exponent" value
    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: float) = SvgHelper.svgAttribute "fillOpacity" value
    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: int) = SvgHelper.svgAttribute "fillOpacity" value

    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: float) = SvgHelper.svgAttribute "fontSize" value
    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: int) = SvgHelper.svgAttribute "fontSize" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: float) = SvgHelper.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<float>) = SvgHelper.svgAttribute "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: int) = SvgHelper.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<int>) = SvgHelper.svgAttribute "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: string) = SvgHelper.svgAttribute "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<string>) = SvgHelper.svgAttribute "from" (values |> String.concat " ")

    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: float) = SvgHelper.svgAttribute "fr" value
    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: int) = SvgHelper.svgAttribute "fr" value

    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: float) = SvgHelper.svgAttribute "fx" value
    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: int) = SvgHelper.svgAttribute "fx" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: float) = SvgHelper.svgAttribute "fy" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: int) = SvgHelper.svgAttribute "fy" value
    /// Sets the color of an SVG shape.
    static member inline fill (color: string) = SvgHelper.svgAttribute "fill" color
    /// Defines an optional additional transformation from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transform: ITransformProperty) =
        SvgHelper.svgAttribute "gradientTransform" (unbox<string> transform)
    /// Defines optional additional transformation(s) from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transforms: seq<ITransformProperty>) =
        SvgHelper.svgAttribute "gradientTransform" (unbox<seq<string>> transforms |> String.concat " ")

    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: float) = SvgHelper.svgAttribute "height" value
    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: int) = SvgHelper.svgAttribute "height" value
    /// Defines the position and dimension, in user space, of an SVG viewport.
    static member inline viewBox (minX: int, minY: int, width: int, height: int) =
        SvgHelper.svgAttribute "viewBox" ($"{minX} {minY} {width} {height}")

    /// Set visible area of the SVG image.
    static member inline viewPort (x: int, y: int, height: int, width: int) =
        SvgHelper.svgAttribute "viewport" (
            (unbox<string> x) + " " +
            (unbox<string> y) + " " +
            (unbox<string> height) + " " +
            (unbox<string> width)
        )

    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: float) = SvgHelper.svgAttribute "markerHeight" value
    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: int) = SvgHelper.svgAttribute "markerHeight" value
    /// Represents the height of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerHeight (value: ICssUnit) = SvgHelper.svgAttribute "markerHeight" value
    
    /// The mask presentation attribute binds a given <mask> element applying it to the element the attribute belongs to.
    static member inline mask (value: string) = SvgHelper.svgAttribute "mask" value

    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: float) = SvgHelper.svgAttribute "markerWidth" value
    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: int) = SvgHelper.svgAttribute "markerWidth" value
    /// Represents the width of the viewport into which the <marker> is to be fitted when it is
    /// rendered according to the viewBox and preserveAspectRatio attributes.
    static member inline markerWidth (value: ICssUnit) = SvgHelper.svgAttribute "markerWidth" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: float) = SvgHelper.svgAttribute "width" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: int) = SvgHelper.svgAttribute "width" value
    /// The URL of a linked resource.
    static member inline href (value: string) = SvgHelper.svgAttribute "href" value
    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: float) = SvgHelper.svgAttribute "intercept" value
    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: int) = SvgHelper.svgAttribute "intercept" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: float) = SvgHelper.svgAttribute "k1" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: int) = SvgHelper.svgAttribute "k1" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: float) = SvgHelper.svgAttribute "k2" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: int) = SvgHelper.svgAttribute "k2" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: float) = SvgHelper.svgAttribute "k3" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: int) = SvgHelper.svgAttribute "k3" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: float) = SvgHelper.svgAttribute "k4" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: int) = SvgHelper.svgAttribute "k4" value

    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<float>) = SvgHelper.svgAttribute "kernelMatrix" (values |> unbox<seq<string>> |> String.concat " ")
    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<int>) = SvgHelper.svgAttribute "kernelMatrix" (values |> unbox<seq<string>>  |> String.concat " ")

    /// A unique identifier for the element. Used by React to identify elements.
    static member key(value: string) = SvgHelper.svgAttribute "key" value
    /// Fires when a media event is aborted.
    static member inline onAbort (handler: Event -> unit) = SvgHelper.svgAttribute "onAbort" handler
    /// Fires when animation is aborted.
    static member inline onAnimationCancel (handler: AnimationEvent -> unit) = SvgHelper.svgAttribute "onAnimationCancel" handler
    /// Fires when animation ends.
    static member inline onAnimationEnd (handler: AnimationEvent -> unit) = SvgHelper.svgAttribute "onAnimationEnd" handler
    /// Fires when animation iterates.
    static member inline onAnimationIteration (handler: AnimationEvent -> unit) = SvgHelper.svgAttribute "onAnimationIteration" handler
    /// Fires the moment that the element loses focus.
    static member inline onBlur (handler: FocusEvent -> unit) = SvgHelper.svgAttribute "onBlur" handler
    /// Fires when a user dismisses the current open dialog
    static member inline onCancel (handler: Event -> unit) = SvgHelper.svgAttribute "onCancel" handler
    /// Fires when a file is ready to start playing (when it has buffered enough to begin).
    static member inline onCanPlay (handler: Event -> unit) = SvgHelper.svgAttribute "onCanPlay" handler
    /// Fires when a file can be played all the way to the end without pausing for buffering
    static member inline onCanPlayThrough (handler: Event -> unit) = SvgHelper.svgAttribute "onCanPlayThrough" handler
    /// Fires the moment when the value of the element is changed
    static member inline onChange (handler: Event -> unit) = SvgHelper.svgAttribute "onChange" handler
    /// Fires on a mouse click on the element.
    static member inline onClick (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onClick" handler
    /// Fires when a context menu is triggered.
    static member inline onContextMenu (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onContextMenu" handler
    /// Fires when a TextTrack has changed the currently displaying cues.
    static member inline onCueChange (handler: Event -> unit) = SvgHelper.svgAttribute "onCueChange" handler
    /// Fires when a mouse is double clicked on the element.
    static member inline onDblClick (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onDblClick" handler
    /// Fires when the length of the media changes.
    static member inline onDurationChange (handler: Event -> unit) = SvgHelper.svgAttribute "onDurationChange" handler
    /// Fires when the media has reached the end (a useful event for messages like "thanks for listening").
    static member inline onEnded (handler: Event -> unit) = SvgHelper.svgAttribute "onEnded" handler
    /// Fires when an error occurs.
    static member inline onError (handler: Event -> unit) = SvgHelper.svgAttribute "onError" handler
    /// Fires when an error occurs.
    static member inline onError (handler: UIEvent -> unit) = SvgHelper.svgAttribute "onError" handler
    /// Fires the moment when the element gets focus.
    static member inline onFocus (handler: FocusEvent -> unit) = SvgHelper.svgAttribute "onFocus" handler
    /// Fires when an element captures a pointer.
    static member inline onGotPointerCapture (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onGotPointerCapture" handler
    /// Fires when an element gets user input.
    static member inline onInput (handler: Event -> unit) = SvgHelper.svgAttribute "onInput" handler
    /// Fires when a submittable element has been checked for validaty and doesn't satisfy its constraints.
    static member inline onInvalid (handler: Event -> unit) = SvgHelper.svgAttribute "onInvalid" handler
    /// Fires when a user presses a key.
    static member inline onKeyDown (handler: KeyboardEvent -> unit) = SvgHelper.svgAttribute "onKeyDown" handler
    /// Fires when a user presses a key.
    static member inline onKeyDown (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> SvgHelper.svgAttribute "onKeyDown"
    /// Fires when a user presses a key.
    static member inline onKeyPress (handler: KeyboardEvent -> unit) = SvgHelper.svgAttribute "onKeyPress" handler
    /// Fires when a user presses a key.
    static member inline onKeyPress (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> SvgHelper.svgAttribute "onKeyPress"
    /// Fires when a user releases a key.
    static member inline onKeyUp (handler: KeyboardEvent -> unit) = SvgHelper.svgAttribute "onKeyUp" handler
    /// Fires when a user releases a key.
    static member inline onKeyUp (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> SvgHelper.svgAttribute "onKeyUp"
    /// Fires after the page is finished loading.
    static member inline onLoad (handler: Event -> unit) = SvgHelper.svgAttribute "onLoad" handler
    /// Fires when media data is loaded.
    static member inline onLoadedData (handler: Event -> unit) = SvgHelper.svgAttribute "onLoadedData" handler
    /// Fires when meta data (like dimensions and duration) are loaded.
    static member inline onLoadedMetadata (handler: Event -> unit) = SvgHelper.svgAttribute "onLoadedMetadata" handler
    /// Fires when a request has completed, irrespective of its success.
    static member inline onLoadEnd (handler: Event -> unit) = SvgHelper.svgAttribute "onLoadEnd" handler
    /// Fires when the resource begins to load before anything is actually loaded.
    static member inline onLoadStart (handler: Event -> unit) = SvgHelper.svgAttribute "onLoadStart" handler
    /// Fires when a captured pointer is released.
    static member inline onLostPointerCapture (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onLostPointerCapture" handler
    /// Fires when a mouse button is pressed down on an element.
    static member inline onMouseDown (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseDown" handler
    /// Fires when a pointer enters an element.
    static member inline onMouseEnter (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseEnter" handler
    /// Fires when a pointer leaves an element.
    static member inline onMouseLeave (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseLeave" handler
    /// Fires when the mouse pointer is moving while it is over an element.
    static member inline onMouseMove (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseMove" handler
    /// Fires when the mouse pointer moves out of an element.
    static member inline onMouseOut (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseOut" handler
    /// Fires when the mouse pointer moves over an element.
    static member inline onMouseOver (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseOver" handler
    /// Fires when a mouse button is released while it is over an element.
    static member inline onMouseUp (handler: MouseEvent -> unit) = SvgHelper.svgAttribute "onMouseUp" handler
    /// Fires when the media is paused either by the user or programmatically.
    static member inline onPause (handler: Event -> unit) = SvgHelper.svgAttribute "onPause" handler
    /// Fires when the media is ready to start playing.
    static member inline onPlay (handler: Event -> unit) = SvgHelper.svgAttribute "onPlay" handler
    /// Fires when the media actually has started playing
    static member inline onPlaying (handler: Event -> unit) = SvgHelper.svgAttribute "onPlaying" handler
    /// Fires when there are no more pointer events.
    static member inline onPointerCancel (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerCancel" handler
    /// Fires when a pointer becomes active.
    static member inline onPointerDown (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerDown" handler
    /// Fires when a pointer is moved into an elements boundaries or one of its descendants.
    static member inline onPointerEnter (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerEnter" handler
    /// Fires when a pointer is moved out of an elements boundaries.
    static member inline onPointerLeave (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerLeave" handler
    /// Fires when a pointer moves.
    static member inline onPointerMove (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerMove" handler
    /// Fires when a pointer is no longer in an elements boundaries, such as moving it, or after a `pointerUp` or `pointerCancel` event.
    static member inline onPointerOut (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerOut" handler
    /// Fires when a pointer is moved into an elements boundaries.
    static member inline onPointerOver (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerOver" handler
    /// Fires when a pointer is no longer active.
    static member inline onPointerUp (handler: PointerEvent -> unit) = SvgHelper.svgAttribute "onPointerUp" handler
    /// Fires when the Reset button in a form is clicked.
    static member inline onReset (handler: Event -> unit) = SvgHelper.svgAttribute "onReset" handler
    /// Fires when the window has been resized.
    static member inline onResize (handler: UIEvent -> unit) = SvgHelper.svgAttribute "onResize" handler
    /// Fires when an element's scrollbar is being scrolled.
    static member inline onScroll (handler: Event -> unit) = SvgHelper.svgAttribute "onScroll" handler
    /// Fires after some text has been selected in an element.
    static member inline onSelect (handler: Event -> unit) = SvgHelper.svgAttribute "onSelect" handler
    /// Fires after some text has been selected in the user interface.
    static member inline onSelect (handler: UIEvent -> unit) = SvgHelper.svgAttribute "onSelect" handler
    /// Fires when a form is submitted.
    static member inline onSubmit (handler: Event -> unit) = SvgHelper.svgAttribute "onSubmit" handler
    /// Fires when the mouse wheel rolls up or down over an element.
    static member inline onWheel (handler: WheelEvent -> unit) = SvgHelper.svgAttribute "onWheel" handler
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<float * float>) =
        PropHelpers.createPointsFloat(coordinates)
        |> SvgHelper.svgAttribute "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<int * int>) =
        PropHelpers.createPointsInt(coordinates)
        |> SvgHelper.svgAttribute "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: string) = SvgHelper.svgAttribute "points" coordinates

    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: float) = SvgHelper.svgAttribute "pointsAtX" value
    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: int) = SvgHelper.svgAttribute "pointsAtX" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: float) = SvgHelper.svgAttribute "pointsAtY" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: int) = SvgHelper.svgAttribute "pointsAtY" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: float) = SvgHelper.svgAttribute "pointsAtZ" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: int) = SvgHelper.svgAttribute "pointsAtZ" value

    /// Indicates how a <feConvolveMatrix> element handles alpha transparency.
    static member inline preserveAlpha (value: bool) = SvgHelper.svgAttribute "preserveAlpha" value

    /// A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing
    /// is displayed until the first frame is available, then the first frame is shown as the poster frame.
    static member inline poster (value: string) = SvgHelper.svgAttribute "poster" value

    /// SVG attribute to define the radius of a circle.
    static member inline r (value: float) = SvgHelper.svgAttribute "r" value
    /// SVG attribute to define the radius of a circle.
    static member inline r (value: int) = SvgHelper.svgAttribute "r" value

    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: float) = SvgHelper.svgAttribute "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: int) = SvgHelper.svgAttribute "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: float) = SvgHelper.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: int) = SvgHelper.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: float) = SvgHelper.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: int) = SvgHelper.svgAttribute "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: float) = SvgHelper.svgAttribute "overlinePosition" value
    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: int) = SvgHelper.svgAttribute "overlinePosition" value

    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: float) = SvgHelper.svgAttribute "overlineThickness" value
    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: int) = SvgHelper.svgAttribute "overlineThickness" value

    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> SvgHelper.svgAttribute "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> SvgHelper.svgAttribute "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: string) = SvgHelper.svgAttribute "path" path

    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: float) = SvgHelper.svgAttribute "rx" value
    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: int) = SvgHelper.svgAttribute "rx" value

    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: float) = SvgHelper.svgAttribute "ry" value
    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: int) = SvgHelper.svgAttribute "ry" value
    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: float) = SvgHelper.svgAttribute "scale" value
    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: int) = SvgHelper.svgAttribute "scale" value

    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: float) = SvgHelper.svgAttribute "seed" value
    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: int) = SvgHelper.svgAttribute "seed" value
    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: float) = SvgHelper.svgAttribute "specularConstant" value
    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: int) = SvgHelper.svgAttribute "specularConstant" value

    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: float) = SvgHelper.svgAttribute "specularExponent" value
    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: int) = SvgHelper.svgAttribute "specularExponent" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: float) = SvgHelper.svgAttribute "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: int) = SvgHelper.svgAttribute "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: float) = SvgHelper.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: int) = SvgHelper.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: float) = SvgHelper.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: int) = SvgHelper.svgAttribute "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: float) = SvgHelper.svgAttribute "stopOpacity" value
    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: int) = SvgHelper.svgAttribute "stopOpacity" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: float) = SvgHelper.svgAttribute "strikethroughPosition" value
    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: int) = SvgHelper.svgAttribute "strikethroughPosition" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: float) = SvgHelper.svgAttribute "strikethroughThickness" value
    /// Represents the ideal thickness of the strikethrough.
    ///
    /// The strikethrough thickness is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: int) = SvgHelper.svgAttribute "strikethroughThickness" value

    /// SVG attribute to define the color (or any SVG paint servers like gradients or patterns) used to paint the outline of the shape.
    static member inline stroke (color: string) = SvgHelper.svgAttribute "stroke" color
    
    /// SVG attribute to define the pattern of dashes and gaps used to paint the outline of the shape.
    static member inline strokeDasharray (value: int array) = SvgHelper.svgAttribute "strokeDasharray" value

    /// SVG attribute to define the offset on the rendering of the associated dash array.
    static member inline strokeDashoffset (value: int) = SvgHelper.svgAttribute "strokeDashoffset" value

    /// SVG attribute to define the  an offset on the rendering of the associated dash array
    static member inline strokeDashoffset (value: float) = SvgHelper.svgAttribute "strokeDashoffset" value

    /// SVG attribute to define the shape to be used at the end of open subpaths when they are stroked.
    static member inline strokeLineCap (value: string) = SvgHelper.svgAttribute "strokeLinecap" value

    /// SVG attribute to define the shape to be used at the end of open subpaths when they are stroked.
    static member inline strokeLineJoin (value: string) = SvgHelper.svgAttribute "strokeLinejoin" value

    /// SVG attribute to define a limit on the ratio of the miter length to the stroke-width used to draw a miter join. 
    /// When the limit is exceeded, the join is converted from a miter to a bevel.
    static member inline strokeMitterLimit (value: int) = SvgHelper.svgAttribute "strokeMiterlimit" value

    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: float) = SvgHelper.svgAttribute "strokeWidth" value

    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: int) = SvgHelper.svgAttribute "strokeWidth" value

    /// SVG attribute to define the opacity of the stroke to be applied to the shape.
    static member inline strokeOpacity (value: float) = SvgHelper.svgAttribute "strokeOpacity" value

    /// SVG attribute to define the opacity of the stroke to be applied to the shape.
    static member inline strokeOpacity (value: int) = SvgHelper.svgAttribute "strokeOpacity" value

    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: float) = SvgHelper.svgAttribute "surfaceScale" value

    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: int) = SvgHelper.svgAttribute "surfaceScale" value

    /// Represents a list of supported language tags.
    ///
    /// This list is matched against the language defined in the user preferences.
    static member inline systemLanguage (value: string) = SvgHelper.svgAttribute "systemLanguage" value

    /// The `tabindex` global attribute indicates that its element can be focused,
    /// and where it participates in sequential keyboard navigation (usually with the Tab key, hence the name).
    static member inline tabIndex (index: int) = SvgHelper.svgAttribute "tabIndex" index

    /// Controls browser behavior when opening a link.
    static member inline target (frameName: string) = SvgHelper.svgAttribute "target" frameName

    /// Determines the positioning in horizontal direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The leftmost column of the matrix is column number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetX < orderX.
    static member inline targetX (index: int) = SvgHelper.svgAttribute "targetX" index

    /// Determines the positioning in vertical direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The topmost row of the matrix is row number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetY < orderY.
    static member inline targetY (index: int) = SvgHelper.svgAttribute "targetY" index

    /// A shorthand for using prop.custom("data-testid", value). Useful for referencing elements when testing React code.
    static member inline testId(value: string) = SvgHelper.svgAttribute "data-testid" value
    static member inline text(value: string) = prop.text value |> unbox<ISvgAttribute>
    static member inline text(value: int) = prop.text value |> unbox<ISvgAttribute>
    static member inline text(value: float) = prop.text value |> unbox<ISvgAttribute>
    /// SVG attribute to indicate what color to use at a gradient stop.
    static member inline stopColor (value: string) = SvgHelper.svgAttribute "stopColor" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: float) = SvgHelper.svgAttribute "textLength" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: int) = SvgHelper.svgAttribute "textLength" value

    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transform: ITransformProperty) =
        let removedUnit = (unbox<string> transform).Replace("px", "").Replace("deg", "")
        SvgHelper.svgAttribute "transform" removedUnit
    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transforms: seq<ITransformProperty>) =
        transforms
        |> unbox<seq<string>>
        |> Seq.map (fun transform -> transform.Replace("px", "").Replace("deg", ""))
        |> String.concat " "
        |> SvgHelper.svgAttribute "transform" 

    /// Specifies the XML Namespace of the document.
    ///
    /// Default value is "http://www.w3.org/2000/svg".
    ///
    /// This is required in documents parsed with XML parsers, and optional in text/html documents.
    static member inline xmlns(ns: string) =
        SvgHelper.svgAttribute "xmlns" ns

    /// Used to define a custom SVG attribute when one is missing.
    static member inline custom(name: string, value: 't) = SvgHelper.svgAttribute name value

module svg =
    /// Controls whether or not an animation is cumulative.
    [<Erase>]
    type accumulate =
        /// Specifies that repeat iterations are not cumulative.
        static member inline none = SvgHelper.svgAttribute "accumulate" "none"
        /// Specifies that each repeat iteration after the first builds upon
        /// the last value of the previous iteration.
        static member inline sum = SvgHelper.svgAttribute "accumulate" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type additive =
        /// Specifies that the animation will override the underlying value of
        /// the attribute and other lower priority animations.
        static member inline replace = SvgHelper.svgAttribute "additive" "replace"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline sum = SvgHelper.svgAttribute "additive" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type alignmentBaseline =
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline alphabetic = SvgHelper.svgAttribute "alignmentBaseline" "alphabetic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline baseline = SvgHelper.svgAttribute "alignmentBaseline" "baseline"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline bottom = SvgHelper.svgAttribute "alignmentBaseline" "bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline center = SvgHelper.svgAttribute "alignmentBaseline" "center"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline central = SvgHelper.svgAttribute "alignmentBaseline" "central"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline hanging = SvgHelper.svgAttribute "alignmentBaseline" "hanging"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline ideographic = SvgHelper.svgAttribute "alignmentBaseline" "ideographic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline mathematical = SvgHelper.svgAttribute "alignmentBaseline" "mathematical"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline middle = SvgHelper.svgAttribute "alignmentBaseline" "middle"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textAfterEdge = SvgHelper.svgAttribute "alignmentBaseline" "text-after-edge"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textBeforeEdge = SvgHelper.svgAttribute "alignmentBaseline" "text-before-edge"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textBottom = SvgHelper.svgAttribute "alignmentBaseline" "text-bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textTop = SvgHelper.svgAttribute "alignmentBaseline" "text-top"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline top = SvgHelper.svgAttribute "alignmentBaseline" "top"

    /// Specifies the interpolation mode for the animation.
    [<Erase>]
    type calcMode =
        /// Specifies that the animation function will jump from one value to the next
        /// without any interpolation.
        static member inline discrete = SvgHelper.svgAttribute "calcMode" "discrete"
        /// Simple linear interpolation between values is used to calculate the animation
        /// function. Except for <animateMotion>, this is the default value.
        static member inline linear = SvgHelper.svgAttribute "calcMode" "linear"
        /// Defines interpolation to produce an even pace of change across the animation.
        ///
        /// This is only supported for values that define a linear numeric range, and for
        /// which some notion of "distance" between points can be calculated (e.g. position,
        /// width, height, etc.).
        ///
        /// If paced is specified, any keyTimes or keySplines will be ignored.
        ///
        /// For <animateMotion>, this is the default value.
        static member inline paced = SvgHelper.svgAttribute "calcMode" "paced"
        /// Interpolates from one value in the values list to the next according to a time
        /// function defined by a cubic Bézier spline.
        ///
        /// The points of the spline are defined in the keyTimes attribute, and the control
        /// points for each interval are defined in the keySplines attribute.
        static member inline spline = SvgHelper.svgAttribute "calcMode" "spline"

    /// The clipPathUnits attribute indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipPathUnits =
        static member inline userSpaceOnUse = SvgHelper.svgAttribute "clipPathUnits" "userSpaceOnUse"
        static member inline objectBoundingBox = SvgHelper.svgAttribute "clipPathUnits" "objectBoundingBox"

    /// Indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipRule =
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction and counting the number of path segments
        /// from the given shape that the ray crosses.
        ///
        /// If this number is odd, the point is inside; if even, the point is outside.
        static member inline evenodd = SvgHelper.svgAttribute "clipRule" "evenodd"
        static member inline inheritFromParent = SvgHelper.svgAttribute "clipRule" "inherit"
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction, and then examining the places where a
        /// segment of the shape crosses the ray.
        static member inline nonzero = SvgHelper.svgAttribute "clipRule" "nonzero"

    /// Specifies the color space for gradient interpolations, color animations, and
    /// alpha compositing.
    [<Erase>]
    type colorInterpolation =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = SvgHelper.svgAttribute "colorInterpolation" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = SvgHelper.svgAttribute "colorInterpolation" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = SvgHelper.svgAttribute "colorInterpolation" "sRGB"

    /// Specifies the color space for imaging operations performed via filter effects.
    [<Erase>]
    type colorInterpolationFilters =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = SvgHelper.svgAttribute "colorInterpolationFilters" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = SvgHelper.svgAttribute "colorInterpolationFilters" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = SvgHelper.svgAttribute "colorInterpolationFilters" "sRGB"

    /// The cursor CSS property sets the type of cursor, if any, to show when the mouse pointer is over an element.
    /// See documentation at https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/cursor
    [<Erase>]
    type cursor =
        /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
        static member inline auto = SvgHelper.svgAttribute "cursor" "auto"
        /// The cursor indicates an alias of something is to be created
        static member inline alias = SvgHelper.svgAttribute "cursor" "alias"
        /// The platform-dependent default cursor. Typically an arrow.
        static member inline defaultCursor = SvgHelper.svgAttribute "cursor" "default"
        /// No cursor is rendered.
        static member inline none = SvgHelper.svgAttribute "cursor" "none"
        /// A context menu is available.
        static member inline contextMenu = SvgHelper.svgAttribute "cursor" "context-menu"
        /// Help information is available.
        static member inline help = SvgHelper.svgAttribute "cursor" "help"
        /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
        static member inline pointer = SvgHelper.svgAttribute "cursor" "pointer"
        /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
        static member inline progress = SvgHelper.svgAttribute "cursor" "progress"
        /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
        static member inline wait = SvgHelper.svgAttribute "cursor" "wait"
        /// The table cell or set of cells can be selected.
        static member inline cell = SvgHelper.svgAttribute "cursor" "cell"
        /// Cross cursor, often used to indicate selection in a bitmap.
        static member inline crosshair = SvgHelper.svgAttribute "cursor" "crosshair"
        /// The text can be selected. Typically the shape of an I-beam.
        static member inline text = SvgHelper.svgAttribute "cursor" "text"
        /// The vertical text can be selected. Typically the shape of a sideways I-beam.
        static member inline verticalText = SvgHelper.svgAttribute "cursor" "vertical-text"
        /// Something is to be copied.
        static member inline copy = SvgHelper.svgAttribute "cursor" "copy"
        /// Something is to be moved.
        static member inline move = SvgHelper.svgAttribute "cursor" "move"
        /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
        static member inline noDrop = SvgHelper.svgAttribute "cursor" "no-drop"
        /// The requested action will not be carried out.
        static member inline notAllowed = SvgHelper.svgAttribute "cursor" "not-allowed"
        /// Something can be grabbed (dragged to be moved).
        static member inline grab = SvgHelper.svgAttribute "cursor" "grab"
        /// Something is being grabbed (dragged to be moved).
        static member inline grabbing = SvgHelper.svgAttribute "cursor" "grabbing"
        /// Something can be scrolled in any direction (panned).
        static member inline allScroll = SvgHelper.svgAttribute "cursor" "all-scroll"
        /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
        static member inline columnResize = SvgHelper.svgAttribute "cursor" "col-resize"
        /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
        static member inline rowResize = SvgHelper.svgAttribute "cursor" "row-resize"
        /// Directional resize arrow
        static member inline northResize = SvgHelper.svgAttribute "cursor" "n-resize"
        /// Directional resize arrow
        static member inline eastResize = SvgHelper.svgAttribute "cursor" "e-resize"
        /// Directional resize arrow
        static member inline southResize = SvgHelper.svgAttribute "cursor" "s-resize"
        /// Directional resize arrow
        static member inline westResize = SvgHelper.svgAttribute "cursor" "w-resize"
        /// Directional resize arrow
        static member inline northEastResize = SvgHelper.svgAttribute "cursor" "ne-resize"
        /// Directional resize arrow
        static member inline northWestResize = SvgHelper.svgAttribute "cursor" "nw-resize"
        /// Directional resize arrow
        static member inline southEastResize = SvgHelper.svgAttribute "cursor" "se-resize"
        /// Directional resize arrow
        static member inline southWestResize = SvgHelper.svgAttribute "cursor" "sw-resize"
        /// Directional resize arrow
        static member inline eastWestResize = SvgHelper.svgAttribute "cursor" "ew-resize"
        /// Directional resize arrow
        static member inline northSouthResize = SvgHelper.svgAttribute "cursor" "ns-resize"
        /// Directional resize arrow
        static member inline northEastSouthWestResize = SvgHelper.svgAttribute "cursor" "nesw-resize"
        /// Directional resize arrow
        static member inline northWestSouthEastResize = SvgHelper.svgAttribute "cursor" "nwse-resize"
        /// Something can be zoomed (magnified) in
        static member inline zoomIn = SvgHelper.svgAttribute "cursor" "zoom-in"
        /// Something can be zoomed out
        static member inline zoomOut = SvgHelper.svgAttribute "cursor" "zoom-out"

    /// Indicates the directionality of the element's text.
    [<Erase>]
    type direction =
        /// Left to right - for languages that are written from left to right.
        static member inline ltr = SvgHelper.svgAttribute "direction" "ltr"
        /// Right to left - for languages that are written from right to left.
        static member inline rtl = SvgHelper.svgAttribute "direction" "rtl"

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
        static member inline alphabetic = SvgHelper.svgAttribute "dominantBaseline" "alphabetic"
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
        static member inline auto = SvgHelper.svgAttribute "dominantBaseline" "auto"
        /// The baseline-identifier for the dominant-baseline is set to be central. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order of
        /// baseline-table names: ideographic, alphabetic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline central = SvgHelper.svgAttribute "dominantBaseline" "central"
        /// The baseline-identifier for the dominant-baseline is set to be hanging, the derived baseline-table is constructed using the
        /// hanging baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size attribute on
        /// this element.
        static member inline hanging = SvgHelper.svgAttribute "dominantBaseline" "hanging"
        /// The baseline-identifier for the dominant-baseline is set to be ideographic, the derived baseline-table is constructed using
        /// the ideographic baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline ideographic = SvgHelper.svgAttribute "dominantBaseline" "ideographic"
        /// The baseline-identifier for the dominant-baseline is set to be mathematical, the derived baseline-table is constructed using
        /// the mathematical baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline mathematical = SvgHelper.svgAttribute "dominantBaseline" "mathematical"
        /// The baseline-identifier for the dominant-baseline is set to be middle. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order
        /// of baseline-table names: alphabetic, ideographic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline middle = SvgHelper.svgAttribute "dominantBaseline" "middle"
        /// The baseline-identifier for the dominant-baseline is set to be text-after-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which font baseline-table to use from the
        /// baseline-tables in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline textAfterEdge = SvgHelper.svgAttribute "dominantBaseline" "text-after-edge"
        /// The baseline-identifier for the dominant-baseline is set to be text-before-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which baseline-table to use from the baseline-tables
        /// in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size attribute on this element.
        static member inline textBeforeEdge = SvgHelper.svgAttribute "dominantBaseline" "text-before-edge"
        /// This value uses the top of the em box as the baseline.
        static member inline textTop = SvgHelper.svgAttribute "dominantBaseline" "text-top"

    /// Indicates the simple duration of an animation.
    [<Erase>]
    type dur =
        /// This value specifies the length of the simple duration.
        static member inline clockValue (duration: System.TimeSpan) =
            PropHelpers.createClockValue(duration)
            |> SvgHelper.svgAttribute "dur"
        /// This value specifies the simple duration as indefinite.
        static member inline indefinite = SvgHelper.svgAttribute "dur" "indefinite"
        /// This value specifies the simple duration as the intrinsic media duration.
        ///
        /// This is only valid for elements that define media.
        static member inline media = SvgHelper.svgAttribute "dur" "media"

    /// Determines how to extend the input image as necessary with color values so
    /// that the matrix operations can be applied when the kernel is positioned at
    /// or near the edge of the input image.
    [<Erase>]
    type edgeMode =
        /// Indicates that the input image is extended along each of its borders as
        /// necessary by duplicating the color values at the given edge of the input image.
        static member inline duplicate = SvgHelper.svgAttribute "edgeMode" "duplicate"
        /// Indicates that the input image is extended with pixel values of zero for
        /// R, G, B and A.
        static member inline none = SvgHelper.svgAttribute "edgeMode" "none"
        /// Indicates that the input image is extended by taking the color values
        /// from the opposite edge of the image.
        static member inline wrap = SvgHelper.svgAttribute "edgeMode" "wrap"

    /// The gradientUnits attribute defines the coordinate system used for attributes specified on the gradient elements. Two elements are using this attribute: <linearGradient> and <radialGradient>
    [<Erase>]
    type gradientUnits =
        static member inline userSpaceOnUse = SvgHelper.svgAttribute "gradientUnits" "userSpaceOnUse"
        static member inline objectBoundingBox = SvgHelper.svgAttribute "gradientUnits" "objectBoundingBox"

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
        static member inline endOfText = SvgHelper.svgAttribute "textAnchor" "end"
        /// The rendered characters are aligned such that the middle of the text
        /// string is at the current text position. (For text on a path,
        /// conceptually the text string is first laid out in a straight line.
        /// The midpoint between the start of the text string and the end of the
        /// text string is determined. Then, the text string is mapped onto the
        /// path with this midpoint placed at the current text position.)
        static member inline middle = SvgHelper.svgAttribute "textAnchor" "middle"
        /// The rendered characters are aligned such that the start of the text
        /// string is at the initial current text position. For an element with
        /// a `direction` property value of `ltr` (typical for most European
        /// languages), the left side of the text is rendered at the initial
        /// text position. For an element with a `direction` property value of
        /// `rtl` (typical for Arabic and Hebrew), the right side of the text is
        /// rendered at the initial text position. For an element with a
        /// vertical primary text direction (often typical for Asian text), the
        /// top side of the text is rendered at the initial text position.
        static member inline startOfText = SvgHelper.svgAttribute "textAnchor" "start"

    [<Erase>]
    type textDecoration =
        static member inline none = SvgHelper.svgAttribute "textDecoration" "none"
        static member inline underline = SvgHelper.svgAttribute "textDecoration" "underline"
        static member inline overline = SvgHelper.svgAttribute "textDecoration" "overline"
        static member inline lineThrough = SvgHelper.svgAttribute "textDecoration" "line-through"

    [<Erase>]
    type transform =
        /// Defines that there should be no transformation.
        static member inline none = SvgHelper.svgAttribute "transform" "none"
        /// Defines a 2D transformation, using a matrix of six values.
        static member inline matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
            SvgHelper.svgAttribute "transform" (
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
            SvgHelper.svgAttribute "transform" (
                "translate(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )

        /// Defines a 3D translation.
        static member inline translate3D(x: int, y: int, z: int) =
            SvgHelper.svgAttribute "transform" (
                "translate3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: int) =
            SvgHelper.svgAttribute "transform" ("translateX(" + (unbox<string> x) + ")")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: int) =
            SvgHelper.svgAttribute "transform" ("translateY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: int) =
            SvgHelper.svgAttribute "transform" ("translateZ(" + (unbox<string> z) + ")")
        /// Defines a 2D scale transformation.
        static member inline scale(x: int, y: int) =
            SvgHelper.svgAttribute "transform" (
                "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )
        /// Defines a scale transformation.
        static member inline scale(n: int) =
            SvgHelper.svgAttribute "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a scale transformation.
        static member inline scale(n: float) =
            SvgHelper.svgAttribute "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a 3D scale transformation
        static member inline scale3D(x: int, y: int, z: int) =
            SvgHelper.svgAttribute "transform" (
                "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a scale transformation by giving a value for the X-axis.
        static member inline scaleX(x: int) =
            SvgHelper.svgAttribute "transform" ("scaleX(" + (unbox<string> x) + ")")

        /// Defines a scale transformation by giving a value for the Y-axis.
        static member inline scaleY(y: int) =
            SvgHelper.svgAttribute "transform" ("scaleY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline scaleZ(z: int) =
            SvgHelper.svgAttribute "transform" ("scaleZ(" + (unbox<string> z) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: int) =
            SvgHelper.svgAttribute "transform" ("rotate(" + (unbox<string> deg) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: float) =
            SvgHelper.svgAttribute "transform" ("rotate(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: float) =
            SvgHelper.svgAttribute "transform" ("rotateX(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: int) =
            SvgHelper.svgAttribute "transform" ("rotateX(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: float) =
            SvgHelper.svgAttribute "transform" ("rotateY(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: int) =
            SvgHelper.svgAttribute "transform" ("rotateY(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: float) =
            SvgHelper.svgAttribute "transform" ("rotateZ(" + (unbox<string> deg) + ")")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: int) =
            SvgHelper.svgAttribute "transform" ("rotateZ(" + (unbox<string> deg) + ")")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: int, yAngle: int) =
            SvgHelper.svgAttribute "transform" ("skew(" + (unbox<string> xAngle) + "," + (unbox<string> yAngle) + ")")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: float, yAngle: float) =
            SvgHelper.svgAttribute "transform" ("skew(" + (unbox<string> xAngle) + "," + (unbox<string> yAngle) + ")")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: int) =
            SvgHelper.svgAttribute "transform" ("skewX(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: float) =
            SvgHelper.svgAttribute "transform" ("skewX(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: int) =
            SvgHelper.svgAttribute "transform" ("skewY(" + (unbox<string> xAngle) + ")")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: float) =
            SvgHelper.svgAttribute "transform" ("skewY(" + (unbox<string> xAngle) + ")")
        /// Defines a perspective view for a 3D transformed element
        static member inline perspective(n: int) =
            SvgHelper.svgAttribute "transform" ("perspective(" + (unbox<string> n) + ")")

    /// Indicates which color channel from in2 to use to displace the pixels in in along the x-axis.
    [<Erase>]
    type xChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the x-axis.
        static member inline A = SvgHelper.svgAttribute "xChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline B = SvgHelper.svgAttribute "xChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline G = SvgHelper.svgAttribute "xChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline R = SvgHelper.svgAttribute "xChannelSelector" "R"

    /// Indicates which color channel from in2 to use to displace the pixels in in along the y-axis.
    [<Erase>]
    type yChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the y-axis.
        static member inline A = SvgHelper.svgAttribute "yChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline B = SvgHelper.svgAttribute "yChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline G = SvgHelper.svgAttribute "yChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline R = SvgHelper.svgAttribute "yChannelSelector" "R"

    [<Erase>]
    type x =
        static member inline percentage(value: float) = SvgHelper.svgAttribute "x" (unbox<string> value + "%")
        static member inline percentage(value: int) = SvgHelper.svgAttribute "x" (unbox<string> value + "%")

    [<Erase>]
    type y =
        static member inline percentage(value: float) = SvgHelper.svgAttribute "y" (unbox<string> value + "%")
        static member inline percentage(value: int) = SvgHelper.svgAttribute "y" (unbox<string> value + "%")
