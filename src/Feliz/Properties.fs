namespace Feliz

open Browser.Types
open Fable.Core.JsInterop
open Fable.Core
open Feliz.Styles
open System.ComponentModel
open System

module PropHelper =

    let inline mkAttr (key: string) (value: obj) : IReactProperty = unbox (key, value)
[<StringEnum; RequireQualifiedAccess>]
type AriaDropEffect =
    /// A duplicate of the source object will be dropped into the target.
    | Copy
    /// A function supported by the drop target is executed, using the drag
    /// source as an input.
    | Execute
    /// A reference or shortcut to the dragged object will be created in the
    /// target object.
    | Link
    /// The source object will be removed from its current location and dropped
    /// into the target.
    | Move
    /// No operation can be performed; effectively cancels the drag operation if
    /// an attempt is made to drop on this object. Ignored if combined with any
    /// other token value. e.g. 'none copy' is equivalent to a 'copy' value.
    | None
    /// There is a popup menu or dialog that allows the user to choose one of
    /// the drag operations (copy, move, link, execute) and any other drag
    /// functionality, such as cancel.
    | Popup

[<StringEnum; RequireQualifiedAccess>]
type AriaRelevant =
    /// Element nodes are added to the DOM within the live region.
    | Additions
    /// Equivalent to the combination of all values, "additions removals text".
    | All
    /// Text or element nodes within the live region are removed from the DOM.
    | Removals
    /// Text is added to any DOM descendant nodes of the live region.
    | Text

