namespace Browser.Types

open Browser.Types
open Fable.Core

type PromiseRejectionEvent =
    inherit Event

    abstract promise: JS.Promise<obj>
    abstract reason: obj