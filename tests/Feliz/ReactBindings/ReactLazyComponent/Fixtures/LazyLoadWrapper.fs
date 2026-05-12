module Tests.ReactBindings.ReactLazyComponent.Fixtures.LazyLoadWrapper

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Components =
    [<ReactComponent>]
    static member LoadOnSwitch(renderLazy: unit -> ReactElement) =
        let shouldLoad, setShouldLoad = React.useState false

        Html.div [
            Html.button [
                prop.testId "load-switch"
                prop.text "Load lazy component"
                prop.onClick (fun _ -> setShouldLoad true)
            ]

            if shouldLoad then
                React.Suspense(
                    fallback = Html.div [ prop.testId "lazy-loading"; prop.text "Loading..." ],
                    children = [ renderLazy () ]
                )
        ]