[<RequireQualifiedAccess; EditorBrowsable(EditorBrowsableState.Never)>]
module PropHelpers =
    let createClockValue (duration: System.TimeSpan) =
        let inline emptyZero i =
            if i < 10 then "0" + (unbox<string> i)
            else unbox<string> i

        [ duration.Hours
          duration.Minutes
          duration.Seconds ]
        |> List.map emptyZero
        |> String.concat ":"
        |> fun res -> res + "." + (emptyZero duration.Milliseconds)

    let createKeySplines (values: seq<float * float * float * float>) =
        values
        |> Seq.map (fun (x1,y1,x2,y2) ->
            (unbox<string> x1) + " " +
            (unbox<string> y1) + " " +
            (unbox<string> x2) + " " +
            (unbox<string> y2))
        |> String.concat "; "

    let createOnKey (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        fun (ev: KeyboardEvent) ->
            let (pressedKey: string, ctrl: bool, shift: bool) = unbox key
            match ctrl, shift with
            | true, true when pressedKey.ToLower() = ev.key.ToLower() && ev.ctrlKey && ev.shiftKey -> handler ev
            | true, false when pressedKey.ToLower() = ev.key.ToLower() && ev.ctrlKey -> handler ev
            | false, true when pressedKey.ToLower() = ev.key.ToLower() && ev.shiftKey -> handler ev
            | false, false when pressedKey.ToLower() = ev.key.ToLower() -> handler ev
            | _, _ -> ()

    let createPointsFloat (coordinates: seq<float * float>) =
        coordinates
        |> Seq.map (fun (x,y) -> (unbox<string> x) + "," + (unbox<string> y))
        |> String.concat " "

    let createPointsInt (coordinates: seq<int * int>) =
        coordinates
        |> Seq.map (fun (x,y) -> (unbox<string> x) + "," + (unbox<string> y))
        |> String.concat " "

    let createSvgPathFloat (path: seq<char * (float list list)>) =
        path
        |> Seq.map (fun (cmdType, cmds) ->
            if cmds.Length = 0 then unbox<string> cmdType
            else
                cmds
                |> Seq.map (unbox<seq<string>> >> String.concat ",")
                |> String.concat " "
                |> fun res -> (unbox<string> cmdType) + " " + res)
        |> String.concat System.Environment.NewLine

    let createSvgPathInt (path: seq<char * (int list list)>) =
        path
        |> Seq.map (fun (cmdType, cmds) ->
            if cmds.Length = 0 then unbox<string> cmdType
            else
                cmds
                |> Seq.map (unbox<seq<string>> >> String.concat ",")
                |> String.concat " "
                |> fun res -> (unbox<string> cmdType) + " " + res)
        |> String.concat System.Environment.NewLine

    let dateTimeValueFunc (value: System.DateTime option) (includeTime: bool) =
        match value with
        | None -> ""
        | Some date ->
            if includeTime
            then (date.ToString("yyyy-MM-ddThh:mm"))
            else (date.ToString("yyyy-MM-dd"))

/// Represents the native Html properties.
[<Erase>]
type prop =
    /// List of types the server accepts, typically a file type.
    static member inline accept (value: string) = PropHelper.mkAttr "accept" value

    /// List of supported charsets.
    static member inline acceptCharset (value: string) = PropHelper.mkAttr "acceptCharset" value

    /// Defines a keyboard shortcut to activate or add focus to the element.
    static member inline accessKey (value: string) = PropHelper.mkAttr "accessKey" value

    /// The URI of a program that processes the information submitted via the form.
    static member inline action (value: string) = PropHelper.mkAttr "action" value

    /// Alternative text in case an image can't be displayed.
    static member inline alt (value: string) = PropHelper.mkAttr "alt" value

    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: float) = PropHelper.mkAttr "amplitude" value
    /// Controls the amplitude of the gamma function of a component transfer element when
    /// its type attribute is gamma.
    static member inline amplitude (value: int) = PropHelper.mkAttr "amplitude" value

    /// Identifies the currently active descendant of a `composite` widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-activedescendant
    static member inline ariaActiveDescendant (id: string) = PropHelper.mkAttr "aria-activedescendant" id

    /// Indicates whether assistive technologies will present all, or only parts
    /// of, the changed region based on the change notifications defined by the
    /// `aria-relevant` attribute.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-atomic
    static member inline ariaAtomic (value: bool) = PropHelper.mkAttr "aria-atomic" value

    /// Indicates whether an element, and its subtree, are currently being
    /// updated.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-busy
    static member inline ariaBusy (value: bool) = PropHelper.mkAttr "aria-busy" value

    /// Indicates the current "checked" state of checkboxes, radio buttons, and
    /// other widgets. See related `aria-pressed` and `aria-selected`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-checked
    static member inline ariaChecked (value: bool) = PropHelper.mkAttr "aria-checked" value

    /// Identifies the element (or elements) whose contents or presence are
    /// controlled by the current element. See related `aria-owns`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-controls
    static member inline ariaControls ([<System.ParamArray>] ids: string []) = PropHelper.mkAttr "aria-controls" (String.concat " " ids)

    /// Specifies a URI referencing content that describes the object. See
    /// related `aria-describedby`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-describedat
    static member inline ariaDescribedAt (uri: string) = PropHelper.mkAttr "aria-describedat" uri

    /// Identifies the element (or elements) that describes the object. See
    /// related `aria-describedat` and `aria-labelledby`.
    ///
    /// The `aria-labelledby` attribute is similar to `aria-describedby` in that
    /// both reference other elements to calculate a text alternative, but a
    /// label should be concise, where a description is intended to provide more
    /// verbose information.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-describedby
    static member inline ariaDescribedBy ([<System.ParamArray>] ids: string []) = PropHelper.mkAttr "aria-describedby" (String.concat " " ids)

    /// Indicates that the element is perceivable but disabled, so it is not
    /// editable or otherwise operable. See related `aria-hidden` and
    /// `aria-readonly`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-disabled
    static member inline ariaDisabled (value: bool) = PropHelper.mkAttr "aria-disabled" value

    /// Indicates what functions can be performed when the dragged object is
    /// released on the drop target. This allows assistive technologies to
    /// convey the possible drag options available to users, including whether a
    /// pop-up menu of choices is provided by the application. Typically, drop
    /// effect functions can only be provided once an object has been grabbed
    /// for a drag operation as the drop effect functions available are
    /// dependent on the object being dragged.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-dropeffect
    static member inline ariaDropEffect ([<System.ParamArray>] values: AriaDropEffect []) = PropHelper.mkAttr "aria-dropeffect" (values |> unbox<string []> |> String.concat " ")

    /// Indicates whether the element, or another grouping element it controls,
    /// is currently expanded or collapsed.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-expanded
    static member inline ariaExpanded (value: bool) = PropHelper.mkAttr "aria-expanded" value

    /// Identifies the next element (or elements) in an alternate reading order
    /// of content which, at the user's discretion, allows assistive technology
    /// to override the general default of reading in document source order.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-flowto
    static member inline ariaFlowTo ([<System.ParamArray>] ids: string []) = PropHelper.mkAttr "aria-flowto" (String.concat " " ids)

    /// Indicates an element's "grabbed" state in a drag-and-drop operation.
    ///
    /// When it is set to true it has been selected for dragging, false
    /// indicates that the element can be grabbed for a drag-and-drop operation,
    /// but is not currently grabbed, and undefined (or no value) indicates the
    /// element cannot be grabbed (default).
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-grabbed
    static member inline ariaGrabbed (value: bool) = PropHelper.mkAttr "aria-grabbed" value

    /// Indicates that the element has a popup context menu or sub-level menu.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-haspopup
    static member inline ariaHasPopup (value: bool) = PropHelper.mkAttr "aria-haspopup" value

    /// Indicates that the element and all of its descendants are not visible or
    /// perceivable to any user as implemented by the author. See related
    /// `aria-disabled`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-hidden
    static member inline ariaHidden (value: bool) = PropHelper.mkAttr "aria-hidden" value

    /// Indicates the entered value does not conform to the format expected by
    /// the application.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-invalid
    static member inline ariaInvalid (value: bool) = PropHelper.mkAttr "aria-invalid" value

    /// Defines a string value that labels the current element. See related
    /// `aria-labelledby`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-label
    static member inline ariaLabel (value: string) = PropHelper.mkAttr "aria-label" value

    /// Defines the hierarchical level of an element within a structure.
    ///
    /// This can be applied inside trees to tree items, to headings inside a
    /// document, to nested grids, nested tablists and to other structural items
    /// that may appear inside a container or participate in an ownership
    /// hierarchy. The value for `aria-level` is an integer greater than or
    /// equal to 1.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-level
    static member inline ariaLevel (value: int) = PropHelper.mkAttr "aria-level" value

    /// Identifies the element (or elements) that labels the current element.
    /// See related `aria-label` and `aria-describedby`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-labelledby
    static member inline ariaLabelledBy ([<System.ParamArray>] ids: string []) = PropHelper.mkAttr "aria-labelledby" (String.concat " " ids)

    /// Indicates whether a text box accepts multiple lines of input or only a
    /// single line.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-multiline
    static member inline ariaMultiLine (value: bool) = PropHelper.mkAttr "aria-multiline" value

    /// Indicates that the user may select more than one item from the current
    /// selectable descendants.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-multiselectable
    static member inline ariaMultiSelectable (value: bool) = PropHelper.mkAttr "aria-multiselectable" value

    /// Identifies an element (or elements) in order to define a visual,
    /// functional, or contextual parent/child relationship between DOM elements
    /// where the DOM hierarchy cannot be used to represent the relationship.
    /// See related `aria-controls`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-owns
    static member inline ariaOwns ([<System.ParamArray>] ids: string []) = PropHelper.mkAttr "aria-owns" (String.concat " " ids)

    /// Indicates the current "pressed" state of toggle buttons. See related
    /// `aria-checked` and `aria-selected`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-pressed
    static member inline ariaPressed (value: bool) = PropHelper.mkAttr "aria-pressed" value

    /// Defines an element's number or position in the current set of listitems
    /// or treeitems. Not required if all elements in the set are present in the
    /// DOM. See related `aria-setsize`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-posinset
    static member inline ariaPosInSet (value: int) = PropHelper.mkAttr "aria-posinset" value

    /// Indicates that the element is not editable, but is otherwise operable.
    /// See related `aria-disabled`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-readonly
    static member inline ariaReadOnly (value: bool) = PropHelper.mkAttr "aria-readonly" value

    /// Indicates what user agent change notifications (additions, removals,
    /// etc.) assistive technologies will receive within a live region. See
    /// related `aria-atomic`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-relevant
    static member inline ariaRelevant ([<System.ParamArray>] values: AriaRelevant []) = PropHelper.mkAttr "aria-relevant" (values |> unbox<string []> |> String.concat " ")

    /// Indicates that user input is required on the element before a form may
    /// be submitted.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-required
    static member inline ariaRequired (value: bool) = PropHelper.mkAttr "aria-required" value

    /// Defines a human-readable, author-localized description for the role of an element.
    ///
    /// https://www.w3.org/WAI/PF/wai-aria-1.1/states_and_properties#aria-roledescription
    static member inline ariaRoleDescription (value: string) = PropHelper.mkAttr "aria-roledescription" value

    /// Indicates the current "selected" state of various widgets. See related
    /// `aria-checked` and `aria-pressed`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-selected
    static member inline ariaSelected (value: bool) = PropHelper.mkAttr "aria-selected" value

    /// Defines the maximum allowed value for a range widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuemax
    static member inline ariaValueMax (value: float) = PropHelper.mkAttr "aria-valuemax" value
    /// Defines the maximum allowed value for a range widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuemax
    static member inline ariaValueMax (value: int) = PropHelper.mkAttr "aria-valuemax" value

    /// Defines the minimum allowed value for a range widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuemin
    static member inline ariaValueMin (value: float) = PropHelper.mkAttr "aria-valuemin" value
    /// Defines the minimum allowed value for a range widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuemin
    static member inline ariaValueMin (value: int) = PropHelper.mkAttr "aria-valuemin" value

    /// Defines the current value for a range widget. See related
    /// `aria-valuetext`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuenow
    static member inline ariaValueNow (value: float) = PropHelper.mkAttr "aria-valuenow" value
    /// Defines the current value for a range widget. See related
    /// `aria-valuetext`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuenow
    static member inline ariaValueNow (value: int) = PropHelper.mkAttr "aria-valuenow" value

    /// Defines the human readable text alternative of `aria-valuenow` for a
    /// range widget.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-valuetext
    static member inline ariaValueText (value: string) = PropHelper.mkAttr "aria-valuetext" value

    /// Defines the number of items in the current set of listitems or
    /// treeitems. Not required if all elements in the set are present in the
    /// DOM. See related `aria-posinset`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-setsize
    static member inline ariaSetSize (value: int) = PropHelper.mkAttr "aria-setsize" value

    /// Indicates that the script should be executed asynchronously.
    static member inline async (value: bool) = PropHelper.mkAttr "async" value

    /// Indicates the name of the CSS property or attribute of the target element
    /// that is going to be changed during an animation.
    static member inline attributeName (value: string) = PropHelper.mkAttr "attributeName" value

    /// Indicates whether controls in this form can by default have their values
    /// automatically completed by the browser.
    static member inline autoComplete (value: string) = PropHelper.mkAttr "autoComplete" value

    /// The element should be automatically focused after the page loaded.
    static member inline autoFocus (value: bool) = PropHelper.mkAttr "autoFocus" value

    /// The audio or video should play as soon as possible.
    static member inline autoPlay (value: bool) = PropHelper.mkAttr "autoPlay" value

    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: float) = PropHelper.mkAttr "azimuth" value
    /// Specifies the direction angle for the light source on the XY plane (clockwise),
    /// in degrees from the x axis.
    static member inline azimuth (value: int) = PropHelper.mkAttr "azimuth" value

    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: float) = PropHelper.mkAttr "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (value: int) = PropHelper.mkAttr "baseFrequency" value
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: float) = PropHelper.mkAttr "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: float, vertical: int) = PropHelper.mkAttr "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: float) = PropHelper.mkAttr "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)
    /// Represents the base frequency parameter for the noise function of the
    /// <feTurbulence> filter primitive.
    static member inline baseFrequency (horizontal: int, vertical: int) = PropHelper.mkAttr "baseFrequency" (unbox<string> horizontal  + "," + unbox<string> vertical)

    /// Defines when an animation should begin or when an element should be discarded.
    static member inline begin' (value: string) = PropHelper.mkAttr "begin" value

    /// Shifts the range of the filter. After applying the kernelMatrix of the <feConvolveMatrix>
    /// element to the input image to yield a number and applied the divisor attribute, the bias
    /// attribute is added to each component. This allows representation of values that would
    /// otherwise be clamped to 0 or 1.
    static member inline bias (value: float) = PropHelper.mkAttr "bias" value
    /// Shifts the range of the filter. After applying the kernelMatrix of the <feConvolveMatrix>
    /// element to the input image to yield a number and applied the divisor attribute, the bias
    /// attribute is added to each component. This allows representation of values that would
    /// otherwise be clamped to 0 or 1.
    static member inline bias (value: int) = PropHelper.mkAttr "bias" value

    /// Specifies a relative offset value for an attribute that will be modified during an animation.
    static member inline by (value: float) = PropHelper.mkAttr "by" value
    /// Specifies a relative offset value for an attribute that will be modified during an animation.
    static member inline by (value: int) = PropHelper.mkAttr "by" value
    /// Specifies a relative offset value for an attribute that will be modified during an animation.
    static member inline by (value: string) = PropHelper.mkAttr "by" value

    static member inline capture (value: bool) = PropHelper.mkAttr "capture" value

    /// This attribute declares the document's character encoding. Must be used in the meta tag.
    static member inline charset (value: string) = PropHelper.mkAttr "charSet" value

    /// Children of this React element.
    static member inline children (value: ReactElement) = PropHelper.mkAttr "children" [value]
    /// Children of this React element.
    static member inline children (elems: ReactElement seq) = PropHelper.mkAttr "children" elems

    /// A URL that designates a source document or message for the information quoted. This attribute is intended to
    /// point to information explaining the context or the reference for the quote.
    static member inline cite (value: string) = PropHelper.mkAttr "cite" value

    /// Specifies a CSS class for this element.
    static member inline className (value: string) = PropHelper.mkAttr "className" value
    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `prop.className [ "one"; "two" ]`
    ///
    /// is the same as
    ///
    /// `prop.className "one two"`
    static member inline className (names: seq<string>) = PropHelper.mkAttr "className" (String.concat " " names)

    /// Takes a `seq<string>` and joins them using a space to combine the classes into a single class property.
    ///
    /// `prop.classes [ "one"; "two" ]` => `prop.className "one two"`
    static member inline classes (names: seq<string>) = PropHelper.mkAttr "className" (String.concat " " names)

    /// Defines the number of columns in a textarea.
    static member inline cols (value: int) = PropHelper.mkAttr "cols" value

    /// Defines the number of columns a cell should span.
    static member inline colSpan (value: int) = PropHelper.mkAttr "colSpan" value

    /// A value associated with http-equiv or name depending on the context.
    static member inline content (value: string) = PropHelper.mkAttr "content" value

    /// Indicates whether the element's content is editable.
    static member inline contentEditable (value: bool) = PropHelper.mkAttr "contentEditable" value

    /// If true, the browser will offer controls to allow the user to control video playback,
    /// including volume, seeking, and pause/resume playback.
    static member inline controls (value: bool) = PropHelper.mkAttr "controls" value

    /// Create a custom prop
    ///
    /// You generally shouldn't need to use this, if you notice a core React/Html attribute missing please submit an issue.
    static member inline custom (key: string, value: 't) = PropHelper.mkAttr key value

    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: float) = PropHelper.mkAttr "cx" value
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: ICssUnit) = PropHelper.mkAttr "cx" value
    /// The SVG cx attribute define the x-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cx (value: int) = PropHelper.mkAttr "cx" value

    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: float) = PropHelper.mkAttr "cy" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: ICssUnit) = PropHelper.mkAttr "cy" value
    /// The SVG cy attribute define the y-axis coordinate of a center point.
    ///
    /// Three elements are using this attribute: <circle>, <ellipse>, and <radialGradient>
    static member inline cy (value: int) = PropHelper.mkAttr "cy" value

    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> PropHelper.mkAttr "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> PropHelper.mkAttr "d"
    /// Defines a SVG path to be drawn.
    static member inline d (path: string) = PropHelper.mkAttr "d" path

    /// Sets the inner Html content of the element.
    static member inline dangerouslySetInnerHTML (content: string) = PropHelper.mkAttr "dangerouslySetInnerHTML" (createObj [ "__html" ==> content ])

    /// This attribute indicates the time and/or date of the element.
    static member inline dateTime (value: string) = PropHelper.mkAttr "dateTime" value

    /// Sets the DOM defaultChecked value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultChecked (value: bool) = PropHelper.mkAttr "defaultChecked" value

    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: bool) = PropHelper.mkAttr "defaultValue" value
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: float) = PropHelper.mkAttr "defaultValue" value
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: int) = PropHelper.mkAttr "defaultValue" value
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: string) = PropHelper.mkAttr "defaultValue" value
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: seq<float>) = PropHelper.mkAttr "defaultValue" (ResizeArray value)
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: seq<int>) = PropHelper.mkAttr "defaultValue" (ResizeArray value)
    /// Sets the DOM defaultValue value when initially rendered.
    ///
    /// Typically only used with uncontrolled components.
    static member inline defaultValue (value: seq<string>) = PropHelper.mkAttr "defaultValue" (ResizeArray value)

    /// Indicates to a browser that the script is meant to be executed after the document
    /// has been parsed, but before firing DOMContentLoaded.
    ///
    /// Scripts with the defer attribute will prevent the DOMContentLoaded event from
    /// firing until the script has loaded and finished evaluating.
    ///
    /// This attribute must not be used if the src attribute is absent (i.e. for inline scripts),
    /// in this case it would have no effect.
    static member inline defer (value: bool) = PropHelper.mkAttr "defer" value

    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: float) = PropHelper.mkAttr "diffuseConstant" value
    /// Represents the kd value in the Phong lighting model.
    ///
    /// In SVG, this can be any non-negative number.
    static member inline diffuseConstant (value: int) = PropHelper.mkAttr "diffuseConstant" value

    /// Sets the directionality of the element.
    static member inline dirName (value: string) = PropHelper.mkAttr "dirName" value

    /// Indicates whether the user can interact with the element.
    static member inline disabled (value: bool) = PropHelper.mkAttr "disabled" value

    /// Specifies the value by which the resulting number of applying the kernelMatrix
    /// of a <feConvolveMatrix> element to the input image color value is divided to
    /// yield the destination color value.
    ///
    /// A divisor that is the sum of all the matrix values tends to have an evening
    /// effect on the overall color intensity of the result.
    static member inline divisor (value: float) = PropHelper.mkAttr "divisor" value
    /// Specifies the value by which the resulting number of applying the kernelMatrix
    /// of a <feConvolveMatrix> element to the input image color value is divided to
    /// yield the destination color value.
    ///
    /// A divisor that is the sum of all the matrix values tends to have an evening
    /// effect on the overall color intensity of the result.
    static member inline divisor (value: int) = PropHelper.mkAttr "divisor" value

    /// This attribute, if present, indicates that the author intends the hyperlink to be used for downloading a resource.
    static member inline download (value: bool) = PropHelper.mkAttr "download" value

    /// This attribute, if present, indicates that the author intends the hyperlink to be used for downloading a resource.
    /// The value specifies the default file name for use in labeling the resource in a local file system.
    static member inline download (value: string) = PropHelper.mkAttr "download" value

    /// Indicates whether the the element can be dragged.
    static member inline draggable (value: bool) = PropHelper.mkAttr "draggable" value

    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: float) = PropHelper.mkAttr "dx" value
    /// SVG attribute to indicate a shift along the x-axis on the position of an element or its content.
    static member inline dx (value: int) = PropHelper.mkAttr "dx" value

    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: float) = PropHelper.mkAttr "dy" value
    /// SVG attribute to indicate a shift along the y-axis on the position of an element or its content.
    static member inline dy (value: int) = PropHelper.mkAttr "dy" value

    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: float) = PropHelper.mkAttr "elevation" value
    /// SVG attribute that specifies the direction angle for the light source from the XY plane towards
    /// the Z-axis, in degrees.
    ///
    /// Note that the positive Z-axis points towards the viewer of the content.
    static member inline elevation (value: int) = PropHelper.mkAttr "elevation" value

    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (value: string) = PropHelper.mkAttr "end" value
    /// Defines an end value for the animation that can constrain the active duration.
    static member inline end' (values: seq<string>) = PropHelper.mkAttr "end" (String.concat ";" values)

    /// Defines the exponent of the gamma function.
    static member inline exponent (value: float) = PropHelper.mkAttr "exponent" value
    /// Defines the exponent of the gamma function.
    static member inline exponent (value: int) = PropHelper.mkAttr "exponent" value

    /// Defines the files that will be uploaded when using an input element of the file type.
    static member inline files (value: FileList) = PropHelper.mkAttr "files" value

    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: float) = PropHelper.mkAttr "fillOpacity" value
    /// SVG attribute to define the opacity of the paint server (color, gradient, pattern, etc) applied to a shape.
    static member inline fillOpacity (value: int) = PropHelper.mkAttr "fillOpacity" value

    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: float) = PropHelper.mkAttr "fontSize" value
    /// SVG attribute to define the size of the font from baseline to baseline when multiple
    /// lines of text are set solid in a multiline layout environment.
    static member inline fontSize (value: int) = PropHelper.mkAttr "fontSize" value

    /// A space-separated list of other elements’ ids, indicating that those elements contributed input
    /// values to (or otherwise affected) the calculation.
    static member inline for' (value: string) = PropHelper.mkAttr "for" value
    /// A space-separated list of other elements’ ids, indicating that those elements contributed input
    /// values to (or otherwise affected) the calculation.
    static member inline for' (ids: #seq<string>) = PropHelper.mkAttr "for" (ids |> String.concat " ")

    /// The <form> element to associate the <meter> element with (its form owner). The value of this
    /// attribute must be the id of a <form> in the same document. If this attribute is not set, the
    /// <button> is associated with its ancestor <form> element, if any. This attribute is only used
    /// if the <meter> element is being used as a form-associated element, such as one displaying a
    /// range corresponding to an <input type="number">.
    static member inline form (value: string) = PropHelper.mkAttr "form" value

    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: float) = PropHelper.mkAttr "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<float>) = PropHelper.mkAttr "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: int) = PropHelper.mkAttr "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<int>) = PropHelper.mkAttr "from" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (value: string) = PropHelper.mkAttr "from" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline from (values: seq<string>) = PropHelper.mkAttr "from" (values |> String.concat " ")

    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: float) = PropHelper.mkAttr "fr" value
    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: int) = PropHelper.mkAttr "fr" value
    /// Defines the radius of the focal point for the radial gradient.
    static member inline fr (value: ICssUnit) = PropHelper.mkAttr "fr" value

    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: float) = PropHelper.mkAttr "fx" value
    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: int) = PropHelper.mkAttr "fx" value
    /// Defines the x-axis coordinate of the focal point for a radial gradient.
    static member inline fx (value: ICssUnit) = PropHelper.mkAttr "fx" value

    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: float) = PropHelper.mkAttr "fy" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: int) = PropHelper.mkAttr "fy" value
    /// Defines the y-axis coordinate of the focal point for a radial gradient.
    static member inline fy (value: ICssUnit) = PropHelper.mkAttr "fy" value

    /// Defines an optional additional transformation from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transform: ITransformProperty) =
        PropHelper.mkAttr "gradientTransform" (unbox<string> transform)
    /// Defines optional additional transformation(s) from the gradient coordinate system
    /// onto the target coordinate system (i.e., userSpaceOnUse or objectBoundingBox).
    ///
    /// This allows for things such as skewing the gradient. This additional transformation
    /// matrix is post-multiplied to (i.e., inserted to the right of) any previously defined
    /// transformations, including the implicit transformation necessary to convert from object
    /// bounding box units to user space.
    static member inline gradientTransform (transforms: seq<ITransformProperty>) =
        PropHelper.mkAttr "gradientTransform" (unbox<seq<string>> transforms |> String.concat " ")

    /// Prevents rendering of given element, while keeping child elements, e.g. script elements, active.
    static member inline hidden (value: bool) = PropHelper.mkAttr "hidden" value

    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: float) = PropHelper.mkAttr "height" value
    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: ICssUnit) = PropHelper.mkAttr "height" value
    /// Specifies the height of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline height (value: int) = PropHelper.mkAttr "height" value

    /// The lower numeric bound of the high end of the measured range. This must be less than the
    /// maximum value (max attribute), and it also must be greater than the low value and minimum
    /// value (low attribute and min attribute, respectively), if any are specified. If unspecified,
    /// or if greater than the maximum value, the high value is equal to the maximum value.
    static member inline high (value: float) = PropHelper.mkAttr "high" value
    /// The lower numeric bound of the high end of the measured range. This must be less than the
    /// maximum value (max attribute), and it also must be greater than the low value and minimum
    /// value (low attribute and min attribute, respectively), if any are specified. If unspecified,
    /// or if greater than the maximum value, the high value is equal to the maximum value.
    static member inline high (value: int) = PropHelper.mkAttr "high" value

    /// The URL of a linked resource.
    static member inline href (value: string) = PropHelper.mkAttr "href" value

    /// Indicates the language of the linked resource. Allowed values are determined by BCP47.
    ///
    /// Use this attribute only if the href attribute is present.
    static member inline hrefLang (value: string) = PropHelper.mkAttr "hreflang" value

    static member inline htmlFor (value: string) = PropHelper.mkAttr "htmlFor" value

    /// Often used with CSS to style a specific element. The value of this attribute must be unique.
    static member inline id (value: int) = PropHelper.mkAttr "id" (unbox<string> value)
    /// Often used with CSS to style a specific element. The value of this attribute must be unique.
    static member inline id (value: string) = PropHelper.mkAttr "id" value

    /// Alias for `dangerouslySetInnerHTML`, sets the inner Html content of the element.
    static member inline innerHtml (content: string) = PropHelper.mkAttr "dangerouslySetInnerHTML" (createObj [ "__html" ==> content ])

    /// Contains inline metadata that a user agent can use to verify that a fetched resource
    /// has been delivered free of unexpected manipulation.
    static member inline integrity (value: string) = PropHelper.mkAttr "integrity" value

    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: float) = PropHelper.mkAttr "intercept" value
    /// Defines the intercept of the linear function of color component transfers when the type
    /// attribute is set to linear.
    static member inline intercept (value: int) = PropHelper.mkAttr "intercept" value

    /// Sets the checked attribute for an element.
    static member inline isChecked (value: bool) = PropHelper.mkAttr "checked" value

    /// Sets the open attribute for an element.
    static member inline isOpen (value: bool) = PropHelper.mkAttr "open" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: float) = PropHelper.mkAttr "k1" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k1 (value: int) = PropHelper.mkAttr "k1" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: float) = PropHelper.mkAttr "k2" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k2 (value: int) = PropHelper.mkAttr "k2" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: float) = PropHelper.mkAttr "k3" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k3 (value: int) = PropHelper.mkAttr "k3" value

    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: float) = PropHelper.mkAttr "k4" value
    /// Defines one of the values to be used within the the arithmetic operation of the
    /// <feComposite> filter primitive.
    static member inline k4 (value: int) = PropHelper.mkAttr "k4" value

    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<float>) = PropHelper.mkAttr "kernelMatrix" (values |> unbox<seq<string>> |> String.concat " ")
    /// Defines the list of numbers that make up the kernel matrix for the
    /// <feConvolveMatrix> element.
    static member inline kernelMatrix (values: seq<int>) = PropHelper.mkAttr "kernelMatrix" (values |> unbox<seq<string>>  |> String.concat " ")

    /// A special string attribute you need to include when creating arrays of elements.
    /// Keys help React identify which items have changed, are added, or are removed.
    /// Keys should be given to the elements inside an array to give the elements a stable identity.
    ///
    /// Keys only need to be unique among sibling elements in the same array. They don’t need to
    /// be unique across the whole application or even a single component.
    static member inline key (value: System.Guid) = PropHelper.mkAttr "key" (unbox<string> value)
    /// A special string attribute you need to include when creating arrays of elements. Keys help
    /// React identify which items have changed, are added, or are removed. Keys should be given
    /// to the elements inside an array to give the elements a stable identity.
    ///
    /// Keys only need to be unique among sibling elements in the same array. They don’t need to
    /// be unique across the whole application or even a single component.
    static member inline key (value: int) = PropHelper.mkAttr "key" value
    /// A special string attribute you need to include when creating arrays of elements. Keys
    /// help React identify which
    /// items have changed, are added, or are removed. Keys should be given to the elements
    /// inside an array to give the elements a stable identity.
    ///
    /// Keys only need to be unique among sibling elements in the same array. They don’t need to
    /// be unique across the whole application or even a single component.
    static member inline key (value: string) = PropHelper.mkAttr "key" value

    /// Indicates the simple duration of an animation.
    static member inline keyPoints (values: seq<float>) =
        PropHelper.mkAttr "keyPoints" (values |> unbox<seq<string>>  |> String.concat ";")

    /// Indicates the simple duration of an animation.
    ///
    /// Each control point description is a set of four values: x1 y1 x2 y2, describing the Bézier
    /// control points for one time segment.
    ///
    /// The keyTimes values that define the associated segment are the Bézier "anchor points",
    /// and the keySplines values are the control points. Thus, there must be one fewer sets of
    /// control points than there are keyTimes.
    ///
    /// The values of x1 y1 x2 y2 must all be in the range 0 to 1.
    static member inline keySplines (values: seq<float * float * float * float>) =
        PropHelpers.createKeySplines(values)
        |> PropHelper.mkAttr "keySplines"

    /// Indicates the simple duration of an animation.
    static member inline keyTimes (values: seq<float>) =
        PropHelper.mkAttr "keyTimes" (values |> unbox<seq<string>> |> String.concat ";")

    /// Helps define the language of an element: the language that non-editable elements are
    /// written in, or the language that the editable elements should be written in by the user.
    static member inline lang (value: string) = PropHelper.mkAttr "lang" value
    /// Specifies a user-readable title of the element.
    static member inline label (value: string) = PropHelper.mkAttr "label" value
    /// Defines the color of the light source for lighting filter primitives.
    static member inline lightingColor (value: string) = PropHelper.mkAttr "lighting-color" value

    /// Represents the angle in degrees between the spot light axis (i.e. the axis between the
    /// light source and the point to which it is pointing at) and the spot light cone. So it
    /// defines a limiting cone which restricts the region where the light is projected.
    ///
    /// No light is projected outside the cone.
    static member inline limitingConeAngle (value: float) = PropHelper.mkAttr "limitingConeAngle" value
    /// Represents the angle in degrees between the spot light axis (i.e. the axis between the
    /// light source and the point to which it is pointing at) and the spot light cone. So it
    /// defines a limiting cone which restricts the region where the light is projected.
    ///
    /// No light is projected outside the cone.
    static member inline limitingConeAngle (value: int) = PropHelper.mkAttr "limitingConeAngle" value

    /// Value of the id attribute of the <c>datalist</c> of autocomplete options
    static member inline list (value : string) = PropHelper.mkAttr "list" value

    /// If true, the browser will automatically seek back to the start upon reaching the end of the video.
    static member inline loop (value: bool) = PropHelper.mkAttr "loop" value

    /// The upper numeric bound of the low end of the measured range. This must be greater than
    /// the minimum value (min attribute), and it also must be less than the high value and
    /// maximum value (high attribute and max attribute, respectively), if any are specified.
    /// If unspecified, or if less than the minimum value, the low value is equal to the minimum value.
    static member inline low (value: float) = PropHelper.mkAttr "low" value
    /// The upper numeric bound of the low end of the measured range. This must be greater than
    /// the minimum value (min attribute), and it also must be less than the high value and
    /// maximum value (high attribute and max attribute, respectively), if any are specified.
    /// If unspecified, or if less than the minimum value, the low value is equal to the minimum value.
    static member inline low (value: int) = PropHelper.mkAttr "low" value
    /// Indicates the maximum value allowed.
    static member inline max (value: float) = PropHelper.mkAttr "max" value
    /// Indicates the maximum value allowed.
    static member inline max (value: int) = PropHelper.mkAttr "max" value
    /// Indicates the maximum value allowed.
    static member inline max (value: DateTime) = PropHelper.mkAttr "max" (value.ToString("yyyy-MM-dd"))

    /// Defines the maximum number of characters allowed in the element.
    static member inline maxLength (value: int) = PropHelper.mkAttr "maxLength" value

    /// This attribute specifies the media that the linked resource applies to.
    /// Its value must be a media type / media query. This attribute is mainly useful
    /// when linking to external stylesheets — it allows the user agent to pick the
    /// best adapted one for the device it runs on.
    ///
    /// In HTML 4, this can only be a simple white-space-separated list of media
    /// description literals, i.e., media types and groups, where defined and allowed
    /// as values for this attribute, such as print, screen, aural, braille. HTML5
    /// extended this to any kind of media queries, which are a superset of the allowed
    /// values of HTML 4.
    ///
    /// Browsers not supporting CSS3 Media Queries won't necessarily recognize the adequate
    /// link; do not forget to set fallback links, the restricted set of media queries
    /// defined in HTML 4.
    static member inline media (value: string) = PropHelper.mkAttr "media" value

    /// Defines which HTTP method to use when submitting the form. Can be GET (default) or POST.
    static member inline method (value: string) = PropHelper.mkAttr "method" value

    /// Indicates the minimum value allowed.
    static member inline min (value: float) = PropHelper.mkAttr "min" value
    /// Indicates the minimum value allowed.
    static member inline min (value: int) = PropHelper.mkAttr "min" value
    /// Indicates the minimum value allowed.
    static member inline min (value: DateTime) = PropHelper.mkAttr "min" (value.ToString("yyyy-MM-dd"))

    /// Defines the minimum number of characters allowed in the element.
    static member inline minLength (value: int) = PropHelper.mkAttr "minLength" value

    /// Indicates whether multiple values can be entered in an input of the type email or file.
    static member inline multiple (value: bool) = PropHelper.mkAttr "multiple" value

    /// Indicates whether the audio will be initially silenced on page load.
    static member inline muted (value: bool) = PropHelper.mkAttr "muted" value

    /// Name of the element.
    ///
    /// For example used by the server to identify the fields in form submits.
    static member inline name (value: string) = PropHelper.mkAttr "name" value

    /// This Boolean attribute is set to indicate that the script should not be executed in
    /// browsers that support ES2015 modules — in effect, this can be used to serve fallback
    /// scripts to older browsers that do not support modular JavaScript code.
    static member inline nomodule (value: bool) = PropHelper.mkAttr "nomodule" value

    /// A cryptographic nonce (number used once) to whitelist scripts in a script-src
    /// Content-Security-Policy. The server must generate a unique nonce value each time
    /// it transmits a policy. It is critical to provide a nonce that cannot be guessed
    /// as bypassing a resource's policy is otherwise trivial.
    static member inline nonce (value: string) = PropHelper.mkAttr "nonce" value

    /// Defines the number of octaves for the noise function of the <feTurbulence> primitive.
    static member inline numOctaves (value: int) = PropHelper.mkAttr "numOctaves" value

    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: float) = PropHelper.mkAttr "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: ICssUnit) = PropHelper.mkAttr "offset" value
    /// SVG attribute to define where the gradient color will begin or end.
    static member inline offset (value: int) = PropHelper.mkAttr "offset" value

    /// Fires when a media event is aborted.
    static member inline onAbort (handler: Event -> unit) = PropHelper.mkAttr "onAbort" handler

    /// Fires when animation is aborted.
    static member inline onAnimationCancel (handler: AnimationEvent -> unit) = PropHelper.mkAttr "onAnimationCancel" handler

    /// Fires when animation ends.
    static member inline onAnimationEnd (handler: AnimationEvent -> unit) = PropHelper.mkAttr "onAnimationEnd" handler

    /// Fires when animation iterates.
    static member inline onAnimationIteration (handler: AnimationEvent -> unit) = PropHelper.mkAttr "onAnimationIteration" handler

    /// Fires when animation starts.
    static member inline onAnimationStart (handler: AnimationEvent -> unit) = PropHelper.mkAttr "onAnimationStart" handler

    /// Fires the moment that the element loses focus.
    static member inline onBlur (handler: FocusEvent -> unit) = PropHelper.mkAttr "onBlur" handler

    /// Fires when a user dismisses the current open dialog
    static member inline onCancel (handler: Event -> unit) = PropHelper.mkAttr "onCancel" handler

    /// Fires when a file is ready to start playing (when it has buffered enough to begin).
    static member inline onCanPlay (handler: Event -> unit) = PropHelper.mkAttr "onCanPlay" handler

    /// Fires when a file can be played all the way to the end without pausing for buffering
    static member inline onCanPlayThrough (handler: Event -> unit) = PropHelper.mkAttr "onCanPlayThrough" handler

    /// Same as `onChange` that takes an event as input but instead let's you deal with the `checked` value changed from the `input` element
    /// directly when it is defined as a checkbox with `prop.inputType.checkbox`.
    static member inline onChange (handler: bool -> unit) = PropHelper.mkAttr "onChange" (fun (ev: Event) -> handler (!!ev.target?``checked``))
    /// Fires the moment when the value of the element is changed
    static member inline onChange (handler: Event -> unit) = PropHelper.mkAttr "onChange" handler
    /// Same as `onChange` that takes an event as input but instead lets you deal with the selected file directly from the `input` element when it is defined as a checkbox with `prop.type'.file`.
    static member inline onChange (handler: File -> unit) =
        let fileHandler (ev: Event) : unit =
            let files : FileList = ev?target?files
            if not (isNullOrUndefined files) && files.length > 0 then handler (files.item 0)
        PropHelper.mkAttr "onChange" fileHandler
    /// Same as `onChange` that takes an event as input but instead lets you deal with the selected files directly from the `input` element when it is defined as a checkbox with `prop.type'.file` and `prop.multiple true`.
    static member inline onChange (handler: File list -> unit) =
        let fileHandler (ev: Event) : unit =
            let fileList : FileList = ev?target?files
            if not (isNullOrUndefined fileList) then handler [ for i in 0 .. fileList.length - 1 -> fileList.item i ]
        PropHelper.mkAttr "onChange" fileHandler
    /// Same as `onChange` that takes an event as input but instead let's you deal with the text changed from the `input` element directly
    /// instead of extracting it from the event arguments.
    static member inline onChange (handler: string -> unit) = PropHelper.mkAttr "onChange" (fun (ev: Event) -> handler (!!ev.target?value))
    /// Same as `onChange` that takes an event as input but instead lets you deal with the DateTime changed from the `input` element as if it was a DateTime instance when using input.type.date since the used format either be yyyy-MM-dd or yyyy-MM-ddTHH:mm
    static member inline onChange (handler: DateTime -> unit) =
        PropHelper.mkAttr "onChange" (fun (ev: Event) ->
            let value : string = !!ev.target?value
            DateParsing.parse value
            |> Option.iter handler
        )

    /// Same as `onChange` that takes an event as input but instead lets you deal with the int changed from the `input` element directly when the type of the input is number
    /// instead of extracting it from the event arguments. Fractional numbers are rounded to the nearest integral value.
    static member inline onChange (handler: int -> unit) =
        PropHelper.mkAttr "onChange" (fun (ev: Event) ->
            // round the value to get only integers
            let value : double = !!ev.target?valueAsNumber
            if not (isNullOrUndefined value) && not(Double.IsNaN value) then
                handler (unbox<int> (Math.Round value))
        )
    /// Same as `onChange` that takes an event as input but instead lets you deal with the float changed from the `input` element directly when the input type is a number
    /// instead of extracting it from the event arguments.
    static member inline onChange (handler: float -> unit) =
        PropHelper.mkAttr "onChange" (fun (ev: Event) ->
            let value : double = !!ev.target?valueAsNumber
            if not (isNullOrUndefined value) && not(Double.IsNaN value) then
                handler (value)
        )

    /// Same as `onChange` but let's you deal with the `checked` value that has changed from the `input` element directly instead of extracting it from the event arguments.
    static member inline onCheckedChange (handler: bool -> unit) = PropHelper.mkAttr "onChange" (fun (ev: Event) -> handler (!!ev.target?``checked``))

    /// Fires on a mouse click on the element.
    static member inline onClick (handler: MouseEvent -> unit) = PropHelper.mkAttr "onClick" handler

    /// Fires when composition ends.
    static member inline onCompositionEnd (handler: CompositionEvent -> unit) = PropHelper.mkAttr "onCompositionEnd" handler

    /// Fires when composition starts.
    static member inline onCompositionStart (handler: CompositionEvent -> unit) = PropHelper.mkAttr "onCompositionStart" handler

    /// Fires when composition changes.
    static member inline onCompositionUpdate (handler: CompositionEvent -> unit) = PropHelper.mkAttr "onCompositionUpdate" handler

    /// Fires when a context menu is triggered.
    static member inline onContextMenu (handler: MouseEvent -> unit) = PropHelper.mkAttr "onContextMenu" handler

    /// Fires when a TextTrack has changed the currently displaying cues.
    static member inline onCueChange (handler: Event -> unit) = PropHelper.mkAttr "onCueChange" handler

        /// Fires when the user copies the content of an element.
    static member inline onCopy (handler: ClipboardEvent -> unit) = PropHelper.mkAttr "onCopy" handler

    /// Fires when the user cuts the content of an element.
    static member inline onCut (handler: ClipboardEvent -> unit) = PropHelper.mkAttr "onCut" handler

    /// Fires when a mouse is double clicked on the element.
    [<Obsolete "Use prop.onDoubleClick instead">]
    static member inline onDblClick (handler: MouseEvent -> unit) = PropHelper.mkAttr "onDoubleClick" handler

    /// Fires when a mouse is double clicked on the element.
    static member inline onDoubleClick (handler: MouseEvent -> unit) = PropHelper.mkAttr "onDoubleClick" handler

    /// Fires when an element is dragged.
    static member inline onDrag (handler: DragEvent -> unit) = PropHelper.mkAttr "onDrag" handler

    /// Fires when the a drag operation has ended.
    static member inline onDragEnd (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragEnd" handler

    /// Fires when an element has been dragged to a valid drop target.
    static member inline onDragEnter (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragEnter" handler

    static member inline onDragExit (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragExit" handler

    /// Fires when an element leaves a valid drop target.
    static member inline onDragLeave (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragLeave" handler

    /// Fires when an element is being dragged over a valid drop target.
    static member inline onDragOver (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragOver" handler

    /// Fires when the a drag operation has begun.
    static member inline onDragStart (handler: DragEvent -> unit) = PropHelper.mkAttr "onDragStart" handler

    /// Fires when dragged element is being dropped.
    static member inline onDrop (handler: DragEvent -> unit) = PropHelper.mkAttr "onDrop" handler

    /// Fires when the length of the media changes.
    static member inline onDurationChange (handler: Event -> unit) = PropHelper.mkAttr "onDurationChange" handler

    /// Fires when something bad happens and the file is suddenly unavailable (like unexpectedly disconnects).
    static member inline onEmptied (handler: Event -> unit) = PropHelper.mkAttr "onEmptied" handler

    static member inline onEncrypted (handler: Event -> unit) = PropHelper.mkAttr "onEncrypted" handler

    /// Fires when the media has reached the end (a useful event for messages like "thanks for listening").
    static member inline onEnded (handler: Event -> unit) = PropHelper.mkAttr "onEnded" handler

    /// Fires when an error occurs.
    static member inline onError (handler: Event -> unit) = PropHelper.mkAttr "onError" handler

    /// Fires when an error occurs.
    static member inline onError (handler: UIEvent -> unit) = PropHelper.mkAttr "onError" handler

    /// Fires the moment when the element gets focus.
    static member inline onFocus (handler: FocusEvent -> unit) = PropHelper.mkAttr "onFocus" handler

    /// Fires when an element captures a pointer.
    static member inline onGotPointerCapture (handler: PointerEvent -> unit) = PropHelper.mkAttr "onGotPointerCapture" handler

    /// Fires when an element gets user input.
    static member inline onInput (handler: Event -> unit) = PropHelper.mkAttr "onInput" handler

    /// Fires when a submittable element has been checked for validaty and doesn't satisfy its constraints.
    static member inline onInvalid (handler: Event -> unit) = PropHelper.mkAttr "onInvalid" handler

    /// Fires when a user presses a key.
    static member inline onKeyDown (handler: KeyboardEvent -> unit) = PropHelper.mkAttr "onKeyDown" handler

    /// Fires when a user presses a key.
    static member inline onKeyDown (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> PropHelper.mkAttr "onKeyDown"

    /// Fires when a user presses a key.
    static member inline onKeyPress (handler: KeyboardEvent -> unit) = PropHelper.mkAttr "onKeyPress" handler

    /// Fires when a user presses a key.
    static member inline onKeyPress (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> PropHelper.mkAttr "onKeyPress"

    /// Fires when a user releases a key.
    static member inline onKeyUp (handler: KeyboardEvent -> unit) = PropHelper.mkAttr "onKeyUp" handler

    /// Fires when a user releases a key.
    static member inline onKeyUp (key: IKeyboardKey, handler: KeyboardEvent -> unit) =
        PropHelpers.createOnKey(key, handler)
        |> PropHelper.mkAttr "onKeyUp"

    /// Fires after the page is finished loading.
    static member inline onLoad (handler: Event -> unit) = PropHelper.mkAttr "onLoad" handler

    /// Fires when media data is loaded.
    static member inline onLoadedData (handler: Event -> unit) = PropHelper.mkAttr "onLoadedData" handler

    /// Fires when meta data (like dimensions and duration) are loaded.
    static member inline onLoadedMetadata (handler: Event -> unit) = PropHelper.mkAttr "onLoadedMetadata" handler

    /// Fires when a request has completed, irrespective of its success.
    static member inline onLoadEnd (handler: Event -> unit) = PropHelper.mkAttr "onLoadEnd" handler

    /// Fires when the file begins to load before anything is actually loaded.
    static member inline onLoadStart (handler: Event -> unit) = PropHelper.mkAttr "onLoadStart" handler

    /// Fires when a captured pointer is released.
    static member inline onLostPointerCapture (handler: PointerEvent -> unit) = PropHelper.mkAttr "onLostPointerCapture" handler

    /// Fires when a mouse button is pressed down on an element.
    static member inline onMouseDown (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseDown" handler

    /// Fires when a pointer enters an element.
    static member inline onMouseEnter (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseEnter" handler

    /// Fires when a pointer leaves an element.
    static member inline onMouseLeave (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseLeave" handler

    /// Fires when the mouse pointer is moving while it is over an element.
    static member inline onMouseMove (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseMove" handler

    /// Fires when the mouse pointer moves out of an element.
    static member inline onMouseOut (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseOut" handler

    /// Fires when the mouse pointer moves over an element.
    static member inline onMouseOver (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseOver" handler

    /// Fires when a mouse button is released while it is over an element.
    static member inline onMouseUp (handler: MouseEvent -> unit) = PropHelper.mkAttr "onMouseUp" handler

    /// Fires when the user pastes some content in an element.
    static member inline onPaste (handler: ClipboardEvent -> unit) = PropHelper.mkAttr "onPaste" handler

    /// Fires when the media is paused either by the user or programmatically.
    static member inline onPause (handler: Event -> unit) = PropHelper.mkAttr "onPause" handler

    /// Fires when the media is ready to start playing.
    static member inline onPlay (handler: Event -> unit) = PropHelper.mkAttr "onPlay" handler

    /// Fires when the media actually has started playing
    static member inline onPlaying (handler: Event -> unit) = PropHelper.mkAttr "onPlaying" handler

    /// Fires when there are no more pointer events.
    static member inline onPointerCancel (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerCancel" handler

    /// Fires when a pointer becomes active.
    static member inline onPointerDown (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerDown" handler

    /// Fires when a pointer is moved into an elements boundaries or one of its descendants.
    static member inline onPointerEnter (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerEnter" handler

    /// Fires when a pointer is moved out of an elements boundaries.
    static member inline onPointerLeave (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerLeave" handler

    /// Fires when a pointer moves.
    static member inline onPointerMove (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerMove" handler

    /// Fires when a pointer is no longer in an elements boundaries, such as moving it, or after a `pointerUp` or `pointerCancel` event.
    static member inline onPointerOut (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerOut" handler

    /// Fires when a pointer is moved into an elements boundaries.
    static member inline onPointerOver (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerOver" handler

    /// Fires when a pointer is no longer active.
    static member inline onPointerUp (handler: PointerEvent -> unit) = PropHelper.mkAttr "onPointerUp" handler

    /// Fires when the browser is in the process of getting the media data.
    static member inline onProgress (handler: Event -> unit) = PropHelper.mkAttr "onProgress" handler

    /// Fires when the playback rate changes (like when a user switches to a slow motion or fast forward mode).
    static member inline onRateChange (handler: Event -> unit) = PropHelper.mkAttr "onRateChange" handler

    /// Fires when the Reset button in a form is clicked.
    static member inline onReset (handler: Event -> unit) = PropHelper.mkAttr "onReset" handler

    /// Fires when the window has been resized.
    static member inline onResize (handler: UIEvent -> unit) = PropHelper.mkAttr "onResize" handler

    /// Fires when an element's scrollbar is being scrolled.
    static member inline onScroll (handler: Event -> unit) = PropHelper.mkAttr "onScroll" handler

    /// Fires when the seeking attribute is set to false indicating that seeking has ended.
    static member inline onSeeked (handler: Event -> unit) = PropHelper.mkAttr "onSeeked" handler

    /// Fires when the seeking attribute is set to true indicating that seeking is active.
    static member inline onSeeking (handler: Event -> unit) = PropHelper.mkAttr "onSeeking" handler

    /// Fires after some text has been selected in an element.
    static member inline onSelect (handler: Event -> unit) = PropHelper.mkAttr "onSelect" handler

    /// Fires after some text has been selected in the user interface.
    static member inline onSelect (handler: UIEvent -> unit) = PropHelper.mkAttr "onSelect" handler

    /// Fires when the browser is unable to fetch the media data for whatever reason.
    static member inline onStalled (handler: Event -> unit) = PropHelper.mkAttr "onStalled" handler

    /// Fires when fetching the media data is stopped before it is completely loaded for whatever reason.
    static member inline onSuspend (handler: Event -> unit) = PropHelper.mkAttr "onSuspend" handler

    /// Fires when a form is submitted.
    static member inline onSubmit (handler: Event -> unit) = PropHelper.mkAttr "onSubmit" handler

    /// Same as `onChange` but let's you deal with the text changed from the `input` element directly
    /// instead of extracting it from the event arguments.
    static member inline onTextChange (handler: string -> unit) = PropHelper.mkAttr "onChange" (fun (ev: Event) -> handler (!!ev.target?value))

    /// Fires when the playing position has changed (like when the user fast forwards to a different point in the media).
    static member inline onTimeUpdate (handler: Event -> unit) = PropHelper.mkAttr "onTimeUpdate" handler

    static member inline onTouchCancel (handler: TouchEvent -> unit) = PropHelper.mkAttr "onTouchCancel" handler

    static member inline onTouchEnd (handler: TouchEvent -> unit) = PropHelper.mkAttr "onTouchEnd" handler

    static member inline onTouchMove (handler: TouchEvent -> unit) = PropHelper.mkAttr "onTouchMove" handler

    static member inline onTouchStart (handler: TouchEvent -> unit) = PropHelper.mkAttr "onTouchStart" handler

    static member inline onTransitionEnd (handler: TransitionEvent -> unit) = PropHelper.mkAttr "onTransitionEnd" handler

    static member inline onTransitionStart (handler: TransitionEvent -> unit) = PropHelper.mkAttr "onTransitionStart" handler

    /// Fires when the volume is changed which (includes setting the volume to "mute").
    static member inline onVolumeChange (handler: Event -> unit) = PropHelper.mkAttr "onVolumeChange" handler

    /// Fires when the media has paused but is expected to resume (like when the media pauses to buffer more data).
    static member inline onWaiting (handler: Event -> unit) = PropHelper.mkAttr "onWaiting" handler

    /// Fires when the mouse wheel rolls up or down over an element.
    static member inline onWheel (handler: WheelEvent -> unit) = PropHelper.mkAttr "onWheel" handler

    /// This attribute indicates the optimal numeric value. It must be within the range (as defined by the min
    /// attribute and max attribute). When used with the low attribute and high attribute, it gives an indication
    /// where along the range is considered preferable. For example, if it is between the min attribute and the
    /// low attribute, then the lower range is considered preferred.
    static member inline optimum (value: float) = PropHelper.mkAttr "optimum" value
    /// This attribute indicates the optimal numeric value. It must be within the range (as defined by the min
    /// attribute and max attribute). When used with the low attribute and high attribute, it gives an indication
    /// where along the range is considered preferable. For example, if it is between the min attribute and the
    /// low attribute, then the lower range is considered preferred.
    static member inline optimum (value: int) = PropHelper.mkAttr "optimum" value

    /// Indicates the minimum value allowed.
    static member inline order (value: int) = PropHelper.mkAttr "order" value
    /// Indicates the minimum value allowed.
    static member inline order (values: seq<int>) = PropHelper.mkAttr "order" (values |> unbox<seq<string>> |> String.concat " ")

    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: float) = PropHelper.mkAttr "overline-position" value
    /// Represents the ideal vertical position of the overline.
    ///
    /// The overline position is expressed in the font's coordinate system.
    static member inline overlinePosition (value: int) = PropHelper.mkAttr "overline-position" value

    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: float) = PropHelper.mkAttr "overline-thickness" value
    /// Represents the ideal thickness of the overline.
    ///
    /// The overline thickness is expressed in the font's coordinate system.
    static member inline overlineThickness (value: int) = PropHelper.mkAttr "overline-thickness" value

    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (float list list)>) =
        PropHelpers.createSvgPathFloat path
        |> PropHelper.mkAttr "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: seq<char * (int list list)>) =
        PropHelpers.createSvgPathInt path
        |> PropHelper.mkAttr "path"
    /// It either defines a text path along which the characters of a text are rendered, or a motion
    /// path along which a referenced element is animated.
    static member inline path (path: string) = PropHelper.mkAttr "path" path
    /// The part global attribute contains a space-separated list of the part names of the element.
    /// Part names allows CSS to select and style specific elements in a shadow tree
    static member inline part(value: string) = PropHelper.mkAttr "part" value
    /// The part global attribute contains a space-separated list of the part names of the element.
    /// Part names allows CSS to select and style specific elements in a shadow tree
    static member inline part(values: #seq<string>) = PropHelper.mkAttr "part" (String.concat " " values)
    /// Specifies a total length for the path, in user units.
    ///
    /// This value is then used to calibrate the browser's distance calculations with those of the
    /// author, by scaling all distance computations using the ratio pathLength/(computed value of
    /// path length).
    ///
    /// This can affect the actual rendered lengths of paths; including text paths, animation paths,
    /// and various stroke operations. Basically, all computations that require the length of the path.
    static member inline pathLength (value: int) = PropHelper.mkAttr "pathLength" value

    /// Sets the input field allowed input.
    ///
    /// This attribute only applies when the value of the type attribute is text, search, tel, url or email.
    static member inline pattern (value: System.Text.RegularExpressions.Regex) = PropHelper.mkAttr "pattern" value

    /// Sets the input field allowed input.
    ///
    /// This attribute only applies when the value of the type attribute is text, search, tel, url or email.
    static member inline pattern (value: string) = PropHelper.mkAttr "pattern" value

    /// Defines a list of transform definitions that are applied to a pattern tile.
    static member inline patternTransform (transform: ITransformProperty) =
        PropHelper.mkAttr "patternTransform" (unbox<string> transform)
    /// Defines a list of transform definitions that are applied to a pattern tile.
    static member inline patternTransform (transforms: seq<ITransformProperty>) =
        PropHelper.mkAttr "patternTransform" (unbox<seq<string>> transforms |> String.concat " ")

    /// Provides a hint to the user of what can be entered in the field.
    static member inline placeholder (value: string) = PropHelper.mkAttr "placeholder" value

    /// Indicating that the video is to be played "inline", that is within the element's playback area.
    ///
    /// Note that the absence of this attribute does not imply that the video will always be played in fullscreen.
    static member inline playsInline (value: bool) = PropHelper.mkAttr "playsInline" value

    /// Contains a space-separated list of URLs to which, when the hyperlink is followed,
    /// POST requests with the body PING will be sent by the browser (in the background).
    ///
    /// Typically used for tracking.
    static member inline ping (value: string) = PropHelper.mkAttr "ping" value
    /// Contains a space-separated list of URLs to which, when the hyperlink is followed,
    /// POST requests with the body PING will be sent by the browser (in the background).
    ///
    /// Typically used for tracking.
    static member inline ping (urls: #seq<string>) = PropHelper.mkAttr "ping" (urls |> String.concat " ")

    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<float * float>) =
        PropHelpers.createPointsFloat(coordinates)
        |> PropHelper.mkAttr "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: seq<int * int>) =
        PropHelpers.createPointsInt(coordinates)
        |> PropHelper.mkAttr "points"
    /// Defines a list of points.
    ///
    /// Each point is defined by a pair of numbers representing a X and a Y coordinate in
    /// the user coordinate system.
    static member inline points (coordinates: string) = PropHelper.mkAttr "points"

    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: float) = PropHelper.mkAttr "pointsAtX" value
    /// Represents the x location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtX (value: int) = PropHelper.mkAttr "pointsAtX" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: float) = PropHelper.mkAttr "pointsAtY" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing.
    static member inline pointsAtY (value: int) = PropHelper.mkAttr "pointsAtY" value

    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: float) = PropHelper.mkAttr "pointsAtZ" value
    /// Represents the y location in the coordinate system established by attribute primitiveUnits
    /// on the <filter> element of the point at which the light source is pointing, assuming that,
    /// in the initial local coordinate system, the positive z-axis comes out towards the person
    /// viewing the content and assuming that one unit along the z-axis equals one unit in x and y.
    static member inline pointsAtZ (value: int) = PropHelper.mkAttr "pointsAtZ" value

    /// Turns a <button> or <input> element into a popover control button.
    /// Takes the ID of the popover element to control as its value.
    static member inline popoverTarget(value: string) = PropHelper.mkAttr "popovertarget" value

    /// Indicates how a <feConvolveMatrix> element handles alpha transparency.
    static member inline preserveAlpha (value: bool) = PropHelper.mkAttr "preserveAlpha" value

    /// A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing
    /// is displayed until the first frame is available, then the first frame is shown as the poster frame.
    static member inline poster (value: string) = PropHelper.mkAttr "poster" value

    /// SVG attribute to define the radius of a circle.
    static member inline r (value: float) = PropHelper.mkAttr "r" value
    /// SVG attribute to define the radius of a circle.
    static member inline r (value: ICssUnit) = PropHelper.mkAttr "r" value
    /// SVG attribute to define the radius of a circle.
    static member inline r (value: int) = PropHelper.mkAttr "r" value

    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: float) = PropHelper.mkAttr "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (value: int) = PropHelper.mkAttr "radius" value
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: float) = PropHelper.mkAttr "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: float, yRadius: int) = PropHelper.mkAttr "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: float) = PropHelper.mkAttr "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)
    /// Represents the radius (or radii) for the operation on a given <feMorphology> filter primitive.
    static member inline radius (xRadius: int, yRadius: int) = PropHelper.mkAttr "radius" (unbox<string> xRadius  + "," + unbox<string> yRadius)

    /// Indicates whether the element can be edited.
    static member inline readOnly (value: bool) = PropHelper.mkAttr "readOnly" value

    /// Used to reference a DOM element or class component from within a parent component.
    static member inline ref (handler: Element -> unit) = PropHelper.mkAttr "ref" handler
    /// Used to reference a DOM element or class component from within a parent component.
    static member inline ref (ref: IRefValue<#HTMLElement option>) = PropHelper.mkAttr "ref" ref

    /// For anchors containing the href attribute, this attribute specifies the relationship
    /// of the target object to the link object. The value is a space-separated list of link
    /// types values. The values and their semantics will be registered by some authority that
    /// might have meaning to the document author. The default relationship, if no other is
    /// given, is void.
    ///
    /// Use this attribute only if the href attribute is present.
    static member inline rel (value: string) = PropHelper.mkAttr "rel" value

    /// Indicates whether this element is required to fill out or not.
    static member inline required (value: bool) = PropHelper.mkAttr "required" value

    /// Defines the assigned name for this filter primitive.
    ///
    /// If supplied, then graphics that result from processing this filter primitive can be
    /// referenced by an in attribute on a subsequent filter primitive within the same
    /// <filter> element.
    ///
    /// If no value is provided, the output will only be available for re-use as the implicit
    /// input into the next filter primitive if that filter primitive provides no value for
    /// its in attribute.
    static member inline result (value: string) = PropHelper.mkAttr "result" value

    /// Sets the aria role
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/roles
    static member inline role ([<System.ParamArray>] roles: string []) = PropHelper.mkAttr "role" (String.concat " " roles)

    /// Defines the number of rows in a text area.
    static member inline rows (value: int) = PropHelper.mkAttr "rows" value

    /// Defines the number of rows a table cell should span over.
    static member inline rowSpan (value: int) = PropHelper.mkAttr "rowSpan" value

    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: float) = PropHelper.mkAttr "rx" value
    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: ICssUnit) = PropHelper.mkAttr "rx" value
    /// The SVG rx attribute defines a radius on the x-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline rx (value: int) = PropHelper.mkAttr "rx" value

    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: float) = PropHelper.mkAttr "ry" value
    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: ICssUnit) = PropHelper.mkAttr "ry" value
    /// The SVG ry attribute defines a radius on the y-axis.
    ///
    /// Two elements are using this attribute: <ellipse>, and <rect>
    static member inline ry (value: int) = PropHelper.mkAttr "ry" value

    /// Applies extra restrictions to the content in the frame.
    ///
    /// The value of the attribute can either be empty to apply all restrictions,
    /// or space-separated tokens to lift particular restrictions
    static member inline sandbox (values: #seq<string>) = PropHelper.mkAttr "sandbox" (values |> String.concat " ")

    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: float) = PropHelper.mkAttr "scale" value
    /// Defines the displacement scale factor to be used on a <feDisplacementMap> filter primitive.
    ///
    /// The amount is expressed in the coordinate system established by the primitiveUnits attribute
    /// on the <filter> element.
    static member inline scale (value: int) = PropHelper.mkAttr "scale" value

    /// Defines the cells that the header (defined in the <th>) element relates to. It may have the following values:
    ///
    ///  - row: The header relates to all cells of the row it belongs to.
    ///  - col: The header relates to all cells of the column it belongs to.
    ///  - rowgroup: The header belongs to a rowgroup and relates to all of its cells. These cells can be placed to the right or the left of the header, depending on the value of the dir attribute in the <table> element.
    ///  - colgroup: The header belongs to a colgroup and relates to all of its cells.
    /// If the scope attribute is not specified, or its value is not row, col, or rowgroup, or colgroup, then browsers automatically select the set of cells to which the header cell applies.
    static member inline scope (value: string) = PropHelper.mkAttr "scope" value

    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: float) = PropHelper.mkAttr "seed" value
    /// Represents the starting number for the pseudo random number generator of the <feTurbulence>
    /// filter primitive.
    static member inline seed (value: int) = PropHelper.mkAttr "seed" value

    /// Defines a value which will be selected on page load.
    static member inline selected (value: bool) = PropHelper.mkAttr "selected" value

    /// Sets the beginning index of the selected text.
    ///
    /// When nothing is selected, this returns the position of the text input cursor (caret) inside of the <input> element.
    static member inline selectionStart (value: int) = PropHelper.mkAttr "selectionStart" value

    /// Sets the end index of the selected text.
    ///
    /// When there's no selection, this returns the offset of the character immediately following the current text input cursor position.
    static member inline selectionEnd (value: int) = PropHelper.mkAttr "selectionEnd" value

    /// Sets the *visual* size of the control.
    ///
    /// The value is in pixels unless the value of type is text or password, in which case, it is the number of characters.
    ///
    /// This attribute only applies when type is set to text, search, tel, url, email, or password.
    static member inline size (value: int) = PropHelper.mkAttr "size" value

    /// Defines the sizes of the icons for visual media contained in the resource.
    /// It must be present only if the rel contains a value of icon or a non-standard
    /// type such as Apple's apple-touch-icon.
    ///
    /// It may have the following values:
    ///
    /// `any`, meaning that the icon can be scaled to any size as it is in a vector
    /// format, like image/svg+xml.
    ///
    /// A white-space separated list of sizes, each in the format `<width in pixels>x<height in pixels>`
    /// or `<width in pixels>X<height in pixels>`. Each of these sizes must be contained in the resource.
    static member inline sizes (value: string) = PropHelper.mkAttr "sizes" value

    /// This attribute contains a positive integer indicating the number of consecutive
    /// columns the <col> element spans. If not present, its default value is 1.
    static member inline span (value: int) = PropHelper.mkAttr "span" value

    /// Defines whether the element may be checked for spelling errors.
    static member inline spellcheck (value: bool) = PropHelper.mkAttr "spellcheck" (string value)

    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: float) = PropHelper.mkAttr "specularConstant" value
    /// Controls the ratio of reflection of the specular lighting.
    ///
    /// It represents the ks value in the Phong lighting model. The bigger the value the stronger the reflection.
    static member inline specularConstant (value: int) = PropHelper.mkAttr "specularConstant" value

    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: float) = PropHelper.mkAttr "specularExponent" value
    /// For <feSpecularLighting>, specularExponent defines the exponent value for the specular term.
    ///
    /// For <feSpotLight>, specularExponent defines the exponent value controlling the focus for the light source.
    static member inline specularExponent (value: int) = PropHelper.mkAttr "specularExponent" value

    /// The URL of the embeddable content.
    static member inline src (value: string) = PropHelper.mkAttr "src" value

    /// Language of the track text data. It must be a valid BCP 47 language tag.
    ///
    /// If the kind attribute is set to subtitles, then srclang must be defined.
    static member inline srcLang (value: string) = PropHelper.mkAttr "srclang" value

    /// One or more responsive image candidates.
    static member inline srcset (value: string) = PropHelper.mkAttr "srcset" value

    /// Defines the first number if other than 1.
    static member inline start (value: string) = PropHelper.mkAttr "start" value

    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: float) = PropHelper.mkAttr "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (value: int) = PropHelper.mkAttr "stdDeviation" value
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: float) = PropHelper.mkAttr "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: float, yAxis: int) = PropHelper.mkAttr "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: float) = PropHelper.mkAttr "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)
    /// Defines the standard deviation for the blur operation.
    static member inline stdDeviation (xAxis: int, yAxis: int) = PropHelper.mkAttr "stdDeviation" (unbox<string> xAxis  + "," + unbox<string> yAxis)

    /// Indicates the stepping interval.
    static member inline step (value: float) = PropHelper.mkAttr "step" value
    /// Indicates the stepping interval.
    static member inline step (value: int) = PropHelper.mkAttr "step" value
    /// The slot global attribute assigns a slot in a shadow DOM shadow tree to an element: An element with a slot attribute is assigned to the slot created by the slot element whose name attribute's value matches that slot attribute's value.
    static member inline slot(value: string) = PropHelper.mkAttr "slot" value
    /// SVG attribute to indicate what color to use at a gradient stop.
    static member inline stopColor (value: string) = PropHelper.mkAttr "stopColor" value

    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: float) = PropHelper.mkAttr "stopOpacity" value
    /// SVG attribute to define the opacity of a given color gradient stop.
    static member inline stopOpacity (value: int) = PropHelper.mkAttr "stopOpacity" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: float) = PropHelper.mkAttr "strikethrough-position" value
    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughPosition (value: int) = PropHelper.mkAttr "strikethrough-position" value

    /// Represents the ideal vertical position of the strikethrough.
    ///
    /// The strikethrough position is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: float) = PropHelper.mkAttr "strikethrough-thickness" value
    /// Represents the ideal thickness of the strikethrough.
    ///
    /// The strikethrough thickness is expressed in the font's coordinate system.
    static member inline strikethroughThickness (value: int) = PropHelper.mkAttr "strikethrough-thickness" value

    /// SVG attribute to define the color (or any SVG paint servers like gradients or patterns) used to paint the outline of the shape.
    static member inline stroke (color: string) = PropHelper.mkAttr "stroke" color

    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: float) = PropHelper.mkAttr "strokeWidth" value
    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: ICssUnit) = PropHelper.mkAttr "strokeWidth" value
    /// SVG attribute to define the width of the stroke to be applied to the shape.
    static member inline strokeWidth (value: int) = PropHelper.mkAttr "strokeWidth" value

    static member inline style (properties: #IStyleAttribute list) = PropHelper.mkAttr "style" (createObj !!properties)

    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: float) = PropHelper.mkAttr "surfaceScale" value
    /// Represents the height of the surface for a light filter primitive.
    static member inline surfaceScale (value: int) = PropHelper.mkAttr "surfaceScale" value

    /// Represents a list of supported language tags.
    ///
    /// This list is matched against the language defined in the user preferences.
    static member inline systemLanguage (value: string) = PropHelper.mkAttr "systemLanguage" value

    /// The `tabindex` global attribute indicates that its element can be focused,
    /// and where it participates in sequential keyboard navigation (usually with the Tab key, hence the name).
    static member inline tabIndex (index: int) = PropHelper.mkAttr "tabIndex" index

    /// Controls browser behavior when opening a link.
    static member inline target (frameName: string) = PropHelper.mkAttr "target" frameName

    /// Determines the positioning in horizontal direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The leftmost column of the matrix is column number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetX < orderX.
    static member inline targetX (index: int) = PropHelper.mkAttr "targetX" index

    /// Determines the positioning in vertical direction of the convolution matrix relative to a
    /// given target pixel in the input image.
    ///
    /// The topmost row of the matrix is row number zero.
    ///
    /// The value must be such that:
    ///
    /// 0 <= targetY < orderY.
    static member inline targetY (index: int) = PropHelper.mkAttr "targetY" index

    /// A shorthand for using prop.custom("data-testid", value). Useful for referencing elements when testing React code.
    static member inline testId(value: string) = PropHelper.mkAttr "data-testid" value

    /// Defines the text content of the element. Alias for `children [ Html.text value ]`
    static member inline text (value: float) = PropHelper.mkAttr "children" [value]
    /// Defines the text content of the element. Alias for `children [ Html.text value ]`
    static member inline text (value: int) = PropHelper.mkAttr "children" [value]
    /// Defines the text content of the element. Alias for `children [ Html.text value ]`
    static member inline text (value: string) = PropHelper.mkAttr "children" [value]

    /// Defines the text content of the element. Alias for `children [ Html.text value ]`
    static member inline text (value: System.Guid) = PropHelper.mkAttr "children" [value.ToString()]

    /// Defines the text content of the element. Alias for `children [ Html.text (sprintf ...) ]`
    static member inline textf fmt = Printf.kprintf prop.text fmt

    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: float) = PropHelper.mkAttr "textLength" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: ICssUnit) = PropHelper.mkAttr "textLength" value
    /// Specifies the width of the space into which the text will draw.
    ///
    /// The user agent will ensure that the text does not extend farther than that distance, using the method or methods
    /// specified by the lengthAdjust attribute.
    static member inline textLength (value: int) = PropHelper.mkAttr "textLength" value

    /// The title global attribute contains text representing advisory information related to the element it belongs to.
    static member inline title (value: string) = PropHelper.mkAttr "title" value

    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (value: float) = PropHelper.mkAttr "to" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (values: seq<float>) = PropHelper.mkAttr "to" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (value: int) = PropHelper.mkAttr "to" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (values: seq<int>) = PropHelper.mkAttr "to" (values |> unbox<seq<string>> |> String.concat " ")
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (value: string) = PropHelper.mkAttr "to" value
    /// Indicates the initial value of the attribute that will be modified during the animation.
    ///
    /// When used with the `to` attribute, the animation will change the modified attribute from
    /// the from value to the to value.
    ///
    /// When used with the `by` attribute, the animation will change the attribute relatively
    /// from the from value by the value specified in by.
    static member inline to' (values: seq<string>) = PropHelper.mkAttr "to" (values |> String.concat " ")

    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transform: ITransformProperty) =
        PropHelper.mkAttr "transform" (unbox<string> transform)
    /// Defines a list of transform definitions that are applied to an element and the element's children.
    static member inline transform (transforms: seq<ITransformProperty>) =
        let unitList = [ "px" ; "deg" ]
        let removeUnits (s : string) =
            List.fold (fun (ins:string) toReplace -> ins.Replace(toReplace,"")) s unitList
        PropHelper.mkAttr "transform" (unbox<seq<string>> transforms |> Seq.map removeUnits |> String.concat " ")

    /// Sets the `type` attribute for the element.
    static member inline type' (value: string) = PropHelper.mkAttr "type" value

    /// Represents the ideal vertical position of the underline.
    ///
    /// The underline position is expressed in the font's coordinate system.
    static member inline underlinePosition (value: float) = PropHelper.mkAttr "underline-position" value
    /// Represents the ideal vertical position of the underline.
    ///
    /// The underline position is expressed in the font's coordinate system.
    static member inline underlinePosition (value: int) = PropHelper.mkAttr "underline-position" value

    /// Represents the ideal thickness of the underline.
    ///
    /// The underline thickness is expressed in the font's coordinate system.
    static member inline underlineThickness (value: float) = PropHelper.mkAttr "underline-thickness" value
    /// Represents the ideal thickness of the underline.
    ///
    /// The underline thickness is expressed in the font's coordinate system.
    static member inline underlineThickness (value: int) = PropHelper.mkAttr "underline-thickness" value

    /// A hash-name reference to a <map> element; that is a '#' followed by the value of a name of a map element.
    static member inline usemap (value: string) = PropHelper.mkAttr "usemap" value

    /// Sets the value of a React controlled component.
    static member inline value (value: bool) = PropHelper.mkAttr "value" value
    /// Sets the value of a React controlled component.
    static member inline value (value: float) = PropHelper.mkAttr "value" value
    /// Sets the value of a React controlled component.
    static member inline value (value: System.Guid) = PropHelper.mkAttr "value" (unbox<string> value)
    /// Sets the value of a React controlled component.
    static member inline value (value: int) = PropHelper.mkAttr "value" value
    /// Sets the value of a React controlled component.
    static member inline value (value: string) = PropHelper.mkAttr "value" value
    /// Sets the value of a React controlled component.
    static member inline value (value: seq<float>) = PropHelper.mkAttr "value" (ResizeArray value)
    /// Sets the value of a React controlled component.
    static member inline value (value: seq<int>) = PropHelper.mkAttr "value" (ResizeArray value)
    /// Sets the value of a React controlled component.
    static member inline value (value: seq<string>) = PropHelper.mkAttr "value" (ResizeArray value)
    /// The value of the element, interpreted as a date
    static member inline value (value: System.DateTime, includeTime: bool) =
        PropHelper.mkAttr "value" (PropHelpers.dateTimeValueFunc (Some value) includeTime)
    /// The value of the element, interpreted as a date
    static member inline value (value: System.DateTime) = prop.value(value, includeTime=false)
    /// The value of the element, interpreted as a date, or empty if there is no value.
    static member inline value (value: System.DateTime option, includeTime: bool) =
        PropHelper.mkAttr "value" (PropHelpers.dateTimeValueFunc value includeTime)

    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: bool) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!value)
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: float) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!value)
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: System.Guid) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!value)
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: int) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!value)
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input box value.
    static member inline valueOrDefault (value: string) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!value)
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: seq<float>) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!(ResizeArray value))
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input value.
    static member inline valueOrDefault (value: seq<int>) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!(ResizeArray value))
    /// `prop.ref` callback that sets the value of an input after DOM element is created.
    /// Can be used instead of `prop.defaultValue` and `prop.value` props to override input box value.
    static member inline valueOrDefault (value: seq<string>) =
        prop.ref (fun e -> if e |> isNull |> not && !!e?value <> !!value then e?value <- !!(ResizeArray value))

    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (value: float) = PropHelper.mkAttr "values" value
    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (values: seq<float>) = PropHelper.mkAttr "values" (values |> unbox<seq<string>> |> String.concat " ")
    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (value: int) = PropHelper.mkAttr "values" value
    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (values: seq<int>) = PropHelper.mkAttr "values" (values |> unbox<seq<string>> |> String.concat " ")
    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (value: string) = PropHelper.mkAttr "values" value
    /// The values attribute has different meanings, depending upon the context where itʼs used,
    /// either it defines a sequence of values used over the course of an animation, or itʼs a
    /// list of numbers for a color matrix, which is interpreted differently depending on the
    /// type of color change to be performed.
    static member inline values (values: seq<string>) = PropHelper.mkAttr "values" (values |> String.concat " ")

    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: float) = PropHelper.mkAttr "width" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: ICssUnit) = PropHelper.mkAttr "width" value
    /// Specifies the width of elements listed here. For all other elements, use the CSS height property.
    ///
    /// HTML: <canvas>, <embed>, <iframe>, <img>, <input>, <object>, <video>
    ///
    /// SVG: <feBlend>, <feColorMatrix>, <feComponentTransfer>, <feComposite>, <feConvolveMatrix>,
    /// <feDiffuseLighting>, <feDisplacementMap>, <feDropShadow>, <feFlood>, <feGaussianBlur>, <feImage>,
    /// <feMerge>, <feMorphology>, <feOffset>, <feSpecularLighting>, <feTile>, <feTurbulence>, <filter>,
    /// <mask>, <pattern>
    static member inline width (value: int) = PropHelper.mkAttr "width" value

    /// SVG attribute to define a x-axis coordinate in the user coordinate system.
    static member inline x (value: float) = PropHelper.mkAttr "x" value
    /// SVG attribute to define a x-axis coordinate in the user coordinate system.
    static member inline x (value: ICssUnit) = PropHelper.mkAttr "x" value
    /// SVG attribute to define a x-axis coordinate in the user coordinate system.
    static member inline x (value: int) = PropHelper.mkAttr "x" value

    /// The x1 attribute is used to specify the first x-coordinate for drawing an SVG element that
    /// requires more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x1 (value: float) = PropHelper.mkAttr "x1" value
    /// The x1 attribute is used to specify the first x-coordinate for drawing an SVG element that
    /// requires more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x1 (value: ICssUnit) = PropHelper.mkAttr "x1" value
    /// The x1 attribute is used to specify the first x-coordinate for drawing an SVG element that
    /// requires more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x1 (value: int) = PropHelper.mkAttr "x1" value

    /// The x2 attribute is used to specify the second x-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x2 (value: float) = PropHelper.mkAttr "x2" value
    /// The x2 attribute is used to specify the second x-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x2 (value: ICssUnit) = PropHelper.mkAttr "x2" value
    /// The x2 attribute is used to specify the second x-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the x attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline x2 (value: int) = PropHelper.mkAttr "x2" value

    /// Specifies the XML Namespace of the document.
    ///
    /// Default value is "http://www.w3.org/1999/xhtml".
    ///
    /// This is required in documents parsed with XML parsers, and optional in text/html documents.
    static member inline xmlns (value: string) = PropHelper.mkAttr "xmlns" value

    /// SVG attribute to define a y-axis coordinate in the user coordinate system.
    static member inline y (value: float) = PropHelper.mkAttr "y" value
    /// SVG attribute to define a y-axis coordinate in the user coordinate system.
    static member inline y (value: ICssUnit) = PropHelper.mkAttr "y" value
    /// SVG attribute to define a y-axis coordinate in the user coordinate system.
    static member inline y (value: int) = PropHelper.mkAttr "y" value

    /// The y1 attribute is used to specify the first y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y1 (value: float) = PropHelper.mkAttr "y1" value
    /// The y1 attribute is used to specify the first y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y1 (value: ICssUnit) = PropHelper.mkAttr "y1" value
    /// The y1 attribute is used to specify the first y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y1 (value: int) = PropHelper.mkAttr "y1" value

    /// The y2 attribute is used to specify the second y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y2 (value: float) = PropHelper.mkAttr "y2" value
    /// The y2 attribute is used to specify the second y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y2 (value: ICssUnit) = PropHelper.mkAttr "y2" value
    /// The y2 attribute is used to specify the second y-coordinate for drawing an SVG element that requires
    /// more than one coordinate. Elements that only need one coordinate use the y attribute instead.
    ///
    /// Two elements are using this attribute: <line>, and <linearGradient>
    static member inline y2 (value: int) = PropHelper.mkAttr "y2" value

    /// Defines the location along the z-axis for a light source in the coordinate system established by the
    /// primitiveUnits attribute on the <filter> element, assuming that, in the initial coordinate system,
    /// the positive z-axis comes out towards the person viewing the content and assuming that one unit along
    /// the z-axis equals one unit in x and y.
    static member inline z (value: float) = PropHelper.mkAttr "z" value
    /// Defines the location along the z-axis for a light source in the coordinate system established by the
    /// primitiveUnits attribute on the <filter> element, assuming that, in the initial coordinate system,
    /// the positive z-axis comes out towards the person viewing the content and assuming that one unit along
    /// the z-axis equals one unit in x and y.
    static member inline z (value: ICssUnit) = PropHelper.mkAttr "z" value
    /// Defines the location along the z-axis for a light source in the coordinate system established by the
    /// primitiveUnits attribute on the <filter> element, assuming that, in the initial coordinate system,
    /// the positive z-axis comes out towards the person viewing the content and assuming that one unit along
    /// the z-axis equals one unit in x and y.
    static member inline z (value: int) = PropHelper.mkAttr "z" value

