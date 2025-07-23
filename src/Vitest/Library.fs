namespace Vitest

open Fable.Core
open Fable.Core.JS

type TestAttachment = obj

type TestAnnotation = obj

type AbortSignal = obj

type IVitest = obj


module console =
    [<Emit("console.log($0)")>]
    let log (msg: obj) = jsNative

[<StringEnum(CaseRules.LowerFirst)>]
type TypeOf =
    | Bigint
    | Boolean
    | Function
    | Number
    | Object
    | String
    | Symbol
    | Undefined

[<Erase>]
type IAssertion<'a> =
    abstract member not: IAssertion<'a>
    abstract member toBe: expected: 'a -> unit
    abstract member toBeCloseTo: expected: float -> unit
    abstract member toBeDefined: expected: unit -> unit
    abstract member toBeUndefined: expected: unit -> unit
    abstract member toBeTruthy: expected: unit -> unit
    abstract member toBeFalsy: expected: unit -> unit
    abstract member toBeNull: expected: unit -> unit
    abstract member toBeNaN: expected: unit -> unit
    abstract member toBeOneOf: expected: ResizeArray<'a> -> unit
    abstract member toBeTypeOf: expected: TypeOf -> unit
    /// No idea how to get this to work with F# types
    abstract member toBeInstanceOf: expected: obj -> unit
    abstract member toBeGreaterThan: expected: float -> unit
    abstract member toBeGreaterThan: expected: int -> unit
    abstract member toBeGreaterThanOrEqual: expected: float -> unit
    abstract member toBeGreaterThanOrEqual: expected: int -> unit
    abstract member toBeLessThan: expected: float -> unit
    abstract member toBeLessThan: expected: int -> unit
    abstract member toBeLessThanOrEqual: expected: float -> unit
    abstract member toBeLessThanOrEqual: expected: int -> unit
    abstract member toEqual: expected: 'a -> unit
    abstract member toStrictEqual: expected: 'a -> unit
    abstract member toContain: obj -> unit
    abstract member toContainEqual: 'a -> unit
    abstract member toHaveLength: expected: int -> unit
    abstract member toHaveProperty: key: string -> unit
    abstract member toHaveProperty: key: string * value: obj -> unit
    abstract member toHaveProperty: key: ResizeArray<string> -> unit
    abstract member toHaveProperty: key: ResizeArray<string> * value: obj -> unit
    abstract member toMatch: expected: System.Text.RegularExpressions.Regex -> unit
    abstract member toMatchObject: expected: obj -> unit
    abstract member toThrowError: expected: string -> unit
    [<Emit("$0.toThrowError($1)")>]
    abstract member toThrowErrorPromise: expected: string -> Promise<unit>
    abstract member toThrowError: expected: System.Text.RegularExpressions.Regex -> unit
    [<Emit("$0.toThrowError($1)")>]
    abstract member toThrowErrorPromise: expected: System.Text.RegularExpressions.Regex -> Promise<unit>
    abstract member toMatchSnapshot: unit -> unit
    abstract member toMatchInlineSnapshot: obj -> unit
    abstract member toMatchFileSnapshot: path: string -> Promise<unit>
    abstract member toThrowErrorMatchingSnapshot: unit -> unit
    abstract member toThrowErrorMatchingSnapshot: hint: string -> unit
    abstract member toThrowErrorMatchingInlineSnapshot: snapshot: string -> unit
    abstract member toThrowErrorMatchingInlineSnapshot: snapshot: string * hint: string -> unit
    abstract member toHaveBeenCalled: unit -> unit
    abstract member toHaveBeenCalledTimes: amount: int -> unit
    [<Emit("$0.toHaveBeenCalledWith(...$1)")>]
    abstract member toHaveBeenCalledWith: arg: obj [] -> unit
    abstract member toHaveBeenCalledBefore : mock: obj -> unit
    abstract member toHaveBeenCalledBefore : mock: obj * failIfNoFirstInvocation: bool -> unit
    abstract member toHaveBeenCalledAfter : mock: obj -> unit
    abstract member toHaveBeenCalledAfter : mock: obj * failIfNoFirstInvocation: bool -> unit
    [<Emit("$0.toHaveBeenCalledExactlyOnceWith(...$1)")>]
    abstract member toHaveBeenCalledExactlyOnceWith : arg: obj [] -> unit
    [<Emit("$0.toHaveBeenLastCalledWith(...$1)")>]
    abstract member toHaveBeenLastCalledWith : arg: obj [] -> unit
    [<Emit("$0.toHaveBeenNthCalledWith($1,...$2)")>]
    abstract member toHaveBeenNthCalledWith : time: int * arg: obj [] -> unit
    abstract member toHaveReturned : unit -> unit
    abstract member toHaveReturnedTimes : amount: int -> unit
    abstract member toHaveReturnedWith : returnValue: obj -> unit
    abstract member toHaveLastReturnedWith : returnValue: obj -> unit
    abstract member toHaveNthReturnedWith : time: int * returnValue: obj -> unit
    abstract member toHaveResolved : unit -> unit
    abstract member toHaveResolvedTimes : amount: int -> unit
    abstract member toHaveResolvedWith : returnValue: obj -> unit
    abstract member toHaveLastResolvedWith : returnValue: obj -> unit
    abstract member toHaveNthResolvedWith : time: int * returnValue: obj -> unit
    abstract member toSatisfy : ('a -> bool) -> unit
    abstract member resolves : IAssertion<Promise<obj>>
    abstract member rejects : IAssertion<obj>


// [<Erase>]
// type IPromiseAssertion<'a> =
//     inherit IAssertion<Promise<'a>>
//     abstract member toBe: expected: 'a -> Promise<unit>

    //https://vitest.dev/api/expect.html#expect-assertions

// type IAssertionCollection<'a> =
//     inherit IAssertion<seq<'a>>
//     abstract member toContain: 'a -> unit
//     abstract member toContainEqual: 'a -> unit

type TestResult =
    abstract member state: string
    abstract member startTime: float
    abstract member retryCount: int
    abstract member repeatCount: int

type Task =
    abstract member id: string
    abstract member name: string
    abstract member suite: string option
    abstract member each: obj option
    abstract member fails: obj option
    abstract member ``type``: string
    abstract member file: obj
    abstract member timeout: int option
    abstract member retry: int option
    abstract member repeats: int option
    abstract member mode: string
    abstract member result: TestResult

[<Erase>]
type Constructor = 
    interface end

/// <summary>
/// Represents a type that can be used with `expect.any()`
/// 
/// There are most likely missing constructors here, feel free to open a PR to add them
/// </summary>
/// <remarks>
/// This is used to check if a value is of a specific type.
/// It is not a constructor, but a marker interface.
/// </remarks>
[<Erase; Mangle(false)>]
type any =
    [<Emit("Number")>]
    static member Number: Constructor = jsNative
    [<Emit("String")>]
    static member String: Constructor = jsNative
    [<Emit("Boolean")>]
    static member Boolean: Constructor = jsNative
    [<Emit("Function")>]
    static member Function: Constructor = jsNative
    [<Emit("Object")>]
    static member Object: Constructor = jsNative
    /// This only works for ResizeArray!
    [<Emit("Array")>]
    static member Array: Constructor = jsNative


type ExpectStatic =
    abstract member not: ExpectStatic
    abstract member soft: value: obj -> IAssertion<obj>
    abstract member anything: unit -> 'a
    abstract member any: Constructor -> 'a
    abstract member closeTo: expected: float -> float
    abstract member closeTo: expected: float * precision: int -> float
    abstract member arrayContaining: #seq<'a> -> #seq<'a>
    abstract member objectContaining: 'a -> 'b
    abstract member stringContaining: string -> string
    abstract member stringMatching: System.Text.RegularExpressions.Regex -> string
    abstract member extend: obj -> unit

type SuiteAPI =
    abstract member skip: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.skip")>]
    abstract member Skip: SuiteAPI

    abstract member only: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.only")>]
    abstract member Only: SuiteAPI
    abstract member todo: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.todo")>]
    abstract member Todo: SuiteAPI

    abstract member concurrent: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.concurrent")>]
    abstract member Concurrent: SuiteAPI

    abstract member sequential: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.sequential")>]
    abstract member Sequential: SuiteAPI

    abstract member shuffle: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.shuffle")>]
    abstract member Shuffle: SuiteAPI

type TestAPI =
    abstract member skip: name: string * fn: (unit -> unit) -> unit

    [<Emit("$0.skip")>]
    abstract member Skip: TestAPI

    abstract member only: name: string * fn: (unit -> unit) -> unit
    abstract member only: name: string * fn: (unit -> Promise<unit>) -> unit

    [<Emit("$0.only")>]
    abstract member Only: TestAPI

    abstract member todo: name: string * fn: (unit -> unit) -> unit
    abstract member todo: name: string * fn: (unit -> Promise<unit>) -> unit

    [<Emit("$0.todo")>]
    abstract member Todo: TestAPI
    abstract member fails: name: string * fn: (unit -> unit) -> unit
    abstract member fails: name: string * fn: (unit -> Promise<unit>) -> unit

    [<Emit("$0.fails")>]
    abstract member Fails: TestAPI
    abstract member concurrent: name: string * fn: (unit -> unit) -> unit
    abstract member concurrent: name: string * fn: (unit -> Promise<unit>) -> unit

    [<Emit("$0.concurrent")>]
    abstract member Concurrent: TestAPI
    abstract member sequential: name: string * fn: (unit -> unit) -> unit
    abstract member sequential: name: string * fn: (unit -> Promise<unit>) -> unit

    [<Emit("$0.sequential")>]
    abstract member Sequential: TestAPI

type TestContext =
    abstract member task: Task
    abstract member expect: value: obj -> IAssertion<obj>
    abstract member skip: unit -> unit
    abstract member skip: note: string -> unit
    abstract member skip: condition: bool -> unit
    abstract member skip: condition: bool * note: string -> unit
    abstract member annotate: message: string -> Promise<TestAnnotation>
    abstract member annotate: message: string * ``type``: string -> Promise<TestAnnotation>
    abstract member annotate: message: string * attachment: TestAttachment -> Promise<TestAnnotation>
    abstract member annotate: message: string * ``type``: string * attachment: TestAttachment -> Promise<TestAnnotation>
    abstract member signal: AbortSignal
    abstract member onTestFailed: fn: (TestContext -> unit) -> unit 
    abstract member onTestFinished: fn: (TestContext -> unit) -> unit

[<AllowNullLiteral>]
[<Global>]
type ViWaitForOptions
    [<ParamObject; Emit("$0")>]
    (?timeout: int, ?interval: int) =
    member val timeout = defaultArg timeout 5000 with get, set
    member val interval = defaultArg interval 50 with get, set

[<AllowNullLiteral>]
[<Global>]
type RuntimeConfig
    [<ParamObject; Emit("$0")>]
    (?allowOnly: bool,
    ?testTimeout: int,
    ?hookTimeout: int,
    ?clearMocks: bool,
    ?restoreMocks: bool,
    ?fakeTimers: obj,
    ?maxConcurrency: int,
    ?sequence: obj) =
    member val allowOnly = defaultArg allowOnly true with get, set
    member val testTimeout = defaultArg testTimeout 5000 with get, set
    member val hookTimeout = defaultArg hookTimeout 5000 with get, set
    member val clearMocks = defaultArg clearMocks true with get, set
    member val restoreMocks = defaultArg restoreMocks true with get, set
    member val fakeTimers = fakeTimers with get, set
    member val maxConcurrency = defaultArg maxConcurrency 5 with get, set
    member val sequence = sequence with get, set


[<AllowNullLiteral>]
[<Global>]
type TestOptions
    [<ParamObject; Emit("$0")>]
    (
        ?timeout: int,
        ?retry: int,
        ?repeats: int,
        ?skip: bool,
        ?concurrent: bool,
        ?sequential: bool,
        ?shuffle: bool,
        ?only: bool,
        ?todo: bool,
        ?fails: bool
    ) =
    member val timeout = timeout with get, set
    member val retry = retry with get, set
    member val repeats = repeats with get, set
    member val skip = skip with get, set
    member val concurrent = concurrent with get, set
    member val sequential = sequential with get, set
    member val shuffle = shuffle with get, set
    member val only = only with get, set
    member val todo = todo with get, set
    member val fails = fails with get, set

[<StringEnum(CaseRules.LowerFirst)>]
type AccessType =
    | Get
    | Set

type Vi =
    abstract member mock: path: string * options: obj -> obj
    abstract member mockObject: value: 'a -> 'a
    abstract member fn: ('a -> 'b) -> ('a -> 'b)
    abstract member spyOn: target: obj * methodName: string -> obj
    abstract member spyOn: target: obj * methodName: string * accessType: AccessType -> obj
    abstract member isMockFunction: ('a -> 'b) -> bool
    abstract member clearAllMocks: unit -> unit
    abstract member resetAllMocks: unit -> unit
    abstract member restoreAllMocks: unit -> unit
    abstract member stubEnv: name: string * value: string option -> unit
    abstract member unstubAllEnvs: unit -> unit
    abstract member stubGlobal: name: string * value: obj -> unit
    abstract member unstubAllGlobals: unit -> unit
    abstract member advanceTimersByTime: ms: int -> unit
    abstract member advanceTimersByTimeAsync: ms: int -> Promise<unit>
    abstract member advanceTimersToNextTimer: unit -> unit
    abstract member advanceTimersToNextTimerAsync: unit -> Promise<unit>
    abstract member advanceTimersToNextFrame : unit -> unit
    abstract member getTimerCount : unit -> int
    abstract member clearAllTimers : unit -> unit
    abstract member getMockedSystemTime : unit -> System.DateTime option
    abstract member getRealSystemTime : unit -> int
    abstract member runAllTicks : unit -> IVitest
    abstract member runAllTimers : unit -> IVitest
    abstract member runAllTimersAsync : unit -> Promise<IVitest>
    abstract member runOnlyPendingTimers : unit -> IVitest
    abstract member runOnlyPendingTimersAsync : unit -> Promise<IVitest>
    abstract member setSystemTime : string -> unit
    abstract member setSystemTime : System.DateTime -> unit
    abstract member setSystemTime : int -> unit
    abstract member useFakeTimers : unit -> IVitest
    abstract member useFakeTimers : obj -> IVitest
    abstract member isFakeTimers : unit -> bool
    abstract member useRealTimers : unit -> IVitest
    abstract member waitFor : fn: (unit -> Promise<'a>) -> Promise<'a>
    abstract member waitFor : fn: (unit -> Promise<'a>) * timeout: int -> Promise<'a>
    abstract member waitFor : fn: (unit -> Promise<'a>) * options: ViWaitForOptions -> Promise<'a>
    abstract member waitFor : fn: (unit -> 'a) -> Promise<'a>
    abstract member waitFor : fn: (unit -> 'a) * timeout: int -> Promise<'a>
    abstract member waitFor : fn: (unit -> 'a) * options: ViWaitForOptions -> Promise<'a>
    abstract member waitUntil : fn: (unit -> Promise<'a>) -> Promise<'a>
    abstract member waitUntil : fn: (unit -> Promise<'a>) * timeout: int -> Promise<'a>
    abstract member waitUntil : fn: (unit -> Promise<'a>) * options: ViWaitForOptions -> Promise<'a>
    abstract member waitUntil : fn: (unit -> 'a) -> Promise<'a>
    abstract member waitUntil : fn: (unit -> 'a) * timeout: int -> Promise<'a>
    abstract member waitUntil : fn: (unit -> 'a) * options: ViWaitForOptions -> Promise<'a>
    abstract member setConfig : config: RuntimeConfig -> unit
    abstract member resetConfig : unit -> unit

[<Erase>]
type Vitest =

    [<ImportMember("vitest")>]
    static member inline describe(name: string, fn: unit -> unit) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline describe(name: string, options: TestOptions, fn: unit -> unit) : unit = jsNative

    [<Import("describe", "vitest")>]
    static member Describe: SuiteAPI = jsNative

    [<Import("test", "vitest")>]
    static member Test: TestAPI = jsNative
    [<ImportMember("vitest")>]
    static member inline test(name: string, fn: unit -> unit) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline test(name: string, options: TestOptions, fn: unit -> unit) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline test(name: string, fn: TestContext -> unit) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline test(name: string, options: TestOptions, fn: TestContext -> unit) : unit = jsNative

    // [<Import("expect", "vitest")>]
    // static member expectSeq<'a>(value: seq<'a>) : IAssertionCollection<'a> = jsNative

    // [<Import("expect", "vitest")>]
    // static member expectPromise<'a>(value: Promise<'a>) : IPromiseAssertion<'a> = jsNative

    [<ImportMember("vitest")>]
    static member expect<'a>(value: 'a) : IAssertion<'a> = jsNative

    [<Import("expect", "vitest")>]
    static member Expect: ExpectStatic = jsNative

    [<ImportMember("vitest")>]
    static member vi: Vi = jsNative

    [<ImportMember("vitest")>]
    static member inline beforeEach(fn: unit -> Promise<unit>, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline beforeEach(fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline afterEach(fn: unit -> Promise<unit>, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline afterEach(fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline beforeAll(fn: unit -> Promise<unit>, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline beforeAll(fn: unit -> unit, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline afterAll(fn: unit -> Promise<unit>, ?timeout: int) : unit = jsNative

    [<ImportMember("vitest")>]
    static member inline afterAll(fn: unit -> unit, ?timeout: int) : unit = jsNative

[<AutoOpen>]
module VitestExtensions =

    type Vitest with
        
        [<ImportMember("vitest")>]
        static member inline test(name: string, fn: unit -> Promise<unit>) : unit = jsNative

        [<ImportMember("vitest")>]
        static member inline test(name: string, options: TestOptions, fn: unit -> Promise<unit>) : unit = jsNative

        [<ImportMember("vitest")>]
        static member inline test(name: string, fn: TestContext -> Promise<unit>) : unit = jsNative

        [<ImportMember("vitest")>]
        static member inline test(name: string, options: TestOptions, fn: TestContext -> Promise<unit>) : unit = jsNative

        static member inline test(name: string, fn: unit -> Async<unit>) : unit = 
            Vitest.test(name, fn >> Async.StartAsPromise)

        static member inline test(name: string, options: TestOptions, fn: unit -> Async<unit>) : unit = 
            Vitest.test(name, options, fn >> Async.StartAsPromise)

        static member inline test(name: string, fn: TestContext -> Async<unit>) : unit = 
            Vitest.test(name, fn >> Async.StartAsPromise)

        static member inline test(name: string, options: TestOptions, fn: TestContext -> Async<unit>) : unit = 
            Vitest.test(name, fn >> Async.StartAsPromise)

        static member inline test(name: string, fn: Async<unit>) : unit = 
            Vitest.test(name, fun () -> fn |> Async.StartAsPromise)

        static member inline test(name: string, options: TestOptions, fn: Async<unit>) : unit = 
            Vitest.test(name, options, fun () -> fn |> Async.StartAsPromise)
