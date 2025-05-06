module Components

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser


let counter = React.functionComponent(fun (props: {| initialCount: int |}) ->
    let (count, setCount) = React.useState(props.initialCount)
    Html.div [
        Html.h1 [
            prop.testId "count"
            prop.text count
        ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ])

let counterWithDebugValue = React.functionComponent(fun () ->
    let (count, setCount) = React.useState(0)
    React.useDebugValue(sprintf "Count is %d" count)
    Html.div [
        Html.h1 [
            prop.testId "count"
            prop.text count
        ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ])

let effectOnceComponent = React.functionComponent(fun (props: {| effectTriggered: unit -> unit |}) ->
    let (count, setCount) = React.useState(0)
    React.useEffectOnce(fun _ -> props.effectTriggered())
    Html.div [
        Html.h1 [
            prop.testId "count"
            prop.text count
        ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ])

let useEffectEveryRender = React.functionComponent(fun (props: {| effectTriggered: unit -> unit |}) ->
    let (count, setCount) = React.useState(0)
    React.useEffect(fun _ -> props.effectTriggered())
    Html.div [
        Html.h1 [
            prop.testId "count"
            prop.text count
        ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ])

let portal = React.functionComponent(fun (props: {| child: ReactElement; id: string |}) ->
    let root = document.getElementById(props.id)
    ReactDOM.createPortal(props.child, root)
)

let useLayoutEffectEveryRender = React.functionComponent(fun (props: {| effectTriggered: unit -> unit |}) ->
    let (count, setCount) = React.useState(0)
    React.useLayoutEffect(fun _ -> props.effectTriggered())
    Html.div [
        Html.h1 [
            prop.testId "count"
            prop.text count
        ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ])

let renderCount = React.functionComponent(fun (input: {| label: string |}) ->
    let countRef = React.useRef 0

    let mutable currentCount = countRef.current

    React.useEffect(fun () -> countRef.current <- currentCount)

    currentCount <- currentCount + 1

    Html.div [
        prop.testId input.label
        prop.text (sprintf "%i" currentCount)
    ])

let callbackRefButton = React.memo(fun (input: {| onClick: unit -> unit |}) ->
    Html.div [
        renderCount {| label = "Button" |}
        Html.button [
            prop.testId "callbackRefButton"
            prop.onClick <| fun _ -> input.onClick()
            prop.text "Show renders"
        ]
    ])

let callbackRef = React.functionComponent(fun () ->
    let count,setCount = React.useState 1
    let resultText,setResultText = React.useState ""

    React.useEffect((fun () ->
        let interval = JS.setInterval(fun () -> setCount(count + 1)) 1000
        React.createDisposable(fun () -> JS.clearInterval(interval))
    ), [| count :> obj |])

    let showCount = React.useCallbackRef(fun () -> setResultText (string count))

    Html.div [
        prop.testId "callbackRef"
        prop.text resultText
        prop.children [
            React.memo (fun props -> renderCount props) {| label = "Main" |}
            callbackRefButton {| onClick = showCount |}
        ]
    ])


let focusInputExample = React.functionComponent(fun () ->
    let inputRef = React.useInputRef()
    let focusTextInput() = inputRef.current |> Option.iter (fun el -> el.focus())

    Html.div [
        Html.input [
            prop.ref inputRef
            prop.type'.text
            prop.testId "focused-input"
        ]

        Html.button [
            prop.testId "focus-input"
            prop.onClick (fun _ -> focusTextInput())
            prop.text "Focus Input"
        ]
    ])

let forwardRefChild = React.forwardRef("forwardChild", fun ((), ref) ->
    Html.div [
        prop.children [
            Html.input [
                prop.testId "focus-input"
                prop.type'.text
                prop.ref ref
            ]
        ]
    ])

let forwardRefParent = React.functionComponent(fun () ->
    let inputRef = React.useInputRef()

    Html.div [
        prop.children [
            forwardRefChild((), inputRef)
            Html.button [
                prop.testId "focus-button"
                prop.text "Click!"
                prop.onClick <| fun ev ->
                    inputRef.current
                    |> Option.iter (fun elem -> elem.focus())
            ]
        ]
    ])

let forwardRefImperativeChild = React.forwardRef(fun ((), ref) ->
    let divText,setDivText = React.useState ""
    let inputRef = React.useInputRef()

    React.useImperativeHandle(ref, fun () ->
        inputRef.current
        |> Option.map(fun innerRef ->
            {| focus = fun () -> setDivText innerRef.className |})
    )

    Html.div [
        Html.input [
            prop.className "Howdy!"
            prop.type'.text
            prop.ref inputRef
        ]
        Html.div [
            prop.testId "focus-text"
            prop.text divText
        ]
    ])

let forwardRefImperativeParent = React.functionComponent(fun () ->
    let ref = React.useRef<{| focus: unit -> unit |} option>(None)

    Html.div [
        forwardRefImperativeChild((), ref)
        Html.button [
            prop.testId "focus-button"
            prop.onClick <| fun ev ->
                ref.current
                |> Option.iter (fun elem -> elem.focus())
        ]
    ])

let codeSplittingLoading = React.functionComponent(fun () ->
    Html.div [
        prop.testId "loading"
        prop.text "Loading"
    ])

let asyncComponent : JS.Promise<unit -> ReactElement> = JsInterop.importDynamic "./CodeSplitting.fs"

let codeSplitting = React.functionComponent(fun () ->
    React.suspense([
        Html.div [
            React.lazy'((fun () ->
                promise {
                    do! Promise.sleep 1000
                    return! asyncComponent
                }
            ),())
        ]
    ], codeSplittingLoading()))

let funcCompTest = React.functionComponent(fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "funcCompTest" |}
        Html.div [
            prop.text (string input.count)
        ]
    ])

let funcCompTestDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffectOnce(fun () -> setCount (count + 1))

    Html.div [
        funcCompTest {| count = count |}
    ])

