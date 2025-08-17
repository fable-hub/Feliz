namespace Feliz.Popover

open Feliz
open Fable.Core
open Fable.Core.JsInterop

module Interop =
    [<Emit("Object.assign({}, $0, $1)")>]
    let objectAssign (x: obj) (y: obj) = jsNative

type IPopoverProperty = interface end

[<Erase>]
type popover =
    /// The popover content.
    static member inline body (content: ReactElement list) =
        unbox<IPopoverProperty> ("body", React.Fragment content)
    /// Determines Whether or not the popover is rendered.
    static member inline isOpen(value: bool) =
        unbox<IPopoverProperty> ("isOpen", value)
    /// A callback function executed every time the user does an action (mousedown or touchstart) outside the DOM tree of both Popover and Target. A canonical use-case is to automatically close the Popover on any external user action.
    static member inline onOuterAction (handler: unit -> unit) =
        unbox<IPopoverProperty> ("onOuterAction", fun _ -> handler())
    /// The polling speed (AKA time between each poll) in milliseconds for checking if a layout refresh is required. This polling is required because it is the only robust way to track the position of a target in the DOM. Defaults to 200. Set to a falsey value to disable.
    static member inline refreshIntervalMs (value: int) =
        unbox<IPopoverProperty> ("refreshIntervalMs", value)
    /// The polling speed (AKA time between each poll) in milliseconds for checking if a layout refresh is required. This polling is required because it is the only robust way to track the position of a target in the DOM. Defaults to 200. Set to a falsey value to disable.
    static member inline refreshIntervalMs (value: bool) =
        unbox<IPopoverProperty> ("refreshIntervalMs", value)
    /// The amount of time in milliseconds that it takes to complete the enter and exit animation. Defaults to '500'.
    static member inline enterExitTransitionDurationMs (value: int) =
        unbox<IPopoverProperty> ("enterExitTransitionDurationMs", value)
    /// The amount of time in milliseconds that it takes to complete the enter and exit animation. Defaults to '500'.
    static member inline enterExitTransitionDurationMs (value: bool) =
        unbox<IPopoverProperty> ("enterExitTransitionDurationMs", value)
    /// Defines the size of the tip pointer. Use .01 to disable tip. Defaults to '7'.
    static member inline tipSize (value: float) =
        unbox<IPopoverProperty> ("tipSize", value)
    /// Disables the tip of the popover. When this option is used, then `popover.tipSize` should be omitted.
    static member inline disableTip =
        unbox<IPopoverProperty> ("tipSize", 0.01)
    /// The content that this popover will orient itself around.
    static member inline children (children: ReactElement list) =
        unbox<IPopoverProperty> ("children", React.KeyedFragment("popoverChildren", children))

[<Erase>]
type Popover =
    static member inline popover (properties: IPopoverProperty list) =
        let defaults = createObj [ "body" ==> Html.none ]
        ReactLegacy.createElement(
            (importDefault "react-popover" |> unbox<ReactElement>), 
            props = Interop.objectAssign defaults (createObj !!properties)
        )

module popover =
    /// Sets a preference of where to position the Popover. Only useful to specify placement in case of multiple available fits. Defaults to `auto`.
    [<Erase>]
    type preferPlace =
        /// Prefer an explicit side.
        static member inline above = unbox<IPopoverProperty> ("preferPlace", "above")
        /// Prefer an explicit side.
        static member inline right = unbox<IPopoverProperty> ("preferPlace", "right")
        /// Prefer an explicit side.
        static member inline below = unbox<IPopoverProperty> ("preferPlace", "below")
        /// Prefer an explicit side.
        static member inline left = unbox<IPopoverProperty> ("preferPlace", "left")
        /// Prefer an orientation.
        static member inline row = unbox<IPopoverProperty> ("preferPlace", "row")
        /// Prefer an orientation.
        static member inline column = unbox<IPopoverProperty> ("preferPlace", "column")
        /// Prefer an order.
        static member inline atStart = unbox<IPopoverProperty> ("preferPlace", "start")
        /// Prefer an order.
        static member inline atEnd = unbox<IPopoverProperty> ("preferPlace", "end")
        /// No preference, automatic resolution. This is the default.
        static member inline auto = unbox<IPopoverProperty> ("preferPlace", null)

    /// Like `preferPlace` except that the given place is a requirement. The resolver becomes scoped or disabled. It is scoped if the place is an orientation or order but disabled if it is a side. For example place: "row" scopes the resolver to above or below placement but place: "above" removes any need for the resolver.
    [<Erase>]
    type place =
        /// Prefer an explicit side.
        static member inline above = unbox<IPopoverProperty> ("place", "above")
        /// Prefer an explicit side.
        static member inline right = unbox<IPopoverProperty> ("place", "right")
        /// Prefer an explicit side.
        static member inline below = unbox<IPopoverProperty> ("place", "below")
        /// Prefer an explicit side.
        static member inline left = unbox<IPopoverProperty> ("place", "left")
        /// Prefer an orientation.
        static member inline row = unbox<IPopoverProperty> ("place", "row")
        /// Prefer an orientation.
        static member inline column = unbox<IPopoverProperty> ("place", "column")
        /// Prefer an order.
        static member inline atStart = unbox<IPopoverProperty> ("place", "start")
        /// Prefer an order.
        static member inline atEnd = unbox<IPopoverProperty> ("place", "end")
        /// No preference, automatic resolution. This is the default.
        static member inline auto = unbox<IPopoverProperty> ("place", null)