module prop =
    /// Controls whether or not an animation is cumulative.
    [<Erase>]
    type accumulate =
        /// Specifies that repeat iterations are not cumulative.
        static member inline none = PropHelper.mkAttr "accumulate" "none"
        /// Specifies that each repeat iteration after the first builds upon
        /// the last value of the previous iteration.
        static member inline sum = PropHelper.mkAttr "accumulate" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type additive =
        /// Specifies that the animation will override the underlying value of
        /// the attribute and other lower priority animations.
        static member inline replace = PropHelper.mkAttr "additive" "replace"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline sum = PropHelper.mkAttr "additive" "sum"

    /// Controls whether or not an animation is additive.
    [<Erase>]
    type alignmentBaseline =
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline alphabetic = PropHelper.mkAttr "alignment-baseline" "alphabetic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline baseline = PropHelper.mkAttr "alignment-baseline" "baseline"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline bottom = PropHelper.mkAttr "alignment-baseline" "bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline center = PropHelper.mkAttr "alignment-baseline" "center"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline central = PropHelper.mkAttr "alignment-baseline" "central"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline hanging = PropHelper.mkAttr "alignment-baseline" "hanging"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline ideographic = PropHelper.mkAttr "alignment-baseline" "ideographic"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline mathematical = PropHelper.mkAttr "alignment-baseline" "mathematical"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline middle = PropHelper.mkAttr "alignment-baseline" "middle"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textAfterEdge = PropHelper.mkAttr "alignment-baseline" "text-after-edge"
        /// Uses the dominant baseline choice of the parent. Matches the box’s
        /// corresponding baseline to that of its parent.
        static member inline textBeforeEdge = PropHelper.mkAttr "alignment-baseline" "text-before-edge"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textBottom = PropHelper.mkAttr "alignment-baseline" "text-bottom"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline textTop = PropHelper.mkAttr "alignment-baseline" "text-top"
        /// Specifies that the animation will add to the underlying value of
        /// the attribute and other lower priority animations.
        static member inline top = PropHelper.mkAttr "alignment-baseline" "top"

    /// Specifies a feature policy for the <iframe>.
    [<Erase>]
    type allow =
        /// Controls whether the current document is allowed to gather information about the acceleration of
        /// the device through the Accelerometer interface.
        static member inline accelerometer = PropHelper.mkAttr "allow" "accelerometer"
        /// Controls whether the current document is allowed to gather information about the amount of light
        /// in the environment around the device through the AmbientLightSensor interface.
        static member inline ambientLightSensor = PropHelper.mkAttr "allow" "ambient-light-sensor"
        /// Controls whether the current document is allowed to autoplay media requested through the
        /// HTMLMediaElement interface.
        ///
        /// When this policy is disabled and there were no user gestures, the Promise returned by
        /// HTMLMediaElement.play() will reject with a DOMException. The autoplay attribute on <audio> and
        /// <video> elements will be ignored.
        static member inline autoplay = PropHelper.mkAttr "allow" "autoplay"
        /// Controls whether the use of the Battery Status API is allowed.
        ///
        /// When this policy is disabled, the  Promise returned by Navigator.getBattery() will reject with
        /// a NotAllowedError DOMException.
        static member inline battery = PropHelper.mkAttr "allow" "battery"
        /// Controls whether the current document is allowed to use video input devices.
        ///
        /// When this policy is disabled, the Promise returned by getUserMedia() will reject with a
        /// NotAllowedError DOMException.
        static member inline camera = PropHelper.mkAttr "allow" "camera"
        /// Controls whether or not the current document is permitted to use the getDisplayMedia() method to
        /// capture screen contents.
        ///
        /// When this policy is disabled, the promise returned by getDisplayMedia() will reject with a
        /// NotAllowedError if permission is not obtained to capture the display's contents.
        static member inline displayCapture = PropHelper.mkAttr "allow" "display-capture"
        /// Controls whether the current document is allowed to set document.domain.
        ///
        /// When this policy is disabled, attempting to set document.domain will fail and cause a SecurityError
        /// DOMException to be be thrown.
        static member inline documentDomain = PropHelper.mkAttr "allow" "document-domain"
        /// Controls whether the current document is allowed to use the Encrypted Media Extensions API (EME).
        ///
        /// When this policy is disabled, the Promise returned by Navigator.requestMediaKeySystemAccess() will
        /// reject with a DOMException.
        static member inline encryptedMedia = PropHelper.mkAttr "allow" "encrypted-media"
        /// Controls whether tasks should execute in frames while they're not being rendered (e.g. if an iframe
        /// is hidden or display: none).
        static member inline executionWhileNotRendered = PropHelper.mkAttr "allow" "execution-while-not-rendered"
        /// Controls whether tasks should execute in frames while they're outside of the visible viewport.
        static member inline executionWhileOutOfViewport = PropHelper.mkAttr "allow" "execution-while-out-of-viewport"
        /// Controls whether the current document is allowed to use Element.requestFullScreen().
        ///
        /// When this policy is disabled, the returned Promise rejects with a TypeError DOMException.
        static member inline fullscreen = PropHelper.mkAttr "allow" "fullscreen"
        /// Controls whether the current document is allowed to use the Geolocation Interface.
        ///
        /// When this policy is disabled, calls to getCurrentPosition() and watchPosition() will cause those
        /// functions' callbacks to be invoked with a PositionError code of PERMISSION_DENIED.
        static member inline geolocation = PropHelper.mkAttr "allow" "geolocation"
        /// Controls whether the current document is allowed to gather information about the orientation of the
        /// device through the Gyroscope interface.
        static member inline gyroscope = PropHelper.mkAttr "allow" "gyroscope"
        /// Controls whether the current document is allowed to show layout animations.
        static member inline layoutAnimations = PropHelper.mkAttr "allow" "layout-animations"
        /// Controls whether the current document is allowed to display images in legacy formats.
        static member inline legacyImageFormats = PropHelper.mkAttr "allow" "legacy-image-formats"
        /// Controls whether the current document is allowed to gather information about the orientation of the
        /// device through the Magnetometer interface.
        static member inline magnetometer = PropHelper.mkAttr "allow" "magnetometer"
        /// Controls whether the current document is allowed to use audio input devices.
        ///
        /// When this policy is disabled, the Promise returned by MediaDevices.getUserMedia() will reject
        /// with a NotAllowedError.
        static member inline microphone = PropHelper.mkAttr "allow" "microphone"
        /// Controls whether the current document is allowed to use the Web MIDI API.
        ///
        /// When this policy is disabled, the Promise returned by Navigator.requestMIDIAccess() will reject
        /// with a DOMException.
        static member inline midi = PropHelper.mkAttr "allow" "midi"
        /// Controls the availability of mechanisms that enables the page author to take control over the behavior
        /// of spatial navigation, or to cancel it outright.
        static member inline navigationOverride = PropHelper.mkAttr "allow" "navigation-override"
        /// Controls whether the current document is allowed to download and display large images.
        static member inline oversizedImages = PropHelper.mkAttr "allow" "oversized-images"
        /// Controls whether the current document is allowed to use the Payment Request API.
        ///
        /// When this policy is enabled, the PaymentRequest() constructor will throw a SecurityError DOMException.
        static member inline payment = PropHelper.mkAttr "allow" "payment"
        /// Controls whether the current document is allowed to play a video in a Picture-in-Picture mode via
        /// the corresponding API.
        static member inline pictureInPicture = PropHelper.mkAttr "allow" "picture-in-picture"
        /// Controls whether the current document is allowed to use the Web Authentication API to create, store,
        /// and retreive public-key credentials.
        static member inline publickeyCredentials = PropHelper.mkAttr "allow" "publickey-credentials"
        /// Controls whether the current document is allowed to make synchronous XMLHttpRequest requests.
        static member inline syncXhr = PropHelper.mkAttr "allow" "sync-xhr"
        /// Controls whether the current document is allowed to use the WebUSB API.
        static member inline usb = PropHelper.mkAttr "allow" "usb"
        /// Controls whether the current document is allowed to use Wake Lock API to indicate that
        /// device should not enter power-saving mode.
        static member inline wakeLock = PropHelper.mkAttr "allow" "wake-lock"
        /// Controls whether or not the current document is allowed to use the WebXR Device API to interact
        /// with a WebXR session.
        static member inline xrSpatialTracking = PropHelper.mkAttr "allow" "xr-spatial-tracking"

    /// Indicates whether user input completion suggestions are provided.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-autocomplete
    [<Erase>]
    type ariaAutocomplete =
        /// A list of choices appears and the currently selected suggestion also
        /// appears inline.
        static member inline both = PropHelper.mkAttr "aria-autocomplete" "both"
        /// The system provides text after the caret as a suggestion for how to
        /// complete the field.
        static member inline inlinedAfterCaret = PropHelper.mkAttr "aria-autocomplete" "inline"
        /// A list of choices appears from which the user can choose.
        static member inline list = PropHelper.mkAttr "aria-autocomplete" "list"
        /// No input completion suggestions are provided.
        static member inline none = PropHelper.mkAttr "aria-autocomplete" "none"

    /// Indicates the current "checked" state of checkboxes, radio buttons, and
    /// other widgets. See related `aria-pressed` and `aria-selected`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-checked
    [<Erase>]
    type ariaChecked =
        /// Indicates a mixed mode value for a tri-state checkbox or
        /// `menuitemcheckbox`.
        static member inline mixed = PropHelper.mkAttr "aria-checked" "mixed"

    /// Indicates what functions can be performed when the dragged object is
    /// released on the drop target. This allows assistive technologies to
    /// convey the possible drag options available to users, including whether a
    /// pop-up menu of choices is provided by the application. Typically, drop
    /// effect functions can only be provided once an object has been grabbed
    /// for a drag operation as the drop effect functions available are
    /// dependent on the object being dragged.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-dropeffect
    [<Erase>]
    type ariaDropEffect =
        /// A duplicate of the source object will be dropped into the target.
        static member inline copy = PropHelper.mkAttr "aria-dropeffect" "copy"
        /// A function supported by the drop target is executed, using the drag
        /// source as an input.
        static member inline execute = PropHelper.mkAttr "aria-dropeffect" "execute"
        /// A reference or shortcut to the dragged object will be created in the
        /// target object.
        static member inline link = PropHelper.mkAttr "aria-dropeffect" "link"
        /// The source object will be removed from its current location and
        /// dropped into the target.
        static member inline move = PropHelper.mkAttr "aria-dropeffect" "move"
        /// No operation can be performed; effectively cancels the drag
        /// operation if an attempt is made to drop on this object. Ignored if
        /// combined with any other token value. e.g. 'none copy' is equivalent
        /// to a 'copy' value.
        static member inline none = PropHelper.mkAttr "aria-dropeffect" "none"
        /// There is a popup menu or dialog that allows the user to choose one
        /// of the drag operations (copy, move, link, execute) and any other
        /// drag functionality, such as cancel.
        static member inline popup = PropHelper.mkAttr "aria-dropeffect" "popup"

    /// Indicates the entered value does not conform to the format expected by
    /// the application.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-invalid
    [<Erase>]
    type ariaInvalid =
        /// A grammatical error was detected.
        static member inline grammar = PropHelper.mkAttr "aria-invalid" "grammar"
        /// A spelling error was detected.
        static member inline spelling = PropHelper.mkAttr "aria-invalid" "spelling"

    /// Indicates that an element will be updated, and describes the types of
    /// updates the user agents, assistive technologies, and user can expect
    /// from the live region.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-live
    [<Erase>]
    type ariaLive =
        /// Indicates that updates to the region have the highest priority and
        /// should be presented the user immediately.
        static member inline assertive = PropHelper.mkAttr "aria-live" "assertive"
        /// Indicates that updates to the region should not be presented to the
        /// user unless the used is currently focused on that region.
        static member inline off = PropHelper.mkAttr "aria-live" "off"
        /// Indicates that updates to the region should be presented at the next
        /// graceful opportunity, such as at the end of speaking the current
        /// sentence or when the user pauses typing.
        static member inline polite = PropHelper.mkAttr "aria-live" "polite"

    /// Indicates whether the element and orientation is horizontal or vertical.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-orientation
    [<Erase>]
    type ariaOrientation =
        /// The element is oriented horizontally.
        static member inline horizontal = PropHelper.mkAttr "aria-orientation" "horizontal"
        /// The element is oriented vertically.
        static member inline vertical = PropHelper.mkAttr "aria-orientation" "vertical"

    /// Indicates the current "pressed" state of toggle buttons. See related
    /// `aria-checked` and `aria-selected`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-pressed
    [<Erase>]
    type ariaPressed =
        /// Indicates a mixed mode value for a tri-state toggle button.
        static member inline mixed = PropHelper.mkAttr "aria-pressed" "mixed"

    /// Indicates what user agent change notifications (additions, removals,
    /// etc.) assistive technologies will receive within a live region. See
    /// related `aria-atomic`.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-relevant
    [<Erase>]
    type ariaRelevant =
        /// Element nodes are added to the DOM within the live region.
        static member inline additions = PropHelper.mkAttr "aria-relevant" "additions"
        /// Equivalent to the combination of all values, "additions removals
        /// text".
        static member inline all = PropHelper.mkAttr "aria-relevant" "all"
        /// Text or element nodes within the live region are removed from the
        /// DOM.
        static member inline removals = PropHelper.mkAttr "aria-relevant" "removals"
        /// Text is added to any DOM descendant nodes of the live region.
        static member inline text = PropHelper.mkAttr "aria-relevant" "text"

    /// Indicates if items in a table or grid are sorted in ascending or
    /// descending order.
    ///
    /// https://www.w3.org/WAI/PF/aria-1.1/states_and_properties#aria-sort
    [<Erase>]
    type ariaSort =
        /// Items are sorted in ascending order by this column.
        static member inline ascending = PropHelper.mkAttr "aria-sort" "ascending"
        /// Items are sorted in descending order by this column.
        static member inline descending = PropHelper.mkAttr "aria-sort" "descending"
        /// There is no defined sort applied to the column.
        static member inline none = PropHelper.mkAttr "aria-sort" "none"
        /// A sort algorithm other than ascending or descending has been
        /// applied.
        static member inline other = PropHelper.mkAttr "aria-sort" "other"

    /// This attribute is only used when rel="preload" or rel="prefetch" has been set on the <link> element.
    /// It specifies the type of content being loaded by the <link>, which is necessary for request matching,
    /// application of correct content security policy, and setting of correct Accept request header.
    /// Furthermore, rel="preload" uses this as a signal for request prioritization.
    [<Erase>]
    type as' =
        /// Applies to <audio> elements.
        static member inline audio = PropHelper.mkAttr "as" "audio"
        /// Applies to <iframe> and <frame> elements.
        static member inline document = PropHelper.mkAttr "as" "document"
        /// Applies to <embed> elements.
        static member inline embed = PropHelper.mkAttr "as" "embed"
        /// Applies to fetch and XHR.
        ///
        /// This value also requires <link> to contain the crossorigin attribute.
        static member inline fetch = PropHelper.mkAttr "as" "fetch"
        /// Applies to CSS @font-face.
        static member inline font = PropHelper.mkAttr "as" "font"
        /// Applies to <img> and <picture> elements with srcset or imageset attributes,
        /// SVG <image> elements, and CSS *-image rules.
        static member inline image = PropHelper.mkAttr "as" "image"
        /// Applies to <object> elements.
        static member inline object = PropHelper.mkAttr "as" "object"
        /// Applies to <script> elements, Worker importScripts.
        static member inline script = PropHelper.mkAttr "as" "script"
        /// Applies to <link rel=stylesheet> elements, and CSS @import.
        static member inline style = PropHelper.mkAttr "as" "style"
        /// Applies to <track> elements.
        static member inline track = PropHelper.mkAttr "as" "track"
        /// Applies to <video> elements.
        static member inline video = PropHelper.mkAttr "as" "video"
        /// Applies to Worker and SharedWorker.
        static member inline worker = PropHelper.mkAttr "as" "worker"

    [<Erase>]
    type autoCapitalize =
        /// All letters should default to uppercase
        static member inline characters = PropHelper.mkAttr "autoCapitalize" "characters"
        /// No autocapitalization is applied (all letters default to lowercase)
        static member inline off = PropHelper.mkAttr "autoCapitalize" "off"
        /// The first letter of each sentence defaults to a capital letter; all other letters default to lowercase
        static member inline on' = PropHelper.mkAttr "autoCapitalize" "on"
        /// The first letter of each word defaults to a capital letter; all other letters default to lowercase
        static member inline words = PropHelper.mkAttr "autoCapitalize" "words"

    /// Specifies the interpolation mode for the animation.
    [<Erase>]
    type calcMode =
        /// Specifies that the animation function will jump from one value to the next
        /// without any interpolation.
        static member inline discrete = PropHelper.mkAttr "calcMode" "discrete"
        /// Simple linear interpolation between values is used to calculate the animation
        /// function. Except for <animateMotion>, this is the default value.
        static member inline linear = PropHelper.mkAttr "calcMode" "linear"
        /// Defines interpolation to produce an even pace of change across the animation.
        ///
        /// This is only supported for values that define a linear numeric range, and for
        /// which some notion of "distance" between points can be calculated (e.g. position,
        /// width, height, etc.).
        ///
        /// If paced is specified, any keyTimes or keySplines will be ignored.
        ///
        /// For <animateMotion>, this is the default value.
        static member inline paced = PropHelper.mkAttr "calcMode" "paced"
        /// Interpolates from one value in the values list to the next according to a time
        /// function defined by a cubic Bézier spline.
        ///
        /// The points of the spline are defined in the keyTimes attribute, and the control
        /// points for each interval are defined in the keySplines attribute.
        static member inline spline = PropHelper.mkAttr "calcMode" "spline"

    /// Specifies that new files should be captured by the device
    [<Erase>]
    type capture =
        /// The user-facing camera and/or microphone should be used.
        static member inline user = PropHelper.mkAttr "capture" "user"
        ///
        /// The outward-facing camera and/or microphone should be used
        static member inline environment = PropHelper.mkAttr "capture" "environment"

    [<Erase>]
    type charset =
        static member inline utf8 = PropHelper.mkAttr "charSet" "UTF-8"

    /// Indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipPath =
        /// Indicates that all coordinates inside the <clipPath> element refer to the user
        /// coordinate system as defined when the clipping path was created.
        static member inline userSpaceOnUse = PropHelper.mkAttr "clipPath" "userSpaceOnUse"
        /// Indicates that all coordinates inside the <clipPath> element are relative to
        /// the bounding box of the element the clipping path is applied to.
        ///
        /// It means that the origin of the coordinate system is the top left corner of the
        /// object bounding box and the width and height of the object bounding box are
        /// considered to have a length of 1 unit value.
        static member inline objectBoundingBox = PropHelper.mkAttr "clipPath" "objectBoundingBox"

    /// Indicates which coordinate system to use for the contents of the <clipPath> element.
    [<Erase>]
    type clipRule =
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction and counting the number of path segments
        /// from the given shape that the ray crosses.
        ///
        /// If this number is odd, the point is inside; if even, the point is outside.
        static member inline evenodd = PropHelper.mkAttr "clip-rule" "evenodd"
        static member inline inheritFromParent = PropHelper.mkAttr "clip-rule" "inherit"
        /// Determines the "insideness" of a point in the shape by drawing a ray from that
        /// point to infinity in any direction, and then examining the places where a
        /// segment of the shape crosses the ray.
        static member inline nonzero = PropHelper.mkAttr "clip-rule" "nonzero"

    /// Specifies the color space for gradient interpolations, color animations, and
    /// alpha compositing.
    [<Erase>]
    type colorInterpolation =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = PropHelper.mkAttr "color-interpolation" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = PropHelper.mkAttr "color-interpolation" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = PropHelper.mkAttr "color-interpolation" "sRGB"

    /// Specifies the color space for imaging operations performed via filter effects.
    [<Erase>]
    type colorInterpolationFilters =
        /// Indicates that the user agent can choose either the sRGB or linearRGB spaces
        /// for color interpolation. This option indicates that the author doesn't require
        /// that color interpolation occur in a particular color space.
        static member inline auto = PropHelper.mkAttr "color-interpolation-filters" "auto"
        /// Indicates that color interpolation should occur in the linearized RGB color
        /// space as described in the sRGB specification.
        static member inline linearRGB = PropHelper.mkAttr "color-interpolation-filters" "linearRGB"
        /// Indicates that color interpolation should occur in the sRGB color space.
        static member inline sRGB = PropHelper.mkAttr "color-interpolation-filters" "sRGB"

    /// A set of values specifying the coordinates of the hot-spot region.
    ///
    /// The number and meaning of the values depend upon the value specified for the shape attribute
    [<Erase>]
    type coords =
        static member inline rect (left: int, top: int, right: int, bottom: int) =
            PropHelper.mkAttr "coords"
                ((unbox<string> left) + "," +
                 (unbox<string> top) + "," +
                 (unbox<string> right) + "," +
                 (unbox<string> bottom))
        static member inline circle (x: int, y: int, r: int) =
            PropHelper.mkAttr "coords"
                ((unbox<string> x) + "," +
                 (unbox<string> y) + "," +
                 (unbox<string> r))
        static member inline poly (x1: int, y1: int, x2: int, y2: int, x3: int, y3: int) =
            PropHelper.mkAttr "coords"
                ((unbox<string> x1) + "," +
                 (unbox<string> y1) + "," +
                 (unbox<string> x2) + "," +
                 (unbox<string> y2) + "," +
                 (unbox<string> x3) + "," +
                 (unbox<string> y3))

    /// Indicates whether CORS must be used when fetching the resource.
    [<Erase>]
    type crossOrigin =
        /// A cross-origin request (i.e. with an Origin HTTP header) is performed, but no credential
        /// is sent (i.e. no cookie, X.509 certificate, or HTTP Basic authentication). If the server
        /// does not give credentials to the origin site (by not setting the Access-Control-Allow-Origin
        /// HTTP header) the resource will be tainted and its usage restricted.
        static member inline anonymous = PropHelper.mkAttr "crossOrigin" "anonymous"
        /// A cross-origin request (i.e. with an Origin HTTP header) is performed along with a credential
        /// sent (i.e. a cookie, certificate, and/or HTTP Basic authentication is performed). If the server
        /// does not give credentials to the origin site (through Access-Control-Allow-Credentials HTTP
        /// header), the resource will be tainted and its usage restricted.
        static member inline useCredentials = PropHelper.mkAttr "crossOrigin" "use-credentials"

    /// Indicates the directionality of the element's text.
    [<Erase>]
    type dir =
        /// Lets the user agent decide.
        static member inline auto = PropHelper.mkAttr "dir" "auto"
        /// Left to right - for languages that are written from left to right.
        static member inline ltr = PropHelper.mkAttr "dir" "ltr"
        /// Right to left - for languages that are written from right to left.
        static member inline rtl = PropHelper.mkAttr "dir" "rtl"

    /// The `dominantBaseline` attribute specifies the dominant baseline, which is the baseline used to align the box’s text
    /// and inline-level contents. It also indicates the default alignment baseline of any boxes participating in baseline
    /// alignment in the box’s alignment context. It is used to determine or re-determine a scaled-baseline-table. A
    /// scaled-baseline-table is a compound value with three components: a baseline-identifier for the dominant-baseline, a
    /// baseline-table and a baseline-table font-size. Some values of the property re-determine all three values; other only
    /// re-establish the baseline-table font-size. When the initial value, auto, would give an undesired result, this property
    /// can be used to explicitly set the desired scaled-baseline-table.
    /// If there is no baseline table in the nominal font or if the baseline table lacks an entry for the desired baseline,
    /// then the browser may use heuristics to determine the position of the desired baseline.
    [<Erase>]
    type dominantBaseline =
        /// The baseline-identifier for the dominant-baseline is set to be alphabetic, the derived baseline-table is constructed
        /// using the alphabetic baseline-table in the font, and the baseline-table font-size is changed to the value of the
        /// font-size attribute on this element.
        static member inline alphabetic = PropHelper.mkAttr "dominantBaseline" "alphabetic"
        /// If this property occurs on a <text> element, then the computed value depends on the value of the writing-mode attribute.
        ///
        /// If the writing-mode is horizontal, then the value of the dominant-baseline component is alphabetic, else if the writing-mode
        /// is vertical, then the value of the dominant-baseline component is central.
        ///
        /// If this property occurs on a <tspan>, <tref>,
        /// <altGlyph> or <textPath> element, then the dominant-baseline and the baseline-table components remain the same as those of
        /// the parent text content element.
        ///
        /// If the computed baseline-shift value actually shifts the baseline, then the baseline-table
        /// font-size component is set to the value of the font-size attribute on the element on which the dominant-baseline attribute
        /// occurs, otherwise the baseline-table font-size remains the same as that of the element.
        ///
        /// If there is no parent text content
        /// element, the scaled-baseline-table value is constructed as above for <text> elements.
        static member inline auto = PropHelper.mkAttr "dominantBaseline" "auto"
        /// The baseline-identifier for the dominant-baseline is set to be central. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order of
        /// baseline-table names: ideographic, alphabetic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline central = PropHelper.mkAttr "dominantBaseline" "central"
        /// The baseline-identifier for the dominant-baseline is set to be hanging, the derived baseline-table is constructed using the
        /// hanging baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size attribute on
        /// this element.
        static member inline hanging = PropHelper.mkAttr "dominantBaseline" "hanging"
        /// The baseline-identifier for the dominant-baseline is set to be ideographic, the derived baseline-table is constructed using
        /// the ideographic baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline ideographic = PropHelper.mkAttr "dominantBaseline" "ideographic"
        /// The baseline-identifier for the dominant-baseline is set to be mathematical, the derived baseline-table is constructed using
        /// the mathematical baseline-table in the font, and the baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline mathematical = PropHelper.mkAttr "dominantBaseline" "mathematical"
        /// The baseline-identifier for the dominant-baseline is set to be middle. The derived baseline-table is constructed from the
        /// defined baselines in a baseline-table in the font. That font baseline-table is chosen using the following priority order
        /// of baseline-table names: alphabetic, ideographic, hanging, mathematical. The baseline-table font-size is changed to the value
        /// of the font-size attribute on this element.
        static member inline middle = PropHelper.mkAttr "dominantBaseline" "middle"
        /// The baseline-identifier for the dominant-baseline is set to be text-after-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which font baseline-table to use from the
        /// baseline-tables in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size
        /// attribute on this element.
        static member inline textAfterEdge = PropHelper.mkAttr "dominantBaseline" "text-after-edge"
        /// The baseline-identifier for the dominant-baseline is set to be text-before-edge. The derived baseline-table is constructed
        /// from the defined baselines in a baseline-table in the font. The choice of which baseline-table to use from the baseline-tables
        /// in the font is browser dependent. The baseline-table font-size is changed to the value of the font-size attribute on this element.
        static member inline textBeforeEdge = PropHelper.mkAttr "dominantBaseline" "text-before-edge"
        /// This value uses the top of the em box as the baseline.
        static member inline textTop = PropHelper.mkAttr "dominantBaseline" "text-top"

    /// Indicates the simple duration of an animation.
    [<Erase>]
    type dur =
        /// This value specifies the length of the simple duration.
        static member inline clockValue (duration: System.TimeSpan) =
            PropHelpers.createClockValue(duration)
            |> PropHelper.mkAttr "dur"
        /// This value specifies the simple duration as indefinite.
        static member inline indefinite = PropHelper.mkAttr "dur" "indefinite"
        /// This value specifies the simple duration as the intrinsic media duration.
        ///
        /// This is only valid for elements that define media.
        static member inline media = PropHelper.mkAttr "dur" "media"

    /// Determines how to extend the input image as necessary with color values so
    /// that the matrix operations can be applied when the kernel is positioned at
    /// or near the edge of the input image.
    [<Erase>]
    type edgeMode =
        /// Indicates that the input image is extended along each of its borders as
        /// necessary by duplicating the color values at the given edge of the input image.
        static member inline duplicate = PropHelper.mkAttr "edgeMode" "duplicate"
        /// Indicates that the input image is extended with pixel values of zero for
        /// R, G, B and A.
        static member inline none = PropHelper.mkAttr "edgeMode" "none"
        /// Indicates that the input image is extended by taking the color values
        /// from the opposite edge of the image.
        static member inline wrap = PropHelper.mkAttr "edgeMode" "wrap"

    /// Defines the final state of the SVG animation.
    [<Erase>]
    type fill =
        /// Keep the state of the last animation frame.
        static member inline freeze = PropHelper.mkAttr "fill" "freeze"
        /// Keep the state of the first animation frame.
        static member inline remove = PropHelper.mkAttr "fill" "remove"

    /// Defines the coordinate system for the attributes x, y, width and height in SVG filter elements.
    [<Erase>]
    type filterUnits =
        /// x, y, width and height represent values in the current coordinate system that results from
        /// taking the current user coordinate system in place at the time when the <filter> element is
        /// referenced (i.e., the user coordinate system for the element referencing the <filter> element
        /// via a filter attribute).
        static member inline userSpaceOnUse = PropHelper.mkAttr "filterUnits" "userSpaceOnUse"
        /// x, y, width and height represent fractions or percentages of the bounding box on the referencing
        /// element.
        static member inline objectBoundingBox = PropHelper.mkAttr "filterUnits" "objectBoundingBox"

    /// Defines the coordinate system used for attributes specified on SVG gradient elements.
    [<Erase>]
    type gradientUnits =
        /// Indicates that the attributes represent values in the coordinate system that results from
        /// taking the current user coordinate system in place at the time when the gradient element
        /// is referenced (i.e., the user coordinate system for the element referencing the gradient
        /// element via a fill or stroke property) and then applying the transform specified by
        /// attribute gradientTransform.
        ///
        /// Percentages represent values relative to the current SVG viewport.
        static member inline userSpaceOnUse = PropHelper.mkAttr "gradientUnits" "userSpaceOnUse"
        /// Indicates that the user coordinate system for the attributes is established using the
        /// bounding box of the element to which the gradient is applied and then applying the
        /// transform specified by attribute gradientTransform.
        ///
        /// Percentages represent values relative to the bounding box for the object.
        static member inline objectBoundingBox = PropHelper.mkAttr "gradientUnits" "objectBoundingBox"

    /// Defines a pragma directive.
    [<Erase>]
    type httpEquiv =
        /// Allows page authors to define a content policy for the current page.
        ///
        /// Content policies mostly specify allowed server origins and script endpoints which help guard against cross-site
        /// scripting attacks.
        static member inline contentSecurityPolicy = PropHelper.mkAttr "httpEquiv" "content-security-policy"
        /// If specified, the content attribute must have the value "text/html; charset=utf-8".
        ///
        /// Note: Can only be used in documents served with a text/html MIME type — not in documents served with an XML MIME type.
        static member inline contentType = PropHelper.mkAttr "httpEquiv" "content-type"
        /// Sets the name of the default CSS style sheet set.
        static member inline defaultStyle = PropHelper.mkAttr "httpEquiv" "default-style"
        /// This instruction specifies:
        ///
        /// The number of seconds until the page should be reloaded - only if the content attribute contains a positive integer.
        ///
        /// The number of seconds until the page should redirect to another - only if the content attribute contains a positive integer followed by the string ';url=', and a valid URL.
        static member inline refresh = PropHelper.mkAttr "httpEquiv" "refresh"
        /// If specified, the content attribute must have the value "IE=edge". User agents are required to ignore this pragma.
        static member inline xUaCompatible = PropHelper.mkAttr "httpEquiv" "x-ua-compatible"

    /// Identifies input for the given filter primitive.
    [<Erase>]
    type in' =
        /// Represents an image snapshot of the SVG document under the filter region at the time that the
        /// <filter> element was invoked, except only the alpha channel is used.
        static member inline backgroundAlpha = PropHelper.mkAttr "in" "BackgroundAlpha"
        /// Represents an image snapshot of the SVG document under the filter region at the time that the
        /// <filter> element was invoked.
        static member inline backgroundImage = PropHelper.mkAttr "in" "BackgroundImage"
        /// An assigned name for the filter primitive.
        ///
        /// If supplied, then graphics that result from processing this filter primitive can be referenced
        /// by an in attribute on a subsequent filter primitive within the same filter element.
        static member inline custom (name: string) = PropHelper.mkAttr "in" name
        /// Represents the value of the fill property on the target element for the filter effect.
        ///
        /// In many cases, the FillPaint is opaque everywhere, but that might not be the case if a shape is
        /// painted with a gradient or pattern which itself includes transparent or semi-transparent parts.
        static member inline fillPaint = PropHelper.mkAttr "in" "FillPaint"
        /// Represents the graphics elements that were the original input into the <filter> element, except
        /// that only the alpha channel is used.
        static member inline sourceAlpha = PropHelper.mkAttr "in" "SourceAlpha"
        /// Represents the graphics elements that were the original input into the <filter> element.
        static member inline sourceGraphic = PropHelper.mkAttr "in" "SourceGraphic"
        /// Represents the value of the stroke property on the target element for the filter effect.
        ///
        /// In many cases, the StrokePaint is opaque everywhere, but that might not be the case if a shape
        /// is painted with a gradient or pattern which itself includes transparent or semi-transparent parts.
        static member inline strokePaint = PropHelper.mkAttr "in" "StrokePaint"

    /// Identifies the second input for the given filter primitive.
    ///
    /// It works exactly like the in attribute.
    [<Erase>]
    type in2 =
        /// Represents an image snapshot of the SVG document under the filter region at the time that the
        /// <filter> element was invoked, except only the alpha channel is used.
        static member inline backgroundAlpha = PropHelper.mkAttr "in2" "BackgroundAlpha"
        /// Represents an image snapshot of the SVG document under the filter region at the time that the
        /// <filter> element was invoked.
        static member inline backgroundImage = PropHelper.mkAttr "in2" "BackgroundImage"
        /// An assigned name for the filter primitive.
        ///
        /// If supplied, then graphics that result from processing this filter primitive can be referenced
        /// by an in attribute on a subsequent filter primitive within the same filter element.
        static member inline custom (name: string) = PropHelper.mkAttr "in2" name
        /// Represents the value of the fill property on the target element for the filter effect.
        ///
        /// In many cases, the FillPaint is opaque everywhere, but that might not be the case if a shape is
        /// painted with a gradient or pattern which itself includes transparent or semi-transparent parts.
        static member inline fillPaint = PropHelper.mkAttr "in2" "FillPaint"
        /// Represents the graphics elements that were the original input into the <filter> element, except
        /// that only the alpha channel is used.
        static member inline sourceAlpha = PropHelper.mkAttr "in2" "SourceAlpha"
        /// Represents the graphics elements that were the original input into the <filter> element.
        static member inline sourceGraphic = PropHelper.mkAttr "in2" "SourceGraphic"
        /// Represents the value of the stroke property on the target element for the filter effect.
        ///
        /// In many cases, the StrokePaint is opaque everywhere, but that might not be the case if a shape
        /// is painted with a gradient or pattern which itself includes transparent or semi-transparent parts.
        static member inline strokePaint = PropHelper.mkAttr "in2" "StrokePaint"

    /// Provides a hint to browsers as to the type of virtual keyboard configuration to use when editing this element or its contents.
    [<Erase>]
    type inputMode =
        static member inline decimal = PropHelper.mkAttr "inputMode" "decimal"
        static member inline email = PropHelper.mkAttr "inputMode" "email"
        static member inline none = PropHelper.mkAttr "inputMode" "none"
        static member inline numeric = PropHelper.mkAttr "inputMode" "numeric"
        static member inline search = PropHelper.mkAttr "inputMode" "search"
        static member inline tel = PropHelper.mkAttr "inputMode" "tel"
        static member inline url = PropHelper.mkAttr "inputMode" "url"

    /// How the text track is meant to be used.
    [<Erase>]
    type kind =
        /// Subtitles provide translation of content that cannot be understood by the viewer. For example dialogue
        /// or text that is not English in an English language film.
        ///
        /// Subtitles may contain additional content, usually extra background information. For example the text
        /// at the beginning of the Star Wars films, or the date, time, and location of a scene.
        static member inline subtitles = PropHelper.mkAttr "kind" "subtitles"
        /// Closed captions provide a transcription and possibly a translation of audio.
        ///
        /// It may include important non-verbal information such as music cues or sound effects.
        /// It may indicate the cue's source (e.g. music, text, character).
        ///
        /// Suitable for users who are deaf or when the sound is muted.
        static member inline captions = PropHelper.mkAttr "kind" "captions"
        /// Textual description of the video content.
        ///
        /// Suitable for users who are blind or where the video cannot be seen.
        static member inline descriptions = PropHelper.mkAttr "kind" "descriptions"
        /// Chapter titles are intended to be used when the user is navigating the media resource.
        static member inline chapters = PropHelper.mkAttr "kind" "chapters"
        /// Tracks used by scripts. Not visible to the user.
        static member inline metadata = PropHelper.mkAttr "kind" "metadata"

    /// Controls how the text is stretched into the length defined by the textLength attribute.
    [<Erase>]
    type lengthAdjust =
        static member inline spacing = PropHelper.mkAttr "lengthAdjust" "spacing"
        static member inline spacingAndGlyphs = PropHelper.mkAttr "lengthAdjust" "spacingAndGlyphs"

    /// Defines the coordinate system for the markerWidth and markerUnits attributes
    /// and the contents of the <marker>.
    [<Erase>]
    type markerUnits =
        /// Specifies that the markerWidth and markerUnits attributes and the contents of the <marker> element represent
        /// values in a coordinate system which has a single unit equal the size in user units of the current stroke width
        /// (see the stroke-width attribute) in place for the graphic object referencing the marker.
        static member inline strokeWidth = PropHelper.mkAttr "markerUnits" "strokeWidth"
        /// Specifies that the markerWidth and markerUnits attributes and the contents of the <marker> element represent
        /// values in the current user coordinate system in place for the graphic object referencing the marker (i.e.,
        /// the user coordinate system for the element referencing the <marker> element via a marker, marker-start,
        /// marker-mid, or marker-end property).
        static member inline userSpaceOnUse = PropHelper.mkAttr "markerUnits" "userSpaceOnUse"

    /// Indicates which coordinate system to use for the contents of the <mask> element.
    [<Erase>]
    type maskContentUnits =
        /// Indicates that all coordinates inside the <mask> element are relative to the bounding box of the element the
        /// mask is applied to.
        ///
        /// A bounding box could be considered the same as if the content of the <mask> were bound to a "0 0 1 1" viewbox.
        static member inline objectBoundingBox = PropHelper.mkAttr "maskContentUnits" "strokeWidth"
        /// Indicates that all coordinates inside the <mask> element refer to the user coordinate system as defined
        /// when the mask was created.
        static member inline userSpaceOnUse = PropHelper.mkAttr "maskContentUnits" "userSpaceOnUse"

    /// Indicates which coordinate system to use for the geometry properties of the <mask> element.
    [<Erase>]
    type maskUnits =
        /// Indicates that all coordinates for the geometry attributes represent fractions or percentages of the bounding box
        /// of the element to which the mask is applied.
        ///
        /// A bounding box could be considered the same as if the content of the <mask> were bound to a "0 0 1 1" viewbox.
        static member inline objectBoundingBox = PropHelper.mkAttr "maskUnits" "strokeWidth"
        /// Indicates that all coordinates for the geometry attributes refer to the user coordinate system as defined
        /// when the mask was created.
        static member inline userSpaceOnUse = PropHelper.mkAttr "maskUnits" "userSpaceOnUse"

    /// Defines the blending mode on the <feBlend> filter primitive.
    [<Erase>]
    type mode =
        /// The final color has the hue and saturation of the top color, while using the luminosity of the
        /// bottom color.
        ///
        /// The effect preserves gray levels and can be used to colorize the foreground.
        static member inline color = PropHelper.mkAttr "mode" "color"
        /// The final color is the result of inverting the bottom color, dividing the value by the top
        /// color, and inverting that value.
        ///
        /// A white foreground leads to no change. A foreground with the inverse color of the backdrop
        /// leads to a black final image.
        ///
        /// This blend mode is similar to multiply, but the foreground need only be as dark as the inverse
        /// of the backdrop to make the final image black.
        static member inline colorBurn = PropHelper.mkAttr "mode" "color-burn"
        /// The final color is the result of dividing the bottom color by the inverse of the top color.
        ///
        /// A black foreground leads to no change. A foreground with the inverse color of the backdrop
        /// leads to a fully lit color.
        ///
        /// This blend mode is similar to screen, but the foreground need only be as light as the inverse
        /// of the backdrop to create a fully lit color.
        static member inline colorDodge = PropHelper.mkAttr "mode" "color-dodge"
        /// The final color is composed of the darkest values of each color channel.
        static member inline darken = PropHelper.mkAttr "mode" "darken"
        /// The final color is the result of subtracting the darker of the two colors from the lighter
        /// one.
        ///
        /// A black layer has no effect, while a white layer inverts the other layer's color.
        static member inline difference = PropHelper.mkAttr "mode" "difference"
        /// The final color is similar to difference, but with less contrast.
        ///
        /// As with difference, a black layer has no effect, while a white layer inverts the other
        /// layer's color.
        static member inline exclusion = PropHelper.mkAttr "mode" "exclusion"
        /// The final color is the result of multiply if the top color is darker, or screen if the top
        /// color is lighter.
        ///
        /// This blend mode is equivalent to overlay but with the layers swapped.
        ///
        /// The effect is similar to shining a harsh spotlight on the backdrop.
        static member inline hardLight = PropHelper.mkAttr "mode" "hard-light"
        /// The final color has the hue of the top color, while using the saturation and luminosity of the
        /// bottom color.
        static member inline hue = PropHelper.mkAttr "mode" "hue"
        /// The final color is composed of the lightest values of each color channel.
        static member inline lighten = PropHelper.mkAttr "mode" "lighten"
        /// The final color has the luminosity of the top color, while using the hue and saturation of the
        /// bottom color.
        ///
        /// This blend mode is equivalent to color, but with the layers swapped.
        static member inline luminosity = PropHelper.mkAttr "mode" "luminosity"
        /// The final color is the result of multiplying the top and bottom colors.
        ///
        /// A black layer leads to a black final layer, and a white layer leads to no change.
        ///
        /// The effect is like two images printed on transparent film overlapping.
        static member inline multiply = PropHelper.mkAttr "mode" "multiply"
        /// The final color is the top color, regardless of what the bottom color is.
        ///
        /// The effect is like two opaque pieces of paper overlapping.
        static member inline normal = PropHelper.mkAttr "mode" "normal"
        /// The final color is the result of multiply if the bottom color is darker, or screen if the
        /// bottom color is lighter.
        ///
        /// This blend mode is equivalent to hard-light but with the layers swapped.
        static member inline overlay = PropHelper.mkAttr "mode" "overlay"
        /// The final color has the saturation of the top color, while using the hue and luminosity of the
        /// bottom color.
        ///
        /// A pure gray backdrop, having no saturation, will have no effect.
        static member inline saturation = PropHelper.mkAttr "mode" "saturation"
        /// The final color is the result of inverting the colors, multiplying them, and inverting
        /// that value.
        ///
        /// A black layer leads to no change, and a white layer leads to a white final layer.
        ///
        /// The effect is like two images shone onto a projection screen.
        static member inline screen = PropHelper.mkAttr "mode" "screen"
        /// The final color is similar to hard-light, but softer.
        ///
        /// This blend mode behaves similar to hard-light.
        ///
        /// The effect is similar to shining a diffused spotlight on the backdrop.
        static member inline softLight = PropHelper.mkAttr "mode" "soft-light"

    /// Defines the blending mode on the <feBlend> filter primitive.
    [<Erase>]
    type operator =
        /// This value indicates that the source graphic defined in the in attribute and the
        /// destination graphic defined in the in2 attribute are combined using the following
        /// formula:
        ///
        /// result = k1*i1*i2 + k2*i1 + k3*i2 + k4
        ///
        /// where:
        ///
        /// i1 and i2 indicate the corresponding pixel channel values of the input image, which
        /// map to in and in2 respectively, and k1,k2,k3,and k4 indicate the values of the
        /// attributes with the same name.
        ///
        /// Used with <feComposite>
        static member inline arithmetic = PropHelper.mkAttr "operator" "arithmetic"
        /// Indicates that the parts of the source graphic defined in the in attribute, which overlap
        /// the destination graphic defined in the in2 attribute, replace the destination graphic.
        ///
        /// The parts of the destination graphic that do not overlap with the source graphic stay untouched.
        ///
        /// Used with <feComposite>
        static member inline atop = PropHelper.mkAttr "operator" "atop"
        /// Fattens the source graphic defined in the in attribute.
        ///
        /// Used with <feMorphology>
        static member inline dilate = PropHelper.mkAttr "operator" "dilate"
        /// Thins the source graphic defined in the in attribute.
        ///
        /// Used with <feMorphology>
        static member inline erode = PropHelper.mkAttr "operator" "erode"
        /// Indicates that the parts of the source graphic defined in the in attribute that overlap the
        /// destination graphic defined in the in2 attribute, replace the destination graphic.
        ///
        /// Used with <feComposite>
        static member inline in' = PropHelper.mkAttr "operator" "in"
        /// Indicates that the sum of the source graphic defined in the in attribute and the destination
        /// graphic defined in the in2 attribute is displayed.
        ///
        /// Used with <feComposite>
        static member inline lighter = PropHelper.mkAttr "operator" "lighter"
        /// Indicates that the parts of the source graphic defined in the in attribute that fall outside
        /// the destination graphic defined in the in2 attribute, are displayed.
        ///
        /// Used with <feComposite>
        static member inline out = PropHelper.mkAttr "operator" "out"
        /// Indicates that the source graphic defined in the in attribute is placed over the destination
        /// graphic defined in the in2 attribute.
        ///
        /// Used with <feComposite>
        static member inline over = PropHelper.mkAttr "operator" "over"
        /// Indicates that the non-overlapping regions of the source graphic defined in the in attribute
        /// and the destination graphic defined in the in2 attribute are combined.
        ///
        /// Used with <feComposite>
        static member inline xor = PropHelper.mkAttr "operator" "xor"

    /// Indicates which coordinate system to use for the contents of the <pattern> element.
    [<Erase>]
    type patternContentUnits =
        /// Indicates that all coordinates inside the <pattern> element are relative to the bounding box of the element
        /// the pattern is applied to.
        ///
        /// A bounding box could be considered the same as if the content of the <pattern> were bound to a "0 0 1 1"
        /// viewbox for a pattern tile of width and height of 100%.
        static member inline objectBoundingBox = PropHelper.mkAttr "patternContentUnits" "objectBoundingBox"
        /// Indicates that all coordinates inside the <pattern> element refer to the user coordinate system as defined
        /// when the pattern tile was created.
        static member inline userSpaceOnUse = PropHelper.mkAttr "patternContentUnits" "userSpaceOnUse"

    /// Indicates which coordinate system to use for the geometry properties of the <pattern> element.
    [<Erase>]
    type patternUnits =
        /// Indicates that all coordinates for the geometry properties represent fractions or percentages of the bounding
        /// box of the element to which the mask is applied.
        ///
        /// A bounding box could be considered the same as if the content of the <mask> were bound to a "0 0 1 1" viewbox.
        static member inline objectBoundingBox = PropHelper.mkAttr "patternUnits" "objectBoundingBox"
        /// Indicates that all coordinates for the geometry properties refer to the user coordinate system as defined
        /// when the pattern was applied.
        static member inline userSpaceOnUse = PropHelper.mkAttr "patternUnits" "userSpaceOnUse"

    /// A global attribute that turns an element into a popover element.
    [<Erase>]
    type popover =
        /// Auto popovers can be hidden by clicking outside it or pressing the Esc key.
        static member inline auto = PropHelper.mkAttr "popover" "auto"
        /// Hint popovers do not close auto popovers when they are displayed, but will close other hint popovers.
        static member inline hint = PropHelper.mkAttr "popover" "hint"
        /// Manual popovers must be displayed and closed using declarative show/hide/toggle buttons or JavaScript.
        static member inline manual = PropHelper.mkAttr "popover" "manual"

    /// Specifies the action to be performed on the popover element being controlled by a control <button> or <input>.
    [<Erase>]
    type popoverTargetAction =
        /// The button will hide a shown popover. If you try to hide an already hidden popover, no action will be taken.
        static member inline hide = PropHelper.mkAttr "popoverTargetAction" "hide"
        /// The button will show a hidden popover. If you try to show an already showing popover, no action will be taken.
        static member inline show = PropHelper.mkAttr "popoverTargetAction" "show"
        ///The button will toggle a popover between showing and hidden.
        static member inline toggle = PropHelper.mkAttr "popoverTargetAction" "toggle"

    /// Provide a hint to the browser about what the author thinks will lead to the best user experience with regards
    /// to what content is loaded before the video is played.
    [<Erase>]
    type preload =
        /// Indicates that the whole video file can be downloaded, even if the user is not expected to use it.
        static member inline auto = PropHelper.mkAttr "preload" "auto"
        /// Indicates that only video metadata (e.g. length) is fetched.
        static member inline metadata = PropHelper.mkAttr "preload" "metadata"
        /// Indicates that the video should not be preloaded.
        static member inline none = PropHelper.mkAttr "preload" "none"

    [<Erase>]
    type preserveAspectRatio =
        /// Do not force uniform scaling.
        ///
        /// Scale the graphic content of the given element non-uniformly if necessary such that the element's
        /// bounding box exactly matches the viewport rectangle. Note that if <align> is none, then the optional
        /// <meetOrSlice> value is ignored.
        static member inline none = PropHelper.mkAttr "preserveAspectRatio" "none"

    [<Erase;RequireQualifiedAccess>]
    module preserveAspectRatio =
        /// Force uniform scaling.
        ///
        /// Align the <min-x> of the element's viewBox with the smallest X value of the viewport.
        ///
        /// Align the <min-y> of the element's viewBox with the smallest Y value of the viewport.
        [<Erase>]
        type xMinYMin =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMinYMin meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMinYMin slice"

        /// Force uniform scaling.
        ///
        /// Align the midpoint X value of the element's viewBox with the midpoint X value of the viewport.
        ///
        /// Align the <min-y> of the element's viewBox with the smallest Y value of the viewport.
        [<Erase>]
        type xMidYMin =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMidYMin meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMidYMin slice"

        /// Force uniform scaling.
        ///
        /// Align the <min-x>+<width> of the element's viewBox with the maximum X value of the viewport.
        ///
        /// Align the <min-y> of the element's viewBox with the smallest Y value of the viewport.
        [<Erase>]
        type xMaxYMin =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMin meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMin slice"

        /// Force uniform scaling.
        ///
        /// Align the <min-x> of the element's viewBox with the smallest X value of the viewport.
        ///
        /// Align the midpoint Y value of the element's viewBox with the midpoint Y value of the viewport.
        [<Erase>]
        type xMinYMid =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMinYMid meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMinYMid slice"

        /// Force uniform scaling.
        ///
        /// Align the midpoint X value of the element's viewBox with the midpoint X value of the viewport.
        ///
        /// Align the midpoint Y value of the element's viewBox with the midpoint Y value of the viewport.
        [<Erase>]
        type xMidYMid =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMidYMid meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMidYMid slice"

        /// Force uniform scaling.
        ///
        /// Align the <min-x>+<width> of the element's viewBox with the maximum X value of the viewport.
        ///
        /// Align the midpoint Y value of the element's viewBox with the midpoint Y value of the viewport.
        [<Erase>]
        type xMaxYMid =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMid meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMid slice"

        /// Force uniform scaling.
        ///
        /// Align the <min-x> of the element's viewBox with the smallest X value of the viewport.
        ///
        /// Align the <min-y>+<height> of the element's viewBox with the maximum Y value of the viewport.
        [<Erase>]
        type xMinYMax =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMinYMax meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMinYMax slice"

        /// Force uniform scaling.
        ///
        /// Align the midpoint X value of the element's viewBox with the midpoint X value of the viewport.
        ///
        /// Align the <min-y>+<height> of the element's viewBox with the maximum Y value of the viewport.
        [<Erase>]
        type xMidYMax =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMidYMax meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMidYMax slice"

        /// Force uniform scaling.
        ///
        /// Align the <min-x>+<width> of the element's viewBox with the maximum X value of the viewport.
        ///
        /// Align the <min-y>+<height> of the element's viewBox with the maximum Y value of the viewport.
        [<Erase>]
        type xMaxYMax =
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewBox is visible within the viewport.
            ///
            /// The viewBox is scaled up as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the graphic does not match the viewport, some of
            /// the viewport will extend beyond the bounds of the viewBox (i.e., the area into which
            /// the viewBox will draw will be smaller than the viewport).
            static member inline meet = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMax meet"
            /// Scale the graphic such that:
            ///
            /// Aspect ratio is preserved.
            ///
            /// The entire viewport is covered by the viewBox.
            ///
            /// The viewBox is scaled down as much as possible, while still meeting the other criteria.
            ///
            /// In this case, if the aspect ratio of the viewBox does not match the viewport, some of the
            /// viewBox will extend beyond the bounds of the viewport (i.e., the area into which the
            /// viewBox will draw is larger than the viewport).
            static member inline slice = PropHelper.mkAttr "preserveAspectRatio" "xMaxYMax slice"

    /// Specifies the coordinate system for the various length values within the filter primitives and
    /// for the attributes that define the filter primitive subregion.
    [<Erase>]
    type primitiveUnits =
        /// Indicates that any length values within the filter definitions represent fractions or
        /// percentages of the bounding box on the referencing element.
        static member inline objectBoundingBox = PropHelper.mkAttr "primitiveUnits" "objectBoundingBox"
        /// Indicates that any length values within the filter definitions represent values in the current user coordinate
        /// system in place at the time when the <filter> element is referenced (i.e., the user coordinate system for the
        /// element referencing the <filter> element via a filter attribute).
        static member inline userSpaceOnUse = PropHelper.mkAttr "primitiveUnits" "userSpaceOnUse"

    /// Indicates which referrer to send when fetching the script, or resources fetched by the script
    [<Erase>]
    type referrerPolicy =
        /// The Referer header will not be sent.
        static member inline noReferrer = PropHelper.mkAttr "referrerPolicy" "no-referrer"
        /// The Referer header will not be sent to origins without TLS (HTTPS).
        static member inline noReferrerWhenDowngrade = PropHelper.mkAttr "referrerPolicy" "no-referrer-when-downgrade"
        /// The sent referrer will be limited to the origin of the referring page: its scheme, host, and port.
        static member inline origin = PropHelper.mkAttr "referrerPolicy" "origin"
        /// The referrer sent to other origins will be limited to the scheme, the host, and the port.
        /// Navigations on the same origin will still include the path.
        static member inline originWhenCrossOrigin = PropHelper.mkAttr "referrerPolicy" "origin-when-cross-origin"
        /// A referrer will be sent for same origin, but cross-origin requests will contain no referrer information.
        static member inline sameOrigin = PropHelper.mkAttr "referrerPolicy" "same-origin"
        /// Only send the origin of the document as the referrer when the protocol security level stays the same
        /// (e.g. HTTPS→HTTPS), but don't send it to a less secure destination (e.g. HTTPS→HTTP).
        static member inline strictOrigin = PropHelper.mkAttr "referrerPolicy" "strict-origin"
        /// Send a full URL when performing a same-origin request, but only send the origin when the protocol security
        /// level stays the same (e.g.HTTPS→HTTPS), and send no header to a less secure destination (e.g. HTTPS→HTTP).
        static member inline strictOriginWhenCrossOrigin = PropHelper.mkAttr "referrerPolicy" "strict-origin-when-cross-origin"
        /// The referrer will include the origin and the path (but not the fragment, password, or username). This value is unsafe,
        /// because it leaks origins and paths from TLS-protected resources to insecure origins.
        static member inline unsafeUrl = PropHelper.mkAttr "referrerPolicy" "unsafe-url"

    /// Defines the x coordinate of an element’s reference point.
    [<Erase>]
    type refX =
        /// Numbers are interpreted as being in the coordinate system of the marker contents, after application of the
        /// viewBox and preserveAspectRatio attributes.
        static member inline length (value: float) = PropHelper.mkAttr "refX" value
        /// Lengths are interpreted as being in the coordinate system of the marker contents, after application
        /// of the viewBox and preserveAspectRatio attributes.
        static member inline length (value: ICssUnit) = PropHelper.mkAttr "refX" value
        /// Numbers are interpreted as being in the coordinate system of the marker contents, after application of the
        /// viewBox and preserveAspectRatio attributes.
        static member inline length (value: int) = PropHelper.mkAttr "refX" value
        /// The reference point of the marker is placed at the left edge of the shape.
        static member inline left = PropHelper.mkAttr "refX" "left"
        /// The reference point of the marker is placed at the horizontal center of the shape.
        static member inline center = PropHelper.mkAttr "refX" "center"
        /// The reference point of the marker is placed at the right edge of the shape.
        static member inline right = PropHelper.mkAttr "refX" "right"

    /// Defines the y coordinate of an element’s reference point.
    [<Erase>]
    type refY =
        /// Numbers are interpreted as being in the coordinate system of the marker contents, after application of the
        /// viewBox and preserveAspectRatio attributes.
        static member inline length (value: float) = PropHelper.mkAttr "refY" value
        /// Lengths are interpreted as being in the coordinate system of the marker contents, after application of the
        /// viewBox and preserveAspectRatio attributes.
        ///
        /// Percentage values are interpreted as being a percentage of the viewBox height.
        static member inline length (value: ICssUnit) = PropHelper.mkAttr "refY" value
        /// Numbers are interpreted as being in the coordinate system of the marker contents, after application of the
        /// viewBox and preserveAspectRatio attributes.
        static member inline length (value: int) = PropHelper.mkAttr "refY" value
        /// The reference point of the marker is placed at the top edge of the shape.
        static member inline top = PropHelper.mkAttr "refY" "top"
        /// The reference point of the marker is placed at the vertical center of the shape.
        static member inline center = PropHelper.mkAttr "refY" "center"
        /// The reference point of the marker is placed at the bottom edge of the shape.
        static member inline bottom = PropHelper.mkAttr "refY" "bottom"

    /// The required rel attribute specifies the relationship between the current document and the linked document/resource.
    ///
    /// Docs at https://www.w3schools.com/tags/att_link_rel.asp
    [<Erase>]
    type rel =
        /// Provides a link to an alternate version of the document (i.e. print page, translated or mirror).
        ///
        /// Example: <link rel="alternate" type="application/atom+xml" title="W3Schools News" href="/blog/news/atom">
        static member inline alternate = PropHelper.mkAttr "rel" "alternate"
        /// Provides a link to the author of the document.
        static member inline author = PropHelper.mkAttr "rel" "author"
        /// Permalink for the nearest ancestor section.
        static member inline bookmark = PropHelper.mkAttr "rel" "bookmark"
        /// Preferred URL for the current document.
        static member inline canonical = PropHelper.mkAttr "rel" "canonical"
        /// Specifies that the browser should preemptively perform DNS resolution for the target resource's origin.
        static member inline dnsPrefetch = PropHelper.mkAttr "rel" "dns-prefetch"
        /// The referenced document is not part of the same site as the current document.
        static member inline external = PropHelper.mkAttr "rel" "external"
        /// Provides a link to a help document. Example: <link rel="help" href="/help/">
        static member inline help = PropHelper.mkAttr "rel" "help"
        /// Imports an icon to represent the document.
        ///
        /// Example: <link rel="icon" href="/favicon.ico" type="image/x-icon">
        static member inline icon = PropHelper.mkAttr "rel" "icon"
        /// Provides a link to copyright information for the document.
        static member inline license = PropHelper.mkAttr "rel" "license"
        /// Web app manifest.
        static member inline manifest = PropHelper.mkAttr "rel" "manifest"
        /// Tells to browser to preemptively fetch the script and store it in the document's module map for later
        /// evaluation. Optionally, the module's dependencies can be fetched as well.
        static member inline modulepreload = PropHelper.mkAttr "rel" "modulepreload"
        /// Provides a link to the next document in the series.
        static member inline next = PropHelper.mkAttr "rel" "next"
        /// Indicates that the current document's original author or publisher does not endorse the referenced document.
        static member inline nofollow = PropHelper.mkAttr "rel" "nofollow"
        /// Creates a top-level browsing context that is not an auxiliary browsing context if the hyperlink would create
        /// either of those, to begin with (i.e., has an appropriate target attribute value).
        static member inline noopener = PropHelper.mkAttr "rel" "noopener"
        /// No Referer header will be included. Additionally, has the same effect as noopener.
        static member inline noreferrer = PropHelper.mkAttr "rel" "noreferrer"
        /// Creates an auxiliary browsing context if the hyperlink would otherwise create a top-level browsing context
        /// that is not an auxiliary browsing context (i.e., has "_blank" as target attribute value).
        static member inline opener = PropHelper.mkAttr "rel" "opener"
        /// Provides the address of the pingback server that handles pingbacks to the current document.
        static member inline pingback = PropHelper.mkAttr "rel" "pingback"
        /// Specifies that the browser should preemptively connect to the target resource's origin.
        static member inline preconnect = PropHelper.mkAttr "rel" "preconnect"
        /// Specifies that the browser should preemptively fetch and cache the target resource as it is likely to be
        /// required for a follow-up navigation.
        static member inline prefetch = PropHelper.mkAttr "rel" "prefetch"
        /// Specifies that the browser agent must preemptively fetch and cache the target resource for current navigation
        /// according to the destination given by the "as" attribute (and the priority associated with that destination).
        static member inline preload = PropHelper.mkAttr "rel" "preload"
        /// Specifies that the browser should pre-render (load) the specified webpage in the background. So, if the user
        /// navigates to this page, it speeds up the page load (because the page is already loaded).
        ///
        /// Warning! This wastes the user's bandwidth!
        ///
        /// Only use prerender if it is absolutely sure that the webpage is required at some point in the user journey.
        static member inline prerender = PropHelper.mkAttr "rel" "prerender"
        /// Indicates that the document is a part of a series, and that the previous document in the series is the referenced document.
        static member inline prev = PropHelper.mkAttr "rel" "prev"
        /// Provides a link to a resource that can be used to search through the current document and its related pages.
        static member inline search = PropHelper.mkAttr "rel" "search"
        /// Imports a style sheet.
        static member inline stylesheet = PropHelper.mkAttr "rel" "stylesheet"
        /// Gives a tag (identified by the given address) that applies to the current document.
        static member inline tag = PropHelper.mkAttr "rel" "tag"

    /// Indicates the number of times an animation will take place.
    [<Erase>]
    type repeatCount =
        /// Specifies the number of iterations.
        ///
        /// It can include partial iterations expressed as fraction values.
        ///
        /// A fractional value describes a portion of the simple duration.
        ///
        /// Values must be greater than 0.
        static member inline iterations (value: float) = PropHelper.mkAttr "repeatCount" value
        /// Specifies the number of iterations.
        ///
        /// It can include partial iterations expressed as fraction values.
        ///
        /// A fractional value describes a portion of the simple duration.
        ///
        /// Values must be greater than 0.
        static member inline iterations (value: int) = PropHelper.mkAttr "repeatCount" value
        /// Indicates that the animation will be repeated indefinitely (i.e. until the document ends).
        static member inline indefinite = PropHelper.mkAttr "repeatCount" "indefinite"

    /// Specifies the total duration for repeating an animation.
    [<Erase>]
    type repeatDur =
        /// This value specifies the duration in presentation time to repeat the animation.
        static member inline clockValue (duration: System.TimeSpan) =
            PropHelpers.createClockValue(duration)
            |> PropHelper.mkAttr "repeatDur"
        /// Indicates that the animation will be repeated indefinitely (i.e. until the document ends).
        static member inline indefinite = PropHelper.mkAttr "repeatDur" "indefinite"

    /// Specifies whether or not an animation can restart.
    [<Erase>]
    type restart =
        /// Indicates that the animation can be restarted at any time.
        static member inline always = PropHelper.mkAttr "restart" "always"
        /// Indicates that the animation cannot be restarted for the time the document is loaded.
        static member inline never = PropHelper.mkAttr "restart" "never"
        /// Indicates that the animation can only be restarted when it is not active (i.e. after the active end).
        ///
        /// Attempts to restart the animation during its active duration are ignored.
        static member inline whenNotActive = PropHelper.mkAttr "restart" "whenNotActive"

    /// https://www.w3.org/WAI/PF/aria-1.1/roles
    [<Erase>]
    type role =
        /// A message with important, and usually time-sensitive, information.
        /// See related `alertdialog` and `status`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#alert
        static member inline alert = PropHelper.mkAttr "role" "alert"
        /// A type of dialog that contains an alert message, where initial focus
        /// goes to an element within the dialog. See related `alert` and
        /// `dialog`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#alertdialog
        static member inline alertDialog = PropHelper.mkAttr "role" "alertdialog"
        /// A region declared as a web application, as opposed to a web
        /// `document`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#application
        static member inline application = PropHelper.mkAttr "role" "application"
        /// A section of a page that consists of a composition that forms an
        /// independent part of a document, page, or site.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#article
        static member inline article = PropHelper.mkAttr "role" "article"
        /// A region that contains mostly site-oriented content, rather than
        /// page-specific content.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#banner
        static member inline banner = PropHelper.mkAttr "role" "banner"
        /// An input that allows for user-triggered actions when clicked or
        /// pressed. See related `link`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#button
        static member inline button = PropHelper.mkAttr "role" "button"
        /// A checkable input that has three possible values: `true`, `false`,
        /// or `mixed`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#checkbox
        static member inline checkbox = PropHelper.mkAttr "role" "checkbox"
        /// A cell containing header information for a column.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#columnheader
        static member inline columnHeader = PropHelper.mkAttr "role" "columnheader"
        /// A presentation of a `select`; usually similar to a `textbox` where
        /// users can type ahead to select an option, or type to enter arbitrary
        /// text as a new item in the list. See related `listbox`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#combobox
        static member inline comboBox = PropHelper.mkAttr "role" "combobox"
        /// A supporting section of the document, designed to be complementary
        /// to the main content at a similar level in the DOM hierarchy, but
        /// remains meaningful when separated from the main content.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#complementary
        static member inline complementary = PropHelper.mkAttr "role" "complementary"
        /// A large perceivable region that contains information about the
        /// parent document.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#contentinfo
        static member inline contentInfo = PropHelper.mkAttr "role" "contentinfo"
        /// A definition of a term or concept.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#definition
        static member inline definition = PropHelper.mkAttr "role" "definition"
        /// A dialog is an application window that is designed to interrupt the
        /// current processing of an application in order to prompt the user to
        /// enter information or require a response. See related `alertdialog`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#dialog
        static member inline dialog = PropHelper.mkAttr "role" "dialog"
        /// A list of references to members of a group, such as a static table
        /// of contents.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#directory
        static member inline directory = PropHelper.mkAttr "role" "directory"
        /// A region containing related information that is declared as document
        /// content, as opposed to a web application.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#document
        static member inline document = PropHelper.mkAttr "role" "document"
        /// A `landmark` region that contains a collection of items and objects
        /// that, as a whole, combine to create a form. See related search.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#form
        static member inline form = PropHelper.mkAttr "role" "form"
        /// A grid is an interactive control which contains cells of tabular
        /// data arranged in rows and columns, like a table.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#grid
        static member inline grid = PropHelper.mkAttr "role" "grid"
        /// A cell in a grid or treegrid.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#gridcell
        static member inline gridCell = PropHelper.mkAttr "role" "gridcell"
        /// A set of user interface objects which are not intended to be
        /// included in a page summary or table of contents by assistive
        /// technologies.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#group
        static member inline group = PropHelper.mkAttr "role" "group"
        /// A heading for a section of the page.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#heading
        static member inline heading = PropHelper.mkAttr "role" "heading"
        /// A container for a collection of elements that form an image.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#img
        static member inline img = PropHelper.mkAttr "role" "img"
        /// An interactive reference to an internal or external resource that,
        /// when activated, causes the user agent to navigate to that resource.
        /// See related `button`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#link
        static member inline link = PropHelper.mkAttr "role" "link"
        /// A group of non-interactive list items. See related `listbox`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#list
        static member inline list = PropHelper.mkAttr "role" "list"
        /// A widget that allows the user to select one or more items from a
        /// list of choices. See related `combobox` and `list`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#listbox
        static member inline listBox = PropHelper.mkAttr "role" "listbox"
        /// A single item in a list or directory.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#listitem
        static member inline listItem = PropHelper.mkAttr "role" "listitem"
        /// A type of live region where new information is added in meaningful
        /// order and old information may disappear. See related `marquee`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#log
        static member inline log = PropHelper.mkAttr "role" "log"
        /// The main content of a document.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#main
        static member inline main = PropHelper.mkAttr "role" "main"
        /// A type of live region where non-essential information changes
        /// frequently. See related `log`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#marquee
        static member inline marquee = PropHelper.mkAttr "role" "marquee"
        /// Content that represents a mathematical expression.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#math
        static member inline math = PropHelper.mkAttr "role" "math"
        /// A type of widget that offers a list of choices to the user.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#menu
        static member inline menu = PropHelper.mkAttr "role" "menu"
        /// A presentation of `menu` that usually remains visible and is usually
        /// presented horizontally.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#menubar
        static member inline menuBar = PropHelper.mkAttr "role" "menubar"
        /// An option in a set of choices contained by a `menu` or `menubar`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#menuitem
        static member inline menuItem = PropHelper.mkAttr "role" "menuitem"
        /// A `menuitem` with a checkable state whose possible values are
        /// `true`, `false`, or `mixed`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#menuitemcheckbox
        static member inline menuItemCheckbox = PropHelper.mkAttr "role" "menuitemcheckbox"
        /// A checkable menuitem in a set of elements with role `menuitemradio`,
        /// only one of which can be checked at a time.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#menuitemradio
        static member inline menuItemRadio = PropHelper.mkAttr "role" "menuitemradio"
        /// A collection of navigational elements (usually links) for navigating
        /// the document or related documents.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#navigation
        static member inline navigation = PropHelper.mkAttr "role" "navigation"
        /// A section whose content is parenthetic or ancillary to the main
        /// content of the resource.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#note
        static member inline note = PropHelper.mkAttr "role" "note"
        /// A selectable item in a `select` list.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#option
        static member inline option = PropHelper.mkAttr "role" "option"
        /// An element whose implicit native role semantics will not be mapped
        /// to the accessibility API.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#presentation
        static member inline presentation = PropHelper.mkAttr "role" "presentation"
        /// An element that displays the progress status for tasks that take a
        /// long time.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#progressbar
        static member inline progressBar = PropHelper.mkAttr "role" "progressbar"
        /// A checkable input in a group of elements with role radio, only one
        /// of which can be checked at a time.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#radio
        static member inline radio = PropHelper.mkAttr "role" "radio"
        /// A group of radio buttons.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#radiogroup
        static member inline radioGroup = PropHelper.mkAttr "role" "radiogroup"
        /// A large perceivable section of a web page or document, that is
        /// important enough to be included in a page summary or table of
        /// contents, for example, an area of the page containing live sporting
        /// event statistics.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#region
        static member inline region = PropHelper.mkAttr "role" "region"
        /// A row of cells in a grid.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#row
        static member inline row = PropHelper.mkAttr "role" "row"
        /// A group containing one or more row elements in a grid.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#rowgroup
        static member inline rowGroup = PropHelper.mkAttr "role" "rowgroup"
        /// A cell containing header information for a row in a grid.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#rowheader
        static member inline rowHeader = PropHelper.mkAttr "role" "rowheader"
        /// A graphical object that controls the scrolling of content within a
        /// viewing area, regardless of whether the content is fully displayed
        /// within the viewing area.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#scrollbar
        static member inline scrollBar = PropHelper.mkAttr "role" "scrollbar"
        /// A divider that separates and distinguishes sections of content or
        /// groups of menuitems.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#separator
        static member inline separator = PropHelper.mkAttr "role" "separator"
        /// A `landmark` region that contains a collection of items and objects
        /// that, as a whole, combine to create a search facility. See related
        /// `form`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#search
        static member inline search = PropHelper.mkAttr "role" "search"
        /// A user input where the user selects a value from within a given
        /// range.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#slider
        static member inline slider = PropHelper.mkAttr "role" "slider"
        /// A form of `range` that expects the user to select from among
        /// discrete choices.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#spinbutton
        static member inline spinButton = PropHelper.mkAttr "role" "spinbutton"
        /// A container whose content is advisory information for the user but
        /// is not important enough to justify an alert, often but not
        /// necessarily presented as a status bar. See related `alert`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#status
        static member inline status = PropHelper.mkAttr "role" "status"
        /// A grouping label providing a mechanism for selecting the tab content
        /// that is to be rendered to the user.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#tab
        static member inline tab = PropHelper.mkAttr "role" "tab"
        /// A list of `tab` elements, which are references to `tabpanel`
        /// elements.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#tablist
        static member inline tabList = PropHelper.mkAttr "role" "tablist"
        /// A container for the resources associated with a `tab`, where each
        /// `tab` is contained in a `tablist`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#tabpanel
        static member inline tabPanel = PropHelper.mkAttr "role" "tabpanel"
        /// Input that allows free-form text as its value.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#textbox
        static member inline textBox = PropHelper.mkAttr "role" "textbox"
        /// A type of live region containing a numerical counter which indicates
        /// an amount of elapsed time from a start point, or the time remaining
        /// until an end point.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#timer
        static member inline timer = PropHelper.mkAttr "role" "timer"
        /// A collection of commonly used function buttons or controls
        /// represented in compact visual form.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#toolbar
        static member inline toolbar = PropHelper.mkAttr "role" "toolbar"
        /// A contextual popup that displays a description for an element.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#tooltip
        static member inline tooltip = PropHelper.mkAttr "role" "tooltip"
        /// A type of `list` that may contain sub-level nested groups that can
        /// be collapsed and expanded.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#tree
        static member inline tree = PropHelper.mkAttr "role" "tree"
        /// A `grid` whose rows can be expanded and collapsed in the same manner
        /// as for a `tree`.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#treegrid
        static member inline treeGrid = PropHelper.mkAttr "role" "treegrid"
        /// An option item of a `tree`. This is an element within a tree that
        /// may be expanded or collapsed if it contains a sub-level group of
        /// `treeitem` elements.
        ///
        /// https://www.w3.org/WAI/PF/aria-1.1/roles#treeitem
        static member inline treeItem = PropHelper.mkAttr "role" "treeitem"

    [<Erase>]
    type selectionDirection =
        /// For the opposite direction.
        static member inline backward = PropHelper.mkAttr "selectionDirection" "backward"
        /// If selection was performed in the start-to-end direction of the current locale.
        static member inline forward = PropHelper.mkAttr "selectionDirection" "forward"
        /// If the direction is unknown.
        static member inline none = PropHelper.mkAttr "selectionDirection" "none"

    /// The shape of the associated hot spot.
    [<Erase>]
    type shape =
        static member inline rect = PropHelper.mkAttr "shape" "rect"
        static member inline circle = PropHelper.mkAttr "shape" "circle"
        static member inline poly = PropHelper.mkAttr "shape" "poly"

    /// The shape of the associated hot spot.
    [<Erase>]
    type spacing =
        /// Indicates that the user agent should use text-on-a-path layout algorithms to adjust
        /// the spacing between typographic characters in order to achieve visually appealing results.
        static member inline auto = PropHelper.mkAttr "spacing" "auto"
        /// Indicates that the typographic characters should be rendered exactly according to the
        /// spacing rules as specified by the layout rules for text-on-a-path.
        static member inline exact = PropHelper.mkAttr "spacing" "exact"

    /// Determines how a shape is filled beyond the defined edges of a gradient.
    [<Erase>]
    type spreadMethod =
        /// Indicates that the final color of the gradient fills the shape beyond the gradient's edges.
        static member inline pad = PropHelper.mkAttr "spreadMethod" "pad"
        /// Indicates that the gradient repeats in reverse beyond its edges.
        static member inline reflect = PropHelper.mkAttr "spreadMethod" "reflect"
        /// Specifies that the gradient repeats in the original order beyond its edges.
        static member inline repeat = PropHelper.mkAttr "spreadMethod" "repeat"

    /// Defines how the Perlin Noise tiles behave at the border.
    [<Erase>]
    type stitchTiles =
        /// Indicates that no attempt is made to achieve smooth transitions at the border of tiles which
        /// contain a turbulence function.
        ///
        /// Sometimes the result will show clear discontinuities at the tile borders.
        static member inline noStitch = PropHelper.mkAttr "stitchTiles" "noStitch"
        /// Indicates that the user agent will automatically adjust the x and y values of the base
        /// frequency such that the <feTurbulence> node’s width and height (i.e., the width and
        /// height of the current subregion) contain an integral number of the tile width and height
        /// for the first octave.
        static member inline stitch = PropHelper.mkAttr "stitchTiles" "stitch"

    [<Erase>]
    type target =
        /// Opens the linked document in a new window or tab.
        static member inline blank = PropHelper.mkAttr "target" "_blank"
        /// Opens the linked document in the parent frame.
        static member inline parent = PropHelper.mkAttr "target" "_parent"
        /// Opens the linked document in the same frame as it was clicked (this is default).
        static member inline self = PropHelper.mkAttr "target" "_self"
        /// Opens the linked document in the full body of the window.
        static member inline top = PropHelper.mkAttr "target" "_top"

    /// The `text-anchor` attribute is used to align (start-, middle- or
    /// end-alignment) a string of pre-formatted text or auto-wrapped text where
    /// the wrapping area is determined from the `inline-size` property relative
    /// to a given point. It is not applicable to other types of auto-wrapped
    /// text. For those cases you should use `text-align`. For multi-line text,
    /// the alignment takes place for each line.
    ///
    /// The `text-anchor` attribute is applied to each individual text chunk
    /// within a given `<text>` element. Each text chunk has an initial current
    /// text position, which represents the point in the user coordinate system
    /// resulting from (depending on context) application of the `x` and `y`
    /// attributes on the `<text>` element, any `x` or `y` attribute values on a
    /// `<tspan>`, `<tref>` or `<altGlyph>` element assigned explicitly to the
    /// first rendered character in a text chunk, or determination of the
    /// initial current text position for a `<textPath>` element.
    [<Erase>]
    type textAnchor =
        /// The rendered characters are shifted such that the end of the
        /// resulting rendered text (final current text position before applying
        /// the `text-anchor` property) is at the initial current text position.
        /// For an element with a `direction` property value of `ltr` (typical
        /// for most European languages), the right side of the text is rendered
        /// at the initial text position. For an element with a `direction`
        /// property value of `rtl` (typical for Arabic and Hebrew), the left
        /// side of the text is rendered at the initial text position. For an
        /// element with a vertical primary text direction (often typical for
        /// Asian text), the bottom of the text is rendered at the initial text
        /// position.
        static member inline endOfText = PropHelper.mkAttr "textAnchor" "end"
        /// The rendered characters are aligned such that the middle of the text
        /// string is at the current text position. (For text on a path,
        /// conceptually the text string is first laid out in a straight line.
        /// The midpoint between the start of the text string and the end of the
        /// text string is determined. Then, the text string is mapped onto the
        /// path with this midpoint placed at the current text position.)
        static member inline middle = PropHelper.mkAttr "textAnchor" "middle"
        /// The rendered characters are aligned such that the start of the text
        /// string is at the initial current text position. For an element with
        /// a `direction` property value of `ltr` (typical for most European
        /// languages), the left side of the text is rendered at the initial
        /// text position. For an element with a `direction` property value of
        /// `rtl` (typical for Arabic and Hebrew), the right side of the text is
        /// rendered at the initial text position. For an element with a
        /// vertical primary text direction (often typical for Asian text), the
        /// top side of the text is rendered at the initial text position.
        static member inline startOfText = PropHelper.mkAttr "textAnchor" "start"

    [<Erase>]
    type type' =
        /// Defines a clickable button (mostly used with a JavaScript code to activate a script)
        static member inline button = PropHelper.mkAttr "type" "button"
        /// Defines a checkbox
        static member inline checkbox = PropHelper.mkAttr "type" "checkbox"
        /// Defines a color picker
        static member inline color = PropHelper.mkAttr "type" "color"
        /// Defines a date control with year, month and day (no time)
        static member inline date = PropHelper.mkAttr "type" "date"
        /// Defines a date and time control (year, month, day, time (no timezone)
        static member inline dateTimeLocal = PropHelper.mkAttr "type" "datetime-local"
        /// Defines a field for an e-mail address
        static member inline email = PropHelper.mkAttr "type" "email"
        /// Defines a file-select field and a "Browse" button (for file uploads)
        static member inline file = PropHelper.mkAttr "type" "file"
        /// Defines a hidden input field
        static member inline hidden = PropHelper.mkAttr "type" "hidden"
        /// Defines an image as the submit button
        static member inline image = PropHelper.mkAttr "type" "image"
        /// Defines a month and year control (no timezone)
        static member inline month = PropHelper.mkAttr "type" "month"
        /// Defines a field for entering a number
        static member inline number = PropHelper.mkAttr "type" "number"
        /// Defines a password field
        static member inline password = PropHelper.mkAttr "type" "password"
        /// Defines a radio button
        static member inline radio = PropHelper.mkAttr "type" "radio"
        /// Defines a range control (like a slider control)
        static member inline range = PropHelper.mkAttr "type" "range"
        /// Defines a reset button
        static member inline reset = PropHelper.mkAttr "type" "reset"
        /// Defines a text field for entering a search string
        static member inline search = PropHelper.mkAttr "type" "search"
        /// Defines a submit button
        static member inline submit = PropHelper.mkAttr "type" "submit"
        /// Defines a field for entering a telephone number
        static member inline tel = PropHelper.mkAttr "type" "tel"
        /// Default. Defines a single-line text field
        static member inline text = PropHelper.mkAttr "type" "text"
        /// Defines a control for entering a time (no timezone)
        static member inline time = PropHelper.mkAttr "type" "time"
        /// Defines a field for entering a URL
        static member inline url = PropHelper.mkAttr "type" "url"
        /// Defines a week and year control (no timezone)
        static member inline week = PropHelper.mkAttr "type" "week"

    /// Indicates how the control wraps text.
    [<Erase>]
    type wrap =
        /// The browser ensures that all line breaks in the value consist of a CR+LF pair,
        /// but does not insert any additional line breaks.
        static member inline soft = PropHelper.mkAttr "wrap" "soft"
        /// The browser automatically inserts line breaks (CR+LF)
        /// so that each line has no more than the width of the control;
        /// the cols attribute must also be specified for this to take effect.
        static member inline hard = PropHelper.mkAttr "wrap" "hard"
        /// Like soft but changes appearance to white-space: pre
        /// so line segments exceeding cols are not wrapped and the `<textarea>` becomes horizontally scrollable.
        /// WARNING: This API has not been standardized.
        static member inline off = PropHelper.mkAttr "wrap" "off"

    /// Indicates which color channel from in2 to use to displace the pixels in in along the x-axis.
    [<Erase>]
    type xChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the x-axis.
        static member inline A = PropHelper.mkAttr "xChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline B = PropHelper.mkAttr "xChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline G = PropHelper.mkAttr "xChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the x-axis.
        static member inline R = PropHelper.mkAttr "xChannelSelector" "R"

    /// Indicates which color channel from in2 to use to displace the pixels in in along the y-axis.
    [<Erase>]
    type yChannelSelector =
        /// Specifies that the alpha channel of the input image defined in in2 will be used to displace
        /// the pixels of the input image defined in in along the y-axis.
        static member inline A = PropHelper.mkAttr "yChannelSelector" "A"
        /// Specifies that the blue color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline B = PropHelper.mkAttr "yChannelSelector" "B"
        /// Specifies that the green color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline G = PropHelper.mkAttr "yChannelSelector" "G"
        /// Specifies that the red color channel of the input image defined in in2 will be used to
        /// displace the pixels of the input image defined in in along the y-axis.
        static member inline R = PropHelper.mkAttr "yChannelSelector" "R"
