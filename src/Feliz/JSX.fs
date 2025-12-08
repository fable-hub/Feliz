namespace Feliz.JSX

open Fable.Core
open Fable.Core.JsInterop
open System
open Feliz

module JSXHelper =
    let inline createElementWithChild (tag: string) (children: obj) : ReactElement =
        JSX.create tag ["children" ==> children] |> unbox

    let inline createElement (name: string) (props: IReactProperty list) : ReactElement =
        JSX.create name !!props |> unbox

open System.Diagnostics.CodeAnalysis

[<Erase>]
type Html =

    static member inline jsx ([<StringSyntax("jsx")>] template: string) : ReactElement = JSX.jsx template |> unbox
    static member inline a xs = JSXHelper.createElement "a" xs
    static member inline a (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "a" children

    static member inline abbr xs = JSXHelper.createElement "abbr" xs
    static member inline abbr (value: float) = JSXHelper.createElementWithChild "abbr" value
    static member inline abbr (value: int) = JSXHelper.createElementWithChild "abbr" value
    static member inline abbr (value: ReactElement) = JSXHelper.createElementWithChild "abbr" value
    static member inline abbr (value: string) = JSXHelper.createElementWithChild "abbr" value
    static member inline abbr (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "abbr" children

    static member inline address xs = JSXHelper.createElement "address" xs
    static member inline address (value: float) = JSXHelper.createElementWithChild "address" value
    static member inline address (value: int) = JSXHelper.createElementWithChild "address" value
    static member inline address (value: ReactElement) = JSXHelper.createElementWithChild "address" value
    static member inline address (value: string) = JSXHelper.createElementWithChild "address" value
    static member inline address (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "address" children

    static member inline anchor xs = JSXHelper.createElement "a" xs
    static member inline anchor (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "a" children

    static member inline animate xs = JSXHelper.createElement "animate" xs

    static member inline animateMotion xs = JSXHelper.createElement "animateMotion" xs
    static member inline animateMotion (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "animateMotion" children

    static member inline animateTransform xs = JSXHelper.createElement "animateTransform" xs
    static member inline animateTransform (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "animateTransform" children

    static member inline area xs = JSXHelper.createElement "area" xs

    static member inline article xs = JSXHelper.createElement "article" xs
    static member inline article (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "article" children

    static member inline aside xs = JSXHelper.createElement "aside" xs
    static member inline aside (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "aside" children

    static member inline audio xs = JSXHelper.createElement "audio" xs
    static member inline audio (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "audio" children

    static member inline b xs = JSXHelper.createElement "b" xs
    static member inline b (value: float) = JSXHelper.createElementWithChild "b" value
    static member inline b (value: int) = JSXHelper.createElementWithChild "b" value
    static member inline b (value: ReactElement) = JSXHelper.createElementWithChild "b" value
    static member inline b (value: string) = JSXHelper.createElementWithChild "b" value
    static member inline b (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "b" children

    static member inline base' xs = JSXHelper.createElement "base" xs

    static member inline bdi xs = JSXHelper.createElement "bdi" xs
    static member inline bdi (value: float) = JSXHelper.createElementWithChild "bdi" value
    static member inline bdi (value: int) = JSXHelper.createElementWithChild "bdi" value
    static member inline bdi (value: ReactElement) = JSXHelper.createElementWithChild "bdi" value
    static member inline bdi (value: string) = JSXHelper.createElementWithChild "bdi" value
    static member inline bdi (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "bdi" children

    static member inline bdo xs = JSXHelper.createElement "bdo" xs
    static member inline bdo (value: float) = JSXHelper.createElementWithChild "bdo" value
    static member inline bdo (value: int) = JSXHelper.createElementWithChild "bdo" value
    static member inline bdo (value: ReactElement) = JSXHelper.createElementWithChild "bdo" value
    static member inline bdo (value: string) = JSXHelper.createElementWithChild "bdo" value
    static member inline bdo (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "bdo" children

    static member inline blockquote xs = JSXHelper.createElement "blockquote" xs
    static member inline blockquote (value: float) = JSXHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: int) = JSXHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: ReactElement) = JSXHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: string) = JSXHelper.createElementWithChild "blockquote" value
    static member inline blockquote (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "blockquote" children

    static member inline body xs = JSXHelper.createElement "body" xs
    static member inline body (value: float) = JSXHelper.createElementWithChild "body" value
    static member inline body (value: int) = JSXHelper.createElementWithChild "body" value
    static member inline body (value: ReactElement) = JSXHelper.createElementWithChild "body" value
    static member inline body (value: string) = JSXHelper.createElementWithChild "body" value
    static member inline body (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "body" children

    static member inline br xs = JSXHelper.createElement "br" xs

    static member inline button xs = JSXHelper.createElement "button" xs
    static member inline button (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "button" children

    static member inline canvas xs = JSXHelper.createElement "canvas" xs

    static member inline caption xs = JSXHelper.createElement "caption" xs
    static member inline caption (value: float) = JSXHelper.createElementWithChild "caption" value
    static member inline caption (value: int) = JSXHelper.createElementWithChild "caption" value
    static member inline caption (value: ReactElement) = JSXHelper.createElementWithChild "caption" value
    static member inline caption (value: string) = JSXHelper.createElementWithChild "caption" value
    static member inline caption (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "caption" children

    static member inline cite xs = JSXHelper.createElement "cite" xs
    static member inline cite (value: float) = JSXHelper.createElementWithChild "cite" value
    static member inline cite (value: int) = JSXHelper.createElementWithChild "cite" value
    static member inline cite (value: ReactElement) = JSXHelper.createElementWithChild "cite" value
    static member inline cite (value: string) = JSXHelper.createElementWithChild "cite" value
    static member inline cite (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "cite" children
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle xs = JSXHelper.createElement "circle" xs
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "circle" children
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath xs = JSXHelper.createElement "clipPath" xs
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "clipPath" children

    static member inline code xs = JSXHelper.createElement "code" xs
    static member inline code (value: bool) = JSXHelper.createElementWithChild "code" value
    static member inline code (value: float) = JSXHelper.createElementWithChild "code" value
    static member inline code (value: int) = JSXHelper.createElementWithChild "code" value
    static member inline code (value: ReactElement) = JSXHelper.createElementWithChild "code" value
    static member inline code (value: string) = JSXHelper.createElementWithChild "code" value
    static member inline code (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "code" children

    static member inline col xs = JSXHelper.createElement "col" xs

    static member inline colgroup xs = JSXHelper.createElement "colgroup" xs
    static member inline colgroup (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "colgroup" children

    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: float) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: int) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: string) : ReactElement = unbox value

    static member inline data xs = JSXHelper.createElement "data" xs
    static member inline data (value: float) = JSXHelper.createElementWithChild "data" value
    static member inline data (value: int) = JSXHelper.createElementWithChild "data" value
    static member inline data (value: ReactElement) = JSXHelper.createElementWithChild "data" value
    static member inline data (value: string) = JSXHelper.createElementWithChild "data" value
    static member inline data (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "data" children

    static member inline datalist xs = JSXHelper.createElement "datalist" xs
    static member inline datalist (value: float) = JSXHelper.createElementWithChild "datalist" value
    static member inline datalist (value: int) = JSXHelper.createElementWithChild "datalist" value
    static member inline datalist (value: ReactElement) = JSXHelper.createElementWithChild "datalist" value
    static member inline datalist (value: string) = JSXHelper.createElementWithChild "datalist" value
    static member inline datalist (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "datalist" children

    static member inline dd xs = JSXHelper.createElement "dd" xs
    static member inline dd (value: float) = JSXHelper.createElementWithChild "dd" value
    static member inline dd (value: int) = JSXHelper.createElementWithChild "dd" value
    static member inline dd (value: ReactElement) = JSXHelper.createElementWithChild "dd" value
    static member inline dd (value: string) = JSXHelper.createElementWithChild "dd" value
    static member inline dd (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "dd" children
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs xs = JSXHelper.createElement "defs" xs
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "defs" children
    static member inline del xs = JSXHelper.createElement "del" xs
    static member inline del (value: float) = JSXHelper.createElementWithChild "del" value
    static member inline del (value: int) = JSXHelper.createElementWithChild "del" value
    static member inline del (value: ReactElement) = JSXHelper.createElementWithChild "del" value
    static member inline del (value: string) = JSXHelper.createElementWithChild "del" value
    static member inline del (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "del" children

    static member inline details xs = JSXHelper.createElement "details" xs
    static member inline details (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "details" children

    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc xs = JSXHelper.createElement "desc" xs
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: float) = JSXHelper.createElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: int) = JSXHelper.createElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: string) = JSXHelper.createElementWithChild "desc" value

    static member inline dfn xs = JSXHelper.createElement "ins" xs
    static member inline dfn (value: float) = JSXHelper.createElementWithChild "dfn" value
    static member inline dfn (value: int) = JSXHelper.createElementWithChild "dfn" value
    static member inline dfn (value: ReactElement) = JSXHelper.createElementWithChild "dfn" value
    static member inline dfn (value: string) = JSXHelper.createElementWithChild "dfn" value
    static member inline dfn (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "dfn" children

    static member inline dialog xs = JSXHelper.createElement "dialog" xs
    static member inline dialog (value: float) = JSXHelper.createElementWithChild "dialog" value
    static member inline dialog (value: int) = JSXHelper.createElementWithChild "dialog" value
    static member inline dialog (value: ReactElement) = JSXHelper.createElementWithChild "dialog" value
    static member inline dialog (value: string) = JSXHelper.createElementWithChild "dialog" value
    static member inline dialog (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "dialog" children

    /// The `<div>` tag defines a division or a section in an HTML document
    static member inline div xs = JSXHelper.createElement "div" xs
    static member inline div (value: float) = JSXHelper.createElementWithChild "div" value
    static member inline div (value: int) = JSXHelper.createElementWithChild "div" value
    static member inline div (value: ReactElement) = JSXHelper.createElementWithChild "div" value
    static member inline div (value: string) = JSXHelper.createElementWithChild "div" value
    static member inline div (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "div" children

    static member inline dl xs = JSXHelper.createElement "dl" xs
    static member inline dl (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "dl" children

    static member inline dt xs = JSXHelper.createElement "dt" xs
    static member inline dt (value: float) = JSXHelper.createElementWithChild "dt" value
    static member inline dt (value: int) = JSXHelper.createElementWithChild "dt" value
    static member inline dt (value: ReactElement) = JSXHelper.createElementWithChild "dt" value
    static member inline dt (value: string) = JSXHelper.createElementWithChild "dt" value
    static member inline dt (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "dt" children

    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse xs = JSXHelper.createElement "ellipse" xs
    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ellipse" children

    static member inline em xs = JSXHelper.createElement "em" xs
    static member inline em (value: float) = JSXHelper.createElementWithChild "em" value
    static member inline em (value: int) = JSXHelper.createElementWithChild "em" value
    static member inline em (value: ReactElement) = JSXHelper.createElementWithChild "em" value
    static member inline em (value: string) = JSXHelper.createElementWithChild "em" value
    static member inline em (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "em" children

    static member inline embed xs = JSXHelper.createElement "embed" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend xs = JSXHelper.createElement "feBlend" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feBlend" children
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix xs = JSXHelper.createElement "feColorMatrix" xs
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feColorMatrix" children
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer xs = JSXHelper.createElement "feComponentTransfer" xs
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feComponentTransfer" children
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite xs = JSXHelper.createElement "feComposite" xs
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feComposite" children
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix xs = JSXHelper.createElement "feConvolveMatrix" xs
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feConvolveMatrix" children
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting xs = JSXHelper.createElement "feDiffuseLighting" xs
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feDiffuseLighting" children
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap xs = JSXHelper.createElement "feDisplacementMap" xs
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feDisplacementMap" children
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight xs = JSXHelper.createElement "feDistantLight" xs
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feDistantLight" children
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow xs = JSXHelper.createElement "feDropShadow" xs
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feDropShadow" children
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood xs = JSXHelper.createElement "feFlood" xs
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feFlood" children
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA xs = JSXHelper.createElement "feFuncA" xs
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feFuncA" children
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB xs = JSXHelper.createElement "feFuncB" xs
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feFuncB" children
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG xs = JSXHelper.createElement "feFuncG" xs
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feFuncG" children
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR xs = JSXHelper.createElement "feFuncR" xs
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feFuncR" children
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur xs = JSXHelper.createElement "feGaussianBlur" xs
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feGaussianBlur" children
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage xs = JSXHelper.createElement "feImage" xs
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feImage" children
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge xs = JSXHelper.createElement "feMerge" xs
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feMerge" children
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode xs = JSXHelper.createElement "feMergeNode" xs
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feMergeNode" children
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology xs = JSXHelper.createElement "feMorphology" xs
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feMorphology" children
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset xs = JSXHelper.createElement "feOffset" xs
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feOffset" children
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight xs = JSXHelper.createElement "fePointLight" xs
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "fePointLight" children
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting xs = JSXHelper.createElement "feSpecularLighting" xs
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feSpecularLighting" children
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight xs = JSXHelper.createElement "feSpotLight" xs
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feSpotLight" children
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile xs = JSXHelper.createElement "feTile" xs
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feTile" children
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence xs = JSXHelper.createElement "feTurbulence" xs
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "feTurbulence" children
    static member inline fieldSet xs = JSXHelper.createElement "fieldset" xs
    static member inline fieldSet (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "fieldset" children

    static member inline figcaption xs = JSXHelper.createElement "figcaption" xs
    static member inline figcaption (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "figcaption" children

    static member inline figure xs = JSXHelper.createElement "figure" xs
    static member inline figure (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "figure" children
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter xs = JSXHelper.createElement "filter" xs
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "filter" children

    static member inline footer xs = JSXHelper.createElement "footer" xs
    static member inline footer (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "footer" children
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject xs = JSXHelper.createElement "foreignObject" xs
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "foreignObject" children

    static member inline form xs = JSXHelper.createElement "form" xs
    static member inline form (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "form" children

    // [<Obsolete("Html.fragment is obsolete, use React.fragment instead. This function will be removed in the coming v1.0 release")>]
    // static member inline fragment xs = Fable.React.Helpers.fragment [] xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g xs = JSXHelper.createElement "g" xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "g" children

    static member inline h1 xs = JSXHelper.createElement "h1" xs
    static member inline h1 (value: float) = JSXHelper.createElementWithChild "h1" value
    static member inline h1 (value: int) = JSXHelper.createElementWithChild "h1" value
    static member inline h1 (value: ReactElement) = JSXHelper.createElementWithChild "h1" value
    static member inline h1 (value: string) = JSXHelper.createElementWithChild "h1" value
    static member inline h1 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h1" children
    static member inline h2 xs = JSXHelper.createElement "h2" xs
    static member inline h2 (value: float) =  JSXHelper.createElementWithChild "h2" value
    static member inline h2 (value: int) =  JSXHelper.createElementWithChild "h2" value
    static member inline h2 (value: ReactElement) =  JSXHelper.createElementWithChild "h2" value
    static member inline h2 (value: string) =  JSXHelper.createElementWithChild "h2" value
    static member inline h2 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h2" children

    static member inline h3 xs = JSXHelper.createElement "h3" xs
    static member inline h3 (value: float) =  JSXHelper.createElementWithChild "h3" value
    static member inline h3 (value: int) =  JSXHelper.createElementWithChild "h3" value
    static member inline h3 (value: ReactElement) =  JSXHelper.createElementWithChild "h3" value
    static member inline h3 (value: string) =  JSXHelper.createElementWithChild "h3" value
    static member inline h3 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h3" children

    static member inline h4 xs = JSXHelper.createElement "h4" xs
    static member inline h4 (value: float) = JSXHelper.createElementWithChild "h4" value
    static member inline h4 (value: int) = JSXHelper.createElementWithChild "h4" value
    static member inline h4 (value: ReactElement) = JSXHelper.createElementWithChild "h4" value
    static member inline h4 (value: string) = JSXHelper.createElementWithChild "h4" value
    static member inline h4 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h4" children

    static member inline h5 xs = JSXHelper.createElement "h5" xs
    static member inline h5 (value: float) = JSXHelper.createElementWithChild "h5" value
    static member inline h5 (value: int) = JSXHelper.createElementWithChild "h5" value
    static member inline h5 (value: ReactElement) = JSXHelper.createElementWithChild "h5" value
    static member inline h5 (value: string) = JSXHelper.createElementWithChild "h5" value
    static member inline h5 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h5" children

    static member inline h6 xs = JSXHelper.createElement "h6" xs
    static member inline h6 (value: float) = JSXHelper.createElementWithChild "h6" value
    static member inline h6 (value: int) = JSXHelper.createElementWithChild "h6" value
    static member inline h6 (value: ReactElement) = JSXHelper.createElementWithChild "h6" value
    static member inline h6 (value: string) = JSXHelper.createElementWithChild "h6" value
    static member inline h6 (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "h6" children

    static member inline head xs = JSXHelper.createElement "head" xs
    static member inline head (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "head" children

    static member inline header xs = JSXHelper.createElement "header" xs
    static member inline header (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "header" children

    static member inline hr xs = JSXHelper.createElement "hr" xs

    static member inline html xs = JSXHelper.createElement "html" xs
    static member inline html (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "html" children

    static member inline i xs = JSXHelper.createElement "i" xs
    static member inline i (value: float) = JSXHelper.createElementWithChild "i" value
    static member inline i (value: int) = JSXHelper.createElementWithChild "i" value
    static member inline i (value: ReactElement) = JSXHelper.createElementWithChild "i" value
    static member inline i (value: string) = JSXHelper.createElementWithChild "i" value
    static member inline i (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "i" children

    static member inline iframe xs = JSXHelper.createElement "iframe" xs

    static member inline img xs = JSXHelper.createElement "img" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image xs = JSXHelper.createElement "image" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "image" children

    static member inline input xs = JSXHelper.createElement "input" xs

    static member inline ins xs = JSXHelper.createElement "ins" xs
    static member inline ins (value: float) = JSXHelper.createElementWithChild "ins" value
    static member inline ins (value: int) = JSXHelper.createElementWithChild "ins" value
    static member inline ins (value: ReactElement) = JSXHelper.createElementWithChild "ins" value
    static member inline ins (value: string) = JSXHelper.createElementWithChild "ins" value
    static member inline ins (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ins" children

    static member inline kbd xs = JSXHelper.createElement "kbd" xs
    static member inline kbd (value: float) = JSXHelper.createElementWithChild "kbd" value
    static member inline kbd (value: int) = JSXHelper.createElementWithChild "kbd" value
    static member inline kbd (value: ReactElement) = JSXHelper.createElementWithChild "kbd" value
    static member inline kbd (value: string) = JSXHelper.createElementWithChild "kbd" value
    static member inline kbd (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "kbd" children

    static member inline label xs = JSXHelper.createElement "label" xs
    static member inline label (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "label" children

    static member inline legend xs = JSXHelper.createElement "legend" xs
    static member inline legend (value: float) = JSXHelper.createElementWithChild "legend" value
    static member inline legend (value: int) = JSXHelper.createElementWithChild "legend" value
    static member inline legend (value: ReactElement) = JSXHelper.createElementWithChild "legend" value
    static member inline legend (value: string) = JSXHelper.createElementWithChild "legend" value
    static member inline legend (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "legend" children

    static member inline li xs = JSXHelper.createElement "li" xs
    static member inline li (value: float) = JSXHelper.createElementWithChild "li" value
    static member inline li (value: int) = JSXHelper.createElementWithChild "li" value
    static member inline li (value: ReactElement) = JSXHelper.createElementWithChild "li" value
    static member inline li (value: string) = JSXHelper.createElementWithChild "li" value
    static member inline li (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "li" children
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line xs = JSXHelper.createElement "line" xs
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "line" children
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient xs = JSXHelper.createElement "linearGradient" xs
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "linearGradient" children

    static member inline link xs = JSXHelper.createElement "link" xs

    static member inline listItem xs = JSXHelper.createElement "li" xs
    static member inline listItem (value: float) = JSXHelper.createElementWithChild "li" value
    static member inline listItem (value: int) = JSXHelper.createElementWithChild "li" value
    static member inline listItem (value: ReactElement) = JSXHelper.createElementWithChild "li" value
    static member inline listItem (value: string) = JSXHelper.createElementWithChild "li" value
    static member inline listItem (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "li" children

    static member inline main xs = JSXHelper.createElement "main" xs
    static member inline main (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "main" children

    static member inline map xs = JSXHelper.createElement "map" xs
    static member inline map (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "map" children

    static member inline mark xs = JSXHelper.createElement "mark" xs
    static member inline mark (value: float) = JSXHelper.createElementWithChild "mark" value
    static member inline mark (value: int) = JSXHelper.createElementWithChild "mark" value
    static member inline mark (value: ReactElement) = JSXHelper.createElementWithChild "mark" value
    static member inline mark (value: string) = JSXHelper.createElementWithChild "mark" value
    static member inline mark (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "mark" children
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker xs = JSXHelper.createElement "marker" xs
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "marker" children
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask xs = JSXHelper.createElement "mask" xs
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "mask" children

    static member inline meta xs = JSXHelper.createElement "meta" xs

    static member inline metadata xs = JSXHelper.createElement "metadata" xs
    static member inline metadata (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "metadata" children

    static member inline meter xs = JSXHelper.createElement "meter" xs
    static member inline meter (value: float) = JSXHelper.createElementWithChild "meter" value
    static member inline meter (value: int) = JSXHelper.createElementWithChild "meter" value
    static member inline meter (value: ReactElement) = JSXHelper.createElementWithChild "meter" value
    static member inline meter (value: string) = JSXHelper.createElementWithChild "meter" value
    static member inline meter (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "meter" children
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath xs = JSXHelper.createElement "mpath" xs
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "mpath" children
    static member inline nav xs = JSXHelper.createElement "nav" xs
    static member inline nav (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "nav" children

    /// The empty element, renders nothing on screen
    static member inline none : ReactElement = unbox null

    static member inline noscript xs = JSXHelper.createElement "noscript" xs
    static member inline noscript (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "noscript" children

    static member inline object xs = JSXHelper.createElement "object" xs
    static member inline object (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "object" children

    static member inline ol xs = JSXHelper.createElement "ol" xs
    static member inline ol (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ol" children

    static member inline option xs = JSXHelper.createElement "option" xs
    static member inline option (value: float) = JSXHelper.createElementWithChild "option" value
    static member inline option (value: int) = JSXHelper.createElementWithChild "option" value
    static member inline option (value: ReactElement) = JSXHelper.createElementWithChild "option" value
    static member inline option (value: string) = JSXHelper.createElementWithChild "option" value
    static member inline option (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "option" children

    static member inline optgroup xs = JSXHelper.createElement "optgroup" xs
    static member inline optgroup (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "optgroup" children

    static member inline orderedList xs = JSXHelper.createElement "ol" xs
    static member inline orderedList (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ol" children

    static member inline output xs = JSXHelper.createElement "output" xs
    static member inline output (value: float) = JSXHelper.createElementWithChild "output" value
    static member inline output (value: int) = JSXHelper.createElementWithChild "output" value
    static member inline output (value: ReactElement) = JSXHelper.createElementWithChild "output" value
    static member inline output (value: string) = JSXHelper.createElementWithChild "output" value
    static member inline output (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "output" children

    static member inline p xs = JSXHelper.createElement "p" xs
    static member inline p (value: float) = JSXHelper.createElementWithChild "p" value
    static member inline p (value: int) = JSXHelper.createElementWithChild "p" value
    static member inline p (value: ReactElement) = JSXHelper.createElementWithChild "p" value
    static member inline p (value: string) = JSXHelper.createElementWithChild "p" value
    static member inline p (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "p" children

    static member inline paragraph xs = JSXHelper.createElement "p" xs
    static member inline paragraph (value: float) = JSXHelper.createElementWithChild "p" value
    static member inline paragraph (value: int) = JSXHelper.createElementWithChild "p" value
    static member inline paragraph (value: ReactElement) = JSXHelper.createElementWithChild "p" value
    static member inline paragraph (value: string) = JSXHelper.createElementWithChild "p" value
    static member inline paragraph (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "p" children

    static member inline param xs = JSXHelper.createElement "param" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path xs = JSXHelper.createElement "path" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "path" children
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern xs = JSXHelper.createElement "pattern" xs
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "pattern" children
    static member inline picture xs = JSXHelper.createElement "picture" xs
    static member inline picture (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "picture" children
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon xs = JSXHelper.createElement "polygon" xs
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "polygon" children
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline xs = JSXHelper.createElement "polyline" xs
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "polyline" children
    static member inline pre xs = JSXHelper.createElement "pre" xs
    static member inline pre (value: bool) = JSXHelper.createElementWithChild "pre" value
    static member inline pre (value: float) = JSXHelper.createElementWithChild "pre" value
    static member inline pre (value: int) = JSXHelper.createElementWithChild "pre" value
    static member inline pre (value: ReactElement) = JSXHelper.createElementWithChild "pre" value
    static member inline pre (value: string) = JSXHelper.createElementWithChild "pre" value
    static member inline pre (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "pre" children

    static member inline progress xs = JSXHelper.createElement "progress" xs
    static member inline progress (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "progress" children

    static member inline q xs = JSXHelper.createElement "q" xs
    static member inline q (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "q" children
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient xs = JSXHelper.createElement "radialGradient" xs
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "radialGradient" children

    static member inline rb xs = JSXHelper.createElement "rb" xs
    static member inline rb (value: float) = JSXHelper.createElementWithChild "rb" value
    static member inline rb (value: int) = JSXHelper.createElementWithChild "rb" value
    static member inline rb (value: ReactElement) = JSXHelper.createElementWithChild "rb" value
    static member inline rb (value: string) = JSXHelper.createElementWithChild "rb" value
    static member inline rb (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "rb" children
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect xs = JSXHelper.createElement "rect" xs
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "rect" children

    static member inline rp xs = JSXHelper.createElement "rp" xs
    static member inline rp (value: float) = JSXHelper.createElementWithChild "rp" value
    static member inline rp (value: int) = JSXHelper.createElementWithChild "rp" value
    static member inline rp (value: ReactElement) = JSXHelper.createElementWithChild "rp" value
    static member inline rp (value: string) = JSXHelper.createElementWithChild "rp" value
    static member inline rp (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "rp" children

    static member inline rt xs = JSXHelper.createElement "rt" xs
    static member inline rt (value: float) = JSXHelper.createElementWithChild "rt" value
    static member inline rt (value: int) = JSXHelper.createElementWithChild "rt" value
    static member inline rt (value: ReactElement) = JSXHelper.createElementWithChild "rt" value
    static member inline rt (value: string) = JSXHelper.createElementWithChild "rt" value
    static member inline rt (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "rt" children

    static member inline rtc xs = JSXHelper.createElement "rtc" xs
    static member inline rtc (value: float) = JSXHelper.createElementWithChild "rtc" value
    static member inline rtc (value: int) = JSXHelper.createElementWithChild "rtc" value
    static member inline rtc (value: ReactElement) = JSXHelper.createElementWithChild "rtc" value
    static member inline rtc (value: string) = JSXHelper.createElementWithChild "rtc" value
    static member inline rtc (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "rtc" children

    static member inline ruby xs = JSXHelper.createElement "ruby" xs
    static member inline ruby (value: float) = JSXHelper.createElementWithChild "ruby" value
    static member inline ruby (value: int) = JSXHelper.createElementWithChild "ruby" value
    static member inline ruby (value: ReactElement) = JSXHelper.createElementWithChild "ruby" value
    static member inline ruby (value: string) = JSXHelper.createElementWithChild "ruby" value
    static member inline ruby (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ruby" children

    static member inline s xs = JSXHelper.createElement "s" xs
    static member inline s (value: float) = JSXHelper.createElementWithChild "s" value
    static member inline s (value: int) = JSXHelper.createElementWithChild "s" value
    static member inline s (value: ReactElement) = JSXHelper.createElementWithChild "s" value
    static member inline s (value: string) = JSXHelper.createElementWithChild "s" value
    static member inline s (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "s" children

    static member inline samp xs = JSXHelper.createElement "samp" xs
    static member inline samp (value: float) = JSXHelper.createElementWithChild "samp" value
    static member inline samp (value: int) = JSXHelper.createElementWithChild "samp" value
    static member inline samp (value: ReactElement) = JSXHelper.createElementWithChild "samp" value
    static member inline samp (value: string) = JSXHelper.createElementWithChild "samp" value
    static member inline samp (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "samp" children

    static member inline script xs = JSXHelper.createElement "script" xs
    static member inline script (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "script" children

    static member inline section xs = JSXHelper.createElement "section" xs
    static member inline section (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "section" children

    static member inline select xs = JSXHelper.createElement "select" xs
    static member inline select (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "select" children
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set xs = JSXHelper.createElement "set" xs
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "set" children

    static member inline small xs = JSXHelper.createElement "small" xs
    static member inline small (value: float) = JSXHelper.createElementWithChild "small" value
    static member inline small (value: int) = JSXHelper.createElementWithChild "small" value
    static member inline small (value: ReactElement) = JSXHelper.createElementWithChild "small" value
    static member inline small (value: string) = JSXHelper.createElementWithChild "small" value
    static member inline small (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "small" children

    static member inline source xs = JSXHelper.createElement "source" xs

    static member inline span xs = JSXHelper.createElement "span" xs
    static member inline span (value: float) = JSXHelper.createElementWithChild "span" value
    static member inline span (value: int) = JSXHelper.createElementWithChild "span" value
    static member inline span (value: ReactElement) = JSXHelper.createElementWithChild "span" value
    static member inline span (value: string) = JSXHelper.createElementWithChild "span" value
    static member inline span (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "span" children
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop xs = JSXHelper.createElement "stop" xs
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "stop" children

    static member inline strong xs = JSXHelper.createElement "strong" xs
    static member inline strong (value: float) = JSXHelper.createElementWithChild "strong" value
    static member inline strong (value: int) = JSXHelper.createElementWithChild "strong" value
    static member inline strong (value: ReactElement) = JSXHelper.createElementWithChild "strong" value
    static member inline strong (value: string) = JSXHelper.createElementWithChild "strong" value
    static member inline strong (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "strong" children

    static member inline style xs = JSXHelper.createElement "style" xs
    static member inline style (value: string) = JSXHelper.createElementWithChild "style" value

    static member inline sub xs = JSXHelper.createElement "sub" xs
    static member inline sub (value: float) = JSXHelper.createElementWithChild "sub" value
    static member inline sub (value: int) = JSXHelper.createElementWithChild "sub" value
    static member inline sub (value: ReactElement) = JSXHelper.createElementWithChild "sub" value
    static member inline sub (value: string) = JSXHelper.createElementWithChild "sub" value
    static member inline sub (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "sub" children

    static member inline summary xs = JSXHelper.createElement "summary" xs
    static member inline summary (value: float) = JSXHelper.createElementWithChild "summary" value
    static member inline summary (value: int) = JSXHelper.createElementWithChild "summary" value
    static member inline summary (value: ReactElement) = JSXHelper.createElementWithChild "summary" value
    static member inline summary (value: string) = JSXHelper.createElementWithChild "summary" value
    static member inline summary (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "summary" children

    static member inline sup xs = JSXHelper.createElement "sup" xs
    static member inline sup (value: float) = JSXHelper.createElementWithChild "sup" value
    static member inline sup (value: int) = JSXHelper.createElementWithChild "sup" value
    static member inline sup (value: ReactElement) = JSXHelper.createElementWithChild "sup" value
    static member inline sup (value: string) = JSXHelper.createElementWithChild "sup" value
    static member inline sup (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "sup" children

    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg xs = JSXHelper.createElement "svg" xs
    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "svg" children
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch xs = JSXHelper.createElement "switch" xs
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "switch" children
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol xs = JSXHelper.createElement "symbol" xs
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "symbol" children

    static member inline table xs = JSXHelper.createElement "table" xs
    static member inline table (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "table" children

    static member inline tableBody xs = JSXHelper.createElement "tbody" xs
    static member inline tableBody (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tbody" children

    static member inline tableCell xs = JSXHelper.createElement "td" xs
    static member inline tableCell (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "td" children

    static member inline tableHeader xs = JSXHelper.createElement "th" xs
    static member inline tableHeader (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "th" children

    static member inline tableRow xs = JSXHelper.createElement "tr" xs
    static member inline tableRow (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tr" children

    static member inline tbody xs = JSXHelper.createElement "tbody" xs
    static member inline tbody (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tbody" children

    static member inline td xs = JSXHelper.createElement "td" xs
    static member inline td (value: float) = JSXHelper.createElementWithChild "td" value
    static member inline td (value: int) = JSXHelper.createElementWithChild "td" value
    static member inline td (value: ReactElement) = JSXHelper.createElementWithChild "td" value
    static member inline td (value: string) = JSXHelper.createElementWithChild "td" value
    static member inline td (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "td" children

    static member inline template xs = JSXHelper.createElement "template" xs
    static member inline template (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "template" children

    [<Obsolete "Html.text is obsolete for creating <text> SVG elements. Use Svg.text instead">]
    static member inline text xs = JSXHelper.createElement "text" xs
    static member inline text (value: float) : ReactElement = unbox value
    static member inline text (value: int) : ReactElement = unbox value
    static member inline text (value: string) : ReactElement = unbox value
    static member inline text (value: Guid) : ReactElement = unbox (string value)

    static member inline textf fmt = Printf.kprintf Html.text fmt

    static member inline textarea xs = JSXHelper.createElement "textarea" xs
    static member inline textarea (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "textarea" children
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath xs = JSXHelper.createElement "textPath" xs
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "textPath" children

    static member inline tfoot xs = JSXHelper.createElement "tfoot" xs
    static member inline tfoot (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tfoot" children

    static member inline th xs = JSXHelper.createElement "th" xs
    static member inline th (value: float) = JSXHelper.createElementWithChild "th" value
    static member inline th (value: int) = JSXHelper.createElementWithChild "th" value
    static member inline th (value: ReactElement) = JSXHelper.createElementWithChild "th" value
    static member inline th (value: string) = JSXHelper.createElementWithChild "th" value
    static member inline th (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "th" children

    static member inline thead xs = JSXHelper.createElement "thead" xs
    static member inline thead (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "thead" children

    static member inline time xs = JSXHelper.createElement "time" xs
    static member inline time (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "time" children
    static member inline title xs = JSXHelper.createElement "title" xs
    static member inline title (value: float) = JSXHelper.createElementWithChild "title" value
    static member inline title (value: int) = JSXHelper.createElementWithChild "title" value
    static member inline title (value: ReactElement) = JSXHelper.createElementWithChild "title" value
    static member inline title (value: string) = JSXHelper.createElementWithChild "title" value
    static member inline title (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "title" children
    static member inline tr xs = JSXHelper.createElement "tr" xs
    static member inline tr (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tr" children

    static member inline track xs = JSXHelper.createElement "track" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan xs = JSXHelper.createElement "tspan" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "tspan" children

    static member inline u xs = JSXHelper.createElement "u" xs
    static member inline u (value: float) = JSXHelper.createElementWithChild "u" value
    static member inline u (value: int) = JSXHelper.createElementWithChild "u" value
    static member inline u (value: ReactElement) = JSXHelper.createElementWithChild "u" value
    static member inline u (value: string) = JSXHelper.createElementWithChild "u" value
    static member inline u (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "u" children

    static member inline ul xs = JSXHelper.createElement "ul" xs
    static member inline ul (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ul" children

    static member inline unorderedList xs = JSXHelper.createElement "ul" xs
    static member inline unorderedList (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "ul" children
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' xs = JSXHelper.createElement "use" xs
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "use" children
    static member inline var xs = JSXHelper.createElement "var" xs
    static member inline var (value: float) = JSXHelper.createElementWithChild "var" value
    static member inline var (value: int) = JSXHelper.createElementWithChild "var" value
    static member inline var (value: ReactElement) = JSXHelper.createElementWithChild "var" value
    static member inline var (value: string) = JSXHelper.createElementWithChild "var" value
    static member inline var (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "var" children

    static member inline video xs = JSXHelper.createElement "video" xs
    static member inline video (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "video" children
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view xs = JSXHelper.createElement "view" xs
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view (children: #seq<ReactElement>) = JSXHelper.createElementWithChild "view" children

    static member inline wbr xs = JSXHelper.createElement "wbr" xs
