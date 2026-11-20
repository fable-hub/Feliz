module Tests.ReactBindings.ReactDomApisTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Browser.Types
open Vitest

/// React's `act`: flushes renders and effects synchronously, used for roots created outside of RTL.
[<Import("act", "react")>]
let private act (callback: unit -> unit) : unit = jsNative

/// Compile-time check only, never called: overload resolution for `hydrateRoot` with `document`, an element,
/// `RootOptions` and the older untyped `obj` options.
let private hydrateRootOverloadsCompile () =
    ReactDOM.hydrateRoot (document, Html.div [], RootOptions(identifierPrefix = "app-"))
    |> ignore

    ReactDOM.hydrateRoot (document.getElementById "root", Html.div []) |> ignore

    ReactDOM.hydrateRoot (document.body, Html.div [], createObj [ "identifierPrefix" ==> "app-" ])
    |> ignore

let private dispatch (eventName: string) (element: HTMLElement) =
    element.dispatchEvent (emitJsExpr eventName "new Event($0)") |> ignore

type Components =
    [<ReactComponent>]
    static member Bomb() : ReactElement = failwith "boom"

    [<ReactComponent>]
    static member IdDisplay() =
        let id = React.useId ()
        Html.p [ prop.testId "id"; prop.text id ]

    [<ReactComponent>]
    static member FlushSyncCounter(onFlushed: string -> unit) =
        let count, setCount = React.useState 0

        Html.div [
            Html.p [ prop.testId "count"; prop.text count ]
            Html.button [
                prop.testId "increment"
                prop.onClick (fun _ ->
                    ReactDOM.flushSync (fun () -> setCount (count + 1))
                    // The DOM is already updated when flushSync returns.
                    onFlushed (document.querySelector("[data-testid='count']").textContent)
                )
                prop.text "Increment"
            ]
        ]

    [<ReactComponent>]
    static member RefWithCleanup(onAttach: Element -> unit, onDetach: unit -> unit) =
        Html.div [
            prop.testId "with-ref"
            prop.ref (fun element ->
                onAttach element
                fun () -> onDetach ()
            )
        ]

describe "ReactDOM.createRoot options"
<| fun _ ->
    test "onCaughtError receives the error and component stack"
    <| fun _ ->
        let consoleSpy = vi.spyOn (console, "error")
        consoleSpy?mockImplementation (fun () -> ()) |> ignore
        let mutable caught: (string * string) option = None
        let container = document.createElement "div"
        document.body.appendChild container |> ignore

        let root =
            ReactDOM.createRoot (
                container,
                RootOptions(onCaughtError = fun error info -> caught <- Some(error.Message, info.componentStack))
            )

        act (fun () -> root.render (React.ErrorBoundary([ Components.Bomb() ], Html.p "fallback")))

        match caught with
        | Some(message, componentStack) ->
            expect(message).toBe "boom"
            expect(componentStack).toContain "Bomb"
        | None -> failwith "onCaughtError was not called"

        act (fun () -> root.unmount ())
        container.remove ()
        consoleSpy?mockRestore () |> ignore

    test "identifierPrefix prefixes useId"
    <| fun _ ->
        let container = document.createElement "div"
        document.body.appendChild container |> ignore

        let root =
            ReactDOM.createRoot (container, RootOptions(identifierPrefix = "feliz-prefix-"))

        act (fun () -> root.render (Components.IdDisplay()))

        expect(container.textContent).toContain "feliz-prefix-"

        act (fun () -> root.unmount ())
        container.remove ()

describe "ReactDOM.flushSync"
<| fun _ ->
    testPromise "updates the DOM synchronously"
    <| fun _ -> promise {
        let onFlushed: string -> unit = vi.fn (fun _ -> ())
        RTL.render (Components.FlushSyncCounter(onFlushed)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "increment")

        expect(onFlushed).toHaveBeenCalledWith [| "1" |]
    }

    test "returns the callback's result"
    <| fun _ -> expect(ReactDOM.flushSync (fun () -> 42)).toBe 42

