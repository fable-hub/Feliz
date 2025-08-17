namespace Feliz.Markdown

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IMarkdownRenderer = interface end

type ICodeProperties =
    abstract isInline : bool
    abstract className : string
    abstract children: ReactElement []

type ITextProperties =
    abstract children: string

type IParagraphProperties =
    abstract children: ReactElement []

type ILinkProperties =
    abstract href: string
    abstract children: ReactElement []

type IHeadingProperties =
    abstract level: int
    abstract children: ReactElement []

type ITableProperties =
    abstract children: ReactElement []

type ITableHeadProperties =
    abstract children: ReactElement []

type ITableBodyProperties =
    abstract children: ReactElement []

type ITableRowProperties =
    abstract children: ReactElement []

type ITableCellProperties =
    abstract isHeader: bool
    abstract children: ReactElement []

type IListProperties =
    abstract children: ReactElement []

type IListItemProperties =
    abstract children: ReactElement []

type IPluginsProperties =
    abstract children: ReactElement []

type IPreProperties = 
    abstract children: ReactElement []

type IComponent = interface end

[<Erase>]
module markdown =
    [<Erase; System.Obsolete "markdown.renderers is obsolete. Use markdown.components instead">]
    type renderers =
        static member inline code (render: ICodeProperties -> Fable.React.ReactElement) =
            unbox<IMarkdownRenderer> (PropHelper.mkAttr "code" render)

    [<Erase>]
    type components =
        static member inline p(render: IParagraphProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "p" render)
        static member inline linkReference(render: ILinkProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "linkReference" render)
        static member inline h1(render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h1" render)
        static member inline h2(render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h2" render)
        static member inline h3 (render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h3" render)
        static member inline h4(render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h4" render)
        static member inline h5 (render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h5" render)
        static member inline h6(render: IHeadingProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "h6" render)
        static member inline table(render: ITableProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "table" render)
        static member inline thead(render: ITableHeadProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "thead" render)
        static member inline tbody(render: ITableBodyProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "tbody" render)
        static member inline trow(render: ITableRowProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "trow" render)
        static member inline tcell(render: ITableCellProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "tcell" render)
        static member inline ol(render: IListProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "ol" render)
        static member inline ul(render: IListProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "ul" render)
        static member inline li(render: IListProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "li" render)
        static member inline code(render: ICodeProperties -> ReactElement) = 
            let renderInternal (props: obj) = 
                let inputs = createObj [
                    "className" ==> emitJsExpr<string> props "$0.className || \"\""
                    "children" ==> emitJsExpr<ReactElement []> props "$0.children || []"
                    "isInline" ==> emitJsExpr<bool> props "$0.inline || false"
                ]
                render (unbox<ICodeProperties> inputs)
            unbox<IComponent> (PropHelper.mkAttr "code" renderInternal)
        static member inline pre(render: ICodeProperties -> ReactElement) = unbox<IComponent> (PropHelper.mkAttr "pre" render)


type INodeType = interface end

/// Contains all possible node types
[<Erase>]
type nodeTypes =
    static member inline root = unbox<INodeType> "root"
    static member inline text = unbox<INodeType> "text"
    static member inline breakTag = unbox<INodeType> "break"
    static member inline paragraph = unbox<INodeType> "paragraph"
    static member inline emphasis = unbox<INodeType> "emphasis"
    static member inline strong = unbox<INodeType> "strong"
    static member inline thematicBreak = unbox<INodeType> "thematicBreak"
    static member inline blockquote = unbox<INodeType> "blockquote"
    static member inline delete = unbox<INodeType> "delete"
    static member inline link = unbox<INodeType> "link"
    static member inline image = unbox<INodeType> "image"
    static member inline linkReference = unbox<INodeType> "linkReference"
    static member inline imageReference = unbox<INodeType> "imageReference"
    static member inline table = unbox<INodeType> "table"
    static member inline tableHead = unbox<INodeType> "tableHead"
    static member inline tableBody = unbox<INodeType> "tableBody"
    static member inline tableRow = unbox<INodeType> "tableRow"
    static member inline tableCell = unbox<INodeType> "tableCell"
    static member inline list = unbox<INodeType> "list"
    static member inline listItem = unbox<INodeType> "listItem"
    static member inline definition = unbox<INodeType> "definition"
    static member inline heading = unbox<INodeType> "heading"
    static member inline inlineCode = unbox<INodeType> "inlineCode"
    static member inline code = unbox<INodeType> "code"
    static member inline html = unbox<INodeType> "html"
    static member inline virtualHtml = unbox<INodeType> "virtualHtml"

[<Erase>]
type markdown =
    /// The Markdown source to parse 
    [<System.Obsolete "markdown.source is deprecated. Use markdown.children insteadf">]
    static member inline source (value: string) = PropHelper.mkAttr "children" value
    /// The Markdown source to parse
    static member inline children (value: string) = PropHelper.mkAttr "children" value
    static member inline components(components: IComponent list) = PropHelper.mkAttr "components" (createObj !!components)
    /// Setting to `false` will cause HTML to be rendered (see notes below about proper HTML support). Be aware that setting this to false might cause security issues if the input is user-generated. Use at your own risk. (default: `true`).
    static member inline escapeHtml(value: bool) = PropHelper.mkAttr "escapeHtml" value
    /// Setting to `true` will skip inlined and blocks of HTML (default: `false`).
    static member inline skipHtml(value: bool) = PropHelper.mkAttr "skipHtml" value
    /// Setting to `true` will add `data-sourcepos` attributes to all elements, indicating where in the markdown source they were rendered from (default: `false`).
    static member inline sourcePosition(value: bool) = PropHelper.mkAttr "sourcePos" value
    /// Setting to `true` will pass a sourcePosition property to all renderers with structured source position information (default: `false`).
    static member inline rawSourcePosition(value: bool) = PropHelper.mkAttr "rawSourcePos" value
    /// Setting to `true` will pass index and parentChildCount props to all renderers (default: `false`).
    static member inline includeNodeIndex (value: bool) = PropHelper.mkAttr "includeNodeIndex" value
    /// Defines which types of nodes should be allowed (rendered). (default: all types).
    static member inline allowedTypes (types: INodeType list) = PropHelper.mkAttr "allowedTypes" (Array.ofList types)
    /// Defines which types of nodes should be allowed (rendered). (default: all types).
    static member inline allowedTypes (types: INodeType array) = PropHelper.mkAttr "allowedTypes" types
    /// Defines which types of nodes should be disallowed (not rendered). (default: none).
    static member inline disallowedTypes (types: INodeType list) = PropHelper.mkAttr "disallowedTypes" (Array.ofList types)
    /// Defines which types of nodes should be disallowed (not rendered). (default: none).
    static member inline disallowedTypes (types: INodeType array) = PropHelper.mkAttr "disallowedTypes" types
    [<System.Obsolete "markdown.renderers is obsolete. Use markdown.components instead">]
    static member inline renderers (renderers: IMarkdownRenderer list) =
        PropHelper.mkAttr "renderers" (createObj !!renderers)
    

[<Erase>]
type Markdown =
    static member inline markdown (properties: seq<IReactProperty>) =
        ReactLegacy.createElement (
            ``type`` = unbox<ReactNode> (importDefault "react-markdown"), 
            props = Fable.Core.JsInterop.createObj !!properties
        )
    static member inline markdown (sourceMarkdown: string) =
        ReactLegacy.createElement (
            ``type`` = unbox<ReactNode> (importDefault "react-markdown"), 
            children = unbox<ReactElement> sourceMarkdown
        )
