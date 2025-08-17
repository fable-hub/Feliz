namespace Feliz

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open System

module HtmlHelper =
    let inline createElementWithChild (tag: string) (children: obj) =
        ReactLegacy.createElement(tag, children = unbox<ReactElement> children)

    let inline createElementWithChildren (tag: string) (children: seq<ReactElement>) =
        ReactLegacy.createElement(tag, children = children)

    /// Iterates once, returns (firstMatch, restWithoutMatch).
    let tryExtractFirst (predicate: 'T -> bool) (xs: 'T list) : ('T option * 'T list) =
        let rec loop acc = function
            | [] -> None, List.rev acc
            | x::xs when predicate x ->
                Some x, List.rev acc @ xs
            | x::xs ->
                loop (x::acc) xs
        loop [] xs

    let createElement (name: string) (props: IReactProperty list) : ReactElement =
        match unbox<(string*obj) list> props |> tryExtractFirst (fun (key, _) -> key = "children") with
        | Some (_, children), props when Interop.isIterable children ->
            ReactLegacy.createElement(
                name, 
                Fable.Core.JsInterop.createObj props,
                unbox<ReactElement list> children
            )
        | Some (_, children), props ->
            ReactLegacy.createElement(
                name, 
                Fable.Core.JsInterop.createObj props,
                unbox<ReactElement> children
            )
        | None, props -> 
            ReactLegacy.createElement(
                name,
                Fable.Core.JsInterop.createObj props
            )

