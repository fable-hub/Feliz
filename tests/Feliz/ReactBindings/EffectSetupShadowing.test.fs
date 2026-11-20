/// Regression tests: the effect hooks with cleanup are emitted through a JS template. A local name declared in that
/// template used to shadow user values with the same name (here `setup`) and threw "Cannot access 'setup' before
/// initialization".
module Tests.ReactBindings.EffectSetupShadowingTests

open Feliz
open Vitest

type Components =
    [<ReactComponent>]
    static member UseEffect(setup: unit -> unit, cleanup: unit -> unit) =
        React.useEffect (
            (fun () ->
                setup ()
                fun () -> cleanup ()
            ),
            [||]
        )

        Html.div "useEffect"

    [<ReactComponent>]
    static member UseEffectOnce(setup: unit -> unit, cleanup: unit -> unit) =
        React.useEffectOnce (fun () ->
            setup ()
            fun () -> cleanup ()
        )

        Html.div "useEffectOnce"

    [<ReactComponent>]
    static member UseLayoutEffect(setup: unit -> unit, cleanup: unit -> unit) =
        React.useLayoutEffect (
            (fun () ->
                setup ()
                fun () -> cleanup ()
            ),
            [||]
        )

        Html.div "useLayoutEffect"

    [<ReactComponent>]
    static member UseLayoutEffectOnce(setup: unit -> unit, cleanup: unit -> unit) =
        React.useLayoutEffectOnce (fun () ->
            setup ()
            fun () -> cleanup ()
        )

        Html.div "useLayoutEffectOnce"

let private runsSetupAndCleanup (render: (unit -> unit) * (unit -> unit) -> ReactElement) =
    let setup: unit -> unit = vi.fn (fun () -> ())
    let cleanup: unit -> unit = vi.fn (fun () -> ())

    let result = RTL.render (render (setup, cleanup))
    expect(setup).toHaveBeenCalledTimes 1

    result.unmount ()
    expect(cleanup).toHaveBeenCalledTimes 1

describe "effect hooks with a captured value named `setup`"
<| fun _ ->
    test "useEffect" <| fun _ -> runsSetupAndCleanup Components.UseEffect
    test "useEffectOnce" <| fun _ -> runsSetupAndCleanup Components.UseEffectOnce

    test "useLayoutEffect"
    <| fun _ -> runsSetupAndCleanup Components.UseLayoutEffect

    test "useLayoutEffectOnce"
    <| fun _ -> runsSetupAndCleanup Components.UseLayoutEffectOnce
