namespace Vitest

open Feliz
open Fable.Core
open Fable.Core.JS

// type Event(name: string, ?options: obj) =
//     member val name: string = name
//     member val options: obj = options

// type MouseEvent(name: string, ?options: obj) =
//     inherit Event(name, ?options = options)


type QueryFn = string -> Browser.Types.HTMLElement option -> bool

[<Erase>]
type TextMatch =
    | Text of string
    | Regex of System.Text.RegularExpressions.Regex
    | Fn of QueryFn

type ILevel = obj

[<AllowNullLiteral>]
[<Global>]
type ByMinTextOptions
    [<ParamObject; Emit("$0")>] (
        ?exact: bool,
        ?normalizer: string -> string
    ) =
    member val exact: bool = exact |> Option.defaultValue true with get, set
    member val normalizer = normalizer |> Option.defaultValue (fun s -> s) with get, set

[<AllowNullLiteral>]
[<Global>]
type ByLabelTextOptions
    [<ParamObject; Emit("$0")>] (
        ?selector: string,
        ?exact: bool,
        ?normalizer: string -> string
    ) =
    member val selector: string = selector |> Option.defaultValue "*" with get, set
    member val exact: bool = exact |> Option.defaultValue true with get, set
    member val normalizer = normalizer |> Option.defaultValue (fun s -> s) with get, set

[<AllowNullLiteral>]
[<Global>]
type ByTextOptions
    [<ParamObject; Emit("$0")>] (
        ?selector: string,
        ?exact: bool,
        ?ignore: U2<bool, string>,
        ?normalizer: string -> string
    ) =
    member val selector: string = selector |> Option.defaultValue "*" with get, set
    member val exact: bool = exact |> Option.defaultValue true with get, set
    member val ignore: U2<bool, string> = ignore |> Option.defaultValue (U2.Case2 "script, style") with get, set
    member val normalizer = normalizer |> Option.defaultValue (fun s -> s) with get, set


[<AllowNullLiteral>]
[<Global>]
type ByRoleOptions
    [<ParamObject; Emit("$0")>] (
        ?hidden: bool,
        ?name: TextMatch,
        ?description: TextMatch,
        ?selected: bool,
        ?busy: bool,
        ?``checked``: bool,
        ?pressed: bool,
        ?suggest: bool,
        ?current: U2<bool, string>,
        ?expanded: bool,
        ?queryFallbacks: bool,
        ?level: int,
        ?value: ILevel
    ) =

    member val hidden: bool = hidden |> Option.defaultValue false with get, set
    member val name: TextMatch = name |> Option.defaultValue (Text "") with get, set
    member val description: TextMatch = description |> Option.defaultValue (Text "") with get
    member val selected: bool = selected |> Option.defaultValue false with get, set
    member val busy: bool = busy |> Option.defaultValue false with get, set
    member val ``checked``: bool = ``checked`` |> Option.defaultValue false with get, set
    member val pressed: bool = pressed |> Option.defaultValue false with get, set
    member val suggest: bool = suggest |> Option.defaultValue false with get, set
    member val current: U2<bool, string> = current |> Option.defaultValue (U2.Case1 false) with get, set
    member val expanded: bool = expanded |> Option.defaultValue false with get, set
    member val queryFallbacks: bool = queryFallbacks |> Option.defaultValue false with get, set
    member val level: int = level |> Option.defaultValue 0 with get, set
    member val value: ILevel = value |> Option.defaultValue null with get, set

/// If you are motivated to extend the interface, please do so and open a PR :)
type IFireEvent =

    abstract member change: node: Browser.Types.HTMLElement * ?eventProperties: obj -> unit
    abstract member click: node: Browser.Types.HTMLElement * ?eventProperties: obj -> unit
    [<Emit("$0[$1]($2, $3)")>]
    abstract member custom: eventName: string * node: Browser.Types.HTMLElement * ?eventProperties: obj -> unit


