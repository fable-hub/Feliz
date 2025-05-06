namespace Feliz.Listeners

open Browser.Types
open Browser.Dom
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open System.ComponentModel

[<EditorBrowsable(EditorBrowsableState.Never)>]
module Impl =
    [<Emit("typeof window !== 'undefined'")>]
    let isWindowDefined () : bool = jsNative

    [<Emit("typeof window.addEventListener === 'function'")>]
    let isWindowListenerFunction () : bool = jsNative

    [<Emit("Object.defineProperty({}, 'passive', {get () { $0() }})")>]
    let definePassive (_updater: unit -> unit) : JS.PropertyDescriptor = jsNative

    let allowsPassiveEvents =
        let mutable passive = false

        try
            if isWindowDefined() && isWindowListenerFunction() then
                let options = 
                    jsOptions<AddEventListenerOptions>(fun o ->
                        o.passive <- true
                    )
                
                window.addEventListener("testPassiveEventSupport", ignore, options)
                window.removeEventListener("testPassiveEventSupport", ignore)
        with _ -> ()

        passive

    let defaultPassive = jsOptions<AddEventListenerOptions>(fun o -> o.passive <- true)

    let adjustPassive (maybeOptions: AddEventListenerOptions option) =
        maybeOptions
        |> Option.map (fun options ->
            if options.passive && not allowsPassiveEvents then
                jsOptions<AddEventListenerOptions>(fun o ->
                    o.capture <- options.capture
                    o.once <- options.once
                    o.passive <- false
                )
            else options)

    let createRemoveOptions (maybeOptions: AddEventListenerOptions option) =
        maybeOptions
        |> Option.bind (fun options ->
            if options.capture then 
                Some (jsOptions<RemoveEventListenerOptions>(fun o -> o.capture <- true))
            else None)

