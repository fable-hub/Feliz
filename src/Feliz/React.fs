namespace Feliz

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser.Types

module internal ReactInternal =

    [<Import("useEffect", "react")>]
    let useEffect (effect: obj) : unit =  jsNative


[<Erase>]
type ReactLegacy =

    [<Import("createElement","react")>]
    static member internal internalCreateElement(``type``: ReactNode, props: obj, [<ParamArray>] children: seq<ReactElement>): ReactElement = jsNative

    [<Import("createElement","react")>]
    static member internal internalCreateElement(``type``: ReactNode, props: obj, children: ReactElement): ReactElement = jsNative

    [<Import("createElement","react")>]
    static member internal internalCreateElement(``type``: ReactNode, props: obj): ReactElement = jsNative

    [<Import("createElement","react")>]
    static member internal internalCreateElement(``type``: ReactNode): ReactElement = jsNative

    static member inline createElement(``type``: string, props: obj, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props, children = children)

    static member inline createElement(``type``: string, props: obj, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props, children = children)

    static member inline createElement(``type``: string, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, null, children = children)

    static member inline createElement(``type``: string, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, null, children = children)

    static member inline createElement(``type``: string, props: obj): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props)

    static member inline createElement(``type``: ReactElement, props: obj, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props, children = children)
    static member inline createElement(``type``: ReactElement, props: obj, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props, children = children)

    static member inline createElement(``type``: ReactElement, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, null, children = children)
    static member inline createElement(``type``: ReactElement, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, null, children = children)

    static member inline createElement(``type``: ReactElement, props: obj): ReactElement = 
        ReactLegacy.internalCreateElement(!^``type``, props)

    static member inline createElement(``type``: ReactNode, props: obj, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(``type``, props, children = children)
    static member inline createElement(``type``: ReactNode, props: obj, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(``type``, props, children = children)

    static member inline createElement(``type``: ReactNode, children: seq<ReactElement>): ReactElement = 
        ReactLegacy.internalCreateElement(``type``, null, children = children)

    static member inline createElement(``type``: ReactNode, children: ReactElement): ReactElement = 
        ReactLegacy.internalCreateElement(``type``, null, children = children)

    static member inline createElement(``type``: ReactNode, props: obj): ReactElement = 
        ReactLegacy.internalCreateElement(``type``, props)


    [<ImportMember("react")>]
    static member inline forwardRef(render: 'props * IRefValue<'t> -> ReactElement): ('props * IRefValue<'t> -> ReactElement) = jsNative


[<Erase>]
type React =

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline Fragment (xs: seq<ReactElement>) =
        ReactLegacy.createElement(unbox<ReactNode> (import "Fragment" "react"), children = xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline Fragment (xs: ReactElement) =
        ReactLegacy.createElement(unbox<ReactNode> (import "Fragment" "react"), children = xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: int, xs: seq<ReactElement>) = // Fable.React.Helpers.fragment [ !!("key", key) ] xs
        ReactLegacy.createElement(unbox<ReactNode> (import "Fragment" "react"), {|key = key|}, xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: string, xs: seq<ReactElement>) =
        ReactLegacy.createElement(unbox<ReactNode> (import "Fragment" "react"), {|key = key|}, xs)

    /// The `React.fragment` component lets you return multiple elements in your `render()` method without creating an additional DOM element.
    static member inline KeyedFragment(key: System.Guid, xs: seq<ReactElement>) =
        ReactLegacy.createElement(unbox<ReactNode> (import "Fragment" "react"), {|key = key.ToString()|}, xs)

    /// Placeholder empty React element to be used when importing external React components with the `[<ReactComponent>]` attribute.
    static member inline Imported() : ReactElement = Fable.Core.JS.undefined

    /// The `useState` hook that creates a state variable for React function components from an initialization function.
    [<ImportMember("react")>]
    static member inline useState<'t>(initializer: unit -> 't): ('t * ('t -> unit)) = jsNative

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
    static member inline useReducer(update: 'state -> 'msg -> 'state, initialState: 'state) : ('state * ('msg -> unit)) = jsNative

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<ImportMember("react")>]
    static member inline useEffect(setup: unit -> unit, ?dependencies: obj []) : unit = jsNative

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    // [<ImportMember("react")>]
    static member inline useEffect(setup: unit -> (unit -> unit), ?dependencies: obj []) : unit = 
        JsInterop.emitJsExpr
            (setup, dependencies)
            "import {useEffect} from 'react';
