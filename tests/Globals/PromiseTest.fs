module Vitest.PromiseTest

open System
open Fable.Core

/// Deterministic promise test helpers used by lifecycle/isolation tests.
/// These helpers avoid embedding test core logic inside per-test Emit snippets.
/// Promise value that can be resolved/rejected manually by a test.
type Deferred<'T> = {
    /// Promise consumed by code under test.
    promise: JS.Promise<'T>
    /// Resolve with a successful value.
    resolve: 'T -> unit
    /// Reject with any object reason; it will be normalized to exn.
    reject: obj -> unit
    /// Reject with a concrete exception.
    rejectExn: exn -> unit
}

let private toExn (reason: obj) : exn =
    match reason with
    | :? exn as ex -> ex
    | null -> Exception("Promise rejected with null reason")
    | _ -> Exception(string reason)

/// Use case: create a pending promise and settle it externally at a controlled time.
let deferred<'T> () : Deferred<'T> =
    let mutable settled = false
    let mutable resolveRef: ('T -> unit) option = None
    let mutable rejectRef: (exn -> unit) option = None

    let promise =
        Promise.create (fun resolve reject ->
            resolveRef <- Some resolve
            rejectRef <- Some reject
        )

    let settleOnce (action: unit -> unit) =
        if not settled then
            settled <- true
            action ()

    let resolve (value: 'T) =
        settleOnce (fun () ->
            match resolveRef with
            | Some resolve -> resolve value
            | None -> failwith "Deferred.resolve called before promise initializer ran"
        )

    let rejectExn (error: exn) =
        settleOnce (fun () ->
            match rejectRef with
            | Some reject -> reject error
            | None -> failwith "Deferred.rejectExn called before promise initializer ran"
        )

    let reject (reason: obj) = rejectExn (toExn reason)

    {
        promise = promise
        resolve = resolve
        reject = reject
        rejectExn = rejectExn
    }

/// Use case: asynchronous wait points in tests without local Emit wrappers.
let delay (milliseconds: int) : JS.Promise<unit> = Promise.sleep milliseconds

/// Use case: immediate successful promise in test setup.
let resolved<'T> (value: 'T) : JS.Promise<'T> = Promise.lift value

/// Use case: immediate failed promise in test setup.
let rejected<'T> (reason: obj) : JS.Promise<'T> = Promise.reject (toExn reason)
