[<AutoOpen>]
module Vitest.TestGlobals

open Vitest
open Feliz

let inline expect<'a> (value: 'a) = Vitest.expect value
let vi = Vitest.vi
let inline render (ele: ReactElement) = RTL.render ele
let userEvent = UserEvent.userEvent
let screen = RTL.screen
let inline describe (name: string) (fn: unit -> unit) = Vitest.describe(name, fn)
let inline test (name: string) (fn: unit -> unit) = Vitest.test(name, fn)
let inline testPromise (name: string) (fn: unit -> Fable.Core.JS.Promise<unit>) = Vitest.test(name, fn)
let inline ftestPromise (name: string) (fn: unit -> Fable.Core.JS.Promise<unit>) = Vitest.Test.only(name, fn)
let inline testAsync (name: string) (fn: Async<unit>) = Vitest.test(name, fn)
