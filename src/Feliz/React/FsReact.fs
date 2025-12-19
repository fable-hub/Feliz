namespace Feliz

open Fable.Core
open Fable.Core.JsInterop
open System

[<Erase>]
type FsReact =

    /// Creates a disposable instance by providing the implementation of the dispose member.
    static member inline createDisposable(dispose: unit -> unit) = { new IDisposable with member _.Dispose() = dispose() }

            /// Creates a disposable instance by merging multiple IDisposables.
    static member inline createDisposable([<ParamArray>] disposables: #IDisposable []) =
        FsReact.createDisposable(fun () ->
            disposables
            |> Array.iter (fun d -> d.Dispose())
        )
    /// Creates a disposable instance by merging multiple IDisposable options.
    static member inline createDisposable([<ParamArray>] disposables: #IDisposable option []) =
        FsReact.createDisposable(fun () ->
            disposables
            |> Array.iter (Option.iter (fun d -> d.Dispose()))
        )
    /// Creates a disposable instance by merging multiple IDisposable refs.
    static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable> []) =
        FsReact.createDisposable(fun () ->
            disposables
            |> Array.iter (fun d -> d.current.Dispose())
        )

    /// Creates a disposable instance by merging multiple IDisposable refs.
    static member inline createDisposable([<ParamArray>] disposables: IRefValue<#IDisposable option> []) =
        FsReact.createDisposable(fun () ->
            disposables
            |> Array.iter (fun d -> d.current |> Option.iter (fun d -> d.Dispose()))
        )

    [<Hook>]
    static member inline useDisposable(dispose: unit -> unit): IDisposable = 
        React.useMemo(
            (fun () -> FsReact.createDisposable dispose),
            [| box dispose |] 
        )

    /// <summary>
    /// Creates a CancellationToken that is cancelled when a component is unmounted.
    /// </summary>
    [<Hook>]
    static member inline useCancellationToken() = 
        let cts = React.useRef(new System.Threading.CancellationTokenSource())
        let token = React.useRef(cts.current.Token)

        React.useEffectOnce(
            fun () ->
                FsReact.createDisposable(fun () ->
                    cts.current.Cancel()
                    cts.current.Dispose()
                )
        )
        token
