namespace Feliz

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser.Types

module ReactInternal =

    [<Import("createElement", "react")>]
    let createElementWithChildren
        (``type``: ReactNode, props: obj, [<ParamArray>] children: seq<ReactElement>)
        : ReactElement =
        jsNative

    [<Import("createElement", "react")>]
    let createElementWithChild (``type``: ReactNode, props: obj, children: ReactElement) : ReactElement = jsNative

    [<Import("createElement", "react")>]
    let createElementWithProps (``type``: ReactNode, props: obj) : ReactElement = jsNative

    [<Import("createElement", "react")>]
    let createElement (``type``: ReactNode) : ReactElement = jsNative

    [<Import("memo", "react")>]
    let memoInternal<'props>
        (renderElement: 'props -> ReactElement, areEqual: ('props -> 'props -> bool))
        : 'props -> ReactElement =
        jsNative

    /// Creates an element from `(key, value)` props. A `children` entry is passed as separate children
    /// arguments, the same way `Html.*` elements do it.
    let createElementFromPropList (``type``: ReactNode) (props: (string * obj) list) : ReactElement =
        let children =
            props
            |> List.tryPick (fun (key, value) -> if key = "children" then Some value else None)

        let props = props |> List.filter (fun (key, _) -> key <> "children") |> createObj

        match children with
        | Some children -> createElementWithChildren (``type``, props, unbox<seq<ReactElement>> children)
        | None -> createElementWithProps (``type``, props)


open ReactInternal

[<Erase>]
type ReactLegacy =

    static member inline createElement(``type``: string, props: obj, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (!^``type``, props, children)

    static member inline createElement(``type``: string, props: obj, children: ReactElement) : ReactElement =
        createElementWithChild (!^``type``, props, children)

    static member inline createElement(``type``: string, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (!^``type``, null, children)

    static member inline createElement(``type``: string, children: ReactElement) : ReactElement =
        createElementWithChild (!^``type``, null, children)

    static member inline createElement(``type``: string, props: obj) : ReactElement =
        createElementWithProps (!^``type``, props)

    static member inline createElement(``type``: ReactElement, props: obj, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (!^``type``, props, children)

    static member inline createElement(``type``: ReactElement, props: obj, children: ReactElement) : ReactElement =
        createElementWithChild (!^``type``, props, children)

    static member inline createElement(``type``: ReactElement, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (!^``type``, null, children)

    static member inline createElement(``type``: ReactElement, children: ReactElement) : ReactElement =
        createElementWithChild (!^``type``, null, children)

    static member inline createElement(``type``: ReactElement, props: obj) : ReactElement =
        createElementWithProps (!^``type``, props)

    static member inline createElement(``type``: ReactNode, props: obj, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (``type``, props, children)

    static member inline createElement(``type``: ReactNode, props: obj, children: ReactElement) : ReactElement =
        createElementWithChild (``type``, props, children)

    static member inline createElement(``type``: ReactNode, children: seq<ReactElement>) : ReactElement =
        createElementWithChildren (``type``, null, children)

    static member inline createElement(``type``: ReactNode, children: ReactElement) : ReactElement =
        createElementWithChild (``type``, null, children)

    static member inline createElement(``type``: ReactNode, props: obj) : ReactElement =
        createElementWithProps (``type``, props)

    static member inline createElement(``type``: ReactNode) : ReactElement = createElement (``type``)


    [<ImportMember("react")>]
    static member inline forwardRef
        (render: 'props * IRefValue<'t> -> ReactElement)
        : ('props * IRefValue<'t> -> ReactElement) =
        jsNative


[<Erase>]
type React =

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline Fragment(xs: seq<ReactElement>) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), children = xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline Fragment(xs: ReactElement) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), children = xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: int, xs: seq<ReactElement>) = // Fable.React.Helpers.fragment [ !!("key", key) ] xs
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), {| key = key |}, xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: string, xs: seq<ReactElement>) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), {| key = key |}, xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: System.Guid, xs: seq<ReactElement>) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), {| key = key.ToString() |}, xs)

    /// <summary>
    /// A Fragment with a ref. The ref receives a `FragmentInstance` that lets you add event listeners, observe,
    /// focus or measure the Fragment's first-level DOM children as a group, without a wrapper element.
    ///
    /// Requires React 19.3 or later.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let fragmentRef = React.useRef&lt;FragmentInstance option&gt; None
    /// React.useEffectOnce (fun () -> fragmentRef.current |> Option.iter (fun f -> f.focus ()))
    /// React.Fragment(fragmentRef, [ Html.input []; Html.input [] ])
    /// ```
    /// </remarks>
    static member inline Fragment(ref: IRefValue<FragmentInstance option>, xs: seq<ReactElement>) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), {| ref = ref |}, xs)

    /// <summary>
    /// A Fragment with a callback ref. React calls the callback with a `FragmentInstance` when the Fragment
    /// mounts and with `null` when it unmounts.
    ///
    /// Requires React 19.3 or later.
    /// </summary>
    static member inline Fragment(ref: FragmentInstance -> unit, xs: seq<ReactElement>) =
        ReactLegacy.createElement (unbox<ReactNode>(import "Fragment" "react"), {| ref = ref |}, xs)

    /// <summary>
    /// A Fragment with a callback ref that returns a cleanup function. React calls the callback with a
    /// `FragmentInstance` when the Fragment mounts and calls the cleanup function when it unmounts.
    ///
    /// Requires React 19.3 or later.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// React.Fragment(
    ///     (fun fragment ->
    ///         fragment.observeUsing observer
    ///         fun () -> fragment.unobserveUsing observer),
    ///     children
    /// )
    /// ```
    /// </remarks>
    static member inline Fragment(ref: FragmentInstance -> (unit -> unit), xs: seq<ReactElement>) =
        ReactLegacy.createElement (
            unbox<ReactNode>(import "Fragment" "react"),
            {|
                ref = Func<FragmentInstance, (unit -> unit)>(fun instance -> ref instance)
            |},
            xs
        )

    /// Placeholder empty React element to be used when importing external React components with the `[<ReactComponent>]` attribute.
    static member inline Imported() : ReactElement = Fable.Core.JS.undefined

    /// Dynamically import a React component from a given path.
    ///
    /// Designed to be used with `[<ReactLazyComponent>]` attribute.
    static member inline DynamicImported(path: string) : ReactElement =
        Fable.Core.JsInterop.importDynamic path |> unbox

    /// The `useState` hook that creates a state variable for React function components from an initialization function.
    [<ImportMember("react")>]
    static member inline useState<'t>(initializer: unit -> 't) : ('t * ('t -> unit)) = jsNative

    /// <summary>
    /// Just like React.useState except that the updater function uses the previous state of the state variable as input and allows you to compute the next value using it.
    /// This is useful in cases where defining helpers functions inside the definition of a React function component would actually cache the initial value (because they become closures) during first render as opposed to using the current value after multiple render cycles.
    ///
    /// Use this instead of React.useState when your state variable is a list, an array, a dictionary, a map or other complex structures.
    /// </summary>
    [<Import("useState", "react")>]
    static member inline useStateWithUpdater(initial: 't) : ('t * (('t -> 't) -> unit)) = jsNative

    /// <summary>
    /// Just like React.useState except that the updater function uses the previous state of the state variable as input and allows you to compute the next value using it.
    /// This is useful in cases where defining helpers functions inside the definition of a React function component would actually cache the initial value (because they become closures) during first render as opposed to using the current value after multiple render cycles.
    ///
    /// Use this instead of React.useState when your state variable is a list, an array, a dictionary, a map or other complex structures.
    /// </summary>
    [<Import("useState", "react")>]
    static member inline useStateWithUpdater(initial: unit -> 't) : ('t * (('t -> 't) -> unit)) = jsNative

    /// Accepts a reducer and returns the current state paired with a dispatch.
    [<ImportMember("react")>]
    static member inline useReducer
        (update: 'state -> 'msg -> 'state, initialState: 'state)
        : ('state * ('msg -> unit)) =
        jsNative

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<ImportMember("react")>]
    static member inline useEffect(setup: unit -> unit, ?dependencies: obj[]) : unit = jsNative

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffect(setup: Func<unit, (unit -> unit)>, ?dependencies: obj[]) : unit =
        JsInterop.emitJsExpr
            (setup, dependencies)
            // No local variable here: Fable inlines the setup lambda into $0, so a declared name could shadow
            // a value with the same name used inside the effect.
            "import {useEffect} from 'react';