describe "new props"
<| fun _ ->
    test "popoverTarget uses React's camelCase name"
    <| fun _ ->
        let consoleSpy = vi.spyOn (console, "error")

        RTL.render (
            Html.div [
                Html.button [
                    prop.testId "toggle"
                    prop.popoverTarget "menu"
                    prop.text "Menu"
                ]
                Html.div [ prop.id "menu"; prop.popover.auto; prop.text "Popover" ]
            ]
        )
        |> ignore

        expect(RTL.screen.getByTestId "toggle").toHaveAttribute("popovertarget", "menu")
        expect(consoleSpy).not.toHaveBeenCalled()
        consoleSpy?mockRestore () |> ignore

    test "renders new attributes without warnings"
    <| fun _ ->
        let consoleSpy = vi.spyOn (console, "error")

        RTL.render (
            Html.div [
                Html.div [ prop.testId "inert"; prop.inert true ]
                Html.img [
                    prop.testId "image"
                    prop.fetchPriority.high
                    prop.alt ""
                ]
                Html.input [ prop.testId "input"; prop.enterKeyHint.done' ]
                Html.input [ prop.testId "input-string"; prop.enterKeyHint "search" ]
                Html.time [
                    prop.testId "time"
                    prop.suppressHydrationWarning true
                    prop.text "now"
                ]
            ]
        )
        |> ignore

        expect(RTL.screen.getByTestId "inert").toHaveAttribute "inert"
        expect(RTL.screen.getByTestId "image").toHaveAttribute("fetchpriority", "high")
        expect(RTL.screen.getByTestId "input").toHaveAttribute("enterkeyhint", "done")
        expect(RTL.screen.getByTestId "input-string").toHaveAttribute("enterkeyhint", "search")
        expect(consoleSpy).not.toHaveBeenCalled()
        consoleSpy?mockRestore () |> ignore

    test "new event handlers are wired to the right DOM events"
    <| fun _ ->
        let onToggle: Event -> unit = vi.fn (fun _ -> ())
        let onBeforeToggle: Event -> unit = vi.fn (fun _ -> ())
        let onClose: Event -> unit = vi.fn (fun _ -> ())
        let onScrollEnd: Event -> unit = vi.fn (fun _ -> ())

        RTL.render (
            Html.div [
                Html.details [
                    prop.testId "details"
                    prop.onToggle onToggle
                    prop.children [ Html.summary "Summary" ]
                ]
                Html.div [
                    prop.testId "popover"
                    prop.popover.manual
                    prop.onBeforeToggle onBeforeToggle
                ]
                Html.dialog [ prop.testId "dialog"; prop.onClose onClose ]
                Html.div [ prop.testId "scroller"; prop.onScrollEnd onScrollEnd ]
            ]
        )
        |> ignore

        dispatch "toggle" (RTL.screen.getByTestId "details")
        dispatch "beforetoggle" (RTL.screen.getByTestId "popover")
        dispatch "close" (RTL.screen.getByTestId "dialog")
        dispatch "scrollend" (RTL.screen.getByTestId "scroller")

        expect(onToggle).toHaveBeenCalledTimes 1
        expect(onBeforeToggle).toHaveBeenCalledTimes 1
        expect(onClose).toHaveBeenCalledTimes 1
        expect(onScrollEnd).toHaveBeenCalledTimes 1

    test "a callback ref's cleanup runs instead of calling the ref with null"
    <| fun _ ->
        let onAttach: Element -> unit = vi.fn (fun _ -> ())
        let onDetach: unit -> unit = vi.fn (fun () -> ())

        let result = RTL.render (Components.RefWithCleanup(onAttach, onDetach))
        expect(onAttach).toHaveBeenCalledWith [| RTL.screen.getByTestId "with-ref" |]
        expect(onDetach).toHaveBeenCalledTimes 0

        result.unmount ()
        expect(onDetach).toHaveBeenCalledTimes 1
        expect(onAttach).toHaveBeenCalledTimes 1

    test "new elements render with the right tags"
    <| fun _ ->
        let result =
            RTL.render (
                Html.div [
                    Html.hgroup [ Html.h1 "Title"; Html.p "Tagline" ]
                    Html.search [ Html.input [ prop.type'.search ] ]
                    Html.slot [ prop.name "named-slot" ]
                ]
            )

        expect(result.container.querySelector "hgroup" |> isNull).toBe false
        expect(result.container.querySelector "search" |> isNull).toBe false
        expect(result.container.querySelector "slot" |> isNull).toBe false
