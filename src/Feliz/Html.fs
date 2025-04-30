namespace Feliz

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open System

[<Erase>]
type Html =
    static member inline a xs = Interop.createElement "a" xs
    static member inline a (children: #seq<ReactElement>) = Interop.reactElementWithChildren "a" children

    static member inline abbr xs = Interop.createElement "abbr" xs
    static member inline abbr (value: float) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: int) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: ReactElement) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: string) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (children: #seq<ReactElement>) = Interop.reactElementWithChildren "abbr" children

    static member inline address xs = Interop.createElement "address" xs
    static member inline address (value: float) = Interop.reactElementWithChild "address" value
    static member inline address (value: int) = Interop.reactElementWithChild "address" value
    static member inline address (value: ReactElement) = Interop.reactElementWithChild "address" value
    static member inline address (value: string) = Interop.reactElementWithChild "address" value
    static member inline address (children: #seq<ReactElement>) = Interop.reactElementWithChildren "address" children

    static member inline anchor xs = Interop.createElement "a" xs
    static member inline anchor (children: #seq<ReactElement>) = Interop.reactElementWithChildren "a" children

    static member inline animate xs = Interop.createElement "animate" xs

    static member inline animateMotion xs = Interop.createElement "animateMotion" xs
    static member inline animateMotion (children: #seq<ReactElement>) = Interop.reactElementWithChildren "animateMotion" children

    static member inline animateTransform xs = Interop.createElement "animateTransform" xs
    static member inline animateTransform (children: #seq<ReactElement>) = Interop.reactElementWithChildren "animateTransform" children

    static member inline area xs = Interop.createElement "area" xs

    static member inline article xs = Interop.createElement "article" xs
    static member inline article (children: #seq<ReactElement>) = Interop.reactElementWithChildren "article" children

    static member inline aside xs = Interop.createElement "aside" xs
    static member inline aside (children: #seq<ReactElement>) = Interop.reactElementWithChildren "aside" children

    static member inline audio xs = Interop.createElement "audio" xs
    static member inline audio (children: #seq<ReactElement>) = Interop.reactElementWithChildren "audio" children

    static member inline b xs = Interop.createElement "b" xs
    static member inline b (value: float) = Interop.reactElementWithChild "b" value
    static member inline b (value: int) = Interop.reactElementWithChild "b" value
    static member inline b (value: ReactElement) = Interop.reactElementWithChild "b" value
    static member inline b (value: string) = Interop.reactElementWithChild "b" value
    static member inline b (children: #seq<ReactElement>) = Interop.reactElementWithChildren "b" children

    static member inline base' xs = Interop.createElement "base" xs

    static member inline bdi xs = Interop.createElement "bdi" xs
    static member inline bdi (value: float) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: int) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: ReactElement) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: string) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (children: #seq<ReactElement>) = Interop.reactElementWithChildren "bdi" children

    static member inline bdo xs = Interop.createElement "bdo" xs
    static member inline bdo (value: float) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: int) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: ReactElement) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: string) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (children: #seq<ReactElement>) = Interop.reactElementWithChildren "bdo" children

    static member inline blockquote xs = Interop.createElement "blockquote" xs
    static member inline blockquote (value: float) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: int) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: ReactElement) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: string) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (children: #seq<ReactElement>) = Interop.reactElementWithChildren "blockquote" children

    static member inline body xs = Interop.createElement "body" xs
    static member inline body (value: float) = Interop.reactElementWithChild "body" value
    static member inline body (value: int) = Interop.reactElementWithChild "body" value
    static member inline body (value: ReactElement) = Interop.reactElementWithChild "body" value
    static member inline body (value: string) = Interop.reactElementWithChild "body" value
    static member inline body (children: #seq<ReactElement>) = Interop.reactElementWithChildren "body" children

    static member inline br xs = Interop.createElement "br" xs

    static member inline button xs = Interop.createElement "button" xs
    static member inline button (children: #seq<ReactElement>) = Interop.reactElementWithChildren "button" children

    static member inline canvas xs = Interop.createElement "canvas" xs

    static member inline caption xs = Interop.createElement "caption" xs
    static member inline caption (value: float) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: int) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: ReactElement) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: string) = Interop.reactElementWithChild "caption" value
    static member inline caption (children: #seq<ReactElement>) = Interop.reactElementWithChildren "caption" children

    static member inline cite xs = Interop.createElement "cite" xs
    static member inline cite (value: float) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: int) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: ReactElement) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: string) = Interop.reactElementWithChild "cite" value
    static member inline cite (children: #seq<ReactElement>) = Interop.reactElementWithChildren "cite" children
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle xs = Interop.createElement "circle" xs
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle (children: #seq<ReactElement>) = Interop.reactElementWithChildren "circle" children
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath xs = Interop.createElement "clipPath" xs
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "clipPath" children

    static member inline code xs = Interop.createElement "code" xs
    static member inline code (value: bool) = Interop.reactElementWithChild "code" value
    static member inline code (value: float) = Interop.reactElementWithChild "code" value
    static member inline code (value: int) = Interop.reactElementWithChild "code" value
    static member inline code (value: ReactElement) = Interop.reactElementWithChild "code" value
    static member inline code (value: string) = Interop.reactElementWithChild "code" value
    static member inline code (children: #seq<ReactElement>) = Interop.reactElementWithChildren "code" children

    static member inline col xs = Interop.createElement "col" xs

    static member inline colgroup xs = Interop.createElement "colgroup" xs
    static member inline colgroup (children: #seq<ReactElement>) = Interop.reactElementWithChildren "colgroup" children

    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: float) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: int) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: string) : ReactElement = unbox value

    static member inline data xs = Interop.createElement "data" xs
    static member inline data (value: float) = Interop.reactElementWithChild "data" value
    static member inline data (value: int) = Interop.reactElementWithChild "data" value
    static member inline data (value: ReactElement) = Interop.reactElementWithChild "data" value
    static member inline data (value: string) = Interop.reactElementWithChild "data" value
    static member inline data (children: #seq<ReactElement>) = Interop.reactElementWithChildren "data" children

    static member inline datalist xs = Interop.createElement "datalist" xs
    static member inline datalist (value: float) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: int) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: ReactElement) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: string) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (children: #seq<ReactElement>) = Interop.reactElementWithChildren "datalist" children

    static member inline dd xs = Interop.createElement "dd" xs
    static member inline dd (value: float) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: int) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: ReactElement) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: string) = Interop.reactElementWithChild "dd" value
    static member inline dd (children: #seq<ReactElement>) = Interop.reactElementWithChildren "dd" children
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs xs = Interop.createElement "defs" xs
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs (children: #seq<ReactElement>) = Interop.reactElementWithChildren "defs" children
    static member inline del xs = Interop.createElement "del" xs
    static member inline del (value: float) = Interop.reactElementWithChild "del" value
    static member inline del (value: int) = Interop.reactElementWithChild "del" value
    static member inline del (value: ReactElement) = Interop.reactElementWithChild "del" value
    static member inline del (value: string) = Interop.reactElementWithChild "del" value
    static member inline del (children: #seq<ReactElement>) = Interop.reactElementWithChildren "del" children

    static member inline details xs = Interop.createElement "details" xs
    static member inline details (children: #seq<ReactElement>) = Interop.reactElementWithChildren "details" children

    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc xs = Interop.createElement "desc" xs
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: float) = Interop.reactElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: int) = Interop.reactElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: string) = Interop.reactElementWithChild "desc" value

    static member inline dfn xs = Interop.createElement "ins" xs
    static member inline dfn (value: float) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: int) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: ReactElement) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: string) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (children: #seq<ReactElement>) = Interop.reactElementWithChildren "dfn" children

    static member inline dialog xs = Interop.createElement "dialog" xs
    static member inline dialog (value: float) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: int) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: ReactElement) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: string) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (children: #seq<ReactElement>) = Interop.reactElementWithChildren "dialog" children

    /// The `<div>` tag defines a division or a section in an HTML document
    static member inline div xs = Interop.createElement "div" xs
    static member inline div (value: float) = Interop.reactElementWithChild "div" value
    static member inline div (value: int) = Interop.reactElementWithChild "div" value
    static member inline div (value: ReactElement) = Interop.reactElementWithChild "div" value
    static member inline div (value: string) = Interop.reactElementWithChild "div" value
    static member inline div (children: #seq<ReactElement>) = Interop.reactElementWithChildren "div" children

    static member inline dl xs = Interop.createElement "dl" xs
    static member inline dl (children: #seq<ReactElement>) = Interop.reactElementWithChildren "dl" children

    static member inline dt xs = Interop.createElement "dt" xs
    static member inline dt (value: float) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: int) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: ReactElement) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: string) = Interop.reactElementWithChild "dt" value
    static member inline dt (children: #seq<ReactElement>) = Interop.reactElementWithChildren "dt" children

    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse xs = Interop.createElement "ellipse" xs
    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ellipse" children

    static member inline em xs = Interop.createElement "em" xs
    static member inline em (value: float) = Interop.reactElementWithChild "em" value
    static member inline em (value: int) = Interop.reactElementWithChild "em" value
    static member inline em (value: ReactElement) = Interop.reactElementWithChild "em" value
    static member inline em (value: string) = Interop.reactElementWithChild "em" value
    static member inline em (children: #seq<ReactElement>) = Interop.reactElementWithChildren "em" children

    static member inline embed xs = Interop.createElement "embed" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend xs = Interop.createElement "feBlend" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feBlend" children
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix xs = Interop.createElement "feColorMatrix" xs
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feColorMatrix" children
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer xs = Interop.createElement "feComponentTransfer" xs
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feComponentTransfer" children
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite xs = Interop.createElement "feComposite" xs
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feComposite" children
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix xs = Interop.createElement "feConvolveMatrix" xs
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feConvolveMatrix" children
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting xs = Interop.createElement "feDiffuseLighting" xs
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDiffuseLighting" children
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap xs = Interop.createElement "feDisplacementMap" xs
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDisplacementMap" children
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight xs = Interop.createElement "feDistantLight" xs
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDistantLight" children
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow xs = Interop.createElement "feDropShadow" xs
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feDropShadow" children
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood xs = Interop.createElement "feFlood" xs
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFlood" children
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA xs = Interop.createElement "feFuncA" xs
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncA" children
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB xs = Interop.createElement "feFuncB" xs
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncB" children
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG xs = Interop.createElement "feFuncG" xs
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncG" children
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR xs = Interop.createElement "feFuncR" xs
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feFuncR" children
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur xs = Interop.createElement "feGaussianBlur" xs
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feGaussianBlur" children
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage xs = Interop.createElement "feImage" xs
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feImage" children
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge xs = Interop.createElement "feMerge" xs
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMerge" children
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode xs = Interop.createElement "feMergeNode" xs
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMergeNode" children
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology xs = Interop.createElement "feMorphology" xs
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feMorphology" children
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset xs = Interop.createElement "feOffset" xs
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feOffset" children
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight xs = Interop.createElement "fePointLight" xs
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "fePointLight" children
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting xs = Interop.createElement "feSpecularLighting" xs
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feSpecularLighting" children
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight xs = Interop.createElement "feSpotLight" xs
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feSpotLight" children
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile xs = Interop.createElement "feTile" xs
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feTile" children
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence xs = Interop.createElement "feTurbulence" xs
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence (children: #seq<ReactElement>) = Interop.reactElementWithChildren "feTurbulence" children
    static member inline fieldSet xs = Interop.createElement "fieldset" xs
    static member inline fieldSet (children: #seq<ReactElement>) = Interop.reactElementWithChildren "fieldset" children

    static member inline figcaption xs = Interop.createElement "figcaption" xs
    static member inline figcaption (children: #seq<ReactElement>) = Interop.reactElementWithChildren "figcaption" children

    static member inline figure xs = Interop.createElement "figure" xs
    static member inline figure (children: #seq<ReactElement>) = Interop.reactElementWithChildren "figure" children
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter xs = Interop.createElement "filter" xs
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter (children: #seq<ReactElement>) = Interop.reactElementWithChildren "filter" children

    static member inline footer xs = Interop.createElement "footer" xs
    static member inline footer (children: #seq<ReactElement>) = Interop.reactElementWithChildren "footer" children
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject xs = Interop.createElement "foreignObject" xs
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject (children: #seq<ReactElement>) = Interop.reactElementWithChildren "foreignObject" children

    static member inline form xs = Interop.createElement "form" xs
    static member inline form (children: #seq<ReactElement>) = Interop.reactElementWithChildren "form" children

    // [<Obsolete("Html.fragment is obsolete, use React.fragment instead. This function will be removed in the coming v1.0 release")>]
    // static member inline fragment xs = Fable.React.Helpers.fragment [] xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g xs = Interop.createElement "g" xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g (children: #seq<ReactElement>) = Interop.reactElementWithChildren "g" children

    static member inline h1 xs = Interop.createElement "h1" xs
    static member inline h1 (value: float) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: int) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: ReactElement) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: string) = Interop.reactElementWithChild "h1" value
    static member inline h1 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h1" children
    static member inline h2 xs = Interop.createElement "h2" xs
    static member inline h2 (value: float) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: int) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: ReactElement) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: string) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h2" children

    static member inline h3 xs = Interop.createElement "h3" xs
    static member inline h3 (value: float) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: int) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: ReactElement) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: string) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h3" children

    static member inline h4 xs = Interop.createElement "h4" xs
    static member inline h4 (value: float) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: int) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: ReactElement) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: string) = Interop.reactElementWithChild "h4" value
    static member inline h4 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h4" children

    static member inline h5 xs = Interop.createElement "h5" xs
    static member inline h5 (value: float) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: int) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: ReactElement) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: string) = Interop.reactElementWithChild "h5" value
    static member inline h5 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h5" children

    static member inline h6 xs = Interop.createElement "h6" xs
    static member inline h6 (value: float) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: int) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: ReactElement) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: string) = Interop.reactElementWithChild "h6" value
    static member inline h6 (children: #seq<ReactElement>) = Interop.reactElementWithChildren "h6" children

    static member inline head xs = Interop.createElement "head" xs
    static member inline head (children: #seq<ReactElement>) = Interop.reactElementWithChildren "head" children

    static member inline header xs = Interop.createElement "header" xs
    static member inline header (children: #seq<ReactElement>) = Interop.reactElementWithChildren "header" children

    static member inline hr xs = Interop.createElement "hr" xs

    static member inline html xs = Interop.createElement "html" xs
    static member inline html (children: #seq<ReactElement>) = Interop.reactElementWithChildren "html" children

    static member inline i xs = Interop.createElement "i" xs
    static member inline i (value: float) = Interop.reactElementWithChild "i" value
    static member inline i (value: int) = Interop.reactElementWithChild "i" value
    static member inline i (value: ReactElement) = Interop.reactElementWithChild "i" value
    static member inline i (value: string) = Interop.reactElementWithChild "i" value
    static member inline i (children: #seq<ReactElement>) = Interop.reactElementWithChildren "i" children

    static member inline iframe xs = Interop.createElement "iframe" xs

    static member inline img xs = Interop.createElement "img" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image xs = Interop.createElement "image" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image (children: #seq<ReactElement>) = Interop.reactElementWithChildren "image" children

    static member inline input xs = Interop.createElement "input" xs

    static member inline ins xs = Interop.createElement "ins" xs
    static member inline ins (value: float) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: int) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: ReactElement) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: string) = Interop.reactElementWithChild "ins" value
    static member inline ins (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ins" children

    static member inline kbd xs = Interop.createElement "kbd" xs
    static member inline kbd (value: float) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: int) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: ReactElement) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: string) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (children: #seq<ReactElement>) = Interop.reactElementWithChildren "kbd" children

    static member inline label xs = Interop.createElement "label" xs
    static member inline label (children: #seq<ReactElement>) = Interop.reactElementWithChildren "label" children

    static member inline legend xs = Interop.createElement "legend" xs
    static member inline legend (value: float) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: int) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: ReactElement) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: string) = Interop.reactElementWithChild "legend" value
    static member inline legend (children: #seq<ReactElement>) = Interop.reactElementWithChildren "legend" children

    static member inline li xs = Interop.createElement "li" xs
    static member inline li (value: float) = Interop.reactElementWithChild "li" value
    static member inline li (value: int) = Interop.reactElementWithChild "li" value
    static member inline li (value: ReactElement) = Interop.reactElementWithChild "li" value
    static member inline li (value: string) = Interop.reactElementWithChild "li" value
    static member inline li (children: #seq<ReactElement>) = Interop.reactElementWithChildren "li" children
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line xs = Interop.createElement "line" xs
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line (children: #seq<ReactElement>) = Interop.reactElementWithChildren "line" children
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient xs = Interop.createElement "linearGradient" xs
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient (children: #seq<ReactElement>) = Interop.reactElementWithChildren "linearGradient" children

    static member inline link xs = Interop.createElement "link" xs

    static member inline listItem xs = Interop.createElement "li" xs
    static member inline listItem (value: float) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: int) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: ReactElement) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: string) = Interop.reactElementWithChild "li" value
    static member inline listItem (children: #seq<ReactElement>) = Interop.reactElementWithChildren "li" children

    static member inline main xs = Interop.createElement "main" xs
    static member inline main (children: #seq<ReactElement>) = Interop.reactElementWithChildren "main" children

    static member inline map xs = Interop.createElement "map" xs
    static member inline map (children: #seq<ReactElement>) = Interop.reactElementWithChildren "map" children

    static member inline mark xs = Interop.createElement "mark" xs
    static member inline mark (value: float) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: int) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: ReactElement) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: string) = Interop.reactElementWithChild "mark" value
    static member inline mark (children: #seq<ReactElement>) = Interop.reactElementWithChildren "mark" children
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker xs = Interop.createElement "marker" xs
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker (children: #seq<ReactElement>) = Interop.reactElementWithChildren "marker" children
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask xs = Interop.createElement "mask" xs
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask (children: #seq<ReactElement>) = Interop.reactElementWithChildren "mask" children

    static member inline meta xs = Interop.createElement "meta" xs

    static member inline metadata xs = Interop.createElement "metadata" xs
    static member inline metadata (children: #seq<ReactElement>) = Interop.reactElementWithChildren "metadata" children

    static member inline meter xs = Interop.createElement "meter" xs
    static member inline meter (value: float) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: int) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: ReactElement) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: string) = Interop.reactElementWithChild "meter" value
    static member inline meter (children: #seq<ReactElement>) = Interop.reactElementWithChildren "meter" children
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath xs = Interop.createElement "mpath" xs
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "mpath" children
    static member inline nav xs = Interop.createElement "nav" xs
    static member inline nav (children: #seq<ReactElement>) = Interop.reactElementWithChildren "nav" children

    /// The empty element, renders nothing on screen
    static member inline none : ReactElement = unbox null

    static member inline noscript xs = Interop.createElement "noscript" xs
    static member inline noscript (children: #seq<ReactElement>) = Interop.reactElementWithChildren "noscript" children

    static member inline object xs = Interop.createElement "object" xs
    static member inline object (children: #seq<ReactElement>) = Interop.reactElementWithChildren "object" children

    static member inline ol xs = Interop.createElement "ol" xs
    static member inline ol (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ol" children

    static member inline option xs = Interop.createElement "option" xs
    static member inline option (value: float) = Interop.reactElementWithChild "option" value
    static member inline option (value: int) = Interop.reactElementWithChild "option" value
    static member inline option (value: ReactElement) = Interop.reactElementWithChild "option" value
    static member inline option (value: string) = Interop.reactElementWithChild "option" value
    static member inline option (children: #seq<ReactElement>) = Interop.reactElementWithChildren "option" children

    static member inline optgroup xs = Interop.createElement "optgroup" xs
    static member inline optgroup (children: #seq<ReactElement>) = Interop.reactElementWithChildren "optgroup" children

    static member inline orderedList xs = Interop.createElement "ol" xs
    static member inline orderedList (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ol" children

    static member inline output xs = Interop.createElement "output" xs
    static member inline output (value: float) = Interop.reactElementWithChild "output" value
    static member inline output (value: int) = Interop.reactElementWithChild "output" value
    static member inline output (value: ReactElement) = Interop.reactElementWithChild "output" value
    static member inline output (value: string) = Interop.reactElementWithChild "output" value
    static member inline output (children: #seq<ReactElement>) = Interop.reactElementWithChildren "output" children

    static member inline p xs = Interop.createElement "p" xs
    static member inline p (value: float) = Interop.reactElementWithChild "p" value
    static member inline p (value: int) = Interop.reactElementWithChild "p" value
    static member inline p (value: ReactElement) = Interop.reactElementWithChild "p" value
    static member inline p (value: string) = Interop.reactElementWithChild "p" value
    static member inline p (children: #seq<ReactElement>) = Interop.reactElementWithChildren "p" children

    static member inline paragraph xs = Interop.createElement "p" xs
    static member inline paragraph (value: float) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: int) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: ReactElement) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: string) = Interop.reactElementWithChild "p" value
    static member inline paragraph (children: #seq<ReactElement>) = Interop.reactElementWithChildren "p" children

    static member inline param xs = Interop.createElement "param" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path xs = Interop.createElement "path" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path (children: #seq<ReactElement>) = Interop.reactElementWithChildren "path" children
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern xs = Interop.createElement "pattern" xs
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern (children: #seq<ReactElement>) = Interop.reactElementWithChildren "pattern" children
    static member inline picture xs = Interop.createElement "picture" xs
    static member inline picture (children: #seq<ReactElement>) = Interop.reactElementWithChildren "picture" children
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon xs = Interop.createElement "polygon" xs
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon (children: #seq<ReactElement>) = Interop.reactElementWithChildren "polygon" children
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline xs = Interop.createElement "polyline" xs
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline (children: #seq<ReactElement>) = Interop.reactElementWithChildren "polyline" children
    static member inline pre xs = Interop.createElement "pre" xs
    static member inline pre (value: bool) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: float) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: int) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: ReactElement) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: string) = Interop.reactElementWithChild "pre" value
    static member inline pre (children: #seq<ReactElement>) = Interop.reactElementWithChildren "pre" children

    static member inline progress xs = Interop.createElement "progress" xs
    static member inline progress (children: #seq<ReactElement>) = Interop.reactElementWithChildren "progress" children

    static member inline q xs = Interop.createElement "q" xs
    static member inline q (children: #seq<ReactElement>) = Interop.reactElementWithChildren "q" children
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient xs = Interop.createElement "radialGradient" xs
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient (children: #seq<ReactElement>) = Interop.reactElementWithChildren "radialGradient" children

    static member inline rb xs = Interop.createElement "rb" xs
    static member inline rb (value: float) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: int) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: ReactElement) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: string) = Interop.reactElementWithChild "rb" value
    static member inline rb (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rb" children
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect xs = Interop.createElement "rect" xs
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rect" children

    static member inline rp xs = Interop.createElement "rp" xs
    static member inline rp (value: float) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: int) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: ReactElement) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: string) = Interop.reactElementWithChild "rp" value
    static member inline rp (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rp" children

    static member inline rt xs = Interop.createElement "rt" xs
    static member inline rt (value: float) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: int) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: ReactElement) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: string) = Interop.reactElementWithChild "rt" value
    static member inline rt (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rt" children

    static member inline rtc xs = Interop.createElement "rtc" xs
    static member inline rtc (value: float) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: int) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: ReactElement) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: string) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (children: #seq<ReactElement>) = Interop.reactElementWithChildren "rtc" children

    static member inline ruby xs = Interop.createElement "ruby" xs
    static member inline ruby (value: float) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: int) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: ReactElement) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: string) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ruby" children

    static member inline s xs = Interop.createElement "s" xs
    static member inline s (value: float) = Interop.reactElementWithChild "s" value
    static member inline s (value: int) = Interop.reactElementWithChild "s" value
    static member inline s (value: ReactElement) = Interop.reactElementWithChild "s" value
    static member inline s (value: string) = Interop.reactElementWithChild "s" value
    static member inline s (children: #seq<ReactElement>) = Interop.reactElementWithChildren "s" children

    static member inline samp xs = Interop.createElement "samp" xs
    static member inline samp (value: float) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: int) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: ReactElement) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: string) = Interop.reactElementWithChild "samp" value
    static member inline samp (children: #seq<ReactElement>) = Interop.reactElementWithChildren "samp" children

    static member inline script xs = Interop.createElement "script" xs
    static member inline script (children: #seq<ReactElement>) = Interop.reactElementWithChildren "script" children

    static member inline section xs = Interop.createElement "section" xs
    static member inline section (children: #seq<ReactElement>) = Interop.reactElementWithChildren "section" children

    static member inline select xs = Interop.createElement "select" xs
    static member inline select (children: #seq<ReactElement>) = Interop.reactElementWithChildren "select" children
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set xs = Interop.createElement "set" xs
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set (children: #seq<ReactElement>) = Interop.reactElementWithChildren "set" children

    static member inline small xs = Interop.createElement "small" xs
    static member inline small (value: float) = Interop.reactElementWithChild "small" value
    static member inline small (value: int) = Interop.reactElementWithChild "small" value
    static member inline small (value: ReactElement) = Interop.reactElementWithChild "small" value
    static member inline small (value: string) = Interop.reactElementWithChild "small" value
    static member inline small (children: #seq<ReactElement>) = Interop.reactElementWithChildren "small" children

    static member inline source xs = Interop.createElement "source" xs

    static member inline span xs = Interop.createElement "span" xs
    static member inline span (value: float) = Interop.reactElementWithChild "span" value
    static member inline span (value: int) = Interop.reactElementWithChild "span" value
    static member inline span (value: ReactElement) = Interop.reactElementWithChild "span" value
    static member inline span (value: string) = Interop.reactElementWithChild "span" value
    static member inline span (children: #seq<ReactElement>) = Interop.reactElementWithChildren "span" children
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop xs = Interop.createElement "stop" xs
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop (children: #seq<ReactElement>) = Interop.reactElementWithChildren "stop" children

    static member inline strong xs = Interop.createElement "strong" xs
    static member inline strong (value: float) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: int) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: ReactElement) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: string) = Interop.reactElementWithChild "strong" value
    static member inline strong (children: #seq<ReactElement>) = Interop.reactElementWithChildren "strong" children

    static member inline style xs = Interop.createElement "style" xs
    static member inline style (value: string) = Interop.reactElementWithChild "style" value

    static member inline sub xs = Interop.createElement "sub" xs
    static member inline sub (value: float) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: int) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: ReactElement) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: string) = Interop.reactElementWithChild "sub" value
    static member inline sub (children: #seq<ReactElement>) = Interop.reactElementWithChildren "sub" children

    static member inline summary xs = Interop.createElement "summary" xs
    static member inline summary (value: float) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: int) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: ReactElement) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: string) = Interop.reactElementWithChild "summary" value
    static member inline summary (children: #seq<ReactElement>) = Interop.reactElementWithChildren "summary" children

    static member inline sup xs = Interop.createElement "sup" xs
    static member inline sup (value: float) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: int) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: ReactElement) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: string) = Interop.reactElementWithChild "sup" value
    static member inline sup (children: #seq<ReactElement>) = Interop.reactElementWithChildren "sup" children

    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg xs = Interop.createElement "svg" xs
    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg (children: #seq<ReactElement>) = Interop.reactElementWithChildren "svg" children
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch xs = Interop.createElement "switch" xs
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch (children: #seq<ReactElement>) = Interop.reactElementWithChildren "switch" children
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol xs = Interop.createElement "symbol" xs
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol (children: #seq<ReactElement>) = Interop.reactElementWithChildren "symbol" children

    static member inline table xs = Interop.createElement "table" xs
    static member inline table (children: #seq<ReactElement>) = Interop.reactElementWithChildren "table" children

    static member inline tableBody xs = Interop.createElement "tbody" xs
    static member inline tableBody (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tbody" children

    static member inline tableCell xs = Interop.createElement "td" xs
    static member inline tableCell (children: #seq<ReactElement>) = Interop.reactElementWithChildren "td" children

    static member inline tableHeader xs = Interop.createElement "th" xs
    static member inline tableHeader (children: #seq<ReactElement>) = Interop.reactElementWithChildren "th" children

    static member inline tableRow xs = Interop.createElement "tr" xs
    static member inline tableRow (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tr" children

    static member inline tbody xs = Interop.createElement "tbody" xs
    static member inline tbody (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tbody" children

    static member inline td xs = Interop.createElement "td" xs
    static member inline td (value: float) = Interop.reactElementWithChild "td" value
    static member inline td (value: int) = Interop.reactElementWithChild "td" value
    static member inline td (value: ReactElement) = Interop.reactElementWithChild "td" value
    static member inline td (value: string) = Interop.reactElementWithChild "td" value
    static member inline td (children: #seq<ReactElement>) = Interop.reactElementWithChildren "td" children

    static member inline template xs = Interop.createElement "template" xs
    static member inline template (children: #seq<ReactElement>) = Interop.reactElementWithChildren "template" children

    [<Obsolete "Html.text is obsolete for creating <text> SVG elements. Use Svg.text instead">]
    static member inline text xs = Interop.createElement "text" xs
    static member inline text (value: float) : ReactElement = unbox value
    static member inline text (value: int) : ReactElement = unbox value
    static member inline text (value: string) : ReactElement = unbox value
    static member inline text (value: System.Guid) : ReactElement = unbox (string value)

    static member inline textf fmt = Printf.kprintf Html.text fmt

    static member inline textarea xs = Interop.createElement "textarea" xs
    static member inline textarea (children: #seq<ReactElement>) = Interop.reactElementWithChildren "textarea" children
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath xs = Interop.createElement "textPath" xs
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath (children: #seq<ReactElement>) = Interop.reactElementWithChildren "textPath" children

    static member inline tfoot xs = Interop.createElement "tfoot" xs
    static member inline tfoot (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tfoot" children

    static member inline th xs = Interop.createElement "th" xs
    static member inline th (value: float) = Interop.reactElementWithChild "th" value
    static member inline th (value: int) = Interop.reactElementWithChild "th" value
    static member inline th (value: ReactElement) = Interop.reactElementWithChild "th" value
    static member inline th (value: string) = Interop.reactElementWithChild "th" value
    static member inline th (children: #seq<ReactElement>) = Interop.reactElementWithChildren "th" children

    static member inline thead xs = Interop.createElement "thead" xs
    static member inline thead (children: #seq<ReactElement>) = Interop.reactElementWithChildren "thead" children

    static member inline time xs = Interop.createElement "time" xs
    static member inline time (children: #seq<ReactElement>) = Interop.reactElementWithChildren "time" children
    static member inline title xs = Interop.createElement "title" xs
    static member inline title (value: float) = Interop.reactElementWithChild "title" value
    static member inline title (value: int) = Interop.reactElementWithChild "title" value
    static member inline title (value: ReactElement) = Interop.reactElementWithChild "title" value
    static member inline title (value: string) = Interop.reactElementWithChild "title" value
    static member inline title (children: #seq<ReactElement>) = Interop.reactElementWithChildren "title" children
    static member inline tr xs = Interop.createElement "tr" xs
    static member inline tr (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tr" children

    static member inline track xs = Interop.createElement "track" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan xs = Interop.createElement "tspan" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan (children: #seq<ReactElement>) = Interop.reactElementWithChildren "tspan" children

    static member inline u xs = Interop.createElement "u" xs
    static member inline u (value: float) = Interop.reactElementWithChild "u" value
    static member inline u (value: int) = Interop.reactElementWithChild "u" value
    static member inline u (value: ReactElement) = Interop.reactElementWithChild "u" value
    static member inline u (value: string) = Interop.reactElementWithChild "u" value
    static member inline u (children: #seq<ReactElement>) = Interop.reactElementWithChildren "u" children

    static member inline ul xs = Interop.createElement "ul" xs
    static member inline ul (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ul" children

    static member inline unorderedList xs = Interop.createElement "ul" xs
    static member inline unorderedList (children: #seq<ReactElement>) = Interop.reactElementWithChildren "ul" children
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' xs = Interop.createElement "use" xs
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' (children: #seq<ReactElement>) = Interop.reactElementWithChildren "use" children
    static member inline var xs = Interop.createElement "var" xs
    static member inline var (value: float) = Interop.reactElementWithChild "var" value
    static member inline var (value: int) = Interop.reactElementWithChild "var" value
    static member inline var (value: ReactElement) = Interop.reactElementWithChild "var" value
    static member inline var (value: string) = Interop.reactElementWithChild "var" value
    static member inline var (children: #seq<ReactElement>) = Interop.reactElementWithChildren "var" children

    static member inline video xs = Interop.createElement "video" xs
    static member inline video (children: #seq<ReactElement>) = Interop.reactElementWithChildren "video" children
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view xs = Interop.createElement "view" xs
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view (children: #seq<ReactElement>) = Interop.reactElementWithChildren "view" children

    static member inline wbr xs = Interop.createElement "wbr" xs