[<Erase>]
type Html =
    static member inline a xs = HtmlHelper.createElement "a" xs
    static member inline a (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "a" children

    static member inline abbr xs = HtmlHelper.createElement "abbr" xs
    static member inline abbr (value: float) = HtmlHelper.createElementWithChild "abbr" value
    static member inline abbr (value: int) = HtmlHelper.createElementWithChild "abbr" value
    static member inline abbr (value: ReactElement) = HtmlHelper.createElementWithChild "abbr" value
    static member inline abbr (value: string) = HtmlHelper.createElementWithChild "abbr" value
    static member inline abbr (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "abbr" children

    static member inline address xs = HtmlHelper.createElement "address" xs
    static member inline address (value: float) = HtmlHelper.createElementWithChild "address" value
    static member inline address (value: int) = HtmlHelper.createElementWithChild "address" value
    static member inline address (value: ReactElement) = HtmlHelper.createElementWithChild "address" value
    static member inline address (value: string) = HtmlHelper.createElementWithChild "address" value
    static member inline address (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "address" children

    static member inline anchor xs = HtmlHelper.createElement "a" xs
    static member inline anchor (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "a" children

    static member inline animate xs = HtmlHelper.createElement "animate" xs

    static member inline animateMotion xs = HtmlHelper.createElement "animateMotion" xs
    static member inline animateMotion (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "animateMotion" children

    static member inline animateTransform xs = HtmlHelper.createElement "animateTransform" xs
    static member inline animateTransform (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "animateTransform" children

    static member inline area xs = HtmlHelper.createElement "area" xs

    static member inline article xs = HtmlHelper.createElement "article" xs
    static member inline article (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "article" children

    static member inline aside xs = HtmlHelper.createElement "aside" xs
    static member inline aside (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "aside" children

    static member inline audio xs = HtmlHelper.createElement "audio" xs
    static member inline audio (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "audio" children

    static member inline b xs = HtmlHelper.createElement "b" xs
    static member inline b (value: float) = HtmlHelper.createElementWithChild "b" value
    static member inline b (value: int) = HtmlHelper.createElementWithChild "b" value
    static member inline b (value: ReactElement) = HtmlHelper.createElementWithChild "b" value
    static member inline b (value: string) = HtmlHelper.createElementWithChild "b" value
    static member inline b (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "b" children

    static member inline base' xs = HtmlHelper.createElement "base" xs

    static member inline bdi xs = HtmlHelper.createElement "bdi" xs
    static member inline bdi (value: float) = HtmlHelper.createElementWithChild "bdi" value
    static member inline bdi (value: int) = HtmlHelper.createElementWithChild "bdi" value
    static member inline bdi (value: ReactElement) = HtmlHelper.createElementWithChild "bdi" value
    static member inline bdi (value: string) = HtmlHelper.createElementWithChild "bdi" value
    static member inline bdi (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "bdi" children

    static member inline bdo xs = HtmlHelper.createElement "bdo" xs
    static member inline bdo (value: float) = HtmlHelper.createElementWithChild "bdo" value
    static member inline bdo (value: int) = HtmlHelper.createElementWithChild "bdo" value
    static member inline bdo (value: ReactElement) = HtmlHelper.createElementWithChild "bdo" value
    static member inline bdo (value: string) = HtmlHelper.createElementWithChild "bdo" value
    static member inline bdo (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "bdo" children

    static member inline blockquote xs = HtmlHelper.createElement "blockquote" xs
    static member inline blockquote (value: float) = HtmlHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: int) = HtmlHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: ReactElement) = HtmlHelper.createElementWithChild "blockquote" value
    static member inline blockquote (value: string) = HtmlHelper.createElementWithChild "blockquote" value
    static member inline blockquote (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "blockquote" children

    static member inline body xs = HtmlHelper.createElement "body" xs
    static member inline body (value: float) = HtmlHelper.createElementWithChild "body" value
    static member inline body (value: int) = HtmlHelper.createElementWithChild "body" value
    static member inline body (value: ReactElement) = HtmlHelper.createElementWithChild "body" value
    static member inline body (value: string) = HtmlHelper.createElementWithChild "body" value
    static member inline body (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "body" children

    static member inline br xs = HtmlHelper.createElement "br" xs

    static member inline button xs = HtmlHelper.createElement "button" xs
    static member inline button (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "button" children

    static member inline canvas xs = HtmlHelper.createElement "canvas" xs

    static member inline caption xs = HtmlHelper.createElement "caption" xs
    static member inline caption (value: float) = HtmlHelper.createElementWithChild "caption" value
    static member inline caption (value: int) = HtmlHelper.createElementWithChild "caption" value
    static member inline caption (value: ReactElement) = HtmlHelper.createElementWithChild "caption" value
    static member inline caption (value: string) = HtmlHelper.createElementWithChild "caption" value
    static member inline caption (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "caption" children

    static member inline cite xs = HtmlHelper.createElement "cite" xs
    static member inline cite (value: float) = HtmlHelper.createElementWithChild "cite" value
    static member inline cite (value: int) = HtmlHelper.createElementWithChild "cite" value
    static member inline cite (value: ReactElement) = HtmlHelper.createElementWithChild "cite" value
    static member inline cite (value: string) = HtmlHelper.createElementWithChild "cite" value
    static member inline cite (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "cite" children
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle xs = HtmlHelper.createElement "circle" xs
    [<Obsolete "Html.circle is obsolete, use Svg.circle instead">]
    static member inline circle (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "circle" children
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath xs = HtmlHelper.createElement "clipPath" xs
    [<Obsolete "Html.clipPath is obsolete, use Svg.clipPath instead">]
    static member inline clipPath (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "clipPath" children

    static member inline code xs = HtmlHelper.createElement "code" xs
    static member inline code (value: bool) = HtmlHelper.createElementWithChild "code" value
    static member inline code (value: float) = HtmlHelper.createElementWithChild "code" value
    static member inline code (value: int) = HtmlHelper.createElementWithChild "code" value
    static member inline code (value: ReactElement) = HtmlHelper.createElementWithChild "code" value
    static member inline code (value: string) = HtmlHelper.createElementWithChild "code" value
    static member inline code (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "code" children

    static member inline col xs = HtmlHelper.createElement "col" xs

    static member inline colgroup xs = HtmlHelper.createElement "colgroup" xs
    static member inline colgroup (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "colgroup" children

    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: float) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: int) : ReactElement = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: string) : ReactElement = unbox value

    static member inline data xs = HtmlHelper.createElement "data" xs
    static member inline data (value: float) = HtmlHelper.createElementWithChild "data" value
    static member inline data (value: int) = HtmlHelper.createElementWithChild "data" value
    static member inline data (value: ReactElement) = HtmlHelper.createElementWithChild "data" value
    static member inline data (value: string) = HtmlHelper.createElementWithChild "data" value
    static member inline data (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "data" children

    static member inline datalist xs = HtmlHelper.createElement "datalist" xs
    static member inline datalist (value: float) = HtmlHelper.createElementWithChild "datalist" value
    static member inline datalist (value: int) = HtmlHelper.createElementWithChild "datalist" value
    static member inline datalist (value: ReactElement) = HtmlHelper.createElementWithChild "datalist" value
    static member inline datalist (value: string) = HtmlHelper.createElementWithChild "datalist" value
    static member inline datalist (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "datalist" children

    static member inline dd xs = HtmlHelper.createElement "dd" xs
    static member inline dd (value: float) = HtmlHelper.createElementWithChild "dd" value
    static member inline dd (value: int) = HtmlHelper.createElementWithChild "dd" value
    static member inline dd (value: ReactElement) = HtmlHelper.createElementWithChild "dd" value
    static member inline dd (value: string) = HtmlHelper.createElementWithChild "dd" value
    static member inline dd (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "dd" children
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs xs = HtmlHelper.createElement "defs" xs
    [<Obsolete "Html.defs is obsolete, use Svg.defs instead">]
    static member inline defs (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "defs" children
    static member inline del xs = HtmlHelper.createElement "del" xs
    static member inline del (value: float) = HtmlHelper.createElementWithChild "del" value
    static member inline del (value: int) = HtmlHelper.createElementWithChild "del" value
    static member inline del (value: ReactElement) = HtmlHelper.createElementWithChild "del" value
    static member inline del (value: string) = HtmlHelper.createElementWithChild "del" value
    static member inline del (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "del" children

    static member inline details xs = HtmlHelper.createElement "details" xs
    static member inline details (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "details" children

    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc xs = HtmlHelper.createElement "desc" xs
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: float) = HtmlHelper.createElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: int) = HtmlHelper.createElementWithChild "desc" value
    [<Obsolete "Html.desc is obsolete, use Svg.desc instead">]
    static member inline desc (value: string) = HtmlHelper.createElementWithChild "desc" value

    static member inline dfn xs = HtmlHelper.createElement "ins" xs
    static member inline dfn (value: float) = HtmlHelper.createElementWithChild "dfn" value
    static member inline dfn (value: int) = HtmlHelper.createElementWithChild "dfn" value
    static member inline dfn (value: ReactElement) = HtmlHelper.createElementWithChild "dfn" value
    static member inline dfn (value: string) = HtmlHelper.createElementWithChild "dfn" value
    static member inline dfn (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "dfn" children

    static member inline dialog xs = HtmlHelper.createElement "dialog" xs
    static member inline dialog (value: float) = HtmlHelper.createElementWithChild "dialog" value
    static member inline dialog (value: int) = HtmlHelper.createElementWithChild "dialog" value
    static member inline dialog (value: ReactElement) = HtmlHelper.createElementWithChild "dialog" value
    static member inline dialog (value: string) = HtmlHelper.createElementWithChild "dialog" value
    static member inline dialog (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "dialog" children

    /// The `<div>` tag defines a division or a section in an HTML document
    static member inline div xs = HtmlHelper.createElement "div" xs
    static member inline div (value: float) = HtmlHelper.createElementWithChild "div" value
    static member inline div (value: int) = HtmlHelper.createElementWithChild "div" value
    static member inline div (value: ReactElement) = HtmlHelper.createElementWithChild "div" value
    static member inline div (value: string) = HtmlHelper.createElementWithChild "div" value
    static member inline div (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "div" children

    static member inline dl xs = HtmlHelper.createElement "dl" xs
    static member inline dl (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "dl" children

    static member inline dt xs = HtmlHelper.createElement "dt" xs
    static member inline dt (value: float) = HtmlHelper.createElementWithChild "dt" value
    static member inline dt (value: int) = HtmlHelper.createElementWithChild "dt" value
    static member inline dt (value: ReactElement) = HtmlHelper.createElementWithChild "dt" value
    static member inline dt (value: string) = HtmlHelper.createElementWithChild "dt" value
    static member inline dt (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "dt" children

    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse xs = HtmlHelper.createElement "ellipse" xs
    [<Obsolete "Html.ellipse is obsolete, use Svg.ellipse instead">]
    static member inline ellipse (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ellipse" children

    static member inline em xs = HtmlHelper.createElement "em" xs
    static member inline em (value: float) = HtmlHelper.createElementWithChild "em" value
    static member inline em (value: int) = HtmlHelper.createElementWithChild "em" value
    static member inline em (value: ReactElement) = HtmlHelper.createElementWithChild "em" value
    static member inline em (value: string) = HtmlHelper.createElementWithChild "em" value
    static member inline em (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "em" children

    static member inline embed xs = HtmlHelper.createElement "embed" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend xs = HtmlHelper.createElement "feBlend" xs
    [<Obsolete "Html.feBlend is obsolete, use Svg.feBlend instead">]
    static member inline feBlend (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feBlend" children
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix xs = HtmlHelper.createElement "feColorMatrix" xs
    [<Obsolete "Html.feColorMatrix is obsolete, use Svg.feColorMatrix instead">]
    static member inline feColorMatrix (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feColorMatrix" children
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer xs = HtmlHelper.createElement "feComponentTransfer" xs
    [<Obsolete "Html.feComponentTransfer is obsolete, use Svg.feComponentTransfer instead">]
    static member inline feComponentTransfer (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feComponentTransfer" children
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite xs = HtmlHelper.createElement "feComposite" xs
    [<Obsolete "Html.feComposite is obsolete, use Svg.feComposite instead">]
    static member inline feComposite (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feComposite" children
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix xs = HtmlHelper.createElement "feConvolveMatrix" xs
    [<Obsolete "Html.feConvolveMatrix is obsolete, use Svg.feConvolveMatrix instead">]
    static member inline feConvolveMatrix (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feConvolveMatrix" children
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting xs = HtmlHelper.createElement "feDiffuseLighting" xs
    [<Obsolete "Html.feDiffuseLighting is obsolete, use Svg.feDiffuseLighting instead">]
    static member inline feDiffuseLighting (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feDiffuseLighting" children
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap xs = HtmlHelper.createElement "feDisplacementMap" xs
    [<Obsolete "Html.feDisplacementMap is obsolete, use Svg.feDisplacementMap instead">]
    static member inline feDisplacementMap (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feDisplacementMap" children
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight xs = HtmlHelper.createElement "feDistantLight" xs
    [<Obsolete "Html.feDistantLight is obsolete, use Svg.feDistantLight instead">]
    static member inline feDistantLight (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feDistantLight" children
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow xs = HtmlHelper.createElement "feDropShadow" xs
    [<Obsolete "Html.feDropShadow is obsolete, use Svg.feDropShadow instead">]
    static member inline feDropShadow (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feDropShadow" children
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood xs = HtmlHelper.createElement "feFlood" xs
    [<Obsolete "Html.feFlood is obsolete, use Svg.feFlood instead">]
    static member inline feFlood (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feFlood" children
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA xs = HtmlHelper.createElement "feFuncA" xs
    [<Obsolete "Html.feFuncA is obsolete, use Svg.feFuncA instead">]
    static member inline feFuncA (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feFuncA" children
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB xs = HtmlHelper.createElement "feFuncB" xs
    [<Obsolete "Html.feFuncB is obsolete, use Svg.feFuncB instead">]
    static member inline feFuncB (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feFuncB" children
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG xs = HtmlHelper.createElement "feFuncG" xs
    [<Obsolete "Html.feFuncG is obsolete, use Svg.feFuncG instead">]
    static member inline feFuncG (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feFuncG" children
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR xs = HtmlHelper.createElement "feFuncR" xs
    [<Obsolete "Html.feFuncR is obsolete, use Svg.feFuncR instead">]
    static member inline feFuncR (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feFuncR" children
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur xs = HtmlHelper.createElement "feGaussianBlur" xs
    [<Obsolete "Html.feGaussianBlur is obsolete, use Svg.feGaussianBlur instead">]
    static member inline feGaussianBlur (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feGaussianBlur" children
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage xs = HtmlHelper.createElement "feImage" xs
    [<Obsolete "Html.feImage is obsolete, use Svg.feImage instead">]
    static member inline feImage (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feImage" children
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge xs = HtmlHelper.createElement "feMerge" xs
    [<Obsolete "Html.feMerge is obsolete, use Svg.feMerge instead">]
    static member inline feMerge (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feMerge" children
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode xs = HtmlHelper.createElement "feMergeNode" xs
    [<Obsolete "Html.feMergeNode is obsolete, use Svg.feMergeNode instead">]
    static member inline feMergeNode (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feMergeNode" children
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology xs = HtmlHelper.createElement "feMorphology" xs
    [<Obsolete "Html.feMorphology is obsolete, use Svg.feMorphology instead">]
    static member inline feMorphology (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feMorphology" children
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset xs = HtmlHelper.createElement "feOffset" xs
    [<Obsolete "Html.feOffset is obsolete, use Svg.feOffset instead">]
    static member inline feOffset (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feOffset" children
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight xs = HtmlHelper.createElement "fePointLight" xs
    [<Obsolete "Html.fePointLight is obsolete, use Svg.fePointLight instead">]
    static member inline fePointLight (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "fePointLight" children
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting xs = HtmlHelper.createElement "feSpecularLighting" xs
    [<Obsolete "Html.feSpecularLighting is obsolete, use Svg.feSpecularLighting instead">]
    static member inline feSpecularLighting (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feSpecularLighting" children
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight xs = HtmlHelper.createElement "feSpotLight" xs
    [<Obsolete "Html.feSpotLight is obsolete, use Svg.feSpotLight instead">]
    static member inline feSpotLight (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feSpotLight" children
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile xs = HtmlHelper.createElement "feTile" xs
    [<Obsolete "Html.feTile is obsolete, use Svg.feTile instead">]
    static member inline feTile (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feTile" children
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence xs = HtmlHelper.createElement "feTurbulence" xs
    [<Obsolete "Html.feTurbulence is obsolete, use Svg.feTurbulence instead">]
    static member inline feTurbulence (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "feTurbulence" children
    static member inline fieldSet xs = HtmlHelper.createElement "fieldset" xs
    static member inline fieldSet (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "fieldset" children

    static member inline figcaption xs = HtmlHelper.createElement "figcaption" xs
    static member inline figcaption (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "figcaption" children

    static member inline figure xs = HtmlHelper.createElement "figure" xs
    static member inline figure (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "figure" children
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter xs = HtmlHelper.createElement "filter" xs
    [<Obsolete "Html.filter is obsolete, use Svg.filter instead">]
    static member inline filter (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "filter" children

    static member inline footer xs = HtmlHelper.createElement "footer" xs
    static member inline footer (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "footer" children
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject xs = HtmlHelper.createElement "foreignObject" xs
    [<Obsolete "Html.foreignObject is obsolete, use Svg.foreignObject instead">]
    static member inline foreignObject (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "foreignObject" children

    static member inline form xs = HtmlHelper.createElement "form" xs
    static member inline form (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "form" children

    // [<Obsolete("Html.fragment is obsolete, use React.fragment instead. This function will be removed in the coming v1.0 release")>]
    // static member inline fragment xs = Fable.React.Helpers.fragment [] xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g xs = HtmlHelper.createElement "g" xs
    [<Obsolete "Html.g is obsolete, use Svg.g instead">]
    static member inline g (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "g" children

    static member inline h1 xs = HtmlHelper.createElement "h1" xs
    static member inline h1 (value: float) = HtmlHelper.createElementWithChild "h1" value
    static member inline h1 (value: int) = HtmlHelper.createElementWithChild "h1" value
    static member inline h1 (value: ReactElement) = HtmlHelper.createElementWithChild "h1" value
    static member inline h1 (value: string) = HtmlHelper.createElementWithChild "h1" value
    static member inline h1 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h1" children
    static member inline h2 xs = HtmlHelper.createElement "h2" xs
    static member inline h2 (value: float) =  HtmlHelper.createElementWithChild "h2" value
    static member inline h2 (value: int) =  HtmlHelper.createElementWithChild "h2" value
    static member inline h2 (value: ReactElement) =  HtmlHelper.createElementWithChild "h2" value
    static member inline h2 (value: string) =  HtmlHelper.createElementWithChild "h2" value
    static member inline h2 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h2" children

    static member inline h3 xs = HtmlHelper.createElement "h3" xs
    static member inline h3 (value: float) =  HtmlHelper.createElementWithChild "h3" value
    static member inline h3 (value: int) =  HtmlHelper.createElementWithChild "h3" value
    static member inline h3 (value: ReactElement) =  HtmlHelper.createElementWithChild "h3" value
    static member inline h3 (value: string) =  HtmlHelper.createElementWithChild "h3" value
    static member inline h3 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h3" children

    static member inline h4 xs = HtmlHelper.createElement "h4" xs
    static member inline h4 (value: float) = HtmlHelper.createElementWithChild "h4" value
    static member inline h4 (value: int) = HtmlHelper.createElementWithChild "h4" value
    static member inline h4 (value: ReactElement) = HtmlHelper.createElementWithChild "h4" value
    static member inline h4 (value: string) = HtmlHelper.createElementWithChild "h4" value
    static member inline h4 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h4" children

    static member inline h5 xs = HtmlHelper.createElement "h5" xs
    static member inline h5 (value: float) = HtmlHelper.createElementWithChild "h5" value
    static member inline h5 (value: int) = HtmlHelper.createElementWithChild "h5" value
    static member inline h5 (value: ReactElement) = HtmlHelper.createElementWithChild "h5" value
    static member inline h5 (value: string) = HtmlHelper.createElementWithChild "h5" value
    static member inline h5 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h5" children

    static member inline h6 xs = HtmlHelper.createElement "h6" xs
    static member inline h6 (value: float) = HtmlHelper.createElementWithChild "h6" value
    static member inline h6 (value: int) = HtmlHelper.createElementWithChild "h6" value
    static member inline h6 (value: ReactElement) = HtmlHelper.createElementWithChild "h6" value
    static member inline h6 (value: string) = HtmlHelper.createElementWithChild "h6" value
    static member inline h6 (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "h6" children

    static member inline head xs = HtmlHelper.createElement "head" xs
    static member inline head (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "head" children

    static member inline header xs = HtmlHelper.createElement "header" xs
    static member inline header (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "header" children

    static member inline hr xs = HtmlHelper.createElement "hr" xs

    static member inline html xs = HtmlHelper.createElement "html" xs
    static member inline html (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "html" children

    static member inline i xs = HtmlHelper.createElement "i" xs
    static member inline i (value: float) = HtmlHelper.createElementWithChild "i" value
    static member inline i (value: int) = HtmlHelper.createElementWithChild "i" value
    static member inline i (value: ReactElement) = HtmlHelper.createElementWithChild "i" value
    static member inline i (value: string) = HtmlHelper.createElementWithChild "i" value
    static member inline i (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "i" children

    static member inline iframe xs = HtmlHelper.createElement "iframe" xs

    static member inline img xs = HtmlHelper.createElement "img" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image xs = HtmlHelper.createElement "image" xs
    /// SVG Image element, not to be confused with HTML img alias.
    static member inline image (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "image" children

    static member inline input xs = HtmlHelper.createElement "input" xs

    static member inline ins xs = HtmlHelper.createElement "ins" xs
    static member inline ins (value: float) = HtmlHelper.createElementWithChild "ins" value
    static member inline ins (value: int) = HtmlHelper.createElementWithChild "ins" value
    static member inline ins (value: ReactElement) = HtmlHelper.createElementWithChild "ins" value
    static member inline ins (value: string) = HtmlHelper.createElementWithChild "ins" value
    static member inline ins (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ins" children

    static member inline kbd xs = HtmlHelper.createElement "kbd" xs
    static member inline kbd (value: float) = HtmlHelper.createElementWithChild "kbd" value
    static member inline kbd (value: int) = HtmlHelper.createElementWithChild "kbd" value
    static member inline kbd (value: ReactElement) = HtmlHelper.createElementWithChild "kbd" value
    static member inline kbd (value: string) = HtmlHelper.createElementWithChild "kbd" value
    static member inline kbd (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "kbd" children

    static member inline label xs = HtmlHelper.createElement "label" xs
    static member inline label (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "label" children

    static member inline legend xs = HtmlHelper.createElement "legend" xs
    static member inline legend (value: float) = HtmlHelper.createElementWithChild "legend" value
    static member inline legend (value: int) = HtmlHelper.createElementWithChild "legend" value
    static member inline legend (value: ReactElement) = HtmlHelper.createElementWithChild "legend" value
    static member inline legend (value: string) = HtmlHelper.createElementWithChild "legend" value
    static member inline legend (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "legend" children

    static member inline li xs = HtmlHelper.createElement "li" xs
    static member inline li (value: float) = HtmlHelper.createElementWithChild "li" value
    static member inline li (value: int) = HtmlHelper.createElementWithChild "li" value
    static member inline li (value: ReactElement) = HtmlHelper.createElementWithChild "li" value
    static member inline li (value: string) = HtmlHelper.createElementWithChild "li" value
    static member inline li (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "li" children
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line xs = HtmlHelper.createElement "line" xs
    [<Obsolete "Html.line is obsolete, use Svg.line instead">]
    static member inline line (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "line" children
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient xs = HtmlHelper.createElement "linearGradient" xs
    [<Obsolete "Html.linearGradient is obsolete, use Svg.linearGradient instead">]
    static member inline linearGradient (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "linearGradient" children

    static member inline link xs = HtmlHelper.createElement "link" xs

    static member inline listItem xs = HtmlHelper.createElement "li" xs
    static member inline listItem (value: float) = HtmlHelper.createElementWithChild "li" value
    static member inline listItem (value: int) = HtmlHelper.createElementWithChild "li" value
    static member inline listItem (value: ReactElement) = HtmlHelper.createElementWithChild "li" value
    static member inline listItem (value: string) = HtmlHelper.createElementWithChild "li" value
    static member inline listItem (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "li" children

    static member inline main xs = HtmlHelper.createElement "main" xs
    static member inline main (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "main" children

    static member inline map xs = HtmlHelper.createElement "map" xs
    static member inline map (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "map" children

    static member inline mark xs = HtmlHelper.createElement "mark" xs
    static member inline mark (value: float) = HtmlHelper.createElementWithChild "mark" value
    static member inline mark (value: int) = HtmlHelper.createElementWithChild "mark" value
    static member inline mark (value: ReactElement) = HtmlHelper.createElementWithChild "mark" value
    static member inline mark (value: string) = HtmlHelper.createElementWithChild "mark" value
    static member inline mark (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "mark" children
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker xs = HtmlHelper.createElement "marker" xs
    [<Obsolete "Html.marker is obsolete, use Svg.marker instead">]
    static member inline marker (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "marker" children
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask xs = HtmlHelper.createElement "mask" xs
    [<Obsolete "Html.mask is obsolete, use Svg.mask instead">]
    static member inline mask (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "mask" children

    static member inline meta xs = HtmlHelper.createElement "meta" xs

    static member inline metadata xs = HtmlHelper.createElement "metadata" xs
    static member inline metadata (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "metadata" children

    static member inline meter xs = HtmlHelper.createElement "meter" xs
    static member inline meter (value: float) = HtmlHelper.createElementWithChild "meter" value
    static member inline meter (value: int) = HtmlHelper.createElementWithChild "meter" value
    static member inline meter (value: ReactElement) = HtmlHelper.createElementWithChild "meter" value
    static member inline meter (value: string) = HtmlHelper.createElementWithChild "meter" value
    static member inline meter (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "meter" children
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath xs = HtmlHelper.createElement "mpath" xs
    [<Obsolete "Html.mpath is obsolte, use Svg.mpath instead">]
    static member inline mpath (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "mpath" children
    static member inline nav xs = HtmlHelper.createElement "nav" xs
    static member inline nav (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "nav" children

    /// The empty element, renders nothing on screen
    static member inline none : ReactElement = unbox null

    static member inline noscript xs = HtmlHelper.createElement "noscript" xs
    static member inline noscript (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "noscript" children

    static member inline object xs = HtmlHelper.createElement "object" xs
    static member inline object (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "object" children

    static member inline ol xs = HtmlHelper.createElement "ol" xs
    static member inline ol (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ol" children

    static member inline option xs = HtmlHelper.createElement "option" xs
    static member inline option (value: float) = HtmlHelper.createElementWithChild "option" value
    static member inline option (value: int) = HtmlHelper.createElementWithChild "option" value
    static member inline option (value: ReactElement) = HtmlHelper.createElementWithChild "option" value
    static member inline option (value: string) = HtmlHelper.createElementWithChild "option" value
    static member inline option (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "option" children

    static member inline optgroup xs = HtmlHelper.createElement "optgroup" xs
    static member inline optgroup (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "optgroup" children

    static member inline orderedList xs = HtmlHelper.createElement "ol" xs
    static member inline orderedList (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ol" children

    static member inline output xs = HtmlHelper.createElement "output" xs
    static member inline output (value: float) = HtmlHelper.createElementWithChild "output" value
    static member inline output (value: int) = HtmlHelper.createElementWithChild "output" value
    static member inline output (value: ReactElement) = HtmlHelper.createElementWithChild "output" value
    static member inline output (value: string) = HtmlHelper.createElementWithChild "output" value
    static member inline output (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "output" children

    static member inline p xs = HtmlHelper.createElement "p" xs
    static member inline p (value: float) = HtmlHelper.createElementWithChild "p" value
    static member inline p (value: int) = HtmlHelper.createElementWithChild "p" value
    static member inline p (value: ReactElement) = HtmlHelper.createElementWithChild "p" value
    static member inline p (value: string) = HtmlHelper.createElementWithChild "p" value
    static member inline p (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "p" children

    static member inline paragraph xs = HtmlHelper.createElement "p" xs
    static member inline paragraph (value: float) = HtmlHelper.createElementWithChild "p" value
    static member inline paragraph (value: int) = HtmlHelper.createElementWithChild "p" value
    static member inline paragraph (value: ReactElement) = HtmlHelper.createElementWithChild "p" value
    static member inline paragraph (value: string) = HtmlHelper.createElementWithChild "p" value
    static member inline paragraph (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "p" children

    static member inline param xs = HtmlHelper.createElement "param" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path xs = HtmlHelper.createElement "path" xs
    [<Obsolete "Html.path is obsolete, use Svg.path instead">]
    static member inline path (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "path" children
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern xs = HtmlHelper.createElement "pattern" xs
    [<Obsolete "Html.pattern is obsolete, use Svg.pattern instead">]
    static member inline pattern (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "pattern" children
    static member inline picture xs = HtmlHelper.createElement "picture" xs
    static member inline picture (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "picture" children
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon xs = HtmlHelper.createElement "polygon" xs
    [<Obsolete "Html.polygon is obsolete, use Svg.polygon instead">]
    static member inline polygon (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "polygon" children
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline xs = HtmlHelper.createElement "polyline" xs
    [<Obsolete "Html.polyline is obsolete, use Svg.polyline instead">]
    static member inline polyline (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "polyline" children
    static member inline pre xs = HtmlHelper.createElement "pre" xs
    static member inline pre (value: bool) = HtmlHelper.createElementWithChild "pre" value
    static member inline pre (value: float) = HtmlHelper.createElementWithChild "pre" value
    static member inline pre (value: int) = HtmlHelper.createElementWithChild "pre" value
    static member inline pre (value: ReactElement) = HtmlHelper.createElementWithChild "pre" value
    static member inline pre (value: string) = HtmlHelper.createElementWithChild "pre" value
    static member inline pre (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "pre" children

    static member inline progress xs = HtmlHelper.createElement "progress" xs
    static member inline progress (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "progress" children

    static member inline q xs = HtmlHelper.createElement "q" xs
    static member inline q (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "q" children
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient xs = HtmlHelper.createElement "radialGradient" xs
    [<Obsolete "Html.radialGradient is obsolete, use Svg.radialGradient instead">]
    static member inline radialGradient (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "radialGradient" children

    static member inline rb xs = HtmlHelper.createElement "rb" xs
    static member inline rb (value: float) = HtmlHelper.createElementWithChild "rb" value
    static member inline rb (value: int) = HtmlHelper.createElementWithChild "rb" value
    static member inline rb (value: ReactElement) = HtmlHelper.createElementWithChild "rb" value
    static member inline rb (value: string) = HtmlHelper.createElementWithChild "rb" value
    static member inline rb (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "rb" children
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect xs = HtmlHelper.createElement "rect" xs
    [<Obsolete "Html.rect is obsolete, use Svg.rect instead">]
    static member inline rect (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "rect" children

    static member inline rp xs = HtmlHelper.createElement "rp" xs
    static member inline rp (value: float) = HtmlHelper.createElementWithChild "rp" value
    static member inline rp (value: int) = HtmlHelper.createElementWithChild "rp" value
    static member inline rp (value: ReactElement) = HtmlHelper.createElementWithChild "rp" value
    static member inline rp (value: string) = HtmlHelper.createElementWithChild "rp" value
    static member inline rp (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "rp" children

    static member inline rt xs = HtmlHelper.createElement "rt" xs
    static member inline rt (value: float) = HtmlHelper.createElementWithChild "rt" value
    static member inline rt (value: int) = HtmlHelper.createElementWithChild "rt" value
    static member inline rt (value: ReactElement) = HtmlHelper.createElementWithChild "rt" value
    static member inline rt (value: string) = HtmlHelper.createElementWithChild "rt" value
    static member inline rt (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "rt" children

    static member inline rtc xs = HtmlHelper.createElement "rtc" xs
    static member inline rtc (value: float) = HtmlHelper.createElementWithChild "rtc" value
    static member inline rtc (value: int) = HtmlHelper.createElementWithChild "rtc" value
    static member inline rtc (value: ReactElement) = HtmlHelper.createElementWithChild "rtc" value
    static member inline rtc (value: string) = HtmlHelper.createElementWithChild "rtc" value
    static member inline rtc (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "rtc" children

    static member inline ruby xs = HtmlHelper.createElement "ruby" xs
    static member inline ruby (value: float) = HtmlHelper.createElementWithChild "ruby" value
    static member inline ruby (value: int) = HtmlHelper.createElementWithChild "ruby" value
    static member inline ruby (value: ReactElement) = HtmlHelper.createElementWithChild "ruby" value
    static member inline ruby (value: string) = HtmlHelper.createElementWithChild "ruby" value
    static member inline ruby (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ruby" children

    static member inline s xs = HtmlHelper.createElement "s" xs
    static member inline s (value: float) = HtmlHelper.createElementWithChild "s" value
    static member inline s (value: int) = HtmlHelper.createElementWithChild "s" value
    static member inline s (value: ReactElement) = HtmlHelper.createElementWithChild "s" value
    static member inline s (value: string) = HtmlHelper.createElementWithChild "s" value
    static member inline s (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "s" children

    static member inline samp xs = HtmlHelper.createElement "samp" xs
    static member inline samp (value: float) = HtmlHelper.createElementWithChild "samp" value
    static member inline samp (value: int) = HtmlHelper.createElementWithChild "samp" value
    static member inline samp (value: ReactElement) = HtmlHelper.createElementWithChild "samp" value
    static member inline samp (value: string) = HtmlHelper.createElementWithChild "samp" value
    static member inline samp (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "samp" children

    static member inline script xs = HtmlHelper.createElement "script" xs
    static member inline script (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "script" children

    static member inline section xs = HtmlHelper.createElement "section" xs
    static member inline section (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "section" children

    static member inline select xs = HtmlHelper.createElement "select" xs
    static member inline select (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "select" children
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set xs = HtmlHelper.createElement "set" xs
    [<Obsolete "Html.set is obsolete, use Svg.set instead">]
    static member inline set (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "set" children

    static member inline small xs = HtmlHelper.createElement "small" xs
    static member inline small (value: float) = HtmlHelper.createElementWithChild "small" value
    static member inline small (value: int) = HtmlHelper.createElementWithChild "small" value
    static member inline small (value: ReactElement) = HtmlHelper.createElementWithChild "small" value
    static member inline small (value: string) = HtmlHelper.createElementWithChild "small" value
    static member inline small (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "small" children

    static member inline source xs = HtmlHelper.createElement "source" xs

    static member inline span xs = HtmlHelper.createElement "span" xs
    static member inline span (value: float) = HtmlHelper.createElementWithChild "span" value
    static member inline span (value: int) = HtmlHelper.createElementWithChild "span" value
    static member inline span (value: ReactElement) = HtmlHelper.createElementWithChild "span" value
    static member inline span (value: string) = HtmlHelper.createElementWithChild "span" value
    static member inline span (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "span" children
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop xs = HtmlHelper.createElement "stop" xs
    [<Obsolete "Html.stop is obsolete, use Svg.stop instead">]
    static member inline stop (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "stop" children

    static member inline strong xs = HtmlHelper.createElement "strong" xs
    static member inline strong (value: float) = HtmlHelper.createElementWithChild "strong" value
    static member inline strong (value: int) = HtmlHelper.createElementWithChild "strong" value
    static member inline strong (value: ReactElement) = HtmlHelper.createElementWithChild "strong" value
    static member inline strong (value: string) = HtmlHelper.createElementWithChild "strong" value
    static member inline strong (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "strong" children

    static member inline style xs = HtmlHelper.createElement "style" xs
    static member inline style (value: string) = HtmlHelper.createElementWithChild "style" value

    static member inline sub xs = HtmlHelper.createElement "sub" xs
    static member inline sub (value: float) = HtmlHelper.createElementWithChild "sub" value
    static member inline sub (value: int) = HtmlHelper.createElementWithChild "sub" value
    static member inline sub (value: ReactElement) = HtmlHelper.createElementWithChild "sub" value
    static member inline sub (value: string) = HtmlHelper.createElementWithChild "sub" value
    static member inline sub (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "sub" children

    static member inline summary xs = HtmlHelper.createElement "summary" xs
    static member inline summary (value: float) = HtmlHelper.createElementWithChild "summary" value
    static member inline summary (value: int) = HtmlHelper.createElementWithChild "summary" value
    static member inline summary (value: ReactElement) = HtmlHelper.createElementWithChild "summary" value
    static member inline summary (value: string) = HtmlHelper.createElementWithChild "summary" value
    static member inline summary (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "summary" children

    static member inline sup xs = HtmlHelper.createElement "sup" xs
    static member inline sup (value: float) = HtmlHelper.createElementWithChild "sup" value
    static member inline sup (value: int) = HtmlHelper.createElementWithChild "sup" value
    static member inline sup (value: ReactElement) = HtmlHelper.createElementWithChild "sup" value
    static member inline sup (value: string) = HtmlHelper.createElementWithChild "sup" value
    static member inline sup (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "sup" children

    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg xs = HtmlHelper.createElement "svg" xs
    [<Obsolete "Html.svg is obsolete, use Svg.svg instead where Svg is the entry point to all SVG related elements">]
    static member inline svg (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "svg" children
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch xs = HtmlHelper.createElement "switch" xs
    [<Obsolete "Html.switch is obsolete, use Svg.switch instead">]
    static member inline switch (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "switch" children
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol xs = HtmlHelper.createElement "symbol" xs
    [<Obsolete "Html.symbol is obsolete, use Svg.symbol instead">]
    static member inline symbol (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "symbol" children

    static member inline table xs = HtmlHelper.createElement "table" xs
    static member inline table (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "table" children

    static member inline tableBody xs = HtmlHelper.createElement "tbody" xs
    static member inline tableBody (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tbody" children

    static member inline tableCell xs = HtmlHelper.createElement "td" xs
    static member inline tableCell (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "td" children

    static member inline tableHeader xs = HtmlHelper.createElement "th" xs
    static member inline tableHeader (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "th" children

    static member inline tableRow xs = HtmlHelper.createElement "tr" xs
    static member inline tableRow (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tr" children

    static member inline tbody xs = HtmlHelper.createElement "tbody" xs
    static member inline tbody (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tbody" children

    static member inline td xs = HtmlHelper.createElement "td" xs
    static member inline td (value: float) = HtmlHelper.createElementWithChild "td" value
    static member inline td (value: int) = HtmlHelper.createElementWithChild "td" value
    static member inline td (value: ReactElement) = HtmlHelper.createElementWithChild "td" value
    static member inline td (value: string) = HtmlHelper.createElementWithChild "td" value
    static member inline td (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "td" children

    static member inline template xs = HtmlHelper.createElement "template" xs
    static member inline template (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "template" children

    [<Obsolete "Html.text is obsolete for creating <text> SVG elements. Use Svg.text instead">]
    static member inline text xs = HtmlHelper.createElement "text" xs
    static member inline text (value: float) : ReactElement = unbox value
    static member inline text (value: int) : ReactElement = unbox value
    static member inline text (value: string) : ReactElement = unbox value
    static member inline text (value: System.Guid) : ReactElement = unbox (string value)

    static member inline textf fmt = Printf.kprintf Html.text fmt

    static member inline textarea xs = HtmlHelper.createElement "textarea" xs
    static member inline textarea (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "textarea" children
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath xs = HtmlHelper.createElement "textPath" xs
    [<Obsolete "Html.textPath is obsolete, use Svg.textPath instead">]
    static member inline textPath (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "textPath" children

    static member inline tfoot xs = HtmlHelper.createElement "tfoot" xs
    static member inline tfoot (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tfoot" children

    static member inline th xs = HtmlHelper.createElement "th" xs
    static member inline th (value: float) = HtmlHelper.createElementWithChild "th" value
    static member inline th (value: int) = HtmlHelper.createElementWithChild "th" value
    static member inline th (value: ReactElement) = HtmlHelper.createElementWithChild "th" value
    static member inline th (value: string) = HtmlHelper.createElementWithChild "th" value
    static member inline th (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "th" children

    static member inline thead xs = HtmlHelper.createElement "thead" xs
    static member inline thead (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "thead" children

    static member inline time xs = HtmlHelper.createElement "time" xs
    static member inline time (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "time" children
    static member inline title xs = HtmlHelper.createElement "title" xs
    static member inline title (value: float) = HtmlHelper.createElementWithChild "title" value
    static member inline title (value: int) = HtmlHelper.createElementWithChild "title" value
    static member inline title (value: ReactElement) = HtmlHelper.createElementWithChild "title" value
    static member inline title (value: string) = HtmlHelper.createElementWithChild "title" value
    static member inline title (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "title" children
    static member inline tr xs = HtmlHelper.createElement "tr" xs
    static member inline tr (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tr" children

    static member inline track xs = HtmlHelper.createElement "track" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan xs = HtmlHelper.createElement "tspan" xs
    [<Obsolete "Html.tspan is obsolete, use Svg.tspan instead">]
    static member inline tspan (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "tspan" children

    static member inline u xs = HtmlHelper.createElement "u" xs
    static member inline u (value: float) = HtmlHelper.createElementWithChild "u" value
    static member inline u (value: int) = HtmlHelper.createElementWithChild "u" value
    static member inline u (value: ReactElement) = HtmlHelper.createElementWithChild "u" value
    static member inline u (value: string) = HtmlHelper.createElementWithChild "u" value
    static member inline u (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "u" children

    static member inline ul xs = HtmlHelper.createElement "ul" xs
    static member inline ul (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ul" children

    static member inline unorderedList xs = HtmlHelper.createElement "ul" xs
    static member inline unorderedList (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "ul" children
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' xs = HtmlHelper.createElement "use" xs
    [<Obsolete "Html.use is obsolete, use Svg.use instead">]
    static member inline use' (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "use" children
    static member inline var xs = HtmlHelper.createElement "var" xs
    static member inline var (value: float) = HtmlHelper.createElementWithChild "var" value
    static member inline var (value: int) = HtmlHelper.createElementWithChild "var" value
    static member inline var (value: ReactElement) = HtmlHelper.createElementWithChild "var" value
    static member inline var (value: string) = HtmlHelper.createElementWithChild "var" value
    static member inline var (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "var" children

    static member inline video xs = HtmlHelper.createElement "video" xs
    static member inline video (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "video" children
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view xs = HtmlHelper.createElement "view" xs
    [<Obsolete "Html.view is obsolete, use Svg.view instead">]
    static member inline view (children: #seq<ReactElement>) = HtmlHelper.createElementWithChildren "view" children

    static member inline wbr xs = HtmlHelper.createElement "wbr" xs
