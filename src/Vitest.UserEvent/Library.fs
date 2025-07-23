namespace Vitest

open Fable.Core
open Fable.Core.JS

type PointerEventsCheckLevel =
    | Never         = 0
    | EachTarget    = 1
    | EachApiCall   = 2
    | EachTrigger   = 4

/// 
/// ```ts
/// export const defaultKeyMap: pointerKey[] = [
///   {name: 'MouseLeft', pointerType: 'mouse', button: 'primary'},
///   {name: 'MouseRight', pointerType: 'mouse', button: 'secondary'},
///   {name: 'MouseMiddle', pointerType: 'mouse', button: 'auxiliary'},
///   {name: 'TouchA', pointerType: 'touch'},
///   {name: 'TouchB', pointerType: 'touch'},
///   {name: 'TouchC', pointerType: 'touch'},
/// ]
/// ```
type PointerKey = obj

[<AllowNullLiteral>]
[<Global>]
type IUserEventOptions
    [<ParamObject; Emit("$0")>] (
        ?advanceTimers: unit -> Promise<unit>,
        ?applyAccept: bool,
        ?autoModify: bool,
        ?delay: int,
        ?document: Browser.Types.Document,
        ?keyboardMap: obj,
        ?pointerEventsCheck: PointerEventsCheckLevel,
        ?pointerMap: ResizeArray<PointerKey>,
        ?skipAutoClose: bool,
        ?skipClick: bool,
        ?skipHover: bool,
        ?writeToClipboard: bool
    ) =
    member val advanceTimers: unit -> Promise<unit> = advanceTimers |> Option.defaultValue (fun () -> JS.Constructors.Promise.resolve()) with get, set
    member val applyAccept: bool = applyAccept |> Option.defaultValue true with get, set
    member val autoModify: bool = autoModify |> Option.defaultValue false with get, set
    member val delay: int = delay |> Option.defaultValue 0 with get, set
    member val document: Browser.Types.Document = document |> Option.defaultValue Browser.Dom.document with get, set
    member val keyboardMap: obj = keyboardMap |> Option.defaultValue null with get, set
    member val pointerEventsCheck: PointerEventsCheckLevel = pointerEventsCheck |> Option.defaultValue PointerEventsCheckLevel.EachApiCall with get, set
    member val pointerMap: ResizeArray<PointerKey> = pointerMap |> Option.defaultValue (ResizeArray<PointerKey>()) with get, set
    member val skipAutoClose: bool = skipAutoClose |> Option.defaultValue false with get
    member val skipClick: bool = skipClick |> Option.defaultValue false with get, set
    member val skipHover: bool = skipHover |> Option.defaultValue false with get, set
    /// `default` when calling the APIs directly: `false`
    /// 
    /// `default` when calling the APIs on an instance from setup(): `true`
    member val writeToClipboard: bool = writeToClipboard |> Option.defaultValue false with get

[<AllowNullLiteral>]
[<Global>]
type ITypeOptions
    [<ParamObject; Emit("$0")>] (
        ?skipClick: bool,
        ?skipAutoClose: bool,
        ?initialSelectionStart: int,
        ?initialSelectionEnd: int
    ) =
    member val skipClick: bool = skipClick |> Option.defaultValue false with get, set
    member val skipAutoClose: bool = skipAutoClose |> Option.defaultValue false with get
    member val initialSelectionStart: int = initialSelectionStart |> Option.defaultValue 0 with get, set
    member val initialSelectionEnd: int = initialSelectionEnd |> Option.defaultValue 0 with get, set

// [<AllowNullLiteral>]
// [<Global>]
// type PointerActionInput
//     [<ParamObject; Emit("$0")>] (
//         ?keys: string,
//         ?target: Browser.Types.HTMLElement,
//         ?pointerName: string
//     ) =
//     member val keys: string = keys |> Option.defaultValue "" with get, set
//     member val target: Browser.Types.HTMLElement = target |> Option.defaultValue null with get, set
//     member val pointerName: string = pointerName |> Option.defaultValue "" with get, set

type PointerActionInput = obj

type DirectOptions = obj

type IUserEvent =
    abstract member setup: ?options: IUserEventOptions -> IUserEvent

    abstract member pointer: input: PointerActionInput * ?options: DirectOptions -> IUserEvent
    abstract member pointer: input: string * ?options: DirectOptions -> IUserEvent
    abstract member pointer: input: ResizeArray<PointerActionInput> * ?options: DirectOptions -> IUserEvent

    abstract member keyboard: input: string * ?options: DirectOptions -> IUserEvent

    abstract member copy: unit -> Browser.Types.DataTransfer option
    abstract member copy: options: DirectOptions -> Browser.Types.DataTransfer option
    abstract member cut: unit -> Browser.Types.DataTransfer option
    abstract member cut: options: DirectOptions -> Browser.Types.DataTransfer option
    abstract member paste: unit -> Promise<unit>
    abstract member paste: Browser.Types.DataTransfer * ?options: DirectOptions -> Promise<unit>
    abstract member paste: string * ?options: DirectOptions -> Promise<unit>

    abstract member clear: element: Browser.Types.HTMLElement -> Promise<unit>
    abstract member selectOptions: element: Browser.Types.HTMLElement * values: Browser.Types.HTMLElement -> Promise<unit>
    abstract member selectOptions: element: Browser.Types.HTMLElement * values: ResizeArray<Browser.Types.HTMLElement> -> Promise<unit>
    abstract member selectOptions: element: Browser.Types.HTMLElement * values: string -> Promise<unit>
    abstract member selectOptions: element: Browser.Types.HTMLElement * values: ResizeArray<string> -> Promise<unit>
    abstract member deselectOptions: element: Browser.Types.HTMLElement * values: Browser.Types.HTMLElement -> Promise<unit>
    abstract member deselectOptions: element: Browser.Types.HTMLElement * values: ResizeArray<Browser.Types.HTMLElement> -> Promise<unit>
    abstract member deselectOptions: element: Browser.Types.HTMLElement * values: string -> Promise<unit>
    abstract member deselectOptions: element: Browser.Types.HTMLElement * values: ResizeArray<string> -> Promise<unit>

    abstract member ``type``: element: Browser.Types.HTMLElement * text: string * ?options: ITypeOptions -> Promise<unit>

    abstract member upload: element: Browser.Types.HTMLElement * file: Browser.Types.File -> Promise<unit>
    abstract member upload: element: Browser.Types.HTMLElement * file: ResizeArray<Browser.Types.File> -> Promise<unit>

    abstract member click: element: Browser.Types.HTMLElement * ?options: DirectOptions -> Promise<unit>
    abstract member dblClick: element: Browser.Types.HTMLElement * ?options: DirectOptions -> Promise<unit>
    abstract member tripleClick: element: Browser.Types.HTMLElement * ?options: DirectOptions-> Promise<unit>
    abstract member hover: element: Browser.Types.HTMLElement * ?options: DirectOptions -> Promise<unit>
    abstract member unhover: element: Browser.Types.HTMLElement * ?options: DirectOptions -> Promise<unit>
    abstract member tab: ?options: {|shift: bool|} -> Promise<unit>

[<Erase; Mangle(false)>]
module UserEvent =

    [<ImportDefault("@testing-library/user-event")>]
    let userEvent: IUserEvent = jsNative
