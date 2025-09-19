module Tests.ReactBindings

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
module TestContext =

    let MyContext = React.createContext<{|state: string; setState: string -> unit|}>()


[<Erase; Mangle(false)>]
module TestLazyComponent =

    let LazyLoadComponent: LazyComponent<{|text: string|}> = 
        React.lazy'(fun () ->
            promise {
                do! Promise.sleep 2000
                return! Fable.Core.JsInterop.importDynamic "./CodeSplitting.jsx"
            }
        )

    [<ReactLazyComponent>]
    let LazyLoadComponentAttributeFromPath(text: string) = React.DynamicImported "./CodeSplitting.jsx"

    [<ReactLazyComponent>]
    let LazyLoadComponentAttribute(text: string) = CodeSplitting.CodeSplitting.MyCodeSplitComponent(text)

[<Erase; Mangle(false)>]
type TestLazyComponentClass =

    [<ReactLazyComponent>]
    static member LazyLoadComponent(?text: string) = CodeSplitting.CodeSplitting.MyCodeSplitComponent(?text = text)

    [<ReactLazyComponent>]
    static member LazyLoadComponentFromPath(?text: string) = React.DynamicImported "./CodeSplitting.jsx"

[<Erase; Mangle(false)>]
type Components =

    [<ReactComponent>]
    static member ComponentUseState(?init: int) =
        let count, setCount = React.useState 0

        Html.div [
            Html.p [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.testId "increment"
                prop.text "Increment"
            ]
        ]

    [<ReactComponent>]
    static member FragmentComponent () =
        React.Fragment [
            Html.p [ prop.testId "first"; prop.text "Hello" ]
            Html.p [ prop.testId "second"; prop.text "World" ]
        ]

    [<ReactComponent>]
    static member ComponentUseCallback(onCreate: (unit -> unit) -> unit) =
        let count, setCount = React.useState 0

        let handleClick = React.useCallback(
            (fun () ->
                Browser.Dom.console.log("Clicked", count)
            ),
            [| box count |]
        )

        onCreate handleClick

        Html.button [
            prop.onClick (fun _ -> setCount(count + 1))
            prop.testId "increment"
            prop.text $"Count: {count}"
        ]

    [<ReactComponent>]
    static member ComponentContextConsumer() =
        let value = React.useContext(TestContext.MyContext)

        Html.div [
            Html.div [
                prop.testId "context-value"
                prop.text value.state
            ]
            Html.button [
                prop.onClick (fun _ -> value.setState "Updated value")
                prop.testId "update-context"
                prop.text "Update Context"
            ]
        ]

    [<ReactComponent>]
    static member ComponentContextProvider() =
        let value, setValue = React.useState "Provided value"

        TestContext.MyContext.Provider(
            {| state = value; setState = setValue|}, 
            [
                Components.ComponentContextConsumer()
            ]
        )

    [<ReactComponent>]
    static member ComponentUseInputRef () =
        let inputRef = React.useInputRef()

        let handleClick () =
            match inputRef.current with
            | Some el -> el.value <- "Updated via ref"
            | None -> ()

        Html.div [
            Html.input [
                prop.testId "my-input"
                prop.ref inputRef
            ]
            Html.button [
                prop.testId "update-button"
                prop.text "Update input"
                prop.onClick (fun _ -> handleClick())
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseRefForValue () =
        // Ref is used to store a value
        let countRef = React.useRef(0)
        let state, setState = React.useState(0)

        let handleIncrement () =
            countRef.current <- countRef.current + 1

        Html.div [
            Html.div [
                prop.testId "count-display"
                prop.text state
            ]
            Html.button [
                prop.testId "increment-ref-button"
                prop.text "Increment ref"
                prop.onClick (fun _ -> handleIncrement())
            ]
            Html.button [
                prop.testId "update-state-button"
                prop.text "Increment state"
                prop.onClick (fun _ -> setState countRef.current)
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseMemo () =
        // Simple memoized value based on count
        let count, setCount = React.useState 0
        let memoizedValue = React.useMemo((fun () -> $"Memoized count: {count}"))

        Html.div [
            Html.div [
                prop.testId "memoized-value"
                prop.text memoizedValue
            ]
            Html.div [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.testId "increment-button"
                prop.text "Increment"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseMemoWithDependency () =
        // Simple memoized value based on count
        let count, setCount = React.useState 0
        let memoizedValue = React.useMemo((fun () -> $"Memoized count: {count}"), [|box count|])

        Html.div [
            Html.div [
                prop.testId "memoized-value"
                prop.text memoizedValue
            ]
            Html.div [
                prop.testId "count"
                prop.text count
            ]
            Html.button [
                prop.testId "increment-button"
                prop.text "Increment"
                prop.onClick (fun _ -> setCount(count + 1))
            ]
        ]

    [<ReactComponent>]
    static member ComponentUseEffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffect(
            (fun () ->
                effect()
                fun () -> disposeEffect()
            )
        )

        Html.div [

        ]

    [<ReactComponent>]
    static member ComponentUseEffectIDisposable(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffectOnce(
            (fun () ->
                effect()
                React.createDisposable(disposeEffect)
            )
        )

        Html.div [

        ]

    
    [<ReactComponent>]
    static member ComponentUseLayoutEffectWithUnmount(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffect(
            (fun () ->
                effect()
                fun () -> disposeEffect()
            )
        )

        Html.div [

        ]

    [<ReactComponent>]
    static member ComponentUseLayoutEffectIDisposable(effect: unit -> unit, disposeEffect: unit -> unit) =
        React.useEffectOnce(
            (fun () ->
                effect()
                React.createDisposable(disposeEffect)
            )
        )

        Html.div [

        ]

    [<ReactComponent>]
    static member ComponentUseCancelationTokenSubcomponent(onToken: System.Threading.CancellationToken -> unit) =
        let token = React.useCancellationToken()

        React.useEffectOnce(fun () ->
            onToken token.current
        )

        Html.div [ ]

    [<ReactComponent>]
    static member LazyLoad() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        React.lazyRender(TestLazyComponent.LazyLoadComponent, {|text = text|})
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeLet() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponent.LazyLoadComponentAttribute(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeClass() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponentClass.LazyLoadComponent(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeLetFromPath() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponent.LazyLoadComponentAttributeFromPath(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member LazyLoadLazyComponentAttributeClassFromPath() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        TestLazyComponentClass.LazyLoadComponentFromPath(text)
                    ]
                )
        ]

    [<ReactComponent>]
    static member ComponentStrictWithEffect(onInit: unit -> unit) =
        React.useEffect((fun () -> onInit()), [||])

        Html.div [
            prop.testId "strict-effect"
            prop.text "This component uses StrictMode with an effect"
        ]

    [<ReactComponent>]
    static member EffectfulTimer() =
        let (paused, setPaused) = React.useState(false)
        // using useStateWithUpdater instead of useState
        // to avoid stale closures in React.useEffect
        let (value, setValue) = React.useStateWithUpdater(0)

        let subscribeToTimer() =
            // start the timer
            let subscriptionId = Fable.Core.JS.setInterval (fun _ -> if not paused then setValue (fun prev -> prev + 1)) 1000
            // return IDisposable with cleanup code that stops the timer
            { new System.IDisposable with member this.Dispose() = Fable.Core.JS.clearInterval(subscriptionId) }

        React.useEffect(subscribeToTimer, [| box paused |])

        Html.div [
            Html.h1 [
                prop.testId "timer-value"
                prop.text value
            ]

            Html.button [
                prop.testId "pause-button"
                prop.style [
                    if paused then
                        style.backgroundColor "yellow"
                    else
                        style.backgroundColor "green"
                ]

                prop.onClick (fun _ -> setPaused(not paused))
                prop.text (if paused then "Resume" else "Pause")
            ]
        ]

    // [<ReactComponent>]
    // static member ComponentUseCancelationToken() =
    //     let tokenRef = React.useRef(None)
    //     let mountSubcomponent, setState = React.useState(true)

    //     Html.div [
    //         if mountSubcomponent then
    //             Components.ComponentUseCancelationTokenSubcomponent(fun token ->
    //                 tokenRef.current <- Some token
    //             )
    //         Html.div [
    //             prop.testId "cancellation-token"
    //             prop.text (match tokenRef.current with | Some token when token.IsCancellationRequested -> "Cancelled" | _ -> "Not Cancelled")
    //         ]
    //         Html.button [
    //             prop.testId "unmount-button"
    //             prop.text "Cancel"
    //             prop.onClick (fun _ -> setState(false))
    //         ]
    //     ]
