module Feliz.ReactApi

open Browser.Types
open Fable.React
open Fable.Core
open System

type ReactChildren =
    abstract toArray: ReactElement -> ReactElement seq
    abstract toArray: ReactElement seq -> ReactElement seq

type IReactApi =
    abstract Children: ReactChildren
    abstract createContext: defaultValue: 'a -> IContext<'a>
    abstract createElement: comp: obj * props: obj -> ReactElement
    abstract createElement: comp: obj * props: obj * [<ParamList>] children: ReactElement seq -> ReactElement
    abstract forwardRef: render: Func<'props,IRefValue<'t>,ReactElement> -> ('props -> IRefValue<'t> -> ReactElement)
    [<Emit("$0.lazy($1)")>]
    abstract lazy': import: (unit -> JS.Promise<'t>) -> 't
    abstract memo: render: ('props -> ReactElement) * areEqual: ('props -> 'props -> bool) -> ('props -> ReactElement)
    abstract StrictMode: obj
    abstract Suspense: obj
    abstract useCallback: callbackFunction: ('a -> 'b) -> dependencies: obj array -> ('a -> 'b)
    abstract useContext: ctx: IContext<'a> -> 'a
    abstract useEffect: obj * dependencies: obj array -> unit
    abstract useEffect: obj -> unit
    abstract useEffect: effect: (unit -> unit) -> unit
    abstract useEffect: effect: (unit -> unit) * dependencies: obj [] -> unit
    abstract useImperativeHandle<'t> : ref: Fable.React.IRefValue<'t> -> createHandle: (unit -> 't) -> dependencies: obj array -> unit
    [<Emit("$0.useImperativeHandle($1, $2)")>]
    abstract useImperativeHandleNoDeps<'t> : ref: Fable.React.IRefValue<'t> -> createHandle: (unit -> 't) -> unit
    abstract useMemo: createFunction: (unit -> 'a) -> dependencies: obj array -> 'a
    abstract useReducer: ('state -> 'msg -> 'state) -> 'state -> ('state * ('msg -> unit))
    [<Emit "$0.useRef($1)">]
    abstract useRefInternal<'t> : initial: 't -> Fable.React.IRefValue<'t>
    abstract useState<'t,'u> : initial:'t -> ('u * ('u -> unit))

type IReactRoot =
    /// Renders the provided React element into the DOM in the supplied container.
    abstract render: ReactElement -> unit
    /// Removes a mounted React component from the DOM and cleans up its event handlers and state.
    abstract unmount : unit -> unit