useEffect(() => {
        const setup = $0();
        return setup;
        }, $1);"


    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    static member inline useEffect(setup: unit -> #IDisposable, ?dependencies: obj []) =
        React.useEffect(
            (fun () ->
                let disp = setup()
                fun () -> disp.Dispose()
            ), 
            ?dependencies = dependencies
        )


    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    static member inline useEffect(setup: unit -> #IDisposable option, ?dependencies: obj []) =
        React.useEffect (setup >> Helpers.optDispose, ?dependencies = dependencies)

        /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> unit) : unit = React.useEffect(setup, [| |])

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> (unit -> unit)) : unit = 
        JsInterop.emitJsExpr
            (setup)
            "import {useEffect} from 'react';
useEffect(() => {
        const setup = $0();
        return setup;
        }, []);"

    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> #IDisposable) =
        React.useEffect(setup, [||])


    /// The `useEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useEffect(disposableEffect, [| |])`.
    [<Hook>]
    static member inline useEffectOnce(setup: unit -> #IDisposable option) =
        React.useEffect (setup >> Helpers.optDispose, [||])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    [<ImportMember("react")>]
    static member inline useLayoutEffect(setup: unit -> unit, ?dependencies: obj []) : unit = jsNative

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    [<ImportMember("react")>]
    static member inline useLayoutEffect(setup: unit -> (unit -> unit), ?dependencies: obj []) : unit = 
        JsInterop.emitJsExpr
            (setup, dependencies)
            "import {useLayoutEffect} from 'react';
useLayoutEffect(() => {
        const setup = $0();
        return setup;
        }, $1);"

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    [<ImportMember("react")>]
    static member inline useLayoutEffect(setup: unit -> #IDisposable, ?dependencies: obj []) : unit = 
        React.useLayoutEffect (
            (fun () -> 
                let disp = setup()
                fun () -> disp.Dispose()
            ), 
            ?dependencies = dependencies
        )

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffect(setup: unit -> #IDisposable option, ?dependencies: obj []) =
        React.useLayoutEffect (setup >> Helpers.optDispose, ?dependencies = dependencies)

        /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> unit) : unit = 
        React.useLayoutEffect(setup, [| |])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> (unit -> unit)) : unit = 
        JsInterop.emitJsExpr
            (setup)
            "import {useLayoutEffect} from 'react';
useLayoutEffect(() => {
        const setup = $0();
        return setup;
        }, []);"

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> #IDisposable) : unit = 
        React.useLayoutEffect(setup, [||])

    /// The `useLayoutEffect` hook that creates a disposable effect for React function components.
    /// This effect has no dependencies which means the effect is re-executed on every re-render.
    /// To make the effect run once (for example you subscribe once to web sockets) then provide an empty array
    /// for the dependencies: `React.useLayoutEffect(disposableEffect, [| |])`.
    /// The signature is identical to useEffect, but it fires synchronously after all DOM mutations. Use this to read layout from the DOM and synchronously re-render. Updates scheduled inside useLayoutEffect will be flushed synchronously, before the browser has a chance to paint.
    static member inline useLayoutEffectOnce(setup: unit -> #IDisposable option) =
        React.useLayoutEffect (setup, [||])

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
    /// If not provided, defaults to empty array, representing dependencies that never change.</param>
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
    static member inline useMemo<'a>(calculateValue: unit -> 'a, dependencies: obj array): 'a = jsNative

    /// <summary>
    /// The `useMemo` hook. Returns a memoized value. Pass a "create" function.
    /// 
    /// This will assume an empty array of dependencies, meaning the memoized value will not be recomputed.
    /// </summary>
    /// <param name='createFunction'>A create function returning a value to be memoized.</param>
    static member inline useMemo<'a>(calculateValue: unit -> 'a): 'a = React.useMemo(calculateValue, [||])

    // //
    // // React.functionComponent
    // //

    // /// <summary>
    // /// Creates a React function component from a function that accepts a "props" object and renders a result.
    // /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    // /// </summary>
    // /// <param name='render'>A render function that returns an element.</param>
    // /// <param name='withKey'>A function to derive a component key from the props.</param>
    // static member inline functionComponent(render: 'props -> ReactElement, ?withKey: 'props -> string) =
    //     Internal.functionComponent render None withKey

    // /// <summary>
    // /// Creates a React function component from a function that accepts a "props" object and renders a result.
    // /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    // /// </summary>
    // /// <param name='name'>The component name to display in the React dev tools.</param>
    // /// <param name='render'>A render function that returns an element.</param>
    // /// <param name='withKey'>A function to derive a component key from the props.</param>
    // [<Obsolete "React.functionComponent is obsolete. Use [<ReactComponent>] attribute to automatically convert them to React components">]
    // static member inline functionComponent(name: string, render: 'props -> ReactElement, ?withKey: 'props -> string) =
    //     Internal.functionComponent render (Some name) withKey

    // /// <summary>
    // /// Creates a React function component from a function that accepts a "props" object and renders a result.
    // /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    // /// </summary>
    // /// <param name='render'>A render function that returns a list of elements.</param>
    // /// <param name='withKey'>A function to derive a component key from the props.</param>
    // [<Obsolete "React.functionComponent is obsolete. Use [<ReactComponent>] attribute to automatically convert them to React components">]
    // static member inline functionComponent(render: 'props -> #seq<ReactElement>, ?withKey: 'props -> string) =
    //     Internal.functionComponent (render >> React.fragment) None withKey

    // /// <summary>
    // /// Creates a React function component from a function that accepts a "props" object and renders a result.
    // /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    // /// </summary>
    // /// <param name='render'>A render function that returns a list of elements.</param>
    // /// <param name='name'>The component name to display in the React dev tools.</param>
    // /// <param name='withKey'>A function to derive a component key from the props.</param>
    // [<Obsolete "React.functionComponent is obsolete. Use [<ReactComponent>] attribute to automatically convert them to React components">]
    // static member inline functionComponent
    //     (name: string, render: 'props -> #seq<ReactElement>, ?withKey: 'props -> string)
    //     =
    //     Internal.functionComponent (render >> React.fragment) (Some name) withKey

    //
    // React.memo
    //

    /// <summary>
    /// `React.memo` memoizes the result of a function component. Given the same props, React will skip rendering the component, and reuse the last rendered result.
    /// By default it will only shallowly compare complex objects in the props object. For more control, a custom `arePropsEqual` function can be provided.
    /// </summary>
    /// <param name='element'>A render function or a React.functionComponent.</param>
    /// <param name='arePropsEqual'>A custom comparison function to use instead of React's default shallow compare.</param>
    [<ImportMember("react")>]
    static member inline memo
        (element: 'props -> ReactElement, ?arePropsEqual: 'props -> 'props -> bool) : 'props -> ReactElement
        = jsNative

    //
    // React.useContext
    //

    /// <summary>
    /// Creates a Context object. When React renders a component that subscribes to this Context object
    /// it will read the current context value from the closest matching Provider above it in the tree.
    /// </summary>
    /// <param name='defaultValue'>A default value that is only used when a component does not have a matching Provider above it in the tree.</param>
    /// TODO!
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
    static member StrictMode (children: seq<ReactElement>) : ReactElement = 
        ReactLegacy.createElement(unbox<ReactNode> (import "StrictMode" "react"), children = children)

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
    static member inline lazy'<'props>(load: unit -> JS.Promise<'props -> ReactElement>): LazyComponent<'props> = jsNative

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
    static member inline lazy'<'props>(load: Async<'props -> ReactElement>): LazyComponent<'props> = 
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
    static member inline lazyRender<'props>(lazyComponent: LazyComponent<'props>, props: 'props): ReactElement =
        ReactLegacy.createElement(
            unbox<ReactElement> lazyComponent,
            props
        )

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
    static member inline lazyRender(lazyComponent: LazyComponent<unit>): ReactElement =
        ReactLegacy.createElement(unbox<ReactNode> lazyComponent, props = null)

    /// <summary>
    /// Lets you specify a loading indicator whenever a child element is not yet ready
    /// to render.
    ///
    /// Currently this is only usable with `React.lazy'`.
    /// </summary>
    /// <param name='children'>The elements that will be rendered within the suspense block.</param>
    /// <param name='fallback'>The element that will be rendered while the children are loading.</param>
    static member inline Suspense(children: seq<ReactElement>, ?fallback: ReactElement) = 
        ReactLegacy.createElement(
            unbox<ReactNode> (import "Suspense" "react"), 
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
    static member inline useImperativeHandle(ref: IRefValue<'t>, createHandle: unit -> 't, ?dependencies: obj[]) = jsNative

    /// Creates a disposable instance by providing the implementation of the dispose member.
    static member inline createDisposable(dispose: unit -> unit) = { new IDisposable with member _.Dispose() = dispose() }

    [<Hook>]
    static member inline useDisposable(dispose: unit -> unit): IDisposable = 
        React.useMemo(
            (fun () -> React.createDisposable dispose),
            [| box dispose |] 
        )

    /// <summary>
    /// Creates a CancellationToken that is cancelled when a component is unmounted.
    /// </summary>
    [<Hook>]
    static member inline useCancellationToken() = 
        let cts = React.useRef(new System.Threading.CancellationTokenSource())
        let token = React.useRef(cts.current.Token)

        React.useEffectOnce(
            fun () ->
                React.createDisposable(fun () ->
                    cts.current.Cancel()
                    cts.current.Dispose()
                )
        )
        token

// [<AutoOpen; Erase>]
// module ReactOverloadMagic =
//     type React with
//         /// Creates a disposable instance by merging multiple IDisposables.
//         static member inline createDisposable([<ParamArray>] disposables: #IDisposable[]) =
//             React.createDisposable (fun () -> disposables |> Array.iter (fun d -> d.Dispose()))

//         /// Creates a disposable instance by merging multiple IDisposable options.
//         static member inline createDisposable([<ParamArray>] disposables: #IDisposable option[]) =
//             React.createDisposable (fun () -> disposables |> Array.iter (Option.iter (fun d -> d.Dispose())))

//         /// Creates a disposable instance by merging multiple IDisposable refs.
//         static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable>[]) =
//             React.createDisposable (fun () -> disposables |> Array.iter (fun d -> d.current.Dispose()))

//         /// Creates a disposable instance by merging multiple IDisposable refs.
//         static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable option>[]) =
//             React.createDisposable (fun () ->
//                 disposables
//                 |> Array.iter (fun d -> d.current |> Option.iter (fun d -> d.Dispose())))

//         /// The `useState` hook that creates a state variable for React function components.
//         static member inline useState<'t>(initial: 't) =
//             Interop.reactApi.useState<'t, 't> (initial)


//         static member inline useStateWithUpdater<'t>(initializer: unit -> 't) : ('t * (('t -> 't) -> unit)) =
//             import "useState" "react"

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
        static member inline useState<'t>(init: 't): ('t * ('t -> unit)) = jsNative

        /// Creates a disposable instance by merging multiple IDisposables.
        static member inline createDisposable([<ParamArray>] disposables: #IDisposable []) =
            React.createDisposable(fun () ->
                disposables
                |> Array.iter (fun d -> d.Dispose())
            )
        /// Creates a disposable instance by merging multiple IDisposable options.
        static member inline createDisposable([<ParamArray>] disposables: #IDisposable option []) =
            React.createDisposable(fun () ->
                disposables
                |> Array.iter (Option.iter (fun d -> d.Dispose()))
            )
        /// Creates a disposable instance by merging multiple IDisposable refs.
        static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable> []) =
            React.createDisposable(fun () ->
                disposables
                |> Array.iter (fun d -> d.current.Dispose())
            )

        /// Creates a disposable instance by merging multiple IDisposable refs.
        static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable option> []) =
            React.createDisposable(fun () ->
                disposables
                |> Array.iter (fun d -> d.current |> Option.iter (fun d -> d.Dispose()))
            )
