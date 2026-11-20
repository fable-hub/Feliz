module Tests.ReactBindings.ComponentsTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Browser.Types
open Vitest

type Components =
    [<ReactComponent>]
    static member Counter() =
        let count, setCount = React.useState 0

        Html.button [
            prop.testId "counter"
            prop.onClick (fun _ -> setCount (count + 1))
            prop.text count
        ]

    [<ReactComponent>]
    static member ActivityToggle() =
        let visible, setVisible = React.useState true

        Html.div [
            Html.button [
                prop.testId "toggle"
                prop.onClick (fun _ -> setVisible (not visible))
                prop.text "Toggle"
            ]
            React.Activity(
                (if visible then
                     ActivityMode.Visible
                 else
                     ActivityMode.Hidden),
                Html.div [
                    prop.testId "panel"
                    prop.children [ Components.Counter() ]
                ]
            )
        ]

    [<ReactComponent>]
    static member FragmentEvents(onClick: unit -> unit) =
        let fragmentRef = React.useRef<FragmentInstance option> None

        React.useEffect (
            (fun () ->
                match fragmentRef.current with
                | Some fragment ->
                    let handler = fun (_: Event) -> onClick ()
                    fragment.addEventListener ("click", handler)
                    fun () -> fragment.removeEventListener ("click", handler)
                | None -> fun () -> ()
            ),
            [||]
        )

        Html.div [
            React.Fragment(
                fragmentRef,
                [
                    Html.button [ prop.testId "first"; prop.text "First" ]
                    Html.button [ prop.testId "second"; prop.text "Second" ]
                ]
            )
        ]

    [<ReactComponent>]
    static member FragmentFocus() =
        Html.div [
            React.Fragment(
                (fun (fragment: FragmentInstance) ->
                    if not (isNull fragment) then
                        fragment.focus ()
                ),
                [
                    Html.input [ prop.testId "first-input" ]
                    Html.input [ prop.testId "second-input" ]
                ]
            )
        ]

    [<ReactComponent>]
    static member FragmentCleanup(onAttach: unit -> unit, onDetach: unit -> unit) =
        Html.div [
            React.Fragment(
                (fun (_: FragmentInstance) ->
                    onAttach ()
                    fun () -> onDetach ()
                ),
                [ Html.span "content" ]
            )
        ]

/// Calls a ViewTransition event handler the way React does: `handler(instance, types)`.
let private invokeViewTransitionHandler (property: IViewTransitionProperty) : obj =
    let _, handler = unbox<string * obj> property
    emitJsExpr handler "$0(null, [])"

describe "Activity"
<| fun _ ->
    testPromise "hides its children and keeps their state"
    <| fun _ -> promise {
        RTL.render (Components.ActivityToggle()) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "counter")
        expect(RTL.screen.getByTestId "counter").toHaveTextContent "1"

        do! userEvent.click (RTL.screen.getByTestId "toggle")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "panel").toHaveStyle "display: none")

        do! userEvent.click (RTL.screen.getByTestId "toggle")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "panel").not.toHaveStyle "display: none")
        expect(RTL.screen.getByTestId "counter").toHaveTextContent "1"
    }

describe "Profiler"
<| fun _ ->
    test "reports render timings"
    <| fun _ ->
        let mutable renders: ProfilerRenderInfo list = []

        RTL.render (React.Profiler("profiled-tree", (fun info -> renders <- renders @ [ info ]), [ Html.p "profiled" ]))
        |> ignore

        match renders with
        | first :: _ ->
            expect(first.id).toBe "profiled-tree"
            expect(first.phase).toBe "mount"
            expect(first.actualDuration >= 0.0).toBe true
            expect(first.commitTime >= 0.0).toBe true
        | [] -> failwith "onRender was not called"

describe "ViewTransition"
<| fun _ ->
    test "renders its children from properties"
    <| fun _ ->
        RTL.render (
            React.ViewTransition [
                viewTransition.name "hero"
                viewTransition.enter "slide-in"
                viewTransition.exit [ "next", "slide-left"; "default", "auto" ]
                viewTransition.default' "none"
                viewTransition.onEnter (fun _ _ -> ())
                viewTransition.children [ Html.p [ prop.testId "content"; prop.text "animated" ] ]
            ]
        )
        |> ignore

        expect(RTL.screen.getByTestId "content").toHaveTextContent "animated"

    test "renders its children from a list"
    <| fun _ ->
        RTL.render (React.ViewTransition [ Html.p [ prop.testId "content"; prop.text "animated" ] ])
        |> ignore

        expect(RTL.screen.getByTestId "content").toHaveTextContent "animated"

    test "builds class maps per transition type"
    <| fun _ ->
        let _, value =
            unbox<string * obj>(viewTransition.enter [ "next", "slide-left"; "default", "auto" ])

        expect(value?next).toBe "slide-left"
        expect(value?``default``).toBe "auto"

    test "event handlers keep React's (instance, types) call shape"
    <| fun _ ->
        let mutable receivedTypes: string[] option = None

        let result =
            invokeViewTransitionHandler (viewTransition.onUpdate (fun _ types -> receivedTypes <- Some types))

        expect(receivedTypes |> Option.map Array.length).toEqual(Some 0)
        expect(isNull result || jsTypeof result = "undefined").toBe true

    test "event handlers can return a cleanup function"
    <| fun _ ->
        let cleanup: unit -> unit = vi.fn (fun () -> ())

        let result =
            invokeViewTransitionHandler (viewTransition.onEnter (fun _ _ -> fun () -> cleanup ()))

        expect(jsTypeof result).toBe "function"
        expect(cleanup).toHaveBeenCalledTimes 0

        emitJsExpr result "$0()" |> ignore
        expect(cleanup).toHaveBeenCalledTimes 1

describe "Fragment refs"
<| fun _ ->
    testPromise "adds event listeners to the Fragment's children"
    <| fun _ -> promise {
        let onClick: unit -> unit = vi.fn (fun () -> ())
        RTL.render (Components.FragmentEvents(onClick)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "first")
        do! userEvent.click (RTL.screen.getByTestId "second")

        expect(onClick).toHaveBeenCalledTimes 2
    }

    test "focuses the first focusable child"
    <| fun _ ->
        RTL.render (Components.FragmentFocus()) |> ignore

        expect(RTL.screen.getByTestId "first-input").toHaveFocus()

    test "runs the callback ref cleanup on unmount"
    <| fun _ ->
        let onAttach: unit -> unit = vi.fn (fun () -> ())
        let onDetach: unit -> unit = vi.fn (fun () -> ())

        let result = RTL.render (Components.FragmentCleanup(onAttach, onDetach))
        expect(onAttach).toHaveBeenCalledTimes 1
        expect(onDetach).toHaveBeenCalledTimes 0

        result.unmount ()
        expect(onDetach).toHaveBeenCalledTimes 1
        expect(onAttach).toHaveBeenCalledTimes 1
