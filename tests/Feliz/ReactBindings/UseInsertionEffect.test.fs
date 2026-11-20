module Tests.ReactBindings.UseInsertionEffectTests

open Feliz
open Vitest

type Components =
    [<ReactComponent>]
    static member InsertionEffectWithCleanup(setup: unit -> unit, cleanup: unit -> unit) =
        React.useInsertionEffect (
            (fun () ->
                setup ()
                fun () -> cleanup ()
            ),
            [||]
        )

        Html.div "insertion effect"

    [<ReactComponent>]
    static member InsertionEffectWithEmptyCleanup(setup: unit -> unit) =
        React.useInsertionEffect ((fun () -> setup ()), [||])
        React.useInsertionEffect ((fun () -> (fun () -> ())), [||])
        Html.div "insertion effect"

    [<ReactComponent>]
    static member InsertionEffectWithDisposable(setup: unit -> unit, cleanup: unit -> unit) =
        React.useInsertionEffect (
            (fun () ->
                setup ()
                FsReact.createDisposable cleanup
            ),
            [||]
        )

        Html.div "insertion effect"

describe "useInsertionEffect"
<| fun _ ->
    test "runs setup on mount and cleanup on unmount"
    <| fun _ ->
        let setup: unit -> unit = vi.fn (fun () -> ())
        let cleanup: unit -> unit = vi.fn (fun () -> ())

        let result = RTL.render (Components.InsertionEffectWithCleanup(setup, cleanup))
        expect(setup).toHaveBeenCalledTimes 1
        expect(cleanup).toHaveBeenCalledTimes 0

        result.unmount ()
        expect(cleanup).toHaveBeenCalledTimes 1

    test "accepts an effect without cleanup and an empty cleanup"
    <| fun _ ->
        let setup: unit -> unit = vi.fn (fun () -> ())

        let result = RTL.render (Components.InsertionEffectWithEmptyCleanup(setup))
        expect(setup).toHaveBeenCalledTimes 1

        result.unmount ()

    test "disposes an IDisposable on unmount"
    <| fun _ ->
        let setup: unit -> unit = vi.fn (fun () -> ())
        let cleanup: unit -> unit = vi.fn (fun () -> ())

        let result = RTL.render (Components.InsertionEffectWithDisposable(setup, cleanup))

        expect(setup).toHaveBeenCalledTimes 1

        result.unmount ()
        expect(cleanup).toHaveBeenCalledTimes 1
