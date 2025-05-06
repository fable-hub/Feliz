namespace Feliz

open System
open System.ComponentModel
open Fable.Core

[<EditorBrowsable(EditorBrowsableState.Never); Erase>]
[<RequireQualifiedAccess>]
module Helpers =
    let optDispose (disposeOption: #IDisposable option) =
        { new IDisposable with member _.Dispose () = disposeOption |> Option.iter (fun d -> d.Dispose()) }