type IQueryable =

    abstract member getByRole: text: string * ?options: ByRoleOptions -> Browser.Types.HTMLElement
    abstract member findByRole: text: string * ?options: ByRoleOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByRole: text: string * ?options: ByRoleOptions -> Browser.Types.HTMLElement option
    abstract member getAllByRole: text: string * ?options: ByRoleOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByRole: text: string * ?options: ByRoleOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByRole: text: string * ?options: ByRoleOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByLabelText: text: string * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement
    abstract member getByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement
    abstract member getByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement
    abstract member findByLabelText: text: string * ?options: ByLabelTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByLabelText: text: string * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByLabelText: text: string * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByLabelText: text: string * ?options: ByLabelTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByLabelText: text: string * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByLabelText: regex: System.Text.RegularExpressions.Regex * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByLabelText: fn: QueryFn * ?options: ByLabelTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByPlaceholderText: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member findByPlaceholderText: text: string * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByPlaceholderText: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByPlaceholderText: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByPlaceholderText: text: string * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByPlaceholderText: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByPlaceholderText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByPlaceholderText: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByText: text: string * ?options: ByTextOptions -> Browser.Types.HTMLElement
    abstract member getByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> Browser.Types.HTMLElement
    abstract member getByText: fn: QueryFn * ?options: ByTextOptions -> Browser.Types.HTMLElement
    abstract member findByText: text: string * ?options: ByTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByText: fn: QueryFn * ?options: ByTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByText: text: string * ?options: ByTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByText: fn: QueryFn * ?options: ByTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByText: text: string * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByText: fn: QueryFn * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByText: text: string * ?options: ByTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByText: fn: QueryFn * ?options: ByTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByText: text: string * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByText: regex: System.Text.RegularExpressions.Regex * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByText: fn: QueryFn * ?options: ByTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByDisplayValue: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member findByDisplayValue: text: string * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByDisplayValue: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByDisplayValue: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByDisplayValue: text: string * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByDisplayValue: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByDisplayValue: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByDisplayValue: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByAltText: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByAltText: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member findByAltText: text: string * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByAltText: fn: QueryFn * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByAltText: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByAltText: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByAltText: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByAltText: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByAltText: text: string * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByAltText: fn: QueryFn * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByAltText: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByAltText: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByAltText: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByTitle: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByTitle: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member findByTitle: text: string * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByTitle: fn: QueryFn * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByTitle: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByTitle: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByTitle: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByTitle: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByTitle: text: string * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByTitle: fn: QueryFn * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByTitle: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByTitle: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByTitle: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>

    abstract member getByTestId: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member getByTestId: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement
    abstract member findByTestId: text: string * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member findByTestId: fn: QueryFn * ?options: ByMinTextOptions -> Promise<Browser.Types.HTMLElement>
    abstract member queryByTestId: text: string * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member queryByTestId: fn: QueryFn * ?options: ByMinTextOptions -> Browser.Types.HTMLElement option
    abstract member getAllByTestId: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member getAllByTestId: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member findAllByTestId: text: string * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member findAllByTestId: fn: QueryFn * ?options: ByMinTextOptions -> Promise<ResizeArray<Browser.Types.HTMLElement>>
    abstract member queryAllByTestId: text: string * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByTestId: regex: System.Text.RegularExpressions.Regex * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>
    abstract member queryAllByTestId: fn: QueryFn * ?options: ByMinTextOptions -> ResizeArray<Browser.Types.HTMLElement>

[<AllowNullLiteral>]
[<Global>]
type RenderOptions 
    [<ParamObjectAttribute; EmitAttribute("$0")>] (
        ?container: Browser.Types.HTMLElement,
        ?baseElement: Browser.Types.HTMLElement,
        ?hydrate: bool,
        ?legacyRoot: bool,
        ?onCaughtError: exn -> unit,
        ?onRecoverableError: exn -> unit,
        ?wrapper: ReactElement,
        ?queries: obj,
        ?reactStrictMode: bool
    ) =
    member val container: Browser.Types.HTMLElement = container |> Option.defaultValue null with get, set
    member val baseElement: Browser.Types.HTMLElement = baseElement |> Option.defaultValue null with get, set
    member val hydrate: bool = hydrate |> Option.defaultValue false with get , set
    member val legacyRoot: bool = legacyRoot |> Option.defaultValue true with get, set
    member val onCaughtError: exn -> unit = onCaughtError |> Option.defaultValue (fun _ -> ()) with get, set
    member val onRecoverableError: exn -> unit = onRecoverableError |> Option.defaultValue (fun _ -> ()) with get, set
    member val wrapper: ReactElement = wrapper |> Option.defaultValue null with get, set
    member val queries: obj = queries |> Option.defaultValue null with get, set
    member val reactStrictMode: bool = reactStrictMode |> Option.defaultValue false with get, set


