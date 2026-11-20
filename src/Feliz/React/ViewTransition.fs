namespace Feliz

open System
open System.ComponentModel
open Fable.Core
open Fable.Core.JsInterop

[<EditorBrowsable(EditorBrowsableState.Never)>]
module ViewTransitionHelper =

    let inline mkProp (key: string) (value: obj) : IViewTransitionProperty = unbox (key, value)

    let inline byType (classes: seq<string * string>) : obj =
        createObj (unbox<seq<string * obj>> classes)

    // Callbacks are wrapped in delegates so React's (instance, types) call shape is kept: Fable would otherwise
    // merge `fun instance types -> fun () -> cleanup` into a single three-argument function.
    let inline mkHandler (handler: ViewTransitionInstance -> string[] -> unit) : obj =
        box (Action<ViewTransitionInstance, string[]>(fun instance types -> handler instance types))

    let inline mkCleanupHandler (handler: ViewTransitionInstance -> string[] -> (unit -> unit)) : obj =
        box (Func<ViewTransitionInstance, string[], (unit -> unit)>(fun instance types -> handler instance types))

/// Properties of `React.ViewTransition`. Requires React 19.3 or later.
///
/// Animation values (`enter`, `exit`, `update`, `share`, `default'`) accept:
/// - `"auto"`: the browser's default cross-fade,
/// - `"none"`: disables this animation,
/// - any other string: a CSS class React applies during the transition, used with `::view-transition-*` selectors,
/// - a list of `transitionType, value` pairs to pick a value based on the types added with `React.addTransitionType`.
///   A `"default"` entry is used when no type matches.
[<Erase>]
type viewTransition =

    /// The `view-transition-name` of this boundary. Only needed for shared element transitions: two boundaries
    /// with the same name, one unmounting and one mounting in the same transition, animate from one to the other.
    /// Each name must only be mounted once at a time.
    static member inline name(value: string) =
        ViewTransitionHelper.mkProp "name" value

    /// Animation used when this boundary is the first thing inserted in a transition.
    static member inline enter(value: string) =
        ViewTransitionHelper.mkProp "enter" value

    /// Animation used when this boundary is inserted, picked by transition type.
    static member inline enter(classesByType: seq<string * string>) =
        ViewTransitionHelper.mkProp "enter" (ViewTransitionHelper.byType classesByType)

    /// Animation used when this boundary is the first thing removed in a transition.
    static member inline exit(value: string) =
        ViewTransitionHelper.mkProp "exit" value

    /// Animation used when this boundary is removed, picked by transition type.
    static member inline exit(classesByType: seq<string * string>) =
        ViewTransitionHelper.mkProp "exit" (ViewTransitionHelper.byType classesByType)

    /// Animation used when DOM inside this boundary changes, or its size or position changes.
    static member inline update(value: string) =
        ViewTransitionHelper.mkProp "update" value

    /// Animation used when DOM inside this boundary changes, picked by transition type.
    static member inline update(classesByType: seq<string * string>) =
        ViewTransitionHelper.mkProp "update" (ViewTransitionHelper.byType classesByType)

    /// Animation used for a shared element transition (see `viewTransition.name`).
    static member inline share(value: string) =
        ViewTransitionHelper.mkProp "share" value

    /// Animation used for a shared element transition, picked by transition type.
    static member inline share(classesByType: seq<string * string>) =
        ViewTransitionHelper.mkProp "share" (ViewTransitionHelper.byType classesByType)

    /// Fallback animation for every trigger that isn't set explicitly. `default' "none"` turns off all triggers
    /// that aren't listed.
    static member inline default'(value: string) =
        ViewTransitionHelper.mkProp "default" value

    /// Fallback animation for every trigger that isn't set explicitly, picked by transition type.
    static member inline default'(classesByType: seq<string * string>) =
        ViewTransitionHelper.mkProp "default" (ViewTransitionHelper.byType classesByType)

    /// Called when the `enter` animation starts. Receives the instance and the transition types.
    static member inline onEnter(handler: ViewTransitionInstance -> string[] -> unit) =
        ViewTransitionHelper.mkProp "onEnter" (ViewTransitionHelper.mkHandler handler)

    /// Called when the `enter` animation starts. The returned cleanup function runs when the transition finishes.
    static member inline onEnter(handler: ViewTransitionInstance -> string[] -> (unit -> unit)) =
        ViewTransitionHelper.mkProp "onEnter" (ViewTransitionHelper.mkCleanupHandler handler)

    /// Called when the `exit` animation starts. Receives the instance and the transition types.
    static member inline onExit(handler: ViewTransitionInstance -> string[] -> unit) =
        ViewTransitionHelper.mkProp "onExit" (ViewTransitionHelper.mkHandler handler)

    /// Called when the `exit` animation starts. The returned cleanup function runs when the transition finishes.
    static member inline onExit(handler: ViewTransitionInstance -> string[] -> (unit -> unit)) =
        ViewTransitionHelper.mkProp "onExit" (ViewTransitionHelper.mkCleanupHandler handler)

    /// Called when the `update` animation starts. Receives the instance and the transition types.
    static member inline onUpdate(handler: ViewTransitionInstance -> string[] -> unit) =
        ViewTransitionHelper.mkProp "onUpdate" (ViewTransitionHelper.mkHandler handler)

    /// Called when the `update` animation starts. The returned cleanup function runs when the transition finishes.
    static member inline onUpdate(handler: ViewTransitionInstance -> string[] -> (unit -> unit)) =
        ViewTransitionHelper.mkProp "onUpdate" (ViewTransitionHelper.mkCleanupHandler handler)

    /// Called when the `share` animation starts. Takes precedence over `onEnter` and `onExit`.
    static member inline onShare(handler: ViewTransitionInstance -> string[] -> unit) =
        ViewTransitionHelper.mkProp "onShare" (ViewTransitionHelper.mkHandler handler)

    /// Called when the `share` animation starts. The returned cleanup function runs when the transition finishes.
    static member inline onShare(handler: ViewTransitionInstance -> string[] -> (unit -> unit)) =
        ViewTransitionHelper.mkProp "onShare" (ViewTransitionHelper.mkCleanupHandler handler)

    /// Key of the boundary, e.g. to animate a list item when it is replaced.
    static member inline key(value: string) = ViewTransitionHelper.mkProp "key" value

    /// Key of the boundary, e.g. to animate a list item when it is replaced.
    static member inline key(value: int) = ViewTransitionHelper.mkProp "key" value

    /// The content to animate. `enter`/`exit` only trigger when the boundary wraps DOM nodes directly
    /// (it must come before any DOM node in its subtree).
    static member inline children(value: ReactElement) =
        ViewTransitionHelper.mkProp "children" [ value ]

    /// The content to animate. `enter`/`exit` only trigger when the boundary wraps DOM nodes directly
    /// (it must come before any DOM node in its subtree).
    static member inline children(elems: seq<ReactElement>) =
        ViewTransitionHelper.mkProp "children" elems
