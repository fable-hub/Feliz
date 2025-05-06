namespace Feliz

open System
open Fable.Core

type ReactDOM =
    [<Import("render", "react-dom"); Obsolete("ReactDOM.render is obsolete since React v18. Please use the ReactDOM.createRoot API instead")>]
    static member render(element: Fable.React.ReactElement, container: Browser.Types.HTMLElement) = jsNative
    [<Obsolete("ReactDOM.render is obsolete since React v18. Please use the ReactDOM.createRoot API instead")>]
    static member render(element: unit -> Fable.React.ReactElement, container: Browser.Types.HTMLElement) = ReactDOM.render(element(), container)
    [<Import("createRoot", "react-dom/client")>]
    static member createRoot(container: Browser.Types.HTMLElement) : ReactApi.IReactRoot = jsNative
    [<Import("createPortal", "react-dom")>]
    static member createPortal (element : Fable.React.ReactElement, container : Browser.Types.HTMLElement) : Fable.React.ReactElement = jsNative

/// The ReactDOMServer object enables you to render components to static markup.
type ReactDOMServer =
    /// Render a React element to its initial HTML. React will return an HTML string. You can use this method to generate HTML on the server and send the markup down on the initial request for faster page loads and to allow search engines to crawl your pages for SEO purposes.
    [<Import("renderToString", "react-dom/server")>]
    static member renderToString(element: ReactElement) : string = jsNative
    /// Similar to renderToString, except this doesn’t create extra DOM attributes that React uses internally, such as data-reactroot. This is useful if you want to use React as a simple static page generator, as stripping away the extra attributes can save some bytes.
    ///
    /// If you plan to use React on the client to make the markup interactive, do not use this method. Instead, use `renderToString` on the server and `ReactDOM.hydrate()` on the client.
    [<Import("renderToStaticMarkup", "react-dom/server")>]
    static member renderToStaticMarkup(element: ReactElement) : string = jsNative