let funcCompWithKey (props: {| count: int |} ) =
    if props.count = 0 then "originalKey"
    else "staticKey"

let funcCompTestWithKey = React.functionComponent((fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "funcCompTestWithKey" |}
        Html.div [
            prop.text (string input.count)
        ]
    ]), funcCompWithKey)

let funcCompTestWithKeyDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffectOnce(fun () -> setCount (count + 1))

    Html.div [
        funcCompTestWithKey {| count = count |}
    ])

let memoCompTest = React.memo(fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "memoCompTest" |}
        Html.div [
            prop.text (string input.count)
        ]
    ])

let memoCompTestDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffectOnce(fun () -> setCount (count + 1))

    Html.div [
        memoCompTest {| count = count |}
    ])

let memoCompTestWithKey = React.memo((fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "memoCompTestWithKey" |}
        Html.div [
            prop.text (string input.count)
        ]
    ]), funcCompWithKey)

let memoCompTestWithKeyDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffectOnce(fun () -> setCount (count + 1))

    Html.div [
        memoCompTestWithKey {| count = count |}
    ])

let memoCompareEqual oldProps newProps = true

let memoCompTestAreEqual = React.memo((fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "memoCompTestAreEqual" |}
        Html.div [
            prop.text (string input.count)
        ]
    ]), areEqual = memoCompareEqual)

let memoCompTestAreEqualDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffectOnce(fun () -> setCount (count + 1))

    Html.div [
        memoCompTestAreEqual {| count = count |}
    ])

let memoCompAreEqual (oldProps: {| count: int |}) (newProps: {| count: int |}) =
    if oldProps.count < 2 then false
    else true

let memoCompWithKey (props: {| count: int |}) =
    if props.count > 2 then "2"
    else System.Guid() |> unbox<string>

let memoCompTestAreEqualWithKey = React.memo((fun (input: {| count: int |}) ->
    Html.div [
        renderCount {| label = "memoCompTestAreEqualWithKey" |}
        Html.div [
            prop.text (string input.count)
        ]
    ]), memoCompWithKey, areEqual = memoCompAreEqual)

let memoCompTestAreEqualWithKeyDiff = React.functionComponent(fun () ->
    let count,setCount = React.useState 0

    React.useEffect(fun () ->
        async {
            do! Async.Sleep 25
            if count < 10 then setCount (count + 1)
        } |> Async.StartImmediate
    )

    Html.div [
        memoCompTestAreEqualWithKey {| count = count |}
    ])

let selectMultipleWithDefault = React.functionComponent(fun (input: {| isDefaultValue: bool; isValue: bool; isValueOrDefault: bool |}) ->
    React.fragment [
        Html.select [
            prop.multiple true
            prop.testId "select-multiple"
            if input.isDefaultValue then
                prop.defaultValue [3]
            elif input.isValue then
                prop.value [3]
            elif input.isValueOrDefault then
                prop.valueOrDefault [3]

            prop.children [
                Html.option [
                    prop.testId "val1"
                    prop.value 1
                    prop.text "A"
                ]
                Html.option [
                    prop.testId "val2"
                    prop.value 2
                    prop.text "B"
                ]
                Html.option [
                    prop.testId "val3"
                    prop.value 3
                    prop.text "C"
                ]
            ]
        ]
    ])

let textfComp = React.functionComponent(fun (input: {| str: string; i: int |}) ->
    Html.div [
        prop.children [
            Html.div [
                prop.testId "textf-str"
                prop.textf "Hello! %s" input.str
            ]
            Html.div [
                prop.testId "textf-int"
                prop.textf "Hello! %i" input.i
            ]
            Html.div [
                prop.testId "textf-two"
                prop.textf "Hello! %s %i" input.str input.i
            ]
            Html.div [
                prop.testId "textf-three"
                prop.textf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))
            ]
        ]
    ])