[<Erase;RequireQualifiedAccess>]
module React =
    [<Erase>]
    type useListener =
        static member inline on (eventType: string, action: #Event -> unit, ?options: AddEventListenerOptions) =
            let addOptions = React.useMemo((fun () -> Impl.adjustPassive options), [| options |])
            let removeOptions = React.useMemo((fun () -> Impl.createRemoveOptions options), [| options |])
            let fn = React.useMemo((fun () -> unbox<#Event> >> action), [| action |])

            let listener = React.useCallbackRef(fun () ->
                match addOptions with
                | Some options -> document.addEventListener(eventType, fn, options)
                | None -> document.addEventListener(eventType, fn)

                React.createDisposable(fun () ->
                    match removeOptions with
                    | Some options -> document.removeEventListener(eventType, fn, options)
                    | None -> document.removeEventListener(eventType, fn)
                )
            )
            
            React.useEffect(listener)

        static member inline onAbort (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("abort", action, ?options = options)
        static member inline onAbort (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("abort", action, ?options = options)
        static member inline onAnimationCancel (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("animationcancel", action, ?options = options)
        static member inline onAnimationEnd (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("animationend", action, ?options = options)
        static member inline onAnimationIteration (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("animationiteration", action, ?options = options)
        static member inline onAnimationStart (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("animationstart", action, ?options = options)
        static member inline onAuxClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("onauxclick", action, ?options = options)
        static member inline onBlur (action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("blur", action, ?options = options)
        static member inline onCancel (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("oncancel", action, ?options = options)
        static member inline onCanPlay (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("canplay", action, ?options = options)
        static member inline onCanPlayThrough (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("canplaythrough", action, ?options = options)
        static member inline onChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("change", action, ?options = options)
        static member inline onClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("click", action, ?options = options)
        static member inline onClose (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("onclose", action, ?options = options)
        static member inline onContextMenu (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("contextmenu", action, ?options = options)
        static member inline onCopy (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("copy", action, ?options = options)
        static member inline onCueChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("oncuechange", action, ?options = options)
        static member inline onCut (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("cut", action, ?options = options)
        static member inline onDblClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dblClick", action, ?options = options)
        static member inline onDOMContentLoaded (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("DOMContentLoaded", action, ?options = options)
        static member inline onDrag (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("drag", action, ?options = options)
        static member inline onDragEnd (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragend", action, ?options = options)
        static member inline onDragEnter (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragenter", action, ?options = options)
        static member inline onDragExit (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragexit", action, ?options = options)
        static member inline onDragLeave (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragleave", action, ?options = options)
        static member inline onDragOver (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragover", action, ?options = options)
        static member inline onDragStart (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("dragstart", action, ?options = options)
        static member inline onDrop (action: DragEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("drop", action, ?options = options)
        static member inline onDurationChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("durationchange", action, ?options = options)
        static member inline onEmptied (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("emptied", action, ?options = options)
        static member inline onEnded (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("ended", action, ?options = options)
        static member inline onError (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("error", action, ?options = options)
        static member inline onError (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("error", action, ?options = options)
        static member inline onFocus (action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("focus", action, ?options = options)
        static member inline onFormData (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("formdata", action, ?options = options)
        static member inline onFullscreenChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("fullscreenchange", action, ?options = options)
        static member inline onFullscreenError (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("fullscreenerror", action, ?options = options)
        static member inline onGotPointerCapture (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("gotPointercapture", action, ?options = options)
        static member inline onInput (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("input", action, ?options = options)
        static member inline onInvalid (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("invalid", action, ?options = options)
        static member inline onKeyDown (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("keydown", action, ?options = options)
        static member inline onKeyPress (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("keypress", action, ?options = options)
        static member inline onKeyUp (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("keyup", action, ?options = options)
        static member inline onLoad (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("load", action, ?options = options)
        static member inline onLoad (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("load", action, ?options = options)
        static member inline onLoadedData (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("loadeddata", action, ?options = options)
        static member inline onLoadedMetadata (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("loadedmetadata", action, ?options = options)
        static member inline onLoadEnd (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("loadend", action, ?options = options)
        static member inline onLoadStart (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("loadstart", action, ?options = options)
        static member inline onLostPointerCapture (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("lostpointercapture", action, ?options = options)
        static member inline onMouseDown (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mousedown", action, ?options = options)
        static member inline onMouseEnter (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mouseenter", action, ?options = options)
        static member inline onMouseLeave (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mouseleave", action, ?options = options)
        static member inline onMouseMove (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mousemove", action, ?options = options)
        static member inline onMouseOut (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mouseout", action, ?options = options)
        static member inline onMouseOver (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mouseover", action, ?options = options)
        static member inline onMouseUp (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("mouseup", action, ?options = options)
        static member inline onPaste (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("paste", action, ?options = options)
        static member inline onPause (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("pause", action, ?options = options)
        static member inline onPlay (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("play", action, ?options = options)
        static member inline onPlaying (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("playing", action, ?options = options)
        static member inline onPointerCancel (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointercancel", action, ?options = options)
        static member inline onPointerDown (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerdown", action, ?options = options)
        static member inline onPointerEnter (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerenter", action, ?options = options)
        static member inline onPointerLeave (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerleave", action, ?options = options)
        static member inline onPointerMove (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointermove", action, ?options = options)
        static member inline onPointerOut (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerout", action, ?options = options)
        static member inline onPointerOver (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerover", action, ?options = options)
        static member inline onPointerUp (action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("pointerup", action, ?options = options)
        static member inline onProgress (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("progress", action, ?options = options)
        static member inline onRateChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("ratechange", action, ?options = options)
        static member inline onReadyStateChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("readystatechange", action, ?options = options)
        static member inline onReset (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("reset", action, ?options = options)
        static member inline onResize (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("resize", action, ?options = options)
        static member inline onScroll (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("scroll", action, ?options = options)
        static member inline onSeeked (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("seeked", action, ?options = options)
        static member inline onSeeking (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("seeking", action, ?options = options)
        static member inline onSelect (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("select", action, ?options = options)
        static member inline onSelectionChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("selectionchange", action, ?options = options)
        static member inline onSelectStart (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("selectstart", action, ?options = options)
        static member inline onStalled (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("stalled", action, ?options = options)
        static member inline onSubmit (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("submit", action, ?options = options)
        static member inline onSuspend (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("suspend", action, ?options = options)
        static member inline onTimeUpdate (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("timeupdate", action, ?options = options)
        static member inline onTouchCancel (action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("touchcancel", action, ?options = options)
        static member inline onTouchEnd (action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("touchend", action, ?options = options)
        static member inline onTouchMove (action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("touchmove", action, ?options = options)
        static member inline onTouchStart (action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("touchstart", action, ?options = options)
        static member inline onTransitionCancel (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("transitioncancel", action, ?options = options)
        static member inline onTransitionEnd (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("transitionend", action, ?options = options)
        static member inline onTransitionRun (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("transitionrun", action, ?options = options)
        static member inline onTransitionStart (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("transitionstart", action, ?options = options)
        static member inline onVisibilityChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("visibilitychange", action, ?options = options)
        static member inline onVolumeChange (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("volumechange", action, ?options = options)
        static member inline onWaiting (action: Event -> unit, ?options: AddEventListenerOptions) = useListener.on("waiting", action, ?options = options)
        static member inline onWheel (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useListener.on("wheel", action, ?options = options)

        /// Invokes the callback when a click event is not within the given element.
        ///
        /// Uses separate handlers for touch and mouse events.
        ///
        /// This listener is passive by default.
        static member inline onClickAway (elemRef: IRefValue<#HTMLElement option>, callback: MouseEvent -> unit, touchCallback: TouchEvent -> unit, ?options: AddEventListenerOptions) =
            let options = Option.defaultValue Impl.defaultPassive options

            useListener.onMouseDown((fun ev ->
                match elemRef.current with
                | Some elem when not (elem.contains(unbox ev.target)) ->
                    callback ev
                | _ -> ()
            ), options)

            useListener.onTouchStart((fun ev ->
                match elemRef.current with
                | Some elem when not (elem.contains(unbox ev.target)) ->
                    touchCallback ev
                | _ -> ()
            ), options)
        
        /// Invokes the callback when a click event is not within the given element.
        ///
        /// Shares a common callback for both touch and mouse events.
        ///
        /// This listener is passive by default.
        static member inline onClickAway (elemRef: IRefValue<#HTMLElement option>, callback: UIEvent -> unit, ?options: AddEventListenerOptions) =
            let options = Option.defaultValue Impl.defaultPassive options

            useListener.onMouseDown((fun ev ->
                match elemRef.current with
                | Some elem when not (elem.contains(unbox ev.target)) ->
                    callback ev
                | _ -> ()
            ), options)

            useListener.onTouchStart((fun ev ->
                match elemRef.current with
                | Some elem when not (elem.contains(unbox ev.target)) ->
                    callback ev
                | _ -> ()
            ), options)

    [<Erase>]
    type useElementListener =
        static member inline on (elemRef: IRefValue<#HTMLElement option>, eventType: string, action: #Event -> unit, ?options: AddEventListenerOptions) =
            let addOptions = React.useMemo((fun () -> Impl.adjustPassive options), [| options |])
            let removeOptions = React.useMemo((fun () -> Impl.createRemoveOptions options), [| options |])
            let fn = React.useMemo((fun () -> unbox<#Event> >> action), [| action |])

            let listener = React.useCallbackRef(fun () ->
                elemRef.current |> Option.iter(fun elem ->
                    match addOptions with
                    | Some options -> elem.addEventListener(eventType, fn, options)
                    | None -> elem.addEventListener(eventType, fn)
                )
                
                React.createDisposable(fun () -> 
                    elemRef.current |> Option.iter(fun elem ->
                        match removeOptions with
                        | Some options -> elem.removeEventListener(eventType, fn, options)
                        | None -> elem.removeEventListener(eventType, fn)
                ))
            )

            React.useEffect(listener)

        static member inline onAbort (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "abort", action, ?options = options)
        static member inline onAbort (elemRef: IRefValue<#HTMLElement option>, action: UIEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "abort", action, ?options = options)
        static member inline onAnimationCancel (elemRef: IRefValue<#HTMLElement option>, action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "animationcancel", action, ?options = options)
        static member inline onAnimationEnd (elemRef: IRefValue<#HTMLElement option>, action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "animationend", action, ?options = options)
        static member inline onAnimationIteration (elemRef: IRefValue<#HTMLElement option>, action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "animationiteration", action, ?options = options)
        static member inline onAnimationStart (elemRef: IRefValue<#HTMLElement option>, action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "animationstart", action, ?options = options)
        static member inline onAuxClick (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "onauxclick", action, ?options = options)
        static member inline onBlur (elemRef: IRefValue<#HTMLElement option>, action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "blur", action, ?options = options)
        static member inline onCancel (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "oncancel", action, ?options = options)
        static member inline onCanPlay (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "canplay", action, ?options = options)
        static member inline onCanPlayThrough (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "canplaythrough", action, ?options = options)
        static member inline onChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "change", action, ?options = options)
        static member inline onClick (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "click", action, ?options = options)
        static member inline onClose (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "onclose", action, ?options = options)
        static member inline onContextMenu (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "contextmenu", action, ?options = options)
        static member inline onCopy (elemRef: IRefValue<#HTMLElement option>, action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "copy", action, ?options = options)
        static member inline onCueChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "oncuechange", action, ?options = options)
        static member inline onCut (elemRef: IRefValue<#HTMLElement option>, action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "cut", action, ?options = options)
        static member inline onDblClick (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dblClick", action, ?options = options)
        static member inline onDOMContentLoaded (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "DOMContentLoaded", action, ?options = options)
        static member inline onDrag (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "drag", action, ?options = options)
        static member inline onDragEnd (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragend", action, ?options = options)
        static member inline onDragEnter (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragenter", action, ?options = options)
        static member inline onDragExit (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragexit", action, ?options = options)
        static member inline onDragLeave (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragleave", action, ?options = options)
        static member inline onDragOver (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragover", action, ?options = options)
        static member inline onDragStart (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "dragstart", action, ?options = options)
        static member inline onDrop (elemRef: IRefValue<#HTMLElement option>, action: DragEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "drop", action, ?options = options)
        static member inline onDurationChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "durationchange", action, ?options = options)
        static member inline onEmptied (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "emptied", action, ?options = options)
        static member inline onEnded (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "ended", action, ?options = options)
        static member inline onError (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "error", action, ?options = options)
        static member inline onError (elemRef: IRefValue<#HTMLElement option>, action: UIEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "error", action, ?options = options)
        static member inline onFocus (elemRef: IRefValue<#HTMLElement option>, action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "focus", action, ?options = options)
        static member inline onFocusIn (elemRef: IRefValue<#HTMLElement option>, action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "focusin", action, ?options = options)
        static member inline onFocusOut (elemRef: IRefValue<#HTMLElement option>, action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "focusout", action, ?options = options)
        static member inline onFormData (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "formdata", action, ?options = options)
        static member inline onFullscreenChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "fullscreenchange", action, ?options = options)
        static member inline onFullscreenError (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "fullscreenerror", action, ?options = options)
        static member inline onGotPointerCapture (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "gotPointercapture", action, ?options = options)
        static member inline onInput (elemRef: IRefValue<#HTMLElement option>, action: UIEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "input", action, ?options = options)
        static member inline onInvalid (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "invalid", action, ?options = options)
        static member inline onKeyDown (elemRef: IRefValue<#HTMLElement option>, action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "keydown", action, ?options = options)
        static member inline onKeyPress (elemRef: IRefValue<#HTMLElement option>, action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "keypress", action, ?options = options)
        static member inline onKeyUp (elemRef: IRefValue<#HTMLElement option>, action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "keyup", action, ?options = options)
        static member inline onLoad (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "load", action, ?options = options)
        static member inline onLoad (elemRef: IRefValue<#HTMLElement option>, action: UIEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "load", action, ?options = options)
        static member inline onLoadedData (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "loadeddata", action, ?options = options)
        static member inline onLoadedMetadata (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "loadedmetadata", action, ?options = options)
        static member inline onLoadEnd (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "loadend", action, ?options = options)
        static member inline onLoadStart (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "loadstart", action, ?options = options)
        static member inline onLostPointerCapture (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "lostpointercapture", action, ?options = options)
        static member inline onMouseDown (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mousedown", action, ?options = options)
        static member inline onMouseEnter (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mouseenter", action, ?options = options)
        static member inline onMouseLeave (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mouseleave", action, ?options = options)
        static member inline onMouseMove (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mousemove", action, ?options = options)
        static member inline onMouseOut (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mouseout", action, ?options = options)
        static member inline onMouseOver (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mouseover", action, ?options = options)
        static member inline onMouseUp (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "mouseup", action, ?options = options)
        static member inline onPaste (elemRef: IRefValue<#HTMLElement option>, action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "paste", action, ?options = options)
        static member inline onPause (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pause", action, ?options = options)
        static member inline onPlay (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "play", action, ?options = options)
        static member inline onPlaying (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "playing", action, ?options = options)
        static member inline onPointerCancel (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointercancel", action, ?options = options)
        static member inline onPointerDown (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerdown", action, ?options = options)
        static member inline onPointerEnter (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerenter", action, ?options = options)
        static member inline onPointerLeave (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerleave", action, ?options = options)
        static member inline onPointerMove (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointermove", action, ?options = options)
        static member inline onPointerOut (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerout", action, ?options = options)
        static member inline onPointerOver (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerover", action, ?options = options)
        static member inline onPointerUp (elemRef: IRefValue<#HTMLElement option>, action: PointerEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "pointerup", action, ?options = options)
        static member inline onProgress (elemRef: IRefValue<#HTMLElement option>, action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "progress", action, ?options = options)
        static member inline onRateChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "ratechange", action, ?options = options)
        static member inline onReadyStateChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "readystatechange", action, ?options = options)
        static member inline onReset (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "reset", action, ?options = options)
        static member inline onResize (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "resize", action, ?options = options)
        static member inline onScroll (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "scroll", action, ?options = options)
        static member inline onSeeked (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "seeked", action, ?options = options)
        static member inline onSeeking (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "seeking", action, ?options = options)
        static member inline onSelect (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "select", action, ?options = options)
        static member inline onSelectionChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "selectionchange", action, ?options = options)
        static member inline onSelectStart (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "selectstart", action, ?options = options)
        static member inline onStalled (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "stalled", action, ?options = options)
        static member inline onSubmit (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "submit", action, ?options = options)
        static member inline onSuspend (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "suspend", action, ?options = options)
        static member inline onTimeUpdate (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "timeupdate", action, ?options = options)
        static member inline onTouchCancel (elemRef: IRefValue<#HTMLElement option>, action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "touchcancel", action, ?options = options)
        static member inline onTouchEnd (elemRef: IRefValue<#HTMLElement option>, action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "touchend", action, ?options = options)
        static member inline onTouchMove (elemRef: IRefValue<#HTMLElement option>, action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "touchmove", action, ?options = options)
        static member inline onTouchStart (elemRef: IRefValue<#HTMLElement option>, action: TouchEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "touchstart", action, ?options = options)
        static member inline onTransitionCancel (elemRef: IRefValue<#HTMLElement option>, action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "transitioncancel", action, ?options = options)
        static member inline onTransitionEnd (elemRef: IRefValue<#HTMLElement option>, action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "transitionend", action, ?options = options)
        static member inline onTransitionRun (elemRef: IRefValue<#HTMLElement option>, action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "transitionrun", action, ?options = options)
        static member inline onTransitionStart (elemRef: IRefValue<#HTMLElement option>, action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "transitionstart", action, ?options = options)
        static member inline onVisibilityChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "visibilitychange", action, ?options = options)
        static member inline onVolumeChange (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "volumechange", action, ?options = options)
        static member inline onWaiting (elemRef: IRefValue<#HTMLElement option>, action: Event -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "waiting", action, ?options = options)
        static member inline onWheel (elemRef: IRefValue<#HTMLElement option>, action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useElementListener.on(elemRef, "wheel", action, ?options = options)

    [<Erase>]
    type useStyle =
        static member inline onCustom (elemRef: IRefValue<#HTMLElement option>) (styles: IStyleAttribute list) (resolver: #HTMLElement option -> bool) =
            let isTrue,setIsTrue = React.useState false
            
            useElementListener.onChange(elemRef, (fun _ ->
                elemRef.current
                |> resolver
                |> setIsTrue
            ), Impl.defaultPassive)

            React.useMemo((fun () -> 
                if isTrue then styles
                else []
            ), [| isTrue :> obj; styles :> obj |])

        static member inline onClick (elemRef: IRefValue<#HTMLElement option>) (styles: IStyleAttribute list) =
            let isClicked,setIsClicked = React.useState false
            
            useElementListener.onClick(elemRef, (fun _ -> setIsClicked (not isClicked)), Impl.defaultPassive)
            
            React.useMemo((fun () -> 
                if isClicked then styles
                else []
            ), [| isClicked :> obj; styles :> obj |])

        static member inline onDisabled< ^elem when ^elem :> HTMLElement and ^elem : (member disabled : bool)> (elemRef: IRefValue< ^elem option>) (styles: IStyleAttribute list) =
            useStyle.onCustom elemRef styles (fun elem ->
                elem
                |> Option.map (fun e -> e?disabled)
                |> Option.defaultValue false
            )

        static member inline onFocus (elemRef: IRefValue<#HTMLElement option>) (styles: IStyleAttribute list) =
            let isFocused,setIsFocused = React.useState false
            
            useElementListener.onFocusIn(elemRef, (fun _ -> setIsFocused true), Impl.defaultPassive)
            useElementListener.onFocusOut(elemRef, (fun _ -> setIsFocused false), Impl.defaultPassive)

            React.useMemo((fun () -> 
                if isFocused then styles
                else []
            ), [| isFocused :> obj; styles :> obj |])

        static member inline onHover (elemRef: IRefValue<#HTMLElement option>) (styles: IStyleAttribute list) =
            let isHovered,setIsHovered = React.useState false
            
            useElementListener.onMouseEnter(elemRef, (fun _ -> setIsHovered true), Impl.defaultPassive)
            useElementListener.onMouseLeave(elemRef, (fun _ -> setIsHovered false), Impl.defaultPassive)

            React.useMemo((fun () -> 
                if isHovered then styles
                else []
            ), [| isHovered :> obj; styles :> obj |])

        static member inline onInvalid< ^elem when ^elem :> HTMLElement and ^elem : (member validity : ValidityState)> (elemRef: IRefValue< ^elem option>) (styles: IStyleAttribute list) =
            useStyle.onCustom elemRef styles (fun elem ->
                elem
                |> Option.map (fun e -> 
                    JS.console.log(e?validity?valid)
                    not e?validity?valid)
                |> Option.defaultValue false
            )

        static member inline onValid< ^elem when ^elem :> HTMLElement and ^elem : (member validity : ValidityState)> (elemRef: IRefValue< ^elem option>) (styles: IStyleAttribute list) =
            useStyle.onCustom elemRef styles (fun elem ->
                elem
                |> Option.map (fun e -> 
                    JS.console.log(e?validity?valid)
                    e?validity?valid)
                |> Option.defaultValue false
            )

    [<Erase>]
    type useWindowListener =
        static member inline on (eventType: string, action: #Event -> unit, ?options: AddEventListenerOptions) =
            let addOptions = React.useMemo((fun () -> Impl.adjustPassive options), [| options |])
            let removeOptions = React.useMemo((fun () -> Impl.createRemoveOptions options), [| options |])
            let fn = React.useMemo((fun () -> unbox<#Event> >> action), [| action |])

            let listener = React.useCallbackRef(fun () ->
                match addOptions with
                | Some options -> window.addEventListener(eventType, fn, options)
                | None -> window.addEventListener(eventType, fn)

                React.createDisposable(fun () ->
                    match removeOptions with
                    | Some options -> window.removeEventListener(eventType, fn, options)
                    | None -> window.removeEventListener(eventType, fn)
                )
            )
            
            React.useEffect(listener)
        
        static member inline onAbort (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("abort", action, ?options = options)
        static member inline onAbort (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("abort", action, ?options = options)
        static member inline onAnimationCancel (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("animationcancel", action, ?options = options)
        static member inline onAnimationEnd (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("animationend", action, ?options = options)
        static member inline onAnimationIteration (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("animationiteration", action, ?options = options)
        static member inline onAnimationStart (action: AnimationEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("animationstart", action, ?options = options)
        static member inline onAuxClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("onauxclick", action, ?options = options)
        static member inline onAfterPrint (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("afterprint", action, ?options = options)
        static member inline onBeforeInstallPrompt (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("beforeinstallprompt", action, ?options = options)
        static member inline onBeforePrint (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("beforeprint", action, ?options = options)
        static member inline onBeforeUnload (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("beforeunload", action, ?options = options)
        static member inline onBlur (action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("blur", action, ?options = options)
        static member inline onChange (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("change", action, ?options = options)
        static member inline onClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("click", action, ?options = options)
        static member inline onClipboardChange (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("clipboardchange", action, ?options = options)
        static member inline onClose (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("onclose", action, ?options = options)
        static member inline onContextMenu (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("contextmenu", action, ?options = options)
        static member inline onCopy (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("copy", action, ?options = options)
        static member inline onCut (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("cut", action, ?options = options)
        static member inline onDblClick (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("dblClick", action, ?options = options)
        static member inline onDeviceMotion (action: DeviceMotionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("devicemotion", action, ?options = options)
        static member inline onDeviceOrientation (action: DeviceOrientationEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("deviceorientation", action, ?options = options)
        static member inline onDOMContentLoaded (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("DOMContentLoaded", action, ?options = options)
        static member inline onDurationChange (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("durationchange", action, ?options = options)
        static member inline onError (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("error", action, ?options = options)
        static member inline onError (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("error", action, ?options = options)
        static member inline onFocus (action: FocusEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("focus", action, ?options = options)
        static member inline onHashChange (action: HashChangeEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("hashchange", action, ?options = options)
        static member inline onInput (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("input", action, ?options = options)
        static member inline onInvalid (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("invalid", action, ?options = options)
        static member inline onKeyDown (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("keydown", action, ?options = options)
        static member inline onKeyPress (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("keypress", action, ?options = options)
        static member inline onKeyUp (action: KeyboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("keyup", action, ?options = options)
        static member inline onLanguageChange (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("languagechange", action, ?options = options)
        static member inline onLoad (action: ProgressEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("load", action, ?options = options)
        static member inline onLoad (action: UIEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("load", action, ?options = options)
        static member inline onMessage (action: MessageEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("message", action, ?options = options)
        static member inline onMessageError (action: MessageEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("message", action, ?options = options)
        static member inline onMouseDown (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mousedown", action, ?options = options)
        static member inline onMouseEnter (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mouseenter", action, ?options = options)
        static member inline onMouseLeave (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mouseleave", action, ?options = options)
        static member inline onMouseMove (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mousemove", action, ?options = options)
        static member inline onMouseOut (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mouseout", action, ?options = options)
        static member inline onMouseOver (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mouseover", action, ?options = options)
        static member inline onMouseUp (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("mouseup", action, ?options = options)
        static member inline onOffline (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("offline", action, ?options = options)
        static member inline onOnline (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("online", action, ?options = options)
        static member inline onOrientationChange (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("orientationchange", action, ?options = options)
        static member inline onPageHide (action: PageTransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("onPageHide", action, ?options = options)
        static member inline onPageShow (action: PageTransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("onPageShow", action, ?options = options)
        static member inline onPaste (action: ClipboardEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("paste", action, ?options = options)
        static member inline onPopState (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("popstate", action, ?options = options)
        static member inline onRejectionHandled (action: PromiseRejectionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("rejectionhandled", action, ?options = options)
        static member inline onReset (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("reset", action, ?options = options)
        static member inline onResize (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("resize", action, ?options = options)
        static member inline onScroll (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("scroll", action, ?options = options)
        static member inline onSelect (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("select", action, ?options = options)
        static member inline onSelectionChange (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("selectionchange", action, ?options = options)
        static member inline onSelectStart (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("selectstart", action, ?options = options)
        static member inline onStorage (action: StorageEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("storage", action, ?options = options)
        static member inline onSubmit (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("submit", action, ?options = options)
        static member inline onTransitionCancel (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("transitioncancel", action, ?options = options)
        static member inline onTransitionEnd (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("transitionend", action, ?options = options)
        static member inline onTransitionRun (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("transitionrun", action, ?options = options)
        static member inline onTransitionStart (action: TransitionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("transitionstart", action, ?options = options)
        static member inline onUnhandledRejection (action: PromiseRejectionEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("unhandledrejection", action, ?options = options)
        static member inline onUnload (action: Event -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("unload", action, ?options = options)
        static member inline onWheel (action: MouseEvent -> unit, ?options: AddEventListenerOptions) = useWindowListener.on("wheel", action, ?options = options)