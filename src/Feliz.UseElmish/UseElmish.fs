module Feliz.UseElmish

open System
open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Feliz

// This module must be public, as the helper function is used by inline overloads of `useElmish`.
// Otherwise we will run into `TypeError: (0 , Util_programWithCustomErrorHandler) is not a function` in the generated JavaScript when using those overloads.
module UseElmishHelper =

    let programWithCustomErrorHandler
        (onError: option<(string * exn) -> unit>)
        (program: Program<'Arg, 'Model, 'Msg, unit>)
        =
        match onError with
        | Some onError -> Program.withErrorHandler onError program
        | None -> program


module private Util =

    /// This must stay inline. As the module is private, the

    [<Emit "setTimeout($0)">]
    let setTimeout (callback: unit -> unit) : unit = jsNative

    type ElmishState<'Arg, 'Model, 'Msg when 'Arg: equality>
        (programFactory: unit -> Program<'Arg, 'Model, 'Msg, unit>, arg: 'Arg, dependencies: obj[] option) =

        let program = programFactory ()
        let queuedMessages = ResizeArray<'Msg>()
        let trackedSubscriptionDisposables = ResizeArray<IDisposable>()

        // To assure that dispatch function is stable (for example for memo).
        // We need to store external reference to final dispatch function assuring that initial version
        // will forward to it at some point.
        let mutable finalDispatch = None
        let mutable lastDisposedModel: obj option = None
        let mutable unmountCleanupAlreadyRan = false
        let onError = Program.onError program

        let reportDisposeError (context: string) (ex: exn) = onError (context, ex)

        let tryGetUnionFields (value: obj) : obj[] option =
#if FABLE_COMPILER
            if isNull value then
                None
            else
                let fields: obj[] = value?fields

                if isNull fields then None else Some fields
#else
            None
#endif

        let hasDisposableValue (value: obj) =
            let isDisposable (candidate: obj) =
                match candidate with
                | :? IDisposable -> true
                | _ -> false

            isDisposable value
            || (
                match tryGetUnionFields value with
                | Some fields -> fields |> Array.exists isDisposable
                | None -> false
            )

        let disposeDisposableValues (value: obj) =
            let mutable disposed = false

            let tryDispose (candidate: obj) =
                match candidate with
                | :? IDisposable as disposable ->
                    disposed <- true

                    try
                        disposable.Dispose()
                    with ex ->
                        reportDisposeError "Unable to dispose model state value." ex
                | _ -> ()

            tryDispose value

            match tryGetUnionFields value with
            | Some fields ->
                for field in fields do
                    tryDispose field
            | None -> ()

            disposed

        // Keep track of messages that are dispatched from the initial No-Op dispatch
        // and dispatch them after the Elmish program has subscribed using the real dispatch.
        let mutable state, cmd =
            let model, cmd = Program.init program arg

            let initialDispatch (msg: 'Msg) =
                match finalDispatch with
                | Some dispatch -> dispatch msg
                | None -> queuedMessages.Add msg

            let subscribed = false
            (model, initialDispatch, subscribed, queuedMessages), cmd

        let removeTrackedDisposable (disposable: IDisposable) =
            trackedSubscriptionDisposables.Remove(disposable) |> ignore

        let trackSubscriptionDisposable (subscriptionDisposable: IDisposable) =
            let mutable disposed = false
            let mutable trackedDisposableRef: IDisposable option = None

            let trackedDisposable =
                { new IDisposable with
                    member _.Dispose() =
                        if not disposed then
                            disposed <- true

                            match trackedDisposableRef with
                            | Some trackedDisposable -> removeTrackedDisposable trackedDisposable
                            | None -> ()

                            try
                                subscriptionDisposable.Dispose()
                            with ex ->
                                reportDisposeError "Unable to dispose subscription." ex
                }

            trackedDisposableRef <- Some trackedDisposable
            trackedSubscriptionDisposables.Add trackedDisposable
            trackedDisposable

        let disposeTrackedSubscriptions () =
            if trackedSubscriptionDisposables.Count > 0 then
                let activeDisposables = trackedSubscriptionDisposables.ToArray()
                trackedSubscriptionDisposables.Clear()

                for disposable in activeDisposables do
                    disposable.Dispose()

        let disposeLatestModel () =
            let model, _, _, _ = state
            let boxedModel = box model

            let shouldDispose =
                match lastDisposedModel with
                | Some previous when obj.ReferenceEquals(previous, boxedModel) -> false
                | _ -> true

            if shouldDispose && disposeDisposableValues boxedModel then
                lastDisposedModel <- Some boxedModel

        let mapSubscription (subscribe: 'Model -> Sub<'Msg>) : 'Model -> Sub<'Msg> =
            fun model ->
                subscribe model
                |> List.map (fun (subscriptionId, subscription) ->
                    subscriptionId,
                    (fun dispatch ->
                        let subscriptionDisposable = subscription dispatch
                        trackSubscriptionDisposable subscriptionDisposable
                    )
                )

        let subscribe =
            UseSyncExternalStoreSubscribe(fun callback ->
                let mutable dispose = false

                let mapInit _init _arg =
                    let model', cmd' =
                        if unmountCleanupAlreadyRan then
                            // Re-run init to get a fresh model and cmd, avoiding ghost-subscribe
                            // state pollution (e.g. Cmd.ofEffect in init firing during StrictMode's
                            // extra subscribe cycle mutating ElmishState.state before real subscribe).
                            _init _arg
                        else
                            let model, _, _, _ = state
                            model, cmd

                    // Don't run the original commands after hot reload
                    cmd <- Cmd.none
                    model', cmd'

                let mapTermination (predicate, terminate) =
                    (fun msg ->
                        let model, _, _, _ = state
                        let mustDispose = dispose && hasDisposableValue (box model)
                        predicate msg || mustDispose
                    ),
                    (fun model ->
                        match box model with
                        // Before Elmish 4 it was allowed to have disposable states as a hack for termination.
                        // Use disposeLatestModel() so the lastDisposedModel guard prevents double-disposal
                        // when DisposeOnUnmount already ran (e.g. delayed dispatch arriving after unmount).
                        | :? IDisposable -> disposeLatestModel ()
                        | _ -> terminate model
                    )

                // Because, in strict mode, subscribing and unsubscribing can happen more than once, Elmish's model that's
                // passed in as a parameter could potentially be outdated. To ensure that the latest version of the model
                // is always used, we retrieve it from state and pass it as latestModel to the update function.
                let mapUpdate update msg _model =
                    let latestModel, _, _, _ = state

                    if dispose then
                        latestModel, Cmd.none
                    else
                        update msg latestModel

                // Restart the program after each hot reload to get the proper dispatch reference
                program
                |> Program.map mapInit mapUpdate id id mapSubscription mapTermination
                |> Program.withSetState (fun model dispatch ->
                    let oldModel, initialDispatch, _, _ = state
                    let subscribed = true
                    finalDispatch <- Some dispatch
                    state <- model, initialDispatch, subscribed, queuedMessages

                    // Skip re-renders if model hasn't changed
                    if not (obj.ReferenceEquals(model, oldModel)) then
                        callback ()
                )
                |> Program.runWith arg

                (fun () ->
                    dispose <- true
                    disposeTrackedSubscriptions ()
                )
            )

        member _.State = state
        member _.Subscribe = subscribe

        member _.BeginMountCycle() = unmountCleanupAlreadyRan <- false

        member _.DisposeOnUnmount() =
            if not unmountCleanupAlreadyRan then
                unmountCleanupAlreadyRan <- true
                disposeTrackedSubscriptions ()
                disposeLatestModel ()

        member _.IsOutdated(arg', dependencies') =
            arg <> arg' || dependencies <> dependencies'

open Util

[<Erase>]
type React =
    static member useElmish
        (program: unit -> Program<'Arg, 'Model, 'Msg, unit>, arg: 'Arg, ?dependencies: obj array)
        : 'Model * ('Msg -> unit) =

        let state, setState =
            React.useState (fun () -> ElmishState(program, arg, dependencies))

        if state.IsOutdated(arg, dependencies) then
            ElmishState(program, arg, dependencies) |> setState

        let finalState, dispatch, subscribed, queuedMessages =
            React.useSyncExternalStore (
                state.Subscribe,
                UseSyncExternalStoreSnapshot(fun () -> state.State),
                UseSyncExternalStoreSnapshot(fun () -> state.State)
            )

        React.useEffect (
            (fun () ->
                state.BeginMountCycle()

                fun () -> state.DisposeOnUnmount()
            ),
            [| box state |]
        )

        // Run any queued messages that were dispatched before the Elmish program finished subscribing.
        React.useEffect (
            (fun () ->
                if subscribed && queuedMessages.Count > 0 then
                    for msg in queuedMessages do
                        setTimeout (fun () -> dispatch msg)

                    queuedMessages.Clear()
            ),
            [| box subscribed; box queuedMessages |]
        )

        finalState, dispatch

    static member inline useElmish(program: unit -> Program<unit, 'Model, 'Msg, unit>, ?dependencies: obj array) =
        React.useElmish (program, (), ?dependencies = dependencies)

    static member inline useElmish
        (
            init: 'Arg -> 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            arg: 'Arg,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram init update (fun _ _ -> ())
                |> fun x ->
                    match onError with
                    | Some onError -> Program.withErrorHandler onError x
                    | None -> x
            ),
            arg,
            ?dependencies = dependencies
        )

    static member inline useElmish
        (
            init: unit -> 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram init update (fun _ _ -> ())
                |> UseElmishHelper.programWithCustomErrorHandler onError
            ),
            ?dependencies = dependencies
        )

    static member inline useElmish
        (
            init: 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram (fun () -> init) update (fun _ _ -> ())
                |> UseElmishHelper.programWithCustomErrorHandler onError
            ),
            ?dependencies = dependencies
        )

    static member inline useElmish
        (
            init: 'Arg -> 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            subscribe: 'Model -> Sub<'Msg>,
            arg: 'Arg,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram init update (fun _ _ -> ())
                |> Program.withSubscription subscribe
                |> UseElmishHelper.programWithCustomErrorHandler onError
            ),
            arg,
            ?dependencies = dependencies
        )

    static member inline useElmish
        (
            init: unit -> 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            subscribe: 'Model -> Sub<'Msg>,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram init update (fun _ _ -> ())
                |> Program.withSubscription subscribe
                |> UseElmishHelper.programWithCustomErrorHandler onError
            ),
            ?dependencies = dependencies
        )

    static member inline useElmish
        (
            init: 'Model * Cmd<'Msg>,
            update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>,
            subscribe: 'Model -> Sub<'Msg>,
            ?dependencies: obj array,
            ?onError: (string * exn) -> unit
        ) =
        React.useElmish (
            (fun () ->
                Program.mkProgram (fun () -> init) update (fun _ _ -> ())
                |> Program.withSubscription subscribe
                |> UseElmishHelper.programWithCustomErrorHandler onError
            ),
            ?dependencies = dependencies
        )
