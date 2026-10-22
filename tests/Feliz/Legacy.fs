module Tests.Components

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser

[<ReactComponent>]
let Counter (props: {| initialCount: int |}) =
    let (count, setCount) = React.useState (props.initialCount)

    Html.div [
        Html.h1 [ prop.testId "count"; prop.text count ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ]

[<ReactComponent>]
let CounterWithDebugValue () =
    let (count, setCount) = React.useState (0)
    React.useDebugValue (sprintf "Count is %d" count)

    Html.div [
        Html.h1 [ prop.testId "count"; prop.text count ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ]

[<ReactComponent>]
let Portal (props: {| child: ReactElement; id: string |}) =
    let root = document.getElementById (props.id)
    ReactDOM.createPortal (props.child, root)

[<ReactComponent>]
let EffectOnceComponent (props: {| effectTriggered: unit -> unit |}) =
    let (count, setCount) = React.useState (0)
    React.useEffectOnce (fun _ -> props.effectTriggered ())

    Html.div [
        Html.h1 [ prop.testId "count"; prop.text count ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ]

[<ReactComponent>]
let UseEffectEveryRender (props: {| effectTriggered: unit -> unit |}) =
    let (count, setCount) = React.useState (0)
    React.useEffect (fun _ -> props.effectTriggered ())

    Html.div [
        Html.h1 [ prop.testId "count"; prop.text count ]

        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.testId "increment"
        ]
    ]

[<ReactComponent>]
let FocusInputExample () =
    let inputRef = React.useInputRef ()

    let focusTextInput () =
        inputRef.current |> Option.iter (fun el -> el.focus ())

    Html.div [
        Html.input [
            prop.ref inputRef
            prop.type'.text
            prop.testId "focused-input"
        ]

        Html.button [
            prop.testId "focus-input"
            prop.onClick (fun _ -> focusTextInput ())
            prop.text "Focus Input"
        ]
    ]

[<ReactComponent>]
let RenderCount (input: {| label: string |}) =
    let countRef = React.useRef 0

    let mutable currentCount = countRef.current

    React.useEffect ((fun () -> countRef.current <- currentCount), [||])

    currentCount <- currentCount + 1

    Html.div [
        prop.testId input.label
        prop.text (sprintf "%i" currentCount)
    ]

// [<ReactComponent>]
// let CallbackRefButton = React.memo(
//     fun (input: {| onClick: unit -> unit |}) ->
//         Html.div [
//             RenderCount {| label = "Button" |}
//             Html.button [
//                 prop.testId "callbackRefButton"
//                 prop.onClick <| fun _ -> input.onClick()
//                 prop.text "Show renders"
//             ]
//         ]
//     )

// [<ReactComponent>]
// let CallbackRef () =
//     let count,setCount = React.useState 1
//     let resultText,setResultText = React.useState ""

//     React.useEffect((fun () ->
//         let interval = JS.setInterval(fun () -> setCount(count + 1)) 1000
//         React.createDisposable(fun () -> JS.clearInterval(interval))
//     ), [| count :> obj |])

//     let showCount = React.useCallback(fun () -> setResultText (string count))

//     Html.div [
//         prop.testId "callbackRef"
//         prop.text resultText
//         prop.children [
//             // React.memo (fun props -> RenderCount) {| label = "Main" |}
//             CallbackRefButton {| onClick = showCount |}
//         ]
//     ]

// [<ReactComponent>]
// let UseLayoutEffectEveryRender (props: {| effectTriggered: unit -> unit |}) =
//     let (count, setCount) = React.useState(0)
//     React.useLayoutEffect(fun _ -> props.effectTriggered())
//     Html.div [
//         Html.h1 [
//             prop.testId "count"
//             prop.text count
//         ]

//         Html.button [
//             prop.text "Increment"
//             prop.onClick (fun _ -> setCount (count + 1))
//             prop.testId "increment"
//         ]
//     ]



// // [<ReactComponent>]
// // let ForwardRefChild = ReactLegacy.forwardRef(fun ((), ref) ->
// //     Html.div [
// //         prop.children [
// //             Html.input [
// //                 prop.testId "focus-input"
// //                 prop.type'.text
// //                 prop.ref ref
// //             ]
// //         ]
// //     ])

// // [<ReactComponent>]
// // let ForwardRefParent () =
// //     let inputRef = React.useInputRef()

// //     Html.div [
// //         prop.children [
// //             ForwardRefChild((), inputRef)
// //             Html.button [
// //                 prop.testId "focus-button"
// //                 prop.text "Click!"
// //                 prop.onClick <| fun ev ->
// //                     inputRef.current
// //                     |> Option.iter (fun elem -> elem.focus())
// //             ]
// //         ]
// //     ]


// // [<ReactComponent>]
// // let ForwardRefImperativeChild = ReactLegacy.forwardRef(fun ((), ref) ->
// //     let divText,setDivText = React.useState ""
// //     let inputRef = React.useInputRef()

// //     React.useImperativeHandle(ref, fun () ->
// //         inputRef.current
// //         |> Option.map(fun innerRef ->
// //             {| focus = fun () -> setDivText innerRef.className |})
// //     )

// //     Html.div [
// //         Html.input [
// //             prop.className "Howdy!"
// //             prop.type'.text
// //             prop.ref inputRef
// //         ]
// //         Html.div [
// //             prop.testId "focus-text"
// //             prop.text divText
// //         ]
// //     ])

// // let ForwardRefImperativeParent () =
// //     let ref = React.useRef<{| focus: unit -> unit |} option>(None)

// //     Html.div [
// //         ForwardRefImperativeChild((), ref)
// //         Html.button [
// //             prop.testId "focus-button"
// //             prop.onClick <| fun ev ->
// //                 ref.current
// //                 |> Option.iter (fun elem -> elem.focus())
// //         ]
// //     ]

// let codeSplittingLoading () =
//     Html.div [
//         prop.testId "loading"
//         prop.text "Loading"
//     ]

// let asyncComponent : JS.Promise<unit -> ReactElement> = JsInterop.importDynamic "./CodeSplitting.fs"

// [<ReactComponent>]
// let CodeSplitting () =
//     React.Suspense(
//         [
//             Html.div [
//                 React.lazy'(
//                     (fun () ->
//                         promise {
//                             do! Promise.sleep 1000
//                             return! asyncComponent
//                         }
//                     )
//                 ) ()
//             ]
//         ],
//         codeSplittingLoading()
//     )

// [<ReactComponent>]
// let FuncCompTest (input: {| count: int |}) =
//     Html.div [
//         RenderCount {| label = "funcCompTest" |}
//         Html.div [
//             prop.text (string input.count)
//         ]
//     ]

// let FuncCompTestDiff () =
//     let count,setCount = React.useState 0

//     React.useEffectOnce(fun () -> setCount (count + 1))

//     Html.div [
//         FuncCompTest {| count = count |}
//     ]

// let funcCompWithKey (count: int) =
//     if count = 0 then "originalKey"
//     else "staticKey"

// [<ReactComponent>]
// let FuncCompTestWithKey (input: {| count: int; key: string |}) =
//     Html.div [
//         RenderCount {| label = "funcCompTestWithKey" |}
//         Html.div [
//             prop.text (string input.count)
//         ]
//     ]

// [<ReactComponent>]
// let FuncCompTestWithKeyDiff () =
//     let count,setCount = React.useState 0

//     React.useEffectOnce(fun () -> setCount (count + 1))

//     Html.div [
//         FuncCompTestWithKey {| count = count; key = funcCompWithKey count |}
//     ]

// [<ReactComponent>]
// let MemoCompTest (input: {| count: int |}) = React.memo(
//     Html.div [
//         RenderCount {| label = "memoCompTest" |}
//         Html.div [
//             prop.text (string input.count)
//         ]
//     ])

// [<ReactComponent>]
// let MemoCompTestDiff () =
//     let count,setCount = React.useState 0

//     React.useEffectOnce(fun () -> setCount (count + 1))

//     Html.div [
//         MemoCompTest {| count = count |}
//     ]

// [<ReactComponent>]
// let MemoCompTestWithKey (input: {| count: int; key: string |}) = React.memo(
//     Html.div [
//         RenderCount {| label = "memoCompTestWithKey" |}
//         Html.div [
//             prop.text (string input.count)
//         ]
//     ])

// [<ReactComponent>]
// let MemoCompTestWithKeyDiff () =
//     let count,setCount = React.useState 0

//     React.useEffectOnce(fun () -> setCount (count + 1))

//     Html.div [
//         MemoCompTestWithKey {| count = count; key = funcCompWithKey count |}
//     ]

// let memoCompareEqual oldProps newProps = true

// [<ReactComponent>]
// let MemoCompTestAreEqual (input: {| count: int |}) = React.memo(
//     Html.div [
//         RenderCount {| label = "memoCompTestAreEqual" |}
//         Html.div [
//             prop.text (string input.count)
//         ]
//     ],
//     arePropsEqual = memoCompareEqual
// )

// [<ReactComponent>]
// let MemoCompTestAreEqualDiff () =
//     let count,setCount = React.useState 0

//     React.useEffectOnce(fun () -> setCount (count + 1))

//     Html.div [
//         MemoCompTestAreEqual {| count = count |}
//     ]

// let MemoCompAreEqual (oldProps: {| count: int |}) (newProps: {| count: int |}) =
//     if oldProps.count < 2 then false
//     else true

// [<ReactComponent>]
// let SelectMultipleWithDefault (input: {| isDefaultValue: bool; isValue: bool; isValueOrDefault: bool |}) =
//     React.Fragment [
//         Html.select [
//             prop.multiple true
//             prop.testId "select-multiple"
//             if input.isDefaultValue then
//                 prop.defaultValue [3]
//             elif input.isValue then
//                 prop.value [3]
//             elif input.isValueOrDefault then
//                 prop.valueOrDefault [3]

//             prop.children [
//                 Html.option [
//                     prop.testId "val1"
//                     prop.value 1
//                     prop.text "A"
//                 ]
//                 Html.option [
//                     prop.testId "val2"
//                     prop.value 2
//                     prop.text "B"
//                 ]
//                 Html.option [
//                     prop.testId "val3"
//                     prop.value 3
//                     prop.text "C"
//                 ]
//             ]
//         ]
//     ]

// [<ReactComponent>]
// let TextfComp (input: {| str: string; i: int |}) =
//     Html.div [
//         prop.children [
//             Html.div [
//                 prop.testId "textf-str"
//                 prop.textf "Hello! %s" input.str
//             ]
//             Html.div [
//                 prop.testId "textf-int"
//                 prop.textf "Hello! %i" input.i
//             ]
//             Html.div [
//                 prop.testId "textf-two"
//                 prop.textf "Hello! %s %i" input.str input.i
//             ]
//             Html.div [
//                 prop.testId "textf-three"
//                 prop.textf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))
//             ]
//         ]
//     ]

// [<ReactComponent>]
// let HtmlTextfComp (input: {| str: string; i: int |}) =
//     Html.div [
//         prop.children [
//             Html.div [
//                 prop.testId "textf-str"
//                 prop.children [
//                     Html.textf "Hello! %s" input.str
//                 ]
//             ]
//             Html.div [
//                 prop.testId "textf-int"
//                 prop.children [
//                     Html.textf "Hello! %i" input.i
//                 ]
//             ]
//             Html.div [
//                 prop.testId "textf-two"
//                 prop.children [
//                     Html.textf "Hello! %s %i" input.str input.i
//                 ]
//             ]
//             Html.div [
//                 prop.testId "textf-three"
//                 prop.children [
//                     Html.textf "Hello! %s %i %s" input.str input.i (input.str + (string input.i))
//                 ]
//             ]
//         ]
//     ]

// module OptionalDispose =

//     // let useEffectWithDis (setup: unit -> System.IDisposable) =
//     //     useEffect(System.Func<_,_>(fun () ->
//     //         let dispose = setup()
//     //         fun () -> dispose.Dispose()
//     //     ))

//     // let useEffect (setup: System.Func<unit, (unit -> unit)>) = import "useEffect" "react"
//     // let useEffectWithDisOpt (setup: unit -> System.IDisposable option) =
//     //     useEffect(System.Func<_,_>(fun () ->
//     //         let dispose = setup()
//     //         match dispose with
//     //         | Some d -> fun () ->  d.Dispose()
//     //         | None -> fun () -> ()
//     //     ))

//     [<ReactComponent>]
//     let OptionalDispose (input: {| onDispose: System.IDisposable option |}) =
//         React.useEffectOnce(fun () -> input.onDispose)
//         // useEffectWithDisOpt(fun () -> input.onDispose)

//         Html.div [
//             prop.testId "dispose-inner"
//         ]

//     [<ReactComponent>]
//     let Render (input: {| isSome: bool |}) =
//         let wasDisposed,setWasDisposed = React.useState false
//         let disposeElement,setDisposeElement = React.useState false

//         // let setWasDisposed = React.useCallbackRef(setWasDisposed)

//         Html.div [
//             Html.div [
//                 prop.testId "was-disposed"
//                 prop.textf "%b" wasDisposed
//             ]
//             if not disposeElement then
//                 if input.isSome then
//                     OptionalDispose {| onDispose = Some { new System.IDisposable with member _.Dispose () = setWasDisposed true } |}
//                 else OptionalDispose {| onDispose = None |}
//             Html.button [
//                 prop.testId "dispose-button"
//                 prop.onClick <| fun _ -> setDisposeElement (not disposeElement)
//             ]
//         ]

// module RefDispose =
//     [<ReactComponent>]
//     let RefDispose (input: {| onDispose: System.IDisposable |}) =
//         React.useEffectOnce(fun () -> input.onDispose)

//         Html.div [
//             prop.testId "dispose-inner"
//         ]

//     [<ReactComponent>]
//     let Render () =
//         let disposedCount,setDisposedCount = React.useState 0
//         let disposedCountRef = React.useRef 0
//         let disposeElement,setDisposeElement = React.useState false

//         let setDisposedCount =
//             React.useCallback(fun () ->
//                 disposedCountRef.current <- disposedCountRef.current + 1
//                 setDisposedCount(disposedCountRef.current)
//             )

//         let disposalOne = React.useRef(Some { new System.IDisposable with member _.Dispose () = setDisposedCount() })
//         let disposalTwo = React.useRef(Some { new System.IDisposable with member _.Dispose () = setDisposedCount() })

//         let multipleDispose = React.createDisposable(disposalOne, disposalTwo)

//         Html.div [
//             Html.div [
//                 prop.testId "disposed-count"
//                 prop.textf "%i" disposedCount
//             ]
//             if not disposeElement then
//                 RefDispose {| onDispose = multipleDispose |}
//             Html.button [
//                 prop.testId "dispose-button"
//                 prop.onClick <| fun _ -> setDisposeElement (not disposeElement)
//             ]
//         ]
