namespace Feliz

open System
open Fable.Core
open Feliz.Styles

[<Erase>]
type style =
    /// The zIndex property sets or returns the stack order of a positioned element.
    ///
    /// An element with greater stack order (1) is always in front of another element with lower stack order (0).
    ///
    /// **Tip**: A positioned element is an element with the position property set to: relative, absolute, or fixed.
    ///
    /// **Tip**: This property is useful if you want to create overlapping elements.
    static member inline zIndex(value: int) = Interop.mkStyle "zIndex" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(value: int) = Interop.mkStyle "margin" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(value: ICssUnit) = Interop.mkStyle "margin" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: int, horizontal: int) =
        Interop.mkStyle "margin" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: int, horizontal: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: ICssUnit, horizontal: int) =
        Interop.mkStyle "margin" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: ICssUnit, horizontal: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: int, bottom: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: int, bottom: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: ICssUnit, bottom: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: ICssUnit, bottom: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: int, bottom: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: int, bottom: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: ICssUnit, bottom: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: ICssUnit, bottom: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: int, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: int, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: ICssUnit, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: int, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: int, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: ICssUnit, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: int, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: int, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: ICssUnit, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: int, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: int, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: int) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginLeft(value: int) = Interop.mkStyle "marginLeft" value
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginLeft(value: ICssUnit) = Interop.mkStyle "marginLeft" value
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginRight(value: int) = Interop.mkStyle "marginRight" value
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginRight(value: ICssUnit) = Interop.mkStyle "marginRight" value
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginTop(value: int) = Interop.mkStyle "marginTop" value
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginTop(value: ICssUnit) = Interop.mkStyle "marginTop" value
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginBottom(value: int) = Interop.mkStyle "marginBottom" value
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginBottom(value: ICssUnit) = Interop.mkStyle "marginBottom" value

    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(value: int) = Interop.mkStyle "marginBlock" value
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(value: ICssUnit) = Interop.mkStyle "marginBlock" value
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: int, blockEnd: int) =
        Interop.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: ICssUnit, blockEnd: int) =
        Interop.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: int, blockEnd: ICssUnit) =
        Interop.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: ICssUnit, blockEnd: ICssUnit) =
        Interop.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockStart(value: int) =
        Interop.mkStyle "marginBlockStart" value
    /// Defines the logical block start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockStart(value: ICssUnit) =
        Interop.mkStyle "marginBlockStart" value
    
    /// Defines the logical block end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockEnd(value: int) =
        Interop.mkStyle "marginBlockEnd" value
    /// Defines the logical block end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockEnd(value: ICssUnit) =
        Interop.mkStyle "marginBlockEnd" value

    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(value: int) = Interop.mkStyle "marginInline" value
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(value: ICssUnit) = Interop.mkStyle "marginInline" value
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: int, inlineEnd: int) =
        Interop.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: ICssUnit, inlineEnd: int) =
        Interop.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: int, inlineEnd: ICssUnit) =
        Interop.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: ICssUnit, inlineEnd: ICssUnit) =
        Interop.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    
    /// Defines the logical inline start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-start
    static member inline marginInlineStart(value: int) =
        Interop.mkStyle "marginInlineStart" value
    /// Defines the logical inline start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-start
    static member inline marginInlineStart(value: ICssUnit) =
        Interop.mkStyle "marginInlineStart" value
    
    /// Defines the logical inline end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-end
    static member inline marginInlineEnd(value: int) =
        Interop.mkStyle "marginInlineEnd" value
    /// Defines the logical inline end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-end
    static member inline marginInlineEnd(value: ICssUnit) =
        Interop.mkStyle "marginInlineEnd" value

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(value: int) = Interop.mkStyle "padding" value
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(value: ICssUnit) = Interop.mkStyle "padding" value
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: int, horizontal: int) =
        Interop.mkStyle "padding" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: int, horizontal: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: ICssUnit, horizontal: int) =
        Interop.mkStyle "padding" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: ICssUnit, horizontal: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: int, bottom: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: int, bottom: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: ICssUnit, bottom: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: ICssUnit, bottom: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: int, bottom: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: int, bottom: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: ICssUnit, bottom: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: ICssUnit, bottom: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: int, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: int, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: ICssUnit, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: int, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: int, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: ICssUnit, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: int, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: int, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: ICssUnit, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: int, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: int, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: int) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        Interop.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the height of the padding area on the bottom of an element.
    static member inline paddingBottom(value: int) = Interop.mkStyle "paddingBottom" value
    /// Sets the height of the padding area on the bottom of an element.
    static member inline paddingBottom(value: ICssUnit) = Interop.mkStyle "paddingBottom" value
    /// Sets the width of the padding area to the left of an element.
    static member inline paddingLeft(value: int) = Interop.mkStyle "paddingLeft" value
    /// Sets the width of the padding area to the left of an element.
    static member inline paddingLeft(value: ICssUnit) = Interop.mkStyle "paddingLeft" value
    /// Sets the width of the padding area on the right of an element.
    static member inline paddingRight(value: int) = Interop.mkStyle "paddingRight" value
    /// Sets the width of the padding area on the right of an element.
    static member inline paddingRight(value: ICssUnit) = Interop.mkStyle "paddingRight" value
    /// Sets the height of the padding area on the top of an element.
    static member inline paddingTop(value: int) = Interop.mkStyle "paddingTop" value
    /// Sets the height of the padding area on the top of an element.
    static member inline paddingTop(value: ICssUnit) = Interop.mkStyle "paddingTop" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(value: int) = Interop.mkStyle "marginBlock" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(value: ICssUnit) = Interop.mkStyle "marginBlock" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: int, blockEnd: int) =
        Interop.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: ICssUnit, blockEnd: int) =
        Interop.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: int, blockEnd: ICssUnit) =
        Interop.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: ICssUnit, blockEnd: ICssUnit) =
        Interop.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockStart(value: int) =
        Interop.mkStyle "paddingBlockStart" value
    /// Defines the logical block start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockStart(value: ICssUnit) =
        Interop.mkStyle "paddingBlockStart" value
    
    /// Defines the logical block end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockEnd(value: int) =
        Interop.mkStyle "paddingBlockEnd" value
    /// Defines the logical block end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockEnd(value: ICssUnit) =
        Interop.mkStyle "paddingBlockEnd" value

    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(value: int) = Interop.mkStyle "marginInline" value
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(value: ICssUnit) = Interop.mkStyle "marginInline" value
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: int, inlineEnd: int) =
        Interop.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: ICssUnit, inlineEnd: int) =
        Interop.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: int, inlineEnd: ICssUnit) =
        Interop.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: ICssUnit, inlineEnd: ICssUnit) =
        Interop.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    
    /// Defines the logical inline start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-start
    static member inline paddingInlineStart(value: int) =
        Interop.mkStyle "paddingInlineStart" value
    /// Defines the logical inline start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-start
    static member inline paddingInlineStart(value: ICssUnit) =
        Interop.mkStyle "paddingInlineStart" value
    
    /// Defines the logical inline end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-end
    static member inline paddingInlineEnd(value: int) =
        Interop.mkStyle "paddingInlineEnd" value
    /// Defines the logical inline end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-end
    static member inline paddingInlineEnd(value: ICssUnit) =
        Interop.mkStyle "paddingInlineEnd" value

    /// Sets the flex shrink factor of a flex item. If the size of all flex items is larger than
    /// the flex container, items shrink to fit according to flex-shrink.
    static member inline flexShrink(value: int) = Interop.mkStyle "flexShrink" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: int) = Interop.mkStyle "flexBasis" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: float) = Interop.mkStyle "flexBasis" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: ICssUnit) = Interop.mkStyle "flexBasis" value
    /// Sets the flex grow factor of a flex item main size. It specifies how much of the remaining
    /// space in the flex container should be assigned to the item (the flex grow factor).
    static member inline flexGrow (value: int) = Interop.mkStyle "flexGrow" value
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 199.5px 99.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [199.5;99.5;99.5]
    /// ```
    static member inline gridTemplateColumns(value: float list) =
        let addPixels = fun x -> x + "px"
        Interop.mkStyle "gridTemplateColumns" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 199.5px 99.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|199.5;99.5;99.5|]
    /// ```
    static member inline gridTemplateColumns(value: float[]) =
        let addPixels = fun x -> x + "px"
        Interop.mkStyle "gridTemplateColumns" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [100; 200; 100]
    /// ```
    static member inline gridTemplateColumns(value: int list) =
        let addPixels = fun x -> x + "px"
        Interop.mkStyle "gridTemplateColumns" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
    /// Sets the width of each individual grid column in pixels.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|100; 200; 100|]
    /// ```
    static member inline gridTemplateColumns(value: int[]) =
        let addPixels = fun x -> x + "px"
        Interop.mkStyle "gridTemplateColumns" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
    /// Sets the width of each individual grid column.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 1fr 1fr 2fr;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [length.fr 1; length.fr 1; length.fr 2]
    /// ```
    static member inline gridTemplateColumns(value: ICssUnit list) =
        Interop.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string list> value))
    /// Sets the width of each individual grid column.
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: 1fr 1fr 2fr;
    /// ```
    /// **F#**
    /// ```f#
    /// gridTemplateColumns: [|length.fr 1; length.fr 1; length.fr 2|]
    /// ```
    static member inline gridTemplateColumns(value: ICssUnit[]) =
        Interop.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string[]> value))
    /// Sets the width of each individual grid column. It can also name the lines between them
    /// There can be multiple names for the same line
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: [first-line] auto [first-line-end second-line-start] 100px [second-line-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns [
    ///     grid.namedLine "first-line"
    ///     grid.templateWidth length.auto
    ///     grid.namedLines ["first-line-end second-line-start"]
    ///     grid.templateWidth 100
    ///     grid.namedLine "second-line-end"
    /// ]
    /// ```
    static member inline gridTemplateColumns(value: IGridTemplateItem list) =
        Interop.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string list>value))
    /// Sets the width of each individual grid column. It can also name the lines between them
    /// There can be multiple names for the same line
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: [first-line] auto [first-line-end second-line-start] 100px [second-line-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns [|
    ///     grid.namedLine "first-line"
    ///     grid.templateWidth length.auto
    ///     grid.namedLines [|"first-line-end second-line-start"|]
    ///     grid.templateWidth 100
    ///     grid.namedLine "second-line-end"
    /// |]
    /// ```
    static member inline gridTemplateColumns(value: IGridTemplateItem[]) =
        Interop.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string[]>value))
    /// Sets the width of a number of grid columns to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 99.5px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 99.5)
    /// ```
    static member inline gridTemplateColumns(count: int, size: float) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px)"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 100px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 100)
    /// ```
    static member inline gridTemplateColumns(count: int, size: int) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px)"
        )
    /// Sets the width of a number of grid columns to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1fr);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, length.fr 1)
    /// ```
    static member inline gridTemplateColumns(count: int, size: ICssUnit) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + ")"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1.5px [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 1.5, "col-start")
    /// ```
    static member inline gridTemplateColumns(count: int, size: float, areaName: string) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid columns to the defined width in pixels, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 10px [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, 10, "col-start")
    /// ```
    static member inline gridTemplateColumns(count: int, size: int, areaName: string) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid columns to the defined width, as well as naming the lines between them
    ///
    /// **CSS**
    /// ```css
    /// grid-template-columns: repeat(3, 1fr [col-start]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateColumns (3, length.fr 1, "col-start")
    /// ```
    static member inline gridTemplateColumns(count: int, size: ICssUnit, areaName: string) =
        Interop.mkStyle "gridTemplateColumns" (
            "repeat(" +
            (unbox<string>count) + ", " +
            (unbox<string>size) + " [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 99.5px 199.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [99.5; 199.5; 99.5]
    /// ```
    static member inline gridTemplateRows(value: float list) =
        let addPixels = (fun x -> x + "px")
        Interop.mkStyle "gridTemplateRows" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 99.5px 199.5px 99.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|99.5; 199.5; 99.5|]
    /// ```
    static member inline gridTemplateRows(value: float[]) =
        let addPixels = (fun x -> x + "px")
        Interop.mkStyle "gridTemplateRows" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [100, 200, 100]
    /// ```
    static member inline gridTemplateRows(value: int list) =
        let addPixels = (fun x -> x + "px")
        Interop.mkStyle "gridTemplateRows" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 100px 200px 100px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|100; 200; 100|]
    /// ```
    static member inline gridTemplateRows(value: int[]) =
        let addPixels = (fun x -> x + "px")
        Interop.mkStyle "gridTemplateRows" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 1fr 10% 250px auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [length.fr 1; length.percent 10; length.px 250; length.auto]
    /// ```
    static member inline gridTemplateRows(value: ICssUnit list) =
        Interop.mkStyle "gridTemplateRows" (String.concat " " (unbox<string list> value))
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: 1fr 10% 250px auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|length.fr 1; length.percent 10; length.px 250; length.auto|]
    /// ```
    static member inline gridTemplateRows(value: ICssUnit[]) =
        Interop.mkStyle "gridTemplateRows" (String.concat " " (unbox<string[]> value))
    /// Sets the width of a number of grid rows to the defined width as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: [row-1-start] 1fr [row-1-end row-2-start] 1fr [row-2-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [
    ///     grid.namedLine "row-1-start"
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLines ["row-1-end"; "row-2-start"]
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLine "row-2-end"
    /// ]
    /// ```
    static member inline gridTemplateRows(value: IGridTemplateItem list) =
        Interop.mkStyle "gridTemplateRows" (String.concat " " (unbox<string list>value))
    /// Sets the width of a number of grid rows to the defined width as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: [row-1-start] 1fr [row-1-end row-2-start] 1fr [row-2-end];
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows [|
    ///     grid.namedLine "row-1-start"
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLines [|"row-1-end"; "row-2-start"|]
    ///     grid.templateWidth (length.fr 1)
    ///     grid.namedLine "row-2-end"
    /// |]
    /// ```
    static member inline gridTemplateRows(value: IGridTemplateItem[]) =
        Interop.mkStyle "gridTemplateRows" (String.concat " " (unbox<string[]>value))
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 199.5);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 199.5)
    /// ```
    static member inline gridTemplateRows(count: int, size: float) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px)"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 100px);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 100)
    /// ```
    static member inline gridTemplateRows(count: int, size: int) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px)"
        )
    /// Sets the width of a number of grid rows to the defined width
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 10%);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, length.percent 10)
    /// ```
    static member inline gridTemplateRows(count: int, size: ICssUnit) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + ")"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 75.5, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 75.5, "row")
    /// ```
    static member inline gridTemplateRows(count: int, size: float, areaName: string) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 100px, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, 100, "row")
    /// ```
    static member inline gridTemplateRows(count: int, size: int, areaName: string) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + "px [" +
            areaName + "])"
        )
    /// Sets the width of a number of grid rows to the defined width in pixels as well as naming the spaces between
    ///
    /// **CSS**
    /// ```css
    /// grid-template-rows: repeat(3, 10%, [row]);
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateRows (3, length.percent 10, "row")
    /// ```
    static member inline gridTemplateRows(count: int, size: ICssUnit, areaName: string) =
        Interop.mkStyle "gridTemplateRows" (
            "repeat("+
            (unbox<string>count) + ", " +
            (unbox<string>size) + " [" +
            areaName + "])"
        )
    /// 2D representation of grid layout as blocks with names
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas:
    ///     'header header header header'
    ///     'nav nav . sidebar'
    ///     'footer footer footer footer';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [
    ///     ["header"; "header"; "header"; "header" ]
    ///     ["nav"   ; "nav"   ; "."     ; "sidebar"]
    ///     ["footer"; "footer"; "footer"; "footer" ]
    /// ]
    /// ```
    static member inline gridTemplateAreas(value: string list list) =
        let wrapLine = (fun x -> "'" + x + "'")
        let lines = List.map (String.concat " " >> wrapLine) value
        let block = String.concat "\n" lines
        Interop.mkStyle "gridTemplateAreas" block
    /// 2D representation of grid layout as blocks with names
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas:
    ///     'header header header header'
    ///     'nav nav . sidebar'
    ///     'footer footer footer footer';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [|
    ///     [|"header"; "header"; "header"; "header" |]
    ///     [|"nav"   ; "nav"   ; "."     ; "sidebar"|]
    ///     [|"footer"; "footer"; "footer"; "footer" |]
    /// |]
    /// ```
    static member inline gridTemplateAreas(value: string[][]) =
        let wrapLine = (fun x -> "'" + x + "'")
        let lines = Array.map (String.concat " " >> wrapLine) value
        let block = String.concat "\n" lines
        Interop.mkStyle "gridTemplateAreas" block
    /// One-dimensional alternative to the nested list. For column-based layouts
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas: 'first second third fourth';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas ["first"; "second"; "third"; "fourth"]
    /// ```
    static member inline gridTemplateAreas(value: string list) =
        let block = (String.concat " ") value
        Interop.mkStyle "gridTemplateAreas" ("'" + block + "'")
    /// One-dimensional alternative to the nested list. For column-based layouts
    ///
    /// **CSS**
    /// ```css
    /// grid-template-areas: 'first second third fourth';
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplateAreas [|"first"; "second"; "third"; "fourth"|]
    /// ```
    static member inline gridTemplateAreas(value: string[]) =
        let block = (String.concat " ") value
        Interop.mkStyle "gridTemplateAreas" ("'" + block + "'")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap 1.5
    /// ```
    static member inline columnGap(value: float) =
        Interop.mkStyle "columnGap" (unbox<string> value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap 10
    /// ```
    static member inline columnGap(value: int) =
        Interop.mkStyle "columnGap" (unbox<string> value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the columns.
    ///
    /// **CSS**
    /// ```css
    /// column-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.columnGap (length.em 1)
    /// ```
    static member inline columnGap(value: ICssUnit) =
        Interop.mkStyle "columnGap" value
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 2.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap 2.5
    /// ```
    static member inline rowGap(value: float) =
        Interop.mkStyle "rowGap" (unbox<string> value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap 10
    /// ```
    static member inline rowGap(value: int) =
        Interop.mkStyle "rowGap" (unbox<string> value + "px")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows.
    ///
    /// **CSS**
    /// ```css
    /// row-gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.rowGap (length.em 1)
    /// ```
    static member inline rowGap(value: ICssUnit) =
        Interop.mkStyle "rowGap" value
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap 10
    /// ```
    static member inline gap(gap: int) =
        Interop.mkStyle "gap" ((unbox<string> gap) + "px ")
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1)
    /// ```
    static member inline gap(gap: ICssUnit) =
        Interop.mkStyle "gap" (unbox<string> gap)
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 2em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, length.em 2)
    /// ```
    static member inline gap(rowGap: ICssUnit, columnGap: ICssUnit) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + " " +
            (unbox<string> columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 3.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, 3.5)
    /// ```
    static member inline gap(rowGap: ICssUnit, columnGap: float) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + " " +
            (unbox<string> columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1em 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (length.em 1, 10)
    /// ```
    static member inline gap(rowGap: ICssUnit, columnGap: int) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + " " +
            (unbox<string> columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 1em;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, length.em 1)
    /// ```
    static member inline gap(rowGap: int, columnGap: ICssUnit) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, 1.5)
    /// ```
    static member inline gap(rowGap: int, columnGap: float) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 10px 15px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (10, 15)
    /// ```
    static member inline gap(rowGap: int, columnGap: int) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 2.5px 15%;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (2.5, length.percent 15)
    /// ```
    static member inline gap(rowGap: float, columnGap: ICssUnit) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap)
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1.5px 1.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (1.5, 1.5)
    /// ```
    static member inline gap(rowGap: float, columnGap: float) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap) + "px"
        )
    /// Specifies the size of the grid lines. You can think of it like
    /// setting the width of the gutters between the rows/columns.
    ///
    /// _Shorthand for `rowGap` and `columnGap`_
    ///
    /// **CSS**
    /// ```css
    /// gap: 1.5px 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gap (1.5, 10)
    /// ```
    static member inline gap(rowGap: float, columnGap: int) =
        Interop.mkStyle "gap" (
            (unbox<string> rowGap) + "px " +
            (unbox<string> columnGap) + "px"
        )
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: col2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart "col2"
    /// ```
    static member inline gridColumnStart(value: string) = Interop.mkStyle "gridColumnStart" value
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// When there are multiple named lines with the same name, you can specify which one by count
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart ("col", 2)
    /// ```
    static member inline gridColumnStart(value: string, count: int) =
        Interop.mkStyle "gridColumnStart" (value + " " + (unbox<string>count))
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart 2
    /// ```
    static member inline gridColumnStart(value: int) = Interop.mkStyle "gridColumnStart" value
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnStart (gridColumn.span "odd-col")
    /// ```
    static member inline gridColumnStart(value: IGridSpan) = Interop.mkStyle "gridColumnStart" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: col-2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd "col-2"
    /// ```
    static member inline gridColumnEnd(value: string) = Interop.mkStyle "gridColumnEnd" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd ("odd-col", 2)
    /// ```
    static member inline gridColumnEnd(value: string, count: int) =
        Interop.mkStyle "gridColumnEnd" (value + " " + (unbox<string> count))
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd 2
    /// ```
    static member inline gridColumnEnd(value: int) = Interop.mkStyle "gridColumnEnd" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-column-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumnEnd (gridColumn.span 2)
    /// ```
    static member inline gridColumnEnd(value: IGridSpan) = Interop.mkStyle "gridColumnEnd" value
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: col2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart "col2"
    /// ```
    static member inline gridRowStart(value: string) = Interop.mkStyle "gridRowStart" value
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart ("col", 2)
    /// ```
    static member inline gridRowStart(value: string, count: int) =
        Interop.mkStyle "gridRowStart" (value + " " + (unbox<string>count))
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart 2
    /// ```
    static member inline gridRowStart(value: int) = Interop.mkStyle "gridRowStart" value
    /// Sets where an item in the grid starts
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-start: span odd-col;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowStart (gridRow.span "odd-col")
    /// ```
    static member inline gridRowStart(value: IGridSpan) = Interop.mkStyle "gridRowStart" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: col-2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd "col-2"
    /// ```
    static member inline gridRowEnd(value: string) = Interop.mkStyle "gridRowEnd" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _When there are multiple named lines with the same name, you can specify which one by count_
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: odd-col 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd ("odd-col", 2)
    /// ```
    static member inline gridRowEnd(value: string, count: int) =
        Interop.mkStyle "gridRowEnd" (value + " " + (unbox<string> count))
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd 2
    /// ```
    static member inline gridRowEnd(value: int) = Interop.mkStyle "gridRowEnd" value
    /// Sets where an item in the grid ends
    /// The value can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// **CSS**
    /// ```css
    /// grid-row-end: span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRowEnd (gridRow.span 2)
    /// ```
    static member inline gridRowEnd(value: IGridSpan) = Interop.mkStyle "gridRowEnd" value
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / col-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", "col-4")
    /// ```
    static member inline gridColumn(start: string, end': string) =
        Interop.mkStyle "gridColumn" (start + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", 4)
    /// ```
    static member inline gridColumn(start: string, end': int) =
        Interop.mkStyle "gridColumn" (start + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: col-2 / span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn ("col-2", gridColumn.span 2)
    /// ```
    static member inline gridColumn(start: string, end': IGridSpan) =
        Interop.mkStyle "gridColumn" (start + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / col-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, "col-4")
    /// ```
    static member inline gridColumn(start: int, end': string) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, 3)
    /// ```
    static member inline gridColumn(start: int, end': int) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: 1 / span 2;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (1, gridColumn.span 2)
    /// ```
    static member inline gridColumn(start: int, end': IGridSpan) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / col-3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, "col-3")
    /// ```
    static member inline gridColumn(start: IGridSpan, end': string) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, 4)
    /// ```
    static member inline gridColumn(start: IGridSpan, end': int) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridColumnStart` and `gridColumnEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-column: span 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridColumn (gridColumn.span 2, gridColumn.span 3)
    /// ```
    static member inline gridColumn(start: IGridSpan, end': IGridSpan) =
        Interop.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / row-4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", "row-4")
    /// ```
    static member inline gridRow(start: string, end': string) =
        Interop.mkStyle "gridRow" (start + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", 4)
    /// ```
    static member inline gridRow(start: string, end': int) =
        Interop.mkStyle "gridRow" (start + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: row-2 / span "odd-row";
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow ("row-2", gridRow.span 2)
    /// ```
    static member inline gridRow(start: string, end': IGridSpan) =
        Interop.mkStyle "gridRow" (start + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / row-3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, "row-3")
    /// ```
    static member inline gridRow(start: int, end': string) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / 4;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, 4)
    /// ```
    static member inline gridRow(start: int, end': int) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (2, gridRow.span 3)
    /// ```
    static member inline gridRow(start: int, end': IGridSpan) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / "row-4";
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, "row-4")
    /// ```
    static member inline gridRow(start: IGridSpan, end': string) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + end')
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, 3)
    /// ```
    static member inline gridRow(start: IGridSpan, end': int) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Determines a grid item’s location within the grid by referring to specific grid lines.
    /// start is the line where the item begins, end' is the line where it ends.
    /// They can be one of the following options:
    /// - a named line
    /// - a numbered line
    /// - span until a named line was hit
    /// - span over a specified number of lines
    ///
    ///
    /// _Shorthand for `gridRowStart` and `gridRowEnds`_
    ///
    /// **CSS**
    /// ```css
    /// grid-row: span 2 / span 3;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridRow (gridRow.span 2, gridRow.span 3)
    /// ```
    static member inline gridRow(start: IGridSpan, end': IGridSpan) =
        Interop.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
    /// Specifies the size of an implicitly-created grid row track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-rows: 1fr;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoRows (length.fr 1)
    /// ```
    static member inline gridAutoRows(value: ICssUnit) =
        Interop.mkStyle "gridAutoRows" (unbox<string> value)
    /// Specifies the size of an implicitly-created grid row track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-rows: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoRows 10
    /// ```
    static member inline gridAutoRows(value: int) =
        Interop.mkStyle "gridAutoRows" (unbox<string> value)
    /// Specifies the size of an implicitly-created grid row track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-rows: 50.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoRows 50.5
    /// ```
    static member inline gridAutoRows(value: float) =
        Interop.mkStyle "gridAutoRows" (unbox<string> value)
    /// Specifies the size of an implicitly-created grid column track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-columns: 1fr;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoColumns (length.fr 1)
    /// ```
    static member inline gridAutoColumns(value: ICssUnit) =
        Interop.mkStyle "gridAutoColumns" (unbox<string> value)
    /// Specifies the size of an implicitly-created grid column track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-columns: 10px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoColumns 10
    /// ```
    static member inline gridAutoColumns(value: int) =
        Interop.mkStyle "gridAutoColumns" (unbox<string> value)
    /// Specifies the size of an implicitly-created grid column track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    ///
    /// **CSS**
    /// ```css
    /// grid-auto-columns: 50.5px;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridAutoColumns 50.5
    /// ```
    static member inline gridAutoColumns(value: float) =
        Interop.mkStyle "gridAutoColumns" (unbox<string> value)
    /// Sets the named grid area the item is placed in
    ///
    /// **CSS**
    /// ```css
    /// grid-area: header;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridArea "header"
    /// ```
    static member inline gridArea(value: string) =
        Interop.mkStyle "gridArea" value
    /// Shorthand for `grid-template-areas`, `grid-template-columns` and `grid-template-rows`.
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-template
    ///
    /// **CSS**
    /// ```css
    /// grid-template:  [header-top] 'a a a'      [header-bottom]
    ///                   [main-top] 'b b b' 1fr  [main-bottom]
    ///                              / auto 1fr auto;
    /// ```
    /// **F#**
    /// ```f#
    /// style.gridTemplate "[header-top] 'a a a'      [header-bottom] " +
    ///                      "[main-top] 'b b b' 1fr  [main-bottom] " +
    ///                                "/ auto 1fr auto"
    /// ```
    static member inline gridTemplate(value: string) =
        Interop.mkStyle "gridTemplate" value
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDuration(timespan: TimeSpan) =
        Interop.mkStyle "transitionDuration" (unbox<string> timespan.TotalMilliseconds + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationSeconds(n: float) =
        Interop.mkStyle "transitionDuration" ((unbox<string> n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationMilliseconds(n: float) =
        Interop.mkStyle "transitionDuration" ((unbox<string> n) + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationSeconds(n: int) =
        Interop.mkStyle "transitionDuration" ((unbox<string> n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationMilliseconds(n: int) =
        Interop.mkStyle "transitionDuration" ((unbox<string> n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelay(timespan: TimeSpan) =
        Interop.mkStyle "transitionDelay" (unbox<string> timespan.TotalMilliseconds + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelaySeconds(n: float) =
        Interop.mkStyle "transitionDelay" ((unbox<string> n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelayMilliseconds(n: float) =
        Interop.mkStyle "transitionDelay" ((unbox<string> n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelaySeconds(n: int) =
        Interop.mkStyle "transitionDelay" ((unbox<string> n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelayMilliseconds(n: int) =
        Interop.mkStyle "transitionDelay" ((unbox<string> n) + "ms")
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty ([<ParamArray>] properties: ITransitionProperty[]) =
        Interop.mkStyle "transitionProperty" (String.concat "," (unbox<string[]> properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (properties: ITransitionProperty list) =
        Interop.mkStyle "transitionProperty" (String.concat "," (unbox<string list> properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (property: ITransitionProperty) =
        Interop.mkStyle "transitionProperty" property
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (property: string) =
        Interop.mkStyle "transitionProperty" property
    
    /// Sets how intermediate values are calculated for CSS properties being affected by a transition effect.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    static member inline transitionTimingFunction (timingFunction: ITransitionTimingFunction) =
        Interop.mkStyle "transitionTimingFunction" timingFunction
    
    /// Sets how intermediate values are calculated for CSS properties being affected by a transition effect.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    static member inline transitionTimingFunction (timingFunction: string) =
        Interop.mkStyle "transitionTimingFunction" timingFunction

    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, timingFunction: ITransitionTimingFunction) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, timingFunction: ITransitionTimingFunction) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, timingFunction: ITransitionTimingFunction) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, timingFunction: ITransitionTimingFunction) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, delay: TimeSpan) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, delay: TimeSpan) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, delayInMs: int) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, delayInMs: int) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, timingFunction: ITransitionTimingFunction, delay: TimeSpan) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction,
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, timingFunction: ITransitionTimingFunction, delay: TimeSpan) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction,
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, timingFunction: ITransitionTimingFunction, delayInMs: int) =
        Interop.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction,
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, timingFunction: ITransitionTimingFunction, delayInMs: int) =
        Interop.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction,
            unbox<string> delayInMs + "ms "
        )
    
    static member inline transform(transformation: ITransformProperty) =
        Interop.mkStyle "transform" transformation

    static member inline transform(transformations: ITransformProperty list) =
        Interop.mkStyle "transform" (String.concat " " (unbox transformations))

    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: int) = Interop.mkStyle "fontSize" (unbox<string> size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: float) = Interop.mkStyle "fontSize" (unbox<string> size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: ICssUnit) = Interop.mkStyle "fontSize" size
    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    /// 
    /// The used value is this unitless number multiplied by the element's own font size. The computed
    /// value is the same as the specified number. In most cases, this is the preferred way to set
    /// line-height and avoid unexpected results due to inheritance.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    static member inline lineHeight(size: int) = Interop.mkStyle "lineHeight" size
    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    ///
    /// The used value is this unitless number multiplied by the element's own font size. The computed
    /// value is the same as the specified number. In most cases, this is the preferred way to set
    /// line-height and avoid unexpected results due to inheritance.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    static member inline lineHeight(size: float) = Interop.mkStyle "lineHeight" size
    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    static member inline lineHeight(size: ICssUnit) = Interop.mkStyle "lineHeight" size

    /// Sets the background color of an element.
    static member inline backgroundColor (color: string) = Interop.mkStyle "backgroundColor" color
    /// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
    ///
    /// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
    /// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
    /// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    static member inline caretColor (color: string) = Interop.mkStyle "caretColor" color
    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    static member inline color (color: string) = Interop.mkStyle "color" color
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline top(value: int) = Interop.mkStyle "top" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline top(value: ICssUnit) = Interop.mkStyle "top" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline bottom(value: int) = Interop.mkStyle "bottom" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline bottom(value: ICssUnit) = Interop.mkStyle "bottom" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline left(value: int) = Interop.mkStyle "left" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline left(value: ICssUnit) = Interop.mkStyle "left" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline right(value: int) = Interop.mkStyle "right" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline right(value: ICssUnit) = Interop.mkStyle "right" value
    /// Define a custom attribute of via key value pair
    static member inline custom(key: string, value: 't) = Interop.mkStyle key value
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    static member inline borderBottom(width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderBottom" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    static member inline borderBottom(width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderBottom" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    static member inline outlineWidth(width: int) =
        Interop.mkStyle "outlineWidth" ((unbox<string> width) + "px")

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    static member inline outlineWidth(width: ICssUnit) =
        Interop.mkStyle "outlineWidth" width

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    static member inline outlineOffset (offset:int) =
        Interop.mkStyle "outlineOffset" ((unbox<string> offset) + "px")

    /// The outline-offset property adds space between an outline and the edge or border of an element.
    ///
    /// The space between an element and its outline is transparent.
    ///
    /// Outlines differ from borders in three ways:
    ///
    ///  - An outline is a line drawn around elements, outside the border edge
    ///  - An outline does not take up space
    ///  - An outline may be non-rectangular
    ///
    static member inline outlineOffset (offset:ICssUnit) =
        Interop.mkStyle "outlineOffset" offset

    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    ///
    /// The `outline-color` property specifies the color of an outline.
    /// 
    /// **Note**: Always declare the outline-style property before the outline-color property. An element must have an outline before you change the color of it.
    static member inline outlineColor (color: string) =
        Interop.mkStyle "outlineColor" color
    
    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    /// The outline shorthand property sets most of the outline properties in a single declaration.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    static member inline outline (width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "outline" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    /// The outline shorthand property sets most of the outline properties in a single declaration.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    static member inline outline (width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "outline" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    
    /// Set an element's left border.
    static member inline borderLeft(width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderLeft" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's left border.
    static member inline borderLeft(width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderLeft" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's right border.
    static member inline borderRight(width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderRight" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's right border.
    static member inline borderRight(width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderRight" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's top border.
    static member inline borderTop(width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderTop" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's top border.
    static member inline borderTop(width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "borderTop" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets the line style of an element's bottom border.
    static member inline borderBottomStyle(style: IBorderStyle) = Interop.mkStyle "borderBottomStyle" (unbox<string> style)
    /// Sets the width of the bottom border of an element.
    static member inline borderBottomWidth (width: int) = Interop.mkStyle "borderBottomWidth" (unbox<string> width + "px")
    /// Sets the width of the bottom border of an element.
    static member inline borderBottomWidth (width: ICssUnit) = Interop.mkStyle "borderBottomWidth" (unbox<string> width)
    /// Sets the color of an element's bottom border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderBottomColor (color: string) = Interop.mkStyle "borderBottomColor" color
    /// Sets the line style of an element's top border.
    static member inline borderTopStyle(style: IBorderStyle) = Interop.mkStyle "borderTopStyle" (unbox<string> style)
    /// Sets the width of the top border of an element.
    static member inline borderTopWidth (width: int) = Interop.mkStyle "borderTopWidth" (unbox<string> width + "px")
    /// Sets the width of the top border of an element.
    static member inline borderTopWidth (width: ICssUnit) = Interop.mkStyle "borderTopWidth" (unbox<string> width)
    /// Sets the color of an element's top border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderTopColor (color: string) = Interop.mkStyle "borderTopColor" color
    /// /// Sets the line style of an element's right border.
    static member inline borderRightStyle(style: IBorderStyle) = Interop.mkStyle "borderRightStyle" (unbox<string> style)
    /// Sets the width of the right border of an element.
    static member inline borderRightWidth (width: int) = Interop.mkStyle "borderRightWidth" (unbox<string> width + "px")
    /// Sets the width of the right border of an element.
    static member inline borderRightWidth (width: ICssUnit) = Interop.mkStyle "borderRightWidth" (unbox<string> width)
    /// Sets the color of an element's right border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderRightColor (color: string) = Interop.mkStyle "borderRightColor" color
    /// Sets the line style of an element's left border.
    static member inline borderLeftStyle(style: IBorderStyle) = Interop.mkStyle "borderLeftStyle" (unbox<string> style)
    /// Sets the width of the left border of an element.
    static member inline borderLeftWidth (width: int) = Interop.mkStyle "borderLeftWidth" (unbox<string> width + "px")
    /// Sets the width of the left border of an element.
    static member inline borderLeftWidth (width: ICssUnit) = Interop.mkStyle "borderLeftWidth" (unbox<string> width)
    /// Sets the color of an element's left border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderLeftColor (color: string) = Interop.mkStyle "borderLeftColor" color
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: int, style: IBorderStyle, color: string) =
        Interop.mkStyle "border" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: ICssUnit, style: IBorderStyle, color: string) =
        Interop.mkStyle "border" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: string, style: IBorderStyle, color: string) =
        Interop.mkStyle "border" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle (style: IBorderStyle) = Interop.mkStyle "borderStyle" style
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle)  =
        Interop.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right))
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle) =
        Interop.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right) + " " +  (unbox<string> bottom))
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle, left: IBorderStyle) =
        Interop.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right) + " " + (unbox<string> bottom) + " " +  (unbox<string> left))
    /// Sets the color of an element's border.
    static member inline borderColor (color: string) = Interop.mkStyle "borderColor" color
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    static member inline borderRadius (radius: int) = Interop.mkStyle "borderRadius" radius
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    static member inline borderRadius (radius: ICssUnit) = Interop.mkStyle "borderRadius" radius
    /// top-left-and-bottom-right | top-right-and-bottom-left
    static member inline borderRadius (topLeftAndBottomRight: int, topRightAndBottomLeft: int) =
        Interop.mkStyle "borderRadius" (
            (unbox<string> topLeftAndBottomRight) + "px " +
            (unbox<string> topRightAndBottomLeft) + "px"
        )

    /// top-left | top-right-and-bottom-left | bottom-right
    static member inline borderRadius (topLeft: int, topRightAndBottomLeft: int, bottomRight: int) =
        Interop.mkStyle "borderRadius" (
            (unbox<string> topLeft) + "px " +
            (unbox<string> topRightAndBottomLeft) + "px " +
            (unbox<string> bottomRight) + "px"
        )

    /// top-left | top-right | bottom-right | bottom-left
    static member inline borderRadius (topLeft: int, topRight: int, bottomRight: int, bottomLeft: int) =
        Interop.mkStyle "borderRadius" (
            (unbox<string> topLeft) + "px " +
            (unbox<string> topRight) + "px " +
            (unbox<string> bottomRight) + "px " +
            (unbox<string> bottomLeft) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int) =
        Interop.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (width: int) = Interop.mkStyle "borderWidth" width
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int, bottom: int) =
        Interop.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int, bottom: int, left: int) =
        Interop.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )

    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (spacing: int) = Interop.mkStyle "borderSpacing" spacing
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (spacing: ICssUnit) = Interop.mkStyle "borderSpacing" spacing
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (horizontalSpacing: int, verticalSpacing: int) =
        Interop.mkStyle "borderSpacing" (
            (unbox<string> horizontalSpacing) + "px " +
            (unbox<string> verticalSpacing) + "px"
        )
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (horizontalSpacing: ICssUnit, verticalSpacing: ICssUnit) =
        Interop.mkStyle "borderSpacing" (
            (unbox<string> horizontalSpacing) + " " +
            (unbox<string> verticalSpacing)
        )

    /// Sets one or more animations to apply to an element. Each name is an @keyframes at-rule that
    /// sets the property values for the animation sequence.
    static member inline animationName(keyframeName: string) = Interop.mkStyle "animationName" keyframeName
    /// Sets the length of time that an animation takes to complete one cycle.
    static member inline animationDuration(timespan: TimeSpan) = Interop.mkStyle "animationDuration" ((unbox<string> timespan.TotalMilliseconds) + "ms")
    /// Sets the length of time that an animation takes to complete one cycle.
    static member inline animationDuration(seconds: int) = Interop.mkStyle "animationDuration" ((unbox<string> seconds) + "s")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    static member inline animationDelay(timespan: TimeSpan) = Interop.mkStyle "animationDelay" ((unbox<string> timespan.TotalMilliseconds) + "ms")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    static member inline animationDelay(seconds: int) = Interop.mkStyle "animationDelay" ((unbox<string> seconds) + "s")
    /// The number of times the animation runs.
    static member inline animationDurationCount(count: int) = Interop.mkStyle "animationDurationCount" count
    /// Sets the font family for the font specified in a @font-face rule.
    static member inline fontFamily (family: string) = Interop.mkStyle "fontFamily" family
    /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold.
    /// Possible values are [100, 200, 300, 400, 500, 600, 700, 800, 900]
    static member inline fontWeight (weight: int) = Interop.mkStyle "fontWeight" weight
    /// Sets the color of decorations added to text by text-decoration-line.
    static member inline textDecorationColor(color: string) = Interop.mkStyle "textDecorationColor" color
    /// Sets the kind of decoration that is used on text in an element, such as an underline or overline.
    static member inline textDecorationLine(line: ITextDecorationLine) = Interop.mkStyle "textDecorationLine" line
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(line: ITextDecorationLine) = Interop.mkStyle "textDecoration" line
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine) =
        Interop.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration) =
        Interop.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top) + " " + (unbox<string> style))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration, color: string) =
        Interop.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top) + " " + (unbox<string> style) + " " + color)
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    static member inline textIndent(value: int) = Interop.mkStyle "textIndent" value
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    static member inline textIndent(value: string) = Interop.mkStyle "textIndent" value
    /// Sets the opacity of an element.
    ///
    /// Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
    static member inline opacity(value: double) = Interop.mkStyle "opacity" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: int) = Interop.mkStyle "minWidth" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: ICssUnit) = Interop.mkStyle "minWidth" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: string) = Interop.mkStyle "minWidth" value
    /// Sets the initial position for each background image.
    ///
    /// The position is relative to the position layer set by background-origin.
    static member inline backgroundPosition  (position: string) = Interop.mkStyle "backgroundPosition" position
    /// Sets the type of cursor, if any, to show when the mouse pointer is over an element.
    static member inline cursor (value: string) = Interop.mkStyle "cursor" value
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    static member inline minHeight (value: int) = Interop.mkStyle "minHeight" value
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    static member inline minHeight (value: ICssUnit) = Interop.mkStyle "minHeight" value
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    static member inline maxWidth (value: int) = Interop.mkStyle "maxWidth" value
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    static member inline maxWidth (value: ICssUnit) = Interop.mkStyle "maxWidth" value
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    static member inline maxHeight (value: int) = Interop.mkStyle "maxHeight" value
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    static member inline maxHeight (value: ICssUnit) = Interop.mkStyle "maxHeight" value
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    static member inline height (value: int) = Interop.mkStyle "height" value
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    static member inline height (value: ICssUnit) = Interop.mkStyle "height" value
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    static member inline width (value: int) = Interop.mkStyle "width" value
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    static member inline width (value: ICssUnit) = Interop.mkStyle "width" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (value: string) = Interop.mkStyle "backgroundSize" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (value: ICssUnit) = Interop.mkStyle "backgroundSize" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (width: ICssUnit, height: ICssUnit) =
        Interop.mkStyle "backgroundSize" (
            unbox<string> width
            + " " +
            unbox<string> height
        )

    /// Sets one or more background images on an element.
    static member inline backgroundImage (value: string) = Interop.mkStyle "backgroundImage" value
    /// Short-hand for `style.backgroundImage(sprintf "url('%s')" value)` to set the backround image using a url.
    static member inline backgroundImageUrl (value: string) = Interop.mkStyle "backgroundImage" ("url('" + value + "')")
    /// Sets how background images are repeated.
    ///
    /// A background image can be repeated along the horizontal and vertical axes, or not repeated at all.
    static member inline backgroundRepeat (repeat: IBackgroundRepeat) = Interop.mkStyle "backgroundRepeat" repeat
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, color: string) =
        Interop.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
        Interop.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            (unbox<string> blur) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int, color: string) =
        Interop.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            (unbox<string> blur) + "px " +
            (unbox<string> spread) + "px " +
            color
        )

    /// Sets the color of an SVG shape.
    static member inline fill (color: string) = Interop.mkStyle "fill" color

    /// Specifies extra inter-character space in addition to the default space between characters.
    static member inline letterSpacing (value: int) = Interop.mkStyle "letterSpacing" value
    /// Specifies extra inter-character space in addition to the default space between characters.
    static member inline letterSpacing (value: ICssUnit) = Interop.mkStyle "letterSpacing" value
    
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin) =
        Interop.mkStyle "transformOrigin" (unbox<string> xOffset)
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin, yOffset: ITransformOrigin) =
        Interop.mkStyle "transformOrigin" (
            unbox<string> xOffset + " " +
            unbox<string> yOffset
        ) 
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin, yOffset: ITransformOrigin, zOffset: ITransformOrigin) =
        Interop.mkStyle "transformOrigin" (
            unbox<string> xOffset + " " +
            unbox<string> yOffset + " " +
            unbox<string> zOffset
        )
    
    /// Sets the color of the scrollbar track and thumb.
    /// The track refers to the background of the scrollbar, which
    /// is generally fixed regardless of the scrolling position.
    /// The thumb refers to the moving part of the scrollbar, which
    /// usually floats on top of the track.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-color
    static member inline scrollbarColor (thumbColor: string, trackColor: string) =
        Interop.mkStyle "scrollbarColor" (thumbColor + " " + trackColor)

    /// Sets the order to lay out an item in a flex or grid container.
    /// Items in a container are sorted by ascending order value and then by their source code order.
    /// Items not given an explicit order value are assigned the default value of 0.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/order
    static member inline order (value: int) = Interop.mkStyle "order" value
    
[<Erase>]
module style =

    [<Erase>]
    type boxShadow =
        static member inline none = Interop.mkStyle "boxShadow" "none"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "boxShadow" "inherit"

    [<Erase>]
    type width =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "width" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "width" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "width" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = Interop.mkStyle "width" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = Interop.mkStyle "width" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = Interop.mkStyle "width" "min-content"

    [<Erase>]
    type minWidth =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "minWidth" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "minWidth" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "minWidth" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = Interop.mkStyle "minWidth" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = Interop.mkStyle "minWidth" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = Interop.mkStyle "minWidth" "min-content"

     [<Erase>]
    type maxWidth =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "maxWidth" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "maxWidth" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "maxWidth" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = Interop.mkStyle "maxWidth" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = Interop.mkStyle "maxWidth" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = Interop.mkStyle "maxWidth" "min-content"

    [<Erase>]
    type height =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "height" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "height" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "height" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = Interop.mkStyle "height" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = Interop.mkStyle "height" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = Interop.mkStyle "height" "min-content"

    [<Erase>]
    type minHeight =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "minHeight" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "minHeight" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "minHeight" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = Interop.mkStyle "minHeight" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = Interop.mkStyle "minHeight" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = Interop.mkStyle "minHeight" "min-content"

    [<Erase>]
    type maxHeight =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "maxHeight" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "maxHeight" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "maxHeight" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = Interop.mkStyle "maxHeight" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = Interop.mkStyle "maxHeight" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = Interop.mkStyle "maxHeight" "min-content"

    [<Erase>]
    type textJustify =
        /// The browser determines the justification algorithm
        static member inline auto = Interop.mkStyle "textJustify" "auto"
        /// Increases/Decreases the space between words
        static member inline interWord = Interop.mkStyle "textJustify" "inter-word"
        /// Increases/Decreases the space between characters
        static member inline interCharacter = Interop.mkStyle "textJustify" "inter-character"
        /// Disables justification methods
        static member inline none = Interop.mkStyle "textJustify" "none"
        static member inline initial = Interop.mkStyle "textJustify" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textJustify" "inherit"

    [<Erase>]
    type whitespace =
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default.
        static member inline normal = Interop.mkStyle "whiteSpace" "normal"
        /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line.
        /// The text continues on the same line until a `<br>` tag is encountered.
        static member inline nowrap = Interop.mkStyle "whiteSpace" "nowrap"
        /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the <pre> tag in HTML.
        static member inline pre = Interop.mkStyle "whiteSpace" "pre"
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
        static member inline preline = Interop.mkStyle "whiteSpace" "pre-line"
        /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
        static member inline prewrap = Interop.mkStyle "whiteSpace" "pre-wrap"
        /// The behavior is identical to that of pre-wrap, except that:
        /// *) Any sequence of preserved white space or other space separators always takes up space, including at the end of the line.
        /// *) A soft wrap opportunity exists after every preserved white space character and after every other space separator (including between adjacent spaces).
        static member inline breakSpaces = Interop.mkStyle "whiteSpace" "break-spaces"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "whiteSpace" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "whiteSpace" "inherit"

    [<Erase>]
    type wordBreak =
        /// Default value. Uses default line break rules.
        static member inline normal = Interop.mkStyle "wordBreak" "normal"
        /// To prevent overflow, word may be broken at any character
        static member inline breakAll = Interop.mkStyle "wordBreak" "break-all"
        /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text. Non-CJK text behavior is the same as value "normal"
        static member inline keepAll = Interop.mkStyle "wordBreak" "keep-all"
        /// To prevent overflow, word may be broken at arbitrary points.
        static member inline breakWord = Interop.mkStyle "wordBreak" "break-word"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "wordBreak" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "wordBreak" "inherit"

    [<Erase>]
    type scrollBehavior =
        /// Allows a straight jump "scroll effect" between elements within the scrolling box. This is default
        static member inline auto = Interop.mkStyle "scrollBehavior" "auto"
        /// Allows a smooth animated "scroll effect" between elements within the scrolling box.
        static member inline smooth = Interop.mkStyle "scrollBehavior" "smooth"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "scrollBehavior" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "scrollBehavior" "inherit"

    /// Sets how strictly snap points are enforced on the scroll container in case there is one.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
    [<Erase>]
    type scrollSnapType =
        /// When the visual viewport of this scroll container is scrolled, it must ignore snap points.
        static member inline none = Interop.mkStyle "scrollSnapType" "none"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        static member inline x = Interop.mkStyle "scrollSnapType" "x"
        /// The scroll container snaps to snap positions in its vertical axis only.
        static member inline y = Interop.mkStyle "scrollSnapType" "y"
        /// The scroll container snaps to snap positions in its block axis only.
        static member inline block = Interop.mkStyle "scrollSnapType" "block"
        /// The scroll container snaps to snap positions in its inline axis only.
        static member inline inline' = Interop.mkStyle "scrollSnapType" "inline"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        static member inline both = Interop.mkStyle "scrollSnapType" "both"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline xMandatory = Interop.mkStyle "scrollSnapType" "x mandatory"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        /// 
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline xProximity = Interop.mkStyle "scrollSnapType" "x proximity"
        /// The scroll container snaps to snap positions in its vertical axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline yMandatory = Interop.mkStyle "scrollSnapType" "y mandatory"
        /// The scroll container snaps to snap positions in its vertical axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline yProximity = Interop.mkStyle "scrollSnapType" "y proximity"
        /// The scroll container snaps to snap positions in its block axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline blockMandatory = Interop.mkStyle "scrollSnapType" "block mandatory"
        /// The scroll container snaps to snap positions in its block axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline blockProximity = Interop.mkStyle "scrollSnapType" "block proximity"
        /// The scroll container snaps to snap positions in its inline axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline inlineMandatory = Interop.mkStyle "scrollSnapType" "inline mandatory"
        /// The scroll container snaps to snap positions in its inline axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline inlineProximity = Interop.mkStyle "scrollSnapType" "inline proximity"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline bothMandatory = Interop.mkStyle "scrollSnapType" "both mandatory"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline bothProximity = Interop.mkStyle "scrollSnapType" "both proximity"

    /// Specifies the box's snap position as an alignment of its snap area (as the alignment subject)
    /// within its snap container's snap port (as the alignment container).
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-align
    [<Erase>]
    type scrollSnapAlign =
        /// This box does not define a snap position in the specified axis. 
        static member inline none = Interop.mkStyle "scrollSnapAlign" "none"
        /// Start alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline start = Interop.mkStyle "scrollSnapAlign" "start"
        /// Center alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline center = Interop.mkStyle "scrollSnapAlign" "center"
        /// End alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline end' = Interop.mkStyle "scrollSnapAlign" "end"
        static member inline noneStart = Interop.mkStyle "scrollSnapAlign" "none start"
        static member inline noneCenter = Interop.mkStyle "scrollSnapAlign" "none center"
        static member inline noneEnd =  Interop.mkStyle "scrollSnapAlign" "none end"
        static member inline startNone = Interop.mkStyle "scrollSnapAlign" "start none"
        static member inline startCenter = Interop.mkStyle "scrollSnapAlign" "start center"
        static member inline startEnd =  Interop.mkStyle "scrollSnapAlign" "start end"
        static member inline centerNone = Interop.mkStyle "scrollSnapAlign" "center none"
        static member inline centerStart = Interop.mkStyle "scrollSnapAlign" "center start"
        static member inline centerEnd =  Interop.mkStyle "scrollSnapAlign" "center end"
        static member inline endNone = Interop.mkStyle "scrollSnapAlign" "end none"
        static member inline endStart = Interop.mkStyle "scrollSnapAlign" "end start"
        static member inline endCenter =  Interop.mkStyle "scrollSnapAlign" "end center"
    
    
    
    /// Sets the maximum thickness of an element's scrollbars when they are shown.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-width
    [<Erase>]
    type scrollbarWidth =
        /// The default scrollbar width for the platform.
        static member inline auto = Interop.mkStyle "scrollbarWidth" "auto"
        /// A thin scrollbar width variant on platforms that provide that option,
        /// or a thinner scrollbar than the default platform scrollbar width. 
        static member inline thin = Interop.mkStyle "scrollbarWidth" "thin"
        /// No scrollbar shown, however the element will still be scrollable.
        static member inline none = Interop.mkStyle "scrollbarWidth" "none"
    
    /// Reserves space for the scrollbar, preventing unwanted layout changes as
    /// the content grows while also avoiding unnecessary visuals when scrolling
    /// isn't needed.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-gutter
    [<Erase>]
    type scrollbarGutter =
        /// The initial value. Classic scrollbars create a gutter when overflow
        /// is scroll, or when overflow is auto and the box is overflowing.
        /// Overlay scrollbars do not consume space.
        static member inline auto = Interop.mkStyle "scrollbarGutter" "auto"
        /// When using classic scrollbars, the gutter will be present if overflow
        /// is auto, scroll, or hidden even if the box is not overflowing.
        /// When using overlay scrollbars, the gutter will not be present.
        static member inline stable = Interop.mkStyle "scrollbarGutter" "stable"
        /// When using classic scrollbars, the gutter will be present if overflow
        /// is auto, scroll, or hidden even if the box is not overflowing.
        /// When using overlay scrollbars, the gutter will not be present.
        /// 
        /// If a gutter would be present on one of the inline start/end edges
        /// of the box, another will be present on the opposite edge as well.
        static member inline stableBothEdges = Interop.mkStyle "scrollbarGutter" "stable both-edges"

    /// sets the color of the scrollbar track and thumb.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-color
    [<Erase>]
    type scrollbarColor =
        static member inline auto = Interop.mkStyle "scrollbarColor" "auto"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "scrollbarColor" "inherit"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "scrollbarColor" "initial"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "scrollbarColor" "unset"
        static member inline revert = Interop.mkStyle "scrollbarColor" "revert"
        static member inline revertLayer = Interop.mkStyle "scrollbarColor" "revert-layer"

    [<Erase>]
    type overflow =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = Interop.mkStyle "overflow" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = Interop.mkStyle "overflow" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = Interop.mkStyle "overflow" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = Interop.mkStyle "overflow" "auto"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "overflow" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "overflow" "inherit"

    [<Erase>]
    type overflowX =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = Interop.mkStyle "overflowX" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = Interop.mkStyle "overflowX" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = Interop.mkStyle "overflowX" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = Interop.mkStyle "overflowX" "auto"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "overflowX" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "overflowX" "inherit"

    [<Erase>]
    type textOrientation =
        /// The characters are rotated 90° clockwise. This is the default value of this property.
        static member inline mixed = Interop.mkStyle "textOrientation" "mixed"
        /// The characters of horizontal scripts are laid out naturally (upright), as
        /// well as the glyphs for vertical scripts. This property makes all the 
        /// characters to be considered as left-to-right: the used value of direction is forced to be ltr.
        static member inline upright = Interop.mkStyle "textOrientation" "upright"
        /// The characters are laid out as they would be horizontally, but with the whole
        /// line rotated 90° clockwise.
        static member inline sideways = Interop.mkStyle "textOrientation" "sideways"
        /// An alias to sideways that is kept for compatibility purposes.
        static member inline sidewaysRight = Interop.mkStyle "textOrientation" "sideways-right"
        /// It makes the property use its default value.
        static member inline initial = Interop.mkStyle "textOrientation" "initial"
        /// It inherits the property from its parents element.
        static member inline inheritFromParent = Interop.mkStyle "textOrientation" "inherit"
    [<Erase>]
    type visibility =
        /// The element is hidden (but still takes up space).
        static member inline hidden = Interop.mkStyle "visibility" "hidden"
        /// Default value. The element is visible.
        static member inline visible = Interop.mkStyle "visibility" "visible"
        /// Only for table rows (`<tr>`), row groups (`<tbody>`), columns (`<col>`), column groups
        /// (`<colgroup>`). This value removes a row or column, but it does not affect the table layout.
        /// The space taken up by the row or column will be available for other content.
        ///
        /// If collapse is used on other elements, it renders as "hidden"
        static member inline collapse = Interop.mkStyle "visibility" "collapse"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "visibility" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "visibility" "inherit"

    [<Erase>]
    type flexBasis =
        /// Default value. The length is equal to the length of the flexible item. If the item has
        /// no length specified, the length will be according to its content.
        static member inline auto = Interop.mkStyle "flexBasis" "auto"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "flexBasis" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "flexBasis" "inherit"

    [<Erase>]
    type flexDirection =
        /// Default value. The flexible items are displayed horizontally, as a row
        static member inline row = Interop.mkStyle "flexDirection" "row"
        /// Same as row, but in reverse order.
        static member inline rowReverse = Interop.mkStyle "flexDirection" "row-reverse"
        /// The flexible items are displayed vertically, as a column
        static member inline column = Interop.mkStyle "flexDirection" "column"
        /// Same as column, but in reverse order
        static member inline columnReverse = Interop.mkStyle "flexDirection" "column-reverse"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "flexBasis" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "flexBasis" "inherit"

    [<Erase>]
    type flexWrap =
        /// Default value. Specifies that the flexible items will not wrap.
        static member inline nowrap = Interop.mkStyle "flexWrap" "nowrap"
        /// Specifies that the flexible items will wrap if necessary
        static member inline wrap = Interop.mkStyle "flexWrap" "wrap"
        /// Specifies that the flexible items will wrap, if necessary, in reverse order
        static member inline wrapReverse = Interop.mkStyle "flexWrap" "wrap-reverse"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "flexWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "flexWrap" "inherit"

    /// Places an element on the left or right side of its container, allowing text and
    /// inline elements to wrap around it. The element is removed from the normal flow
    /// of the page, though still remaining a part of the flow (in contrast to absolute
    /// positioning).
    [<Erase>]
    type float' =
        /// The element must float on the left side of its containing block.
        static member inline left = Interop.mkStyle "float" "left"
        /// The element must float on the right side of its containing block.
        static member inline right = Interop.mkStyle "float" "right"
        /// The element must not float.
        static member inline none = Interop.mkStyle "float" "none"

    /// Determines how a font face is displayed based on whether and when it is downloaded and ready to use.
    [<Erase>]
    type fontDisplay =
        /// The font display strategy is defined by the user agent.
        ///
        /// Default value
        static member inline auto = Interop.mkStyle "fontDisplay" "auto"
        /// Gives the font face a short block period and an infinite swap period.
        static member inline block = Interop.mkStyle "fontDisplay" "block"
        /// Gives the font face an extremely small block period and an infinite swap period.
        static member inline swap = Interop.mkStyle "fontDisplay" "swap"
        /// Gives the font face an extremely small block period and a short swap period.
        static member inline fallback = Interop.mkStyle "fontDisplay" "fallback"
        /// Gives the font face an extremely small block period and no swap period.
        static member inline optional = Interop.mkStyle "fontDisplay" "optional"

    [<Erase>]
    type fontKerning =
        /// Default. The browser determines whether font kerning should be applied or not
        static member inline auto = Interop.mkStyle "fontKerning" "auto"
        /// Specifies that font kerning is applied
        static member inline normal = Interop.mkStyle "fontKerning" "normal"
        /// Specifies that font kerning is not applied
        static member inline none = Interop.mkStyle "fontKerning" "none"

    /// The font-weight property sets how thick or thin characters in text should be displayed.
    [<Erase>]
    type fontWeight =
        /// Defines normal characters. This is default.
        static member inline normal = Interop.mkStyle "fontWeight" "normal"
        /// Defines thick characters.
        static member inline bold = Interop.mkStyle "fontWeight" "bold"
        /// Defines thicker characters
        static member inline bolder = Interop.mkStyle "fontWeight" "bolder"
        /// Defines lighter characters.
        static member inline lighter = Interop.mkStyle "fontWeight" "lighter"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "fontWeight" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "fontWeight" "inherit"

    [<Erase>]
    type fontStyle =
        /// The browser displays a normal font style. This is defaut.
        static member inline normal = Interop.mkStyle "fontStyle" "normal"
        /// The browser displays an italic font style.
        static member inline italic = Interop.mkStyle "fontStyle" "italic"
        /// The browser displays an oblique font style.
        static member inline oblique = Interop.mkStyle "fontStyle" "oblique"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "fontStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "fontStyle" "inherit"

    [<Erase>]
    type fontVariant =
        /// The browser displays a normal font. This is default
        static member inline normal = Interop.mkStyle "fontVariant" "normal"
        /// The browser displays a small-caps font
        static member inline smallCaps = Interop.mkStyle "fontVariant" "small-caps"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "fontVariant" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "fontVariant" "inherit"

    [<Erase>]
    type overflowY =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = Interop.mkStyle "overflowY" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = Interop.mkStyle "overflowY" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = Interop.mkStyle "overflowY" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = Interop.mkStyle "overflowY" "auto"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "overflowY" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "overflowY" "inherit"

    [<Erase>]
    type wordWrap =
        /// Break words only at allowed break points
        static member inline normal = Interop.mkStyle "wordWrap" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = Interop.mkStyle "wordWrap" "break-word"
        /// To prevent overflow, an otherwise unbreakable string of characters — like a long word or URL — may be broken
        /// at any point if there are no otherwise-acceptable break points in the line.
        static member inline anywhere = Interop.mkStyle "wordWrap" "anywhere"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "wordWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "wordWrap" "inherit"

    /// The overflow-anchor property makes it possible to turn off scroll anchoring.
    /// Scroll anchoring is a feature in the browser that prevents a viewable area that is scrolled into focus to move when new content is loaded above. This is typically a problem on a slow connection if the user scrolls down and starts reading before the page is fully loaded.
    [<Erase>]
    type overflowAnchor =
        /// Default value. Scroll anchoring is enabled
        static member inline auto = Interop.mkStyle "overflowAnchor" "auto"
        /// Scroll anchoring is disabled
        static member inline none = Interop.mkStyle "overflowAnchor" "none"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "overflowAnchor" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "overflowAnchor" "inherit"

    /// The overflow-wrap property applies to inline elements, setting whether the browser should insert line breaks
    /// within an otherwise unbreakable string to prevent text from overflowing its line box.
    [<Erase>]
    type overflowWrap =
        /// Break words only at allowed break points
        static member inline normal = Interop.mkStyle "overflowWrap" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = Interop.mkStyle "overflowWrap" "break-word"
        /// To prevent overflow, an otherwise unbreakable string of characters — like a long word or URL — may be broken
        /// at any point if there are no otherwise-acceptable break points in the line.
        static member inline anywhere = Interop.mkStyle "overflowWrap" "anywhere"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "overflowWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "overflowWrap" "inherit"

    /// Sets the horizontal spacing behavior between text characters.
    [<Erase>]
    type letterSpacing =
        /// The normal letter spacing for the current font
        static member inline normal = Interop.mkStyle "letterSpacing" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = Interop.mkStyle "letterSpacing" "break-word"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "letterSpacing" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "letterSpacing" "inherit"
    
    /// Sets the distance between the borders of adjacent table cells.
    [<Erase>]
    type borderSpacing =
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "borderSpacing" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "borderSpacing" "inherit"

    /// The `align-self` CSS property overrides a grid or flex item's `align-items` value.
    /// - In Grid, it aligns the item inside the grid area.
    /// - In Flexbox, it aligns the item on the cross axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    /// **Note**: The property doesn't apply to block-level boxes, or to table cells. If a flexbox item's cross-axis margin is auto, then align-self is ignored.
    [<Erase>]
    type alignSelf =
        /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container.
        static member inline auto = Interop.mkStyle "alignSelf" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In static position of absolutely-positioned layouts, the keyword behaves as stretch.
        /// - For flex items, the keyword behaves as stretch.
        /// - For grid items, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        /// - The property doesn't apply to block-level boxes, and to table cells.
        static member inline normal = Interop.mkStyle "alignSelf" "normal"
        
        /// The flex item's margin box is centered within the line on the cross-axis.
        /// If the cross-size of the item is larger than the flex container, it will overflow equally in both directions.
        static member inline center = Interop.mkStyle "alignSelf" "center"
        /// Put the item at the start
        static member inline start = Interop.mkStyle "alignSelf" "start"
        /// Put the item at the end
        static member inline end' = Interop.mkStyle "alignSelf" "end"        
        /// Aligns the items to be flush with the edge of the alignment container corresponding to the item's start side in the cross axis.
        static member inline selfStart = Interop.mkStyle "alignSelf" "self-start"
        /// Aligns the items to be flush with the edge of the alignment container corresponding to the item's end side in the cross axis.
        static member inline selfEnd = Interop.mkStyle "alignSelf" "self-end"
        /// The cross-start margin edge of the flex item is flushed with the cross-start edge of the line.
        static member inline flexStart = Interop.mkStyle "alignSelf" "flex-start"
        /// The cross-end margin edge of the flex item is flushed with the cross-end edge of the line.
        static member inline flexEnd = Interop.mkStyle "alignSelf" "flex-end"
        
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        static member inline baseline = Interop.mkStyle "alignSelf" "baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// 
        /// The fallback alignment for first baseline is start
        static member inline firstBaseline = Interop.mkStyle "alignSelf" "first baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// 
        /// The fallback alignment for last baseline is end
        static member inline lastBaseline = Interop.mkStyle "alignSelf" "last baseline"
        /// If the combined size of the items along the cross axis is less than the size of the alignment container
        /// and the item is auto-sized, its size is increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size of all auto-sized items exactly fills the alignment container along the cross axis.
        static member inline stretch = Interop.mkStyle "alignSelf" "stretch"
        
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "alignSelf" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "alignSelf" "inherit"
        static member inline revert = Interop.mkStyle "alignSelf" "revert"
        static member inline unset = Interop.mkStyle "alignSelf" "unset"

    /// The CSS `align-items` property sets the `align-self` value on all direct children as a group.
    /// - In Grid Layout, it controls the alignment of items on the Block Axis within their grid area.
    /// - In Flexbox, it controls the alignment of items on the Cross Axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    [<Erase>]
    type alignItems =
        /// Default. Items are stretched to fit the container
        static member inline stretch = Interop.mkStyle "alignItems" "stretch"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In static position of absolutely-positioned layouts, the keyword behaves as stretch.
        /// - For flex items, the keyword behaves as stretch.
        /// - For grid items, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        /// - The property doesn't apply to block-level boxes, and to table cells.
        static member inline normal = Interop.mkStyle "alignItems" "normal"

        /// The flex items' margin boxes are centered within the line on the cross-axis.
        /// If the cross-size of an item is larger than the flex container, it will overflow equally in both directions.
        static member inline center = Interop.mkStyle "alignItems"  "center"
        /// The items are packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = Interop.mkStyle "alignItems" "start"
        /// The items are packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = Interop.mkStyle "alignItems" "end"
        /// The cross-start margin edges of the flex items are flushed with the cross-start edge of the line.
        static member inline flexStart = Interop.mkStyle "alignItems" "flex-start"
        /// The cross-end margin edges of the flex items are flushed with the cross-end edge of the line.
        static member inline flexEnd = Interop.mkStyle "alignItems" "flex-end"

        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline baseline = Interop.mkStyle "alignItems" "baseline"
        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline firstBaseline = Interop.mkStyle "alignItems" "first baseline"
        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline lastBaseline = Interop.mkStyle "alignItems" "last baseline"

        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "alignItems"  "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "alignItems"  "inherit"
        static member inline revert = Interop.mkStyle "alignItems"  "revert"
        static member inline unset = Interop.mkStyle "alignItems"  "unset"

    /// The CSS `align-content` property sets the distribution of space between and around content items
    /// along a flexbox's cross-axis or a grid's block axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    /// **Note**: This property has no effect on single line flex containers (i.e. ones with `flex-wrap: nowrap`).
    ///
    /// **Tip**: Use the justify-content property to align the items on the main-axis (horizontally).
    [<Erase>]
    type alignContent =
        /// Default value. The items are packed in their default position as if no `align-content` value was set.
        static member inline normal = Interop.mkStyle "alignContent" "normal"
        
        /// The items are packed flush to each other in the center of the alignment container along the cross axis.
        static member inline center = Interop.mkStyle "alignContent" "center"
        /// The items are packed flush to each other against the start edge of the alignment container in the cross axis.
        static member inline start = Interop.mkStyle "alignContent" "start"
        /// The items are packed flush to each other against the end edge of the alignment container in the cross axis.
        static member inline end' = Interop.mkStyle "alignContent" "end"
        /// The items are packed flush to each other against the edge of the alignment container depending on the
        /// flex container's cross-start side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `start`.
        static member inline flexStart = Interop.mkStyle "alignContent" "flex-start"
        /// The items are packed flush to each other against the edge of the alignment container depending on the
        /// flex container's cross-end side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `end`.
        static member inline flexEnd = Interop.mkStyle "alignContent" "flex-end"

        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        static member inline baseline = Interop.mkStyle "alignContent" "baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for first baseline is start.
        static member inline firstBaseline = Interop.mkStyle "alignContent" "first baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for last baseline is end.
        static member inline lastBaseline = Interop.mkStyle "alignContent" "last baseline"

        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The first item is flush with the start edge of the alignment container in the cross axis,
        /// and the last item is flush with the end edge of the alignment container in the cross axis.
        static member inline spaceBetween = Interop.mkStyle "alignContent" "space-between"
        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The empty space before the first and after the last item equals half of the space
        /// between each pair of adjacent items.
        static member inline spaceAround = Interop.mkStyle "alignContent" "space-around"
        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items, the start edge and the first item,
        /// and the end edge and the last item, are all exactly the same.
        static member inline spaceEvenly = Interop.mkStyle "alignContent" "space-evenly"
        /// If the combined size of the items along the cross axis is less than the size of the
        /// alignment container, any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container along the cross axis.
        static member inline stretch = Interop.mkStyle "alignContent" "stretch"

        static member inline initial = Interop.mkStyle "alignContent" "initial"
        static member inline inheritFromParent = Interop.mkStyle "alignContent" "inherit"
        static member inline revert = Interop.mkStyle "alignContent" "revert"
        static member inline unset = Interop.mkStyle "alignContent" "unset"

    /// The CSS `justify-self` property sets the way a box is justified inside its alignment container along the appropriate axis.
    /// The effect of this property is dependent of the layout mode we are in:
    /// - In block-level layouts, it aligns an item inside its containing block on the inline axis.
    /// - For absolutely-positioned elements, it aligns an item inside its containing block on the inline axis, accounting for the offset values of top, left, bottom, and right.
    /// - In table cell layouts, this property is ignored
    /// - In grid layouts, it aligns an item inside its grid area on the inline axis
    /// - In flexbox layouts, this property is ignored
    /// 
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/justify-self
    /// 
    /// **Tip**: Use the align-items property to align the items vertically.
    [<Erase>]
    type justifySelf =
        /// The value used is the value of the justify-items property of the parents box,
        /// unless the box has no parent, or is absolutely positioned, in these cases, auto represents normal.
        static member inline auto = Interop.mkStyle "justifySelf" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In block-level layouts, the keyword is a synonym of start.
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In table cell layouts, this keyword has no meaning as this property is ignored.
        /// - In flexbox layouts, this keyword has no meaning as this property is ignored.
        /// - In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        static member inline normal = Interop.mkStyle "justifySelf" "normal"
        /// If the combined size of the items is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container.
        static member inline stretch = Interop.mkStyle "justifySelf" "stretch"

        /// Items are positioned at the center of the container
        static member inline center = Interop.mkStyle "justifySelf" "center"
        /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = Interop.mkStyle "justifySelf" "start"
        /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = Interop.mkStyle "justifySelf" "end"
        /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
        static member inline selfStart = Interop.mkStyle "justifySelf" "self-start"
        /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
        static member inline selfEnd = Interop.mkStyle "justifySelf" "self-end"
        /// Equivalent to 'start'. Note that justify-self is ignored in Flexbox layouts.
        static member inline flexStart = Interop.mkStyle "justifySelf" "flex-start"
        /// Equivalent to 'end'. Note that justify-self is ignored in Flexbox layouts.
        static member inline flexEnd = Interop.mkStyle "justifySelf" "flex-end"
        /// Pack items from the left
        static member inline left = Interop.mkStyle "justifySelf" "left"
        /// Pack items from the right
        static member inline right = Interop.mkStyle "justifySelf" "right"

        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for first baseline is start, the one for last baseline is end.
        static member inline baseline = Interop.mkStyle "justifySelf" "baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for `first baseline` is `start`.
        static member inline firstBaseline = Interop.mkStyle "justifySelf" "first baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for `last baseline` is `end`.
        static member inline lastBaseline = Interop.mkStyle "justifySelf" "last baseline"

        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "justifySelf" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "justifySelf" "inherit"
        static member inline revert = Interop.mkStyle "justifySelf" "revert"
        static member inline unset = Interop.mkStyle "justifySelf" "unset"

    /// The CSS justify-items property defines the default justify-self for all items of the box,
    /// giving them all a default way of justifying each box along the appropriate axis.
    /// The effect of this property is dependent of the layout mode we are in:
    /// - In block-level layouts, it aligns the items inside their containing block on the inline axis.
    /// - For absolutely-positioned elements, it aligns the items inside their containing block on the inline axis, accounting for the offset values of top, left, bottom, and right.
    /// - In table cell layouts, this property is ignored
    /// - In flexbox layouts, this property is ignored
    /// - In grid layouts, it aligns the items inside their grid areas on the inline axis
    ///
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/justify-items
    ///
    /// **Tip**: Use the align-items property to align the items vertically.
    [<Erase>]
    type justifyItems =
        /// The value used is the value of the justify-items property of the parents box,
        /// unless the box has no parent, or is absolutely positioned, in these cases, auto represents `normal`.
        static member inline auto = Interop.mkStyle "justifyItems" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In block-level layouts, the keyword is a synonym of start.
        /// - In absolutely-positioned layouts, the keyword behaved like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In table cell layouts, this keyword has no meaning as this property is ignored.
        /// - In flexbox layouts, this keyword has no meaning as this property is ignored.
        /// - In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like `start`.
        static member inline normal = Interop.mkStyle "justifyItems" "normal"
        /// If the combined size of the items is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container.
        static member inline stretch = Interop.mkStyle "justifyItems" "stretch"

        /// The items are packed flush to each other toward the center of the of the alignment container.
        static member inline center = Interop.mkStyle "justifyItems" "center"
        /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = Interop.mkStyle "justifyItems" "start"
        /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = Interop.mkStyle "justifyItems" "end"
        /// Equivalent to 'start'. Note that justify-items is ignored in Flexbox layouts.
        static member inline flexStart = Interop.mkStyle "justifyItems" "flex-start"
        /// Equivalent to 'end'. Note that justify-items is ignored in Flexbox layouts.
        static member inline flexEnd = Interop.mkStyle "justifyItems" "flex-end"
        /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
        static member inline selfStart = Interop.mkStyle "justifyItems" "self-start"
        /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
        static member inline selfEnd = Interop.mkStyle "justifyItems" "self-end"
        /// The items are packed flush to each other toward the left edge of the alignment container.
        /// If the property's axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline left = Interop.mkStyle "justifyItems" "left"
        /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis.
        /// If the property's axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline right = Interop.mkStyle "justifyItems" "right"

        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        static member inline baseline = Interop.mkStyle "justifyItems" "baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        /// The fallback alignment for `first baseline` is `start`.
        static member inline firstBaseline = Interop.mkStyle "justifyItems" "first baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        /// The fallback alignment for `last baseline` is `end`.
        static member inline lastBaseline = Interop.mkStyle "justifyItems" "last baseline"

        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "justifyItems" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "justifyItems" "inherit"
        static member inline revert = Interop.mkStyle "justifyItems" "revert"
        static member inline unset = Interop.mkStyle "justifyItems" "unset"

    /// The CSS `justify-content` property defines how the browser distributes space
    /// between and around content items along the main-axis of a flex container,
    /// and the inline axis of a grid container.
    ///
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content
    /// **Note**: The alignment is done after the lengths and auto margins are applied, meaning that,
    ///             if in a Flexbox layout there is at least one flexible element, with flex-grow different from 0,
    ///             it will have no effect as there won't be any available space.
    /// **Tip**: Use the align-items property to align the items vertically.
    [<Erase>]
    type justifyContent =
        /// The items are packed in their default position as if no justify-content value was set.
        /// This value behaves as `stretch` in grid and flex containers.
        static member inline normal = Interop.mkStyle "justifyContent" "normal"

        /// The items are packed flush to each other toward the center of the alignment container along the main axis.
        static member inline center = Interop.mkStyle "justifyContent" "center"
        /// The items are packed flush to each other toward the start edge of the alignment container in the main axis.
        static member inline start = Interop.mkStyle "justifyContent" "start"
        /// The items are packed flush to each other toward the end edge of the alignment container in the main axis.
        static member inline end' = Interop.mkStyle "justifyContent" "end"
        /// The items are packed flush to each other toward the edge of the alignment container depending on the flex container's
        /// main-start side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `start`.
        static member inline flexStart = Interop.mkStyle "justifyContent" "flex-start"
        /// The items are packed flush to each other toward the edge of the alignment container depending on the flex container's
        /// main-end side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `end`.
        static member inline flexEnd = Interop.mkStyle "justifyContent" "flex-end"
        /// The items are packed flush to each other toward the left edge of the alignment container.
        /// If the property’s axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline left = Interop.mkStyle "justifyContent" "left"
        /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis.
        /// If the property’s axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline right = Interop.mkStyle "justifyContent" "right"

        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The first item is flush with the main-start edge, and the last item is flush with the main-end edge.
        static member inline spaceBetween = Interop.mkStyle "justifyContent" "space-between"
        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The empty space before the first and after the last item equals half of the space between each pair of adjacent items.
        static member inline spaceAround = Interop.mkStyle "justifyContent" "space-around"
        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items, the main-start edge and the first item,
        /// and the main-end edge and the last item, are all exactly the same.
        static member inline spaceEvenly = Interop.mkStyle "justifyContent" "space-evenly"
        /// If the combined size of the items along the main axis is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally), while still respecting
        /// the constraints imposed by max-height/max-width (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container along the main axis.
        /// **Note**: stretch is not supported by flexible boxes (flexbox).
        static member inline stretch = Interop.mkStyle "justifyContent" "stretch"

        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "justifyItems" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "justifyItems" "inherit"
        static member inline revert = Interop.mkStyle "justifyItems" "revert"
        static member inline unset = Interop.mkStyle "justifyItems" "unset"

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    [<Erase>]
    type outlineWidth =
        /// Specifies a medium outline. This is default.
        static member inline medium = Interop.mkStyle "outlineWidth" "medium"
        /// Specifies a thin outline.
        static member inline thin = Interop.mkStyle "outlineWidth" "thin"
        /// Specifies a thick outline.
        static member inline thick = Interop.mkStyle "outlineWidth" "thick"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "outlineWidth" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "outlineWidth" "inherit"

    [<Erase>]
    type listStyleType =
        /// Default value. The marker is a filled circle
        static member inline disc = Interop.mkStyle "listStyleType" "disc"
        /// The marker is traditional Armenian numbering
        static member inline armenian = Interop.mkStyle "listStyleType" "armenian"
        /// The marker is a circle
        static member inline circle = Interop.mkStyle "listStyleType" "circle"
        /// The marker is plain ideographic numbers
        static member inline cjkIdeographic = Interop.mkStyle "listStyleType" "cjk-ideographic"
        /// The marker is a number
        static member inline decimal = Interop.mkStyle "listStyleType" "decimal"
        /// The marker is a number with leading zeros (01, 02, 03, etc.)
        static member inline decimalLeadingZero = Interop.mkStyle "listStyleType" "decimal-leading-zero"
        /// The marker is traditional Georgian numbering
        static member inline georgian = Interop.mkStyle "listStyleType" "georgian"
        /// The marker is traditional Hebrew numbering
        static member inline hebrew = Interop.mkStyle "listStyleType" "hebrew"
        /// The marker is traditional Hiragana numbering
        static member inline hiragana = Interop.mkStyle "listStyleType" "hiragana"
        /// The marker is traditional Hiragana iroha numbering
        static member inline hiraganaIroha = Interop.mkStyle "listStyleType" "hiragana-iroha"
        /// The marker is traditional Katakana numbering
        static member inline katakana = Interop.mkStyle "listStyleType" "katakana"
        /// The marker is traditional Katakana iroha numbering
        static member inline katakanaIroha = Interop.mkStyle "listStyleType" "katakana-iroha"
        /// The marker is lower-alpha (a, b, c, d, e, etc.)
        static member inline lowerAlpha = Interop.mkStyle "listStyleType" "lower-alpha"
        /// The marker is lower-greek
        static member inline lowerGreek = Interop.mkStyle "listStyleType" "lower-greek"
        /// The marker is lower-latin (a, b, c, d, e, etc.)
        static member inline lowerLatin = Interop.mkStyle "listStyleType" "lower-latin"
        /// The marker is lower-roman (i, ii, iii, iv, v, etc.)
        static member inline lowerRoman = Interop.mkStyle "listStyleType" "lower-roman"
        /// No marker is shown
        static member inline none = Interop.mkStyle "listStyleType" "none"
        /// The marker is a square
        static member inline square = Interop.mkStyle "listStyleType" "square"
        /// The marker is upper-alpha (A, B, C, D, E, etc.)
        static member inline upperAlpha = Interop.mkStyle "listStyleType" "upper-alpha"
        /// The marker is upper-greek
        static member inline upperGreek = Interop.mkStyle "listStyleType" "upper-greek"
        /// The marker is upper-latin (A, B, C, D, E, etc.)
        static member inline upperLatin = Interop.mkStyle "listStyleType" "upper-latin"
        /// The marker is upper-roman (I, II, III, IV, V, etc.)
        static member inline upperRoman = Interop.mkStyle "listStyleType" "upper-roman"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = Interop.mkStyle "listStyleType" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = Interop.mkStyle "listStyleType" "inherit"

    [<Erase>]
    type listStyleImage =
        /// No image will be displayed. Instead, the list-style-type property will define what type of list marker will be rendered. This is default
        static member inline none = Interop.mkStyle "listStyleImage" "none"
        /// The path to the image to be used as a list-item marker
        static member inline url (path: string) = Interop.mkStyle "listStyleImage" ("url('" + path + "')")
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = Interop.mkStyle "listStyleImage" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = Interop.mkStyle "listStyleImage" "inherit"

    [<Erase>]
    type listStylePosition =
        /// The bullet points will be inside the list item
        static member inline inside = Interop.mkStyle "listStylePosition" "inside"
        /// The bullet points will be outside the list item. This is default
        static member inline outside = Interop.mkStyle "listStylePosition" "outside"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = Interop.mkStyle "listStylePosition" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = Interop.mkStyle "listStylePosition" "inherit"

    [<Erase>]
    type textAlign =
        /// Aligns the text to the left.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align
        static member inline left = Interop.mkStyle "textAlign" "left"
        /// Aligns the text to the right.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=right
        static member inline right = Interop.mkStyle "textAlign" "right"
        /// Centers the text.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=center
        static member inline center = Interop.mkStyle "textAlign" "center"
        /// Stretches the lines so that each line has equal width (like in newspapers and magazines).
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=justify
        static member inline justify = Interop.mkStyle "textAlign" "justify"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = Interop.mkStyle "textAlign" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = Interop.mkStyle "textAlign" "inherit"

    [<Erase>]
    type textDecorationLine =
        static member inline none = Interop.mkStyle "textDecorationLine" "none"
        static member inline underline = Interop.mkStyle "textDecorationLine" "underline"
        static member inline overline = Interop.mkStyle "textDecorationLine" "overline"
        static member inline lineThrough = Interop.mkStyle "textDecorationLine" "line-through"
        static member inline initial = Interop.mkStyle "textDecorationLine" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textDecorationLine" "inherit"

    [<Erase>]
    type textDecoration =
        static member inline none = Interop.mkStyle "textDecoration" "none"
        static member inline underline = Interop.mkStyle "textDecoration" "underline"
        static member inline overline = Interop.mkStyle "textDecoration" "overline"
        static member inline lineThrough = Interop.mkStyle "textDecoration" "line-through"
        static member inline initial = Interop.mkStyle "textDecoration" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textDecoration" "inherit"

    /// The `transform-style` property specifies how nested elements are rendered in 3D space.
    [<Erase>]
    type transformStyle =
        /// Specifies that child elements will NOT preserve its 3D position. This is default.
        static member inline flat = Interop.mkStyle "transformStyle" "flat"
        /// Specifies that child elements will preserve its 3D position
        static member inline preserve3D = Interop.mkStyle "transformStyle" "preserve-3d"
        static member inline initial = Interop.mkStyle "transformStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "transformStyle" "inherit"

    [<Erase>]
    type textTransform =
        /// No capitalization. The text renders as it is. This is default.
        static member inline none = Interop.mkStyle "textTransform" "none"
        /// Transforms the first character of each word to uppercase.
        static member inline capitalize = Interop.mkStyle "textTransform" "capitalize"
        /// Transforms all characters to uppercase.
        static member inline uppercase = Interop.mkStyle "textTransform" "uppercase"
        /// Transforms all characters to lowercase.
        static member inline lowercase = Interop.mkStyle "textTransform" "lowercase"
        static member inline initial = Interop.mkStyle "textTransform" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textTransform" "inherit"

    [<Erase>]
    type textOverflow =
        /// Default value. The text is clipped and not accessible.
        static member inline clip = Interop.mkStyle "textOverflow" "clip"
        /// Render an ellipsis ("...") to represent the clipped text.
        static member inline ellipsis = Interop.mkStyle "textOverflow" "ellipsis"
        /// Render the given string to represent the clipped text.
        static member inline custom(value: string) = Interop.mkStyle "textOverflow" value
        static member inline initial = Interop.mkStyle "textOverflow" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textOverflow" "inherit"

    /// Defines visual effects like blur and saturation to an element.
    [<Erase>]
    type filters =
        static member inline private mkFilter value : IFilter = unbox value 
        /// Default value. Specifies no effects.
        static member inline none = filters.mkFilter "none"
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline blur(value: int) = filters.mkFilter ("blur(" + (unbox<string> value) + "%)")
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline blur(value: double) = filters.mkFilter ("blur(" + (unbox<string> value) + ")")
        /// Adjusts the brightness of the element
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        ///
        /// Values over 100% will provide brighter results.
        static member inline brightness(value: int) = filters.mkFilter ("brightness(" + (unbox<string> value) + "%)")
        /// Adjusts the brightness of the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline brightness(value: double) = filters.mkFilter ("brightness(" + (unbox<string> value) + ")")
        /// Adjusts the contrast of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline contrast(value: int) = filters.mkFilter ("contrast(" + (unbox<string> value) + "%)")
        /// Adjusts the contrast of the element. A larger value will create more contrast.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline contrast(value: double) = filters.mkFilter ("contrast(" + (unbox<string> value) + ")")
        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int,  color: string) =
            filters.mkFilter (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                (unbox<string> blur) + "px " +
                (unbox<string> spread) + "px " +
                color +
                ")"
            )

        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
            filters.mkFilter (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                (unbox<string> blur) + "px " +
                color +
                ")"
            )

        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, color: string) =
            filters.mkFilter (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                color +
                ")"
            )

        /// Converts the image to grayscale
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline grayscale(value: int) = filters.mkFilter ("grayscale(" + (unbox<string> value) + "%)")
        /// Converts the image to grayscale
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline grayscale(value: double) = filters.mkFilter ("grayscale(" + (unbox<string> value) + ")")
        /// Applies a hue rotation on the image. The value defines the number of degrees around the color circle the image
        /// samples will be adjusted. 0deg is default, and represents the original image.
        ///
        /// **Note**: Maximum value is 360
        static member inline hueRotate(degrees: int) = filters.mkFilter ("hue-rotate(" + (unbox<string> degrees) + "deg)")
        /// Inverts the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline invert(value: int) = filters.mkFilter ("invert(" + (unbox<string> value) + "%)")
        /// Inverts the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline invert(value: double) = filters.mkFilter ("invert(" + (unbox<string> value) + ")")
        /// Sets the opacity of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline opacity(value: int) = filters.mkFilter ("opacity(" + (unbox<string> value) + "%)")
        /// Sets the opacity of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline opacity(value: double) = filters.mkFilter ("opacity(" + (unbox<string> value) + ")")
        /// Sets the saturation of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline saturate(value: int) = filters.mkFilter ("saturate(" + (unbox<string> value) + "%)")
        /// Sets the saturation of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline saturate(value: double) = filters.mkFilter ("saturate(" + (unbox<string> value) + ")")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline sepia(value: int) = filters.mkFilter ("sepia(" + (unbox<string> value) + "%)")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline sepia(value: double) = filters.mkFilter ("sepia(" + (unbox<string> value) + ")")
        /// The url() function takes the location of an XML file that specifies an SVG filter, and may include an anchor to a specific filter element.
        ///
        /// Example: `filter: url(svg-url#element-id)`
        static member inline url(value: string) = filters.mkFilter ("url(" + value + ")")
        /// Sets this property to its default value.
        static member inline initial = filters.mkFilter "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = filters.mkFilter "inherit"

    /// Defines visual effects like blur and saturation to an element.
    [<Erase>]
    type filter =
        /// Default value. Specifies no effects.
        static member inline none = Interop.mkStyle "filter" "none"
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline blur(value: int) = Interop.mkStyle "filter" ("blur(" + (unbox<string> value) + "%)")
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline blur(value: double) = Interop.mkStyle "filter" ("blur(" + (unbox<string> value) + ")")
        /// Adjusts the brightness of the element
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        ///
        /// Values over 100% will provide brighter results.
        static member inline brightness(value: int) = Interop.mkStyle "filter" ("brightness(" + (unbox<string> value) + "%)")
        /// Adjusts the brightness of the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline brightness(value: double) = Interop.mkStyle "filter" ("brightness(" + (unbox<string> value) + ")")
        /// Adjusts the contrast of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline contrast(value: int) = Interop.mkStyle "filter" ("contrast(" + (unbox<string> value) + "%)")
        /// Adjusts the contrast of the element. A larger value will create more contrast.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline contrast(value: double) = Interop.mkStyle "filter" ("contrast(" + (unbox<string> value) + ")")
        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int, color: string) =
            Interop.mkStyle "filter" (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                (unbox<string> blur) + "px " +
                (unbox<string> spread) + "px " +
                color +
                ")"
            )

        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
            Interop.mkStyle "filter" (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                (unbox<string> blur) + "px " +
                color +
                ")"
            )

        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, color: string) =
            Interop.mkStyle "filter" (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                color +
                ")"
            )

        /// Converts the image to grayscale
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline grayscale(value: int) = Interop.mkStyle "filter" ("grayscale(" + (unbox<string> value) + "%)")
        /// Converts the image to grayscale
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline grayscale(value: double) = Interop.mkStyle "filter" ("grayscale(" + (unbox<string> value) + ")")
        /// Applies a hue rotation on the image. The value defines the number of degrees around the color circle the image
        /// samples will be adjusted. 0deg is default, and represents the original image.
        ///
        /// **Note**: Maximum value is 360
        static member inline hueRotate(degrees: int) = Interop.mkStyle "filter" ("hue-rotate(" + (unbox<string> degrees) + "deg)")
        /// Inverts the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline invert(value: int) = Interop.mkStyle "filter" ("invert(" + (unbox<string> value) + "%)")
        /// Inverts the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline invert(value: double) = Interop.mkStyle "filter" ("invert(" + (unbox<string> value) + ")")
        /// Sets the opacity of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline opacity(value: int) = Interop.mkStyle "filter" ("opacity(" + (unbox<string> value) + "%)")
        /// Sets the opacity of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline opacity(value: double) = Interop.mkStyle "filter" ("opacity(" + (unbox<string> value) + ")")
        /// Sets the saturation of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline saturate(value: int) = Interop.mkStyle "filter" ("saturate(" + (unbox<string> value) + "%)")
        /// Sets the saturation of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline saturate(value: double) = Interop.mkStyle "filter" ("saturate(" + (unbox<string> value) + ")")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline sepia(value: int) = Interop.mkStyle "filter" ("sepia(" + (unbox<string> value) + "%)")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline sepia(value: double) = Interop.mkStyle "filter" ("sepia(" + (unbox<string> value) + ")")
        /// The url() function takes the location of an XML file that specifies an SVG filter, and may include an anchor to a specific filter element.
        ///
        /// Example: `filter: url(svg-url#element-id)`
        static member inline url(value: string) = Interop.mkStyle "filter" ("url(" + value + ")")
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "filter" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "filter" "inherit"
        /// Applies zero or more filters to the same element
        static member inline multiple(filters: seq<IFilter>) =
            let filters = Seq.map unbox<string> filters |> String.concat " "
            Interop.mkStyle "filter" filters

    /// Sets whether table borders should collapse into a single border or be separated as in standard HTML.
    [<Erase>]
    type borderCollapse =
        /// Borders are separated; each cell will display its own borders. This is default.
        static member inline separate = Interop.mkStyle "borderCollapse" "separate"
        /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect)
        static member inline collapse = Interop.mkStyle "borderCollapse" "collapse"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "borderCollapse" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "borderCollapse" "inherit"

    /// Specifies the size of the background images
    [<Erase>]
    type backgroundSize =
        /// Default value. The background image is displayed in its original size
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=auto)
        static member inline auto = Interop.mkStyle "backgroundSize" "auto"
        /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges.
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=cover)
        static member inline cover = Interop.mkStyle "backgroundSize" "cover"
        /// Resize the background image to make sure the image is fully visible
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=contain)
        static member inline contain = Interop.mkStyle "backgroundSize" "contain"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "backgroundSize" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "backgroundSize" "inherit"

    [<Erase>]
    type textDecorationStyle =
        /// Default value. The line will display as a single line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=solid
        static member inline solid = Interop.mkStyle "textDecorationStyle" "solid"
        /// The line will display as a double line.
        ///
        /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=double
        static member inline double = Interop.mkStyle "textDecorationStyle" "double"
        /// The line will display as a dotted line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dotted
        static member inline dotted = Interop.mkStyle "textDecorationStyle" "dotted"
        /// The line will display as a dashed line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dashed
        static member inline dashed = Interop.mkStyle "textDecorationStyle" "dashed"
        /// The line will display as a wavy line.
        ///
        /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=wavy
        static member inline wavy = Interop.mkStyle "textDecorationStyle" "wavy"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=initial
        static member inline initial = Interop.mkStyle "textDecorationStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "textDecorationStyle" "inherit"

    [<Erase>]
    type fontStretch =
        /// Makes the text as narrow as it gets.
        static member inline ultraCondensed = Interop.mkStyle "fontStretch" "ultra-condensed"
        /// Makes the text narrower than condensed, but not as narrow as ultra-condensed
        static member inline extraCondensed = Interop.mkStyle "fontStretch" "extra-condensed"
        /// Makes the text narrower than semi-condensed, but not as narrow as extra-condensed.
        static member inline condensed = Interop.mkStyle "fontStretch" "condensed"
        /// Makes the text narrower than normal, but not as narrow as condensed.
        static member inline semiCondensed = Interop.mkStyle "fontStretch" "semi-condensed"
        /// Default value. No font stretching
        static member inline normal = Interop.mkStyle "fontStretch" "normal"
        /// Makes the text wider than normal, but not as wide as expanded
        static member inline semiExpanded = Interop.mkStyle "fontStretch" "semi-expanded"
        /// Makes the text wider than semi-expanded, but not as wide as extra-expanded
        static member inline expanded = Interop.mkStyle "fontStretch" "expanded"
        /// Makes the text wider than expanded, but not as wide as ultra-expanded
        static member inline extraExpanded = Interop.mkStyle "fontStretch" "extra-expanded"
        /// Makes the text as wide as it gets.
        static member inline ultraExpanded = Interop.mkStyle "fontStretch" "ultra-expanded"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "fontStretch" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "fontStretch" "inherit"

    /// Specifies how an element should float.
    ///
    /// **Note**: Absolutely positioned elements ignores the float property!
    [<Erase>]
    type floatStyle =
        /// The element does not float, (will be displayed just where it occurs in the text). This is default
        static member inline none = Interop.mkStyle "float" "none"
        static member inline left = Interop.mkStyle "float" "left"
        static member inline right = Interop.mkStyle "float" "right"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "float" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "float" "inherit"

    [<Erase>]
    type verticalAlign =
        /// The element is aligned with the baseline of the parent. This is default.
        static member inline baseline = Interop.mkStyle "verticalAlign" "baseline"
        /// The element is aligned with the subscript baseline of the parent
        static member inline sub = Interop.mkStyle "verticalAlign" "sup"
        /// The element is aligned with the superscript baseline of the parent.
        static member inline super = Interop.mkStyle "verticalAlign" "super"
        /// The element is aligned with the top of the tallest element on the line.
        static member inline top = Interop.mkStyle "verticalAlign" "top"
        /// The element is aligned with the top of the parent element's font.
        static member inline textTop = Interop.mkStyle "verticalAlign" "text-top"
        /// The element is placed in the middle of the parent element.
        static member inline middle = Interop.mkStyle "verticalAlign" "middle"
        /// The element is aligned with the lowest element on the line.
        static member inline bottom = Interop.mkStyle "verticalAlign" "bottom"
        /// The element is aligned with the bottom of the parent element's font
        static member inline textBottom = Interop.mkStyle "verticalAlign" "text-bottom"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "verticalAlign" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "verticalAlign" "inherit"

    /// Specifies whether lines of text are laid out horizontally or vertically.
    [<Erase>]
    type writingMode =
        /// Let the content flow horizontally from left to right, vertically from top to bottom
        static member inline horizontalTopBottom = Interop.mkStyle "writingMode" "horizontal-tb"
        /// Let the content flow vertically from top to bottom, horizontally from right to left
        static member inline verticalRightLeft = Interop.mkStyle "writingMode" "vertical-rl"
        /// Let the content flow vertically from top to bottom, horizontally from left to right
        static member inline verticalLeftRight = Interop.mkStyle "writingMode" "vertical-lr"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "writingMode" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "writingMode" "inherit"

    [<Erase>]
    type animationTimingFunction =
        /// Default value. Specifies a animation effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
        static member inline ease = Interop.mkStyle "animationTimingFunction" "ease"
        /// Specifies a animation effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
        static member inline linear = Interop.mkStyle "animationTimingFunction" "linear"
        /// Specifies a animation effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
        static member inline easeIn = Interop.mkStyle "animationTimingFunction" "ease-in"
        /// Specifies a animation effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
        static member inline easeOut = Interop.mkStyle "animationTimingFunction" "ease-out"
        /// Specifies a animation effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
        static member inline easeInOut = Interop.mkStyle "animationTimingFunction" "ease-in-out"
        /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
        static member inline cubicBezier(n1: float, n2: float, n3: float, n4: float) =
            Interop.mkStyle "animationTimingFunction" (
                "cubic-bezier(" + (unbox<string> n1) + "," +
                (unbox<string> n2) + "," +
                (unbox<string> n3) + "," +
                (unbox<string> n4) + ")"
            )
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "animationTimingFunction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "animationTimingFunction" "inherit"

    [<Erase>]
    type transitionTimingFunction =
        /// Default value. Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
        static member inline ease = Interop.mkStyle "transitionTimingFunction" "ease"
        /// Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
        static member inline linear = Interop.mkStyle "transitionTimingFunction" "linear"
        /// Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
        static member inline easeIn = Interop.mkStyle "transitionTimingFunction" "ease-in"
        /// Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
        static member inline easeOut = Interop.mkStyle "transitionTimingFunction" "ease-out"
        /// Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
        static member inline easeInOut = Interop.mkStyle "transitionTimingFunction" "ease-in-out"
        /// Equivalent to steps(1, start)
        static member inline stepStart = Interop.mkStyle "transitionTimingFunction" "step-start"
        /// Equivalent to steps(1, end)
        static member inline stepEnd = Interop.mkStyle "transitionTimingFunction" "step-end"
        static member inline stepsToEnd(steps: int) =
            Interop.mkStyle "transitionTimingFunction" ("steps(" + (unbox<string> steps) + ", end)")
        static member inline stepsToStart(steps: int) =
            Interop.mkStyle "transitionTimingFunction" ("steps(" + (unbox<string> steps) + ", start)")
        /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
        static member inline cubicBezier(n1: float, n2: float, n3: float, n4: float) =
            Interop.mkStyle "transitionTimingFunction" (
                "cubic-bezier(" + (unbox<string> n1) + "," +
                (unbox<string> n2) + "," +
                (unbox<string> n3) + "," +
                (unbox<string> n4) + ")"
            )
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "transitionTimingFunction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "transitionTimingFunction" "inherit"

    [<Erase>]
    type userSelect =
        /// Default. Text can be selected if the browser allows it.
        static member inline auto = Interop.mkStyle "userSelect" "auto"
        /// Prevents text selection.
        static member inline none = Interop.mkStyle "userSelect" "none"
        /// The text can be selected by the user.
        static member inline text = Interop.mkStyle "userSelect" "text"
        /// Text selection is made with one click instead of a double-click.
        static member inline all = Interop.mkStyle "userSelect" "all"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "userSelect" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "userSelect" "inherit"

    [<Erase>]
    type borderStyle =
        /// Specifies a dotted border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline dotted = Interop.mkStyle "borderStyle" "dotted"
        /// Specifies a dashed border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline dashed = Interop.mkStyle "borderStyle" "dashed"
        /// Specifies a solid border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline solid = Interop.mkStyle "borderStyle" "solid"
        /// Specifies a double border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline double = Interop.mkStyle "borderStyle" "double"
        /// Specifies a 3D grooved border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline groove = Interop.mkStyle "borderStyle" "groove"
        /// Specifies a 3D ridged border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline ridge = Interop.mkStyle "borderStyle" "ridge"
        /// Specifies a 3D inset border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline inset = Interop.mkStyle "borderStyle" "inset"
        /// Specifies a 3D outset border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline outset = Interop.mkStyle "borderStyle" "outset"
        /// Default value. Specifies no border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline none = Interop.mkStyle "borderStyle" "none"
        /// The same as "none", except in border conflict resolution for table elements.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        static member inline hidden = Interop.mkStyle "borderStyle" "hidden"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        ///
        /// Read about initial value https://www.w3schools.com/cssref/css_initial.asp
        static member inline initial = Interop.mkStyle "borderStyle" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        ///
        /// Read about inherit https://www.w3schools.com/cssref/css_inherit.asp
        static member inline inheritFromParent = Interop.mkStyle "borderStyle" "inherit"

    /// Defines the algorithm used to lay out table cells, rows, and columns.
    ///
    /// **Tip:** The main benefit of table-layout: fixed; is that the table renders much faster. On large tables,
    /// users will not see any part of the table until the browser has rendered the whole table. So, if you use
    /// table-layout: fixed, users will see the top of the table while the browser loads and renders rest of the
    /// table. This gives the impression that the page loads a lot quicker!
    [<Erase>]
    type tableLayout =
        /// Browsers use an automatic table layout algorithm. The column width is set by the widest unbreakable
        /// content in the cells. The content will dictate the layout
        static member inline auto = Interop.mkStyle "tableLayout" "auto"
        /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col
        /// or by the width of the first row of cells. Cells in other rows do not affect column widths. If no widths
        /// are present on the first row, the column widths are divided equally across the table, regardless of content
        /// inside the cells
        static member inline fixed' = Interop.mkStyle "tableLayout" "fixed"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "tableLayout" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "tableLayout" "inherit"

    [<Erase>]
    type display =
        /// Displays an element as an inline element (like `<span>`). Any height and width properties will have no effect.
        static member inline inlineElement = Interop.mkStyle "display" "inline"
        /// Displays an element as a block element (like `<p>`). It starts on a new line, and takes up the whole width.
        static member inline block = Interop.mkStyle "display" "block"
        /// Makes the container disappear, making the child elements children of the element the next level up in the DOM.
        static member inline contents = Interop.mkStyle "display" "contents"
        /// Displays an element as a block-level flex container.
        static member inline flex = Interop.mkStyle "display" "flex"
        /// Displays an element as a block container box, and lays out its contents using flow layout.
        ///
        /// It always establishes a new block formatting context for its contents.
        static member inline flowRoot = Interop.mkStyle "display" "flow-root"
        /// Displays an element as a block-level grid container.
        static member inline grid = Interop.mkStyle "display" "grid"
        /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values.
        static member inline inlineBlock = Interop.mkStyle "display" "inline-block"
        /// Displays an element as an inline-level flex container.
        static member inline inlineFlex = Interop.mkStyle "display" "inline-flex"
        /// Displays an element as an inline-level grid container
        static member inline inlineGrid = Interop.mkStyle "display" "inline-grid"
        /// The element is displayed as an inline-level table.
        static member inline inlineTable = Interop.mkStyle "display" "inline-table"
        /// Let the element behave like a `<li>` element
        static member inline listItem = Interop.mkStyle "display" "list-item"
        /// Displays an element as either block or inline, depending on context.
        static member inline runIn = Interop.mkStyle "display" "run-in"
        /// Let the element behave like a `<table>` element.
        static member inline table = Interop.mkStyle "display" "table"
        /// Let the element behave like a <caption> element.
        static member inline tableCaption = Interop.mkStyle "display" "table-caption"
        /// Let the element behave like a <colgroup> element.
        static member inline tableColumnGroup = Interop.mkStyle "display" "table-column-group"
        /// Let the element behave like a <thead> element.
        static member inline tableHeaderGroup = Interop.mkStyle "display" "table-header-group"
        /// Let the element behave like a <tfoot> element.
        static member inline tableFooterGroup = Interop.mkStyle "display" "table-footer-group"
        /// Let the element behave like a <tbody> element.
        static member inline tableRowGroup = Interop.mkStyle "display" "table-row-group"
        /// Let the element behave like a <td> element.
        static member inline tableCell = Interop.mkStyle "display" "table-cell"
        /// Let the element behave like a <col> element.
        static member inline tableColumn = Interop.mkStyle "display" "table-column"
        /// Let the element behave like a <tr> element.
        static member inline tableRow = Interop.mkStyle "display" "table-row"
        /// The element is completely removed.
        static member inline none = Interop.mkStyle "display" "none"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "display" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "display" "inherit"

    /// The cursor CSS property sets the type of cursor, if any, to show when the mouse pointer is over an element.
    /// See documentation at https://developer.mozilla.org/en-US/docs/Web/CSS/cursor
    [<Erase>]
    type cursor =
        /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
        static member inline auto = Interop.mkStyle "cursor" "auto"
        /// The cursor indicates an alias of something is to be created
        static member inline alias = Interop.mkStyle "cursor" "alias"
        /// The platform-dependent default cursor. Typically an arrow.
        static member inline defaultCursor = Interop.mkStyle "cursor" "default"
        /// No cursor is rendered.
        static member inline none = Interop.mkStyle "cursor" "none"
        /// A context menu is available.
        static member inline contextMenu = Interop.mkStyle "cursor" "context-menu"
        /// Help information is available.
        static member inline help = Interop.mkStyle "cursor" "help"
        /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
        static member inline pointer = Interop.mkStyle "cursor" "pointer"
        /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
        static member inline progress = Interop.mkStyle "cursor" "progress"
        /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
        static member inline wait = Interop.mkStyle "cursor" "wait"
        /// The table cell or set of cells can be selected.
        static member inline cell = Interop.mkStyle "cursor" "cell"
        /// Cross cursor, often used to indicate selection in a bitmap.
        static member inline crosshair = Interop.mkStyle "cursor" "crosshair"
        /// The text can be selected. Typically the shape of an I-beam.
        static member inline text = Interop.mkStyle "cursor" "text"
        /// The vertical text can be selected. Typically the shape of a sideways I-beam.
        static member inline verticalText = Interop.mkStyle "cursor" "vertical-text"
        /// Something is to be copied.
        static member inline copy = Interop.mkStyle "cursor" "copy"
        /// Something is to be moved.
        static member inline move = Interop.mkStyle "cursor" "move"
        /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
        static member inline noDrop = Interop.mkStyle "cursor" "no-drop"
        /// The requested action will not be carried out.
        static member inline notAllowed = Interop.mkStyle "cursor" "not-allowed"
        /// Something can be grabbed (dragged to be moved).
        static member inline grab = Interop.mkStyle "cursor" "grab"
        /// Something is being grabbed (dragged to be moved).
        static member inline grabbing = Interop.mkStyle "cursor" "grabbing"
        /// Something can be scrolled in any direction (panned).
        static member inline allScroll = Interop.mkStyle "cursor" "all-scroll"
        /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
        static member inline columnResize = Interop.mkStyle "cursor" "col-resize"
        /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
        static member inline rowResize = Interop.mkStyle "cursor" "row-resize"
        /// Directional resize arrow
        static member inline northResize = Interop.mkStyle "cursor" "n-resize"
        /// Directional resize arrow
        static member inline eastResize = Interop.mkStyle "cursor" "e-resize"
        /// Directional resize arrow
        static member inline southResize = Interop.mkStyle "cursor" "s-resize"
        /// Directional resize arrow
        static member inline westResize = Interop.mkStyle "cursor" "w-resize"
        /// Directional resize arrow
        static member inline northEastResize = Interop.mkStyle "cursor" "ne-resize"
        /// Directional resize arrow
        static member inline northWestResize = Interop.mkStyle "cursor" "nw-resize"
        /// Directional resize arrow
        static member inline southEastResize = Interop.mkStyle "cursor" "se-resize"
        /// Directional resize arrow
        static member inline southWestResize = Interop.mkStyle "cursor" "sw-resize"
        /// Directional resize arrow
        static member inline eastWestResize = Interop.mkStyle "cursor" "ew-resize"
        /// Directional resize arrow
        static member inline northSouthResize = Interop.mkStyle "cursor" "ns-resize"
        /// Directional resize arrow
        static member inline northEastSouthWestResize = Interop.mkStyle "cursor" "nesw-resize"
        /// Directional resize arrow
        static member inline northWestSouthEastResize = Interop.mkStyle "cursor" "nwse-resize"
        /// Something can be zoomed (magnified) in
        static member inline zoomIn = Interop.mkStyle "cursor" "zoom-in"
        /// Something can be zoomed out
        static member inline zoomOut = Interop.mkStyle "cursor" "zoom-out"

    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    ///
    /// The outline-style property specifies the style of an outline.
    ///
    /// An outline is a line around an element. It is displayed around the margin of the element. However, it is different from the border property.
    ///
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    [<Erase>]
    type outlineStyle =
        /// Permits the user agent to render a custom outline style.
        static member inline auto = Interop.mkStyle "outlineStyle" "auto"
        /// Specifies no outline. This is default.
        static member inline none = Interop.mkStyle "outlineStyle" "none"
        /// Specifies a hidden outline
        static member inline hidden = Interop.mkStyle "outlineStyle" "hidden"
        /// Specifies a dotted outline
        static member inline dotted = Interop.mkStyle "outlineStyle" "dotted"
        /// Specifies a dashed outline
        static member inline dashed = Interop.mkStyle "outlineStyle" "dashed"
        /// Specifies a solid outline
        static member inline solid = Interop.mkStyle "outlineStyle" "solid"
        /// Specifies a double outliner
        static member inline double = Interop.mkStyle "outlineStyle" "double"
        /// Specifies a 3D grooved outline. The effect depends on the outline-color value
        static member inline groove = Interop.mkStyle "outlineStyle" "groove"
        /// Specifies a 3D ridged outline. The effect depends on the outline-color value
        static member inline ridge = Interop.mkStyle "outlineStyle" "ridge"
        /// Specifies a 3D inset  outline. The effect depends on the outline-color value
        static member inline inset = Interop.mkStyle "outlineStyle" "inset"
        /// Specifies a 3D outset outline. The effect depends on the outline-color value
        static member inline outset = Interop.mkStyle "outlineStyle" "outset"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "outlineStyle" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "outlineStyle" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = Interop.mkStyle "outlineStyle" "unset"

    /// The object-fit CSS property sets how the content of a replaced element, such as an <img> or <video>, should be resized to fit its container.
    [<Erase>]
    type objectFit =
        /// The replaced content is scaled to maintain its aspect ratio while fitting within the element's content box. The entire object is made to fill the box, while preserving its aspect ratio, so the object will be "letterboxed" if its aspect ratio does not match the aspect ratio of the box.
        static member inline contain = Interop.mkStyle "objectFit" "contain"
        /// The replaced content is sized to maintain its aspect ratio while filling the element's entire content box. If the object's aspect ratio does not match the aspect ratio of its box, then the object will be clipped to fit.
        static member inline cover = Interop.mkStyle "objectFit" "cover"
        /// The replaced content is sized to fill the element's content box. The entire object will completely fill the box. If the object's aspect ratio does not match the aspect ratio of its box, then the object will be stretched to fit.
        static member inline fill = Interop.mkStyle "objectFit" "fill"
        /// The replaced content is not resized.
        static member inline none = Interop.mkStyle "objectFit" "none"
        /// The content is sized as if none or contain were specified, whichever would result in a smaller concrete object size.
        static member inline scaleDown = Interop.mkStyle "objectFit" "scale-down"
    
    [<Erase>]
    type backgroundPosition =
        /// The background image will scroll with the page. This is default.
        static member inline scroll = Interop.mkStyle "backgroundPosition" "scroll"
        /// The background image will not scroll with the page.
        static member inline fixedNoScroll = Interop.mkStyle "backgroundPosition" "fixed"
        /// The background image will scroll with the element's contents.
        static member inline local = Interop.mkStyle "backgroundPosition" "local"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "backgroundPosition" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "backgroundPosition" "inherit"

    /// This property defines the blending mode of each background layer (color and/or image).
    [<Erase>]
    type backgroundBlendMode =
        /// This is default. Sets the blending mode to normal.
        static member inline normal = Interop.mkStyle "backgroundBlendMode" "normal"
        /// Sets the blending mode to screen
        static member inline screen = Interop.mkStyle "backgroundBlendMode" "screen"
        /// Sets the blending mode to overlay
        static member inline overlay = Interop.mkStyle "backgroundBlendMode" "overlay"
        /// Sets the blending mode to darken
        static member inline darken = Interop.mkStyle "backgroundBlendMode" "darken"
        /// Sets the blending mode to multiply
        static member inline lighten = Interop.mkStyle "backgroundBlendMode" "lighten"
        /// Sets the blending mode to color-dodge
        static member inline collorDodge = Interop.mkStyle "backgroundBlendMode" "color-dodge"
        /// Sets the blending mode to saturation
        static member inline saturation = Interop.mkStyle "backgroundBlendMode" "saturation"
        /// Sets the blending mode to color
        static member inline color = Interop.mkStyle "backgroundBlendMode" "color"
        /// Sets the blending mode to luminosity
        static member inline luminosity = Interop.mkStyle "backgroundBlendMode" "luminosity"

    /// Defines how far the background (color or image) should extend within an element.
    [<Erase>]
    type backgroundClip =
        /// Default value. The background extends behind the border.
        static member inline borderBox = Interop.mkStyle "backgroundClip" "border-box"
        /// The background extends to the inside edge of the border.
        static member inline paddingBox = Interop.mkStyle "backgroundClip" "padding-box"
        /// The background extends to the edge of the content box.
        static member inline contentBox = Interop.mkStyle "backgroundClip" "content-box"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "backgroundClip" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "backgroundClip" "inherit"

    [<Erase>]
    type transform =
        /// Defines that there should be no transformation.
        static member inline none = Interop.mkStyle "transform" "none"
        /// Defines a 2D transformation, using a matrix of six values.
        static member inline matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
            Interop.mkStyle "transform" (
                "matrix(" +
                (unbox<string> x1) + "," +
                (unbox<string> y1) + "," +
                (unbox<string> z1) + "," +
                (unbox<string> x2) + "," +
                (unbox<string> y2) + "," +
                (unbox<string> z2) + ")"
            )

        /// Defines a 2D translation.
        static member inline translate(x: int, y: int) =
            Interop.mkStyle "transform" (
                "translate(" + (unbox<string> x) + "px," + (unbox<string> y) + "px)"
            )
        /// Defines a 2D translation.
        static member inline translate(x: ICssUnit, y: ICssUnit) =
            Interop.mkStyle "transform" (
                "translate(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )

        /// Defines a 3D translation.
        static member inline translate3D(x: int, y: int, z: int) =
            Interop.mkStyle "transform" (
                "translate3d(" + (unbox<string> x) + "px," + (unbox<string> y) + "px," + (unbox<string> z) + "px)"
            )
        /// Defines a 3D translation.
        static member inline translate3D(x: ICssUnit, y: ICssUnit, z: ICssUnit) =
            Interop.mkStyle "transform" (
                "translate3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: int) =
            Interop.mkStyle "transform" ("translateX(" + (unbox<string> x) + "px)")
        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: ICssUnit) =
            Interop.mkStyle "transform" ("translateX(" + (unbox<string> x) + ")")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: int) =
            Interop.mkStyle "transform" ("translateY(" + (unbox<string> y) + "px)")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: ICssUnit) =
            Interop.mkStyle "transform" ("translateY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: int) =
            Interop.mkStyle "transform" ("translateZ(" + (unbox<string> z) + "px)")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: ICssUnit) =
            Interop.mkStyle "transform" ("translateZ(" + (unbox<string> z) + ")")

        /// Defines a 2D scale transformation.
        static member inline scale(x: int, y: int) =
            Interop.mkStyle "transform" (
                "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )
        /// Defines a scale transformation.
        static member inline scale(n: int) =
            Interop.mkStyle "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a scale transformation.
        static member inline scale(n: float) =
            Interop.mkStyle "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a 3D scale transformation
        static member inline scale3D(x: int, y: int, z: int) =
            Interop.mkStyle "transform" (
                "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a scale transformation by giving a value for the X-axis.
        static member inline scaleX(x: int) =
            Interop.mkStyle "transform" ("scaleX(" + (unbox<string> x) + ")")

        /// Defines a scale transformation by giving a value for the Y-axis.
        static member inline scaleY(y: int) =
            Interop.mkStyle "transform" ("scaleY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline scaleZ(z: int) =
            Interop.mkStyle "transform" ("scaleZ(" + (unbox<string> z) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: int) =
            Interop.mkStyle "transform" ("rotate(" + (unbox<string> deg) + "deg)")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: float) =
            Interop.mkStyle "transform" ("rotate(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: float) =
            Interop.mkStyle "transform" ("rotateX(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: int) =
            Interop.mkStyle "transform" ("rotateX(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: float) =
            Interop.mkStyle "transform" ("rotateY(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: int) =
            Interop.mkStyle "transform" ("rotateY(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: float) =
            Interop.mkStyle "transform" ("rotateZ(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: int) =
            Interop.mkStyle "transform" ("rotateZ(" + (unbox<string> deg) + "deg)")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: int, yAngle: int) =
            Interop.mkStyle "transform" ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: float, yAngle: float) =
            Interop.mkStyle "transform" ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: int) =
            Interop.mkStyle "transform" ("skewX(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: float) =
            Interop.mkStyle "transform" ("skewX(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: int) =
            Interop.mkStyle "transform" ("skewY(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: float) =
            Interop.mkStyle "transform" ("skewY(" + (unbox<string> xAngle) + "deg)")
        /// Defines a perspective view for a 3D transformed element
        static member inline perspective(n: int) =
            Interop.mkStyle "transform" ("perspective(" + (unbox<string> n) + ")")
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "transform" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "transform" "inherit"

    [<Erase>]
    type margin =
        static member inline auto = Interop.mkStyle "margin" "auto"

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<Erase>]
    type direction =
        /// Text direction goes from right-to-left
        static member inline rightToLeft = Interop.mkStyle "direction" "rtl"
        /// Text direction goes from left-to-right. This is default
        static member inline leftToRight = Interop.mkStyle "direction" "ltr"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "direction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "direction" "inherit"

    /// Sets whether or not to display borders on empty cells in a table.
    [<Erase>]
    type emptyCells =
        /// Display borders on empty cells. This is default
        static member inline show = Interop.mkStyle "emptyCells" "show"
        /// Hide borders on empty cells
        static member inline hide = Interop.mkStyle "emptyCells" "hide"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "emptyCells" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "emptyCells" "inherit"


    /// Sets whether or not the animation should play in reverse on alternate cycles.
    [<Erase>]
    type animationDirection =
        /// Default value. The animation should be played as normal
        static member inline normal = Interop.mkStyle "animationDirection" "normal"
        /// The animation should play in reverse direction
        static member inline reverse = Interop.mkStyle "animationDirection" "reverse"
        /// The animation will be played as normal every odd time (1, 3, 5, etc..) and in reverse direction every even time (2, 4, 6, etc...).
        static member inline alternate = Interop.mkStyle "animationDirection" "alternate"
        /// The animation will be played in reverse direction every odd time (1, 3, 5, etc..) and in a normal direction every even time (2,4,6,etc...)
        static member inline alternateReverse = Interop.mkStyle "animationDirection" "alternate-reverse"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "animationDirection" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "animationDirection" "inherit"

    [<Erase>]
    type animationPlayState =
        /// Default value. Specifies that the animation is running.
        static member inline running = Interop.mkStyle "animationPlayState" "running"
        /// Specifies that the animation is paused
        static member inline paused = Interop.mkStyle "animationPlayState" "paused"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "animationPlayState" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "animationPlayState" "inherit"

    [<Erase>]
    type animationIterationCount =
        /// Specifies that the animation should be played infinite times (forever)
        static member inline infinite = Interop.mkStyle "animationIterationCount" "infinite"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "animationIterationCount" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "animationIterationCount" "inherit"

    /// Specifies a style for the element when the animation is not playing (before it starts, after it ends, or both).
    [<Erase>]
    type animationFillMode =
        /// Default value. Animation will not apply any styles to the element before or after it is executing
        static member inline none = Interop.mkStyle "animationFillMode" "none"
        /// The element will retain the style values that is set by the last keyframe (depends on animation-direction and animation-iteration-count).
        static member inline forwards = Interop.mkStyle "animationFillMode" "forwards"
        /// The element will get the style values that is set by the first keyframe (depends on animation-direction), and retain this during the animation-delay period
        static member inline backwards = Interop.mkStyle "animationFillMode" "backwards"
        /// The animation will follow the rules for both forwards and backwards, extending the animation properties in both directions
        static member inline both = Interop.mkStyle "animationFillMode" "both"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "animationFillMode" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "animationFillMode" "inherit"

    [<Erase>]
    type backgroundRepeat =
        /// The background image is repeated both vertically and horizontally. This is default.
        static member inline repeat = Interop.mkStyle "backgroundRepeat" "repeat"
        /// The background image is only repeated horizontally.
        static member inline repeatX = Interop.mkStyle "backgroundRepeat" "repeat-x"
        /// The background image is only repeated vertically.
        static member inline repeatY = Interop.mkStyle "backgroundRepeat" "repeat-y"
        /// The background-image is not repeated.
        static member inline noRepeat = Interop.mkStyle "backgroundRepeat" "no-repeat"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "backgroundRepeat" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "backgroundRepeat" "inherit"

    [<Erase>]
    type position =
        /// Default value. Elements render in order, as they appear in the document flow.
        static member inline defaultStatic = Interop.mkStyle "position" "static"
        /// The element is positioned relative to its first positioned (not static) ancestor element.
        static member inline absolute = Interop.mkStyle "position" "absolute"
        /// The element is positioned relative to the browser window
        static member inline fixedRelativeToWindow = Interop.mkStyle "position" "fixed"
        /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position.
        static member inline relative = Interop.mkStyle "position" "relative"
        /// The element is positioned based on the user's scroll position
        ///
        /// A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed).
        ///
        /// Note: Not supported in IE/Edge 15 or earlier. Supported in Safari from version 6.1 with a -webkit- prefix.
        static member inline sticky = Interop.mkStyle "position" "sticky"
        static member inline initial = Interop.mkStyle "position" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "position" "inherit"


    [<Erase>]
    type order =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "order" "inherit"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "order" "initial"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "order" "unset"
        static member inline revert = Interop.mkStyle "order" "revert"
        static member inline revertLayer = Interop.mkStyle "order" "revert-layer"

    /// Sets how the total width and height of an element is calculated.
    [<Erase>]
    type boxSizing =
        /// Default value. The width and height properties include the content, but does not include the padding, border, or margin.
        static member inline contentBox = Interop.mkStyle "boxSizing" "content-box"
        /// The width and height properties include the content, padding, and border, but do not include the margin. Note that padding and border will be inside of the box.
        static member inline borderBox = Interop.mkStyle "boxSizing" "border-box"

    /// Sets under what circumstances (if any) a particular graphics element can become the target of pointer events.
    [<Erase>]
    type pointerEvents =
        /// Default value. The element behaves as it would if the pointer-events property were not specified.
        static member inline auto = Interop.mkStyle "pointerEvents" "auto"
        /// The element is never the target of pointer events; however, pointer events may target its descendant elements if those descendants have pointer-events set to some other value.
        static member inline none = Interop.mkStyle "pointerEvents" "none"
        static member inline initial = Interop.mkStyle "pointerEvents" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = Interop.mkStyle "pointerEvents" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "pointerEvents" "unset"

    /// Sets whether an element is resizable, and if so, in which directions.
    [<Erase>]
    type resize =
        /// Default value. The element offers no user-controllable method for resizing it.
        static member inline none = Interop.mkStyle "resize" "none"
        /// The element displays a mechanism for allowing the user to resize it, which may be resized both horizontally and vertically.
        static member inline both = Interop.mkStyle "resize" "both"
        /// The element displays a mechanism for allowing the user to resize it in the horizontal direction.
        static member inline horizontal = Interop.mkStyle "resize" "horizontal"
        /// The element displays a mechanism for allowing the user to resize it in the vertical direction.
        static member inline vertical = Interop.mkStyle "resize" "vertical"
        /// The element displays a mechanism for allowing the user to resize it in the block direction (either horizontally or vertically, depending on the writing-mode and direction value).
        static member inline block = Interop.mkStyle "resize" "block"
        /// The element displays a mechanism for allowing the user to resize it in the inline direction (either horizontally or vertically, depending on the writing-mode and direction value).
        static member inline inline' = Interop.mkStyle "resize" "inline"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "resize" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "resize" "inherit"

    /// Sets the break-before property of an element.
    ///
    /// The break-before CSS property sets how page, column, or region breaks should behave before a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakBefore =
        /// Allows, but does not force, any break (page, column, or region) to be inserted right before the principal box.
        static member inline auto = Interop.mkStyle "breakBefore" "auto"
        /// Avoids any break (page, column, or region) from being inserted right before the principal box.
        static member inline avoid = Interop.mkStyle "breakBefore" "avoid"
        /// Forces a page break right after the principal box. The type of this break is that of the immediately-containing fragmentation context. If we are inside a multicol container then it would force a column break, inside paged media (but not inside a multicol container) a page break.
        static member inline always = Interop.mkStyle "breakBefore" "always"
        /// Forces a page break right after the principal box. Breaking through all possible fragmentation contexts. So a break inside a multicol container, which was inside a page container would force a column and page break.
        static member inline all = Interop.mkStyle "breakBefore" "all"
        /// Avoids any page break right before the principal box.
        static member inline avoidPage = Interop.mkStyle "breakBefore" "avoid-page"
        /// Forces a page break right before the principal box.
        static member inline page = Interop.mkStyle "breakBefore" "page"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a left page.
        static member inline left = Interop.mkStyle "breakBefore" "left"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a right page.
        static member inline right = Interop.mkStyle "breakBefore" "right"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a recto page. (A recto page is a right page in a left-to-right spread or a left page in a right-to-left spread.)
        static member inline recto = Interop.mkStyle "breakBefore" "recto"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a verso page. (A verso page is a left page in a left-to-right spread or a right page in a right-to-left spread.)
        static member inline verso = Interop.mkStyle "breakBefore" "verso"
        /// Avoids any column break right before the principal box.
        static member inline avoidColumn = Interop.mkStyle "breakBefore" "avoid-column"
        /// Forces a column break right before the principal box.
        static member inline column = Interop.mkStyle "breakBefore" "column"
        /// Avoids any region break right before the principal box.
        static member inline avoidRegion = Interop.mkStyle "breakBefore" "avoid-region"
        /// Forces a region break right before the principal box.
        static member inline region = Interop.mkStyle "breakBefore" "region"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "breakBefore" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "breakBefore" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = Interop.mkStyle "breakBefore" "unset"

    /// Sets the break-after property of an element.
    ///
    /// The break-after CSS property sets how page, column, or region breaks should behave after a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakAfter =
        /// Allows, but does not force, any break (page, column, or region) to be inserted right after the principal box.
        static member inline auto = Interop.mkStyle "breakAfter" "auto"
        /// Avoids any break (page, column, or region) from being inserted right after the principal box.
        static member inline avoid = Interop.mkStyle "breakAfter" "avoid"
        /// Forces a page break right after the principal box. The type of this break is that of the immediately-containing fragmentation context. If we are inside a multicol container then it would force a column break, inside paged media (but not inside a multicol container) a page break.
        static member inline always = Interop.mkStyle "breakAfter" "always"
        /// Forces a page break right after the principal box. Breaking through all possible fragmentation contexts. So a break inside a multicol container, which was inside a page container would force a column and page break.
        static member inline all = Interop.mkStyle "breakAfter" "all"
        /// Avoids any page break right after the principal box.
        static member inline avoidPage = Interop.mkStyle "breakAfter" "avoid-page"
        /// Forces a page break right after the principal box.
        static member inline page = Interop.mkStyle "breakAfter" "page"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a left page.
        static member inline left = Interop.mkStyle "breakAfter" "left"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a right page.
        static member inline right = Interop.mkStyle "breakAfter" "right"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a recto page. (A recto page is a right page in a left-to-right spread or a left page in a right-to-left spread.)
        static member inline recto = Interop.mkStyle "breakAfter" "recto"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a verso page. (A verso page is a left page in a left-to-right spread or a right page in a right-to-left spread.)
        static member inline verso = Interop.mkStyle "breakAfter" "verso"
        /// Avoids any column break right after the principal box.
        static member inline avoidColumn = Interop.mkStyle "breakAfter" "avoid-column"
        /// Forces a column break right after the principal box.
        static member inline column = Interop.mkStyle "breakAfter" "column"
        /// Avoids any region break right after the principal box.
        static member inline avoidRegion = Interop.mkStyle "breakAfter" "avoid-region"
        /// Forces a region break right after the principal box.
        static member inline region = Interop.mkStyle "breakAfter" "region"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "breakAfter" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "breakAfter" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = Interop.mkStyle "breakAfter" "unset"
    
    /// Sets the break-inside property of an element.
    ///
    /// The break-inside CSS property sets how page, column, or region breaks should behave inside a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakInside =
        /// Allows, but does not force, any break (page, column, or region) to be inserted within the principal box.
        static member inline auto = Interop.mkStyle "breakInside" "auto"
        /// Avoids any break (page, column, or region) from being inserted within the principal box.
        static member inline avoid = Interop.mkStyle "breakInside" "avoid"
        /// Avoids any page break within the principal box.
        static member inline avoidPage = Interop.mkStyle "breakInside" "avoid-page"
        /// Avoids any column break within the principal box.
        static member inline avoidColumn = Interop.mkStyle "breakInside" "avoid-column"
        /// Avoids any region break within the principal box.
        static member inline avoidRegion = Interop.mkStyle "breakInside" "avoid-region"
        /// Sets this property to its default value.
        static member inline initial = Interop.mkStyle "breakInside" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "breakInside" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = Interop.mkStyle "breakInside" "unset"
    
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    [<Erase>]
    type transformOrigin =        
        static member inline initial = Interop.mkStyle "transformOrigin" "initial"
        static member inline inheritFromParent = Interop.mkStyle "transformOrigin" "inherit"
        static member inline revert = Interop.mkStyle "transformOrigin" "revert"
        static member inline revertLayer = Interop.mkStyle "transformOrigin" "revertLayer"
        static member inline unset = Interop.mkStyle "transformOrigin" "unset"

    /// Sets the background color of an element.
    [<Erase; RequireQualifiedAccess>]
    type backgroundColor =
        static member inline indianRed = Interop.mkStyle "backgroundColor" "#CD5C5C"
        static member inline lightCoral = Interop.mkStyle "backgroundColor" "#F08080"
        static member inline salmon = Interop.mkStyle "backgroundColor" "#FA8072"
        static member inline darkSalmon = Interop.mkStyle "backgroundColor" "#E9967A"
        static member inline lightSalmon = Interop.mkStyle "backgroundColor" "#FFA07A"
        static member inline crimson = Interop.mkStyle "backgroundColor" "#DC143C"
        static member inline red = Interop.mkStyle "backgroundColor" "#FF0000"
        static member inline fireBrick = Interop.mkStyle "backgroundColor" "#B22222"
        static member inline darkred = Interop.mkStyle "backgroundColor" "#8B0000"
        static member inline pink = Interop.mkStyle "backgroundColor" "#FFC0CB"
        static member inline lightPink = Interop.mkStyle "backgroundColor" "#FFB6C1"
        static member inline hotPink = Interop.mkStyle "backgroundColor" "#FF69B4"
        static member inline deepPink = Interop.mkStyle "backgroundColor" "#FF1493"
        static member inline mediumVioletRed = Interop.mkStyle "backgroundColor" "#C71585"
        static member inline paleVioletRed = Interop.mkStyle "backgroundColor" "#DB7093"
        static member inline coral = Interop.mkStyle "backgroundColor" "#FF7F50"
        static member inline tomato = Interop.mkStyle "backgroundColor" "#FF6347"
        static member inline orangeRed = Interop.mkStyle "backgroundColor" "#FF4500"
        static member inline darkOrange = Interop.mkStyle "backgroundColor" "#FF8C00"
        static member inline orange = Interop.mkStyle "backgroundColor" "#FFA500"
        static member inline gold = Interop.mkStyle "backgroundColor" "#FFD700"
        static member inline yellow = Interop.mkStyle "backgroundColor" "#FFFF00"
        static member inline lightYellow = Interop.mkStyle "backgroundColor" "#FFFFE0"
        static member inline limonChiffon = Interop.mkStyle "backgroundColor" "#FFFACD"
        static member inline lightGoldenRodYellow = Interop.mkStyle "backgroundColor" "#FAFAD2"
        static member inline papayaWhip = Interop.mkStyle "backgroundColor" "#FFEFD5"
        static member inline moccasin = Interop.mkStyle "backgroundColor" "#FFE4B5"
        static member inline peachPuff = Interop.mkStyle "backgroundColor" "#FFDAB9"
        static member inline paleGoldenRod = Interop.mkStyle "backgroundColor" "#EEE8AA"
        static member inline khaki = Interop.mkStyle "backgroundColor" "#F0E68C"
        static member inline darkKhaki = Interop.mkStyle "backgroundColor" "#BDB76B"
        static member inline lavender = Interop.mkStyle "backgroundColor" "#E6E6FA"
        static member inline thistle = Interop.mkStyle "backgroundColor" "#D8BFD8"
        static member inline plum = Interop.mkStyle "backgroundColor" "#DDA0DD"
        static member inline violet = Interop.mkStyle "backgroundColor" "#EE82EE"
        static member inline orchid = Interop.mkStyle "backgroundColor" "#DA70D6"
        static member inline fuchsia = Interop.mkStyle "backgroundColor" "#FF00FF"
        static member inline magenta = Interop.mkStyle "backgroundColor" "#FF00FF"
        static member inline mediumOrchid = Interop.mkStyle "backgroundColor" "#BA55D3"
        static member inline mediumPurple = Interop.mkStyle "backgroundColor" "#9370DB"
        static member inline rebeccaPurple = Interop.mkStyle "backgroundColor" "#663399"
        static member inline blueViolet = Interop.mkStyle "backgroundColor" "#8A2BE2"
        static member inline darkViolet = Interop.mkStyle "backgroundColor" "#9400D3"
        static member inline darkOrchid = Interop.mkStyle "backgroundColor" "#9932CC"
        static member inline darkMagenta = Interop.mkStyle "backgroundColor" "#8B008B"
        static member inline purple = Interop.mkStyle "backgroundColor" "#800080"
        static member inline indigo = Interop.mkStyle "backgroundColor" "#4B0082"
        static member inline slateBlue = Interop.mkStyle "backgroundColor" "#6A5ACD"
        static member inline darkSlateBlue = Interop.mkStyle "backgroundColor" "#483D8B"
        static member inline mediumSlateBlue = Interop.mkStyle "backgroundColor" "#7B68EE"
        static member inline greenYellow = Interop.mkStyle "backgroundColor" "#ADFF2F"
        static member inline chartreuse = Interop.mkStyle "backgroundColor" "#7FFF00"
        static member inline lawnGreen = Interop.mkStyle "backgroundColor" "#7CFC00"
        static member inline lime = Interop.mkStyle "backgroundColor" "#00FF00"
        static member inline limeGreen = Interop.mkStyle "backgroundColor" "#32CD32"
        static member inline paleGreen = Interop.mkStyle "backgroundColor" "#98FB98"
        static member inline lightGreen = Interop.mkStyle "backgroundColor" "#90EE90"
        static member inline mediumSpringGreen = Interop.mkStyle "backgroundColor" "#00FA9A"
        static member inline springGreen = Interop.mkStyle "backgroundColor" "#00FF7F"
        static member inline mediumSeaGreen = Interop.mkStyle "backgroundColor" "#3CB371"
        static member inline seaGreen = Interop.mkStyle "backgroundColor" "#2E8B57"
        static member inline forestGreen = Interop.mkStyle "backgroundColor" "#228B22"
        static member inline green = Interop.mkStyle "backgroundColor" "#008000"
        static member inline darkGreen = Interop.mkStyle "backgroundColor" "#006400"
        static member inline yellowGreen = Interop.mkStyle "backgroundColor" "#9ACD32"
        static member inline oliveDrab = Interop.mkStyle "backgroundColor" "#6B8E23"
        static member inline olive = Interop.mkStyle "backgroundColor" "#808000"
        static member inline darkOliveGreen = Interop.mkStyle "backgroundColor" "#556B2F"
        static member inline mediumAquamarine = Interop.mkStyle "backgroundColor" "#66CDAA"
        static member inline darkSeaGreen = Interop.mkStyle "backgroundColor" "#8FBC8B"
        static member inline lightSeaGreen = Interop.mkStyle "backgroundColor" "#20B2AA"
        static member inline darkCyan = Interop.mkStyle "backgroundColor" "#008B8B"
        static member inline teal = Interop.mkStyle "backgroundColor" "#008080"
        static member inline aqua = Interop.mkStyle "backgroundColor" "#00FFFF"
        static member inline cyan = Interop.mkStyle "backgroundColor" "#00FFFF"
        static member inline lightCyan = Interop.mkStyle "backgroundColor" "#E0FFFF"
        static member inline paleTurqouise = Interop.mkStyle "backgroundColor" "#AFEEEE"
        static member inline aquaMarine = Interop.mkStyle "backgroundColor" "#7FFFD4"
        static member inline turqouise = Interop.mkStyle "backgroundColor" "#AFEEEE"
        static member inline mediumTurqouise = Interop.mkStyle "backgroundColor" "#48D1CC"
        static member inline darkTurqouise = Interop.mkStyle "backgroundColor" "#00CED1"
        static member inline cadetBlue = Interop.mkStyle "backgroundColor" "#5F9EA0"
        static member inline steelBlue = Interop.mkStyle "backgroundColor" "#4682B4"
        static member inline lightSteelBlue = Interop.mkStyle "backgroundColor" "#B0C4DE"
        static member inline powederBlue = Interop.mkStyle "backgroundColor" "#B0E0E6"
        static member inline lightBlue = Interop.mkStyle "backgroundColor" "#ADD8E6"
        static member inline skyBlue = Interop.mkStyle "backgroundColor" "#87CEEB"
        static member inline lightSkyBlue = Interop.mkStyle "backgroundColor" "#87CEFA"
        static member inline deepSkyBlue = Interop.mkStyle "backgroundColor" "#00BFFF"
        static member inline dodgerBlue = Interop.mkStyle "backgroundColor" "#1E90FF"
        static member inline cornFlowerBlue = Interop.mkStyle "backgroundColor" "#6495ED"
        static member inline royalBlue = Interop.mkStyle "backgroundColor" "#4169E1"
        static member inline blue = Interop.mkStyle "backgroundColor" "#0000FF"
        static member inline mediumBlue = Interop.mkStyle "backgroundColor" "#0000CD"
        static member inline darkBlue = Interop.mkStyle "backgroundColor" "#00008B"
        static member inline navy = Interop.mkStyle "backgroundColor" "#000080"
        static member inline midnightBlue = Interop.mkStyle "backgroundColor" "#191970"
        static member inline cornSilk = Interop.mkStyle "backgroundColor" "#FFF8DC"
        static member inline blanchedAlmond = Interop.mkStyle "backgroundColor" "#FFEBCD"
        static member inline bisque = Interop.mkStyle "backgroundColor" "#FFE4C4"
        static member inline navajoWhite = Interop.mkStyle "backgroundColor" "#FFDEAD"
        static member inline wheat = Interop.mkStyle "backgroundColor" "#F5DEB3"
        static member inline burlyWood = Interop.mkStyle "backgroundColor" "#DEB887"
        static member inline tan = Interop.mkStyle "backgroundColor" "#D2B48C"
        static member inline rosyBrown = Interop.mkStyle "backgroundColor" "#BC8F8F"
        static member inline sandyBrown = Interop.mkStyle "backgroundColor" "#F4A460"
        static member inline goldenRod = Interop.mkStyle "backgroundColor" "#DAA520"
        static member inline darkGoldenRod = Interop.mkStyle "backgroundColor" "#B8860B"
        static member inline peru = Interop.mkStyle "backgroundColor" "#CD853F"
        static member inline chocolate = Interop.mkStyle "backgroundColor" "#D2691E"
        static member inline saddleBrown = Interop.mkStyle "backgroundColor" "#8B4513"
        static member inline sienna = Interop.mkStyle "backgroundColor" "#A0522D"
        static member inline brown = Interop.mkStyle "backgroundColor" "#A52A2A"
        static member inline maroon = Interop.mkStyle "backgroundColor" "#A52A2A"
        static member inline white = Interop.mkStyle "backgroundColor" "#FFFFFF"
        static member inline snow = Interop.mkStyle "backgroundColor" "#FFFAFA"
        static member inline honeyDew = Interop.mkStyle "backgroundColor" "#F0FFF0"
        static member inline mintCream = Interop.mkStyle "backgroundColor" "#F5FFFA"
        static member inline azure = Interop.mkStyle "backgroundColor" "#F0FFFF"
        static member inline aliceBlue = Interop.mkStyle "backgroundColor" "#F0F8FF"
        static member inline ghostWhite = Interop.mkStyle "backgroundColor" "#F8F8FF"
        static member inline whiteSmoke = Interop.mkStyle "backgroundColor" "#F5F5F5"
        static member inline seaShell = Interop.mkStyle "backgroundColor" "#FFF5EE"
        static member inline beige = Interop.mkStyle "backgroundColor" "#F5F5DC"
        static member inline oldLace = Interop.mkStyle "backgroundColor" "#FDF5E6"
        static member inline floralWhite = Interop.mkStyle "backgroundColor" "#FFFAF0"
        static member inline ivory = Interop.mkStyle "backgroundColor" "#FFFFF0"
        static member inline antiqueWhite = Interop.mkStyle "backgroundColor" "#FAEBD7"
        static member inline linen = Interop.mkStyle "backgroundColor" "#FAF0E6"
        static member inline lavenderBlush = Interop.mkStyle "backgroundColor" "#FFF0F5"
        static member inline mistyRose = Interop.mkStyle "backgroundColor" "#FFE4E1"
        static member inline gainsBoro = Interop.mkStyle "backgroundColor" "#DCDCDC"
        static member inline lightGray = Interop.mkStyle "backgroundColor" "#D3D3D3"
        static member inline silver = Interop.mkStyle "backgroundColor" "#C0C0C0"
        static member inline darkGray = Interop.mkStyle "backgroundColor" "#A9A9A9"
        static member inline gray = Interop.mkStyle "backgroundColor" "#808080"
        static member inline dimGray = Interop.mkStyle "backgroundColor" "#696969"
        static member inline lightSlateGray = Interop.mkStyle "backgroundColor" "#778899"
        static member inline slateGray = Interop.mkStyle "backgroundColor" "#708090"
        static member inline darkSlateGray = Interop.mkStyle "backgroundColor" "#2F4F4F"
        static member inline black = Interop.mkStyle "backgroundColor" "#000000"
        static member inline transparent = Interop.mkStyle "backgroundColor" "transparent"

    /// Sets the color of an element's border.
    [<Erase; RequireQualifiedAccess>]
    type borderColor =
        static member inline indianRed = Interop.mkStyle "borderColor" "#CD5C5C"
        static member inline lightCoral = Interop.mkStyle "borderColor" "#F08080"
        static member inline salmon = Interop.mkStyle "borderColor" "#FA8072"
        static member inline darkSalmon = Interop.mkStyle "borderColor" "#E9967A"
        static member inline lightSalmon = Interop.mkStyle "borderColor" "#FFA07A"
        static member inline crimson = Interop.mkStyle "borderColor" "#DC143C"
        static member inline red = Interop.mkStyle "borderColor" "#FF0000"
        static member inline fireBrick = Interop.mkStyle "borderColor" "#B22222"
        static member inline darkred = Interop.mkStyle "borderColor" "#8B0000"
        static member inline pink = Interop.mkStyle "borderColor" "#FFC0CB"
        static member inline lightPink = Interop.mkStyle "borderColor" "#FFB6C1"
        static member inline hotPink = Interop.mkStyle "borderColor" "#FF69B4"
        static member inline deepPink = Interop.mkStyle "borderColor" "#FF1493"
        static member inline mediumVioletRed = Interop.mkStyle "borderColor" "#C71585"
        static member inline paleVioletRed = Interop.mkStyle "borderColor" "#DB7093"
        static member inline coral = Interop.mkStyle "borderColor" "#FF7F50"
        static member inline tomato = Interop.mkStyle "borderColor" "#FF6347"
        static member inline orangeRed = Interop.mkStyle "borderColor" "#FF4500"
        static member inline darkOrange = Interop.mkStyle "borderColor" "#FF8C00"
        static member inline orange = Interop.mkStyle "borderColor" "#FFA500"
        static member inline gold = Interop.mkStyle "borderColor" "#FFD700"
        static member inline yellow = Interop.mkStyle "borderColor" "#FFFF00"
        static member inline lightYellow = Interop.mkStyle "borderColor" "#FFFFE0"
        static member inline limonChiffon = Interop.mkStyle "borderColor" "#FFFACD"
        static member inline lightGoldenRodYellow = Interop.mkStyle "borderColor" "#FAFAD2"
        static member inline papayaWhip = Interop.mkStyle "borderColor" "#FFEFD5"
        static member inline moccasin = Interop.mkStyle "borderColor" "#FFE4B5"
        static member inline peachPuff = Interop.mkStyle "borderColor" "#FFDAB9"
        static member inline paleGoldenRod = Interop.mkStyle "borderColor" "#EEE8AA"
        static member inline khaki = Interop.mkStyle "borderColor" "#F0E68C"
        static member inline darkKhaki = Interop.mkStyle "borderColor" "#BDB76B"
        static member inline lavender = Interop.mkStyle "borderColor" "#E6E6FA"
        static member inline thistle = Interop.mkStyle "borderColor" "#D8BFD8"
        static member inline plum = Interop.mkStyle "borderColor" "#DDA0DD"
        static member inline violet = Interop.mkStyle "borderColor" "#EE82EE"
        static member inline orchid = Interop.mkStyle "borderColor" "#DA70D6"
        static member inline fuchsia = Interop.mkStyle "borderColor" "#FF00FF"
        static member inline magenta = Interop.mkStyle "borderColor" "#FF00FF"
        static member inline mediumOrchid = Interop.mkStyle "borderColor" "#BA55D3"
        static member inline mediumPurple = Interop.mkStyle "borderColor" "#9370DB"
        static member inline rebeccaPurple = Interop.mkStyle "borderColor" "#663399"
        static member inline blueViolet = Interop.mkStyle "borderColor" "#8A2BE2"
        static member inline darkViolet = Interop.mkStyle "borderColor" "#9400D3"
        static member inline darkOrchid = Interop.mkStyle "borderColor" "#9932CC"
        static member inline darkMagenta = Interop.mkStyle "borderColor" "#8B008B"
        static member inline purple = Interop.mkStyle "borderColor" "#800080"
        static member inline indigo = Interop.mkStyle "borderColor" "#4B0082"
        static member inline slateBlue = Interop.mkStyle "borderColor" "#6A5ACD"
        static member inline darkSlateBlue = Interop.mkStyle "borderColor" "#483D8B"
        static member inline mediumSlateBlue = Interop.mkStyle "borderColor" "#7B68EE"
        static member inline greenYellow = Interop.mkStyle "borderColor" "#ADFF2F"
        static member inline chartreuse = Interop.mkStyle "borderColor" "#7FFF00"
        static member inline lawnGreen = Interop.mkStyle "borderColor" "#7CFC00"
        static member inline lime = Interop.mkStyle "borderColor" "#00FF00"
        static member inline limeGreen = Interop.mkStyle "borderColor" "#32CD32"
        static member inline paleGreen = Interop.mkStyle "borderColor" "#98FB98"
        static member inline lightGreen = Interop.mkStyle "borderColor" "#90EE90"
        static member inline mediumSpringGreen = Interop.mkStyle "borderColor" "#00FA9A"
        static member inline springGreen = Interop.mkStyle "borderColor" "#00FF7F"
        static member inline mediumSeaGreen = Interop.mkStyle "borderColor" "#3CB371"
        static member inline seaGreen = Interop.mkStyle "borderColor" "#2E8B57"
        static member inline forestGreen = Interop.mkStyle "borderColor" "#228B22"
        static member inline green = Interop.mkStyle "borderColor" "#008000"
        static member inline darkGreen = Interop.mkStyle "borderColor" "#006400"
        static member inline yellowGreen = Interop.mkStyle "borderColor" "#9ACD32"
        static member inline oliveDrab = Interop.mkStyle "borderColor" "#6B8E23"
        static member inline olive = Interop.mkStyle "borderColor" "#808000"
        static member inline darkOliveGreen = Interop.mkStyle "borderColor" "#556B2F"
        static member inline mediumAquamarine = Interop.mkStyle "borderColor" "#66CDAA"
        static member inline darkSeaGreen = Interop.mkStyle "borderColor" "#8FBC8B"
        static member inline lightSeaGreen = Interop.mkStyle "borderColor" "#20B2AA"
        static member inline darkCyan = Interop.mkStyle "borderColor" "#008B8B"
        static member inline teal = Interop.mkStyle "borderColor" "#008080"
        static member inline aqua = Interop.mkStyle "borderColor" "#00FFFF"
        static member inline cyan = Interop.mkStyle "borderColor" "#00FFFF"
        static member inline lightCyan = Interop.mkStyle "borderColor" "#E0FFFF"
        static member inline paleTurqouise = Interop.mkStyle "borderColor" "#AFEEEE"
        static member inline aquaMarine = Interop.mkStyle "borderColor" "#7FFFD4"
        static member inline turqouise = Interop.mkStyle "borderColor" "#AFEEEE"
        static member inline mediumTurqouise = Interop.mkStyle "borderColor" "#48D1CC"
        static member inline darkTurqouise = Interop.mkStyle "borderColor" "#00CED1"
        static member inline cadetBlue = Interop.mkStyle "borderColor" "#5F9EA0"
        static member inline steelBlue = Interop.mkStyle "borderColor" "#4682B4"
        static member inline lightSteelBlue = Interop.mkStyle "borderColor" "#B0C4DE"
        static member inline powederBlue = Interop.mkStyle "borderColor" "#B0E0E6"
        static member inline lightBlue = Interop.mkStyle "borderColor" "#ADD8E6"
        static member inline skyBlue = Interop.mkStyle "borderColor" "#87CEEB"
        static member inline lightSkyBlue = Interop.mkStyle "borderColor" "#87CEFA"
        static member inline deepSkyBlue = Interop.mkStyle "borderColor" "#00BFFF"
        static member inline dodgerBlue = Interop.mkStyle "borderColor" "#1E90FF"
        static member inline cornFlowerBlue = Interop.mkStyle "borderColor" "#6495ED"
        static member inline royalBlue = Interop.mkStyle "borderColor" "#4169E1"
        static member inline blue = Interop.mkStyle "borderColor" "#0000FF"
        static member inline mediumBlue = Interop.mkStyle "borderColor" "#0000CD"
        static member inline darkBlue = Interop.mkStyle "borderColor" "#00008B"
        static member inline navy = Interop.mkStyle "borderColor" "#000080"
        static member inline midnightBlue = Interop.mkStyle "borderColor" "#191970"
        static member inline cornSilk = Interop.mkStyle "borderColor" "#FFF8DC"
        static member inline blanchedAlmond = Interop.mkStyle "borderColor" "#FFEBCD"
        static member inline bisque = Interop.mkStyle "borderColor" "#FFE4C4"
        static member inline navajoWhite = Interop.mkStyle "borderColor" "#FFDEAD"
        static member inline wheat = Interop.mkStyle "borderColor" "#F5DEB3"
        static member inline burlyWood = Interop.mkStyle "borderColor" "#DEB887"
        static member inline tan = Interop.mkStyle "borderColor" "#D2B48C"
        static member inline rosyBrown = Interop.mkStyle "borderColor" "#BC8F8F"
        static member inline sandyBrown = Interop.mkStyle "borderColor" "#F4A460"
        static member inline goldenRod = Interop.mkStyle "borderColor" "#DAA520"
        static member inline darkGoldenRod = Interop.mkStyle "borderColor" "#B8860B"
        static member inline peru = Interop.mkStyle "borderColor" "#CD853F"
        static member inline chocolate = Interop.mkStyle "borderColor" "#D2691E"
        static member inline saddleBrown = Interop.mkStyle "borderColor" "#8B4513"
        static member inline sienna = Interop.mkStyle "borderColor" "#A0522D"
        static member inline brown = Interop.mkStyle "borderColor" "#A52A2A"
        static member inline maroon = Interop.mkStyle "borderColor" "#A52A2A"
        static member inline white = Interop.mkStyle "borderColor" "#FFFFFF"
        static member inline snow = Interop.mkStyle "borderColor" "#FFFAFA"
        static member inline honeyDew = Interop.mkStyle "borderColor" "#F0FFF0"
        static member inline mintCream = Interop.mkStyle "borderColor" "#F5FFFA"
        static member inline azure = Interop.mkStyle "borderColor" "#F0FFFF"
        static member inline aliceBlue = Interop.mkStyle "borderColor" "#F0F8FF"
        static member inline ghostWhite = Interop.mkStyle "borderColor" "#F8F8FF"
        static member inline whiteSmoke = Interop.mkStyle "borderColor" "#F5F5F5"
        static member inline seaShell = Interop.mkStyle "borderColor" "#FFF5EE"
        static member inline beige = Interop.mkStyle "borderColor" "#F5F5DC"
        static member inline oldLace = Interop.mkStyle "borderColor" "#FDF5E6"
        static member inline floralWhite = Interop.mkStyle "borderColor" "#FFFAF0"
        static member inline ivory = Interop.mkStyle "borderColor" "#FFFFF0"
        static member inline antiqueWhite = Interop.mkStyle "borderColor" "#FAEBD7"
        static member inline linen = Interop.mkStyle "borderColor" "#FAF0E6"
        static member inline lavenderBlush = Interop.mkStyle "borderColor" "#FFF0F5"
        static member inline mistyRose = Interop.mkStyle "borderColor" "#FFE4E1"
        static member inline gainsBoro = Interop.mkStyle "borderColor" "#DCDCDC"
        static member inline lightGray = Interop.mkStyle "borderColor" "#D3D3D3"
        static member inline silver = Interop.mkStyle "borderColor" "#C0C0C0"
        static member inline darkGray = Interop.mkStyle "borderColor" "#A9A9A9"
        static member inline gray = Interop.mkStyle "borderColor" "#808080"
        static member inline dimGray = Interop.mkStyle "borderColor" "#696969"
        static member inline lightSlateGray = Interop.mkStyle "borderColor" "#778899"
        static member inline slateGray = Interop.mkStyle "borderColor" "#708090"
        static member inline darkSlateGray = Interop.mkStyle "borderColor" "#2F4F4F"
        static member inline black = Interop.mkStyle "borderColor" "#000000"
        static member inline transparent = Interop.mkStyle "borderColor" "transparent"

    /// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
    ///
    /// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
    /// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
    /// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    [<Erase; RequireQualifiedAccess>]
    type caretColor =
        /// The user agent selects an appropriate color for the caret.
        ///
        /// This is generally currentcolor, but the user agent may choose a different color to ensure good
        /// visibility and contrast with the surrounding content, taking into account the value of currentcolor,
        /// the background, shadows, and other factors.
        static member inline auto = Interop.mkStyle "caretColor" "auto"
        static member inline indianRed = Interop.mkStyle "caretColor" "#CD5C5C"
        static member inline lightCoral = Interop.mkStyle "caretColor" "#F08080"
        static member inline salmon = Interop.mkStyle "caretColor" "#FA8072"
        static member inline darkSalmon = Interop.mkStyle "caretColor" "#E9967A"
        static member inline lightSalmon = Interop.mkStyle "caretColor" "#FFA07A"
        static member inline crimson = Interop.mkStyle "caretColor" "#DC143C"
        static member inline red = Interop.mkStyle "caretColor" "#FF0000"
        static member inline fireBrick = Interop.mkStyle "caretColor" "#B22222"
        static member inline darkred = Interop.mkStyle "caretColor" "#8B0000"
        static member inline pink = Interop.mkStyle "caretColor" "#FFC0CB"
        static member inline lightPink = Interop.mkStyle "caretColor" "#FFB6C1"
        static member inline hotPink = Interop.mkStyle "caretColor" "#FF69B4"
        static member inline deepPink = Interop.mkStyle "caretColor" "#FF1493"
        static member inline mediumVioletRed = Interop.mkStyle "caretColor" "#C71585"
        static member inline paleVioletRed = Interop.mkStyle "caretColor" "#DB7093"
        static member inline coral = Interop.mkStyle "caretColor" "#FF7F50"
        static member inline tomato = Interop.mkStyle "caretColor" "#FF6347"
        static member inline orangeRed = Interop.mkStyle "caretColor" "#FF4500"
        static member inline darkOrange = Interop.mkStyle "caretColor" "#FF8C00"
        static member inline orange = Interop.mkStyle "caretColor" "#FFA500"
        static member inline gold = Interop.mkStyle "caretColor" "#FFD700"
        static member inline yellow = Interop.mkStyle "caretColor" "#FFFF00"
        static member inline lightYellow = Interop.mkStyle "caretColor" "#FFFFE0"
        static member inline limonChiffon = Interop.mkStyle "caretColor" "#FFFACD"
        static member inline lightGoldenRodYellow = Interop.mkStyle "caretColor" "#FAFAD2"
        static member inline papayaWhip = Interop.mkStyle "caretColor" "#FFEFD5"
        static member inline moccasin = Interop.mkStyle "caretColor" "#FFE4B5"
        static member inline peachPuff = Interop.mkStyle "caretColor" "#FFDAB9"
        static member inline paleGoldenRod = Interop.mkStyle "caretColor" "#EEE8AA"
        static member inline khaki = Interop.mkStyle "caretColor" "#F0E68C"
        static member inline darkKhaki = Interop.mkStyle "caretColor" "#BDB76B"
        static member inline lavender = Interop.mkStyle "caretColor" "#E6E6FA"
        static member inline thistle = Interop.mkStyle "caretColor" "#D8BFD8"
        static member inline plum = Interop.mkStyle "caretColor" "#DDA0DD"
        static member inline violet = Interop.mkStyle "caretColor" "#EE82EE"
        static member inline orchid = Interop.mkStyle "caretColor" "#DA70D6"
        static member inline fuchsia = Interop.mkStyle "caretColor" "#FF00FF"
        static member inline magenta = Interop.mkStyle "caretColor" "#FF00FF"
        static member inline mediumOrchid = Interop.mkStyle "caretColor" "#BA55D3"
        static member inline mediumPurple = Interop.mkStyle "caretColor" "#9370DB"
        static member inline rebeccaPurple = Interop.mkStyle "caretColor" "#663399"
        static member inline blueViolet = Interop.mkStyle "caretColor" "#8A2BE2"
        static member inline darkViolet = Interop.mkStyle "caretColor" "#9400D3"
        static member inline darkOrchid = Interop.mkStyle "caretColor" "#9932CC"
        static member inline darkMagenta = Interop.mkStyle "caretColor" "#8B008B"
        static member inline purple = Interop.mkStyle "caretColor" "#800080"
        static member inline indigo = Interop.mkStyle "caretColor" "#4B0082"
        static member inline slateBlue = Interop.mkStyle "caretColor" "#6A5ACD"
        static member inline darkSlateBlue = Interop.mkStyle "caretColor" "#483D8B"
        static member inline mediumSlateBlue = Interop.mkStyle "caretColor" "#7B68EE"
        static member inline greenYellow = Interop.mkStyle "caretColor" "#ADFF2F"
        static member inline chartreuse = Interop.mkStyle "caretColor" "#7FFF00"
        static member inline lawnGreen = Interop.mkStyle "caretColor" "#7CFC00"
        static member inline lime = Interop.mkStyle "caretColor" "#00FF00"
        static member inline limeGreen = Interop.mkStyle "caretColor" "#32CD32"
        static member inline paleGreen = Interop.mkStyle "caretColor" "#98FB98"
        static member inline lightGreen = Interop.mkStyle "caretColor" "#90EE90"
        static member inline mediumSpringGreen = Interop.mkStyle "caretColor" "#00FA9A"
        static member inline springGreen = Interop.mkStyle "caretColor" "#00FF7F"
        static member inline mediumSeaGreen = Interop.mkStyle "caretColor" "#3CB371"
        static member inline seaGreen = Interop.mkStyle "caretColor" "#2E8B57"
        static member inline forestGreen = Interop.mkStyle "caretColor" "#228B22"
        static member inline green = Interop.mkStyle "caretColor" "#008000"
        static member inline darkGreen = Interop.mkStyle "caretColor" "#006400"
        static member inline yellowGreen = Interop.mkStyle "caretColor" "#9ACD32"
        static member inline oliveDrab = Interop.mkStyle "caretColor" "#6B8E23"
        static member inline olive = Interop.mkStyle "caretColor" "#808000"
        static member inline darkOliveGreen = Interop.mkStyle "caretColor" "#556B2F"
        static member inline mediumAquamarine = Interop.mkStyle "caretColor" "#66CDAA"
        static member inline darkSeaGreen = Interop.mkStyle "caretColor" "#8FBC8B"
        static member inline lightSeaGreen = Interop.mkStyle "caretColor" "#20B2AA"
        static member inline darkCyan = Interop.mkStyle "caretColor" "#008B8B"
        static member inline teal = Interop.mkStyle "caretColor" "#008080"
        static member inline aqua = Interop.mkStyle "caretColor" "#00FFFF"
        static member inline cyan = Interop.mkStyle "caretColor" "#00FFFF"
        static member inline lightCyan = Interop.mkStyle "caretColor" "#E0FFFF"
        static member inline paleTurqouise = Interop.mkStyle "caretColor" "#AFEEEE"
        static member inline aquaMarine = Interop.mkStyle "caretColor" "#7FFFD4"
        static member inline turqouise = Interop.mkStyle "caretColor" "#AFEEEE"
        static member inline mediumTurqouise = Interop.mkStyle "caretColor" "#48D1CC"
        static member inline darkTurqouise = Interop.mkStyle "caretColor" "#00CED1"
        static member inline cadetBlue = Interop.mkStyle "caretColor" "#5F9EA0"
        static member inline steelBlue = Interop.mkStyle "caretColor" "#4682B4"
        static member inline lightSteelBlue = Interop.mkStyle "caretColor" "#B0C4DE"
        static member inline powederBlue = Interop.mkStyle "caretColor" "#B0E0E6"
        static member inline lightBlue = Interop.mkStyle "caretColor" "#ADD8E6"
        static member inline skyBlue = Interop.mkStyle "caretColor" "#87CEEB"
        static member inline lightSkyBlue = Interop.mkStyle "caretColor" "#87CEFA"
        static member inline deepSkyBlue = Interop.mkStyle "caretColor" "#00BFFF"
        static member inline dodgerBlue = Interop.mkStyle "caretColor" "#1E90FF"
        static member inline cornFlowerBlue = Interop.mkStyle "caretColor" "#6495ED"
        static member inline royalBlue = Interop.mkStyle "caretColor" "#4169E1"
        static member inline blue = Interop.mkStyle "caretColor" "#0000FF"
        static member inline mediumBlue = Interop.mkStyle "caretColor" "#0000CD"
        static member inline darkBlue = Interop.mkStyle "caretColor" "#00008B"
        static member inline navy = Interop.mkStyle "caretColor" "#000080"
        static member inline midnightBlue = Interop.mkStyle "caretColor" "#191970"
        static member inline cornSilk = Interop.mkStyle "caretColor" "#FFF8DC"
        static member inline blanchedAlmond = Interop.mkStyle "caretColor" "#FFEBCD"
        static member inline bisque = Interop.mkStyle "caretColor" "#FFE4C4"
        static member inline navajoWhite = Interop.mkStyle "caretColor" "#FFDEAD"
        static member inline wheat = Interop.mkStyle "caretColor" "#F5DEB3"
        static member inline burlyWood = Interop.mkStyle "caretColor" "#DEB887"
        static member inline tan = Interop.mkStyle "caretColor" "#D2B48C"
        static member inline rosyBrown = Interop.mkStyle "caretColor" "#BC8F8F"
        static member inline sandyBrown = Interop.mkStyle "caretColor" "#F4A460"
        static member inline goldenRod = Interop.mkStyle "caretColor" "#DAA520"
        static member inline darkGoldenRod = Interop.mkStyle "caretColor" "#B8860B"
        static member inline peru = Interop.mkStyle "caretColor" "#CD853F"
        static member inline chocolate = Interop.mkStyle "caretColor" "#D2691E"
        static member inline saddleBrown = Interop.mkStyle "caretColor" "#8B4513"
        static member inline sienna = Interop.mkStyle "caretColor" "#A0522D"
        static member inline brown = Interop.mkStyle "caretColor" "#A52A2A"
        static member inline maroon = Interop.mkStyle "caretColor" "#A52A2A"
        static member inline white = Interop.mkStyle "caretColor" "#FFFFFF"
        static member inline snow = Interop.mkStyle "caretColor" "#FFFAFA"
        static member inline honeyDew = Interop.mkStyle "caretColor" "#F0FFF0"
        static member inline mintCream = Interop.mkStyle "caretColor" "#F5FFFA"
        static member inline azure = Interop.mkStyle "caretColor" "#F0FFFF"
        static member inline aliceBlue = Interop.mkStyle "caretColor" "#F0F8FF"
        static member inline ghostWhite = Interop.mkStyle "caretColor" "#F8F8FF"
        static member inline whiteSmoke = Interop.mkStyle "caretColor" "#F5F5F5"
        static member inline seaShell = Interop.mkStyle "caretColor" "#FFF5EE"
        static member inline beige = Interop.mkStyle "caretColor" "#F5F5DC"
        static member inline oldLace = Interop.mkStyle "caretColor" "#FDF5E6"
        static member inline floralWhite = Interop.mkStyle "caretColor" "#FFFAF0"
        static member inline ivory = Interop.mkStyle "caretColor" "#FFFFF0"
        static member inline antiqueWhite = Interop.mkStyle "caretColor" "#FAEBD7"
        static member inline linen = Interop.mkStyle "caretColor" "#FAF0E6"
        static member inline lavenderBlush = Interop.mkStyle "caretColor" "#FFF0F5"
        static member inline mistyRose = Interop.mkStyle "caretColor" "#FFE4E1"
        static member inline gainsBoro = Interop.mkStyle "caretColor" "#DCDCDC"
        static member inline lightGray = Interop.mkStyle "caretColor" "#D3D3D3"
        static member inline silver = Interop.mkStyle "caretColor" "#C0C0C0"
        static member inline darkGray = Interop.mkStyle "caretColor" "#A9A9A9"
        static member inline gray = Interop.mkStyle "caretColor" "#808080"
        static member inline dimGray = Interop.mkStyle "caretColor" "#696969"
        static member inline lightSlateGray = Interop.mkStyle "caretColor" "#778899"
        static member inline slateGray = Interop.mkStyle "caretColor" "#708090"
        static member inline darkSlateGray = Interop.mkStyle "caretColor" "#2F4F4F"
        static member inline black = Interop.mkStyle "caretColor" "#000000"
        static member inline transparent = Interop.mkStyle "caretColor" "transparent"

    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    [<Erase; RequireQualifiedAccess>]
    type color =
        static member inline indianRed = Interop.mkStyle "color" "#CD5C5C"
        static member inline lightCoral = Interop.mkStyle "color" "#F08080"
        static member inline salmon = Interop.mkStyle "color" "#FA8072"
        static member inline darkSalmon = Interop.mkStyle "color" "#E9967A"
        static member inline lightSalmon = Interop.mkStyle "color" "#FFA07A"
        static member inline crimson = Interop.mkStyle "color" "#DC143C"
        static member inline red = Interop.mkStyle "color" "#FF0000"
        static member inline fireBrick = Interop.mkStyle "color" "#B22222"
        static member inline darkred = Interop.mkStyle "color" "#8B0000"
        static member inline pink = Interop.mkStyle "color" "#FFC0CB"
        static member inline lightPink = Interop.mkStyle "color" "#FFB6C1"
        static member inline hotPink = Interop.mkStyle "color" "#FF69B4"
        static member inline deepPink = Interop.mkStyle "color" "#FF1493"
        static member inline mediumVioletRed = Interop.mkStyle "color" "#C71585"
        static member inline paleVioletRed = Interop.mkStyle "color" "#DB7093"
        static member inline coral = Interop.mkStyle "color" "#FF7F50"
        static member inline tomato = Interop.mkStyle "color" "#FF6347"
        static member inline orangeRed = Interop.mkStyle "color" "#FF4500"
        static member inline darkOrange = Interop.mkStyle "color" "#FF8C00"
        static member inline orange = Interop.mkStyle "color" "#FFA500"
        static member inline gold = Interop.mkStyle "color" "#FFD700"
        static member inline yellow = Interop.mkStyle "color" "#FFFF00"
        static member inline lightYellow = Interop.mkStyle "color" "#FFFFE0"
        static member inline limonChiffon = Interop.mkStyle "color" "#FFFACD"
        static member inline lightGoldenRodYellow = Interop.mkStyle "color" "#FAFAD2"
        static member inline papayaWhip = Interop.mkStyle "color" "#FFEFD5"
        static member inline moccasin = Interop.mkStyle "color" "#FFE4B5"
        static member inline peachPuff = Interop.mkStyle "color" "#FFDAB9"
        static member inline paleGoldenRod = Interop.mkStyle "color" "#EEE8AA"
        static member inline khaki = Interop.mkStyle "color" "#F0E68C"
        static member inline darkKhaki = Interop.mkStyle "color" "#BDB76B"
        static member inline lavender = Interop.mkStyle "color" "#E6E6FA"
        static member inline thistle = Interop.mkStyle "color" "#D8BFD8"
        static member inline plum = Interop.mkStyle "color" "#DDA0DD"
        static member inline violet = Interop.mkStyle "color" "#EE82EE"
        static member inline orchid = Interop.mkStyle "color" "#DA70D6"
        static member inline fuchsia = Interop.mkStyle "color" "#FF00FF"
        static member inline magenta = Interop.mkStyle "color" "#FF00FF"
        static member inline mediumOrchid = Interop.mkStyle "color" "#BA55D3"
        static member inline mediumPurple = Interop.mkStyle "color" "#9370DB"
        static member inline rebeccaPurple = Interop.mkStyle "color" "#663399"
        static member inline blueViolet = Interop.mkStyle "color" "#8A2BE2"
        static member inline darkViolet = Interop.mkStyle "color" "#9400D3"
        static member inline darkOrchid = Interop.mkStyle "color" "#9932CC"
        static member inline darkMagenta = Interop.mkStyle "color" "#8B008B"
        static member inline purple = Interop.mkStyle "color" "#800080"
        static member inline indigo = Interop.mkStyle "color" "#4B0082"
        static member inline slateBlue = Interop.mkStyle "color" "#6A5ACD"
        static member inline darkSlateBlue = Interop.mkStyle "color" "#483D8B"
        static member inline mediumSlateBlue = Interop.mkStyle "color" "#7B68EE"
        static member inline greenYellow = Interop.mkStyle "color" "#ADFF2F"
        static member inline chartreuse = Interop.mkStyle "color" "#7FFF00"
        static member inline lawnGreen = Interop.mkStyle "color" "#7CFC00"
        static member inline lime = Interop.mkStyle "color" "#00FF00"
        static member inline limeGreen = Interop.mkStyle "color" "#32CD32"
        static member inline paleGreen = Interop.mkStyle "color" "#98FB98"
        static member inline lightGreen = Interop.mkStyle "color" "#90EE90"
        static member inline mediumSpringGreen = Interop.mkStyle "color" "#00FA9A"
        static member inline springGreen = Interop.mkStyle "color" "#00FF7F"
        static member inline mediumSeaGreen = Interop.mkStyle "color" "#3CB371"
        static member inline seaGreen = Interop.mkStyle "color" "#2E8B57"
        static member inline forestGreen = Interop.mkStyle "color" "#228B22"
        static member inline green = Interop.mkStyle "color" "#008000"
        static member inline darkGreen = Interop.mkStyle "color" "#006400"
        static member inline yellowGreen = Interop.mkStyle "color" "#9ACD32"
        static member inline oliveDrab = Interop.mkStyle "color" "#6B8E23"
        static member inline olive = Interop.mkStyle "color" "#808000"
        static member inline darkOliveGreen = Interop.mkStyle "color" "#556B2F"
        static member inline mediumAquamarine = Interop.mkStyle "color" "#66CDAA"
        static member inline darkSeaGreen = Interop.mkStyle "color" "#8FBC8B"
        static member inline lightSeaGreen = Interop.mkStyle "color" "#20B2AA"
        static member inline darkCyan = Interop.mkStyle "color" "#008B8B"
        static member inline teal = Interop.mkStyle "color" "#008080"
        static member inline aqua = Interop.mkStyle "color" "#00FFFF"
        static member inline cyan = Interop.mkStyle "color" "#00FFFF"
        static member inline lightCyan = Interop.mkStyle "color" "#E0FFFF"
        static member inline paleTurqouise = Interop.mkStyle "color" "#AFEEEE"
        static member inline aquaMarine = Interop.mkStyle "color" "#7FFFD4"
        static member inline turqouise = Interop.mkStyle "color" "#AFEEEE"
        static member inline mediumTurqouise = Interop.mkStyle "color" "#48D1CC"
        static member inline darkTurqouise = Interop.mkStyle "color" "#00CED1"
        static member inline cadetBlue = Interop.mkStyle "color" "#5F9EA0"
        static member inline steelBlue = Interop.mkStyle "color" "#4682B4"
        static member inline lightSteelBlue = Interop.mkStyle "color" "#B0C4DE"
        static member inline powederBlue = Interop.mkStyle "color" "#B0E0E6"
        static member inline lightBlue = Interop.mkStyle "color" "#ADD8E6"
        static member inline skyBlue = Interop.mkStyle "color" "#87CEEB"
        static member inline lightSkyBlue = Interop.mkStyle "color" "#87CEFA"
        static member inline deepSkyBlue = Interop.mkStyle "color" "#00BFFF"
        static member inline dodgerBlue = Interop.mkStyle "color" "#1E90FF"
        static member inline cornFlowerBlue = Interop.mkStyle "color" "#6495ED"
        static member inline royalBlue = Interop.mkStyle "color" "#4169E1"
        static member inline blue = Interop.mkStyle "color" "#0000FF"
        static member inline mediumBlue = Interop.mkStyle "color" "#0000CD"
        static member inline darkBlue = Interop.mkStyle "color" "#00008B"
        static member inline navy = Interop.mkStyle "color" "#000080"
        static member inline midnightBlue = Interop.mkStyle "color" "#191970"
        static member inline cornSilk = Interop.mkStyle "color" "#FFF8DC"
        static member inline blanchedAlmond = Interop.mkStyle "color" "#FFEBCD"
        static member inline bisque = Interop.mkStyle "color" "#FFE4C4"
        static member inline navajoWhite = Interop.mkStyle "color" "#FFDEAD"
        static member inline wheat = Interop.mkStyle "color" "#F5DEB3"
        static member inline burlyWood = Interop.mkStyle "color" "#DEB887"
        static member inline tan = Interop.mkStyle "color" "#D2B48C"
        static member inline rosyBrown = Interop.mkStyle "color" "#BC8F8F"
        static member inline sandyBrown = Interop.mkStyle "color" "#F4A460"
        static member inline goldenRod = Interop.mkStyle "color" "#DAA520"
        static member inline darkGoldenRod = Interop.mkStyle "color" "#B8860B"
        static member inline peru = Interop.mkStyle "color" "#CD853F"
        static member inline chocolate = Interop.mkStyle "color" "#D2691E"
        static member inline saddleBrown = Interop.mkStyle "color" "#8B4513"
        static member inline sienna = Interop.mkStyle "color" "#A0522D"
        static member inline brown = Interop.mkStyle "color" "#A52A2A"
        static member inline maroon = Interop.mkStyle "color" "#A52A2A"
        static member inline white = Interop.mkStyle "color" "#FFFFFF"
        static member inline snow = Interop.mkStyle "color" "#FFFAFA"
        static member inline honeyDew = Interop.mkStyle "color" "#F0FFF0"
        static member inline mintCream = Interop.mkStyle "color" "#F5FFFA"
        static member inline azure = Interop.mkStyle "color" "#F0FFFF"
        static member inline aliceBlue = Interop.mkStyle "color" "#F0F8FF"
        static member inline ghostWhite = Interop.mkStyle "color" "#F8F8FF"
        static member inline whiteSmoke = Interop.mkStyle "color" "#F5F5F5"
        static member inline seaShell = Interop.mkStyle "color" "#FFF5EE"
        static member inline beige = Interop.mkStyle "color" "#F5F5DC"
        static member inline oldLace = Interop.mkStyle "color" "#FDF5E6"
        static member inline floralWhite = Interop.mkStyle "color" "#FFFAF0"
        static member inline ivory = Interop.mkStyle "color" "#FFFFF0"
        static member inline antiqueWhite = Interop.mkStyle "color" "#FAEBD7"
        static member inline linen = Interop.mkStyle "color" "#FAF0E6"
        static member inline lavenderBlush = Interop.mkStyle "color" "#FFF0F5"
        static member inline mistyRose = Interop.mkStyle "color" "#FFE4E1"
        static member inline gainsBoro = Interop.mkStyle "color" "#DCDCDC"
        static member inline lightGray = Interop.mkStyle "color" "#D3D3D3"
        static member inline silver = Interop.mkStyle "color" "#C0C0C0"
        static member inline darkGray = Interop.mkStyle "color" "#A9A9A9"
        static member inline gray = Interop.mkStyle "color" "#808080"
        static member inline dimGray = Interop.mkStyle "color" "#696969"
        static member inline lightSlateGray = Interop.mkStyle "color" "#778899"
        static member inline slateGray = Interop.mkStyle "color" "#708090"
        static member inline darkSlateGray = Interop.mkStyle "color" "#2F4F4F"
        static member inline black = Interop.mkStyle "color" "#000000"
        static member inline transparent = Interop.mkStyle "color" "transparent"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = Interop.mkStyle "color" "inherit"
        /// Sets this property to its default value
        static member inline initial = Interop.mkStyle "color" "initial"
        static member inline revert = Interop.mkStyle "color" "revert"
        static member inline revertLayer = Interop.mkStyle "color" "revert-layer"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = Interop.mkStyle "color" "unset"

    /// Sets the color of decorations added to text by text-decoration-line.
    [<Erase; RequireQualifiedAccess>]
    type textDecorationColor =
        static member inline indianRed = Interop.mkStyle "textDecorationColor" "#CD5C5C"
        static member inline lightCoral = Interop.mkStyle "textDecorationColor" "#F08080"
        static member inline salmon = Interop.mkStyle "textDecorationColor" "#FA8072"
        static member inline darkSalmon = Interop.mkStyle "textDecorationColor" "#E9967A"
        static member inline lightSalmon = Interop.mkStyle "textDecorationColor" "#FFA07A"
        static member inline crimson = Interop.mkStyle "textDecorationColor" "#DC143C"
        static member inline red = Interop.mkStyle "textDecorationColor" "#FF0000"
        static member inline fireBrick = Interop.mkStyle "textDecorationColor" "#B22222"
        static member inline darkred = Interop.mkStyle "textDecorationColor" "#8B0000"
        static member inline pink = Interop.mkStyle "textDecorationColor" "#FFC0CB"
        static member inline lightPink = Interop.mkStyle "textDecorationColor" "#FFB6C1"
        static member inline hotPink = Interop.mkStyle "textDecorationColor" "#FF69B4"
        static member inline deepPink = Interop.mkStyle "textDecorationColor" "#FF1493"
        static member inline mediumVioletRed = Interop.mkStyle "textDecorationColor" "#C71585"
        static member inline paleVioletRed = Interop.mkStyle "textDecorationColor" "#DB7093"
        static member inline coral = Interop.mkStyle "textDecorationColor" "#FF7F50"
        static member inline tomato = Interop.mkStyle "textDecorationColor" "#FF6347"
        static member inline orangeRed = Interop.mkStyle "textDecorationColor" "#FF4500"
        static member inline darkOrange = Interop.mkStyle "textDecorationColor" "#FF8C00"
        static member inline orange = Interop.mkStyle "textDecorationColor" "#FFA500"
        static member inline gold = Interop.mkStyle "textDecorationColor" "#FFD700"
        static member inline yellow = Interop.mkStyle "textDecorationColor" "#FFFF00"
        static member inline lightYellow = Interop.mkStyle "textDecorationColor" "#FFFFE0"
        static member inline limonChiffon = Interop.mkStyle "textDecorationColor" "#FFFACD"
        static member inline lightGoldenRodYellow = Interop.mkStyle "textDecorationColor" "#FAFAD2"
        static member inline papayaWhip = Interop.mkStyle "textDecorationColor" "#FFEFD5"
        static member inline moccasin = Interop.mkStyle "textDecorationColor" "#FFE4B5"
        static member inline peachPuff = Interop.mkStyle "textDecorationColor" "#FFDAB9"
        static member inline paleGoldenRod = Interop.mkStyle "textDecorationColor" "#EEE8AA"
        static member inline khaki = Interop.mkStyle "textDecorationColor" "#F0E68C"
        static member inline darkKhaki = Interop.mkStyle "textDecorationColor" "#BDB76B"
        static member inline lavender = Interop.mkStyle "textDecorationColor" "#E6E6FA"
        static member inline thistle = Interop.mkStyle "textDecorationColor" "#D8BFD8"
        static member inline plum = Interop.mkStyle "textDecorationColor" "#DDA0DD"
        static member inline violet = Interop.mkStyle "textDecorationColor" "#EE82EE"
        static member inline orchid = Interop.mkStyle "textDecorationColor" "#DA70D6"
        static member inline fuchsia = Interop.mkStyle "textDecorationColor" "#FF00FF"
        static member inline magenta = Interop.mkStyle "textDecorationColor" "#FF00FF"
        static member inline mediumOrchid = Interop.mkStyle "textDecorationColor" "#BA55D3"
        static member inline mediumPurple = Interop.mkStyle "textDecorationColor" "#9370DB"
        static member inline rebeccaPurple = Interop.mkStyle "textDecorationColor" "#663399"
        static member inline blueViolet = Interop.mkStyle "textDecorationColor" "#8A2BE2"
        static member inline darkViolet = Interop.mkStyle "textDecorationColor" "#9400D3"
        static member inline darkOrchid = Interop.mkStyle "textDecorationColor" "#9932CC"
        static member inline darkMagenta = Interop.mkStyle "textDecorationColor" "#8B008B"
        static member inline purple = Interop.mkStyle "textDecorationColor" "#800080"
        static member inline indigo = Interop.mkStyle "textDecorationColor" "#4B0082"
        static member inline slateBlue = Interop.mkStyle "textDecorationColor" "#6A5ACD"
        static member inline darkSlateBlue = Interop.mkStyle "textDecorationColor" "#483D8B"
        static member inline mediumSlateBlue = Interop.mkStyle "textDecorationColor" "#7B68EE"
        static member inline greenYellow = Interop.mkStyle "textDecorationColor" "#ADFF2F"
        static member inline chartreuse = Interop.mkStyle "textDecorationColor" "#7FFF00"
        static member inline lawnGreen = Interop.mkStyle "textDecorationColor" "#7CFC00"
        static member inline lime = Interop.mkStyle "textDecorationColor" "#00FF00"
        static member inline limeGreen = Interop.mkStyle "textDecorationColor" "#32CD32"
        static member inline paleGreen = Interop.mkStyle "textDecorationColor" "#98FB98"
        static member inline lightGreen = Interop.mkStyle "textDecorationColor" "#90EE90"
        static member inline mediumSpringGreen = Interop.mkStyle "textDecorationColor" "#00FA9A"
        static member inline springGreen = Interop.mkStyle "textDecorationColor" "#00FF7F"
        static member inline mediumSeaGreen = Interop.mkStyle "textDecorationColor" "#3CB371"
        static member inline seaGreen = Interop.mkStyle "textDecorationColor" "#2E8B57"
        static member inline forestGreen = Interop.mkStyle "textDecorationColor" "#228B22"
        static member inline green = Interop.mkStyle "textDecorationColor" "#008000"
        static member inline darkGreen = Interop.mkStyle "textDecorationColor" "#006400"
        static member inline yellowGreen = Interop.mkStyle "textDecorationColor" "#9ACD32"
        static member inline oliveDrab = Interop.mkStyle "textDecorationColor" "#6B8E23"
        static member inline olive = Interop.mkStyle "textDecorationColor" "#808000"
        static member inline darkOliveGreen = Interop.mkStyle "textDecorationColor" "#556B2F"
        static member inline mediumAquamarine = Interop.mkStyle "textDecorationColor" "#66CDAA"
        static member inline darkSeaGreen = Interop.mkStyle "textDecorationColor" "#8FBC8B"
        static member inline lightSeaGreen = Interop.mkStyle "textDecorationColor" "#20B2AA"
        static member inline darkCyan = Interop.mkStyle "textDecorationColor" "#008B8B"
        static member inline teal = Interop.mkStyle "textDecorationColor" "#008080"
        static member inline aqua = Interop.mkStyle "textDecorationColor" "#00FFFF"
        static member inline cyan = Interop.mkStyle "textDecorationColor" "#00FFFF"
        static member inline lightCyan = Interop.mkStyle "textDecorationColor" "#E0FFFF"
        static member inline paleTurqouise = Interop.mkStyle "textDecorationColor" "#AFEEEE"
        static member inline aquaMarine = Interop.mkStyle "textDecorationColor" "#7FFFD4"
        static member inline turqouise = Interop.mkStyle "textDecorationColor" "#AFEEEE"
        static member inline mediumTurqouise = Interop.mkStyle "textDecorationColor" "#48D1CC"
        static member inline darkTurqouise = Interop.mkStyle "textDecorationColor" "#00CED1"
        static member inline cadetBlue = Interop.mkStyle "textDecorationColor" "#5F9EA0"
        static member inline steelBlue = Interop.mkStyle "textDecorationColor" "#4682B4"
        static member inline lightSteelBlue = Interop.mkStyle "textDecorationColor" "#B0C4DE"
        static member inline powederBlue = Interop.mkStyle "textDecorationColor" "#B0E0E6"
        static member inline lightBlue = Interop.mkStyle "textDecorationColor" "#ADD8E6"
        static member inline skyBlue = Interop.mkStyle "textDecorationColor" "#87CEEB"
        static member inline lightSkyBlue = Interop.mkStyle "textDecorationColor" "#87CEFA"
        static member inline deepSkyBlue = Interop.mkStyle "textDecorationColor" "#00BFFF"
        static member inline dodgerBlue = Interop.mkStyle "textDecorationColor" "#1E90FF"
        static member inline cornFlowerBlue = Interop.mkStyle "textDecorationColor" "#6495ED"
        static member inline royalBlue = Interop.mkStyle "textDecorationColor" "#4169E1"
        static member inline blue = Interop.mkStyle "textDecorationColor" "#0000FF"
        static member inline mediumBlue = Interop.mkStyle "textDecorationColor" "#0000CD"
        static member inline darkBlue = Interop.mkStyle "textDecorationColor" "#00008B"
        static member inline navy = Interop.mkStyle "textDecorationColor" "#000080"
        static member inline midnightBlue = Interop.mkStyle "textDecorationColor" "#191970"
        static member inline cornSilk = Interop.mkStyle "textDecorationColor" "#FFF8DC"
        static member inline blanchedAlmond = Interop.mkStyle "textDecorationColor" "#FFEBCD"
        static member inline bisque = Interop.mkStyle "textDecorationColor" "#FFE4C4"
        static member inline navajoWhite = Interop.mkStyle "textDecorationColor" "#FFDEAD"
        static member inline wheat = Interop.mkStyle "textDecorationColor" "#F5DEB3"
        static member inline burlyWood = Interop.mkStyle "textDecorationColor" "#DEB887"
        static member inline tan = Interop.mkStyle "textDecorationColor" "#D2B48C"
        static member inline rosyBrown = Interop.mkStyle "textDecorationColor" "#BC8F8F"
        static member inline sandyBrown = Interop.mkStyle "textDecorationColor" "#F4A460"
        static member inline goldenRod = Interop.mkStyle "textDecorationColor" "#DAA520"
        static member inline darkGoldenRod = Interop.mkStyle "textDecorationColor" "#B8860B"
        static member inline peru = Interop.mkStyle "textDecorationColor" "#CD853F"
        static member inline chocolate = Interop.mkStyle "textDecorationColor" "#D2691E"
        static member inline saddleBrown = Interop.mkStyle "textDecorationColor" "#8B4513"
        static member inline sienna = Interop.mkStyle "textDecorationColor" "#A0522D"
        static member inline brown = Interop.mkStyle "textDecorationColor" "#A52A2A"
        static member inline maroon = Interop.mkStyle "textDecorationColor" "#A52A2A"
        static member inline white = Interop.mkStyle "textDecorationColor" "#FFFFFF"
        static member inline snow = Interop.mkStyle "textDecorationColor" "#FFFAFA"
        static member inline honeyDew = Interop.mkStyle "textDecorationColor" "#F0FFF0"
        static member inline mintCream = Interop.mkStyle "textDecorationColor" "#F5FFFA"
        static member inline azure = Interop.mkStyle "textDecorationColor" "#F0FFFF"
        static member inline aliceBlue = Interop.mkStyle "textDecorationColor" "#F0F8FF"
        static member inline ghostWhite = Interop.mkStyle "textDecorationColor" "#F8F8FF"
        static member inline whiteSmoke = Interop.mkStyle "textDecorationColor" "#F5F5F5"
        static member inline seaShell = Interop.mkStyle "textDecorationColor" "#FFF5EE"
        static member inline beige = Interop.mkStyle "textDecorationColor" "#F5F5DC"
        static member inline oldLace = Interop.mkStyle "textDecorationColor" "#FDF5E6"
        static member inline floralWhite = Interop.mkStyle "textDecorationColor" "#FFFAF0"
        static member inline ivory = Interop.mkStyle "textDecorationColor" "#FFFFF0"
        static member inline antiqueWhite = Interop.mkStyle "textDecorationColor" "#FAEBD7"
        static member inline linen = Interop.mkStyle "textDecorationColor" "#FAF0E6"
        static member inline lavenderBlush = Interop.mkStyle "textDecorationColor" "#FFF0F5"
        static member inline mistyRose = Interop.mkStyle "textDecorationColor" "#FFE4E1"
        static member inline gainsBoro = Interop.mkStyle "textDecorationColor" "#DCDCDC"
        static member inline lightGray = Interop.mkStyle "textDecorationColor" "#D3D3D3"
        static member inline silver = Interop.mkStyle "textDecorationColor" "#C0C0C0"
        static member inline darkGray = Interop.mkStyle "textDecorationColor" "#A9A9A9"
        static member inline gray = Interop.mkStyle "textDecorationColor" "#808080"
        static member inline dimGray = Interop.mkStyle "textDecorationColor" "#696969"
        static member inline lightSlateGray = Interop.mkStyle "textDecorationColor" "#778899"
        static member inline slateGray = Interop.mkStyle "textDecorationColor" "#708090"
        static member inline darkSlateGray = Interop.mkStyle "textDecorationColor" "#2F4F4F"
        static member inline black = Interop.mkStyle "textDecorationColor" "#000000"
        static member inline transparent = Interop.mkStyle "textDecorationColor" "transparent"

    /// Controls how the auto-placement algorithm works, specifying exactly how auto-placed items get flowed into the grid
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow
    [<Erase>]
    type gridAutoFlow =
        /// Default value. Items are placed by filling each row in turn, adding new rows as necessary
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-flow: row;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoFlow.row
        /// ```
        static member inline row = Interop.mkStyle "gridAutoFlow" "row"
        /// Items are placed by filling each column in turn, adding new columns as necessary
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-flow: column;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoFlow.column
        /// ```
        static member inline column = Interop.mkStyle "gridAutoFlow" "column"
        /// The "dense" algorithm attempts to fill in holes earlier in the grid, if smaller items come up later.
        /// This may cause items to appear out-of-order, when doing so would fill in holes left by larger items.
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-flow: dense;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoFlow.dense
        /// ```
        static member inline dense = Interop.mkStyle "gridAutoFlow" "dense"
        /// Items are placed by filling each row in turn, adding new rows as necessary.
        /// The "dense" algorithm attempts to fill in holes earlier in the grid, if smaller items come up later.
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-flow: row dense;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoFlow.rowDense
        /// ```
        static member inline rowDense = Interop.mkStyle "gridAutoFlow" "row dense"
        /// Items are placed by filling each column in turn, adding new columns as necessary.
        /// The "dense" algorithm attempts to fill in holes earlier in the grid, if smaller items come up later.
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-flow#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-flow: column dense;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoFlow.columnDense
        /// ```
        static member inline columnDense = Interop.mkStyle "gridAutoFlow" "column dense"

    /// Specifies the size of an implicitly-created grid column track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns
    [<Erase>]
    type gridAutoColumns =
        /// Default value. The size of the columns is determined by the size of the container
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-columns: auto;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoColumns.auto
        /// ```
        static member inline auto = Interop.mkStyle "gridAutoColumns" "auto"
        /// Represents the largest minimal content contribution of the grid items occupying the grid track
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-columns: min-content;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoColumns.minContent
        /// ```
        static member inline minContent = Interop.mkStyle "gridAutoColumns" "min-content"
        /// Represents the largest maximal content contribution of the grid items occupying the grid track
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-columns#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-columns: max-content;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoColumns.maxContent
        /// ```
        static member inline maxContent = Interop.mkStyle "gridAutoColumns" "max-content"
    
    /// Specifies the size of an implicitly-created grid row track
    ///
    /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows
    [<Erase>]
    type gridAutoRows =
        /// Default value. The size of the rows is determined by the size of the container
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-rows: auto;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoRows.auto
        /// ```
        static member inline auto = Interop.mkStyle "gridAutoRows" "auto"
        /// Represents the largest minimal content contribution of the grid items occupying the grid track
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-rows: min-content;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoRows.minContent
        /// ```
        static member inline minContent = Interop.mkStyle "gridAutoRows" "min-content"
        /// Represents the largest maximal content contribution of the grid items occupying the grid track
        ///
        /// Documentation: https://developer.mozilla.org/en-US/docs/Web/CSS/grid-auto-rows#values
        ///
        /// **CSS**
        /// ```css
        /// grid-auto-rows: max-content;
        /// ```
        /// **F#**
        /// ```f#
        /// style.gridAutoRows.maxContent
        /// ```
        static member inline maxContent = Interop.mkStyle "gridAutoRows" "max-content"

    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    [<Erase>]
    type lineHeight =
        /// Depends on the user agent. Desktop browsers (including Firefox)
        /// use a default value of roughly 1.2, depending on the element's font-family.
        static member inline normal = Interop.mkStyle "lineHeight" "normal"
