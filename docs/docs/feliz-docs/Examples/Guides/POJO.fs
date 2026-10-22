module Examples.Guides.POJO

// Record types might look like JavaScript objects, but Fable does not treat them as such.

/// This will be a class and NOT a plain JS object!
type POJORecord = {
    name: string
    version: int
    isAwesome: bool
}

let Pojo_RecordType: POJORecord = {
    name = "Feliz"
    version = 3
    isAwesome = true
}

// Anonymous records are transpiled to plain JS objects!

let Pojo_AnonymousRecordType = {|
    name = "Fable"
    version = 4
    isAwesome = true
    noTypeReference = true
|}

// You can also write type references for anonymous records.
type POJOAnonymousRecord = {|
    name: string
    version: int
    isAwesome: bool
|}

let Pojo_AnonymousRecordTypeWithType: POJOAnonymousRecord = {|
    name = "Fable"
    version = 4
    isAwesome = true
|}

// You can also use the [<PojoAttribute>] to create POJOs from classes.
// This allows for optional properties

[<Fable.Core.JS.PojoAttribute>]
type POJOClass(?name: string, ?version: int, ?isAwesome: bool) =
    member val name = name with get, set
    member val version = version with get, set
    member val isAwesome = isAwesome with get, set

let Pojo_Class = POJOClass(name = "Fable", isAwesome = true)

// You can also recreate the POJOAttribute by yourself using Emit and Erase

open Fable.Core

[<AllowNullLiteral>]
[<Global>] // do not generate code for this with Fable
type Options [<ParamObject; Emit("$0")>] (searchTerm: string, ?isCaseSensitive: bool) =
    member val searchTerm: string = jsNative with get, set
    member val isCaseSensitive: bool option = jsNative with get, set