let htmlTextfComp = React.functionComponent(fun (input: {| str: string; i: int |}) ->
    Html.div [
        prop.children [
            Html.div [
                prop.testId "textf-str"
                prop.children [
                    Html.textf "Hello! %s" input.str
                ]
            ]
            Html.div [
                prop.testId "textf-int"
                prop.children [
                    Html.textf "Hello! %i" input.i
                ]
            ]
            Html.div [
                prop.testId "textf-two"
                prop.children [
                    Html.textf "Hello! %s %i" input.str input.i
                ]
            ]
            Html.div [
                prop.testId "textf-three"
                prop.children [
                    Html.textf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))
                ]
            ]
        ]
    ])

module TokenCancellation =
    let useToken = React.functionComponent(fun (input: {| failedCallback: unit -> unit |}) ->
        let token = React.useCancellationToken()

        React.useEffectOnce(fun () ->
            async {
                do! Async.Sleep 500
                input.failedCallback()
            }
            |> fun a -> Async.StartImmediate(a,token.current)
        )

        Html.none)

    let resultComp = React.functionComponent(fun (input: {| result: string |}) ->
        Html.div [
            prop.testId "useTokenCancellation" // this is tested for disposed
            prop.text input.result
        ])

    let main = React.functionComponent(fun (input: {| failTest: bool |}) ->
        let renderChild,setRenderChild = React.useState true
        let resultText,setResultText = React.useState ""

        let setFailed = React.useCallbackRef <| fun () -> setResultText "Failed"

        React.useLayoutEffectOnce(fun () ->
            async {
                do! Async.Sleep 100

                if not input.failTest then
                    setResultText "Disposed"
                    setRenderChild false
            }
            |> Async.StartImmediate
        )

        Html.div [
            if renderChild then
                useToken {| failedCallback = setFailed |}
            resultComp {| result = resultText |}
        ])

module OptionalDispose =

    // let useEffectWithDis (setup: unit -> System.IDisposable) = 
    //     useEffect(System.Func<_,_>(fun () ->
    //         let dispose = setup()
    //         fun () -> dispose.Dispose()
    //     ))

    // let useEffect (setup: System.Func<unit, (unit -> unit)>) = import "useEffect" "react"
    // let useEffectWithDisOpt (setup: unit -> System.IDisposable option) = 
    //     useEffect(System.Func<_,_>(fun () ->
    //         let dispose = setup()
    //         match dispose with
    //         | Some d -> fun () ->  d.Dispose()
    //         | None -> fun () -> ()
    //     ))

    let optionalDispose = React.functionComponent(fun (input: {| onDispose: System.IDisposable option |}) ->
        React.useEffectOnce(fun () -> input.onDispose)
        // useEffectWithDisOpt(fun () -> input.onDispose)

        Html.div [
            prop.testId "dispose-inner"
        ])

    let render = React.functionComponent(fun (input: {| isSome: bool |}) ->
        let wasDisposed,setWasDisposed = React.useState false
        let disposeElement,setDisposeElement = React.useState false

        // let setWasDisposed = React.useCallbackRef(setWasDisposed)

        Html.div [
            Html.div [
                prop.testId "was-disposed"
                prop.textf "%b" wasDisposed
            ]
            if not disposeElement then
                if input.isSome then
                    optionalDispose {| onDispose = Some { new System.IDisposable with member _.Dispose () = setWasDisposed true } |}
                else optionalDispose {| onDispose = None |}
            Html.button [
                prop.testId "dispose-button"
                prop.onClick <| fun _ -> setDisposeElement (not disposeElement)
            ]
        ])

module RefDispose =
    let refDispose = React.functionComponent(fun (input: {| onDispose: System.IDisposable |}) ->
        React.useEffectOnce(fun () -> input.onDispose)

        Html.div [
            prop.testId "dispose-inner"
        ])

    let render = React.functionComponent(fun () ->
        let disposedCount,setDisposedCount = React.useState 0
        let disposedCountRef = React.useRef 0
        let disposeElement,setDisposeElement = React.useState false

        let setDisposedCount =
            React.useCallbackRef(fun () ->
                disposedCountRef.current <- disposedCountRef.current + 1
                setDisposedCount(disposedCountRef.current)
            )

        let disposalOne = React.useRef(Some { new System.IDisposable with member _.Dispose () = setDisposedCount() })
        let disposalTwo = React.useRef(Some { new System.IDisposable with member _.Dispose () = setDisposedCount() })

        let multipleDispose = React.createDisposable(disposalOne, disposalTwo)

        Html.div [
            Html.div [
                prop.testId "disposed-count"
                prop.textf "%i" disposedCount
            ]
            if not disposeElement then
                refDispose {| onDispose = multipleDispose |}
            Html.button [
                prop.testId "dispose-button"
                prop.onClick <| fun _ -> setDisposeElement (not disposeElement)
            ]
        ])
