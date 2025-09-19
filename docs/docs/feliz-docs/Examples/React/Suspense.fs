module Example.Suspense

open Feliz
open Fable.Core

/// Lazy load with delay to simulate large component
/// 
/// Note: Prefer using `[<ReactLazyComponent>]` instead of this approach!
let LazyHello: LazyComponent<unit> =
    React.lazy'(fun () ->
        promise {
            do! Promise.sleep 2000
            return! JsInterop.importDynamic "./Counter"
        }
    )

[<ReactComponent(true)>]
let SuspenseDemo() =
    let load, setLoad = React.useState(false)
    Html.div [
        Html.h3 [ prop.text "Suspense Example" ]
        Html.p "Loading the component will take 2 seconds. Then the component will be cached and future reruns will be instant."
        if load then
            React.Suspense([ 
                    React.lazyRender(LazyHello, ()) 
                ],
                Html.div [ prop.text "Loading..." ]
            )
        else
            Html.button [
                prop.text (if load then "Hide Lazy Component" else "Load Lazy Component")
                prop.onClick (fun _ -> setLoad(not load))
            ]
    ]