useEffect(() => ($0)(), $1);"

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffect(setup: unit -> (unit -> unit), ?dependencies: obj[]) : unit =
        React.useEffect (Func<_, _> setup, ?dependencies = dependencies)

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffect(setup: unit -> #IDisposable, ?dependencies: obj[]) =
        React.useEffect (
            Func<_, _>(fun () ->
                let disp = setup ()
                fun () -> disp.Dispose()
            ),
            ?dependencies = dependencies
        )

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffect(setup: unit -> #IDisposable option, ?dependencies: obj[]) =
        React.useEffect (setup >> Helpers.optDispose, ?dependencies = dependencies)

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> unit) : unit = React.useEffect (setup, [||])

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> (unit -> unit)) : unit =
        React.useEffect (Func<_, _> setup, [||])


    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> #IDisposable) = React.useEffect (setup, [||])

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> #IDisposable option) =
        React.useEffect (setup >> Helpers.optDispose, [||])

    [<ImportMember("react")>]
    static member inline useId() : string = jsNative

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    [<ImportMember("react")>]
    static member inline useLayoutEffect(setup: unit -> unit, ?dependencies: obj[]) : unit = jsNative

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffect(setup: Func<unit, (unit -> unit)>, ?dependencies: obj[]) : unit =
        JsInterop.emitJsExpr
            (setup, dependencies)
            // No local variable here: Fable inlines the setup lambda into $0, so a declared name could shadow
            // a value with the same name used inside the effect.
            "import {useLayoutEffect} from 'react';
