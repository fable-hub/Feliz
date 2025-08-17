namespace Feliz

open System
open Fable.Core
open Feliz.Styles

module StyleHelper =

    let inline mkStyle (key: string) (value: obj) : IStyleAttribute = unbox (key, value)

[<Erase>]
type style =
    /// The zIndex property sets or returns the stack order of a positioned element.
    ///
    /// An element with greater stack order (1) is always in front of another element with lower stack order (0).
    ///
    /// **Tip**: A positioned element is an element with the position property set to: relative, absolute, or fixed.
    ///
    /// **Tip**: This property is useful if you want to create overlapping elements.
    static member inline zIndex(value: int) = StyleHelper.mkStyle "zIndex" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(value: int) = StyleHelper.mkStyle "margin" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(value: ICssUnit) = StyleHelper.mkStyle "margin" value
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: int, horizontal: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: int, horizontal: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: ICssUnit, horizontal: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(vertical: ICssUnit, horizontal: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: int, bottom: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: int, bottom: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: ICssUnit, bottom: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: int, horizontal: ICssUnit, bottom: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: int, bottom: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: int, bottom: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: ICssUnit, bottom: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the margin area on three sides of an element. It is a shorthand for margin-top, margin-right
    /// and margin-bottom.
    static member inline margin(top: ICssUnit, horizontal: ICssUnit, bottom: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: int, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: int, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: int, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: int, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: int, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: int, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: int, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the margin area on all four sides of an element. It is a shorthand for margin-top, margin-right,
    /// margin-bottom, and margin-left.
    static member inline margin(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "margin" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginLeft(value: int) = StyleHelper.mkStyle "marginLeft" value
    /// Sets the margin area on the left side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginLeft(value: ICssUnit) = StyleHelper.mkStyle "marginLeft" value
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginRight(value: int) = StyleHelper.mkStyle "marginRight" value
    /// sets the margin area on the right side of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginRight(value: ICssUnit) = StyleHelper.mkStyle "marginRight" value
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginTop(value: int) = StyleHelper.mkStyle "marginTop" value
    /// Sets the margin area on the top of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginTop(value: ICssUnit) = StyleHelper.mkStyle "marginTop" value
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginBottom(value: int) = StyleHelper.mkStyle "marginBottom" value
    /// Sets the margin area on the bottom of an element. A positive value places it farther from its
    /// neighbors, while a negative value places it closer.
    static member inline marginBottom(value: ICssUnit) = StyleHelper.mkStyle "marginBottom" value

    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(value: int) = StyleHelper.mkStyle "marginBlock" value
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(value: ICssUnit) = StyleHelper.mkStyle "marginBlock" value
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: int, blockEnd: int) =
        StyleHelper.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: ICssUnit, blockEnd: int) =
        StyleHelper.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: int, blockEnd: ICssUnit) =
        StyleHelper.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlock(blockStart: ICssUnit, blockEnd: ICssUnit) =
        StyleHelper.mkStyle "marginBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    
    /// Defines the logical block start margin of an element, which
    /// maps to a physical margin depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockStart(value: int) =
        StyleHelper.mkStyle "marginBlockStart" value
    /// Defines the logical block start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockStart(value: ICssUnit) =
        StyleHelper.mkStyle "marginBlockStart" value
    
    /// Defines the logical block end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockEnd(value: int) =
        StyleHelper.mkStyle "marginBlockEnd" value
    /// Defines the logical block end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-block
    static member inline marginBlockEnd(value: ICssUnit) =
        StyleHelper.mkStyle "marginBlockEnd" value

    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(value: int) = StyleHelper.mkStyle "marginInline" value
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(value: ICssUnit) = StyleHelper.mkStyle "marginInline" value
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: int, inlineEnd: int) =
        StyleHelper.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: ICssUnit, inlineEnd: int) =
        StyleHelper.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: int, inlineEnd: ICssUnit) =
        StyleHelper.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end margins of an element,
    /// which maps to a physical margin depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline
    static member inline marginInline(inlineStart: ICssUnit, inlineEnd: ICssUnit) =
        StyleHelper.mkStyle "marginInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    
    /// Defines the logical inline start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-start
    static member inline marginInlineStart(value: int) =
        StyleHelper.mkStyle "marginInlineStart" value
    /// Defines the logical inline start margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-start
    static member inline marginInlineStart(value: ICssUnit) =
        StyleHelper.mkStyle "marginInlineStart" value
    
    /// Defines the logical inline end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-end
    static member inline marginInlineEnd(value: int) =
        StyleHelper.mkStyle "marginInlineEnd" value
    /// Defines the logical inline end margin of an element, which maps
    /// to a physical margin depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/margin-inline-end
    static member inline marginInlineEnd(value: ICssUnit) =
        StyleHelper.mkStyle "marginInlineEnd" value

    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(value: int) = StyleHelper.mkStyle "padding" value
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(value: ICssUnit) = StyleHelper.mkStyle "padding" value
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: int, horizontal: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: int, horizontal: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> vertical) + "px " +
            (unbox<string> horizontal)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: ICssUnit, horizontal: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(vertical: ICssUnit, horizontal: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> vertical) + " " +
            (unbox<string> horizontal)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: int, bottom: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: int, bottom: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: ICssUnit, bottom: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, horizontal: ICssUnit, bottom: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: int, bottom: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: int, bottom: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + "px " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: ICssUnit, bottom: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, horizontal: ICssUnit, bottom: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> horizontal) + " " +
            (unbox<string> bottom)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: int, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: int, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: int, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: int, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: int, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: int, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: int, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: int, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left)
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: int) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left) + "px"
        )
    /// Sets the padding area on all four sides of an element. It is a shorthand for padding-top,
    /// padding-right, padding-bottom, and padding-left.
    static member inline padding(top: ICssUnit, right: ICssUnit, bottom: ICssUnit, left: ICssUnit) =
        StyleHelper.mkStyle "padding" (
            (unbox<string> top) + " " +
            (unbox<string> right) + " " +
            (unbox<string> bottom) + " " +
            (unbox<string> left)
        )
    /// Sets the height of the padding area on the bottom of an element.
    static member inline paddingBottom(value: int) = StyleHelper.mkStyle "paddingBottom" value
    /// Sets the height of the padding area on the bottom of an element.
    static member inline paddingBottom(value: ICssUnit) = StyleHelper.mkStyle "paddingBottom" value
    /// Sets the width of the padding area to the left of an element.
    static member inline paddingLeft(value: int) = StyleHelper.mkStyle "paddingLeft" value
    /// Sets the width of the padding area to the left of an element.
    static member inline paddingLeft(value: ICssUnit) = StyleHelper.mkStyle "paddingLeft" value
    /// Sets the width of the padding area on the right of an element.
    static member inline paddingRight(value: int) = StyleHelper.mkStyle "paddingRight" value
    /// Sets the width of the padding area on the right of an element.
    static member inline paddingRight(value: ICssUnit) = StyleHelper.mkStyle "paddingRight" value
    /// Sets the height of the padding area on the top of an element.
    static member inline paddingTop(value: int) = StyleHelper.mkStyle "paddingTop" value
    /// Sets the height of the padding area on the top of an element.
    static member inline paddingTop(value: ICssUnit) = StyleHelper.mkStyle "paddingTop" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(value: int) = StyleHelper.mkStyle "marginBlock" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(value: ICssUnit) = StyleHelper.mkStyle "marginBlock" value
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: int, blockEnd: int) =
        StyleHelper.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: ICssUnit, blockEnd: int) =
        StyleHelper.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: int, blockEnd: ICssUnit) =
        StyleHelper.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlock(blockStart: ICssUnit, blockEnd: ICssUnit) =
        StyleHelper.mkStyle "paddingBlock" (
            unbox<string> blockStart + " " +
            unbox<string> blockEnd
        )
    
    /// Defines the logical block start padding of an element, which
    /// maps to a physical padding properties depending on the element's writing
    /// mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockStart(value: int) =
        StyleHelper.mkStyle "paddingBlockStart" value
    /// Defines the logical block start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockStart(value: ICssUnit) =
        StyleHelper.mkStyle "paddingBlockStart" value
    
    /// Defines the logical block end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockEnd(value: int) =
        StyleHelper.mkStyle "paddingBlockEnd" value
    /// Defines the logical block end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-block
    static member inline paddingBlockEnd(value: ICssUnit) =
        StyleHelper.mkStyle "paddingBlockEnd" value

    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(value: int) = StyleHelper.mkStyle "marginInline" value
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(value: ICssUnit) = StyleHelper.mkStyle "marginInline" value
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: int, inlineEnd: int) =
        StyleHelper.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: ICssUnit, inlineEnd: int) =
        StyleHelper.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: int, inlineEnd: ICssUnit) =
        StyleHelper.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    /// Defines the logical inline start and end paddings of an element,
    /// which maps to a physical padding properties depending on the element's
    /// writing mode, directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline
    static member inline paddingInline(inlineStart: ICssUnit, inlineEnd: ICssUnit) =
        StyleHelper.mkStyle "paddingInline" (
            unbox<string> inlineStart + " " +
            unbox<string> inlineEnd
        )
    
    /// Defines the logical inline start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-start
    static member inline paddingInlineStart(value: int) =
        StyleHelper.mkStyle "paddingInlineStart" value
    /// Defines the logical inline start padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-start
    static member inline paddingInlineStart(value: ICssUnit) =
        StyleHelper.mkStyle "paddingInlineStart" value
    
    /// Defines the logical inline end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-end
    static member inline paddingInlineEnd(value: int) =
        StyleHelper.mkStyle "paddingInlineEnd" value
    /// Defines the logical inline end padding of an element, which maps
    /// to a physical padding properties depending on the element's writing mode,
    /// directionality, and text orientation.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/padding-inline-end
    static member inline paddingInlineEnd(value: ICssUnit) =
        StyleHelper.mkStyle "paddingInlineEnd" value

    /// Sets the flex shrink factor of a flex item. If the size of all flex items is larger than
    /// the flex container, items shrink to fit according to flex-shrink.
    static member inline flexShrink(value: int) = StyleHelper.mkStyle "flexShrink" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: int) = StyleHelper.mkStyle "flexBasis" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: float) = StyleHelper.mkStyle "flexBasis" value
    /// Sets the initial main size of a flex item. It sets the size of the content box unless
    /// otherwise set with box-sizing.
    static member inline flexBasis (value: ICssUnit) = StyleHelper.mkStyle "flexBasis" value
    /// Sets the flex grow factor of a flex item main size. It specifies how much of the remaining
    /// space in the flex container should be assigned to the item (the flex grow factor).
    static member inline flexGrow (value: int) = StyleHelper.mkStyle "flexGrow" value
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
        StyleHelper.mkStyle "gridTemplateColumns" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string list>value))
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
        StyleHelper.mkStyle "gridTemplateColumns" (String.concat " " (unbox<string[]>value))
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateColumns" (
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
        StyleHelper.mkStyle "gridTemplateRows" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateRows" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateRows" ((List.map addPixels >> String.concat " ") (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateRows" ((Array.map addPixels >> String.concat " ") (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateRows" (String.concat " " (unbox<string list> value))
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
        StyleHelper.mkStyle "gridTemplateRows" (String.concat " " (unbox<string[]> value))
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
        StyleHelper.mkStyle "gridTemplateRows" (String.concat " " (unbox<string list>value))
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
        StyleHelper.mkStyle "gridTemplateRows" (String.concat " " (unbox<string[]>value))
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateRows" (
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
        StyleHelper.mkStyle "gridTemplateAreas" block
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
        StyleHelper.mkStyle "gridTemplateAreas" block
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
        StyleHelper.mkStyle "gridTemplateAreas" ("'" + block + "'")
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
        StyleHelper.mkStyle "gridTemplateAreas" ("'" + block + "'")
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
        StyleHelper.mkStyle "columnGap" (unbox<string> value + "px")
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
        StyleHelper.mkStyle "columnGap" (unbox<string> value + "px")
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
        StyleHelper.mkStyle "columnGap" value
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
        StyleHelper.mkStyle "rowGap" (unbox<string> value + "px")
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
        StyleHelper.mkStyle "rowGap" (unbox<string> value + "px")
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
        StyleHelper.mkStyle "rowGap" value
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
        StyleHelper.mkStyle "gap" ((unbox<string> gap) + "px ")
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
        StyleHelper.mkStyle "gap" (unbox<string> gap)
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
        StyleHelper.mkStyle "gap" (
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
    static member inline gridColumnStart(value: string) = StyleHelper.mkStyle "gridColumnStart" value
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
        StyleHelper.mkStyle "gridColumnStart" (value + " " + (unbox<string>count))
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
    static member inline gridColumnStart(value: int) = StyleHelper.mkStyle "gridColumnStart" value
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
    static member inline gridColumnStart(value: IGridSpan) = StyleHelper.mkStyle "gridColumnStart" value
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
    static member inline gridColumnEnd(value: string) = StyleHelper.mkStyle "gridColumnEnd" value
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
        StyleHelper.mkStyle "gridColumnEnd" (value + " " + (unbox<string> count))
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
    static member inline gridColumnEnd(value: int) = StyleHelper.mkStyle "gridColumnEnd" value
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
    static member inline gridColumnEnd(value: IGridSpan) = StyleHelper.mkStyle "gridColumnEnd" value
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
    static member inline gridRowStart(value: string) = StyleHelper.mkStyle "gridRowStart" value
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
        StyleHelper.mkStyle "gridRowStart" (value + " " + (unbox<string>count))
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
    static member inline gridRowStart(value: int) = StyleHelper.mkStyle "gridRowStart" value
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
    static member inline gridRowStart(value: IGridSpan) = StyleHelper.mkStyle "gridRowStart" value
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
    static member inline gridRowEnd(value: string) = StyleHelper.mkStyle "gridRowEnd" value
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
        StyleHelper.mkStyle "gridRowEnd" (value + " " + (unbox<string> count))
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
    static member inline gridRowEnd(value: int) = StyleHelper.mkStyle "gridRowEnd" value
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
    static member inline gridRowEnd(value: IGridSpan) = StyleHelper.mkStyle "gridRowEnd" value
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
        StyleHelper.mkStyle "gridColumn" (start + " / " + end')
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
        StyleHelper.mkStyle "gridColumn" (start + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridColumn" (start + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + end')
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + end')
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridColumn" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" (start + " / " + end')
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
        StyleHelper.mkStyle "gridRow" (start + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" (start + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + end')
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + end')
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridRow" ((unbox<string>start) + " / " + (unbox<string>end'))
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
        StyleHelper.mkStyle "gridAutoRows" (unbox<string> value)
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
        StyleHelper.mkStyle "gridAutoRows" (unbox<string> value)
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
        StyleHelper.mkStyle "gridAutoRows" (unbox<string> value)
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
        StyleHelper.mkStyle "gridAutoColumns" (unbox<string> value)
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
        StyleHelper.mkStyle "gridAutoColumns" (unbox<string> value)
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
        StyleHelper.mkStyle "gridAutoColumns" (unbox<string> value)
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
        StyleHelper.mkStyle "gridArea" value
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
        StyleHelper.mkStyle "gridTemplate" value
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDuration(timespan: TimeSpan) =
        StyleHelper.mkStyle "transitionDuration" (unbox<string> timespan.TotalMilliseconds + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationSeconds(n: float) =
        StyleHelper.mkStyle "transitionDuration" ((unbox<string> n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationMilliseconds(n: float) =
        StyleHelper.mkStyle "transitionDuration" ((unbox<string> n) + "ms")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationSeconds(n: int) =
        StyleHelper.mkStyle "transitionDuration" ((unbox<string> n) + "s")
    /// Sets the length of time a transition animation should take to complete. By default, the
    /// value is 0s, meaning that no animation will occur.
    static member inline transitionDurationMilliseconds(n: int) =
        StyleHelper.mkStyle "transitionDuration" ((unbox<string> n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelay(timespan: TimeSpan) =
        StyleHelper.mkStyle "transitionDelay" (unbox<string> timespan.TotalMilliseconds + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelaySeconds(n: float) =
        StyleHelper.mkStyle "transitionDelay" ((unbox<string> n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelayMilliseconds(n: float) =
        StyleHelper.mkStyle "transitionDelay" ((unbox<string> n) + "ms")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelaySeconds(n: int) =
        StyleHelper.mkStyle "transitionDelay" ((unbox<string> n) + "s")
    /// Specifies the duration to wait before starting a property's transition effect when its value changes.
    static member inline transitionDelayMilliseconds(n: int) =
        StyleHelper.mkStyle "transitionDelay" ((unbox<string> n) + "ms")
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty ([<ParamArray>] properties: ITransitionProperty[]) =
        StyleHelper.mkStyle "transitionProperty" (String.concat "," (unbox<string[]> properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (properties: ITransitionProperty list) =
        StyleHelper.mkStyle "transitionProperty" (String.concat "," (unbox<string list> properties))
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (property: ITransitionProperty) =
        StyleHelper.mkStyle "transitionProperty" property
    /// Sets the CSS properties to which a transition effect should be applied.
    static member inline transitionProperty (property: string) =
        StyleHelper.mkStyle "transitionProperty" property
    
    /// Sets how intermediate values are calculated for CSS properties being affected by a transition effect.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    static member inline transitionTimingFunction (timingFunction: ITransitionTimingFunction) =
        StyleHelper.mkStyle "transitionTimingFunction" timingFunction
    
    /// Sets how intermediate values are calculated for CSS properties being affected by a transition effect.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    static member inline transitionTimingFunction (timingFunction: string) =
        StyleHelper.mkStyle "transitionTimingFunction" timingFunction

    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, timingFunction: ITransitionTimingFunction) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, timingFunction: ITransitionTimingFunction) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, timingFunction: ITransitionTimingFunction) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, timingFunction: ITransitionTimingFunction) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, delay: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, delay: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, delayInMs: int) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, delayInMs: int) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, duration: TimeSpan, timingFunction: ITransitionTimingFunction, delay: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction,
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, duration: TimeSpan, timingFunction: ITransitionTimingFunction, delay: TimeSpan) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> duration.TotalMilliseconds + "ms " +
            unbox<string> timingFunction,
            unbox<string> delay.TotalMilliseconds + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: ITransitionProperty, durationInMs: int, timingFunction: ITransitionTimingFunction, delayInMs: int) =
        StyleHelper.mkStyle "transition" (
            unbox<string> property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction,
            unbox<string> delayInMs + "ms "
        )
    /// The transition property is a shorthand property for transition-property, transition-duration,
    /// transition-timing-function, transition-delay, and transition-behavior.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    static member inline transition (property: string, durationInMs: int, timingFunction: ITransitionTimingFunction, delayInMs: int) =
        StyleHelper.mkStyle "transition" (
            property + " " +
            unbox<string> durationInMs + "ms " +
            unbox<string> timingFunction,
            unbox<string> delayInMs + "ms "
        )
    
    static member inline transform(transformation: ITransformProperty) =
        StyleHelper.mkStyle "transform" transformation

    static member inline transform(transformations: ITransformProperty list) =
        StyleHelper.mkStyle "transform" (String.concat " " (unbox transformations))

    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: int) = StyleHelper.mkStyle "fontSize" (unbox<string> size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: float) = StyleHelper.mkStyle "fontSize" (unbox<string> size + "px")
    /// Sets the size of the font.
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    static member inline fontSize(size: ICssUnit) = StyleHelper.mkStyle "fontSize" size
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
    static member inline lineHeight(size: int) = StyleHelper.mkStyle "lineHeight" size
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
    static member inline lineHeight(size: float) = StyleHelper.mkStyle "lineHeight" size
    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    ///
    /// This property is also used to compute the size of em, ex, and other relative <length> units.
    ///
    /// Note: Negative values are not allowed.
    static member inline lineHeight(size: ICssUnit) = StyleHelper.mkStyle "lineHeight" size

    /// Sets the background color of an element.
    static member inline backgroundColor (color: string) = StyleHelper.mkStyle "backgroundColor" color
    /// Sets the color of the insertion caret, the visible marker where the next character typed will be inserted.
    ///
    /// This is sometimes referred to as the text input cursor. The caret appears in elements such as <input> or
    /// those with the contenteditable attribute. The caret is typically a thin vertical line that flashes to
    /// help make it more noticeable. By default, it is black, but its color can be altered with this property.
    static member inline caretColor (color: string) = StyleHelper.mkStyle "caretColor" color
    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    static member inline color (color: string) = StyleHelper.mkStyle "color" color
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline top(value: int) = StyleHelper.mkStyle "top" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline top(value: ICssUnit) = StyleHelper.mkStyle "top" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline bottom(value: int) = StyleHelper.mkStyle "bottom" value
    /// Specifies the vertical position of a positioned element. It has no effect on non-positioned elements.
    static member inline bottom(value: ICssUnit) = StyleHelper.mkStyle "bottom" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline left(value: int) = StyleHelper.mkStyle "left" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline left(value: ICssUnit) = StyleHelper.mkStyle "left" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline right(value: int) = StyleHelper.mkStyle "right" value
    /// Specifies the horizontal position of a positioned element. It has no effect on non-positioned elements.
    static member inline right(value: ICssUnit) = StyleHelper.mkStyle "right" value
    /// Define a custom attribute of via key value pair
    static member inline custom(key: string, value: 't) = StyleHelper.mkStyle key value
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    static member inline borderBottom(width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderBottom" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's bottom border. It sets the values of border-bottom-width,
    /// border-bottom-style and border-bottom-color.
    static member inline borderBottom(width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderBottom" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    static member inline outlineWidth(width: int) =
        StyleHelper.mkStyle "outlineWidth" ((unbox<string> width) + "px")

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    static member inline outlineWidth(width: ICssUnit) =
        StyleHelper.mkStyle "outlineWidth" width

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
        StyleHelper.mkStyle "outlineOffset" ((unbox<string> offset) + "px")

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
        StyleHelper.mkStyle "outlineOffset" offset

    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    ///
    /// The `outline-color` property specifies the color of an outline.
    /// 
    /// **Note**: Always declare the outline-style property before the outline-color property. An element must have an outline before you change the color of it.
    static member inline outlineColor (color: string) =
        StyleHelper.mkStyle "outlineColor" color
    
    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    /// The outline shorthand property sets most of the outline properties in a single declaration.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    static member inline outline (width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "outline" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// An outline is a line that is drawn around elements (outside the borders) to make the element "stand out".
    /// The outline shorthand property sets most of the outline properties in a single declaration.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/outline
    static member inline outline (width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "outline" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    
    /// Set an element's left border.
    static member inline borderLeft(width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderLeft" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's left border.
    static member inline borderLeft(width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderLeft" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's right border.
    static member inline borderRight(width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderRight" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's right border.
    static member inline borderRight(width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderRight" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's top border.
    static member inline borderTop(width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderTop" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Set an element's top border.
    static member inline borderTop(width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "borderTop" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets the line style of an element's bottom border.
    static member inline borderBottomStyle(style: IBorderStyle) = StyleHelper.mkStyle "borderBottomStyle" (unbox<string> style)
    /// Sets the width of the bottom border of an element.
    static member inline borderBottomWidth (width: int) = StyleHelper.mkStyle "borderBottomWidth" (unbox<string> width + "px")
    /// Sets the width of the bottom border of an element.
    static member inline borderBottomWidth (width: ICssUnit) = StyleHelper.mkStyle "borderBottomWidth" (unbox<string> width)
    /// Sets the color of an element's bottom border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderBottomColor (color: string) = StyleHelper.mkStyle "borderBottomColor" color
    /// Sets the line style of an element's top border.
    static member inline borderTopStyle(style: IBorderStyle) = StyleHelper.mkStyle "borderTopStyle" (unbox<string> style)
    /// Sets the width of the top border of an element.
    static member inline borderTopWidth (width: int) = StyleHelper.mkStyle "borderTopWidth" (unbox<string> width + "px")
    /// Sets the width of the top border of an element.
    static member inline borderTopWidth (width: ICssUnit) = StyleHelper.mkStyle "borderTopWidth" (unbox<string> width)
    /// Sets the color of an element's top border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderTopColor (color: string) = StyleHelper.mkStyle "borderTopColor" color
    /// /// Sets the line style of an element's right border.
    static member inline borderRightStyle(style: IBorderStyle) = StyleHelper.mkStyle "borderRightStyle" (unbox<string> style)
    /// Sets the width of the right border of an element.
    static member inline borderRightWidth (width: int) = StyleHelper.mkStyle "borderRightWidth" (unbox<string> width + "px")
    /// Sets the width of the right border of an element.
    static member inline borderRightWidth (width: ICssUnit) = StyleHelper.mkStyle "borderRightWidth" (unbox<string> width)
    /// Sets the color of an element's right border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderRightColor (color: string) = StyleHelper.mkStyle "borderRightColor" color
    /// Sets the line style of an element's left border.
    static member inline borderLeftStyle(style: IBorderStyle) = StyleHelper.mkStyle "borderLeftStyle" (unbox<string> style)
    /// Sets the width of the left border of an element.
    static member inline borderLeftWidth (width: int) = StyleHelper.mkStyle "borderLeftWidth" (unbox<string> width + "px")
    /// Sets the width of the left border of an element.
    static member inline borderLeftWidth (width: ICssUnit) = StyleHelper.mkStyle "borderLeftWidth" (unbox<string> width)
    /// Sets the color of an element's left border.
    ///
    /// It can also be set with the shorthand CSS properties border-color or border-bottom.
    static member inline borderLeftColor (color: string) = StyleHelper.mkStyle "borderLeftColor" color
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: int, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "border" (
            (unbox<string> width) + "px " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: ICssUnit, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "border" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets an element's border.
    ///
    /// It sets the values of border-width, border-style, and border-color.
    static member inline border(width: string, style: IBorderStyle, color: string) =
        StyleHelper.mkStyle "border" (
            (unbox<string> width) + " " +
            (unbox<string> style) + " " +
            color
        )
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle (style: IBorderStyle) = StyleHelper.mkStyle "borderStyle" style
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle)  =
        StyleHelper.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right))
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle) =
        StyleHelper.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right) + " " +  (unbox<string> bottom))
    /// Sets the line style for all four sides of an element's border.
    static member inline borderStyle(top: IBorderStyle, right: IBorderStyle, bottom: IBorderStyle, left: IBorderStyle) =
        StyleHelper.mkStyle "borderStyle" ((unbox<string> top) + " " + (unbox<string> right) + " " + (unbox<string> bottom) + " " +  (unbox<string> left))
    /// Sets the color of an element's border.
    static member inline borderColor (color: string) = StyleHelper.mkStyle "borderColor" color
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    static member inline borderRadius (radius: int) = StyleHelper.mkStyle "borderRadius" radius
    /// Rounds the corners of an element's outer border edge. You can set a single radius to make
    /// circular corners, or two radii to make elliptical corners.
    static member inline borderRadius (radius: ICssUnit) = StyleHelper.mkStyle "borderRadius" radius
    /// top-left-and-bottom-right | top-right-and-bottom-left
    static member inline borderRadius (topLeftAndBottomRight: int, topRightAndBottomLeft: int) =
        StyleHelper.mkStyle "borderRadius" (
            (unbox<string> topLeftAndBottomRight) + "px " +
            (unbox<string> topRightAndBottomLeft) + "px"
        )

    /// top-left | top-right-and-bottom-left | bottom-right
    static member inline borderRadius (topLeft: int, topRightAndBottomLeft: int, bottomRight: int) =
        StyleHelper.mkStyle "borderRadius" (
            (unbox<string> topLeft) + "px " +
            (unbox<string> topRightAndBottomLeft) + "px " +
            (unbox<string> bottomRight) + "px"
        )

    /// top-left | top-right | bottom-right | bottom-left
    static member inline borderRadius (topLeft: int, topRight: int, bottomRight: int, bottomLeft: int) =
        StyleHelper.mkStyle "borderRadius" (
            (unbox<string> topLeft) + "px " +
            (unbox<string> topRight) + "px " +
            (unbox<string> bottomRight) + "px " +
            (unbox<string> bottomLeft) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int) =
        StyleHelper.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (width: int) = StyleHelper.mkStyle "borderWidth" width
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int, bottom: int) =
        StyleHelper.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px"
        )
    /// Sets the width of an element's border.
    static member inline borderWidth (top: int, right: int, bottom: int, left: int) =
        StyleHelper.mkStyle "borderWidth" (
            (unbox<string> top) + "px " +
            (unbox<string> right) + "px " +
            (unbox<string> bottom) + "px " +
            (unbox<string> left) + "px"
        )

    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (spacing: int) = StyleHelper.mkStyle "borderSpacing" spacing
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (spacing: ICssUnit) = StyleHelper.mkStyle "borderSpacing" spacing
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (horizontalSpacing: int, verticalSpacing: int) =
        StyleHelper.mkStyle "borderSpacing" (
            (unbox<string> horizontalSpacing) + "px " +
            (unbox<string> verticalSpacing) + "px"
        )
    /// Sets the distance between the borders of adjacent table cells
    static member inline borderSpacing (horizontalSpacing: ICssUnit, verticalSpacing: ICssUnit) =
        StyleHelper.mkStyle "borderSpacing" (
            (unbox<string> horizontalSpacing) + " " +
            (unbox<string> verticalSpacing)
        )

    /// Sets one or more animations to apply to an element. Each name is an @keyframes at-rule that
    /// sets the property values for the animation sequence.
    static member inline animationName(keyframeName: string) = StyleHelper.mkStyle "animationName" keyframeName
    /// Sets the length of time that an animation takes to complete one cycle.
    static member inline animationDuration(timespan: TimeSpan) = StyleHelper.mkStyle "animationDuration" ((unbox<string> timespan.TotalMilliseconds) + "ms")
    /// Sets the length of time that an animation takes to complete one cycle.
    static member inline animationDuration(seconds: int) = StyleHelper.mkStyle "animationDuration" ((unbox<string> seconds) + "s")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    static member inline animationDelay(timespan: TimeSpan) = StyleHelper.mkStyle "animationDelay" ((unbox<string> timespan.TotalMilliseconds) + "ms")
    /// Sets when an animation starts.
    ///
    /// The animation can start later, immediately from its beginning, or immediately and partway through the animation.
    static member inline animationDelay(seconds: int) = StyleHelper.mkStyle "animationDelay" ((unbox<string> seconds) + "s")
    /// The number of times the animation runs.
    static member inline animationDurationCount(count: int) = StyleHelper.mkStyle "animationDurationCount" count
    /// Sets the font family for the font specified in a @font-face rule.
    static member inline fontFamily (family: string) = StyleHelper.mkStyle "fontFamily" family
    /// Defines from thin to thick characters. 400 is the same as normal, and 700 is the same as bold.
    /// Possible values are [100, 200, 300, 400, 500, 600, 700, 800, 900]
    static member inline fontWeight (weight: int) = StyleHelper.mkStyle "fontWeight" weight
    /// Sets the color of decorations added to text by text-decoration-line.
    static member inline textDecorationColor(color: string) = StyleHelper.mkStyle "textDecorationColor" color
    /// Sets the kind of decoration that is used on text in an element, such as an underline or overline.
    static member inline textDecorationLine(line: ITextDecorationLine) = StyleHelper.mkStyle "textDecorationLine" line
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(line: ITextDecorationLine) = StyleHelper.mkStyle "textDecoration" line
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine) =
        StyleHelper.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration) =
        StyleHelper.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top) + " " + (unbox<string> style))
    /// Sets the appearance of decorative lines on text.
    ///
    /// It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style,
    /// and the newer text-decoration-thickness property.
    static member inline textDecoration(bottom: ITextDecorationLine, top: ITextDecorationLine, style: ITextDecoration, color: string) =
        StyleHelper.mkStyle "textDecoration" ((unbox<string> bottom) + " " + (unbox<string> top) + " " + (unbox<string> style) + " " + color)
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    static member inline textIndent(value: int) = StyleHelper.mkStyle "textIndent" value
    /// Sets the length of empty space (indentation) that is put before lines of text in a block.
    static member inline textIndent(value: string) = StyleHelper.mkStyle "textIndent" value
    /// Sets the opacity of an element.
    ///
    /// Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
    static member inline opacity(value: double) = StyleHelper.mkStyle "opacity" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: int) = StyleHelper.mkStyle "minWidth" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: ICssUnit) = StyleHelper.mkStyle "minWidth" value
    /// Sets the minimum width of an element.
    ///
    /// It prevents the used value of the width property from becoming smaller than the value specified for min-width.
    static member inline minWidth (value: string) = StyleHelper.mkStyle "minWidth" value
    /// Sets the initial position for each background image.
    ///
    /// The position is relative to the position layer set by background-origin.
    static member inline backgroundPosition  (position: string) = StyleHelper.mkStyle "backgroundPosition" position
    /// Sets the type of cursor, if any, to show when the mouse pointer is over an element.
    static member inline cursor (value: string) = StyleHelper.mkStyle "cursor" value
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    static member inline minHeight (value: int) = StyleHelper.mkStyle "minHeight" value
    /// Sets the minimum height of an element.
    ///
    /// It prevents the used value of the height property from becoming smaller than the value specified for min-height.
    static member inline minHeight (value: ICssUnit) = StyleHelper.mkStyle "minHeight" value
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    static member inline maxWidth (value: int) = StyleHelper.mkStyle "maxWidth" value
    /// Sets the maximum width of an element.
    ///
    /// It prevents the used value of the width property from becoming larger than the value specified by max-width.
    static member inline maxWidth (value: ICssUnit) = StyleHelper.mkStyle "maxWidth" value
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    static member inline maxHeight (value: int) = StyleHelper.mkStyle "maxHeight" value
    /// Sets the maximum height of an element.
    ///
    /// It prevents the used value of the height property from becoming larger than the value specified for max-height.
    static member inline maxHeight (value: ICssUnit) = StyleHelper.mkStyle "maxHeight" value
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    static member inline height (value: int) = StyleHelper.mkStyle "height" value
    /// Set the height of an element.
    ///
    /// By default, the property defines the height of the content area.
    static member inline height (value: ICssUnit) = StyleHelper.mkStyle "height" value
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    static member inline width (value: int) = StyleHelper.mkStyle "width" value
    /// Sets the width of an element.
    ///
    /// By default, the property defines the width of the content area.
    static member inline width (value: ICssUnit) = StyleHelper.mkStyle "width" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (value: string) = StyleHelper.mkStyle "backgroundSize" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (value: ICssUnit) = StyleHelper.mkStyle "backgroundSize" value
    /// Sets the size of the element's background image.
    ///
    /// The image can be left to its natural size, stretched, or constrained to fit the available space.
    static member inline backgroundSize (width: ICssUnit, height: ICssUnit) =
        StyleHelper.mkStyle "backgroundSize" (
            unbox<string> width
            + " " +
            unbox<string> height
        )

    /// Sets one or more background images on an element.
    static member inline backgroundImage (value: string) = StyleHelper.mkStyle "backgroundImage" value
    /// Short-hand for `style.backgroundImage(sprintf "url('%s')" value)` to set the backround image using a url.
    static member inline backgroundImageUrl (value: string) = StyleHelper.mkStyle "backgroundImage" ("url('" + value + "')")
    /// Sets how background images are repeated.
    ///
    /// A background image can be repeated along the horizontal and vertical axes, or not repeated at all.
    static member inline backgroundRepeat (repeat: IBackgroundRepeat) = StyleHelper.mkStyle "backgroundRepeat" repeat
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, color: string) =
        StyleHelper.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, color: string) =
        StyleHelper.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            (unbox<string> blur) + "px " +
            color
        )
    /// Adds shadow effects around an element's frame.
    ///
    /// A box shadow is described by X and Y offsets relative to the element, blur and spread radii, and color.
    static member inline boxShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int, color: string) =
        StyleHelper.mkStyle "boxShadow" (
            (unbox<string> horizontalOffset) + "px " +
            (unbox<string> verticalOffset) + "px " +
            (unbox<string> blur) + "px " +
            (unbox<string> spread) + "px " +
            color
        )

    /// Sets the color of an SVG shape.
    static member inline fill (color: string) = StyleHelper.mkStyle "fill" color

    /// Specifies extra inter-character space in addition to the default space between characters.
    static member inline letterSpacing (value: int) = StyleHelper.mkStyle "letterSpacing" value
    /// Specifies extra inter-character space in addition to the default space between characters.
    static member inline letterSpacing (value: ICssUnit) = StyleHelper.mkStyle "letterSpacing" value
    
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin) =
        StyleHelper.mkStyle "transformOrigin" (unbox<string> xOffset)
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin, yOffset: ITransformOrigin) =
        StyleHelper.mkStyle "transformOrigin" (
            unbox<string> xOffset + " " +
            unbox<string> yOffset
        ) 
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    static member inline transformOrigin (xOffset: ITransformOrigin, yOffset: ITransformOrigin, zOffset: ITransformOrigin) =
        StyleHelper.mkStyle "transformOrigin" (
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
        StyleHelper.mkStyle "scrollbarColor" (thumbColor + " " + trackColor)

    /// Sets the order to lay out an item in a flex or grid container.
    /// Items in a container are sorted by ascending order value and then by their source code order.
    /// Items not given an explicit order value are assigned the default value of 0.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/order
    static member inline order (value: int) = StyleHelper.mkStyle "order" value
    
[<Erase>]
module style =

    [<Erase>]
    type boxShadow =
        static member inline none = StyleHelper.mkStyle "boxShadow" "none"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "boxShadow" "inherit"

    [<Erase>]
    type width =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "width" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "width" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "width" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = StyleHelper.mkStyle "width" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = StyleHelper.mkStyle "width" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = StyleHelper.mkStyle "width" "min-content"

    [<Erase>]
    type minWidth =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "minWidth" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "minWidth" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "minWidth" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = StyleHelper.mkStyle "minWidth" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = StyleHelper.mkStyle "minWidth" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = StyleHelper.mkStyle "minWidth" "min-content"

     [<Erase>]
    type maxWidth =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "maxWidth" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "maxWidth" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "maxWidth" "unset"

        /// The larger of either the intrinsic minimum width or the smaller of the intrinsic preferred width and the available width
        static member inline fitContent = StyleHelper.mkStyle "maxWidth" "fit-content"

        /// The intrinsic preferred width.
        static member inline maxContent = StyleHelper.mkStyle "maxWidth" "max-content"

        /// The intrinsic minimum width.
        static member inline minContent = StyleHelper.mkStyle "maxWidth" "min-content"

    [<Erase>]
    type height =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "height" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "height" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "height" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = StyleHelper.mkStyle "height" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = StyleHelper.mkStyle "height" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = StyleHelper.mkStyle "height" "min-content"

    [<Erase>]
    type minHeight =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "minHeight" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "minHeight" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "minHeight" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = StyleHelper.mkStyle "minHeight" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = StyleHelper.mkStyle "minHeight" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = StyleHelper.mkStyle "minHeight" "min-content"

    [<Erase>]
    type maxHeight =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "maxHeight" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "maxHeight" "initial"
        /// Resets this property to its inherited value if it inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "maxHeight" "unset"

        /// The larger of either the intrinsic minimum height or the smaller of the intrinsic preferred height and the available height
        static member inline fitContent = StyleHelper.mkStyle "maxHeight" "fit-content"

        /// The intrinsic preferred height.
        static member inline maxContent = StyleHelper.mkStyle "maxHeight" "max-content"

        /// The intrinsic minimum height.
        static member inline minContent = StyleHelper.mkStyle "maxHeight" "min-content"

    [<Erase>]
    type textJustify =
        /// The browser determines the justification algorithm
        static member inline auto = StyleHelper.mkStyle "textJustify" "auto"
        /// Increases/Decreases the space between words
        static member inline interWord = StyleHelper.mkStyle "textJustify" "inter-word"
        /// Increases/Decreases the space between characters
        static member inline interCharacter = StyleHelper.mkStyle "textJustify" "inter-character"
        /// Disables justification methods
        static member inline none = StyleHelper.mkStyle "textJustify" "none"
        static member inline initial = StyleHelper.mkStyle "textJustify" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textJustify" "inherit"

    [<Erase>]
    type whitespace =
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary. This is default.
        static member inline normal = StyleHelper.mkStyle "whiteSpace" "normal"
        /// Sequences of whitespace will collapse into a single whitespace. Text will never wrap to the next line.
        /// The text continues on the same line until a `<br>` tag is encountered.
        static member inline nowrap = StyleHelper.mkStyle "whiteSpace" "nowrap"
        /// Whitespace is preserved by the browser. Text will only wrap on line breaks. Acts like the <pre> tag in HTML.
        static member inline pre = StyleHelper.mkStyle "whiteSpace" "pre"
        /// Sequences of whitespace will collapse into a single whitespace. Text will wrap when necessary, and on line breaks
        static member inline preline = StyleHelper.mkStyle "whiteSpace" "pre-line"
        /// Whitespace is preserved by the browser. Text will wrap when necessary, and on line breaks
        static member inline prewrap = StyleHelper.mkStyle "whiteSpace" "pre-wrap"
        /// The behavior is identical to that of pre-wrap, except that:
        /// *) Any sequence of preserved white space or other space separators always takes up space, including at the end of the line.
        /// *) A soft wrap opportunity exists after every preserved white space character and after every other space separator (including between adjacent spaces).
        static member inline breakSpaces = StyleHelper.mkStyle "whiteSpace" "break-spaces"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "whiteSpace" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "whiteSpace" "inherit"

    [<Erase>]
    type wordBreak =
        /// Default value. Uses default line break rules.
        static member inline normal = StyleHelper.mkStyle "wordBreak" "normal"
        /// To prevent overflow, word may be broken at any character
        static member inline breakAll = StyleHelper.mkStyle "wordBreak" "break-all"
        /// Word breaks should not be used for Chinese/Japanese/Korean (CJK) text. Non-CJK text behavior is the same as value "normal"
        static member inline keepAll = StyleHelper.mkStyle "wordBreak" "keep-all"
        /// To prevent overflow, word may be broken at arbitrary points.
        static member inline breakWord = StyleHelper.mkStyle "wordBreak" "break-word"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "wordBreak" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "wordBreak" "inherit"

    [<Erase>]
    type scrollBehavior =
        /// Allows a straight jump "scroll effect" between elements within the scrolling box. This is default
        static member inline auto = StyleHelper.mkStyle "scrollBehavior" "auto"
        /// Allows a smooth animated "scroll effect" between elements within the scrolling box.
        static member inline smooth = StyleHelper.mkStyle "scrollBehavior" "smooth"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "scrollBehavior" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "scrollBehavior" "inherit"

    /// Sets how strictly snap points are enforced on the scroll container in case there is one.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-type
    [<Erase>]
    type scrollSnapType =
        /// When the visual viewport of this scroll container is scrolled, it must ignore snap points.
        static member inline none = StyleHelper.mkStyle "scrollSnapType" "none"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        static member inline x = StyleHelper.mkStyle "scrollSnapType" "x"
        /// The scroll container snaps to snap positions in its vertical axis only.
        static member inline y = StyleHelper.mkStyle "scrollSnapType" "y"
        /// The scroll container snaps to snap positions in its block axis only.
        static member inline block = StyleHelper.mkStyle "scrollSnapType" "block"
        /// The scroll container snaps to snap positions in its inline axis only.
        static member inline inline' = StyleHelper.mkStyle "scrollSnapType" "inline"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        static member inline both = StyleHelper.mkStyle "scrollSnapType" "both"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline xMandatory = StyleHelper.mkStyle "scrollSnapType" "x mandatory"
        /// The scroll container snaps to snap positions in its horizontal axis only.
        /// 
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline xProximity = StyleHelper.mkStyle "scrollSnapType" "x proximity"
        /// The scroll container snaps to snap positions in its vertical axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline yMandatory = StyleHelper.mkStyle "scrollSnapType" "y mandatory"
        /// The scroll container snaps to snap positions in its vertical axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline yProximity = StyleHelper.mkStyle "scrollSnapType" "y proximity"
        /// The scroll container snaps to snap positions in its block axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline blockMandatory = StyleHelper.mkStyle "scrollSnapType" "block mandatory"
        /// The scroll container snaps to snap positions in its block axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline blockProximity = StyleHelper.mkStyle "scrollSnapType" "block proximity"
        /// The scroll container snaps to snap positions in its inline axis only.
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline inlineMandatory = StyleHelper.mkStyle "scrollSnapType" "inline mandatory"
        /// The scroll container snaps to snap positions in its inline axis only.
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline inlineProximity = StyleHelper.mkStyle "scrollSnapType" "inline proximity"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        /// 
        /// The visual viewport of this scroll container must snap to a snap position if it isn't currently scrolled.
        static member inline bothMandatory = StyleHelper.mkStyle "scrollSnapType" "both mandatory"
        /// The scroll container snaps to snap positions in both of its axes independently
        /// (potentially snapping to different elements in each axis).
        ///
        /// The visual viewport of this scroll container may snap to a snap position if it isn't currently scrolled.
        /// The user agent decides if it snaps or not based on scroll parameters. This is the default snap strictness
        /// if any snap axis is specified.
        static member inline bothProximity = StyleHelper.mkStyle "scrollSnapType" "both proximity"

    /// Specifies the box's snap position as an alignment of its snap area (as the alignment subject)
    /// within its snap container's snap port (as the alignment container).
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scroll-snap-align
    [<Erase>]
    type scrollSnapAlign =
        /// This box does not define a snap position in the specified axis. 
        static member inline none = StyleHelper.mkStyle "scrollSnapAlign" "none"
        /// Start alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline start = StyleHelper.mkStyle "scrollSnapAlign" "start"
        /// Center alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline center = StyleHelper.mkStyle "scrollSnapAlign" "center"
        /// End alignment of this box’s scroll snap area within the scroll
        /// container’s snapport is a snap position in the specified axis. 
        static member inline end' = StyleHelper.mkStyle "scrollSnapAlign" "end"
        static member inline noneStart = StyleHelper.mkStyle "scrollSnapAlign" "none start"
        static member inline noneCenter = StyleHelper.mkStyle "scrollSnapAlign" "none center"
        static member inline noneEnd =  StyleHelper.mkStyle "scrollSnapAlign" "none end"
        static member inline startNone = StyleHelper.mkStyle "scrollSnapAlign" "start none"
        static member inline startCenter = StyleHelper.mkStyle "scrollSnapAlign" "start center"
        static member inline startEnd =  StyleHelper.mkStyle "scrollSnapAlign" "start end"
        static member inline centerNone = StyleHelper.mkStyle "scrollSnapAlign" "center none"
        static member inline centerStart = StyleHelper.mkStyle "scrollSnapAlign" "center start"
        static member inline centerEnd =  StyleHelper.mkStyle "scrollSnapAlign" "center end"
        static member inline endNone = StyleHelper.mkStyle "scrollSnapAlign" "end none"
        static member inline endStart = StyleHelper.mkStyle "scrollSnapAlign" "end start"
        static member inline endCenter =  StyleHelper.mkStyle "scrollSnapAlign" "end center"
    
    
    
    /// Sets the maximum thickness of an element's scrollbars when they are shown.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-width
    [<Erase>]
    type scrollbarWidth =
        /// The default scrollbar width for the platform.
        static member inline auto = StyleHelper.mkStyle "scrollbarWidth" "auto"
        /// A thin scrollbar width variant on platforms that provide that option,
        /// or a thinner scrollbar than the default platform scrollbar width. 
        static member inline thin = StyleHelper.mkStyle "scrollbarWidth" "thin"
        /// No scrollbar shown, however the element will still be scrollable.
        static member inline none = StyleHelper.mkStyle "scrollbarWidth" "none"
    
    /// Reserves space for the scrollbar, preventing unwanted layout changes as
    /// the content grows while also avoiding unnecessary visuals when scrolling
    /// isn't needed.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-gutter
    [<Erase>]
    type scrollbarGutter =
        /// The initial value. Classic scrollbars create a gutter when overflow
        /// is scroll, or when overflow is auto and the box is overflowing.
        /// Overlay scrollbars do not consume space.
        static member inline auto = StyleHelper.mkStyle "scrollbarGutter" "auto"
        /// When using classic scrollbars, the gutter will be present if overflow
        /// is auto, scroll, or hidden even if the box is not overflowing.
        /// When using overlay scrollbars, the gutter will not be present.
        static member inline stable = StyleHelper.mkStyle "scrollbarGutter" "stable"
        /// When using classic scrollbars, the gutter will be present if overflow
        /// is auto, scroll, or hidden even if the box is not overflowing.
        /// When using overlay scrollbars, the gutter will not be present.
        /// 
        /// If a gutter would be present on one of the inline start/end edges
        /// of the box, another will be present on the opposite edge as well.
        static member inline stableBothEdges = StyleHelper.mkStyle "scrollbarGutter" "stable both-edges"

    /// sets the color of the scrollbar track and thumb.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/scrollbar-color
    [<Erase>]
    type scrollbarColor =
        static member inline auto = StyleHelper.mkStyle "scrollbarColor" "auto"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "scrollbarColor" "inherit"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "scrollbarColor" "initial"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "scrollbarColor" "unset"
        static member inline revert = StyleHelper.mkStyle "scrollbarColor" "revert"
        static member inline revertLayer = StyleHelper.mkStyle "scrollbarColor" "revert-layer"

    [<Erase>]
    type overflow =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = StyleHelper.mkStyle "overflow" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = StyleHelper.mkStyle "overflow" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = StyleHelper.mkStyle "overflow" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = StyleHelper.mkStyle "overflow" "auto"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "overflow" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "overflow" "inherit"

    [<Erase>]
    type overflowX =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = StyleHelper.mkStyle "overflowX" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = StyleHelper.mkStyle "overflowX" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = StyleHelper.mkStyle "overflowX" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = StyleHelper.mkStyle "overflowX" "auto"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "overflowX" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "overflowX" "inherit"

    [<Erase>]
    type textOrientation =
        /// The characters are rotated 90° clockwise. This is the default value of this property.
        static member inline mixed = StyleHelper.mkStyle "textOrientation" "mixed"
        /// The characters of horizontal scripts are laid out naturally (upright), as
        /// well as the glyphs for vertical scripts. This property makes all the 
        /// characters to be considered as left-to-right: the used value of direction is forced to be ltr.
        static member inline upright = StyleHelper.mkStyle "textOrientation" "upright"
        /// The characters are laid out as they would be horizontally, but with the whole
        /// line rotated 90° clockwise.
        static member inline sideways = StyleHelper.mkStyle "textOrientation" "sideways"
        /// An alias to sideways that is kept for compatibility purposes.
        static member inline sidewaysRight = StyleHelper.mkStyle "textOrientation" "sideways-right"
        /// It makes the property use its default value.
        static member inline initial = StyleHelper.mkStyle "textOrientation" "initial"
        /// It inherits the property from its parents element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textOrientation" "inherit"
    [<Erase>]
    type visibility =
        /// The element is hidden (but still takes up space).
        static member inline hidden = StyleHelper.mkStyle "visibility" "hidden"
        /// Default value. The element is visible.
        static member inline visible = StyleHelper.mkStyle "visibility" "visible"
        /// Only for table rows (`<tr>`), row groups (`<tbody>`), columns (`<col>`), column groups
        /// (`<colgroup>`). This value removes a row or column, but it does not affect the table layout.
        /// The space taken up by the row or column will be available for other content.
        ///
        /// If collapse is used on other elements, it renders as "hidden"
        static member inline collapse = StyleHelper.mkStyle "visibility" "collapse"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "visibility" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "visibility" "inherit"

    [<Erase>]
    type flexBasis =
        /// Default value. The length is equal to the length of the flexible item. If the item has
        /// no length specified, the length will be according to its content.
        static member inline auto = StyleHelper.mkStyle "flexBasis" "auto"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "flexBasis" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "flexBasis" "inherit"

    [<Erase>]
    type flexDirection =
        /// Default value. The flexible items are displayed horizontally, as a row
        static member inline row = StyleHelper.mkStyle "flexDirection" "row"
        /// Same as row, but in reverse order.
        static member inline rowReverse = StyleHelper.mkStyle "flexDirection" "row-reverse"
        /// The flexible items are displayed vertically, as a column
        static member inline column = StyleHelper.mkStyle "flexDirection" "column"
        /// Same as column, but in reverse order
        static member inline columnReverse = StyleHelper.mkStyle "flexDirection" "column-reverse"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "flexBasis" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "flexBasis" "inherit"

    [<Erase>]
    type flexWrap =
        /// Default value. Specifies that the flexible items will not wrap.
        static member inline nowrap = StyleHelper.mkStyle "flexWrap" "nowrap"
        /// Specifies that the flexible items will wrap if necessary
        static member inline wrap = StyleHelper.mkStyle "flexWrap" "wrap"
        /// Specifies that the flexible items will wrap, if necessary, in reverse order
        static member inline wrapReverse = StyleHelper.mkStyle "flexWrap" "wrap-reverse"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "flexWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "flexWrap" "inherit"

    /// Places an element on the left or right side of its container, allowing text and
    /// inline elements to wrap around it. The element is removed from the normal flow
    /// of the page, though still remaining a part of the flow (in contrast to absolute
    /// positioning).
    [<Erase>]
    type float' =
        /// The element must float on the left side of its containing block.
        static member inline left = StyleHelper.mkStyle "float" "left"
        /// The element must float on the right side of its containing block.
        static member inline right = StyleHelper.mkStyle "float" "right"
        /// The element must not float.
        static member inline none = StyleHelper.mkStyle "float" "none"

    /// Determines how a font face is displayed based on whether and when it is downloaded and ready to use.
    [<Erase>]
    type fontDisplay =
        /// The font display strategy is defined by the user agent.
        ///
        /// Default value
        static member inline auto = StyleHelper.mkStyle "fontDisplay" "auto"
        /// Gives the font face a short block period and an infinite swap period.
        static member inline block = StyleHelper.mkStyle "fontDisplay" "block"
        /// Gives the font face an extremely small block period and an infinite swap period.
        static member inline swap = StyleHelper.mkStyle "fontDisplay" "swap"
        /// Gives the font face an extremely small block period and a short swap period.
        static member inline fallback = StyleHelper.mkStyle "fontDisplay" "fallback"
        /// Gives the font face an extremely small block period and no swap period.
        static member inline optional = StyleHelper.mkStyle "fontDisplay" "optional"

    [<Erase>]
    type fontKerning =
        /// Default. The browser determines whether font kerning should be applied or not
        static member inline auto = StyleHelper.mkStyle "fontKerning" "auto"
        /// Specifies that font kerning is applied
        static member inline normal = StyleHelper.mkStyle "fontKerning" "normal"
        /// Specifies that font kerning is not applied
        static member inline none = StyleHelper.mkStyle "fontKerning" "none"

    /// The font-weight property sets how thick or thin characters in text should be displayed.
    [<Erase>]
    type fontWeight =
        /// Defines normal characters. This is default.
        static member inline normal = StyleHelper.mkStyle "fontWeight" "normal"
        /// Defines thick characters.
        static member inline bold = StyleHelper.mkStyle "fontWeight" "bold"
        /// Defines thicker characters
        static member inline bolder = StyleHelper.mkStyle "fontWeight" "bolder"
        /// Defines lighter characters.
        static member inline lighter = StyleHelper.mkStyle "fontWeight" "lighter"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "fontWeight" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "fontWeight" "inherit"

    [<Erase>]
    type fontStyle =
        /// The browser displays a normal font style. This is defaut.
        static member inline normal = StyleHelper.mkStyle "fontStyle" "normal"
        /// The browser displays an italic font style.
        static member inline italic = StyleHelper.mkStyle "fontStyle" "italic"
        /// The browser displays an oblique font style.
        static member inline oblique = StyleHelper.mkStyle "fontStyle" "oblique"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "fontStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "fontStyle" "inherit"

    [<Erase>]
    type fontVariant =
        /// The browser displays a normal font. This is default
        static member inline normal = StyleHelper.mkStyle "fontVariant" "normal"
        /// The browser displays a small-caps font
        static member inline smallCaps = StyleHelper.mkStyle "fontVariant" "small-caps"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "fontVariant" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "fontVariant" "inherit"

    [<Erase>]
    type overflowY =
        /// The content is not clipped, and it may be rendered outside the left and right edges. This is default.
        static member inline visible = StyleHelper.mkStyle "overflowY" "visible"
        /// The content is clipped - and no scrolling mechanism is provided.
        static member inline hidden = StyleHelper.mkStyle "overflowY" "hidden"
        /// The content is clipped and a scrolling mechanism is provided.
        static member inline scroll = StyleHelper.mkStyle "overflowY" "scroll"
        /// Should cause a scrolling mechanism to be provided for overflowing boxes
        static member inline auto = StyleHelper.mkStyle "overflowY" "auto"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "overflowY" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "overflowY" "inherit"

    [<Erase>]
    type wordWrap =
        /// Break words only at allowed break points
        static member inline normal = StyleHelper.mkStyle "wordWrap" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = StyleHelper.mkStyle "wordWrap" "break-word"
        /// To prevent overflow, an otherwise unbreakable string of characters — like a long word or URL — may be broken
        /// at any point if there are no otherwise-acceptable break points in the line.
        static member inline anywhere = StyleHelper.mkStyle "wordWrap" "anywhere"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "wordWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "wordWrap" "inherit"

    /// The overflow-anchor property makes it possible to turn off scroll anchoring.
    /// Scroll anchoring is a feature in the browser that prevents a viewable area that is scrolled into focus to move when new content is loaded above. This is typically a problem on a slow connection if the user scrolls down and starts reading before the page is fully loaded.
    [<Erase>]
    type overflowAnchor =
        /// Default value. Scroll anchoring is enabled
        static member inline auto = StyleHelper.mkStyle "overflowAnchor" "auto"
        /// Scroll anchoring is disabled
        static member inline none = StyleHelper.mkStyle "overflowAnchor" "none"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "overflowAnchor" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "overflowAnchor" "inherit"

    /// The overflow-wrap property applies to inline elements, setting whether the browser should insert line breaks
    /// within an otherwise unbreakable string to prevent text from overflowing its line box.
    [<Erase>]
    type overflowWrap =
        /// Break words only at allowed break points
        static member inline normal = StyleHelper.mkStyle "overflowWrap" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = StyleHelper.mkStyle "overflowWrap" "break-word"
        /// To prevent overflow, an otherwise unbreakable string of characters — like a long word or URL — may be broken
        /// at any point if there are no otherwise-acceptable break points in the line.
        static member inline anywhere = StyleHelper.mkStyle "overflowWrap" "anywhere"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "overflowWrap" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "overflowWrap" "inherit"

    /// Sets the horizontal spacing behavior between text characters.
    [<Erase>]
    type letterSpacing =
        /// The normal letter spacing for the current font
        static member inline normal = StyleHelper.mkStyle "letterSpacing" "normal"
        /// Allows unbreakable words to be broken
        static member inline breakWord = StyleHelper.mkStyle "letterSpacing" "break-word"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "letterSpacing" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "letterSpacing" "inherit"
    
    /// Sets the distance between the borders of adjacent table cells.
    [<Erase>]
    type borderSpacing =
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "borderSpacing" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "borderSpacing" "inherit"

    /// The `align-self` CSS property overrides a grid or flex item's `align-items` value.
    /// - In Grid, it aligns the item inside the grid area.
    /// - In Flexbox, it aligns the item on the cross axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-self
    /// **Note**: The property doesn't apply to block-level boxes, or to table cells. If a flexbox item's cross-axis margin is auto, then align-self is ignored.
    [<Erase>]
    type alignSelf =
        /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container.
        static member inline auto = StyleHelper.mkStyle "alignSelf" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In static position of absolutely-positioned layouts, the keyword behaves as stretch.
        /// - For flex items, the keyword behaves as stretch.
        /// - For grid items, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        /// - The property doesn't apply to block-level boxes, and to table cells.
        static member inline normal = StyleHelper.mkStyle "alignSelf" "normal"
        
        /// The flex item's margin box is centered within the line on the cross-axis.
        /// If the cross-size of the item is larger than the flex container, it will overflow equally in both directions.
        static member inline center = StyleHelper.mkStyle "alignSelf" "center"
        /// Put the item at the start
        static member inline start = StyleHelper.mkStyle "alignSelf" "start"
        /// Put the item at the end
        static member inline end' = StyleHelper.mkStyle "alignSelf" "end"        
        /// Aligns the items to be flush with the edge of the alignment container corresponding to the item's start side in the cross axis.
        static member inline selfStart = StyleHelper.mkStyle "alignSelf" "self-start"
        /// Aligns the items to be flush with the edge of the alignment container corresponding to the item's end side in the cross axis.
        static member inline selfEnd = StyleHelper.mkStyle "alignSelf" "self-end"
        /// The cross-start margin edge of the flex item is flushed with the cross-start edge of the line.
        static member inline flexStart = StyleHelper.mkStyle "alignSelf" "flex-start"
        /// The cross-end margin edge of the flex item is flushed with the cross-end edge of the line.
        static member inline flexEnd = StyleHelper.mkStyle "alignSelf" "flex-end"
        
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        static member inline baseline = StyleHelper.mkStyle "alignSelf" "baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// 
        /// The fallback alignment for first baseline is start
        static member inline firstBaseline = StyleHelper.mkStyle "alignSelf" "first baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// 
        /// The fallback alignment for last baseline is end
        static member inline lastBaseline = StyleHelper.mkStyle "alignSelf" "last baseline"
        /// If the combined size of the items along the cross axis is less than the size of the alignment container
        /// and the item is auto-sized, its size is increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size of all auto-sized items exactly fills the alignment container along the cross axis.
        static member inline stretch = StyleHelper.mkStyle "alignSelf" "stretch"
        
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "alignSelf" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "alignSelf" "inherit"
        static member inline revert = StyleHelper.mkStyle "alignSelf" "revert"
        static member inline unset = StyleHelper.mkStyle "alignSelf" "unset"

    /// The CSS `align-items` property sets the `align-self` value on all direct children as a group.
    /// - In Grid Layout, it controls the alignment of items on the Block Axis within their grid area.
    /// - In Flexbox, it controls the alignment of items on the Cross Axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-items
    [<Erase>]
    type alignItems =
        /// Default. Items are stretched to fit the container
        static member inline stretch = StyleHelper.mkStyle "alignItems" "stretch"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In static position of absolutely-positioned layouts, the keyword behaves as stretch.
        /// - For flex items, the keyword behaves as stretch.
        /// - For grid items, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        /// - The property doesn't apply to block-level boxes, and to table cells.
        static member inline normal = StyleHelper.mkStyle "alignItems" "normal"

        /// The flex items' margin boxes are centered within the line on the cross-axis.
        /// If the cross-size of an item is larger than the flex container, it will overflow equally in both directions.
        static member inline center = StyleHelper.mkStyle "alignItems"  "center"
        /// The items are packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = StyleHelper.mkStyle "alignItems" "start"
        /// The items are packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = StyleHelper.mkStyle "alignItems" "end"
        /// The cross-start margin edges of the flex items are flushed with the cross-start edge of the line.
        static member inline flexStart = StyleHelper.mkStyle "alignItems" "flex-start"
        /// The cross-end margin edges of the flex items are flushed with the cross-end edge of the line.
        static member inline flexEnd = StyleHelper.mkStyle "alignItems" "flex-end"

        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline baseline = StyleHelper.mkStyle "alignItems" "baseline"
        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline firstBaseline = StyleHelper.mkStyle "alignItems" "first baseline"
        /// All flex items are aligned such that their flex container baselines align.
        /// The item with the largest distance between its cross-start margin edge and
        /// its baseline is flushed with the cross-start edge of the line.
        static member inline lastBaseline = StyleHelper.mkStyle "alignItems" "last baseline"

        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "alignItems"  "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "alignItems"  "inherit"
        static member inline revert = StyleHelper.mkStyle "alignItems"  "revert"
        static member inline unset = StyleHelper.mkStyle "alignItems"  "unset"

    /// The CSS `align-content` property sets the distribution of space between and around content items
    /// along a flexbox's cross-axis or a grid's block axis.
    /// **Reference**: https://developer.mozilla.org/en-US/docs/Web/CSS/align-content
    /// **Note**: This property has no effect on single line flex containers (i.e. ones with `flex-wrap: nowrap`).
    ///
    /// **Tip**: Use the justify-content property to align the items on the main-axis (horizontally).
    [<Erase>]
    type alignContent =
        /// Default value. The items are packed in their default position as if no `align-content` value was set.
        static member inline normal = StyleHelper.mkStyle "alignContent" "normal"
        
        /// The items are packed flush to each other in the center of the alignment container along the cross axis.
        static member inline center = StyleHelper.mkStyle "alignContent" "center"
        /// The items are packed flush to each other against the start edge of the alignment container in the cross axis.
        static member inline start = StyleHelper.mkStyle "alignContent" "start"
        /// The items are packed flush to each other against the end edge of the alignment container in the cross axis.
        static member inline end' = StyleHelper.mkStyle "alignContent" "end"
        /// The items are packed flush to each other against the edge of the alignment container depending on the
        /// flex container's cross-start side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `start`.
        static member inline flexStart = StyleHelper.mkStyle "alignContent" "flex-start"
        /// The items are packed flush to each other against the edge of the alignment container depending on the
        /// flex container's cross-end side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `end`.
        static member inline flexEnd = StyleHelper.mkStyle "alignContent" "flex-end"

        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        static member inline baseline = StyleHelper.mkStyle "alignContent" "baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for first baseline is start.
        static member inline firstBaseline = StyleHelper.mkStyle "alignContent" "first baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment
        /// baseline of the box's first or last baseline set with the corresponding baseline
        /// in the shared first or last baseline set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for last baseline is end.
        static member inline lastBaseline = StyleHelper.mkStyle "alignContent" "last baseline"

        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The first item is flush with the start edge of the alignment container in the cross axis,
        /// and the last item is flush with the end edge of the alignment container in the cross axis.
        static member inline spaceBetween = StyleHelper.mkStyle "alignContent" "space-between"
        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The empty space before the first and after the last item equals half of the space
        /// between each pair of adjacent items.
        static member inline spaceAround = StyleHelper.mkStyle "alignContent" "space-around"
        /// The items are evenly distributed within the alignment container along the cross axis.
        /// The spacing between each pair of adjacent items, the start edge and the first item,
        /// and the end edge and the last item, are all exactly the same.
        static member inline spaceEvenly = StyleHelper.mkStyle "alignContent" "space-evenly"
        /// If the combined size of the items along the cross axis is less than the size of the
        /// alignment container, any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container along the cross axis.
        static member inline stretch = StyleHelper.mkStyle "alignContent" "stretch"

        static member inline initial = StyleHelper.mkStyle "alignContent" "initial"
        static member inline inheritFromParent = StyleHelper.mkStyle "alignContent" "inherit"
        static member inline revert = StyleHelper.mkStyle "alignContent" "revert"
        static member inline unset = StyleHelper.mkStyle "alignContent" "unset"

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
        static member inline auto = StyleHelper.mkStyle "justifySelf" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In block-level layouts, the keyword is a synonym of start.
        /// - In absolutely-positioned layouts, the keyword behaves like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In table cell layouts, this keyword has no meaning as this property is ignored.
        /// - In flexbox layouts, this keyword has no meaning as this property is ignored.
        /// - In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like start.
        static member inline normal = StyleHelper.mkStyle "justifySelf" "normal"
        /// If the combined size of the items is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container.
        static member inline stretch = StyleHelper.mkStyle "justifySelf" "stretch"

        /// Items are positioned at the center of the container
        static member inline center = StyleHelper.mkStyle "justifySelf" "center"
        /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = StyleHelper.mkStyle "justifySelf" "start"
        /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = StyleHelper.mkStyle "justifySelf" "end"
        /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
        static member inline selfStart = StyleHelper.mkStyle "justifySelf" "self-start"
        /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
        static member inline selfEnd = StyleHelper.mkStyle "justifySelf" "self-end"
        /// Equivalent to 'start'. Note that justify-self is ignored in Flexbox layouts.
        static member inline flexStart = StyleHelper.mkStyle "justifySelf" "flex-start"
        /// Equivalent to 'end'. Note that justify-self is ignored in Flexbox layouts.
        static member inline flexEnd = StyleHelper.mkStyle "justifySelf" "flex-end"
        /// Pack items from the left
        static member inline left = StyleHelper.mkStyle "justifySelf" "left"
        /// Pack items from the right
        static member inline right = StyleHelper.mkStyle "justifySelf" "right"

        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for first baseline is start, the one for last baseline is end.
        static member inline baseline = StyleHelper.mkStyle "justifySelf" "baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for `first baseline` is `start`.
        static member inline firstBaseline = StyleHelper.mkStyle "justifySelf" "first baseline"
        /// Specifies participation in first- or last-baseline alignment:
        /// aligns the alignment baseline of the box's first or last baseline set
        /// with the corresponding baseline in the shared first or last baseline
        /// set of all the boxes in its baseline-sharing group.
        /// The fallback alignment for `last baseline` is `end`.
        static member inline lastBaseline = StyleHelper.mkStyle "justifySelf" "last baseline"

        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "justifySelf" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "justifySelf" "inherit"
        static member inline revert = StyleHelper.mkStyle "justifySelf" "revert"
        static member inline unset = StyleHelper.mkStyle "justifySelf" "unset"

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
        static member inline auto = StyleHelper.mkStyle "justifyItems" "auto"
        /// The effect of this keyword is dependent of the layout mode we are in:
        /// - In block-level layouts, the keyword is a synonym of start.
        /// - In absolutely-positioned layouts, the keyword behaved like start on replaced absolutely-positioned boxes, and as stretch on all other absolutely-positioned boxes.
        /// - In table cell layouts, this keyword has no meaning as this property is ignored.
        /// - In flexbox layouts, this keyword has no meaning as this property is ignored.
        /// - In grid layouts, this keyword leads to a behavior similar to the one of stretch, except for boxes with an aspect ratio or an intrinsic sizes where it behaves like `start`.
        static member inline normal = StyleHelper.mkStyle "justifyItems" "normal"
        /// If the combined size of the items is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally),
        /// while still respecting the constraints imposed by `max-height`/`max-width` (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container.
        static member inline stretch = StyleHelper.mkStyle "justifyItems" "stretch"

        /// The items are packed flush to each other toward the center of the of the alignment container.
        static member inline center = StyleHelper.mkStyle "justifyItems" "center"
        /// The item is packed flush to each other toward the start edge of the alignment container in the appropriate axis.
        static member inline start = StyleHelper.mkStyle "justifyItems" "start"
        /// The item is packed flush to each other toward the end edge of the alignment container in the appropriate axis.
        static member inline end' = StyleHelper.mkStyle "justifyItems" "end"
        /// Equivalent to 'start'. Note that justify-items is ignored in Flexbox layouts.
        static member inline flexStart = StyleHelper.mkStyle "justifyItems" "flex-start"
        /// Equivalent to 'end'. Note that justify-items is ignored in Flexbox layouts.
        static member inline flexEnd = StyleHelper.mkStyle "justifyItems" "flex-end"
        /// The item is packed flush to the edge of the alignment container of the start side of the item, in the appropriate axis.
        static member inline selfStart = StyleHelper.mkStyle "justifyItems" "self-start"
        /// The item is packed flush to the edge of the alignment container of the end side of the item, in the appropriate axis.
        static member inline selfEnd = StyleHelper.mkStyle "justifyItems" "self-end"
        /// The items are packed flush to each other toward the left edge of the alignment container.
        /// If the property's axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline left = StyleHelper.mkStyle "justifyItems" "left"
        /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis.
        /// If the property's axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline right = StyleHelper.mkStyle "justifyItems" "right"

        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        static member inline baseline = StyleHelper.mkStyle "justifyItems" "baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        /// The fallback alignment for `first baseline` is `start`.
        static member inline firstBaseline = StyleHelper.mkStyle "justifyItems" "first baseline"
        /// Specifies participation in first- or last-baseline alignment: aligns the alignment baseline of the box's
        /// first or last baseline set with the corresponding baseline in the shared first or last baseline set of all
        /// the boxes in its baseline-sharing group.
        /// The fallback alignment for `last baseline` is `end`.
        static member inline lastBaseline = StyleHelper.mkStyle "justifyItems" "last baseline"

        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "justifyItems" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "justifyItems" "inherit"
        static member inline revert = StyleHelper.mkStyle "justifyItems" "revert"
        static member inline unset = StyleHelper.mkStyle "justifyItems" "unset"

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
        static member inline normal = StyleHelper.mkStyle "justifyContent" "normal"

        /// The items are packed flush to each other toward the center of the alignment container along the main axis.
        static member inline center = StyleHelper.mkStyle "justifyContent" "center"
        /// The items are packed flush to each other toward the start edge of the alignment container in the main axis.
        static member inline start = StyleHelper.mkStyle "justifyContent" "start"
        /// The items are packed flush to each other toward the end edge of the alignment container in the main axis.
        static member inline end' = StyleHelper.mkStyle "justifyContent" "end"
        /// The items are packed flush to each other toward the edge of the alignment container depending on the flex container's
        /// main-start side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `start`.
        static member inline flexStart = StyleHelper.mkStyle "justifyContent" "flex-start"
        /// The items are packed flush to each other toward the edge of the alignment container depending on the flex container's
        /// main-end side. This only applies to flex layout items.
        /// For items that are not children of a flex container, this value is treated like `end`.
        static member inline flexEnd = StyleHelper.mkStyle "justifyContent" "flex-end"
        /// The items are packed flush to each other toward the left edge of the alignment container.
        /// If the property’s axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline left = StyleHelper.mkStyle "justifyContent" "left"
        /// The items are packed flush to each other toward the right edge of the alignment container in the appropriate axis.
        /// If the property’s axis is not parallel with the inline axis, this value behaves like `start`.
        static member inline right = StyleHelper.mkStyle "justifyContent" "right"

        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The first item is flush with the main-start edge, and the last item is flush with the main-end edge.
        static member inline spaceBetween = StyleHelper.mkStyle "justifyContent" "space-between"
        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items is the same.
        /// The empty space before the first and after the last item equals half of the space between each pair of adjacent items.
        static member inline spaceAround = StyleHelper.mkStyle "justifyContent" "space-around"
        /// The items are evenly distributed within the alignment container along the main axis.
        /// The spacing between each pair of adjacent items, the main-start edge and the first item,
        /// and the main-end edge and the last item, are all exactly the same.
        static member inline spaceEvenly = StyleHelper.mkStyle "justifyContent" "space-evenly"
        /// If the combined size of the items along the main axis is less than the size of the alignment container,
        /// any auto-sized items have their size increased equally (not proportionally), while still respecting
        /// the constraints imposed by max-height/max-width (or equivalent functionality),
        /// so that the combined size exactly fills the alignment container along the main axis.
        /// **Note**: stretch is not supported by flexible boxes (flexbox).
        static member inline stretch = StyleHelper.mkStyle "justifyContent" "stretch"

        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "justifyItems" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "justifyItems" "inherit"
        static member inline revert = StyleHelper.mkStyle "justifyItems" "revert"
        static member inline unset = StyleHelper.mkStyle "justifyItems" "unset"

    /// An outline is a line around an element.
    /// It is displayed around the margin of the element. However, it is different from the border property.
    /// The outline is not a part of the element's dimensions, therefore the element's width and height properties do not contain the width of the outline.
    [<Erase>]
    type outlineWidth =
        /// Specifies a medium outline. This is default.
        static member inline medium = StyleHelper.mkStyle "outlineWidth" "medium"
        /// Specifies a thin outline.
        static member inline thin = StyleHelper.mkStyle "outlineWidth" "thin"
        /// Specifies a thick outline.
        static member inline thick = StyleHelper.mkStyle "outlineWidth" "thick"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "outlineWidth" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "outlineWidth" "inherit"

    [<Erase>]
    type listStyleType =
        /// Default value. The marker is a filled circle
        static member inline disc = StyleHelper.mkStyle "listStyleType" "disc"
        /// The marker is traditional Armenian numbering
        static member inline armenian = StyleHelper.mkStyle "listStyleType" "armenian"
        /// The marker is a circle
        static member inline circle = StyleHelper.mkStyle "listStyleType" "circle"
        /// The marker is plain ideographic numbers
        static member inline cjkIdeographic = StyleHelper.mkStyle "listStyleType" "cjk-ideographic"
        /// The marker is a number
        static member inline decimal = StyleHelper.mkStyle "listStyleType" "decimal"
        /// The marker is a number with leading zeros (01, 02, 03, etc.)
        static member inline decimalLeadingZero = StyleHelper.mkStyle "listStyleType" "decimal-leading-zero"
        /// The marker is traditional Georgian numbering
        static member inline georgian = StyleHelper.mkStyle "listStyleType" "georgian"
        /// The marker is traditional Hebrew numbering
        static member inline hebrew = StyleHelper.mkStyle "listStyleType" "hebrew"
        /// The marker is traditional Hiragana numbering
        static member inline hiragana = StyleHelper.mkStyle "listStyleType" "hiragana"
        /// The marker is traditional Hiragana iroha numbering
        static member inline hiraganaIroha = StyleHelper.mkStyle "listStyleType" "hiragana-iroha"
        /// The marker is traditional Katakana numbering
        static member inline katakana = StyleHelper.mkStyle "listStyleType" "katakana"
        /// The marker is traditional Katakana iroha numbering
        static member inline katakanaIroha = StyleHelper.mkStyle "listStyleType" "katakana-iroha"
        /// The marker is lower-alpha (a, b, c, d, e, etc.)
        static member inline lowerAlpha = StyleHelper.mkStyle "listStyleType" "lower-alpha"
        /// The marker is lower-greek
        static member inline lowerGreek = StyleHelper.mkStyle "listStyleType" "lower-greek"
        /// The marker is lower-latin (a, b, c, d, e, etc.)
        static member inline lowerLatin = StyleHelper.mkStyle "listStyleType" "lower-latin"
        /// The marker is lower-roman (i, ii, iii, iv, v, etc.)
        static member inline lowerRoman = StyleHelper.mkStyle "listStyleType" "lower-roman"
        /// No marker is shown
        static member inline none = StyleHelper.mkStyle "listStyleType" "none"
        /// The marker is a square
        static member inline square = StyleHelper.mkStyle "listStyleType" "square"
        /// The marker is upper-alpha (A, B, C, D, E, etc.)
        static member inline upperAlpha = StyleHelper.mkStyle "listStyleType" "upper-alpha"
        /// The marker is upper-greek
        static member inline upperGreek = StyleHelper.mkStyle "listStyleType" "upper-greek"
        /// The marker is upper-latin (A, B, C, D, E, etc.)
        static member inline upperLatin = StyleHelper.mkStyle "listStyleType" "upper-latin"
        /// The marker is upper-roman (I, II, III, IV, V, etc.)
        static member inline upperRoman = StyleHelper.mkStyle "listStyleType" "upper-roman"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = StyleHelper.mkStyle "listStyleType" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = StyleHelper.mkStyle "listStyleType" "inherit"

    [<Erase>]
    type listStyleImage =
        /// No image will be displayed. Instead, the list-style-type property will define what type of list marker will be rendered. This is default
        static member inline none = StyleHelper.mkStyle "listStyleImage" "none"
        /// The path to the image to be used as a list-item marker
        static member inline url (path: string) = StyleHelper.mkStyle "listStyleImage" ("url('" + path + "')")
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = StyleHelper.mkStyle "listStyleImage" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = StyleHelper.mkStyle "listStyleImage" "inherit"

    [<Erase>]
    type listStylePosition =
        /// The bullet points will be inside the list item
        static member inline inside = StyleHelper.mkStyle "listStylePosition" "inside"
        /// The bullet points will be outside the list item. This is default
        static member inline outside = StyleHelper.mkStyle "listStylePosition" "outside"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = StyleHelper.mkStyle "listStylePosition" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = StyleHelper.mkStyle "listStylePosition" "inherit"

    [<Erase>]
    type textAlign =
        /// Aligns the text to the left.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align
        static member inline left = StyleHelper.mkStyle "textAlign" "left"
        /// Aligns the text to the right.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=right
        static member inline right = StyleHelper.mkStyle "textAlign" "right"
        /// Centers the text.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=center
        static member inline center = StyleHelper.mkStyle "textAlign" "center"
        /// Stretches the lines so that each line has equal width (like in newspapers and magazines).
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=justify
        static member inline justify = StyleHelper.mkStyle "textAlign" "justify"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline initial = StyleHelper.mkStyle "textAlign" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-align&preval=initial
        static member inline inheritFromParent = StyleHelper.mkStyle "textAlign" "inherit"

    [<Erase>]
    type textDecorationLine =
        static member inline none = StyleHelper.mkStyle "textDecorationLine" "none"
        static member inline underline = StyleHelper.mkStyle "textDecorationLine" "underline"
        static member inline overline = StyleHelper.mkStyle "textDecorationLine" "overline"
        static member inline lineThrough = StyleHelper.mkStyle "textDecorationLine" "line-through"
        static member inline initial = StyleHelper.mkStyle "textDecorationLine" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textDecorationLine" "inherit"

    [<Erase>]
    type textDecoration =
        static member inline none = StyleHelper.mkStyle "textDecoration" "none"
        static member inline underline = StyleHelper.mkStyle "textDecoration" "underline"
        static member inline overline = StyleHelper.mkStyle "textDecoration" "overline"
        static member inline lineThrough = StyleHelper.mkStyle "textDecoration" "line-through"
        static member inline initial = StyleHelper.mkStyle "textDecoration" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textDecoration" "inherit"

    /// The `transform-style` property specifies how nested elements are rendered in 3D space.
    [<Erase>]
    type transformStyle =
        /// Specifies that child elements will NOT preserve its 3D position. This is default.
        static member inline flat = StyleHelper.mkStyle "transformStyle" "flat"
        /// Specifies that child elements will preserve its 3D position
        static member inline preserve3D = StyleHelper.mkStyle "transformStyle" "preserve-3d"
        static member inline initial = StyleHelper.mkStyle "transformStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "transformStyle" "inherit"

    [<Erase>]
    type textTransform =
        /// No capitalization. The text renders as it is. This is default.
        static member inline none = StyleHelper.mkStyle "textTransform" "none"
        /// Transforms the first character of each word to uppercase.
        static member inline capitalize = StyleHelper.mkStyle "textTransform" "capitalize"
        /// Transforms all characters to uppercase.
        static member inline uppercase = StyleHelper.mkStyle "textTransform" "uppercase"
        /// Transforms all characters to lowercase.
        static member inline lowercase = StyleHelper.mkStyle "textTransform" "lowercase"
        static member inline initial = StyleHelper.mkStyle "textTransform" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textTransform" "inherit"

    [<Erase>]
    type textOverflow =
        /// Default value. The text is clipped and not accessible.
        static member inline clip = StyleHelper.mkStyle "textOverflow" "clip"
        /// Render an ellipsis ("...") to represent the clipped text.
        static member inline ellipsis = StyleHelper.mkStyle "textOverflow" "ellipsis"
        /// Render the given string to represent the clipped text.
        static member inline custom(value: string) = StyleHelper.mkStyle "textOverflow" value
        static member inline initial = StyleHelper.mkStyle "textOverflow" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textOverflow" "inherit"

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
        static member inline none = StyleHelper.mkStyle "filter" "none"
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline blur(value: int) = StyleHelper.mkStyle "filter" ("blur(" + (unbox<string> value) + "%)")
        /// Applies a blur effect to the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline blur(value: double) = StyleHelper.mkStyle "filter" ("blur(" + (unbox<string> value) + ")")
        /// Adjusts the brightness of the element
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        ///
        /// Values over 100% will provide brighter results.
        static member inline brightness(value: int) = StyleHelper.mkStyle "filter" ("brightness(" + (unbox<string> value) + "%)")
        /// Adjusts the brightness of the element. A larger value will create more blur.
        ///
        /// This overload takes a floating number that goes from 0 to 1,
        static member inline brightness(value: double) = StyleHelper.mkStyle "filter" ("brightness(" + (unbox<string> value) + ")")
        /// Adjusts the contrast of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline contrast(value: int) = StyleHelper.mkStyle "filter" ("contrast(" + (unbox<string> value) + "%)")
        /// Adjusts the contrast of the element. A larger value will create more contrast.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline contrast(value: double) = StyleHelper.mkStyle "filter" ("contrast(" + (unbox<string> value) + ")")
        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, blur: int, spread: int, color: string) =
            StyleHelper.mkStyle "filter" (
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
            StyleHelper.mkStyle "filter" (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                (unbox<string> blur) + "px " +
                color +
                ")"
            )

        /// Applies a drop shadow effect.
        static member inline dropShadow(horizontalOffset: int, verticalOffset: int, color: string) =
            StyleHelper.mkStyle "filter" (
                "drop-shadow(" +
                (unbox<string> horizontalOffset) + "px " +
                (unbox<string> verticalOffset) + "px " +
                color +
                ")"
            )

        /// Converts the image to grayscale
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline grayscale(value: int) = StyleHelper.mkStyle "filter" ("grayscale(" + (unbox<string> value) + "%)")
        /// Converts the image to grayscale
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline grayscale(value: double) = StyleHelper.mkStyle "filter" ("grayscale(" + (unbox<string> value) + ")")
        /// Applies a hue rotation on the image. The value defines the number of degrees around the color circle the image
        /// samples will be adjusted. 0deg is default, and represents the original image.
        ///
        /// **Note**: Maximum value is 360
        static member inline hueRotate(degrees: int) = StyleHelper.mkStyle "filter" ("hue-rotate(" + (unbox<string> degrees) + "deg)")
        /// Inverts the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline invert(value: int) = StyleHelper.mkStyle "filter" ("invert(" + (unbox<string> value) + "%)")
        /// Inverts the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline invert(value: double) = StyleHelper.mkStyle "filter" ("invert(" + (unbox<string> value) + ")")
        /// Sets the opacity of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline opacity(value: int) = StyleHelper.mkStyle "filter" ("opacity(" + (unbox<string> value) + "%)")
        /// Sets the opacity of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline opacity(value: double) = StyleHelper.mkStyle "filter" ("opacity(" + (unbox<string> value) + ")")
        /// Sets the saturation of the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline saturate(value: int) = StyleHelper.mkStyle "filter" ("saturate(" + (unbox<string> value) + "%)")
        /// Sets the saturation of the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline saturate(value: double) = StyleHelper.mkStyle "filter" ("saturate(" + (unbox<string> value) + ")")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes an integer that represents a percentage from 0 to 100.
        static member inline sepia(value: int) = StyleHelper.mkStyle "filter" ("sepia(" + (unbox<string> value) + "%)")
        /// Applies Sepia filter to the element.
        ///
        /// This overload takes a floating number that goes from 0 to 1
        static member inline sepia(value: double) = StyleHelper.mkStyle "filter" ("sepia(" + (unbox<string> value) + ")")
        /// The url() function takes the location of an XML file that specifies an SVG filter, and may include an anchor to a specific filter element.
        ///
        /// Example: `filter: url(svg-url#element-id)`
        static member inline url(value: string) = StyleHelper.mkStyle "filter" ("url(" + value + ")")
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "filter" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "filter" "inherit"
        /// Applies zero or more filters to the same element
        static member inline multiple(filters: seq<IFilter>) =
            let filters = Seq.map unbox<string> filters |> String.concat " "
            StyleHelper.mkStyle "filter" filters

    /// Sets whether table borders should collapse into a single border or be separated as in standard HTML.
    [<Erase>]
    type borderCollapse =
        /// Borders are separated; each cell will display its own borders. This is default.
        static member inline separate = StyleHelper.mkStyle "borderCollapse" "separate"
        /// Borders are collapsed into a single border when possible (border-spacing and empty-cells properties have no effect)
        static member inline collapse = StyleHelper.mkStyle "borderCollapse" "collapse"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "borderCollapse" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "borderCollapse" "inherit"

    /// Specifies the size of the background images
    [<Erase>]
    type backgroundSize =
        /// Default value. The background image is displayed in its original size
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=auto)
        static member inline auto = StyleHelper.mkStyle "backgroundSize" "auto"
        /// Resize the background image to cover the entire container, even if it has to stretch the image or cut a little bit off one of the edges.
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=cover)
        static member inline cover = StyleHelper.mkStyle "backgroundSize" "cover"
        /// Resize the background image to make sure the image is fully visible
        ///
        /// See [example here](https://www.w3schools.com/cssref/playit.asp?filename=playcss_background-size&preval=contain)
        static member inline contain = StyleHelper.mkStyle "backgroundSize" "contain"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "backgroundSize" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "backgroundSize" "inherit"

    [<Erase>]
    type textDecorationStyle =
        /// Default value. The line will display as a single line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=solid
        static member inline solid = StyleHelper.mkStyle "textDecorationStyle" "solid"
        /// The line will display as a double line.
        ///
        /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=double
        static member inline double = StyleHelper.mkStyle "textDecorationStyle" "double"
        /// The line will display as a dotted line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dotted
        static member inline dotted = StyleHelper.mkStyle "textDecorationStyle" "dotted"
        /// The line will display as a dashed line.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dashed
        static member inline dashed = StyleHelper.mkStyle "textDecorationStyle" "dashed"
        /// The line will display as a wavy line.
        ///
        /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=wavy
        static member inline wavy = StyleHelper.mkStyle "textDecorationStyle" "wavy"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=initial
        static member inline initial = StyleHelper.mkStyle "textDecorationStyle" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "textDecorationStyle" "inherit"

    [<Erase>]
    type fontStretch =
        /// Makes the text as narrow as it gets.
        static member inline ultraCondensed = StyleHelper.mkStyle "fontStretch" "ultra-condensed"
        /// Makes the text narrower than condensed, but not as narrow as ultra-condensed
        static member inline extraCondensed = StyleHelper.mkStyle "fontStretch" "extra-condensed"
        /// Makes the text narrower than semi-condensed, but not as narrow as extra-condensed.
        static member inline condensed = StyleHelper.mkStyle "fontStretch" "condensed"
        /// Makes the text narrower than normal, but not as narrow as condensed.
        static member inline semiCondensed = StyleHelper.mkStyle "fontStretch" "semi-condensed"
        /// Default value. No font stretching
        static member inline normal = StyleHelper.mkStyle "fontStretch" "normal"
        /// Makes the text wider than normal, but not as wide as expanded
        static member inline semiExpanded = StyleHelper.mkStyle "fontStretch" "semi-expanded"
        /// Makes the text wider than semi-expanded, but not as wide as extra-expanded
        static member inline expanded = StyleHelper.mkStyle "fontStretch" "expanded"
        /// Makes the text wider than expanded, but not as wide as ultra-expanded
        static member inline extraExpanded = StyleHelper.mkStyle "fontStretch" "extra-expanded"
        /// Makes the text as wide as it gets.
        static member inline ultraExpanded = StyleHelper.mkStyle "fontStretch" "ultra-expanded"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "fontStretch" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "fontStretch" "inherit"

    /// Specifies how an element should float.
    ///
    /// **Note**: Absolutely positioned elements ignores the float property!
    [<Erase>]
    type floatStyle =
        /// The element does not float, (will be displayed just where it occurs in the text). This is default
        static member inline none = StyleHelper.mkStyle "float" "none"
        static member inline left = StyleHelper.mkStyle "float" "left"
        static member inline right = StyleHelper.mkStyle "float" "right"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "float" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "float" "inherit"

    [<Erase>]
    type verticalAlign =
        /// The element is aligned with the baseline of the parent. This is default.
        static member inline baseline = StyleHelper.mkStyle "verticalAlign" "baseline"
        /// The element is aligned with the subscript baseline of the parent
        static member inline sub = StyleHelper.mkStyle "verticalAlign" "sup"
        /// The element is aligned with the superscript baseline of the parent.
        static member inline super = StyleHelper.mkStyle "verticalAlign" "super"
        /// The element is aligned with the top of the tallest element on the line.
        static member inline top = StyleHelper.mkStyle "verticalAlign" "top"
        /// The element is aligned with the top of the parent element's font.
        static member inline textTop = StyleHelper.mkStyle "verticalAlign" "text-top"
        /// The element is placed in the middle of the parent element.
        static member inline middle = StyleHelper.mkStyle "verticalAlign" "middle"
        /// The element is aligned with the lowest element on the line.
        static member inline bottom = StyleHelper.mkStyle "verticalAlign" "bottom"
        /// The element is aligned with the bottom of the parent element's font
        static member inline textBottom = StyleHelper.mkStyle "verticalAlign" "text-bottom"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "verticalAlign" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "verticalAlign" "inherit"

    /// Specifies whether lines of text are laid out horizontally or vertically.
    [<Erase>]
    type writingMode =
        /// Let the content flow horizontally from left to right, vertically from top to bottom
        static member inline horizontalTopBottom = StyleHelper.mkStyle "writingMode" "horizontal-tb"
        /// Let the content flow vertically from top to bottom, horizontally from right to left
        static member inline verticalRightLeft = StyleHelper.mkStyle "writingMode" "vertical-rl"
        /// Let the content flow vertically from top to bottom, horizontally from left to right
        static member inline verticalLeftRight = StyleHelper.mkStyle "writingMode" "vertical-lr"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "writingMode" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "writingMode" "inherit"

    [<Erase>]
    type animationTimingFunction =
        /// Default value. Specifies a animation effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
        static member inline ease = StyleHelper.mkStyle "animationTimingFunction" "ease"
        /// Specifies a animation effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
        static member inline linear = StyleHelper.mkStyle "animationTimingFunction" "linear"
        /// Specifies a animation effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
        static member inline easeIn = StyleHelper.mkStyle "animationTimingFunction" "ease-in"
        /// Specifies a animation effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
        static member inline easeOut = StyleHelper.mkStyle "animationTimingFunction" "ease-out"
        /// Specifies a animation effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
        static member inline easeInOut = StyleHelper.mkStyle "animationTimingFunction" "ease-in-out"
        /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
        static member inline cubicBezier(n1: float, n2: float, n3: float, n4: float) =
            StyleHelper.mkStyle "animationTimingFunction" (
                "cubic-bezier(" + (unbox<string> n1) + "," +
                (unbox<string> n2) + "," +
                (unbox<string> n3) + "," +
                (unbox<string> n4) + ")"
            )
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "animationTimingFunction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "animationTimingFunction" "inherit"

    [<Erase>]
    type transitionTimingFunction =
        /// Default value. Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1)).
        static member inline ease = StyleHelper.mkStyle "transitionTimingFunction" "ease"
        /// Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
        static member inline linear = StyleHelper.mkStyle "transitionTimingFunction" "linear"
        /// Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1)).
        static member inline easeIn = StyleHelper.mkStyle "transitionTimingFunction" "ease-in"
        /// Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1)).
        static member inline easeOut = StyleHelper.mkStyle "transitionTimingFunction" "ease-out"
        /// Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
        static member inline easeInOut = StyleHelper.mkStyle "transitionTimingFunction" "ease-in-out"
        /// Equivalent to steps(1, start)
        static member inline stepStart = StyleHelper.mkStyle "transitionTimingFunction" "step-start"
        /// Equivalent to steps(1, end)
        static member inline stepEnd = StyleHelper.mkStyle "transitionTimingFunction" "step-end"
        static member inline stepsToEnd(steps: int) =
            StyleHelper.mkStyle "transitionTimingFunction" ("steps(" + (unbox<string> steps) + ", end)")
        static member inline stepsToStart(steps: int) =
            StyleHelper.mkStyle "transitionTimingFunction" ("steps(" + (unbox<string> steps) + ", start)")
        /// Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
        static member inline cubicBezier(n1: float, n2: float, n3: float, n4: float) =
            StyleHelper.mkStyle "transitionTimingFunction" (
                "cubic-bezier(" + (unbox<string> n1) + "," +
                (unbox<string> n2) + "," +
                (unbox<string> n3) + "," +
                (unbox<string> n4) + ")"
            )
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "transitionTimingFunction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "transitionTimingFunction" "inherit"

    [<Erase>]
    type userSelect =
        /// Default. Text can be selected if the browser allows it.
        static member inline auto = StyleHelper.mkStyle "userSelect" "auto"
        /// Prevents text selection.
        static member inline none = StyleHelper.mkStyle "userSelect" "none"
        /// The text can be selected by the user.
        static member inline text = StyleHelper.mkStyle "userSelect" "text"
        /// Text selection is made with one click instead of a double-click.
        static member inline all = StyleHelper.mkStyle "userSelect" "all"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "userSelect" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "userSelect" "inherit"

    [<Erase>]
    type borderStyle =
        /// Specifies a dotted border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline dotted = StyleHelper.mkStyle "borderStyle" "dotted"
        /// Specifies a dashed border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline dashed = StyleHelper.mkStyle "borderStyle" "dashed"
        /// Specifies a solid border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline solid = StyleHelper.mkStyle "borderStyle" "solid"
        /// Specifies a double border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline double = StyleHelper.mkStyle "borderStyle" "double"
        /// Specifies a 3D grooved border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline groove = StyleHelper.mkStyle "borderStyle" "groove"
        /// Specifies a 3D ridged border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline ridge = StyleHelper.mkStyle "borderStyle" "ridge"
        /// Specifies a 3D inset border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline inset = StyleHelper.mkStyle "borderStyle" "inset"
        /// Specifies a 3D outset border. The effect depends on the border-color value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline outset = StyleHelper.mkStyle "borderStyle" "outset"
        /// Default value. Specifies no border.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=dotted
        static member inline none = StyleHelper.mkStyle "borderStyle" "none"
        /// The same as "none", except in border conflict resolution for table elements.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        static member inline hidden = StyleHelper.mkStyle "borderStyle" "hidden"
        /// Sets this property to its default value.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        ///
        /// Read about initial value https://www.w3schools.com/cssref/css_initial.asp
        static member inline initial = StyleHelper.mkStyle "borderStyle" "initial"
        /// Inherits this property from its parent element.
        ///
        /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_border-style&preval=hidden
        ///
        /// Read about inherit https://www.w3schools.com/cssref/css_inherit.asp
        static member inline inheritFromParent = StyleHelper.mkStyle "borderStyle" "inherit"

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
        static member inline auto = StyleHelper.mkStyle "tableLayout" "auto"
        /// Sets a fixed table layout algorithm. The table and column widths are set by the widths of table and col
        /// or by the width of the first row of cells. Cells in other rows do not affect column widths. If no widths
        /// are present on the first row, the column widths are divided equally across the table, regardless of content
        /// inside the cells
        static member inline fixed' = StyleHelper.mkStyle "tableLayout" "fixed"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "tableLayout" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "tableLayout" "inherit"

    [<Erase>]
    type display =
        /// Displays an element as an inline element (like `<span>`). Any height and width properties will have no effect.
        static member inline inlineElement = StyleHelper.mkStyle "display" "inline"
        /// Displays an element as a block element (like `<p>`). It starts on a new line, and takes up the whole width.
        static member inline block = StyleHelper.mkStyle "display" "block"
        /// Makes the container disappear, making the child elements children of the element the next level up in the DOM.
        static member inline contents = StyleHelper.mkStyle "display" "contents"
        /// Displays an element as a block-level flex container.
        static member inline flex = StyleHelper.mkStyle "display" "flex"
        /// Displays an element as a block container box, and lays out its contents using flow layout.
        ///
        /// It always establishes a new block formatting context for its contents.
        static member inline flowRoot = StyleHelper.mkStyle "display" "flow-root"
        /// Displays an element as a block-level grid container.
        static member inline grid = StyleHelper.mkStyle "display" "grid"
        /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values.
        static member inline inlineBlock = StyleHelper.mkStyle "display" "inline-block"
        /// Displays an element as an inline-level flex container.
        static member inline inlineFlex = StyleHelper.mkStyle "display" "inline-flex"
        /// Displays an element as an inline-level grid container
        static member inline inlineGrid = StyleHelper.mkStyle "display" "inline-grid"
        /// The element is displayed as an inline-level table.
        static member inline inlineTable = StyleHelper.mkStyle "display" "inline-table"
        /// Let the element behave like a `<li>` element
        static member inline listItem = StyleHelper.mkStyle "display" "list-item"
        /// Displays an element as either block or inline, depending on context.
        static member inline runIn = StyleHelper.mkStyle "display" "run-in"
        /// Let the element behave like a `<table>` element.
        static member inline table = StyleHelper.mkStyle "display" "table"
        /// Let the element behave like a <caption> element.
        static member inline tableCaption = StyleHelper.mkStyle "display" "table-caption"
        /// Let the element behave like a <colgroup> element.
        static member inline tableColumnGroup = StyleHelper.mkStyle "display" "table-column-group"
        /// Let the element behave like a <thead> element.
        static member inline tableHeaderGroup = StyleHelper.mkStyle "display" "table-header-group"
        /// Let the element behave like a <tfoot> element.
        static member inline tableFooterGroup = StyleHelper.mkStyle "display" "table-footer-group"
        /// Let the element behave like a <tbody> element.
        static member inline tableRowGroup = StyleHelper.mkStyle "display" "table-row-group"
        /// Let the element behave like a <td> element.
        static member inline tableCell = StyleHelper.mkStyle "display" "table-cell"
        /// Let the element behave like a <col> element.
        static member inline tableColumn = StyleHelper.mkStyle "display" "table-column"
        /// Let the element behave like a <tr> element.
        static member inline tableRow = StyleHelper.mkStyle "display" "table-row"
        /// The element is completely removed.
        static member inline none = StyleHelper.mkStyle "display" "none"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "display" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "display" "inherit"

    /// The cursor CSS property sets the type of cursor, if any, to show when the mouse pointer is over an element.
    /// See documentation at https://developer.mozilla.org/en-US/docs/Web/CSS/cursor
    [<Erase>]
    type cursor =
        /// The User Agent will determine the cursor to display based on the current context. E.g., equivalent to text when hovering text.
        static member inline auto = StyleHelper.mkStyle "cursor" "auto"
        /// The cursor indicates an alias of something is to be created
        static member inline alias = StyleHelper.mkStyle "cursor" "alias"
        /// The platform-dependent default cursor. Typically an arrow.
        static member inline defaultCursor = StyleHelper.mkStyle "cursor" "default"
        /// No cursor is rendered.
        static member inline none = StyleHelper.mkStyle "cursor" "none"
        /// A context menu is available.
        static member inline contextMenu = StyleHelper.mkStyle "cursor" "context-menu"
        /// Help information is available.
        static member inline help = StyleHelper.mkStyle "cursor" "help"
        /// The cursor is a pointer that indicates a link. Typically an image of a pointing hand.
        static member inline pointer = StyleHelper.mkStyle "cursor" "pointer"
        /// The program is busy in the background, but the user can still interact with the interface (in contrast to `wait`).
        static member inline progress = StyleHelper.mkStyle "cursor" "progress"
        /// The program is busy, and the user can't interact with the interface (in contrast to progress). Sometimes an image of an hourglass or a watch.
        static member inline wait = StyleHelper.mkStyle "cursor" "wait"
        /// The table cell or set of cells can be selected.
        static member inline cell = StyleHelper.mkStyle "cursor" "cell"
        /// Cross cursor, often used to indicate selection in a bitmap.
        static member inline crosshair = StyleHelper.mkStyle "cursor" "crosshair"
        /// The text can be selected. Typically the shape of an I-beam.
        static member inline text = StyleHelper.mkStyle "cursor" "text"
        /// The vertical text can be selected. Typically the shape of a sideways I-beam.
        static member inline verticalText = StyleHelper.mkStyle "cursor" "vertical-text"
        /// Something is to be copied.
        static member inline copy = StyleHelper.mkStyle "cursor" "copy"
        /// Something is to be moved.
        static member inline move = StyleHelper.mkStyle "cursor" "move"
        /// An item may not be dropped at the current location. On Windows and Mac OS X, `no-drop` is the same as `not-allowed`.
        static member inline noDrop = StyleHelper.mkStyle "cursor" "no-drop"
        /// The requested action will not be carried out.
        static member inline notAllowed = StyleHelper.mkStyle "cursor" "not-allowed"
        /// Something can be grabbed (dragged to be moved).
        static member inline grab = StyleHelper.mkStyle "cursor" "grab"
        /// Something is being grabbed (dragged to be moved).
        static member inline grabbing = StyleHelper.mkStyle "cursor" "grabbing"
        /// Something can be scrolled in any direction (panned).
        static member inline allScroll = StyleHelper.mkStyle "cursor" "all-scroll"
        /// The item/column can be resized horizontally. Often rendered as arrows pointing left and right with a vertical bar separating them.
        static member inline columnResize = StyleHelper.mkStyle "cursor" "col-resize"
        /// The item/row can be resized vertically. Often rendered as arrows pointing up and down with a horizontal bar separating them.
        static member inline rowResize = StyleHelper.mkStyle "cursor" "row-resize"
        /// Directional resize arrow
        static member inline northResize = StyleHelper.mkStyle "cursor" "n-resize"
        /// Directional resize arrow
        static member inline eastResize = StyleHelper.mkStyle "cursor" "e-resize"
        /// Directional resize arrow
        static member inline southResize = StyleHelper.mkStyle "cursor" "s-resize"
        /// Directional resize arrow
        static member inline westResize = StyleHelper.mkStyle "cursor" "w-resize"
        /// Directional resize arrow
        static member inline northEastResize = StyleHelper.mkStyle "cursor" "ne-resize"
        /// Directional resize arrow
        static member inline northWestResize = StyleHelper.mkStyle "cursor" "nw-resize"
        /// Directional resize arrow
        static member inline southEastResize = StyleHelper.mkStyle "cursor" "se-resize"
        /// Directional resize arrow
        static member inline southWestResize = StyleHelper.mkStyle "cursor" "sw-resize"
        /// Directional resize arrow
        static member inline eastWestResize = StyleHelper.mkStyle "cursor" "ew-resize"
        /// Directional resize arrow
        static member inline northSouthResize = StyleHelper.mkStyle "cursor" "ns-resize"
        /// Directional resize arrow
        static member inline northEastSouthWestResize = StyleHelper.mkStyle "cursor" "nesw-resize"
        /// Directional resize arrow
        static member inline northWestSouthEastResize = StyleHelper.mkStyle "cursor" "nwse-resize"
        /// Something can be zoomed (magnified) in
        static member inline zoomIn = StyleHelper.mkStyle "cursor" "zoom-in"
        /// Something can be zoomed out
        static member inline zoomOut = StyleHelper.mkStyle "cursor" "zoom-out"

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
        static member inline auto = StyleHelper.mkStyle "outlineStyle" "auto"
        /// Specifies no outline. This is default.
        static member inline none = StyleHelper.mkStyle "outlineStyle" "none"
        /// Specifies a hidden outline
        static member inline hidden = StyleHelper.mkStyle "outlineStyle" "hidden"
        /// Specifies a dotted outline
        static member inline dotted = StyleHelper.mkStyle "outlineStyle" "dotted"
        /// Specifies a dashed outline
        static member inline dashed = StyleHelper.mkStyle "outlineStyle" "dashed"
        /// Specifies a solid outline
        static member inline solid = StyleHelper.mkStyle "outlineStyle" "solid"
        /// Specifies a double outliner
        static member inline double = StyleHelper.mkStyle "outlineStyle" "double"
        /// Specifies a 3D grooved outline. The effect depends on the outline-color value
        static member inline groove = StyleHelper.mkStyle "outlineStyle" "groove"
        /// Specifies a 3D ridged outline. The effect depends on the outline-color value
        static member inline ridge = StyleHelper.mkStyle "outlineStyle" "ridge"
        /// Specifies a 3D inset  outline. The effect depends on the outline-color value
        static member inline inset = StyleHelper.mkStyle "outlineStyle" "inset"
        /// Specifies a 3D outset outline. The effect depends on the outline-color value
        static member inline outset = StyleHelper.mkStyle "outlineStyle" "outset"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "outlineStyle" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "outlineStyle" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "outlineStyle" "unset"

    /// The object-fit CSS property sets how the content of a replaced element, such as an <img> or <video>, should be resized to fit its container.
    [<Erase>]
    type objectFit =
        /// The replaced content is scaled to maintain its aspect ratio while fitting within the element's content box. The entire object is made to fill the box, while preserving its aspect ratio, so the object will be "letterboxed" if its aspect ratio does not match the aspect ratio of the box.
        static member inline contain = StyleHelper.mkStyle "objectFit" "contain"
        /// The replaced content is sized to maintain its aspect ratio while filling the element's entire content box. If the object's aspect ratio does not match the aspect ratio of its box, then the object will be clipped to fit.
        static member inline cover = StyleHelper.mkStyle "objectFit" "cover"
        /// The replaced content is sized to fill the element's content box. The entire object will completely fill the box. If the object's aspect ratio does not match the aspect ratio of its box, then the object will be stretched to fit.
        static member inline fill = StyleHelper.mkStyle "objectFit" "fill"
        /// The replaced content is not resized.
        static member inline none = StyleHelper.mkStyle "objectFit" "none"
        /// The content is sized as if none or contain were specified, whichever would result in a smaller concrete object size.
        static member inline scaleDown = StyleHelper.mkStyle "objectFit" "scale-down"
    
    [<Erase>]
    type backgroundPosition =
        /// The background image will scroll with the page. This is default.
        static member inline scroll = StyleHelper.mkStyle "backgroundPosition" "scroll"
        /// The background image will not scroll with the page.
        static member inline fixedNoScroll = StyleHelper.mkStyle "backgroundPosition" "fixed"
        /// The background image will scroll with the element's contents.
        static member inline local = StyleHelper.mkStyle "backgroundPosition" "local"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "backgroundPosition" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "backgroundPosition" "inherit"

    /// This property defines the blending mode of each background layer (color and/or image).
    [<Erase>]
    type backgroundBlendMode =
        /// This is default. Sets the blending mode to normal.
        static member inline normal = StyleHelper.mkStyle "backgroundBlendMode" "normal"
        /// Sets the blending mode to screen
        static member inline screen = StyleHelper.mkStyle "backgroundBlendMode" "screen"
        /// Sets the blending mode to overlay
        static member inline overlay = StyleHelper.mkStyle "backgroundBlendMode" "overlay"
        /// Sets the blending mode to darken
        static member inline darken = StyleHelper.mkStyle "backgroundBlendMode" "darken"
        /// Sets the blending mode to multiply
        static member inline lighten = StyleHelper.mkStyle "backgroundBlendMode" "lighten"
        /// Sets the blending mode to color-dodge
        static member inline collorDodge = StyleHelper.mkStyle "backgroundBlendMode" "color-dodge"
        /// Sets the blending mode to saturation
        static member inline saturation = StyleHelper.mkStyle "backgroundBlendMode" "saturation"
        /// Sets the blending mode to color
        static member inline color = StyleHelper.mkStyle "backgroundBlendMode" "color"
        /// Sets the blending mode to luminosity
        static member inline luminosity = StyleHelper.mkStyle "backgroundBlendMode" "luminosity"

    /// Defines how far the background (color or image) should extend within an element.
    [<Erase>]
    type backgroundClip =
        /// Default value. The background extends behind the border.
        static member inline borderBox = StyleHelper.mkStyle "backgroundClip" "border-box"
        /// The background extends to the inside edge of the border.
        static member inline paddingBox = StyleHelper.mkStyle "backgroundClip" "padding-box"
        /// The background extends to the edge of the content box.
        static member inline contentBox = StyleHelper.mkStyle "backgroundClip" "content-box"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "backgroundClip" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "backgroundClip" "inherit"

    [<Erase>]
    type transform =
        /// Defines that there should be no transformation.
        static member inline none = StyleHelper.mkStyle "transform" "none"
        /// Defines a 2D transformation, using a matrix of six values.
        static member inline matrix(x1: int, y1: int, z1: int, x2: int, y2: int, z2: int) =
            StyleHelper.mkStyle "transform" (
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
            StyleHelper.mkStyle "transform" (
                "translate(" + (unbox<string> x) + "px," + (unbox<string> y) + "px)"
            )
        /// Defines a 2D translation.
        static member inline translate(x: ICssUnit, y: ICssUnit) =
            StyleHelper.mkStyle "transform" (
                "translate(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )

        /// Defines a 3D translation.
        static member inline translate3D(x: int, y: int, z: int) =
            StyleHelper.mkStyle "transform" (
                "translate3d(" + (unbox<string> x) + "px," + (unbox<string> y) + "px," + (unbox<string> z) + "px)"
            )
        /// Defines a 3D translation.
        static member inline translate3D(x: ICssUnit, y: ICssUnit, z: ICssUnit) =
            StyleHelper.mkStyle "transform" (
                "translate3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: int) =
            StyleHelper.mkStyle "transform" ("translateX(" + (unbox<string> x) + "px)")
        /// Defines a translation, using only the value for the X-axis.
        static member inline translateX(x: ICssUnit) =
            StyleHelper.mkStyle "transform" ("translateX(" + (unbox<string> x) + ")")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: int) =
            StyleHelper.mkStyle "transform" ("translateY(" + (unbox<string> y) + "px)")
        /// Defines a translation, using only the value for the Y-axis
        static member inline translateY(y: ICssUnit) =
            StyleHelper.mkStyle "transform" ("translateY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: int) =
            StyleHelper.mkStyle "transform" ("translateZ(" + (unbox<string> z) + "px)")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline translateZ(z: ICssUnit) =
            StyleHelper.mkStyle "transform" ("translateZ(" + (unbox<string> z) + ")")

        /// Defines a 2D scale transformation.
        static member inline scale(x: int, y: int) =
            StyleHelper.mkStyle "transform" (
                "scale(" + (unbox<string> x) + "," + (unbox<string> y) + ")"
            )
        /// Defines a scale transformation.
        static member inline scale(n: int) =
            StyleHelper.mkStyle "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a scale transformation.
        static member inline scale(n: float) =
            StyleHelper.mkStyle "transform" (
                "scale(" + (unbox<string> n) + ")"
            )

        /// Defines a 3D scale transformation
        static member inline scale3D(x: int, y: int, z: int) =
            StyleHelper.mkStyle "transform" (
                "scale3d(" + (unbox<string> x) + "," + (unbox<string> y) + "," + (unbox<string> z) + ")"
            )

        /// Defines a scale transformation by giving a value for the X-axis.
        static member inline scaleX(x: int) =
            StyleHelper.mkStyle "transform" ("scaleX(" + (unbox<string> x) + ")")

        /// Defines a scale transformation by giving a value for the Y-axis.
        static member inline scaleY(y: int) =
            StyleHelper.mkStyle "transform" ("scaleY(" + (unbox<string> y) + ")")
        /// Defines a 3D translation, using only the value for the Z-axis
        static member inline scaleZ(z: int) =
            StyleHelper.mkStyle "transform" ("scaleZ(" + (unbox<string> z) + ")")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: int) =
            StyleHelper.mkStyle "transform" ("rotate(" + (unbox<string> deg) + "deg)")
        /// Defines a 2D rotation, the angle is specified in the parameter.
        static member inline rotate(deg: float) =
            StyleHelper.mkStyle "transform" ("rotate(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: float) =
            StyleHelper.mkStyle "transform" ("rotateX(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the X-axis.
        static member inline rotateX(deg: int) =
            StyleHelper.mkStyle "transform" ("rotateX(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: float) =
            StyleHelper.mkStyle "transform" ("rotateY(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Y-axis
        static member inline rotateY(deg: int) =
            StyleHelper.mkStyle "transform" ("rotateY(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: float) =
            StyleHelper.mkStyle "transform" ("rotateZ(" + (unbox<string> deg) + "deg)")
        /// Defines a 3D rotation along the Z-axis
        static member inline rotateZ(deg: int) =
            StyleHelper.mkStyle "transform" ("rotateZ(" + (unbox<string> deg) + "deg)")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: int, yAngle: int) =
            StyleHelper.mkStyle "transform" ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
        /// Defines a 2D skew transformation along the X- and the Y-axis.
        static member inline skew(xAngle: float, yAngle: float) =
            StyleHelper.mkStyle "transform" ("skew(" + (unbox<string> xAngle) + "deg," + (unbox<string> yAngle) + "deg)")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: int) =
            StyleHelper.mkStyle "transform" ("skewX(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the X-axis
        static member inline skewX(xAngle: float) =
            StyleHelper.mkStyle "transform" ("skewX(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: int) =
            StyleHelper.mkStyle "transform" ("skewY(" + (unbox<string> xAngle) + "deg)")
        /// Defines a 2D skew transformation along the Y-axis
        static member inline skewY(xAngle: float) =
            StyleHelper.mkStyle "transform" ("skewY(" + (unbox<string> xAngle) + "deg)")
        /// Defines a perspective view for a 3D transformed element
        static member inline perspective(n: int) =
            StyleHelper.mkStyle "transform" ("perspective(" + (unbox<string> n) + ")")
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "transform" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "transform" "inherit"

    [<Erase>]
    type margin =
        static member inline auto = StyleHelper.mkStyle "margin" "auto"

    /// The direction property specifies the text direction/writing direction within a block-level element.
    [<Erase>]
    type direction =
        /// Text direction goes from right-to-left
        static member inline rightToLeft = StyleHelper.mkStyle "direction" "rtl"
        /// Text direction goes from left-to-right. This is default
        static member inline leftToRight = StyleHelper.mkStyle "direction" "ltr"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "direction" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "direction" "inherit"

    /// Sets whether or not to display borders on empty cells in a table.
    [<Erase>]
    type emptyCells =
        /// Display borders on empty cells. This is default
        static member inline show = StyleHelper.mkStyle "emptyCells" "show"
        /// Hide borders on empty cells
        static member inline hide = StyleHelper.mkStyle "emptyCells" "hide"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "emptyCells" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "emptyCells" "inherit"


    /// Sets whether or not the animation should play in reverse on alternate cycles.
    [<Erase>]
    type animationDirection =
        /// Default value. The animation should be played as normal
        static member inline normal = StyleHelper.mkStyle "animationDirection" "normal"
        /// The animation should play in reverse direction
        static member inline reverse = StyleHelper.mkStyle "animationDirection" "reverse"
        /// The animation will be played as normal every odd time (1, 3, 5, etc..) and in reverse direction every even time (2, 4, 6, etc...).
        static member inline alternate = StyleHelper.mkStyle "animationDirection" "alternate"
        /// The animation will be played in reverse direction every odd time (1, 3, 5, etc..) and in a normal direction every even time (2,4,6,etc...)
        static member inline alternateReverse = StyleHelper.mkStyle "animationDirection" "alternate-reverse"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "animationDirection" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "animationDirection" "inherit"

    [<Erase>]
    type animationPlayState =
        /// Default value. Specifies that the animation is running.
        static member inline running = StyleHelper.mkStyle "animationPlayState" "running"
        /// Specifies that the animation is paused
        static member inline paused = StyleHelper.mkStyle "animationPlayState" "paused"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "animationPlayState" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "animationPlayState" "inherit"

    [<Erase>]
    type animationIterationCount =
        /// Specifies that the animation should be played infinite times (forever)
        static member inline infinite = StyleHelper.mkStyle "animationIterationCount" "infinite"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "animationIterationCount" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "animationIterationCount" "inherit"

    /// Specifies a style for the element when the animation is not playing (before it starts, after it ends, or both).
    [<Erase>]
    type animationFillMode =
        /// Default value. Animation will not apply any styles to the element before or after it is executing
        static member inline none = StyleHelper.mkStyle "animationFillMode" "none"
        /// The element will retain the style values that is set by the last keyframe (depends on animation-direction and animation-iteration-count).
        static member inline forwards = StyleHelper.mkStyle "animationFillMode" "forwards"
        /// The element will get the style values that is set by the first keyframe (depends on animation-direction), and retain this during the animation-delay period
        static member inline backwards = StyleHelper.mkStyle "animationFillMode" "backwards"
        /// The animation will follow the rules for both forwards and backwards, extending the animation properties in both directions
        static member inline both = StyleHelper.mkStyle "animationFillMode" "both"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "animationFillMode" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "animationFillMode" "inherit"

    [<Erase>]
    type backgroundRepeat =
        /// The background image is repeated both vertically and horizontally. This is default.
        static member inline repeat = StyleHelper.mkStyle "backgroundRepeat" "repeat"
        /// The background image is only repeated horizontally.
        static member inline repeatX = StyleHelper.mkStyle "backgroundRepeat" "repeat-x"
        /// The background image is only repeated vertically.
        static member inline repeatY = StyleHelper.mkStyle "backgroundRepeat" "repeat-y"
        /// The background-image is not repeated.
        static member inline noRepeat = StyleHelper.mkStyle "backgroundRepeat" "no-repeat"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "backgroundRepeat" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "backgroundRepeat" "inherit"

    [<Erase>]
    type position =
        /// Default value. Elements render in order, as they appear in the document flow.
        static member inline defaultStatic = StyleHelper.mkStyle "position" "static"
        /// The element is positioned relative to its first positioned (not static) ancestor element.
        static member inline absolute = StyleHelper.mkStyle "position" "absolute"
        /// The element is positioned relative to the browser window
        static member inline fixedRelativeToWindow = StyleHelper.mkStyle "position" "fixed"
        /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position.
        static member inline relative = StyleHelper.mkStyle "position" "relative"
        /// The element is positioned based on the user's scroll position
        ///
        /// A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed).
        ///
        /// Note: Not supported in IE/Edge 15 or earlier. Supported in Safari from version 6.1 with a -webkit- prefix.
        static member inline sticky = StyleHelper.mkStyle "position" "sticky"
        static member inline initial = StyleHelper.mkStyle "position" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "position" "inherit"


    [<Erase>]
    type order =
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "order" "inherit"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "order" "initial"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "order" "unset"
        static member inline revert = StyleHelper.mkStyle "order" "revert"
        static member inline revertLayer = StyleHelper.mkStyle "order" "revert-layer"

    /// Sets how the total width and height of an element is calculated.
    [<Erase>]
    type boxSizing =
        /// Default value. The width and height properties include the content, but does not include the padding, border, or margin.
        static member inline contentBox = StyleHelper.mkStyle "boxSizing" "content-box"
        /// The width and height properties include the content, padding, and border, but do not include the margin. Note that padding and border will be inside of the box.
        static member inline borderBox = StyleHelper.mkStyle "boxSizing" "border-box"

    /// Sets under what circumstances (if any) a particular graphics element can become the target of pointer events.
    [<Erase>]
    type pointerEvents =
        /// Default value. The element behaves as it would if the pointer-events property were not specified.
        static member inline auto = StyleHelper.mkStyle "pointerEvents" "auto"
        /// The element is never the target of pointer events; however, pointer events may target its descendant elements if those descendants have pointer-events set to some other value.
        static member inline none = StyleHelper.mkStyle "pointerEvents" "none"
        static member inline initial = StyleHelper.mkStyle "pointerEvents" "initial"
        /// Inherits this property from its parent element
        static member inline inheritFromParent = StyleHelper.mkStyle "pointerEvents" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "pointerEvents" "unset"

    /// Sets whether an element is resizable, and if so, in which directions.
    [<Erase>]
    type resize =
        /// Default value. The element offers no user-controllable method for resizing it.
        static member inline none = StyleHelper.mkStyle "resize" "none"
        /// The element displays a mechanism for allowing the user to resize it, which may be resized both horizontally and vertically.
        static member inline both = StyleHelper.mkStyle "resize" "both"
        /// The element displays a mechanism for allowing the user to resize it in the horizontal direction.
        static member inline horizontal = StyleHelper.mkStyle "resize" "horizontal"
        /// The element displays a mechanism for allowing the user to resize it in the vertical direction.
        static member inline vertical = StyleHelper.mkStyle "resize" "vertical"
        /// The element displays a mechanism for allowing the user to resize it in the block direction (either horizontally or vertically, depending on the writing-mode and direction value).
        static member inline block = StyleHelper.mkStyle "resize" "block"
        /// The element displays a mechanism for allowing the user to resize it in the inline direction (either horizontally or vertically, depending on the writing-mode and direction value).
        static member inline inline' = StyleHelper.mkStyle "resize" "inline"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "resize" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "resize" "inherit"

    /// Sets the break-before property of an element.
    ///
    /// The break-before CSS property sets how page, column, or region breaks should behave before a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakBefore =
        /// Allows, but does not force, any break (page, column, or region) to be inserted right before the principal box.
        static member inline auto = StyleHelper.mkStyle "breakBefore" "auto"
        /// Avoids any break (page, column, or region) from being inserted right before the principal box.
        static member inline avoid = StyleHelper.mkStyle "breakBefore" "avoid"
        /// Forces a page break right after the principal box. The type of this break is that of the immediately-containing fragmentation context. If we are inside a multicol container then it would force a column break, inside paged media (but not inside a multicol container) a page break.
        static member inline always = StyleHelper.mkStyle "breakBefore" "always"
        /// Forces a page break right after the principal box. Breaking through all possible fragmentation contexts. So a break inside a multicol container, which was inside a page container would force a column and page break.
        static member inline all = StyleHelper.mkStyle "breakBefore" "all"
        /// Avoids any page break right before the principal box.
        static member inline avoidPage = StyleHelper.mkStyle "breakBefore" "avoid-page"
        /// Forces a page break right before the principal box.
        static member inline page = StyleHelper.mkStyle "breakBefore" "page"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a left page.
        static member inline left = StyleHelper.mkStyle "breakBefore" "left"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a right page.
        static member inline right = StyleHelper.mkStyle "breakBefore" "right"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a recto page. (A recto page is a right page in a left-to-right spread or a left page in a right-to-left spread.)
        static member inline recto = StyleHelper.mkStyle "breakBefore" "recto"
        /// Forces one or two page breaks right before the principal box, whichever will make the next page into a verso page. (A verso page is a left page in a left-to-right spread or a right page in a right-to-left spread.)
        static member inline verso = StyleHelper.mkStyle "breakBefore" "verso"
        /// Avoids any column break right before the principal box.
        static member inline avoidColumn = StyleHelper.mkStyle "breakBefore" "avoid-column"
        /// Forces a column break right before the principal box.
        static member inline column = StyleHelper.mkStyle "breakBefore" "column"
        /// Avoids any region break right before the principal box.
        static member inline avoidRegion = StyleHelper.mkStyle "breakBefore" "avoid-region"
        /// Forces a region break right before the principal box.
        static member inline region = StyleHelper.mkStyle "breakBefore" "region"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "breakBefore" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "breakBefore" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "breakBefore" "unset"

    /// Sets the break-after property of an element.
    ///
    /// The break-after CSS property sets how page, column, or region breaks should behave after a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakAfter =
        /// Allows, but does not force, any break (page, column, or region) to be inserted right after the principal box.
        static member inline auto = StyleHelper.mkStyle "breakAfter" "auto"
        /// Avoids any break (page, column, or region) from being inserted right after the principal box.
        static member inline avoid = StyleHelper.mkStyle "breakAfter" "avoid"
        /// Forces a page break right after the principal box. The type of this break is that of the immediately-containing fragmentation context. If we are inside a multicol container then it would force a column break, inside paged media (but not inside a multicol container) a page break.
        static member inline always = StyleHelper.mkStyle "breakAfter" "always"
        /// Forces a page break right after the principal box. Breaking through all possible fragmentation contexts. So a break inside a multicol container, which was inside a page container would force a column and page break.
        static member inline all = StyleHelper.mkStyle "breakAfter" "all"
        /// Avoids any page break right after the principal box.
        static member inline avoidPage = StyleHelper.mkStyle "breakAfter" "avoid-page"
        /// Forces a page break right after the principal box.
        static member inline page = StyleHelper.mkStyle "breakAfter" "page"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a left page.
        static member inline left = StyleHelper.mkStyle "breakAfter" "left"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a right page.
        static member inline right = StyleHelper.mkStyle "breakAfter" "right"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a recto page. (A recto page is a right page in a left-to-right spread or a left page in a right-to-left spread.)
        static member inline recto = StyleHelper.mkStyle "breakAfter" "recto"
        /// Forces one or two page breaks right after the principal box, whichever will make the next page into a verso page. (A verso page is a left page in a left-to-right spread or a right page in a right-to-left spread.)
        static member inline verso = StyleHelper.mkStyle "breakAfter" "verso"
        /// Avoids any column break right after the principal box.
        static member inline avoidColumn = StyleHelper.mkStyle "breakAfter" "avoid-column"
        /// Forces a column break right after the principal box.
        static member inline column = StyleHelper.mkStyle "breakAfter" "column"
        /// Avoids any region break right after the principal box.
        static member inline avoidRegion = StyleHelper.mkStyle "breakAfter" "avoid-region"
        /// Forces a region break right after the principal box.
        static member inline region = StyleHelper.mkStyle "breakAfter" "region"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "breakAfter" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "breakAfter" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "breakAfter" "unset"
    
    /// Sets the break-inside property of an element.
    ///
    /// The break-inside CSS property sets how page, column, or region breaks should behave inside a generated box. If there is no generated box, the property is ignored.
    [<Erase>]
    type breakInside =
        /// Allows, but does not force, any break (page, column, or region) to be inserted within the principal box.
        static member inline auto = StyleHelper.mkStyle "breakInside" "auto"
        /// Avoids any break (page, column, or region) from being inserted within the principal box.
        static member inline avoid = StyleHelper.mkStyle "breakInside" "avoid"
        /// Avoids any page break within the principal box.
        static member inline avoidPage = StyleHelper.mkStyle "breakInside" "avoid-page"
        /// Avoids any column break within the principal box.
        static member inline avoidColumn = StyleHelper.mkStyle "breakInside" "avoid-column"
        /// Avoids any region break within the principal box.
        static member inline avoidRegion = StyleHelper.mkStyle "breakInside" "avoid-region"
        /// Sets this property to its default value.
        static member inline initial = StyleHelper.mkStyle "breakInside" "initial"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "breakInside" "inherit"
        /// Resets to its inherited value if the property naturally inherits from its parent,
        /// and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "breakInside" "unset"
    
    /// Sets the origin for an element's transformations.
    /// The transform origin is the point around which a transformation is applied.
    [<Erase>]
    type transformOrigin =        
        static member inline initial = StyleHelper.mkStyle "transformOrigin" "initial"
        static member inline inheritFromParent = StyleHelper.mkStyle "transformOrigin" "inherit"
        static member inline revert = StyleHelper.mkStyle "transformOrigin" "revert"
        static member inline revertLayer = StyleHelper.mkStyle "transformOrigin" "revertLayer"
        static member inline unset = StyleHelper.mkStyle "transformOrigin" "unset"

    /// Sets the background color of an element.
    [<Erase; RequireQualifiedAccess>]
    type backgroundColor =
        static member inline indianRed = StyleHelper.mkStyle "backgroundColor" "#CD5C5C"
        static member inline lightCoral = StyleHelper.mkStyle "backgroundColor" "#F08080"
        static member inline salmon = StyleHelper.mkStyle "backgroundColor" "#FA8072"
        static member inline darkSalmon = StyleHelper.mkStyle "backgroundColor" "#E9967A"
        static member inline lightSalmon = StyleHelper.mkStyle "backgroundColor" "#FFA07A"
        static member inline crimson = StyleHelper.mkStyle "backgroundColor" "#DC143C"
        static member inline red = StyleHelper.mkStyle "backgroundColor" "#FF0000"
        static member inline fireBrick = StyleHelper.mkStyle "backgroundColor" "#B22222"
        static member inline darkred = StyleHelper.mkStyle "backgroundColor" "#8B0000"
        static member inline pink = StyleHelper.mkStyle "backgroundColor" "#FFC0CB"
        static member inline lightPink = StyleHelper.mkStyle "backgroundColor" "#FFB6C1"
        static member inline hotPink = StyleHelper.mkStyle "backgroundColor" "#FF69B4"
        static member inline deepPink = StyleHelper.mkStyle "backgroundColor" "#FF1493"
        static member inline mediumVioletRed = StyleHelper.mkStyle "backgroundColor" "#C71585"
        static member inline paleVioletRed = StyleHelper.mkStyle "backgroundColor" "#DB7093"
        static member inline coral = StyleHelper.mkStyle "backgroundColor" "#FF7F50"
        static member inline tomato = StyleHelper.mkStyle "backgroundColor" "#FF6347"
        static member inline orangeRed = StyleHelper.mkStyle "backgroundColor" "#FF4500"
        static member inline darkOrange = StyleHelper.mkStyle "backgroundColor" "#FF8C00"
        static member inline orange = StyleHelper.mkStyle "backgroundColor" "#FFA500"
        static member inline gold = StyleHelper.mkStyle "backgroundColor" "#FFD700"
        static member inline yellow = StyleHelper.mkStyle "backgroundColor" "#FFFF00"
        static member inline lightYellow = StyleHelper.mkStyle "backgroundColor" "#FFFFE0"
        static member inline limonChiffon = StyleHelper.mkStyle "backgroundColor" "#FFFACD"
        static member inline lightGoldenRodYellow = StyleHelper.mkStyle "backgroundColor" "#FAFAD2"
        static member inline papayaWhip = StyleHelper.mkStyle "backgroundColor" "#FFEFD5"
        static member inline moccasin = StyleHelper.mkStyle "backgroundColor" "#FFE4B5"
        static member inline peachPuff = StyleHelper.mkStyle "backgroundColor" "#FFDAB9"
        static member inline paleGoldenRod = StyleHelper.mkStyle "backgroundColor" "#EEE8AA"
        static member inline khaki = StyleHelper.mkStyle "backgroundColor" "#F0E68C"
        static member inline darkKhaki = StyleHelper.mkStyle "backgroundColor" "#BDB76B"
        static member inline lavender = StyleHelper.mkStyle "backgroundColor" "#E6E6FA"
        static member inline thistle = StyleHelper.mkStyle "backgroundColor" "#D8BFD8"
        static member inline plum = StyleHelper.mkStyle "backgroundColor" "#DDA0DD"
        static member inline violet = StyleHelper.mkStyle "backgroundColor" "#EE82EE"
        static member inline orchid = StyleHelper.mkStyle "backgroundColor" "#DA70D6"
        static member inline fuchsia = StyleHelper.mkStyle "backgroundColor" "#FF00FF"
        static member inline magenta = StyleHelper.mkStyle "backgroundColor" "#FF00FF"
        static member inline mediumOrchid = StyleHelper.mkStyle "backgroundColor" "#BA55D3"
        static member inline mediumPurple = StyleHelper.mkStyle "backgroundColor" "#9370DB"
        static member inline rebeccaPurple = StyleHelper.mkStyle "backgroundColor" "#663399"
        static member inline blueViolet = StyleHelper.mkStyle "backgroundColor" "#8A2BE2"
        static member inline darkViolet = StyleHelper.mkStyle "backgroundColor" "#9400D3"
        static member inline darkOrchid = StyleHelper.mkStyle "backgroundColor" "#9932CC"
        static member inline darkMagenta = StyleHelper.mkStyle "backgroundColor" "#8B008B"
        static member inline purple = StyleHelper.mkStyle "backgroundColor" "#800080"
        static member inline indigo = StyleHelper.mkStyle "backgroundColor" "#4B0082"
        static member inline slateBlue = StyleHelper.mkStyle "backgroundColor" "#6A5ACD"
        static member inline darkSlateBlue = StyleHelper.mkStyle "backgroundColor" "#483D8B"
        static member inline mediumSlateBlue = StyleHelper.mkStyle "backgroundColor" "#7B68EE"
        static member inline greenYellow = StyleHelper.mkStyle "backgroundColor" "#ADFF2F"
        static member inline chartreuse = StyleHelper.mkStyle "backgroundColor" "#7FFF00"
        static member inline lawnGreen = StyleHelper.mkStyle "backgroundColor" "#7CFC00"
        static member inline lime = StyleHelper.mkStyle "backgroundColor" "#00FF00"
        static member inline limeGreen = StyleHelper.mkStyle "backgroundColor" "#32CD32"
        static member inline paleGreen = StyleHelper.mkStyle "backgroundColor" "#98FB98"
        static member inline lightGreen = StyleHelper.mkStyle "backgroundColor" "#90EE90"
        static member inline mediumSpringGreen = StyleHelper.mkStyle "backgroundColor" "#00FA9A"
        static member inline springGreen = StyleHelper.mkStyle "backgroundColor" "#00FF7F"
        static member inline mediumSeaGreen = StyleHelper.mkStyle "backgroundColor" "#3CB371"
        static member inline seaGreen = StyleHelper.mkStyle "backgroundColor" "#2E8B57"
        static member inline forestGreen = StyleHelper.mkStyle "backgroundColor" "#228B22"
        static member inline green = StyleHelper.mkStyle "backgroundColor" "#008000"
        static member inline darkGreen = StyleHelper.mkStyle "backgroundColor" "#006400"
        static member inline yellowGreen = StyleHelper.mkStyle "backgroundColor" "#9ACD32"
        static member inline oliveDrab = StyleHelper.mkStyle "backgroundColor" "#6B8E23"
        static member inline olive = StyleHelper.mkStyle "backgroundColor" "#808000"
        static member inline darkOliveGreen = StyleHelper.mkStyle "backgroundColor" "#556B2F"
        static member inline mediumAquamarine = StyleHelper.mkStyle "backgroundColor" "#66CDAA"
        static member inline darkSeaGreen = StyleHelper.mkStyle "backgroundColor" "#8FBC8B"
        static member inline lightSeaGreen = StyleHelper.mkStyle "backgroundColor" "#20B2AA"
        static member inline darkCyan = StyleHelper.mkStyle "backgroundColor" "#008B8B"
        static member inline teal = StyleHelper.mkStyle "backgroundColor" "#008080"
        static member inline aqua = StyleHelper.mkStyle "backgroundColor" "#00FFFF"
        static member inline cyan = StyleHelper.mkStyle "backgroundColor" "#00FFFF"
        static member inline lightCyan = StyleHelper.mkStyle "backgroundColor" "#E0FFFF"
        static member inline paleTurqouise = StyleHelper.mkStyle "backgroundColor" "#AFEEEE"
        static member inline aquaMarine = StyleHelper.mkStyle "backgroundColor" "#7FFFD4"
        static member inline turqouise = StyleHelper.mkStyle "backgroundColor" "#AFEEEE"
        static member inline mediumTurqouise = StyleHelper.mkStyle "backgroundColor" "#48D1CC"
        static member inline darkTurqouise = StyleHelper.mkStyle "backgroundColor" "#00CED1"
        static member inline cadetBlue = StyleHelper.mkStyle "backgroundColor" "#5F9EA0"
        static member inline steelBlue = StyleHelper.mkStyle "backgroundColor" "#4682B4"
        static member inline lightSteelBlue = StyleHelper.mkStyle "backgroundColor" "#B0C4DE"
        static member inline powederBlue = StyleHelper.mkStyle "backgroundColor" "#B0E0E6"
        static member inline lightBlue = StyleHelper.mkStyle "backgroundColor" "#ADD8E6"
        static member inline skyBlue = StyleHelper.mkStyle "backgroundColor" "#87CEEB"
        static member inline lightSkyBlue = StyleHelper.mkStyle "backgroundColor" "#87CEFA"
        static member inline deepSkyBlue = StyleHelper.mkStyle "backgroundColor" "#00BFFF"
        static member inline dodgerBlue = StyleHelper.mkStyle "backgroundColor" "#1E90FF"
        static member inline cornFlowerBlue = StyleHelper.mkStyle "backgroundColor" "#6495ED"
        static member inline royalBlue = StyleHelper.mkStyle "backgroundColor" "#4169E1"
        static member inline blue = StyleHelper.mkStyle "backgroundColor" "#0000FF"
        static member inline mediumBlue = StyleHelper.mkStyle "backgroundColor" "#0000CD"
        static member inline darkBlue = StyleHelper.mkStyle "backgroundColor" "#00008B"
        static member inline navy = StyleHelper.mkStyle "backgroundColor" "#000080"
        static member inline midnightBlue = StyleHelper.mkStyle "backgroundColor" "#191970"
        static member inline cornSilk = StyleHelper.mkStyle "backgroundColor" "#FFF8DC"
        static member inline blanchedAlmond = StyleHelper.mkStyle "backgroundColor" "#FFEBCD"
        static member inline bisque = StyleHelper.mkStyle "backgroundColor" "#FFE4C4"
        static member inline navajoWhite = StyleHelper.mkStyle "backgroundColor" "#FFDEAD"
        static member inline wheat = StyleHelper.mkStyle "backgroundColor" "#F5DEB3"
        static member inline burlyWood = StyleHelper.mkStyle "backgroundColor" "#DEB887"
        static member inline tan = StyleHelper.mkStyle "backgroundColor" "#D2B48C"
        static member inline rosyBrown = StyleHelper.mkStyle "backgroundColor" "#BC8F8F"
        static member inline sandyBrown = StyleHelper.mkStyle "backgroundColor" "#F4A460"
        static member inline goldenRod = StyleHelper.mkStyle "backgroundColor" "#DAA520"
        static member inline darkGoldenRod = StyleHelper.mkStyle "backgroundColor" "#B8860B"
        static member inline peru = StyleHelper.mkStyle "backgroundColor" "#CD853F"
        static member inline chocolate = StyleHelper.mkStyle "backgroundColor" "#D2691E"
        static member inline saddleBrown = StyleHelper.mkStyle "backgroundColor" "#8B4513"
        static member inline sienna = StyleHelper.mkStyle "backgroundColor" "#A0522D"
        static member inline brown = StyleHelper.mkStyle "backgroundColor" "#A52A2A"
        static member inline maroon = StyleHelper.mkStyle "backgroundColor" "#A52A2A"
        static member inline white = StyleHelper.mkStyle "backgroundColor" "#FFFFFF"
        static member inline snow = StyleHelper.mkStyle "backgroundColor" "#FFFAFA"
        static member inline honeyDew = StyleHelper.mkStyle "backgroundColor" "#F0FFF0"
        static member inline mintCream = StyleHelper.mkStyle "backgroundColor" "#F5FFFA"
        static member inline azure = StyleHelper.mkStyle "backgroundColor" "#F0FFFF"
        static member inline aliceBlue = StyleHelper.mkStyle "backgroundColor" "#F0F8FF"
        static member inline ghostWhite = StyleHelper.mkStyle "backgroundColor" "#F8F8FF"
        static member inline whiteSmoke = StyleHelper.mkStyle "backgroundColor" "#F5F5F5"
        static member inline seaShell = StyleHelper.mkStyle "backgroundColor" "#FFF5EE"
        static member inline beige = StyleHelper.mkStyle "backgroundColor" "#F5F5DC"
        static member inline oldLace = StyleHelper.mkStyle "backgroundColor" "#FDF5E6"
        static member inline floralWhite = StyleHelper.mkStyle "backgroundColor" "#FFFAF0"
        static member inline ivory = StyleHelper.mkStyle "backgroundColor" "#FFFFF0"
        static member inline antiqueWhite = StyleHelper.mkStyle "backgroundColor" "#FAEBD7"
        static member inline linen = StyleHelper.mkStyle "backgroundColor" "#FAF0E6"
        static member inline lavenderBlush = StyleHelper.mkStyle "backgroundColor" "#FFF0F5"
        static member inline mistyRose = StyleHelper.mkStyle "backgroundColor" "#FFE4E1"
        static member inline gainsBoro = StyleHelper.mkStyle "backgroundColor" "#DCDCDC"
        static member inline lightGray = StyleHelper.mkStyle "backgroundColor" "#D3D3D3"
        static member inline silver = StyleHelper.mkStyle "backgroundColor" "#C0C0C0"
        static member inline darkGray = StyleHelper.mkStyle "backgroundColor" "#A9A9A9"
        static member inline gray = StyleHelper.mkStyle "backgroundColor" "#808080"
        static member inline dimGray = StyleHelper.mkStyle "backgroundColor" "#696969"
        static member inline lightSlateGray = StyleHelper.mkStyle "backgroundColor" "#778899"
        static member inline slateGray = StyleHelper.mkStyle "backgroundColor" "#708090"
        static member inline darkSlateGray = StyleHelper.mkStyle "backgroundColor" "#2F4F4F"
        static member inline black = StyleHelper.mkStyle "backgroundColor" "#000000"
        static member inline transparent = StyleHelper.mkStyle "backgroundColor" "transparent"

    /// Sets the color of an element's border.
    [<Erase; RequireQualifiedAccess>]
    type borderColor =
        static member inline indianRed = StyleHelper.mkStyle "borderColor" "#CD5C5C"
        static member inline lightCoral = StyleHelper.mkStyle "borderColor" "#F08080"
        static member inline salmon = StyleHelper.mkStyle "borderColor" "#FA8072"
        static member inline darkSalmon = StyleHelper.mkStyle "borderColor" "#E9967A"
        static member inline lightSalmon = StyleHelper.mkStyle "borderColor" "#FFA07A"
        static member inline crimson = StyleHelper.mkStyle "borderColor" "#DC143C"
        static member inline red = StyleHelper.mkStyle "borderColor" "#FF0000"
        static member inline fireBrick = StyleHelper.mkStyle "borderColor" "#B22222"
        static member inline darkred = StyleHelper.mkStyle "borderColor" "#8B0000"
        static member inline pink = StyleHelper.mkStyle "borderColor" "#FFC0CB"
        static member inline lightPink = StyleHelper.mkStyle "borderColor" "#FFB6C1"
        static member inline hotPink = StyleHelper.mkStyle "borderColor" "#FF69B4"
        static member inline deepPink = StyleHelper.mkStyle "borderColor" "#FF1493"
        static member inline mediumVioletRed = StyleHelper.mkStyle "borderColor" "#C71585"
        static member inline paleVioletRed = StyleHelper.mkStyle "borderColor" "#DB7093"
        static member inline coral = StyleHelper.mkStyle "borderColor" "#FF7F50"
        static member inline tomato = StyleHelper.mkStyle "borderColor" "#FF6347"
        static member inline orangeRed = StyleHelper.mkStyle "borderColor" "#FF4500"
        static member inline darkOrange = StyleHelper.mkStyle "borderColor" "#FF8C00"
        static member inline orange = StyleHelper.mkStyle "borderColor" "#FFA500"
        static member inline gold = StyleHelper.mkStyle "borderColor" "#FFD700"
        static member inline yellow = StyleHelper.mkStyle "borderColor" "#FFFF00"
        static member inline lightYellow = StyleHelper.mkStyle "borderColor" "#FFFFE0"
        static member inline limonChiffon = StyleHelper.mkStyle "borderColor" "#FFFACD"
        static member inline lightGoldenRodYellow = StyleHelper.mkStyle "borderColor" "#FAFAD2"
        static member inline papayaWhip = StyleHelper.mkStyle "borderColor" "#FFEFD5"
        static member inline moccasin = StyleHelper.mkStyle "borderColor" "#FFE4B5"
        static member inline peachPuff = StyleHelper.mkStyle "borderColor" "#FFDAB9"
        static member inline paleGoldenRod = StyleHelper.mkStyle "borderColor" "#EEE8AA"
        static member inline khaki = StyleHelper.mkStyle "borderColor" "#F0E68C"
        static member inline darkKhaki = StyleHelper.mkStyle "borderColor" "#BDB76B"
        static member inline lavender = StyleHelper.mkStyle "borderColor" "#E6E6FA"
        static member inline thistle = StyleHelper.mkStyle "borderColor" "#D8BFD8"
        static member inline plum = StyleHelper.mkStyle "borderColor" "#DDA0DD"
        static member inline violet = StyleHelper.mkStyle "borderColor" "#EE82EE"
        static member inline orchid = StyleHelper.mkStyle "borderColor" "#DA70D6"
        static member inline fuchsia = StyleHelper.mkStyle "borderColor" "#FF00FF"
        static member inline magenta = StyleHelper.mkStyle "borderColor" "#FF00FF"
        static member inline mediumOrchid = StyleHelper.mkStyle "borderColor" "#BA55D3"
        static member inline mediumPurple = StyleHelper.mkStyle "borderColor" "#9370DB"
        static member inline rebeccaPurple = StyleHelper.mkStyle "borderColor" "#663399"
        static member inline blueViolet = StyleHelper.mkStyle "borderColor" "#8A2BE2"
        static member inline darkViolet = StyleHelper.mkStyle "borderColor" "#9400D3"
        static member inline darkOrchid = StyleHelper.mkStyle "borderColor" "#9932CC"
        static member inline darkMagenta = StyleHelper.mkStyle "borderColor" "#8B008B"
        static member inline purple = StyleHelper.mkStyle "borderColor" "#800080"
        static member inline indigo = StyleHelper.mkStyle "borderColor" "#4B0082"
        static member inline slateBlue = StyleHelper.mkStyle "borderColor" "#6A5ACD"
        static member inline darkSlateBlue = StyleHelper.mkStyle "borderColor" "#483D8B"
        static member inline mediumSlateBlue = StyleHelper.mkStyle "borderColor" "#7B68EE"
        static member inline greenYellow = StyleHelper.mkStyle "borderColor" "#ADFF2F"
        static member inline chartreuse = StyleHelper.mkStyle "borderColor" "#7FFF00"
        static member inline lawnGreen = StyleHelper.mkStyle "borderColor" "#7CFC00"
        static member inline lime = StyleHelper.mkStyle "borderColor" "#00FF00"
        static member inline limeGreen = StyleHelper.mkStyle "borderColor" "#32CD32"
        static member inline paleGreen = StyleHelper.mkStyle "borderColor" "#98FB98"
        static member inline lightGreen = StyleHelper.mkStyle "borderColor" "#90EE90"
        static member inline mediumSpringGreen = StyleHelper.mkStyle "borderColor" "#00FA9A"
        static member inline springGreen = StyleHelper.mkStyle "borderColor" "#00FF7F"
        static member inline mediumSeaGreen = StyleHelper.mkStyle "borderColor" "#3CB371"
        static member inline seaGreen = StyleHelper.mkStyle "borderColor" "#2E8B57"
        static member inline forestGreen = StyleHelper.mkStyle "borderColor" "#228B22"
        static member inline green = StyleHelper.mkStyle "borderColor" "#008000"
        static member inline darkGreen = StyleHelper.mkStyle "borderColor" "#006400"
        static member inline yellowGreen = StyleHelper.mkStyle "borderColor" "#9ACD32"
        static member inline oliveDrab = StyleHelper.mkStyle "borderColor" "#6B8E23"
        static member inline olive = StyleHelper.mkStyle "borderColor" "#808000"
        static member inline darkOliveGreen = StyleHelper.mkStyle "borderColor" "#556B2F"
        static member inline mediumAquamarine = StyleHelper.mkStyle "borderColor" "#66CDAA"
        static member inline darkSeaGreen = StyleHelper.mkStyle "borderColor" "#8FBC8B"
        static member inline lightSeaGreen = StyleHelper.mkStyle "borderColor" "#20B2AA"
        static member inline darkCyan = StyleHelper.mkStyle "borderColor" "#008B8B"
        static member inline teal = StyleHelper.mkStyle "borderColor" "#008080"
        static member inline aqua = StyleHelper.mkStyle "borderColor" "#00FFFF"
        static member inline cyan = StyleHelper.mkStyle "borderColor" "#00FFFF"
        static member inline lightCyan = StyleHelper.mkStyle "borderColor" "#E0FFFF"
        static member inline paleTurqouise = StyleHelper.mkStyle "borderColor" "#AFEEEE"
        static member inline aquaMarine = StyleHelper.mkStyle "borderColor" "#7FFFD4"
        static member inline turqouise = StyleHelper.mkStyle "borderColor" "#AFEEEE"
        static member inline mediumTurqouise = StyleHelper.mkStyle "borderColor" "#48D1CC"
        static member inline darkTurqouise = StyleHelper.mkStyle "borderColor" "#00CED1"
        static member inline cadetBlue = StyleHelper.mkStyle "borderColor" "#5F9EA0"
        static member inline steelBlue = StyleHelper.mkStyle "borderColor" "#4682B4"
        static member inline lightSteelBlue = StyleHelper.mkStyle "borderColor" "#B0C4DE"
        static member inline powederBlue = StyleHelper.mkStyle "borderColor" "#B0E0E6"
        static member inline lightBlue = StyleHelper.mkStyle "borderColor" "#ADD8E6"
        static member inline skyBlue = StyleHelper.mkStyle "borderColor" "#87CEEB"
        static member inline lightSkyBlue = StyleHelper.mkStyle "borderColor" "#87CEFA"
        static member inline deepSkyBlue = StyleHelper.mkStyle "borderColor" "#00BFFF"
        static member inline dodgerBlue = StyleHelper.mkStyle "borderColor" "#1E90FF"
        static member inline cornFlowerBlue = StyleHelper.mkStyle "borderColor" "#6495ED"
        static member inline royalBlue = StyleHelper.mkStyle "borderColor" "#4169E1"
        static member inline blue = StyleHelper.mkStyle "borderColor" "#0000FF"
        static member inline mediumBlue = StyleHelper.mkStyle "borderColor" "#0000CD"
        static member inline darkBlue = StyleHelper.mkStyle "borderColor" "#00008B"
        static member inline navy = StyleHelper.mkStyle "borderColor" "#000080"
        static member inline midnightBlue = StyleHelper.mkStyle "borderColor" "#191970"
        static member inline cornSilk = StyleHelper.mkStyle "borderColor" "#FFF8DC"
        static member inline blanchedAlmond = StyleHelper.mkStyle "borderColor" "#FFEBCD"
        static member inline bisque = StyleHelper.mkStyle "borderColor" "#FFE4C4"
        static member inline navajoWhite = StyleHelper.mkStyle "borderColor" "#FFDEAD"
        static member inline wheat = StyleHelper.mkStyle "borderColor" "#F5DEB3"
        static member inline burlyWood = StyleHelper.mkStyle "borderColor" "#DEB887"
        static member inline tan = StyleHelper.mkStyle "borderColor" "#D2B48C"
        static member inline rosyBrown = StyleHelper.mkStyle "borderColor" "#BC8F8F"
        static member inline sandyBrown = StyleHelper.mkStyle "borderColor" "#F4A460"
        static member inline goldenRod = StyleHelper.mkStyle "borderColor" "#DAA520"
        static member inline darkGoldenRod = StyleHelper.mkStyle "borderColor" "#B8860B"
        static member inline peru = StyleHelper.mkStyle "borderColor" "#CD853F"
        static member inline chocolate = StyleHelper.mkStyle "borderColor" "#D2691E"
        static member inline saddleBrown = StyleHelper.mkStyle "borderColor" "#8B4513"
        static member inline sienna = StyleHelper.mkStyle "borderColor" "#A0522D"
        static member inline brown = StyleHelper.mkStyle "borderColor" "#A52A2A"
        static member inline maroon = StyleHelper.mkStyle "borderColor" "#A52A2A"
        static member inline white = StyleHelper.mkStyle "borderColor" "#FFFFFF"
        static member inline snow = StyleHelper.mkStyle "borderColor" "#FFFAFA"
        static member inline honeyDew = StyleHelper.mkStyle "borderColor" "#F0FFF0"
        static member inline mintCream = StyleHelper.mkStyle "borderColor" "#F5FFFA"
        static member inline azure = StyleHelper.mkStyle "borderColor" "#F0FFFF"
        static member inline aliceBlue = StyleHelper.mkStyle "borderColor" "#F0F8FF"
        static member inline ghostWhite = StyleHelper.mkStyle "borderColor" "#F8F8FF"
        static member inline whiteSmoke = StyleHelper.mkStyle "borderColor" "#F5F5F5"
        static member inline seaShell = StyleHelper.mkStyle "borderColor" "#FFF5EE"
        static member inline beige = StyleHelper.mkStyle "borderColor" "#F5F5DC"
        static member inline oldLace = StyleHelper.mkStyle "borderColor" "#FDF5E6"
        static member inline floralWhite = StyleHelper.mkStyle "borderColor" "#FFFAF0"
        static member inline ivory = StyleHelper.mkStyle "borderColor" "#FFFFF0"
        static member inline antiqueWhite = StyleHelper.mkStyle "borderColor" "#FAEBD7"
        static member inline linen = StyleHelper.mkStyle "borderColor" "#FAF0E6"
        static member inline lavenderBlush = StyleHelper.mkStyle "borderColor" "#FFF0F5"
        static member inline mistyRose = StyleHelper.mkStyle "borderColor" "#FFE4E1"
        static member inline gainsBoro = StyleHelper.mkStyle "borderColor" "#DCDCDC"
        static member inline lightGray = StyleHelper.mkStyle "borderColor" "#D3D3D3"
        static member inline silver = StyleHelper.mkStyle "borderColor" "#C0C0C0"
        static member inline darkGray = StyleHelper.mkStyle "borderColor" "#A9A9A9"
        static member inline gray = StyleHelper.mkStyle "borderColor" "#808080"
        static member inline dimGray = StyleHelper.mkStyle "borderColor" "#696969"
        static member inline lightSlateGray = StyleHelper.mkStyle "borderColor" "#778899"
        static member inline slateGray = StyleHelper.mkStyle "borderColor" "#708090"
        static member inline darkSlateGray = StyleHelper.mkStyle "borderColor" "#2F4F4F"
        static member inline black = StyleHelper.mkStyle "borderColor" "#000000"
        static member inline transparent = StyleHelper.mkStyle "borderColor" "transparent"

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
        static member inline auto = StyleHelper.mkStyle "caretColor" "auto"
        static member inline indianRed = StyleHelper.mkStyle "caretColor" "#CD5C5C"
        static member inline lightCoral = StyleHelper.mkStyle "caretColor" "#F08080"
        static member inline salmon = StyleHelper.mkStyle "caretColor" "#FA8072"
        static member inline darkSalmon = StyleHelper.mkStyle "caretColor" "#E9967A"
        static member inline lightSalmon = StyleHelper.mkStyle "caretColor" "#FFA07A"
        static member inline crimson = StyleHelper.mkStyle "caretColor" "#DC143C"
        static member inline red = StyleHelper.mkStyle "caretColor" "#FF0000"
        static member inline fireBrick = StyleHelper.mkStyle "caretColor" "#B22222"
        static member inline darkred = StyleHelper.mkStyle "caretColor" "#8B0000"
        static member inline pink = StyleHelper.mkStyle "caretColor" "#FFC0CB"
        static member inline lightPink = StyleHelper.mkStyle "caretColor" "#FFB6C1"
        static member inline hotPink = StyleHelper.mkStyle "caretColor" "#FF69B4"
        static member inline deepPink = StyleHelper.mkStyle "caretColor" "#FF1493"
        static member inline mediumVioletRed = StyleHelper.mkStyle "caretColor" "#C71585"
        static member inline paleVioletRed = StyleHelper.mkStyle "caretColor" "#DB7093"
        static member inline coral = StyleHelper.mkStyle "caretColor" "#FF7F50"
        static member inline tomato = StyleHelper.mkStyle "caretColor" "#FF6347"
        static member inline orangeRed = StyleHelper.mkStyle "caretColor" "#FF4500"
        static member inline darkOrange = StyleHelper.mkStyle "caretColor" "#FF8C00"
        static member inline orange = StyleHelper.mkStyle "caretColor" "#FFA500"
        static member inline gold = StyleHelper.mkStyle "caretColor" "#FFD700"
        static member inline yellow = StyleHelper.mkStyle "caretColor" "#FFFF00"
        static member inline lightYellow = StyleHelper.mkStyle "caretColor" "#FFFFE0"
        static member inline limonChiffon = StyleHelper.mkStyle "caretColor" "#FFFACD"
        static member inline lightGoldenRodYellow = StyleHelper.mkStyle "caretColor" "#FAFAD2"
        static member inline papayaWhip = StyleHelper.mkStyle "caretColor" "#FFEFD5"
        static member inline moccasin = StyleHelper.mkStyle "caretColor" "#FFE4B5"
        static member inline peachPuff = StyleHelper.mkStyle "caretColor" "#FFDAB9"
        static member inline paleGoldenRod = StyleHelper.mkStyle "caretColor" "#EEE8AA"
        static member inline khaki = StyleHelper.mkStyle "caretColor" "#F0E68C"
        static member inline darkKhaki = StyleHelper.mkStyle "caretColor" "#BDB76B"
        static member inline lavender = StyleHelper.mkStyle "caretColor" "#E6E6FA"
        static member inline thistle = StyleHelper.mkStyle "caretColor" "#D8BFD8"
        static member inline plum = StyleHelper.mkStyle "caretColor" "#DDA0DD"
        static member inline violet = StyleHelper.mkStyle "caretColor" "#EE82EE"
        static member inline orchid = StyleHelper.mkStyle "caretColor" "#DA70D6"
        static member inline fuchsia = StyleHelper.mkStyle "caretColor" "#FF00FF"
        static member inline magenta = StyleHelper.mkStyle "caretColor" "#FF00FF"
        static member inline mediumOrchid = StyleHelper.mkStyle "caretColor" "#BA55D3"
        static member inline mediumPurple = StyleHelper.mkStyle "caretColor" "#9370DB"
        static member inline rebeccaPurple = StyleHelper.mkStyle "caretColor" "#663399"
        static member inline blueViolet = StyleHelper.mkStyle "caretColor" "#8A2BE2"
        static member inline darkViolet = StyleHelper.mkStyle "caretColor" "#9400D3"
        static member inline darkOrchid = StyleHelper.mkStyle "caretColor" "#9932CC"
        static member inline darkMagenta = StyleHelper.mkStyle "caretColor" "#8B008B"
        static member inline purple = StyleHelper.mkStyle "caretColor" "#800080"
        static member inline indigo = StyleHelper.mkStyle "caretColor" "#4B0082"
        static member inline slateBlue = StyleHelper.mkStyle "caretColor" "#6A5ACD"
        static member inline darkSlateBlue = StyleHelper.mkStyle "caretColor" "#483D8B"
        static member inline mediumSlateBlue = StyleHelper.mkStyle "caretColor" "#7B68EE"
        static member inline greenYellow = StyleHelper.mkStyle "caretColor" "#ADFF2F"
        static member inline chartreuse = StyleHelper.mkStyle "caretColor" "#7FFF00"
        static member inline lawnGreen = StyleHelper.mkStyle "caretColor" "#7CFC00"
        static member inline lime = StyleHelper.mkStyle "caretColor" "#00FF00"
        static member inline limeGreen = StyleHelper.mkStyle "caretColor" "#32CD32"
        static member inline paleGreen = StyleHelper.mkStyle "caretColor" "#98FB98"
        static member inline lightGreen = StyleHelper.mkStyle "caretColor" "#90EE90"
        static member inline mediumSpringGreen = StyleHelper.mkStyle "caretColor" "#00FA9A"
        static member inline springGreen = StyleHelper.mkStyle "caretColor" "#00FF7F"
        static member inline mediumSeaGreen = StyleHelper.mkStyle "caretColor" "#3CB371"
        static member inline seaGreen = StyleHelper.mkStyle "caretColor" "#2E8B57"
        static member inline forestGreen = StyleHelper.mkStyle "caretColor" "#228B22"
        static member inline green = StyleHelper.mkStyle "caretColor" "#008000"
        static member inline darkGreen = StyleHelper.mkStyle "caretColor" "#006400"
        static member inline yellowGreen = StyleHelper.mkStyle "caretColor" "#9ACD32"
        static member inline oliveDrab = StyleHelper.mkStyle "caretColor" "#6B8E23"
        static member inline olive = StyleHelper.mkStyle "caretColor" "#808000"
        static member inline darkOliveGreen = StyleHelper.mkStyle "caretColor" "#556B2F"
        static member inline mediumAquamarine = StyleHelper.mkStyle "caretColor" "#66CDAA"
        static member inline darkSeaGreen = StyleHelper.mkStyle "caretColor" "#8FBC8B"
        static member inline lightSeaGreen = StyleHelper.mkStyle "caretColor" "#20B2AA"
        static member inline darkCyan = StyleHelper.mkStyle "caretColor" "#008B8B"
        static member inline teal = StyleHelper.mkStyle "caretColor" "#008080"
        static member inline aqua = StyleHelper.mkStyle "caretColor" "#00FFFF"
        static member inline cyan = StyleHelper.mkStyle "caretColor" "#00FFFF"
        static member inline lightCyan = StyleHelper.mkStyle "caretColor" "#E0FFFF"
        static member inline paleTurqouise = StyleHelper.mkStyle "caretColor" "#AFEEEE"
        static member inline aquaMarine = StyleHelper.mkStyle "caretColor" "#7FFFD4"
        static member inline turqouise = StyleHelper.mkStyle "caretColor" "#AFEEEE"
        static member inline mediumTurqouise = StyleHelper.mkStyle "caretColor" "#48D1CC"
        static member inline darkTurqouise = StyleHelper.mkStyle "caretColor" "#00CED1"
        static member inline cadetBlue = StyleHelper.mkStyle "caretColor" "#5F9EA0"
        static member inline steelBlue = StyleHelper.mkStyle "caretColor" "#4682B4"
        static member inline lightSteelBlue = StyleHelper.mkStyle "caretColor" "#B0C4DE"
        static member inline powederBlue = StyleHelper.mkStyle "caretColor" "#B0E0E6"
        static member inline lightBlue = StyleHelper.mkStyle "caretColor" "#ADD8E6"
        static member inline skyBlue = StyleHelper.mkStyle "caretColor" "#87CEEB"
        static member inline lightSkyBlue = StyleHelper.mkStyle "caretColor" "#87CEFA"
        static member inline deepSkyBlue = StyleHelper.mkStyle "caretColor" "#00BFFF"
        static member inline dodgerBlue = StyleHelper.mkStyle "caretColor" "#1E90FF"
        static member inline cornFlowerBlue = StyleHelper.mkStyle "caretColor" "#6495ED"
        static member inline royalBlue = StyleHelper.mkStyle "caretColor" "#4169E1"
        static member inline blue = StyleHelper.mkStyle "caretColor" "#0000FF"
        static member inline mediumBlue = StyleHelper.mkStyle "caretColor" "#0000CD"
        static member inline darkBlue = StyleHelper.mkStyle "caretColor" "#00008B"
        static member inline navy = StyleHelper.mkStyle "caretColor" "#000080"
        static member inline midnightBlue = StyleHelper.mkStyle "caretColor" "#191970"
        static member inline cornSilk = StyleHelper.mkStyle "caretColor" "#FFF8DC"
        static member inline blanchedAlmond = StyleHelper.mkStyle "caretColor" "#FFEBCD"
        static member inline bisque = StyleHelper.mkStyle "caretColor" "#FFE4C4"
        static member inline navajoWhite = StyleHelper.mkStyle "caretColor" "#FFDEAD"
        static member inline wheat = StyleHelper.mkStyle "caretColor" "#F5DEB3"
        static member inline burlyWood = StyleHelper.mkStyle "caretColor" "#DEB887"
        static member inline tan = StyleHelper.mkStyle "caretColor" "#D2B48C"
        static member inline rosyBrown = StyleHelper.mkStyle "caretColor" "#BC8F8F"
        static member inline sandyBrown = StyleHelper.mkStyle "caretColor" "#F4A460"
        static member inline goldenRod = StyleHelper.mkStyle "caretColor" "#DAA520"
        static member inline darkGoldenRod = StyleHelper.mkStyle "caretColor" "#B8860B"
        static member inline peru = StyleHelper.mkStyle "caretColor" "#CD853F"
        static member inline chocolate = StyleHelper.mkStyle "caretColor" "#D2691E"
        static member inline saddleBrown = StyleHelper.mkStyle "caretColor" "#8B4513"
        static member inline sienna = StyleHelper.mkStyle "caretColor" "#A0522D"
        static member inline brown = StyleHelper.mkStyle "caretColor" "#A52A2A"
        static member inline maroon = StyleHelper.mkStyle "caretColor" "#A52A2A"
        static member inline white = StyleHelper.mkStyle "caretColor" "#FFFFFF"
        static member inline snow = StyleHelper.mkStyle "caretColor" "#FFFAFA"
        static member inline honeyDew = StyleHelper.mkStyle "caretColor" "#F0FFF0"
        static member inline mintCream = StyleHelper.mkStyle "caretColor" "#F5FFFA"
        static member inline azure = StyleHelper.mkStyle "caretColor" "#F0FFFF"
        static member inline aliceBlue = StyleHelper.mkStyle "caretColor" "#F0F8FF"
        static member inline ghostWhite = StyleHelper.mkStyle "caretColor" "#F8F8FF"
        static member inline whiteSmoke = StyleHelper.mkStyle "caretColor" "#F5F5F5"
        static member inline seaShell = StyleHelper.mkStyle "caretColor" "#FFF5EE"
        static member inline beige = StyleHelper.mkStyle "caretColor" "#F5F5DC"
        static member inline oldLace = StyleHelper.mkStyle "caretColor" "#FDF5E6"
        static member inline floralWhite = StyleHelper.mkStyle "caretColor" "#FFFAF0"
        static member inline ivory = StyleHelper.mkStyle "caretColor" "#FFFFF0"
        static member inline antiqueWhite = StyleHelper.mkStyle "caretColor" "#FAEBD7"
        static member inline linen = StyleHelper.mkStyle "caretColor" "#FAF0E6"
        static member inline lavenderBlush = StyleHelper.mkStyle "caretColor" "#FFF0F5"
        static member inline mistyRose = StyleHelper.mkStyle "caretColor" "#FFE4E1"
        static member inline gainsBoro = StyleHelper.mkStyle "caretColor" "#DCDCDC"
        static member inline lightGray = StyleHelper.mkStyle "caretColor" "#D3D3D3"
        static member inline silver = StyleHelper.mkStyle "caretColor" "#C0C0C0"
        static member inline darkGray = StyleHelper.mkStyle "caretColor" "#A9A9A9"
        static member inline gray = StyleHelper.mkStyle "caretColor" "#808080"
        static member inline dimGray = StyleHelper.mkStyle "caretColor" "#696969"
        static member inline lightSlateGray = StyleHelper.mkStyle "caretColor" "#778899"
        static member inline slateGray = StyleHelper.mkStyle "caretColor" "#708090"
        static member inline darkSlateGray = StyleHelper.mkStyle "caretColor" "#2F4F4F"
        static member inline black = StyleHelper.mkStyle "caretColor" "#000000"
        static member inline transparent = StyleHelper.mkStyle "caretColor" "transparent"

    /// Sets the foreground color value of an element's text and text decorations, and sets the
    /// `currentcolor` value. `currentcolor` may be used as an indirect value on other properties
    /// and is the default for other color properties, such as border-color.
    [<Erase; RequireQualifiedAccess>]
    type color =
        static member inline indianRed = StyleHelper.mkStyle "color" "#CD5C5C"
        static member inline lightCoral = StyleHelper.mkStyle "color" "#F08080"
        static member inline salmon = StyleHelper.mkStyle "color" "#FA8072"
        static member inline darkSalmon = StyleHelper.mkStyle "color" "#E9967A"
        static member inline lightSalmon = StyleHelper.mkStyle "color" "#FFA07A"
        static member inline crimson = StyleHelper.mkStyle "color" "#DC143C"
        static member inline red = StyleHelper.mkStyle "color" "#FF0000"
        static member inline fireBrick = StyleHelper.mkStyle "color" "#B22222"
        static member inline darkred = StyleHelper.mkStyle "color" "#8B0000"
        static member inline pink = StyleHelper.mkStyle "color" "#FFC0CB"
        static member inline lightPink = StyleHelper.mkStyle "color" "#FFB6C1"
        static member inline hotPink = StyleHelper.mkStyle "color" "#FF69B4"
        static member inline deepPink = StyleHelper.mkStyle "color" "#FF1493"
        static member inline mediumVioletRed = StyleHelper.mkStyle "color" "#C71585"
        static member inline paleVioletRed = StyleHelper.mkStyle "color" "#DB7093"
        static member inline coral = StyleHelper.mkStyle "color" "#FF7F50"
        static member inline tomato = StyleHelper.mkStyle "color" "#FF6347"
        static member inline orangeRed = StyleHelper.mkStyle "color" "#FF4500"
        static member inline darkOrange = StyleHelper.mkStyle "color" "#FF8C00"
        static member inline orange = StyleHelper.mkStyle "color" "#FFA500"
        static member inline gold = StyleHelper.mkStyle "color" "#FFD700"
        static member inline yellow = StyleHelper.mkStyle "color" "#FFFF00"
        static member inline lightYellow = StyleHelper.mkStyle "color" "#FFFFE0"
        static member inline limonChiffon = StyleHelper.mkStyle "color" "#FFFACD"
        static member inline lightGoldenRodYellow = StyleHelper.mkStyle "color" "#FAFAD2"
        static member inline papayaWhip = StyleHelper.mkStyle "color" "#FFEFD5"
        static member inline moccasin = StyleHelper.mkStyle "color" "#FFE4B5"
        static member inline peachPuff = StyleHelper.mkStyle "color" "#FFDAB9"
        static member inline paleGoldenRod = StyleHelper.mkStyle "color" "#EEE8AA"
        static member inline khaki = StyleHelper.mkStyle "color" "#F0E68C"
        static member inline darkKhaki = StyleHelper.mkStyle "color" "#BDB76B"
        static member inline lavender = StyleHelper.mkStyle "color" "#E6E6FA"
        static member inline thistle = StyleHelper.mkStyle "color" "#D8BFD8"
        static member inline plum = StyleHelper.mkStyle "color" "#DDA0DD"
        static member inline violet = StyleHelper.mkStyle "color" "#EE82EE"
        static member inline orchid = StyleHelper.mkStyle "color" "#DA70D6"
        static member inline fuchsia = StyleHelper.mkStyle "color" "#FF00FF"
        static member inline magenta = StyleHelper.mkStyle "color" "#FF00FF"
        static member inline mediumOrchid = StyleHelper.mkStyle "color" "#BA55D3"
        static member inline mediumPurple = StyleHelper.mkStyle "color" "#9370DB"
        static member inline rebeccaPurple = StyleHelper.mkStyle "color" "#663399"
        static member inline blueViolet = StyleHelper.mkStyle "color" "#8A2BE2"
        static member inline darkViolet = StyleHelper.mkStyle "color" "#9400D3"
        static member inline darkOrchid = StyleHelper.mkStyle "color" "#9932CC"
        static member inline darkMagenta = StyleHelper.mkStyle "color" "#8B008B"
        static member inline purple = StyleHelper.mkStyle "color" "#800080"
        static member inline indigo = StyleHelper.mkStyle "color" "#4B0082"
        static member inline slateBlue = StyleHelper.mkStyle "color" "#6A5ACD"
        static member inline darkSlateBlue = StyleHelper.mkStyle "color" "#483D8B"
        static member inline mediumSlateBlue = StyleHelper.mkStyle "color" "#7B68EE"
        static member inline greenYellow = StyleHelper.mkStyle "color" "#ADFF2F"
        static member inline chartreuse = StyleHelper.mkStyle "color" "#7FFF00"
        static member inline lawnGreen = StyleHelper.mkStyle "color" "#7CFC00"
        static member inline lime = StyleHelper.mkStyle "color" "#00FF00"
        static member inline limeGreen = StyleHelper.mkStyle "color" "#32CD32"
        static member inline paleGreen = StyleHelper.mkStyle "color" "#98FB98"
        static member inline lightGreen = StyleHelper.mkStyle "color" "#90EE90"
        static member inline mediumSpringGreen = StyleHelper.mkStyle "color" "#00FA9A"
        static member inline springGreen = StyleHelper.mkStyle "color" "#00FF7F"
        static member inline mediumSeaGreen = StyleHelper.mkStyle "color" "#3CB371"
        static member inline seaGreen = StyleHelper.mkStyle "color" "#2E8B57"
        static member inline forestGreen = StyleHelper.mkStyle "color" "#228B22"
        static member inline green = StyleHelper.mkStyle "color" "#008000"
        static member inline darkGreen = StyleHelper.mkStyle "color" "#006400"
        static member inline yellowGreen = StyleHelper.mkStyle "color" "#9ACD32"
        static member inline oliveDrab = StyleHelper.mkStyle "color" "#6B8E23"
        static member inline olive = StyleHelper.mkStyle "color" "#808000"
        static member inline darkOliveGreen = StyleHelper.mkStyle "color" "#556B2F"
        static member inline mediumAquamarine = StyleHelper.mkStyle "color" "#66CDAA"
        static member inline darkSeaGreen = StyleHelper.mkStyle "color" "#8FBC8B"
        static member inline lightSeaGreen = StyleHelper.mkStyle "color" "#20B2AA"
        static member inline darkCyan = StyleHelper.mkStyle "color" "#008B8B"
        static member inline teal = StyleHelper.mkStyle "color" "#008080"
        static member inline aqua = StyleHelper.mkStyle "color" "#00FFFF"
        static member inline cyan = StyleHelper.mkStyle "color" "#00FFFF"
        static member inline lightCyan = StyleHelper.mkStyle "color" "#E0FFFF"
        static member inline paleTurqouise = StyleHelper.mkStyle "color" "#AFEEEE"
        static member inline aquaMarine = StyleHelper.mkStyle "color" "#7FFFD4"
        static member inline turqouise = StyleHelper.mkStyle "color" "#AFEEEE"
        static member inline mediumTurqouise = StyleHelper.mkStyle "color" "#48D1CC"
        static member inline darkTurqouise = StyleHelper.mkStyle "color" "#00CED1"
        static member inline cadetBlue = StyleHelper.mkStyle "color" "#5F9EA0"
        static member inline steelBlue = StyleHelper.mkStyle "color" "#4682B4"
        static member inline lightSteelBlue = StyleHelper.mkStyle "color" "#B0C4DE"
        static member inline powederBlue = StyleHelper.mkStyle "color" "#B0E0E6"
        static member inline lightBlue = StyleHelper.mkStyle "color" "#ADD8E6"
        static member inline skyBlue = StyleHelper.mkStyle "color" "#87CEEB"
        static member inline lightSkyBlue = StyleHelper.mkStyle "color" "#87CEFA"
        static member inline deepSkyBlue = StyleHelper.mkStyle "color" "#00BFFF"
        static member inline dodgerBlue = StyleHelper.mkStyle "color" "#1E90FF"
        static member inline cornFlowerBlue = StyleHelper.mkStyle "color" "#6495ED"
        static member inline royalBlue = StyleHelper.mkStyle "color" "#4169E1"
        static member inline blue = StyleHelper.mkStyle "color" "#0000FF"
        static member inline mediumBlue = StyleHelper.mkStyle "color" "#0000CD"
        static member inline darkBlue = StyleHelper.mkStyle "color" "#00008B"
        static member inline navy = StyleHelper.mkStyle "color" "#000080"
        static member inline midnightBlue = StyleHelper.mkStyle "color" "#191970"
        static member inline cornSilk = StyleHelper.mkStyle "color" "#FFF8DC"
        static member inline blanchedAlmond = StyleHelper.mkStyle "color" "#FFEBCD"
        static member inline bisque = StyleHelper.mkStyle "color" "#FFE4C4"
        static member inline navajoWhite = StyleHelper.mkStyle "color" "#FFDEAD"
        static member inline wheat = StyleHelper.mkStyle "color" "#F5DEB3"
        static member inline burlyWood = StyleHelper.mkStyle "color" "#DEB887"
        static member inline tan = StyleHelper.mkStyle "color" "#D2B48C"
        static member inline rosyBrown = StyleHelper.mkStyle "color" "#BC8F8F"
        static member inline sandyBrown = StyleHelper.mkStyle "color" "#F4A460"
        static member inline goldenRod = StyleHelper.mkStyle "color" "#DAA520"
        static member inline darkGoldenRod = StyleHelper.mkStyle "color" "#B8860B"
        static member inline peru = StyleHelper.mkStyle "color" "#CD853F"
        static member inline chocolate = StyleHelper.mkStyle "color" "#D2691E"
        static member inline saddleBrown = StyleHelper.mkStyle "color" "#8B4513"
        static member inline sienna = StyleHelper.mkStyle "color" "#A0522D"
        static member inline brown = StyleHelper.mkStyle "color" "#A52A2A"
        static member inline maroon = StyleHelper.mkStyle "color" "#A52A2A"
        static member inline white = StyleHelper.mkStyle "color" "#FFFFFF"
        static member inline snow = StyleHelper.mkStyle "color" "#FFFAFA"
        static member inline honeyDew = StyleHelper.mkStyle "color" "#F0FFF0"
        static member inline mintCream = StyleHelper.mkStyle "color" "#F5FFFA"
        static member inline azure = StyleHelper.mkStyle "color" "#F0FFFF"
        static member inline aliceBlue = StyleHelper.mkStyle "color" "#F0F8FF"
        static member inline ghostWhite = StyleHelper.mkStyle "color" "#F8F8FF"
        static member inline whiteSmoke = StyleHelper.mkStyle "color" "#F5F5F5"
        static member inline seaShell = StyleHelper.mkStyle "color" "#FFF5EE"
        static member inline beige = StyleHelper.mkStyle "color" "#F5F5DC"
        static member inline oldLace = StyleHelper.mkStyle "color" "#FDF5E6"
        static member inline floralWhite = StyleHelper.mkStyle "color" "#FFFAF0"
        static member inline ivory = StyleHelper.mkStyle "color" "#FFFFF0"
        static member inline antiqueWhite = StyleHelper.mkStyle "color" "#FAEBD7"
        static member inline linen = StyleHelper.mkStyle "color" "#FAF0E6"
        static member inline lavenderBlush = StyleHelper.mkStyle "color" "#FFF0F5"
        static member inline mistyRose = StyleHelper.mkStyle "color" "#FFE4E1"
        static member inline gainsBoro = StyleHelper.mkStyle "color" "#DCDCDC"
        static member inline lightGray = StyleHelper.mkStyle "color" "#D3D3D3"
        static member inline silver = StyleHelper.mkStyle "color" "#C0C0C0"
        static member inline darkGray = StyleHelper.mkStyle "color" "#A9A9A9"
        static member inline gray = StyleHelper.mkStyle "color" "#808080"
        static member inline dimGray = StyleHelper.mkStyle "color" "#696969"
        static member inline lightSlateGray = StyleHelper.mkStyle "color" "#778899"
        static member inline slateGray = StyleHelper.mkStyle "color" "#708090"
        static member inline darkSlateGray = StyleHelper.mkStyle "color" "#2F4F4F"
        static member inline black = StyleHelper.mkStyle "color" "#000000"
        static member inline transparent = StyleHelper.mkStyle "color" "transparent"
        /// Inherits this property from its parent element.
        static member inline inheritFromParent = StyleHelper.mkStyle "color" "inherit"
        /// Sets this property to its default value
        static member inline initial = StyleHelper.mkStyle "color" "initial"
        static member inline revert = StyleHelper.mkStyle "color" "revert"
        static member inline revertLayer = StyleHelper.mkStyle "color" "revert-layer"
        /// Resets to its inherited value if the property naturally inherits from its parent, and to its initial value if not.
        static member inline unset = StyleHelper.mkStyle "color" "unset"

    /// Sets the color of decorations added to text by text-decoration-line.
    [<Erase; RequireQualifiedAccess>]
    type textDecorationColor =
        static member inline indianRed = StyleHelper.mkStyle "textDecorationColor" "#CD5C5C"
        static member inline lightCoral = StyleHelper.mkStyle "textDecorationColor" "#F08080"
        static member inline salmon = StyleHelper.mkStyle "textDecorationColor" "#FA8072"
        static member inline darkSalmon = StyleHelper.mkStyle "textDecorationColor" "#E9967A"
        static member inline lightSalmon = StyleHelper.mkStyle "textDecorationColor" "#FFA07A"
        static member inline crimson = StyleHelper.mkStyle "textDecorationColor" "#DC143C"
        static member inline red = StyleHelper.mkStyle "textDecorationColor" "#FF0000"
        static member inline fireBrick = StyleHelper.mkStyle "textDecorationColor" "#B22222"
        static member inline darkred = StyleHelper.mkStyle "textDecorationColor" "#8B0000"
        static member inline pink = StyleHelper.mkStyle "textDecorationColor" "#FFC0CB"
        static member inline lightPink = StyleHelper.mkStyle "textDecorationColor" "#FFB6C1"
        static member inline hotPink = StyleHelper.mkStyle "textDecorationColor" "#FF69B4"
        static member inline deepPink = StyleHelper.mkStyle "textDecorationColor" "#FF1493"
        static member inline mediumVioletRed = StyleHelper.mkStyle "textDecorationColor" "#C71585"
        static member inline paleVioletRed = StyleHelper.mkStyle "textDecorationColor" "#DB7093"
        static member inline coral = StyleHelper.mkStyle "textDecorationColor" "#FF7F50"
        static member inline tomato = StyleHelper.mkStyle "textDecorationColor" "#FF6347"
        static member inline orangeRed = StyleHelper.mkStyle "textDecorationColor" "#FF4500"
        static member inline darkOrange = StyleHelper.mkStyle "textDecorationColor" "#FF8C00"
        static member inline orange = StyleHelper.mkStyle "textDecorationColor" "#FFA500"
        static member inline gold = StyleHelper.mkStyle "textDecorationColor" "#FFD700"
        static member inline yellow = StyleHelper.mkStyle "textDecorationColor" "#FFFF00"
        static member inline lightYellow = StyleHelper.mkStyle "textDecorationColor" "#FFFFE0"
        static member inline limonChiffon = StyleHelper.mkStyle "textDecorationColor" "#FFFACD"
        static member inline lightGoldenRodYellow = StyleHelper.mkStyle "textDecorationColor" "#FAFAD2"
        static member inline papayaWhip = StyleHelper.mkStyle "textDecorationColor" "#FFEFD5"
        static member inline moccasin = StyleHelper.mkStyle "textDecorationColor" "#FFE4B5"
        static member inline peachPuff = StyleHelper.mkStyle "textDecorationColor" "#FFDAB9"
        static member inline paleGoldenRod = StyleHelper.mkStyle "textDecorationColor" "#EEE8AA"
        static member inline khaki = StyleHelper.mkStyle "textDecorationColor" "#F0E68C"
        static member inline darkKhaki = StyleHelper.mkStyle "textDecorationColor" "#BDB76B"
        static member inline lavender = StyleHelper.mkStyle "textDecorationColor" "#E6E6FA"
        static member inline thistle = StyleHelper.mkStyle "textDecorationColor" "#D8BFD8"
        static member inline plum = StyleHelper.mkStyle "textDecorationColor" "#DDA0DD"
        static member inline violet = StyleHelper.mkStyle "textDecorationColor" "#EE82EE"
        static member inline orchid = StyleHelper.mkStyle "textDecorationColor" "#DA70D6"
        static member inline fuchsia = StyleHelper.mkStyle "textDecorationColor" "#FF00FF"
        static member inline magenta = StyleHelper.mkStyle "textDecorationColor" "#FF00FF"
        static member inline mediumOrchid = StyleHelper.mkStyle "textDecorationColor" "#BA55D3"
        static member inline mediumPurple = StyleHelper.mkStyle "textDecorationColor" "#9370DB"
        static member inline rebeccaPurple = StyleHelper.mkStyle "textDecorationColor" "#663399"
        static member inline blueViolet = StyleHelper.mkStyle "textDecorationColor" "#8A2BE2"
        static member inline darkViolet = StyleHelper.mkStyle "textDecorationColor" "#9400D3"
        static member inline darkOrchid = StyleHelper.mkStyle "textDecorationColor" "#9932CC"
        static member inline darkMagenta = StyleHelper.mkStyle "textDecorationColor" "#8B008B"
        static member inline purple = StyleHelper.mkStyle "textDecorationColor" "#800080"
        static member inline indigo = StyleHelper.mkStyle "textDecorationColor" "#4B0082"
        static member inline slateBlue = StyleHelper.mkStyle "textDecorationColor" "#6A5ACD"
        static member inline darkSlateBlue = StyleHelper.mkStyle "textDecorationColor" "#483D8B"
        static member inline mediumSlateBlue = StyleHelper.mkStyle "textDecorationColor" "#7B68EE"
        static member inline greenYellow = StyleHelper.mkStyle "textDecorationColor" "#ADFF2F"
        static member inline chartreuse = StyleHelper.mkStyle "textDecorationColor" "#7FFF00"
        static member inline lawnGreen = StyleHelper.mkStyle "textDecorationColor" "#7CFC00"
        static member inline lime = StyleHelper.mkStyle "textDecorationColor" "#00FF00"
        static member inline limeGreen = StyleHelper.mkStyle "textDecorationColor" "#32CD32"
        static member inline paleGreen = StyleHelper.mkStyle "textDecorationColor" "#98FB98"
        static member inline lightGreen = StyleHelper.mkStyle "textDecorationColor" "#90EE90"
        static member inline mediumSpringGreen = StyleHelper.mkStyle "textDecorationColor" "#00FA9A"
        static member inline springGreen = StyleHelper.mkStyle "textDecorationColor" "#00FF7F"
        static member inline mediumSeaGreen = StyleHelper.mkStyle "textDecorationColor" "#3CB371"
        static member inline seaGreen = StyleHelper.mkStyle "textDecorationColor" "#2E8B57"
        static member inline forestGreen = StyleHelper.mkStyle "textDecorationColor" "#228B22"
        static member inline green = StyleHelper.mkStyle "textDecorationColor" "#008000"
        static member inline darkGreen = StyleHelper.mkStyle "textDecorationColor" "#006400"
        static member inline yellowGreen = StyleHelper.mkStyle "textDecorationColor" "#9ACD32"
        static member inline oliveDrab = StyleHelper.mkStyle "textDecorationColor" "#6B8E23"
        static member inline olive = StyleHelper.mkStyle "textDecorationColor" "#808000"
        static member inline darkOliveGreen = StyleHelper.mkStyle "textDecorationColor" "#556B2F"
        static member inline mediumAquamarine = StyleHelper.mkStyle "textDecorationColor" "#66CDAA"
        static member inline darkSeaGreen = StyleHelper.mkStyle "textDecorationColor" "#8FBC8B"
        static member inline lightSeaGreen = StyleHelper.mkStyle "textDecorationColor" "#20B2AA"
        static member inline darkCyan = StyleHelper.mkStyle "textDecorationColor" "#008B8B"
        static member inline teal = StyleHelper.mkStyle "textDecorationColor" "#008080"
        static member inline aqua = StyleHelper.mkStyle "textDecorationColor" "#00FFFF"
        static member inline cyan = StyleHelper.mkStyle "textDecorationColor" "#00FFFF"
        static member inline lightCyan = StyleHelper.mkStyle "textDecorationColor" "#E0FFFF"
        static member inline paleTurqouise = StyleHelper.mkStyle "textDecorationColor" "#AFEEEE"
        static member inline aquaMarine = StyleHelper.mkStyle "textDecorationColor" "#7FFFD4"
        static member inline turqouise = StyleHelper.mkStyle "textDecorationColor" "#AFEEEE"
        static member inline mediumTurqouise = StyleHelper.mkStyle "textDecorationColor" "#48D1CC"
        static member inline darkTurqouise = StyleHelper.mkStyle "textDecorationColor" "#00CED1"
        static member inline cadetBlue = StyleHelper.mkStyle "textDecorationColor" "#5F9EA0"
        static member inline steelBlue = StyleHelper.mkStyle "textDecorationColor" "#4682B4"
        static member inline lightSteelBlue = StyleHelper.mkStyle "textDecorationColor" "#B0C4DE"
        static member inline powederBlue = StyleHelper.mkStyle "textDecorationColor" "#B0E0E6"
        static member inline lightBlue = StyleHelper.mkStyle "textDecorationColor" "#ADD8E6"
        static member inline skyBlue = StyleHelper.mkStyle "textDecorationColor" "#87CEEB"
        static member inline lightSkyBlue = StyleHelper.mkStyle "textDecorationColor" "#87CEFA"
        static member inline deepSkyBlue = StyleHelper.mkStyle "textDecorationColor" "#00BFFF"
        static member inline dodgerBlue = StyleHelper.mkStyle "textDecorationColor" "#1E90FF"
        static member inline cornFlowerBlue = StyleHelper.mkStyle "textDecorationColor" "#6495ED"
        static member inline royalBlue = StyleHelper.mkStyle "textDecorationColor" "#4169E1"
        static member inline blue = StyleHelper.mkStyle "textDecorationColor" "#0000FF"
        static member inline mediumBlue = StyleHelper.mkStyle "textDecorationColor" "#0000CD"
        static member inline darkBlue = StyleHelper.mkStyle "textDecorationColor" "#00008B"
        static member inline navy = StyleHelper.mkStyle "textDecorationColor" "#000080"
        static member inline midnightBlue = StyleHelper.mkStyle "textDecorationColor" "#191970"
        static member inline cornSilk = StyleHelper.mkStyle "textDecorationColor" "#FFF8DC"
        static member inline blanchedAlmond = StyleHelper.mkStyle "textDecorationColor" "#FFEBCD"
        static member inline bisque = StyleHelper.mkStyle "textDecorationColor" "#FFE4C4"
        static member inline navajoWhite = StyleHelper.mkStyle "textDecorationColor" "#FFDEAD"
        static member inline wheat = StyleHelper.mkStyle "textDecorationColor" "#F5DEB3"
        static member inline burlyWood = StyleHelper.mkStyle "textDecorationColor" "#DEB887"
        static member inline tan = StyleHelper.mkStyle "textDecorationColor" "#D2B48C"
        static member inline rosyBrown = StyleHelper.mkStyle "textDecorationColor" "#BC8F8F"
        static member inline sandyBrown = StyleHelper.mkStyle "textDecorationColor" "#F4A460"
        static member inline goldenRod = StyleHelper.mkStyle "textDecorationColor" "#DAA520"
        static member inline darkGoldenRod = StyleHelper.mkStyle "textDecorationColor" "#B8860B"
        static member inline peru = StyleHelper.mkStyle "textDecorationColor" "#CD853F"
        static member inline chocolate = StyleHelper.mkStyle "textDecorationColor" "#D2691E"
        static member inline saddleBrown = StyleHelper.mkStyle "textDecorationColor" "#8B4513"
        static member inline sienna = StyleHelper.mkStyle "textDecorationColor" "#A0522D"
        static member inline brown = StyleHelper.mkStyle "textDecorationColor" "#A52A2A"
        static member inline maroon = StyleHelper.mkStyle "textDecorationColor" "#A52A2A"
        static member inline white = StyleHelper.mkStyle "textDecorationColor" "#FFFFFF"
        static member inline snow = StyleHelper.mkStyle "textDecorationColor" "#FFFAFA"
        static member inline honeyDew = StyleHelper.mkStyle "textDecorationColor" "#F0FFF0"
        static member inline mintCream = StyleHelper.mkStyle "textDecorationColor" "#F5FFFA"
        static member inline azure = StyleHelper.mkStyle "textDecorationColor" "#F0FFFF"
        static member inline aliceBlue = StyleHelper.mkStyle "textDecorationColor" "#F0F8FF"
        static member inline ghostWhite = StyleHelper.mkStyle "textDecorationColor" "#F8F8FF"
        static member inline whiteSmoke = StyleHelper.mkStyle "textDecorationColor" "#F5F5F5"
        static member inline seaShell = StyleHelper.mkStyle "textDecorationColor" "#FFF5EE"
        static member inline beige = StyleHelper.mkStyle "textDecorationColor" "#F5F5DC"
        static member inline oldLace = StyleHelper.mkStyle "textDecorationColor" "#FDF5E6"
        static member inline floralWhite = StyleHelper.mkStyle "textDecorationColor" "#FFFAF0"
        static member inline ivory = StyleHelper.mkStyle "textDecorationColor" "#FFFFF0"
        static member inline antiqueWhite = StyleHelper.mkStyle "textDecorationColor" "#FAEBD7"
        static member inline linen = StyleHelper.mkStyle "textDecorationColor" "#FAF0E6"
        static member inline lavenderBlush = StyleHelper.mkStyle "textDecorationColor" "#FFF0F5"
        static member inline mistyRose = StyleHelper.mkStyle "textDecorationColor" "#FFE4E1"
        static member inline gainsBoro = StyleHelper.mkStyle "textDecorationColor" "#DCDCDC"
        static member inline lightGray = StyleHelper.mkStyle "textDecorationColor" "#D3D3D3"
        static member inline silver = StyleHelper.mkStyle "textDecorationColor" "#C0C0C0"
        static member inline darkGray = StyleHelper.mkStyle "textDecorationColor" "#A9A9A9"
        static member inline gray = StyleHelper.mkStyle "textDecorationColor" "#808080"
        static member inline dimGray = StyleHelper.mkStyle "textDecorationColor" "#696969"
        static member inline lightSlateGray = StyleHelper.mkStyle "textDecorationColor" "#778899"
        static member inline slateGray = StyleHelper.mkStyle "textDecorationColor" "#708090"
        static member inline darkSlateGray = StyleHelper.mkStyle "textDecorationColor" "#2F4F4F"
        static member inline black = StyleHelper.mkStyle "textDecorationColor" "#000000"
        static member inline transparent = StyleHelper.mkStyle "textDecorationColor" "transparent"

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
        static member inline row = StyleHelper.mkStyle "gridAutoFlow" "row"
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
        static member inline column = StyleHelper.mkStyle "gridAutoFlow" "column"
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
        static member inline dense = StyleHelper.mkStyle "gridAutoFlow" "dense"
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
        static member inline rowDense = StyleHelper.mkStyle "gridAutoFlow" "row dense"
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
        static member inline columnDense = StyleHelper.mkStyle "gridAutoFlow" "column dense"

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
        static member inline auto = StyleHelper.mkStyle "gridAutoColumns" "auto"
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
        static member inline minContent = StyleHelper.mkStyle "gridAutoColumns" "min-content"
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
        static member inline maxContent = StyleHelper.mkStyle "gridAutoColumns" "max-content"
    
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
        static member inline auto = StyleHelper.mkStyle "gridAutoRows" "auto"
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
        static member inline minContent = StyleHelper.mkStyle "gridAutoRows" "min-content"
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
        static member inline maxContent = StyleHelper.mkStyle "gridAutoRows" "max-content"

    /// Sets the height of a line box. It's commonly used to set the distance between lines of text.
    /// On block-level elements, it specifies the minimum height of line boxes within the element.
    /// On non-replaced inline elements, it specifies the height that is used to calculate line box height.
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/line-height
    [<Erase>]
    type lineHeight =
        /// Depends on the user agent. Desktop browsers (including Firefox)
        /// use a default value of roughly 1.2, depending on the element's font-family.
        static member inline normal = StyleHelper.mkStyle "lineHeight" "normal"
