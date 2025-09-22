module Feliz.UseElmish

open Fable.Core
open Elmish

module private Util =
    type UseSyncExternalStoreSubscribe = delegate of (unit -> unit) -> (unit -> unit)

    [<ImportMember("react")>]
    let useSyncExternalStore(subscribe: UseSyncExternalStoreSubscribe, getSnapshot: unit -> 'Model, getServerSnapshot: (unit -> 'Model) option): 'Model = jsNative

    [<ImportMember("react")>]
    let useState(init: unit -> 'State): 'State * ('State -> unit) = jsNative

    [<ImportMember "react">]
    let useEffect(effect: unit -> unit, dependencies: obj array) : unit = jsNative

    [<Emit "setTimeout($0)">]
    let setTimeout(callback: unit -> unit) : unit = jsNative

    type ElmishState<'Arg, 'Model, 'Msg when 'Arg : equality>(program: unit -> Program<'Arg, 'Model, 'Msg, unit>, arg: 'Arg, dependencies: obj[] option) =
        // let guid = System.Guid.NewGuid()
        // do printfn "Creating %O..." guid

        // React will run the subscribe function when the component is mounted and after each hot reload
        // However we need to store the initial model here for two reasons:
        // - It looks like useSyncExternalStore returns the state before running subscribe
        // - We can restore the model after a hot reload
        let program = program()
        // Keep track of messages are that dispach from the initial No-Op dispatch
        // And dispatch them after the Elmish program has subscribed using the "real" dispatch
        let queuedMessages = ResizeArray<'Msg>()
        
        // To assure that dispatch function is stable (for example for memo).
        // We need to store external reference to final dispatch function assuring that initial version
        // will forward to it at some point.
        let mutable finalDispatch = None
        
        let mutable state, cmd =
            let mutable model, cmd = Program.init program arg
            // Initial dispatch is a No-Op before the Elmish program has subscribed
            // So here we store the messages and dispatch them after the Elmish program has subscribed
            let initialDispatch (msg: 'Msg) =
              match finalDispatch with
              | Some dispatch -> dispatch msg
              | None -> queuedMessages.Add msg
            let subscribed = false
            (model, initialDispatch, subscribed, queuedMessages), cmd

        let subscribe = UseSyncExternalStoreSubscribe(fun callback ->
            // printfn "Subscribing %O..." guid
            let mutable dispose = false
            // needsDispose is used to determine whether the model inside state needs to be disposed of when the subscription is terminated.
            // If the model does implement System.IDisposable, we set needsDispose to true, which ensures that the Dispose() method is called when the subscription is terminated.
            // If the model doesn't implement System.IDisposable or the subscription isn't being terminated, we use the provided terminate function to handle the model.
            // Added because, in strict mode, subscribing and unsubscribing can happen more than once
            let needsDispose =
                let (model, _, _, _) = state
                match box model with
                | :? System.IDisposable -> true
                | _ -> false

            let mapInit _init _arg =
                let cmd' = cmd
                // Don't run the original commands after hot reload
                cmd <- Cmd.none
                let (model, _, _, _) = state
                model, cmd'

            let mapTermination (predicate, terminate) =
                (fun msg -> predicate msg || (needsDispose && dispose)),
                (fun model ->
                    // printfn "Terminating %O..." guid
                    match box model with
                    // Before Elmish 4 it was allowed to have disposable states as a hack for termination
                    | :? System.IDisposable as disp -> disp.Dispose()
                    | _ -> terminate model)

            // Because, in strict mode, subscribing and unsubscribing can happen more than once, Elmish's model that's
            // passed in as a parameter could potentially be outdated. To ensure that the latest version of the model
            // is always used, we retrieve it from state and pass it as latestModel to the update function
            let mapUpdate update msg model =
                let (latestModel, _, _, _) = state
                update msg latestModel

            // Restart the program after each hot reload to get the proper dispatch reference
            program
            |> Program.map mapInit mapUpdate id id id mapTermination
            |> Program.withSetState (fun model dispatch ->
                let (oldModel, initialDispatch, _, _) = state
                let subscribed = true
                finalDispatch <- Some dispatch
                state <- model, initialDispatch, subscribed, queuedMessages
                // Skip re-renders if model hasn't changed
                if not(obj.ReferenceEquals(model, oldModel)) then
                    callback())
            |> Program.runWith arg

            (fun () ->
                // printfn "Unsubscribing %O..." guid
                dispose <- true))

        member _.State = state
        member _.Subscribe = subscribe
        member _.IsOutdated(arg', dependencies') = arg <> arg' || dependencies <> dependencies'

open Util

[<Erase>]
type React =
    static member useElmish(program: unit -> Program<'Arg, 'Model, 'Msg, unit>, arg: 'Arg, ?dependencies: obj array): 'Model * ('Msg -> unit) =
        let state, setState = useState(fun () -> ElmishState(program, arg, dependencies))
        if state.IsOutdated(arg, dependencies) then
            ElmishState(program, arg, dependencies) |> setState
        let finalState, dispatch, subscribed, queuedMessages = useSyncExternalStore(state.Subscribe, (fun () -> state.State), None)
        // Run any queued messages that were dispatched before the Elmish program finished subscribing
        useEffect((fun () ->
            if subscribed && queuedMessages.Count > 0 then
                for msg in queuedMessages do
                    setTimeout(fun () -> dispatch msg)
                queuedMessages.Clear()
        ), [| subscribed; queuedMessages |])
        finalState, dispatch

    static member inline useElmish(program: unit -> Program<unit, 'Model, 'Msg, unit>, ?dependencies: obj array) =
        React.useElmish(program, (), ?dependencies=dependencies)

    static member inline useElmish(init: 'Arg -> 'Model * Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>, arg: 'Arg, ?dependencies: obj array) =
        React.useElmish((fun () -> Program.mkProgram init update (fun _ _ -> ())), arg, ?dependencies=dependencies)

    static member inline useElmish(init: unit -> 'Model * Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>, ?dependencies: obj array) =
        React.useElmish((fun () -> Program.mkProgram init update (fun _ _ -> ())), ?dependencies=dependencies)

    static member inline useElmish(init: 'Model * Cmd<'Msg>, update: 'Msg -> 'Model -> 'Model * Cmd<'Msg>, ?dependencies: obj array) =
        React.useElmish((fun () -> Program.mkProgram (fun () -> init) update (fun _ _ -> ())), ?dependencies=dependencies)
