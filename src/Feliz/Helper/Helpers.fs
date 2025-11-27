namespace Feliz

open System
open System.ComponentModel
open Fable.Core
open Fable.Core.JsInterop

[<EditorBrowsable(EditorBrowsableState.Never); Erase>]
[<RequireQualifiedAccess>]
module Helpers =
    let optDispose (disposeOption: #IDisposable option) =
        { new IDisposable with member _.Dispose () = disposeOption |> Option.iter (fun d -> d.Dispose()) }

[<RequireQualifiedAccess>]
module Interop =

    open Fable.Core
    open Fable.React

    [<Emit("($0 !== null && typeof $0 === \"object\" && !Array.isArray($0))")>]
    let isObject (value: obj) = jsNative

    let setKeyOnObj (withKey: ('props -> string) option) props =
        match withKey with
        | Some f ->
            props?key <- f props
            props
        | None -> props

