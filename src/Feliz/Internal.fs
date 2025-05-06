namespace Feliz

open System
open Fable.Core
open Fable.Core.JsInterop


module Internal =

    let propsWithKey (withKey: ('props -> string) option) props =
        match withKey with
        | Some f ->
            props?key <- f props
            props
        | None -> props

    let functionComponent
            (renderElement: 'props -> ReactElement)
            (name: string option)
            (withKey: ('props -> string) option)
        : 'props -> Fable.React.ReactElement =
            name |> Option.iter (fun name -> renderElement?displayName <- name)
            #if FABLE_COMPILER_3
            Browser.Dom.console.warn("Feliz: using React.functionComponent in Fable 3 is obsolete, please consider using the [<ReactComponent>] attribute instead which makes Feliz output better Javascript code that is compatible with react-refresh")
            #endif
            fun props ->
                let props = props |> propsWithKey withKey
                Interop.reactApi.createElement(renderElement, props)
    let memo
        (renderElement: 'props -> ReactElement)
        (name: string option)
        (areEqual: ('props -> 'props -> bool) option)
        (withKey: ('props -> string) option)
        : 'props -> Fable.React.ReactElement =
            let memoElementType = Interop.reactApi.memo(renderElement, (defaultArg areEqual (unbox null)))
            name |> Option.iter (fun name -> renderElement?displayName <- name)
            fun props ->
                let props = props |> propsWithKey withKey
                Interop.reactApi.createElement(memoElementType, props)

    let inline useMemo (createFunction: unit -> 'a) (dependencies: (obj array) option) =
        Interop.reactApi.useMemo createFunction (defaultArg dependencies [||])

    let createDisposable (dispose: unit -> unit) =
        { new IDisposable with member _.Dispose() = dispose() }

    [<Hook>]
    let useDisposable (dispose: unit -> unit) =
        useMemo (fun () -> createDisposable dispose) (Some [| dispose |])

    let inline useEffectDisposableOptWithDeps (effect: unit -> #IDisposable option) (dependencies: obj []) =
        ReactInterop.useEffectWithDeps (effect >> Helpers.optDispose) dependencies

    let inline useEffectDisposableOpt (effect: unit -> #IDisposable option) =
        ReactInterop.useEffect effect

    let inline useEffectWithDeps (effect: unit -> unit) (dependencies: obj []) =
        Interop.reactApi.useEffect(effect, dependencies)

    let inline useEffect (effect: unit -> unit) =
        Interop.reactApi.useEffect effect


    [<Hook>]
    let useEffectOnce(effect: unit -> unit) =
        let calledOnce = Interop.reactApi.useRefInternal false
        
        useEffectWithDeps (fun () ->
            if not calledOnce.current then
                calledOnce.current <- true
                effect()
        ) [||]

    [<Hook>]
    let useEffectDisposableOnce (effect: unit -> #IDisposable) =
        let destroyFunc = Interop.reactApi.useRefInternal None
        let calledOnce = Interop.reactApi.useRefInternal false
        let renderAfterCalled = Interop.reactApi.useRefInternal false

        if calledOnce.current then
            renderAfterCalled.current <- true

        useEffectDisposableOptWithDeps (fun () -> 
            if calledOnce.current 
            then None
            else
                calledOnce.current <- true
                destroyFunc.current <- effect() |> Some

                if renderAfterCalled.current
                then destroyFunc.current
                else None
        ) [||]

    [<Hook>]
    let useEffectDisposableOptOnce (effect: unit -> #IDisposable option) =
        let destroyFunc = Interop.reactApi.useRefInternal None
        let calledOnce = Interop.reactApi.useRefInternal false
        let renderAfterCalled = Interop.reactApi.useRefInternal false

        if calledOnce.current then
            renderAfterCalled.current <- true

        useEffectDisposableOptWithDeps (fun () -> 
            if calledOnce.current 
            then None
            else
                calledOnce.current <- true
                destroyFunc.current <- effect()

                if renderAfterCalled.current
                then destroyFunc.current
                else None
        ) [||]


    let createContext<'a> (name: string option) (defaultValue: 'a option) =
        let contextObject = Interop.reactApi.createContext (defaultArg defaultValue Fable.Core.JS.undefined<'a>)
        name |> Option.iter (fun name -> contextObject?displayName <- name)
        contextObject

    let inline useRef<'t>(initialValue: 't) = Interop.reactApi.useRefInternal(initialValue)

    let inline useCallback(callbackFunction: 'a -> 'b) (dependencies: (obj array) option) =
        Interop.reactApi.useCallback callbackFunction (defaultArg dependencies [||])

    let inline useLayoutEffect(effect: unit -> unit) =
        ReactInterop.useLayoutEffect
            (fun _ ->
                effect()
                createDisposable ignore)

    [<Hook>]
    let useCallbackRef(callback: ('a -> 'b)) =
        let lastRenderCallbackRef = useRef(callback)

        let callbackRef =
            useCallback (fun (arg: 'a) ->
                lastRenderCallbackRef.current(arg)
            ) (Some [||])

        useLayoutEffect(fun () ->
            // render is commited - it's safe to update the callback
            lastRenderCallbackRef.current <- callback
        )

        callbackRef

    let forwardRef(render: ('props * IRefValue<'t> -> ReactElement)) : ('props * IRefValue<'t> -> ReactElement) =
        let forwardRefType = Interop.reactApi.forwardRef(Func<'props,IRefValue<'t>,ReactElement> (fun props ref -> render(props,ref)))
        fun (props, ref) ->
            let propsObj = props |> JsInterop.toPlainJsObj
            propsObj?ref <- ref
            Interop.reactApi.createElement(forwardRefType, propsObj)

    let forwardRefWithName (name: string) (render: ('props * IRefValue<'t> -> ReactElement)) : ('props * IRefValue<'t> -> ReactElement) =
        let forwardRefType = Interop.reactApi.forwardRef(Func<'props,IRefValue<'t>,ReactElement> (fun props ref -> render(props,ref)))
        render?displayName <- name
        fun (props, ref) ->
            let propsObj = props |> JsInterop.toPlainJsObj
            propsObj?ref <- ref
            Interop.reactApi.createElement(forwardRefType, propsObj)

    [<Hook>]
    let useCancellationToken () =
        let cts = useRef(new System.Threading.CancellationTokenSource())
        let token = useRef(cts.current.Token)

        useEffectDisposableOnce(fun () ->
            createDisposable(fun () ->
                cts.current.Cancel()
                cts.current.Dispose()
            )
        )

        token
