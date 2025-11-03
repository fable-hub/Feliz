module Components 

open Feliz
open Fable.Core
open Fable.Core.JS


// [<ReactLazyComponent>]
// let LazyCounter(init) = Counter.Counter.Counter(init)


// [<ReactLazyComponent>]
// let private LazyCounter(init: int) : ReactElement = React.DynamicImported "./Counter"

    // Counter.Counter.Counter(init)


// [<ReactComponent>]
// let LazyLoad() =
//         let showPreview, setShowPreview = React.useState(false)
//         let count, setCount = React.useState(0)
//         Html.div [
//             Html.input [
//                 prop.testId "input"
//                 prop.type'.number
//                 prop.value count
//                 prop.onChange (fun (e: int) -> setCount(e))
//             ]
//             Html.label [
//                 Html.input [
//                     prop.testId "checkbox"
//                     prop.type' "checkbox"
//                     prop.onChange (fun (e: bool) -> setShowPreview(e))
//                 ]
//                 Html.text "Load Component"
//             ]
//             if showPreview then
//                 React.Suspense(
//                     fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
//                     children = [
//                         Html.h1 "Preview"
//                         // LazyCounter(count)
//                     ]
//                 )
//         ]

let Main() =
    Html.div [
        // LazyLoad()
        Html.div "!"
        NativeCounter.NativeCounter()
    ]
