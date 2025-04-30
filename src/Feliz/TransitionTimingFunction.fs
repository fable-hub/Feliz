namespace Feliz

open Fable.Core
open Feliz.Styles

[<Erase>]
type jumpTerm =
    /// Denotes a left-continuous function, so that the first jump happens when the transition begins
    static member inline jumpStart : ITransitionJumpTerm = unbox "jump-start"
    /// Denotes a right-continuous function, so that the last jump happens when the animation ends
    static member inline jumpEnd : ITransitionJumpTerm = unbox "jump-end"
    /// There is no jump on either end. Instead, holding at both the 0% mark and the 100% mark, each for 1/n of the duration
    static member inline jumpNone : ITransitionJumpTerm = unbox "jump-none"
    /// Includes pauses at both the 0% and 100% marks, effectively adding a step during the transition time.
    static member inline jumpBoth : ITransitionJumpTerm = unbox "jump-both"
    /// Same as jumpStart
    static member inline start : ITransitionJumpTerm = unbox "start"
    /// Same as jumpEnd
    static member inline end' : ITransitionJumpTerm = unbox "end"

/// Sets how intermediate values are calculated for CSS properties being affected by a transition effect.
/// https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
[<Erase>]
type transitionTimingFunction =
    /// Equal to cubic-bezier(0.25, 0.1, 0.25, 1.0), the default value, increases in velocity
    /// towards the middle of the transition, slowing back down at the end.
    static member inline ease : ITransitionTimingFunction = unbox "ease"
    /// Equal to cubic-bezier(0.0, 0.0, 1.0, 1.0), transitions at an even speed
    static member inline linear : ITransitionTimingFunction = unbox "linear"
    /// Equal to cubic-bezier(0.42, 0, 1.0, 1.0), starts off slowly,
    /// with the transition speed increasing until complete.
    static member inline easeIn : ITransitionTimingFunction = unbox "ease-in"
    /// Equal to cubic-bezier(0, 0, 0.58, 1.0), starts transitioning quickly,
    /// slowing down as the transition continues.
    static member inline easeOut : ITransitionTimingFunction = unbox "ease-out"
    /// Equal to cubic-bezier(0.42, 0, 0.58, 1.0), starts transitioning slowly,
    /// speeds up, and then slows down again.
    static member inline easeInOut : ITransitionTimingFunction = unbox "ease-in-out"
    /// An author-defined cubic-Bezier curve, where the p1 and p3 values must be in the range of 0 to 1.
    static member inline cubicBezier (p1: int, p2: int, p3: int, p4: int): ITransitionTimingFunction =
        unbox (
            "cubic-bezier(" +
            unbox<string> p1 + ", " +
            unbox<string> p2 + ", " +
            unbox<string> p3 + ", " +
            unbox<string> p4 + ")"
        )
    /// Displays the transition along n stops along the transition, displaying each stop for equal lengths of time.
    /// For example, if n is 5, there are 5 steps.
    /// Whether the transition holds temporarily at 0%, 20%, 40%, 60% and 80%, on the 20%, 40%, 60%, 80% and 100%,
    /// or makes 5 stops between the 0% and 100% along the transition, or makes 5 stops including the 0% and 100%
    /// marks (on the 0%, 25%, 50%, 75%, and 100%) depends on which jump terms is used
    static member inline steps (n: int, jumpTerm: ITransitionJumpTerm) : ITransitionTimingFunction =
        unbox (
            "steps(" +
            unbox<string> n + ", " +
            unbox<string> jumpTerm + ")"
        )
    /// Equal to steps(1, jump-start)
    static member inline stepStart : ITransitionTimingFunction = unbox "step-start"
    /// Equal to steps(1, jump-end)
    static member inline stepEnd : ITransitionTimingFunction = unbox "step-end"