type RenderResult =
    inherit IQueryable

    abstract member container: Browser.Types.HTMLElement
    abstract member baseElement: Browser.Types.HTMLElement
    abstract member debug: ?baseElement: Browser.Types.HTMLElement * maxLength: int * ?options: obj -> string
    abstract member unmount: unit -> unit
    abstract member rerender: reactElement: ReactElement -> unit
    abstract member asFragment: unit -> Browser.Types.DocumentFragment

[<AllowNullLiteral>]
[<Global>]
type RTLWaitForOptions
    [<ParamObject; Emit("$0")>] (
        ?container: Browser.Types.HTMLElement,
        ?timeout: int,
        ?interval: int,
        ?onTimeout: obj -> obj,
        ?mutationObserverOptions: obj
    ) =
        member val container: Browser.Types.HTMLElement = container |> Option.defaultValue null with get, set
        member val timeout: int = timeout |> Option.defaultValue 1000 with get, set
        member val interval: int = interval |> Option.defaultValue 50 with get, set
        member val onTimeout: obj -> obj = onTimeout |> Option.defaultValue (fun _ -> null) with get, set
        member val mutationObserverOptions: obj = mutationObserverOptions |> Option.defaultValue null with get, set

[<Erase>]
type RTL =

    /// Default queries provided by React Testing Library
    /// 
    /// https://testing-library.com/docs/dom-testing-library/api-custom-queries/
    [<Import("queries", "@testing-library/react")>]
    static member queries: obj = jsNative

    [<Import("screen", "@testing-library/react")>]
    static member screen: IQueryable = jsNative

    [<Import("render", "@testing-library/react")>]
    static member render(reactElement: ReactElement, ?options: RenderOptions) : RenderResult = jsNative

    /// https://testing-library.com/docs/guide-events
    [<Import("fireEvent", "@testing-library/react")>]
    static member fireEvent: IFireEvent = jsNative

    [<Import("createEvent", "@testing-library/react")>]
    [<Emit("$0[$1]($2, $3)")>]
    static member createEvent (eventName: string, node: Browser.Types.HTMLElement, ?eventProperties: obj) : Browser.Types.Event = jsNative

    /// https://testing-library.com/docs/guide-events
    [<Import("fireEvent", "@testing-library/react")>]
    static member fireEventWith (node: Browser.Types.HTMLElement, event: Browser.Types.Event) = jsNative

    [<Import("waitFor", "@testing-library/react")>]
    static member waitFor<'a> (callback: (unit -> 'a), ?options: RTLWaitForOptions) : Promise<'a> = jsNative

    [<Import("waitFor", "@testing-library/react")>]
    static member waitFor<'a> (callbackPromise: (unit -> Promise<'a>), ?options: RTLWaitForOptions) : Promise<'a> = jsNative

    static member inline waitFor<'a> (callback: Async<'a>, ?options: RTLWaitForOptions) : Promise<'a> = 
        RTL.waitFor<'a>((fun () -> (callback |> Async.StartAsPromise)), ?options = options)

    [<Import("waitForElementToBeRemoved", "@testing-library/react")>]
    static member waitForElementToBeRemoved (callback: (unit -> obj), ?options: RTLWaitForOptions) : Promise<unit> = jsNative

    [<Import("waitForElementToBeRemoved", "@testing-library/react")>]
    static member waitForElementToBeRemoved (callback: obj, ?options: RTLWaitForOptions) : Promise<unit> = jsNative

    [<ImportMember("@testing-library/react")>]
    static member cleanup () : unit = jsNative

    // [<ImportMember("@testing-library/react")>]
    // [<Emit("$0")>]
    // static member act (actFn: unit -> Promise<unit>) : Promise<unit> = jsNative

    [<ImportMember("@testing-library/react")>]
    static member act (actFn: unit -> unit) : unit = jsNative