useLayoutEffect(() => ($0)(), $1);"

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffect(setup: unit -> (unit -> unit), ?dependencies: obj[]) : unit =
        React.useLayoutEffect (Func<_, _> setup, ?dependencies = dependencies)

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffect(setup: unit -> #IDisposable, ?dependencies: obj[]) : unit =
        React.useLayoutEffect (
            Func<_, _>(fun () ->
                let disp = setup ()
                fun () -> disp.Dispose()
            ),
            ?dependencies = dependencies
        )

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffect(setup: unit -> #IDisposable option, ?dependencies: obj[]) =
        React.useLayoutEffect (setup >> Helpers.optDispose, ?dependencies = dependencies)

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> unit) : unit = React.useLayoutEffect (setup, [||])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> (unit -> unit)) : unit =
        React.useLayoutEffect (Func<_, _> setup, [||])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> #IDisposable) : unit = React.useLayoutEffect (setup, [||])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> #IDisposable option) = React.useLayoutEffect (setup, [||])

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: string) = jsNative

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: int) = jsNative

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: float) = jsNative

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: bool) = jsNative

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: obj) = jsNative

    /// Can be used to display a label for custom hooks in React DevTools.
    [<ImportMember("react")>]
    static member inline useDebugValue(value: 't, formatter: 't -> string) = jsNative

    /// <summary>
    /// `useCallback` is a React Hook that lets you cache a function definition between re-renders.
    /// </summary>
    /// <param name='callbackFunction'>A callback function to be memoized.</param>
    /// <param name='dependencies'>An array of dependencies upon which the callback function depends.
    /// If not provided, React returns a new function on every render (no memoization), so you almost always want
    /// to pass dependencies. Use an empty array for a function that never changes.</param>
    [<ImportMember("react")>]
    static member inline useCallback(callbackFunction: 'a -> 'b, ?dependencies: obj array) : 'a -> 'b = jsNative

    /// Returns a mutable ref object whose .current property is initialized to the passed argument (initialValue). The returned object will persist for the full lifetime of the component.
    ///
    /// Essentially, useRef is like a container that can hold a mutable value in its .current property.
    [<ImportMember("react")>]
    static member inline useRef<'t>(initialValue: 't) : IRefValue<'t> = jsNative

    /// A specialized version of React.useRef() that creates a reference to an input element.
    ///
    /// Useful for controlling the internal properties and methods of that element, for example to enable focus().
    static member inline useInputRef() : IRefValue<HTMLInputElement option> = React.useRef (None)

    /// A specialized version of React.useRef() that creates a reference to a button element.
    static member inline useButtonRef() : Fable.React.IRefValue<HTMLButtonElement option> = React.useRef (None)

    /// A specialized version of React.useRef() that creates a reference to a generic HTML element.
    ///
    /// Useful for controlling the internal properties and methods of that element, for integration with third-party libraries that require a Html element.
    static member inline useElementRef() : IRefValue<HTMLElement option> = React.useRef (None)

    /// <summary>
    /// The `useMemo` hook. Returns a memoized value. Pass a "create" function and an array of dependencies.
    /// `useMemo` will only recompute the memoized value when one of the dependencies has changed.
    /// </summary>
    /// <param name='createFunction'>A create function returning a value to be memoized.</param>
    /// <param name='dependencies'>An array of dependencies upon which the create function depends.</param>
    [<ImportMember("react")>]
    static member inline useMemo<'a>(calculateValue: unit -> 'a, dependencies: obj array) : 'a = jsNative

    /// <summary>
    /// The `useMemo` hook. Returns a memoized value. Pass a "create" function.
    ///
    /// This will assume an empty array of dependencies, meaning the memoized value will not be recomputed.
    /// </summary>
    /// <param name='createFunction'>A create function returning a value to be memoized.</param>
    static member inline useMemo<'a>(calculateValue: unit -> 'a) : 'a = React.useMemo (calculateValue, [||])


    //
    // React.memo
    //

    /// <summary>
    /// `React.memo` memoizes the result of a function component. Given the same props, React will skip rendering the component, and reuse the last rendered result.
    /// By default it will only shallowly compare complex objects in the props object. For more control, a custom `arePropsEqual` function can be provided.
    /// </summary>
    /// <param name='element'>A render function or a React.functionComponent.</param>
    /// <param name='areEqual'>A custom comparison function to use instead of React's default shallow compare.</param>
    [<Import("memo", "react")>]
    static member inline memo<'props>
        (ele: 'props -> ReactElement, ?areEqual: 'props -> 'props -> bool)
        : MemoComponent<'props> =
        jsNative



    /// <summary>
    /// This is a Feliz helper function to call a memo component.
    ///
    /// </summary>
    /// <remarks>
    ///
    /// ```fsharp
    /// let ComponentLazy: {|text: string|} -> ReactElement =
    ///     React.lazy'(fun () ->
    ///         importDynamic "./LazyComponent.jsx"
    ///     )
    /// ```
    ///
    /// Can be calles like this:
    ///
    /// ```fsharp
    /// React.lazyRender(ComponentLazy, {|text = "Hello"|})
    /// ```
    ///
    /// </remarks>
    static member inline memoRender<'props>
        (ele: MemoComponent<'props>, props: 'props, ?withKey: 'props -> string)
        : ReactElement =
        if (Interop.isObject (box props) |> not) then
            Browser.Dom.console.error "React.memoRender: props must be an object."

        let props = Interop.setKeyOnObj withKey props
        ReactLegacy.createElement (unbox<ReactElement> ele, props)

    static member inline memoRender<'props>(ele: MemoComponent<unit>, ?withKey: string) : ReactElement =
        let props =
            Interop.setKeyOnObj (withKey |> Option.map (fun k -> fun _ -> k)) (createObj [])

        ReactLegacy.createElement (unbox<ReactElement> ele, props)

    //
    // React.useContext
    //

    /// <summary>
    /// Creates a Context object. When React renders a component that subscribes to this Context object
    /// it will read the current context value from the closest matching Provider above it in the tree.
    /// </summary>
    /// <param name='defaultValue'>A default value that is only used when a component does not have a matching Provider above it in the tree.</param>
    [<ImportMember("react")>]
    static member inline createContext<'a>(?defaultValue: 'a) : ReactContext<'a> = jsNative

    // /// <summary>
    // /// A Provider component that allows consuming components to subscribe to context changes.
    // /// </summary>
    // /// <param name='contextObject'>A context object returned from a previous React.createContext call.</param>
    // /// <param name='contextValue'>The context value to be provided to descendant components.</param>
    // /// <param name='child'>A child element.</param>
    // static member inline contextProvider
    //     (contextObject: Fable.React.IContext<'a>, contextValue: 'a, children: ReactElement)
    //     : ReactElement =
    //     ReactLegacy.createElement (unbox contextObject, {|value = contextValue|}, children)

    // /// <summary>
    // /// A Provider component that allows consuming components to subscribe to context changes.
    // /// </summary>
    // /// <param name='contextObject'>A context object returned from a previous React.createContext call.</param>
    // /// <param name='contextValue'>The context value to be provided to descendant components.</param>
    // /// <param name='children'>A sequence of child elements.</param>
    // static member inline contextProvider
    //     (contextObject: Fable.React.IContext<'a>, contextValue: 'a, children: #seq<ReactElement>)
    //     : ReactElement =
    //     ReactLegacy.createElement (unbox contextObject, {|value = contextValue|}, children)

    // /// <summary>
    // /// A Consumer component that subscribes to context changes.
    // ///
    // /// Recommended to use `useContext` instead of this.
    // /// </summary>
    // /// <param name='contextObject'>A context object returned from a previous React.createContext call.</param>
    // /// <param name='render'>A render function that returns an element.</param>
    // static member inline contextConsumer
    //     (contextObject: Fable.React.IContext<'a>, render: 'a -> ReactElement)
    //     : ReactElement =
    //     ReactLegacy.createElement (contextObject?Consumer) [ "children" ==> !!render ]
    //     |> unbox<ReactElement>

    // /// <summary>
    // /// A Consumer component that subscribes to context changes.
    // /// </summary>
    // /// <param name='contextObject'>A context object returned from a previous React.createContext call.</param>
    // /// <param name='render'>A render function that returns a sequence of elements.</param>
    // static member inline contextConsumer
    //     (contextObject: Fable.React.IContext<'a>, render: 'a -> #seq<ReactElement>)
    //     : ReactElement =
    //     ReactLegacy.createElement (contextObject?Consumer) [ "children" ==> (render >> React.Fragment) ]
    //     |> unbox<ReactElement>

    /// <summary>
    /// The `useContext` hook. Accepts a context object (the value returned from React.createContext) and returns the current context value for that context.
    /// The current context value is determined by the value prop of the nearest Provider component above the calling component in the tree.
    /// </summary>
    /// <param name='contextObject'>A context object returned from a previous React.createContext call.</param>
    [<ImportMember("react")>]
    static member inline useContext(someContext: ReactContext<'a>) : 'a = jsNative

    // /// <summary>
    // /// Forwards a given ref, allowing you to pass it further down to a child.
    // /// </summary>
    // /// <param name='render'>A render function that returns an element.</param>
    // static member inline forwardRef
    //     (render: ('props * IRefValue<'t> -> ReactElement))
    //     : ('props * IRefValue<'t> -> ReactElement) =
    //     Internal.forwardRef render

    // /// <summary>
    // /// Forwards a given ref, allowing you to pass it further down to a child.
    // ///
    // /// In React 19, forwardRef is no longer necessary. Pass ref as a prop instead.
    // /// forwardRef will deprecated in a future release. Learn more [here](https://react.dev/blog/2024/12/05/react-19#ref-as-a-prop).
    // /// </summary>
    // /// <param name='render'>A render function that returns an element.</param>
    // [<ImportMember("react")>]
    // static member inline forwardRef
    //     (render: ('props * IRefValue<'t> -> ReactElement))

    //     : ('props * IRefValue<'t> -> ReactElement) =
    //     Internal.forwardRefWithName name render

    /// <summary>
    /// Highlights potential problems in an application by enabling additional checks
    /// and warnings for descendants. As well as double rendering function components.
    ///
    /// This *does not do anything* in production mode. You do not need to hide it
    /// with compiler directives.
    /// </summary>
    /// <param name='children'>The elements that will be rendered with additional
    /// checks and warnings.</param>
    static member StrictMode(children: seq<ReactElement>) : ReactElement =
        ReactLegacy.createElement (unbox<ReactNode>(import "StrictMode" "react"), children)

    /// <summary>
    /// Lets you define a component that is loaded dynamically. Which helps with code splitting.
    /// </summary>
    /// <param name='load'>
    ///  The dynamicImport of the component.
    ///
    ///  Such as `let asyncComponent : JS.Promise[unit -> ReactElement] = JsInterop.importDynamic "./CodeSplitting.fs"`.
    ///
    ///  Where you would then pass in `fun () -> asyncComponent`.
    /// </param>
    [<Import("lazy", "react")>]
    static member inline lazy'<'props>(load: unit -> JS.Promise<'props -> ReactElement>) : LazyComponent<'props> =
        jsNative

    /// <summary>
    /// Lets you define a component that is loaded dynamically. Which helps with code splitting.
    /// </summary>
    /// <param name='load'>
    ///  The dynamicImport of the component.
    ///
    ///  Such as `let asyncComponent : JS.Promise[unit -> ReactElement] = JsInterop.importDynamic "./CodeSplitting.fs"`.
    ///
    ///  Where you would then pass in `fun () -> asyncComponent`.
    /// </param>
    static member inline lazy'<'props>(load: Async<'props -> ReactElement>) : LazyComponent<'props> =
        React.lazy' (fun () -> load |> Async.StartAsPromise)

    /// <summary>
    /// This is a Feliz helper function to call a lazy loaded component.
    ///
    /// </summary>
    /// <remarks>
    ///
    /// ```fsharp
    /// let ComponentLazy: {|text: string|} -> ReactElement =
    ///     React.lazy'(fun () ->
    ///         importDynamic "./LazyComponent.jsx"
    ///     )
    /// ```
    ///
    /// Can be calles like this:
    ///
    /// ```fsharp
    /// React.lazyRender(ComponentLazy, {|text = "Hello"|})
    /// ```
    ///
    /// </remarks>
    static member inline lazyRender<'props>(lazyComponent: LazyComponent<'props>, props: 'props) : ReactElement =
        if (Interop.isObject (box props) |> not) then
            Browser.Dom.console.error "React.lazyRender: props must be an object."

        ReactLegacy.createElement (unbox<ReactElement> lazyComponent, props)

    /// <summary>
    /// This is a Feliz helper function to call a lazy loaded component.
    ///
    /// </summary>
    /// <remarks>
    ///
    /// ```fsharp
    /// let ComponentLazy: {|text: string|} -> ReactElement =
    ///     React.lazy'(fun () ->
    ///         importDynamic "./LazyComponent.jsx"
    ///     )
    /// ```
    ///
    /// Can be calles like this:
    ///
    /// ```fsharp
    /// React.lazyRender(ComponentLazy, {|text = "Hello"|})
    /// ```
    ///
    /// </remarks>
    static member inline lazyRender(lazyComponent: LazyComponent<unit>) : ReactElement =
        ReactLegacy.createElement (unbox<ReactNode> lazyComponent, props = null)

    /// <summary>
    /// Lets you specify a loading indicator whenever a child element is not yet ready
    /// to render.
    ///
    /// Currently this is only usable with `React.lazy'`.
    /// </summary>
    /// <param name='children'>The elements that will be rendered within the suspense block.</param>
    /// <param name='fallback'>The element that will be rendered while the children are loading.</param>
    static member inline Suspense(children: seq<ReactElement>, ?fallback: ReactElement) =
        ReactLegacy.createElement (
            unbox<ReactNode>(import "Suspense" "react"),
            props = {| fallback = fallback |},
            children = children
        )

    /// <summary>
    /// Allows you to override the behavior of a given ref.
    ///
    /// </summary>
    /// <param name='ref'>The ref you want to override.</param>
    /// <param name='createHandle'>A function that returns a new ref with changed behavior.</param>
    /// <param name='dependencies'>An array of dependencies upon which the imperative handle function depends.</param>
    [<ImportMember("react")>]
    static member inline useImperativeHandle(ref: IRefValue<'t>, createHandle: unit -> 't, ?dependencies: obj[]) =
        jsNative

    /// <summary>
    /// Subscribes to a data source, and returns the current value from it.
    /// </summary>
    /// <param name='subscribe'>A function that sets up a subscription to the external data source. It receives a callback to be called when the data source changes.</param>
    /// <param name='getSnapshot'>A function that returns the current value of the external data source.</param>
    /// <returns>The current value from the external data source.</returns>
    [<ImportMember("react")>]
    static member inline useSyncExternalStore
        (
            subscribe: UseSyncExternalStoreSubscribe,
            getSnapshot: UseSyncExternalStoreSnapshot<'T>,
            ?getServerSnapshot: UseSyncExternalStoreSnapshot<'T>
        ) : 'T =
        jsNative

    /// <summary>
    /// Subscribes to a data source, and returns the current value from it.
    /// </summary>
    /// <param name='subscribe'>A function that sets up a subscription to the external data source. It receives a callback to be called when the data source changes.</param>
    /// <param name='getSnapshot'>A function that returns the current value of the external data source.</param>
    /// <returns>The current value from the external data source.</returns>
    static member inline useSyncExternalStore
        (
            subscribe: (unit -> unit) -> (unit -> unit),
            getSnapshot: UseSyncExternalStoreSnapshot<'T>,
            ?getServerSnapshot: UseSyncExternalStoreSnapshot<'T>
        ) : 'T =
        React.useSyncExternalStore (
            UseSyncExternalStoreSubscribe subscribe,
            getSnapshot,
            ?getServerSnapshot = getServerSnapshot
        )

    /// <summary>
    /// Subscribes to a data source, and returns the current value from it.
    /// </summary>
    /// <param name='subscribe'>A function that sets up a subscription to the external data source. It receives a callback to be called when the data source changes.</param>
    /// <param name='getSnapshot'>A function that returns the current value of the external data source.</param>
    /// <returns>The current value from the external data source.</returns>
    static member inline useSyncExternalStore
        (
            subscribe: (unit -> unit) -> #IDisposable,
            getSnapshot: UseSyncExternalStoreSnapshot<'T>,
            ?getServerSnapshot: UseSyncExternalStoreSnapshot<'T>
        ) : 'T =
        React.useSyncExternalStore (
            UseSyncExternalStoreSubscribe(fun (callback) ->
                let disp = subscribe (callback)
                fun () -> disp.Dispose()
            ),
            getSnapshot,
            ?getServerSnapshot = getServerSnapshot
        )

    //
    // Transitions
    //

    /// <summary>
    /// Lets you update state without blocking the UI. State updates inside `startTransition` are marked as
    /// non-urgent: React keeps the current UI interactive and can interrupt the render for more urgent updates
    /// (like typing). Returns `isPending` and the `startTransition` function.
    ///
    /// For async work (e.g. `promise { ... }`), use `React.useAsyncTransition`.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let isPending, startTransition = React.useTransition ()
    /// Html.button [
    ///     prop.onClick (fun _ -> startTransition (fun () -> setTab "posts"))
    ///     prop.text (if isPending then "Loading..." else "Posts")
    /// ]
    /// ```
    /// </remarks>
    [<Import("useTransition", "react")>]
    static member inline useTransition() : bool * ((unit -> unit) -> unit) = jsNative

    /// <summary>
    /// Like `React.useTransition`, but `startTransition` takes an async action returning a promise.
    /// `isPending` stays `true` until the promise settles (React calls this an "Action").
    ///
    /// State updates after a `let!`/`do!` are not part of the transition anymore; wrap them in
    /// `React.startTransition` again if they should be.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let isPending, startTransition = React.useAsyncTransition ()
    /// Html.button [
    ///     prop.disabled isPending
    ///     prop.onClick (fun _ ->
    ///         startTransition (fun () -> promise {
    ///             let! saved = saveName name
    ///             React.startTransition (fun () -> setSavedName saved)
    ///         }))
    ///     prop.text "Save"
    /// ]
    /// ```
    /// </remarks>
    [<Import("useTransition", "react")>]
    static member inline useAsyncTransition() : bool * ((unit -> JS.Promise<unit>) -> unit) = jsNative

    /// <summary>
    /// Marks the state updates inside `action` as a non-blocking transition. Unlike `React.useTransition` it can be
    /// called outside of components (e.g. from a store), but doesn't give you an `isPending` flag.
    /// </summary>
    [<Import("startTransition", "react")>]
    static member inline startTransition(action: unit -> unit) : unit = jsNative

    /// <summary>
    /// Runs an async action as a transition. Unlike `React.useAsyncTransition` it can be called outside of
    /// components, but doesn't give you an `isPending` flag.
    /// </summary>
    [<Import("startTransition", "react")>]
    static member inline startTransition(action: unit -> JS.Promise<unit>) : unit = jsNative

    /// <summary>
    /// Adds a type to the current transition. Call it inside `startTransition`, before the state update.
    /// `React.ViewTransition` uses the types to choose an animation, and you can target them in CSS with
    /// `:active-view-transition-type(type)`. Types are cleared after each commit.
    ///
    /// Requires React 19.3 or later.
    /// </summary>
    [<ImportMember("react")>]
    static member inline addTransitionType(transitionType: string) : unit = jsNative

    /// <summary>
    /// Returns a deferred copy of `value` that lags behind during urgent updates: React first re-renders with the
    /// old value, then renders the new value in the background. Useful to keep an input responsive while an
    /// expensive list re-renders.
    /// </summary>
    /// <param name='value'>The value to defer.</param>
    /// <param name='initialValue'>Value used for the initial render; React then re-renders in the background with `value`.</param>
    [<ImportMember("react")>]
    static member inline useDeferredValue(value: 't, ?initialValue: 't) : 't = jsNative

    //
    // Effects
    //

    /// <summary>
    /// A version of `useEffect` that fires before React makes DOM changes. Meant for CSS-in-JS library authors
    /// to inject styles before layout effects read the layout. Prefer `useEffect` or `useLayoutEffect` otherwise.
    /// </summary>
    [<ImportMember("react")>]
    static member inline useInsertionEffect(setup: unit -> unit, ?dependencies: obj[]) : unit = jsNative

    /// <summary>
    /// A version of `useEffect` that fires before React makes DOM changes. Meant for CSS-in-JS library authors
    /// to inject styles before layout effects read the layout. Prefer `useEffect` or `useLayoutEffect` otherwise.
    /// </summary>
    static member inline useInsertionEffect(setup: Func<unit, (unit -> unit)>, ?dependencies: obj[]) : unit =
        JsInterop.emitJsExpr
            (setup, dependencies)
            // No local variable here: Fable inlines the setup lambda into $0, so a declared name could shadow
            // a value with the same name used inside the effect.
            "import {useInsertionEffect} from 'react';
useInsertionEffect(() => ($0)(), $1);"

    /// <summary>
    /// A version of `useEffect` that fires before React makes DOM changes. Meant for CSS-in-JS library authors
    /// to inject styles before layout effects read the layout. Prefer `useEffect` or `useLayoutEffect` otherwise.
    /// </summary>
    static member inline useInsertionEffect(setup: unit -> (unit -> unit), ?dependencies: obj[]) : unit =
        React.useInsertionEffect (Func<_, _> setup, ?dependencies = dependencies)

    /// <summary>
    /// A version of `useEffect` that fires before React makes DOM changes. Meant for CSS-in-JS library authors
    /// to inject styles before layout effects read the layout. Prefer `useEffect` or `useLayoutEffect` otherwise.
    /// </summary>
    static member inline useInsertionEffect(setup: unit -> #IDisposable, ?dependencies: obj[]) : unit =
        React.useInsertionEffect (
            Func<_, _>(fun () ->
                let disp = setup ()
                fun () -> disp.Dispose()
            ),
            ?dependencies = dependencies
        )

    /// <summary>
    /// Wraps a function so that it always sees the latest props and state, while keeping a stable identity.
    /// Use it for logic that is triggered by an effect but shouldn't make the effect re-run, e.g. reading the
    /// current theme inside a connection callback. This replaces `useRef`/`useStateWithUpdater` workarounds for
    /// stale closures.
    ///
    /// Only call the returned function from inside effects (never during rendering), and don't pass it to other
    /// components or hooks. Leave it out of effect dependencies.
    ///
    /// Requires React 19.2 or later.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let onConnected = React.useEffectEvent (fun () -> showNotification ("Connected!", theme))
    /// React.useEffect ((fun () ->
    ///     let connection = createConnection roomId
    ///     connection.on ("connected", onConnected)
    ///     fun () -> connection.disconnect ()), [| box roomId |])
    /// ```
    /// </remarks>
    [<ImportMember("react")>]
    static member inline useEffectEvent(callback: 'a -> 'b) : 'a -> 'b = jsNative

    //
    // use
    //

    /// <summary>
    /// Reads the result of a promise, suspending the component until it resolves. Show a loading state with
    /// `React.Suspense` and handle rejections with `React.ErrorBoundary`.
    ///
    /// Named `use'` because `use` is an F# keyword. Unlike other hooks it can be called inside `if` and loops.
    ///
    /// The promise must be created outside of the component that reads it (e.g. by a parent, a router loader, or
    /// a cache). A promise created during render is new on every render and suspends forever. For the same reason
    /// there is no `Async` overload.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// [&lt;ReactComponent&gt;]
    /// let Message (messagePromise: JS.Promise&lt;string&gt;) =
    ///     let message = React.use' messagePromise
    ///     Html.p message
    ///
    /// React.Suspense([ Message(fetchMessage ()) ], Html.p "Loading...")
    /// ```
    /// </remarks>
    [<Import("use", "react")>]
    static member inline use'(promise: JS.Promise<'t>) : 't = jsNative

    /// <summary>
    /// Reads the value of a context, like `React.useContext`, but can be called inside `if` and loops.
    ///
    /// Named `use'` because `use` is an F# keyword.
    /// </summary>
    [<Import("use", "react")>]
    static member inline use'(context: ReactContext<'t>) : 't = jsNative

    //
    // Actions
    //

    /// <summary>
    /// Keeps state that is updated by an action, e.g. the result of a form submission.
    /// Returns the current state, a `dispatch` function that runs the action, and `isPending`.
    ///
    /// The action receives the previous state and the payload passed to `dispatch`. When `dispatch` is passed to
    /// `prop.action` of a form, the payload is the form's `FormData`. When calling `dispatch` yourself, call it inside
    /// `React.startTransition` (or a transition from `React.useTransition`) so `isPending` updates.
    /// </summary>
    /// <param name='action'>Computes the next state from the previous state and the payload.</param>
    /// <param name='initialState'>The state before the action is run the first time.</param>
    /// <param name='permalink'>The URL the form navigates to if it is submitted before JavaScript has loaded (server rendering only).</param>
    [<Import("useActionState", "react")>]
    static member inline useActionState
        (action: 'state -> 'payload -> 'state, initialState: 'state, ?permalink: string)
        : 'state * ('payload -> unit) * bool =
        jsNative

    /// <summary>
    /// Keeps state that is updated by an async action, e.g. the server's response to a form submission.
    /// Returns the current state, a `dispatch` function that runs the action, and `isPending`, which is `true`
    /// until the returned promise settles. Multiple dispatches are queued and run one after another.
    ///
    /// The action receives the previous state and the payload passed to `dispatch`. When `dispatch` is passed to
    /// `prop.action` of a form, the payload is the form's `FormData`. When calling `dispatch` yourself, call it inside
    /// `React.startTransition` (or a transition from `React.useTransition`).
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let error, submitAction, isPending =
    ///     React.useActionState ((fun (_: string option) (formData: FormData) -> promise {
    ///         let! result = updateName (string (formData.get "name"))
    ///         return result.Error
    ///     }), None)
    ///
    /// Html.form [
    ///     prop.action submitAction
    ///     prop.children [
    ///         Html.input [ prop.name "name" ]
    ///         Html.button [ prop.type'.submit; prop.disabled isPending; prop.text "Update" ]
    ///         match error with
    ///         | Some error -> Html.p error
    ///         | None -> Html.none
    ///     ]
    /// ]
    /// ```
    /// </remarks>
    /// <param name='action'>Computes the next state from the previous state and the payload.</param>
    /// <param name='initialState'>The state before the action is run the first time.</param>
    /// <param name='permalink'>The URL the form navigates to if it is submitted before JavaScript has loaded (server rendering only).</param>
    [<Import("useActionState", "react")>]
    static member inline useActionState
        (action: 'state -> 'payload -> JS.Promise<'state>, initialState: 'state, ?permalink: string)
        : 'state * ('payload -> unit) * bool =
        jsNative

    /// <summary>
    /// Shows a different state while an action is running, e.g. a message as "sent" before the server confirms it.
    /// Returns the optimistic state and a setter. Outside of an action the optimistic state equals `value`; when the
    /// action finishes, React switches back to `value` (usually updated with the real result by then).
    ///
    /// Call the setter inside an action or `startTransition`.
    /// </summary>
    [<ImportMember("react")>]
    static member inline useOptimistic(value: 't) : 't * ('t -> unit) = jsNative

    /// <summary>
    /// Shows a different state while an action is running, e.g. a list with a pending item appended. The `update`
    /// function computes the optimistic state from the current state and the value passed to the returned function.
    ///
    /// Call the returned function inside an action or `startTransition`.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// let optimisticMessages, addOptimisticMessage =
    ///     React.useOptimistic (messages, fun current newMessage -> current @ [ newMessage ])
    /// ```
    /// </remarks>
    [<ImportMember("react")>]
    static member inline useOptimistic(value: 't, update: 't -> 'optimistic -> 't) : 't * ('optimistic -> unit) =
        jsNative

    //
    // Components
    //

    /// <summary>
    /// Hides and shows part of the UI while keeping its state. A hidden Activity hides its children with
    /// `display: none`, cleans up their effects and renders updates at low priority. Making it visible again restores
    /// the previous state, which is useful for tabs, sidebars or pre-rendering content the user is likely to see next.
    ///
    /// Requires React 19.2 or later.
    /// </summary>
    static member inline Activity(mode: ActivityMode, children: seq<ReactElement>) : ReactElement =
        ReactLegacy.createElement (unbox<ReactNode>(import "Activity" "react"), {| mode = mode |}, children)

    /// <summary>
    /// Hides and shows part of the UI while keeping its state. A hidden Activity hides its children with
    /// `display: none`, cleans up their effects and renders updates at low priority. Making it visible again restores
    /// the previous state, which is useful for tabs, sidebars or pre-rendering content the user is likely to see next.
    ///
    /// Requires React 19.2 or later.
    /// </summary>
    static member inline Activity(mode: ActivityMode, child: ReactElement) : ReactElement =
        ReactLegacy.createElement (unbox<ReactNode>(import "Activity" "react"), {| mode = mode |}, child)

    /// <summary>
    /// Measures how often a part of the tree renders and how long rendering takes.
    /// Profiling is disabled in production builds unless you use React's profiling build.
    /// </summary>
    /// <param name='id'>Identifies the part of the UI being measured.</param>
    /// <param name='onRender'>Called each time the tree commits, with timing information.</param>
    /// <param name='children'>The elements to measure.</param>
    static member inline Profiler
        (id: string, onRender: ProfilerRenderInfo -> unit, children: seq<ReactElement>)
        : ReactElement =
        ReactLegacy.createElement (
            unbox<ReactNode>(import "Profiler" "react"),
            createObj [
                "id" ==> id
                "onRender"
                ==> JsInterop.emitJsExpr
                        onRender
                        "(id, phase, actualDuration, baseDuration, startTime, commitTime) => ($0)({ id, phase, actualDuration, baseDuration, startTime, commitTime })"
            ],
            children
        )

    /// <summary>
    /// Catches errors thrown while rendering its children (including rejected promises read with `React.use'`)
    /// and renders `fallback` instead.
    ///
    /// Error boundaries don't catch errors in event handlers or async code outside of rendering.
    /// </summary>
    /// <param name='children'>The elements to protect.</param>
    /// <param name='fallback'>Rendered instead of the children after an error.</param>
    /// <param name='onError'>Called with the error and its component stack, e.g. to log it.</param>
    /// <param name='onReset'>Called before the boundary resets because `resetKeys` changed.</param>
    /// <param name='resetKeys'>When any of these values changes (compared like hook dependencies), the boundary resets and renders the children again.</param>
    static member inline ErrorBoundary
        (
            children: seq<ReactElement>,
            fallback: ReactElement,
            ?onError: exn -> ReactErrorInfo -> unit,
            ?onReset: unit -> unit,
            ?resetKeys: obj[]
        ) : ReactElement =
        ReactLegacy.createElement (
            unbox<ReactNode> ErrorBoundaryInternal.errorBoundaryComponent,
            ErrorBoundaryInternal.createProps
                (box fallback)
                (onError
                 |> Option.map (fun onError -> Action<exn, ReactErrorInfo>(fun error info -> onError error info)))
                onReset
                resetKeys,
            children
        )

    /// <summary>
    /// Catches errors thrown while rendering its children (including rejected promises read with `React.use'`)
    /// and renders the result of `fallback` instead. `fallback` receives the error and a `reset` function that
    /// renders the children again.
    ///
    /// The fallback function runs inside a class component, so don't call hooks in it directly. Return a
    /// `[&lt;ReactComponent&gt;]` instead if you need hooks: `fun props -> ErrorView(props.error, props.reset)`.
    ///
    /// Error boundaries don't catch errors in event handlers or async code outside of rendering.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// React.ErrorBoundary(
    ///     [ Profile() ],
    ///     (fun props ->
    ///         Html.div [
    ///             Html.p $"Something went wrong: {props.error.Message}"
    ///             Html.button [ prop.onClick (fun _ -> props.reset ()); prop.text "Try again" ]
    ///         ]),
    ///     onError = fun error info -> console.error (error, info.componentStack)
    /// )
    /// ```
    /// </remarks>
    /// <param name='children'>The elements to protect.</param>
    /// <param name='fallback'>Renders the fallback UI from the caught error.</param>
    /// <param name='onError'>Called with the error and its component stack, e.g. to log it.</param>
    /// <param name='onReset'>Called before the boundary resets, either through `reset` or because `resetKeys` changed.</param>
    /// <param name='resetKeys'>When any of these values changes (compared like hook dependencies), the boundary resets and renders the children again.</param>
    static member inline ErrorBoundary
        (
            children: seq<ReactElement>,
            fallback: ErrorBoundaryFallbackProps -> ReactElement,
            ?onError: exn -> ReactErrorInfo -> unit,
            ?onReset: unit -> unit,
            ?resetKeys: obj[]
        ) : ReactElement =
        ReactLegacy.createElement (
            unbox<ReactNode> ErrorBoundaryInternal.errorBoundaryComponent,
            ErrorBoundaryInternal.createProps
                (box fallback)
                (onError
                 |> Option.map (fun onError -> Action<exn, ReactErrorInfo>(fun error info -> onError error info)))
                onReset
                resetKeys,
            children
        )

    /// <summary>
    /// Animates its children with the browser's View Transition API when they enter, exit or change during a
    /// transition (`startTransition`, `useDeferredValue` or a `Suspense` reveal). Plain state updates don't animate.
    /// Browsers without View Transitions just update without animating.
    ///
    /// Configure it with the `viewTransition` properties. Requires React 19.3 or later.
    /// </summary>
    /// <remarks>
    /// ```fsharp
    /// React.ViewTransition [
    ///     viewTransition.enter "slide-in"
    ///     viewTransition.exit "slide-out"
    ///     viewTransition.children [ Html.div [ prop.text "Animated" ] ]
    /// ]
    /// ```
    /// </remarks>
    static member inline ViewTransition(props: IViewTransitionProperty list) : ReactElement =
        createElementFromPropList (unbox<ReactNode>(import "ViewTransition" "react")) (unbox props)

    /// <summary>
    /// Animates its children with the browser's default cross-fade when they enter, exit or change during a
    /// transition (`startTransition`, `useDeferredValue` or a `Suspense` reveal). Plain state updates don't animate.
    ///
    /// Requires React 19.3 or later.
    /// </summary>
    static member inline ViewTransition(children: seq<ReactElement>) : ReactElement =
        ReactLegacy.createElement (unbox<ReactNode>(import "ViewTransition" "react"), children = children)


// This extensions module is required to help f# compiler understand overloads.
// Without this, for me the compiler was unable to resolve e.g. `useState` overload between `'t` and `unit -> 't`
[<AutoOpen>]
module ReactExtensions =

    type ReactContext<'a> with
        member inline this.Provider(value: 'a, children: ReactElement) : ReactElement =
            ReactLegacy.createElement (unbox<ReactNode> this, {| value = value |}, children)

        member inline this.Provider(value: 'a, children: seq<ReactElement>) : ReactElement =
            ReactLegacy.createElement (unbox<ReactNode> this, {| value = value |}, children)

        member inline this.Consumer(children: ReactElement) : ReactElement =
            ReactLegacy.createElement (unbox<ReactNode> this?Consumer, children)

        member inline this.Consumer(children: seq<ReactElement>) : ReactElement =
            ReactLegacy.createElement (unbox<ReactNode> this?Consumer, children)

    type React with
        /// The `useState` hook that creates a state variable for React function components from an initialization function.
        [<ImportMember("react")>]
        static member inline useState<'t>(init: 't) : ('t * ('t -> unit)) = jsNative
