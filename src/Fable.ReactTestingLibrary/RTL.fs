namespace Fable.ReactTestingLibrary

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open System.Text.RegularExpressions

type RTL =
    /// This is a light wrapper around the react-dom/test-utils act function. 
    /// All it does is forward all arguments to the act function if your version of react supports act.
    static member act (callback: unit -> unit) = Bindings.act callback

    /// Unmounts React trees that were mounted with render.
    static member cleanup () = Bindings.cleanup()

    /// Set the configuration options.
    static member configure (options: IConfigureOption list) = 
        Bindings.configure(unbox<IConfigureOptions> (createObj !!options))

    /// Fires a DOM event.
    static member fireEvent (element: #HTMLElement, event: #Browser.Types.Event) = 
        Bindings.fireEvent.custom(element, event)

    /// Gets the text of the element.
    static member getNodeText (element: #HTMLElement) =
        Bindings.getNodeText element

    /// Allows iteration over the implicit ARIA roles represented 
    /// in a given tree of DOM nodes.
    ///
    /// It returns an object, indexed by role name, with each value being an 
    /// array of elements which have that implicit ARIA role.
    static member getRoles (element: #HTMLElement) =
        Bindings.getRoles element

    /// Compute if the given element should be excluded from the accessibility API by the browser. 
    /// 
    /// It implements every MUST criteria from the Excluding Elements from the Accessibility Tree 
    /// section in WAI-ARIA 1.2 with the exception of checking the role attribute.
    static member isInaccessible (element: #HTMLElement) =
        Bindings.isInaccessible element

    /// Print out a list of all the implicit ARIA roles within a tree of DOM nodes, each role 
    /// containing a list of all of the nodes which match that role.
    static member logRoles (element: #HTMLElement) =
        Bindings.logRoles element

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: #HTMLElement) =
        Bindings.prettyDOMImport.invoke element

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (node: Node) =
        Bindings.prettyDOMImport.invoke (unbox node)

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: #HTMLElement, maxLength: int) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength)

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: #HTMLElement, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, options = (unbox (createObj !!options)))

    /// Returns a readable representation of the DOM tree of a node.
    static member prettyDOM (element: #HTMLElement, maxLength: int, options: IPrettyDOMOption list) =
        Bindings.prettyDOMImport.invoke(element, maxLength = maxLength, options = (unbox (createObj !!options)))

    /// Render into a container which is appended to document.body.
    ///
    /// By default, React Testing Library will create a div and append that div to the document.body and 
    /// this is where your React component will be rendered. If you provide your own HTMLElement container 
    /// via this option, it will not be appended to the document.body automatically.
    ///
    /// If the container is specified, then this defaults to that, otherwise this defaults to document.documentElement. 
    /// This is used as the base element for the queries as well as what is printed when you use debug().
    ///
    /// If hydrate is set to true, then it will render with ReactDOM.hydrate. This may be useful if you 
    /// are using server-side rendering and use ReactDOM.hydrate to mount your components.
    ///
    /// Pass a React Component as the wrapper option to have it rendered around the inner element. 
    /// This is most useful for creating reusable custom render functions for common data providers.
    static member render (reactElement: ReactElement) = 
        Bindings.renderImport.invoke reactElement
        |> Bindings.render<HTMLElement,HTMLElement>
    /// Render into a container which is appended to document.body.
    ///
    /// By default, React Testing Library will create a div and append that div to the document.body and 
    /// this is where your React component will be rendered. If you provide your own HTMLElement container 
    /// via this option, it will not be appended to the document.body automatically.
    ///
    /// If the container is specified, then this defaults to that, otherwise this defaults to document.documentElement. 
    /// This is used as the base element for the queries as well as what is printed when you use debug().
    ///
    /// If hydrate is set to true, then it will render with ReactDOM.hydrate. This may be useful if you 
    /// are using server-side rendering and use ReactDOM.hydrate to mount your components.
    ///
    /// Pass a React Component as the wrapper option to have it rendered around the inner element. 
    /// This is most useful for creating reusable custom render functions for common data providers.
    static member render<'BaseElement, 'Container when 'BaseElement :> HTMLElement and 'Container :> HTMLElement>
        (reactElement: ReactElement, 
         ?baseElement: 'BaseElement, 
         ?container: 'Container, 
         ?hydrate: bool, 
         ?wrapper: ReactElement) = 
        
        Bindings.renderImport.invoke(reactElement, options = Bindings.createRenderOptions baseElement container hydrate wrapper)
        |> Bindings.render<'BaseElement,'Container>

    /// Queries bound to the document.body
    static member screen = RTL.within(unbox Browser.Dom.document.body)

    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> unit) = Bindings.waitForImport.invoke callback
    /// When in need to wait for any period of time you can use waitFor, to wait for your expectations to pass.
    static member waitFor (callback: unit -> unit, waitForOptions: IWaitOption list) = 
        Bindings.waitForImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 

    /// Wait for the removal of an element from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> #HTMLElement option) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback)
    /// Wait for the removal of elements from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> #HTMLElement list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback >> ResizeArray)
    /// Wait for the removal of an element from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> #HTMLElement option, waitForOptions: IWaitOption list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback, unbox<IWaitOptions> (createObj !!waitForOptions)) 
    /// Wait for the removal of an element from the DOM.
    static member waitForElementToBeRemoved (callback: unit -> #HTMLElement list, waitForOptions: IWaitOption list) = 
        Bindings.waitForElementToBeRemovedImport.invoke(callback >> ResizeArray, unbox<IWaitOptions> (createObj !!waitForOptions)) 
        
    /// Takes a DOM element and binds it to the raw query functions, allowing them to be used without specifying a container. 
    static member within<'Element when 'Element :> HTMLElement> (element: 'Element) =
        Bindings.withinImport.invoke element
        |> Bindings.queriesForElement

type configureOption =
    /// The default value for the hidden option used by getByRole. 
    ///
    /// Defaults to false.
    static member defaultHidden (value: bool) = Interop.mkConfigureOption "defaultHidden" value

    /// A function that returns the error used when getBy* or getAllBy* fail. 
    /// Takes the error message and container object as arguments.
    static member getElementError (handler: string * #HTMLElement -> exn) = 
        Interop.mkConfigureOption "getElementError" handler

    /// By default, waitFor will ensure that the stack trace for errors thrown 
    /// by Testing Library is cleaned up and shortened so it's easier for you to 
    /// identify the part of your code that resulted in the error (async stack 
    /// traces are hard to debug). 
    ///
    /// You can also disable this for a specific call in the options you pass to waitFor.
    static member showOriginalStackTrace (value: bool) = Interop.mkConfigureOption "showOriginalStackTrace" value

    /// The attribute used by getByTestId and related queries. 
    ///
    /// Defaults to data-testid.
    static member testIdAttribute (value: string) = Interop.mkConfigureOption "defaultHidden" value

    /// When enabled, if better queries are available the test will fail and provide a suggested 
    /// query to use instead. 
    ///
    /// Defaults to false.
    ///
    /// You can disable a suggestion for a single query in the options of that query.
    static member throwSuggestions (value: bool) = Interop.mkConfigureOption "throwSuggestions" value
    
type queryOption =
    /// If true, only includes elements in the query set that are marked as
    /// checked in the accessibility tree, i.e., `aria-checked="true"`
    static member checked' (value: bool) = Interop.mkRoleMatcherOption "checked" value

    /// Requires an exact match.
    /// 
    /// Defaults to true.
    static member exact (value: bool) = Interop.mkMatcherOption "exact" value
    
    /// If set to true, elements that are normally excluded from the
    /// accessibility tree are considered for the query as well.
    ///
    /// Defaults to false.
    static member hidden (value: bool) = Interop.mkRoleMatcherOption "hidden" value

    /// Disables selector exclusions.
    ///
    /// Defaults to true.
    static member ignore (value: bool) = Interop.mkTextMatcherOption "ignore" value
    /// Specify selectors to exclude from matches.
    ///
    /// Such as if you had two elements with the same testId, if one is an input,
    /// you could use queryOption.selector "input" to exclude that input element.
    ///
    /// Defaults to "script".
    static member ignore (value: string) = Interop.mkTextMatcherOption "ignore" value
    
    /// Adds a query condition based on a match of the level.
    ///
    /// Such as a h1-h6 element, or aria-level.
    static member level (value: int) = Interop.mkRoleMatcherOption "level" value

    /// Adds a query condition based on a match of the accessible name.
    ///
    /// Such as a label element, label attribute, or aria-label.
    static member name (value: string) = Interop.mkRoleMatcherOption "name" value
    /// Adds a query condition based on a match of the accessible name.
    ///
    /// Such as a label element, label attribute, or aria-label.
    static member name (value: Regex) = Interop.mkRoleMatcherOption "name" value
    /// Adds a query condition based on a match of the accessible name.
    ///
    /// Such as a label element, label attribute, or aria-label.
    static member name (fn: #HTMLElement -> bool) = Interop.mkRoleMatcherOption "name" fn
    
    /// If true, only includes elements in the query set that are marked as
    /// pressed in the accessibility tree, i.e., `aria-pressed="true"`
    static member pressed (value: bool) = Interop.mkRoleMatcherOption "pressed" value

    /// Allows transforming the text before the match.
    static member normalizer (fn: string -> string) = Interop.mkMatcherOption "normalizer" fn
    
    /// Adds a query condition based on if the element is selected.
    ///
    /// Such as a selected attribute or aria-selected.
    static member selected (value: bool) = Interop.mkRoleMatcherOption "selected" value
    
    /// Specify a selector to reduce matches.
    ///
    /// Such as if you had two elements with the same testId, if one is an input,
    /// you could use queryOption.selector "input" to get that input element.
    ///
    /// Defaults to "*".
    static member selector (value: string) = Interop.mkLabelTextMatcherOption "selector" value
    
    /// Allows disabling query suggestions if the global setting is enabled.
    ///
    /// Defaults to true.
    static member suggest (value: bool) = Interop.mkMatcherOption "suggest" value

type prettyDOMOption =
    /// Call toJSON method (if it exists) on objects.
    static member callToJSON (value: bool) = Interop.mkPrettyDOMOption "callToJSON" value
    /// Escape special characters in regular expressions.
    static member escapeRegex (value: bool) = Interop.mkPrettyDOMOption "escapeRegex" value
    /// Escape special characters in strings.
    static member escapeString (value: bool) = Interop.mkPrettyDOMOption "escapeString" value
    /// Highlight syntax with colors in terminal (some plugins).
    static member highlight (value: bool) = Interop.mkPrettyDOMOption "highlight" value
    /// Spaces in each level of indentation.
    static member indent (value: int) = Interop.mkPrettyDOMOption "indent" value
    /// Levels to print in arrays, objects, elements, .. etc.
    static member maxDepth (value: int) = Interop.mkPrettyDOMOption "maxDepth" value
    /// Minimize added space: no indentation nor line breaks.
    static member min (value: bool) = Interop.mkPrettyDOMOption "min" value
    /// Plugins to serialize application-specific data types.
    static member plugins (value: seq<string>) = Interop.mkPrettyDOMOption "plugins" (ResizeArray value)
    /// Include or omit the name of a function.
    static member printFunctionName (value: bool) = Interop.mkPrettyDOMOption "printFunctionName" value
    /// Colors to highlight syntax in terminal.
    static member theme (properties: IPrettyDOMThemeOption list) = Interop.mkPrettyDOMOption "theme" (createObj !!properties)

[<RequireQualifiedAccess>]
module prettyDOMOption =
    /// PrettyDOM theme options.
    type theme =
        /// Default: "gray"
        static member comment (value: string) = Interop.mkPrettyDOMOThemeption "comment" value
        /// Default: "reset"
        static member content (value: string) = Interop.mkPrettyDOMOThemeption "content" value
        /// Default: "yellow"
        static member prop (value: string) = Interop.mkPrettyDOMOThemeption "prop" value
        /// Default: "cyan"
        static member tag (value: string) = Interop.mkPrettyDOMOThemeption "tag" value
        /// Default: "green"
        static member value (value: string) = Interop.mkPrettyDOMOThemeption "value" value

type waitForOption =
    /// The default container is the global document. 
    ///
    /// Make sure the elements you wait for are descendants of container.
    static member container (element: #HTMLElement) = Interop.mkWaitOption "container" element

    /// The default interval is 50ms. 
    ///
    /// However it will run your callback immediately before starting the intervals.
    static member interval (value: int) = Interop.mkWaitOption "interval" value

    /// Sets the configuration of the mutation observer.
    static member mutationObserver (options: IMutationObserverOption list) = Interop.mkWaitOption "mutationObserverOptions" (createObj !!options)

    /// The default timeout is 1000ms.
    static member timeout (value: int) = Interop.mkWaitOption "timeout" value

[<RequireQualifiedAccess>]
module waitForOption =
    type mutationObserver =
        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member attributeFiler (filter: string) = Interop.mkMutationObserverOption "attributeFilter" (filter |> Array.singleton |> ResizeArray)

        /// An array of specific attribute names to be monitored. 
        ///
        /// If this property isn't included, changes to all attributes cause mutation notifications.
        static member attributeFiler (filters: string list) = Interop.mkMutationObserverOption "attributeFilter" (filters |> ResizeArray)

        /// Set to true to record the previous value of any attribute that changes when monitoring the node or nodes for attribute changes.
        ///
        /// The default value is `false` via omission.
        static member attributeOldValue (value: bool) = Interop.mkMutationObserverOption "attributeOldValue" value

        /// Set to true to watch for changes to the value of attributes on the node or nodes being monitored. 
        ///
        /// The default value is false.
        static member attributes (value: bool) = Interop.mkMutationObserverOption "attributes" value

        /// Set to true to monitor the specified target node or subtree for changes to the character data contained within the node or nodes. 
        ///
        /// The default value is `false` via omission.
        static member characterData (value: bool) = Interop.mkMutationObserverOption "characterData" value

        /// Set to true to record the previous value of a node's text whenever the text changes on nodes being monitored.
        ///
        /// The default value is `false` via omission.
        static member characterDataOldValue (value: bool) = Interop.mkMutationObserverOption "characterDataOldValue" value

        /// Set to true to monitor the target node (and, if subtree is true, its descendants) for the addition of 
        /// new child nodes or removal of existing child nodes. 
        ///
        /// The default is false.
        static member childList (value: bool) = Interop.mkMutationObserverOption "childList" value

        /// Set to true to extend monitoring to the entire subtree of nodes rooted at target. All of the other MutationObserverInit properties 
        /// are then extended to all of the nodes in the subtree instead of applying solely to the target node. 
        ///
        /// The default value is false.
        static member subtree (value: bool) = Interop.mkMutationObserverOption "subtree" value

[<RequireQualifiedAccess>]
module RTL =
    /// Convenience methods for creating DOM events that can then be fired by fireEvent, allowing you to have a 
    /// reference to the event created: this might be useful if you need to access event properties that cannot 
    /// be initiated programmatically (such as timeStamp).
    type createEvent =
        static member abort (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member abort (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationEnd (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationIteration (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationStart (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member blur (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member canPlay (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member canPlayThrough (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member change (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member click (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionEnd (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionStart (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionUpdate (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member contextMenu (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member copy (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member cut (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dblClick (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member doubleClick (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member drag (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragEnd (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragEnter (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragExit (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragLeave (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragOver (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragStart (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member drop (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member durationChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member emptied (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member encrypted (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member ended (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member error (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member error (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focus (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focusIn (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focusOut (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member gotPointerCapture (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member input (element: #HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member invalid (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyDown (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyPress (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyUp (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member load (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member load (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadedData (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadedMetadata (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadStart (element: #HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member lostPointerCapture (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseDown (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseEnter (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseLeave (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseMove (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseOut (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseOver (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseUp (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member paste (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pause (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member play (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member playing (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerCancel (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerDown (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerEnter (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerLeave (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerMove (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerOut (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerOver (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerUp (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member popState (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))        
        static member progress (element: #HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member rateChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member reset (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member scroll (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member seeked (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member seeking (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member select (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member stalled (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member submit (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member suspend (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member timeUpdate (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchCancel (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchEnd (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchMove (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchStart (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member transitionEnd (element: #HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member volumeChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member waiting (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member wheel (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))

    /// Convenience methods for firing DOM events.
    type fireEvent =
        static member abort (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member abort (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationEnd (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationIteration (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member animationStart (element: #HTMLElement, ?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member blur (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member canPlay (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member canPlayThrough (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member change (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member click (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionEnd (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionStart (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member compositionUpdate (element: #HTMLElement, ?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member contextMenu (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member copy (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member cut (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dblClick (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member doubleClick (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member drag (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragEnd (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragEnter (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragExit (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragLeave (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragOver (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member dragStart (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member drop (element: #HTMLElement, ?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member durationChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member emptied (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member encrypted (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member ended (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member error (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member error (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focus (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focusIn (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member focusOut (element: #HTMLElement, ?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member gotPointerCapture (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member input (element: #HTMLElement, ?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member invalid (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyDown (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyPress (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member keyUp (element: #HTMLElement, ?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member load (element: #HTMLElement, ?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member load (element: #HTMLElement, ?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadedData (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadedMetadata (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member loadStart (element: #HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member lostPointerCapture (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseDown (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseEnter (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseLeave (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseMove (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseOut (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseOver (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member mouseUp (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member paste (element: #HTMLElement, ?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pause (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member play (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member playing (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerCancel (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerDown (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerEnter (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerLeave (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerMove (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerOut (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerOver (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member pointerUp (element: #HTMLElement, ?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member popState (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))        
        static member progress (element: #HTMLElement, ?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member rateChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member reset (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member scroll (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member seeked (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member seeking (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member select (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member stalled (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member submit (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member suspend (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member timeUpdate (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchCancel (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchEnd (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchMove (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member touchStart (element: #HTMLElement, ?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member transitionEnd (element: #HTMLElement, ?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member volumeChange (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member waiting (element: #HTMLElement, ?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        static member wheel (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))

    /// Convenience methods for using fireEvent.
    type userEvent =
        /// Selects the text inside an input or textarea and deletes it.
        static member clear (element: #HTMLElement) = Bindings.userEvent.clear(element)
        /// Clicks element, depending on what element is it can have different side effects.
        static member click (element: #HTMLElement, ?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            let eventInit = (eventProperties |> Option.map (fun props -> createObj !!props))
            let options = Bindings.createClickOptions clickCount skipHover

            Bindings.userEvent.click(element, ?eventInit = eventInit, ?options = options)
        /// Cntrl + clicks element, depending on what element is it can have different side effects.
        static member ctrlClick (element: #HTMLElement, ?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) = 
            let eventInit = createObj !!(Option.defaultValue [] eventProperties @ (unbox [ mouseEvent.ctrlKey true ]))
            let options = Bindings.createClickOptions clickCount skipHover

            Bindings.userEvent.click(element, eventInit, ?options = options)
        /// Clicks element twice, depending on what element is it can have different side effects.
        static member dblClick (element: #HTMLElement, ?eventProperties: #IMouseEventProperty list) = 
            Bindings.userEvent.dblClick(element, ?eventInit = (eventProperties |> Option.map (fun props -> createObj !!props)))
        /// Hovers over an element.
        static member hover (element: #HTMLElement) = Bindings.userEvent.hover(element)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: #HTMLElement, values: 'T []) = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: #HTMLElement, values: 'T list) = Bindings.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        static member selectOptions (element: #HTMLElement, values: ResizeArray<'T>) = Bindings.userEvent.selectOptions(element, values)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        static member deselectOptions (element: #HTMLElement, values: 'T []) : unit = Bindings.userEvent.deselectOptions(element, values)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        static member deselectOptions (element: #HTMLElement, values: 'T list) : unit = Bindings.userEvent.deselectOptions(element, values)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        static member deselectOptions (element: #HTMLElement, values: ResizeArray<'T>) : unit = Bindings.userEvent.deselectOptions(element, values)
        /// Shift + clicks element, depending on what element is it can have different side effects.
        static member shiftClick (element: #HTMLElement, ?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            let eventInit = createObj !!(Option.defaultValue [] eventProperties @ (unbox [ mouseEvent.shiftKey true ]))
            let options = Bindings.createClickOptions clickCount skipHover

            Bindings.userEvent.click(element, eventInit, ?options = options)
        /// Cntrl + shift + clicks element, depending on what element is it can have different side effects.
        static member shiftCtrlClick (element: #HTMLElement, ?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            let eventInit = createObj !!(Option.defaultValue [] eventProperties @ (unbox [ mouseEvent.shiftKey true; mouseEvent.ctrlKey true ]))
            let options = Bindings.createClickOptions clickCount skipHover

            Bindings.userEvent.click(element, eventInit, ?options = options)
        /// Fires a tab event changing the document.activeElement in the same way the browser does.
        static member tab (?shift: bool, ?focusTrap: #HTMLElement) = Bindings.userEvent.tab(?options = Bindings.createTabOptions shift focusTrap)
        /// Writes text inside an <input> or a <textarea>.
        ///
        /// You can use special characters via brackets such as {enter}, supported keys:
        /// enter, esc, backspace, shift, ctrl, alt, meta
        ///
        /// shift, ctrl, alt, and meta will activate their respective event key. Which is 
        /// ended with a closing tag: {/shift}, {/ctrl}, {/alt}, and {/meta}.
        ///
        /// shift does *not* cause lowercase text to become uppercase.
        static member type' (element: #HTMLElement, text: string, ?skipClick: bool, ?skipAutoClose: bool, ?initialSelectionStart: int, ?initialSelectionEnd: int) = 
            Bindings.userEvent.typeInternal(element, text, Bindings.createTypeOptions skipClick skipAutoClose None initialSelectionStart initialSelectionEnd)
        /// Writes text inside an <input> or a <textarea>.
        ///
        /// You can use special characters via brackets such as {enter}, supported keys:
        /// enter, esc, backspace, shift, ctrl, alt, meta
        ///
        /// shift, ctrl, alt, and meta will activate their respective event key. Which is 
        /// ended with a closing tag: {/shift}, {/ctrl}, {/alt}, and {/meta}.
        ///
        /// shift does *not* cause lowercase text to become uppercase.
        static member type' (element: #HTMLElement, text: string, delayMS: int, ?skipClick: bool, ?skipAutoClose: bool, ?initialSelectionStart: int, ?initialSelectionEnd: int) = 
            Bindings.userEvent.typeInternal(element, text, Bindings.createTypeOptions skipClick skipAutoClose (Some delayMS) initialSelectionStart initialSelectionEnd)
            |> unbox<JS.Promise<unit>>
        /// Unhovers an element.
        static member unhover (element: #HTMLElement) = Bindings.userEvent.unhover(element)
        /// Uploads a file to an <input>. 
        static member upload (element: #HTMLElement, file: File, ?clickEventProps: #IMouseEventProperty list, ?changeEventProps: #IEventProperty list) =
            Bindings.userEvent.upload(element, file, ?options = Bindings.createUploadEventInit clickEventProps changeEventProps)
        /// Uploads a file to an <input>. 
        ///
        /// For uploading multiple files use <input> with the multiple attribute.
        static member upload (element: #HTMLElement, files: seq<File>, ?clickEventProps: #IMouseEventProperty list, ?changeEventProps: #IEventProperty list) =
            Bindings.userEvent.upload(element, ResizeArray files, ?options = Bindings.createUploadEventInit clickEventProps changeEventProps)

[<AutoOpen>]
module RTLExtensions =
    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementCreateEvent (element: HTMLElement) =
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.createEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationIteration(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.createEvent.animationStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.blur(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlay(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.createEvent.canPlayThrough(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.createEvent.change(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.click(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.createEvent.compositionUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.contextMenu(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.copy(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.cut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.dblClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.doubleClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drag(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragExit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.dragStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.createEvent.drop(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.durationChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.createEvent.emptied(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.createEvent.encrypted(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.createEvent.ended(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.createEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focus(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusIn(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.createEvent.focusOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.gotPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.createEvent.input(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.createEvent.invalid(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyPress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.createEvent.keyUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.createEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.createEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedData(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.createEvent.loadedMetadata(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.loadStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.lostPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.mouseUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.createEvent.paste(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.createEvent.pause(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.createEvent.play(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.createEvent.playing(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.createEvent.pointerUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.createEvent.popState(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.createEvent.progress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.rateChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.createEvent.reset(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.createEvent.scroll(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeked(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.createEvent.seeking(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.select(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.createEvent.stalled(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.createEvent.submit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.createEvent.suspend(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.createEvent.timeUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.createEvent.touchStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.createEvent.transitionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.createEvent.volumeChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.createEvent.waiting(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.createEvent.wheel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))

    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementFireEvent (element: HTMLElement) =
        member _.abort (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.abort (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.abort(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationEnd (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationIteration (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationIteration(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.animationStart (?eventProperties: #IAnimationEventProperty list) = Bindings.fireEvent.animationStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.blur (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.blur(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.canPlay (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlay(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.canPlayThrough (?eventProperties: #IEventProperty list) = Bindings.fireEvent.canPlayThrough(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.change (?eventProperties: #IEventProperty list) = Bindings.fireEvent.change(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.click (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.click(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionEnd (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionStart (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.compositionUpdate (?eventProperties: #ICompositionEventProperty list) = Bindings.fireEvent.compositionUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.contextMenu (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.contextMenu(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.copy (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.copy(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.cut (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.cut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dblClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.dblClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.doubleClick (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.doubleClick(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.drag (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drag(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragEnd (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragEnter (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragExit (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragExit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragLeave (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragOver (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.dragStart (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.dragStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.drop (?eventProperties: #IDragEventProperty list) = Bindings.fireEvent.drop(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.durationChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.durationChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.emptied (?eventProperties: #IEventProperty list) = Bindings.fireEvent.emptied(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.encrypted (?eventProperties: #IEventProperty list) = Bindings.fireEvent.encrypted(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.ended (?eventProperties: #IEventProperty list) = Bindings.fireEvent.ended(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.error (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.error (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.error(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focus (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focus(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focusIn (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusIn(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.focusOut (?eventProperties: #IFocusEventProperty list) = Bindings.fireEvent.focusOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.gotPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.gotPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.input (?eventProperties: #IInputEventProperty list) = Bindings.fireEvent.input(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.invalid (?eventProperties: #IEventProperty list) = Bindings.fireEvent.invalid(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyDown (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyPress (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyPress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.keyUp (?eventProperties: #IKeyboardEventProperty list) = Bindings.fireEvent.keyUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.load (?eventProperties: IProgressEventProperty list) = Bindings.fireEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.load (?eventProperties: IUIEventProperty list) = Bindings.fireEvent.load(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadedData (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedData(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadedMetadata (?eventProperties: #IEventProperty list) = Bindings.fireEvent.loadedMetadata(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.loadStart (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.loadStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.lostPointerCapture (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.lostPointerCapture(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseDown (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseEnter (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseLeave (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseMove (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseOut (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseOver (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.mouseUp (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.mouseUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.paste (?eventProperties: #IClipboardEventProperty list) = Bindings.fireEvent.paste(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pause (?eventProperties: #IEventProperty list) = Bindings.fireEvent.pause(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.play (?eventProperties: #IEventProperty list) = Bindings.fireEvent.play(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.playing (?eventProperties: #IEventProperty list) = Bindings.fireEvent.playing(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerCancel (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerDown (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerDown(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerEnter (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerEnter(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerLeave (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerLeave(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerMove (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerOut (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOut(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerOver (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerOver(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.pointerUp (?eventProperties: #IPointerEventProperty list) = Bindings.fireEvent.pointerUp(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.popState (?eventProperties: #IEventProperty list) = Bindings.fireEvent.popState(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))        
        member _.progress (?eventProperties: #IProgressEventProperty list) = Bindings.fireEvent.progress(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.rateChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.rateChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.reset (?eventProperties: #IEventProperty list) = Bindings.fireEvent.reset(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.scroll (?eventProperties: #IEventProperty list) = Bindings.fireEvent.scroll(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.seeked (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeked(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.seeking (?eventProperties: #IEventProperty list) = Bindings.fireEvent.seeking(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.select (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.select(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.stalled (?eventProperties: #IEventProperty list) = Bindings.fireEvent.stalled(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.submit (?eventProperties: #IEventProperty list) = Bindings.fireEvent.submit(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.suspend (?eventProperties: #IEventProperty list) = Bindings.fireEvent.suspend(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.timeUpdate (?eventProperties: #IEventProperty list) = Bindings.fireEvent.timeUpdate(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchCancel (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchCancel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchEnd (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchMove (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchMove(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.touchStart (?eventProperties: #ITouchEventProperty list) = Bindings.fireEvent.touchStart(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.transitionEnd (?eventProperties: #ITransitionEventProperty list) = Bindings.fireEvent.transitionEnd(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.volumeChange (?eventProperties: #IEventProperty list) = Bindings.fireEvent.volumeChange(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.waiting (?eventProperties: #IEventProperty list) = Bindings.fireEvent.waiting(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))
        member _.wheel (?eventProperties: #IMouseEventProperty list) = Bindings.fireEvent.wheel(element, ?eventProperties = (eventProperties |> Option.map (fun props -> createObj !!props)))

    [<NoComparison>]
    [<NoEquality>]
    type HTMLElementUserEvent (element: HTMLElement) =
        /// Selects the text inside an input or textarea and deletes it.
        member _.clear () = RTL.userEvent.clear(element)
        /// Clicks element, depending on what element is it can have different side effects.
        member _.click (?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            RTL.userEvent.click(element, ?clickCount = clickCount, ?skipHover = skipHover, ?eventProperties = eventProperties)
        /// Cntrl + clicks element, depending on what element is it can have different side effects.
        member _.ctrlClick (?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            RTL.userEvent.ctrlClick(element, ?clickCount = clickCount, ?skipHover = skipHover, ?eventProperties = eventProperties)
        /// Clicks element twice, depending on what element is it can have different side effects.
        member _.dblClick (?eventProperties: #IMouseEventProperty list) =
            RTL.userEvent.dblClick(element, ?eventProperties = eventProperties)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        member _.deselectOptions (values: 'T []) = RTL.userEvent.deselectOptions(element, values)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        member _.deselectOptions (values: 'T list) = RTL.userEvent.deselectOptions(element, values)
        /// Remove the selection for the specified option(s) of a <select multiple> element.
        member _.deselectOptions (values: ResizeArray<'T>) = RTL.userEvent.deselectOptions(element, values)
        /// Hovers over the element.
        member _.hover () = RTL.userEvent.hover(element)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: 'T []) = RTL.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: 'T list) = RTL.userEvent.selectOptions(element, values)
        /// Selects the specified option(s) of a <select> or a <select multiple> element.
        member _.selectOptions (values: ResizeArray<'T>) = RTL.userEvent.selectOptions(element, values)
        /// Shift + clicks element, depending on what element is it can have different side effects.
        member _.shiftClick (?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            RTL.userEvent.shiftClick(element, ?clickCount = clickCount, ?skipHover = skipHover, ?eventProperties = eventProperties)
        /// Cntrl + shift + clicks element, depending on what element is it can have different side effects.
        member _.shiftCtrlClick (?clickCount: int, ?skipHover: bool, ?eventProperties: #IMouseEventProperty list) =
            RTL.userEvent.shiftCtrlClick(element, ?clickCount = clickCount, ?skipHover = skipHover, ?eventProperties = eventProperties)
        /// Fires a tab event changing the document.activeElement in the same way the browser does.
        member _.tab (?shift: bool) = RTL.userEvent.tab(?shift = shift, ?focusTrap = Some element)
        /// Writes text inside an <input> or a <textarea>.
        ///
        /// You can use special characters via brackets such as {enter}, supported keys:
        /// enter, esc, backspace, shift, ctrl, alt, meta
        ///
        /// shift, ctrl, alt, and meta will activate their respective event key. Which is 
        /// ended with a closing tag: {/shift}, {/ctrl}, {/alt}, and {/meta}.
        ///
        /// shift does *not* cause lowercase text to become uppercase.
        member _.type' (text: string, ?skipClick: bool, ?skipAutoClose: bool, ?initialSelectionStart: int, ?initialSelectionEnd: int) = 
            RTL.userEvent.type' (
                element, 
                text,
                ?skipClick = skipClick,
                ?skipAutoClose = skipAutoClose,
                ?initialSelectionStart = initialSelectionStart,
                ?initialSelectionEnd = initialSelectionEnd
            )
        /// Writes text inside an <input> or a <textarea>.
        ///
        /// You can use special characters via brackets such as {enter}, supported keys:
        /// enter, esc, backspace, shift, ctrl, alt, meta
        ///
        /// shift, ctrl, alt, and meta will activate their respective event key. Which is 
        /// ended with a closing tag: {/shift}, {/ctrl}, {/alt}, and {/meta}.
        ///
        /// shift does *not* cause lowercase text to become uppercase.
        member _.type' (text: string, delayMS: int, ?skipClick: bool, ?skipAutoClose: bool, ?initialSelectionStart: int, ?initialSelectionEnd: int) = 
            RTL.userEvent.type' (
                element, 
                text,
                delayMS,
                ?skipClick = skipClick,
                ?skipAutoClose = skipAutoClose,
                ?initialSelectionStart = initialSelectionStart,
                ?initialSelectionEnd = initialSelectionEnd
            )
        /// Unhovers the element.
        member _.unhover () = RTL.userEvent.unhover(element)
        /// Uploads a file to an <input>. 
        member _.upload (file: File, ?clickEventProps: #IMouseEventProperty list, ?changeEventProps: #IEventProperty list) =
            RTL.userEvent.upload(element, file, ?clickEventProps = clickEventProps, ?changeEventProps = changeEventProps)
        /// Uploads a file to an <input>. 
        ///
        /// For uploading multiple files use <input> with the multiple attribute.
        member _.upload (files: seq<File>, ?clickEventProps: #IMouseEventProperty list, ?changeEventProps: #IEventProperty list) =
            RTL.userEvent.upload(element, ResizeArray files, ?clickEventProps = clickEventProps, ?changeEventProps = changeEventProps)

    type Browser.Types.HTMLElement with
        member this.createEvent = HTMLElementCreateEvent(this)
        member this.fireEvent = HTMLElementFireEvent(this)
        member this.userEvent = HTMLElementUserEvent(this)
