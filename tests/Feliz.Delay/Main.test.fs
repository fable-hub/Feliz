module DelayTests

open Fable.Core
open Vitest
open Feliz
open Feliz.Delay
open Browser

[<ReactComponent>]
let DelayComp () =
    React.delay [
        delay.fallback [
            Html.div [
                prop.testId "fallback"
            ]
        ]

        delay.children [
            Html.div [
                prop.testId "render"
            ]
        ]
    ]

[<ReactComponent>]
let DuspenseCompInner() =
    Html.div [
        prop.testId "suspense-child"
    ]

let asyncComponent : JS.Promise<unit -> ReactElement> = JsInterop.importDynamic "./CodeSplitting.fs"

let LazyComponent: LazyComponent<unit> =
    React.lazy'(fun () -> promise {
        do! Promise.sleep 1000
        return! asyncComponent
    })


[<ReactComponent>]
let DelaySuspenseComp () =
    React.delaySuspense [
        delaySuspense.delay [
            delay.fallback [
                Html.div [
                    prop.testId "fallback"
                ]
            ]

            delay.children [
                Html.div [
                    prop.testId "render"
                ]
            ]
        ]

        delaySuspense.children [
            React.lazyRender LazyComponent
        ]
    ]

Vitest.describe("Feliz.Delay Tests", fun _ ->
    Vitest.test("delay does not render until after time has passed", fun () -> promise {
        let render = RTL.render(DelayComp())
        
        Vitest.expect(render.queryByTestId "fallback" |> Option.isSome).toBeTruthy() // "Fallback is rendered initially"
        Vitest.expect(render.queryByTestId "render" |> Option.isNone).toBeTruthy() // render is not rendered initially

        do!
            RTL.waitFor (fun () -> 
                Vitest.expect(render.queryByTestId "fallback" |> Option.isNone).toBeTruthy() // "Fallback is no longer rendered"
                Vitest.expect(render.queryByTestId "render" |> Option.isSome).toBeTruthy() // "Child is now rendered"
            )
    })

    Vitest.test("delaySuspense does not render until after time has passed", fun () -> promise {

        let render = RTL.render(DelaySuspenseComp())
    
        Vitest.expect(render.queryByTestId "fallback" |> Option.isSome).toBeTruthy() // "Delay fallback is rendered initially"
        Vitest.expect(render.queryByTestId "render" |> Option.isNone).toBeTruthy() // "Delay child is not rendered initially"
        Vitest.expect(render.queryByTestId "async-load" |> Option.isNone).toBeTruthy() // "Suspense child is not rendered initially"

        do!
            RTL.waitFor (fun () ->
                Vitest.expect(render.queryByTestId "fallback" |> Option.isNone).toBeTruthy() // Fallback is no longer rendered
                Vitest.expect(render.queryByTestId "render" |> Option.isSome).toBeTruthy() // Child is now rendered
                Vitest.expect(render.queryByTestId "async-load" |> Option.isNone).toBeTruthy() // Suspense child is still not rendered
            )
        do! Promise.sleep 1000

        do!
            RTL.waitFor (fun () ->
                Vitest.expect(render.queryByTestId "fallback" |> Option.isNone).toBeTruthy() //"delay fallback is no longer rendered"
                Vitest.expect(render.queryByTestId "render" |> Option.isNone).toBeTruthy() //"delay child is no longer rendered"
                Vitest.expect(render.queryByTestId "async-load" |> Option.isSome).toBeTruthy() //"Suspense child is now rendered"
            )
    })
)
