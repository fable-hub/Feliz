namespace Fable.ReactTestingLibrary

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type typeArg =
    static member inline abort = "abort"
    static member inline afterPrint = "afterprint"
    static member inline animationCancel = "animationcancel"
    static member inline animationEnd = "animationend"
    static member inline animationIteration = "animationiteration"
    static member inline animationStart = "animationstart"
    static member inline appInstalled = "appinstalled"
    static member inline audioProcess = "audioprocess"
    static member inline audioEnd = "audioend"
    static member inline audioStart = "audiostart"
    static member inline beforePrint = "beforeprint"
    static member inline beforeUnload = "beforeunload"
    static member inline beginEvent = "beginEvent"
    static member inline blocked = "blocked"
    static member inline blur = "blur"
    static member inline boundary = "boundary"
    static member inline canPlay = "canplay"
    static member inline canPlayThrough = "canplaythrough"
    static member inline change = "change"
    static member inline chargingChange = "chargingchange"
    static member inline chargingTimeChange = "chargingtimechange"
    static member inline click = "click"
    static member inline close = "close"
    static member inline complete = "complete"
    static member inline compositionEnd = "compositionend"
    static member inline compositionStart = "compositionstart"
    static member inline compositionUpdate = "compositionupdate"
    static member inline contextMenu = "contextmenu"
    static member inline copy = "copy"
    static member inline cut = "cut"
    static member inline dblClick = "dblclick"
    static member inline devicecCange = "devicechange"
    static member inline deviceMotion = "devicemotion"
    static member inline deviceOrientation = "deviceorientation"
    static member inline dischargingTimeChange = "dischargingtimechange"
    static member inline drag = "drag"
    static member inline dragEnd = "dragend"
    static member inline dragEnter = "dragenter"
    static member inline dragLeave = "dragleave"
    static member inline dragOver = "dragover"
    static member inline dragStart = "dragstart"
    static member inline drop = "drop"
    static member inline durationChange = "durationchange"
    static member inline emptied = "emptied"
    static member inline end' = "end"
    static member inline ended = "ended"
    static member inline endEvent = "endEvent"
    static member inline error = "error"
    static member inline focus = "focus"
    static member inline focusIn = "focusin"
    static member inline focusOut = "focusout"
    static member inline fullscreenChange = "fullscreenchange"
    static member inline fullscreenError = "fullscreenerror"
    static member inline gamepadConnected = "gamepadconnected"
    static member inline gamepaddDsconnected = "gamepaddisconnected"
    static member inline gotpointerCapture = "gotpointercapture"
    static member inline hashChange = "hashchange"
    static member inline lostPointerCapture = "lostpointercapture"
    static member inline input = "input"
    static member inline invalid = "invalid"
    static member inline keyDown = "keydown"
    static member inline keyUp = "keyup"
    static member inline languageChange = "languagechange"
    static member inline levelChange = "levelchange"
    static member inline load = "load"
    static member inline loadedData = "loadeddata"
    static member inline loadedMetaData = "loadedmetadata"
    static member inline loadEnd = "loadend"
    static member inline loadStart = "loadstart"
    static member inline mark = "mark"
    static member inline message = "message"
    static member inline messageError = "messageerror"
    static member inline mouseDown = "mousedown"
    static member inline mouseEnter = "mouseenter"
    static member inline mouseLeave = "mouseleave"
    static member inline mouseMove = "mousemove"
    static member inline mouseOut = "mouseout"
    static member inline mouseOver = "mouseover"
    static member inline mouseUp = "mouseup"
    static member inline noMatch = "nomatch"
    static member inline notificationClick = "notificationclick"
    static member inline offline = "offline"
    static member inline online = "online"
    static member inline open' = "open"
    static member inline orientationChange = "orientationchange"
    static member inline pageHide = "pagehide"
    static member inline pageShow = "pageshow"
    static member inline paste = "paste"
    static member inline pause = "pause"
    static member inline pointerCancel = "pointercancel"
    static member inline pointerDown = "pointerdown"
    static member inline pointerEnter = "pointerenter"
    static member inline pointerLeave = "pointerleave"
    static member inline pointerLockchange = "pointerlockchange"
    static member inline pointerLockerror = "pointerlockerror"
    static member inline pointerMove = "pointermove"
    static member inline pointerOut = "pointerout"
    static member inline pointerOver = "pointerover"
    static member inline pointerUp = "pointerup"
    static member inline play = "play"
    static member inline playing = "playing"
    static member inline popState = "popstate"
    static member inline progress = "progress"
    static member inline push = "push"
    static member inline pushSubscriptionChange = "pushsubscriptionchange"
    static member inline rateChange = "ratechange"
    static member inline readyStateChange = "readystatechange"
    static member inline repeatEvent = "repeatEvent"
    static member inline reset = "reset"
    static member inline resize = "resize"
    static member inline resourceTimingBufferFull = "resourcetimingbufferfull"
    static member inline result = "result"
    static member inline resume = "resume"
    static member inline scroll = "scroll"
    static member inline seeked = "seeked"
    static member inline seeking = "seeking"
    static member inline select = "select"
    static member inline selectStart = "selectstart"
    static member inline selectiOnchange = "selectionchange"
    static member inline show = "show"
    static member inline slotChange = "slotchange"
    static member inline soundEnd = "soundend"
    static member inline soundStart = "soundstart"
    static member inline speechEnd = "speechend"
    static member inline speechStart = "speechstart"
    static member inline stalled = "stalled"
    static member inline start = "start"
    static member inline storage = "storage"
    static member inline submit = "submit"
    static member inline success = "success"
    static member inline suspend = "suspend"
    static member inline svgAbort = "SVGAbort"
    static member inline svgError = "SVGError"
    static member inline svgLoad = "SVGLoad"
    static member inline svgResize = "SVGResize"
    static member inline svgScroll = "SVGScroll"
    static member inline svgUnload = "SVGUnload"
    static member inline svgZoom = "SVGZoom"
    static member inline timeout = "timeout"
    static member inline timeUpdate = "timeupdate"
    static member inline touchCancel = "touchcancel"
    static member inline touchEnd = "touchend"
    static member inline touchMove = "touchmove"
    static member inline touchStart = "touchstart"
    static member inline transitionEnd = "transitionend"
    static member inline unload = "unload"
    static member inline upgradeNeeded = "upgradeneeded"
    static member inline userProximity = "userproximity"
    static member inline voicesChanged = "voiceschanged"
    static member inline versionChange = "versionchange"
    static member inline visibilityChange = "visibilitychange"
    static member inline volumeChange = "volumechange"
    static member inline waiting = "waiting"
    static member inline wheel = "wheel"

type event =
    static member bubbles (value: bool) = Interop.mkEventAttr "bubbles" value
    static member cancelBubble (value: bool) = Interop.mkEventAttr "cancelBubble" value
    static member cancelable (value: bool) = Interop.mkEventAttr "cancelable" value
    static member composed (value: bool) = Interop.mkEventAttr "composed" value
    static member currentTarget (value: obj) = Interop.mkEventAttr "currentTarget" value
    static member defaultPrevented (value: bool) = Interop.mkEventAttr "defaultPrevented" value
    static member isTrusted (value: bool) = Interop.mkEventAttr "isTrusted" value
    static member returnValue (value: bool) = Interop.mkEventAttr "returnValue" value
    static member target (properties: IReactProperty list) = Interop.mkEventAttr "target" (createObj !!properties)
    static member timeStamp (value: int) = Interop.mkEventAttr "timeStamp" value
    static member type' (value: string) = Interop.mkEventAttr "type" value

module event =
    type eventPhase =
        static member atTarget = Interop.mkEventAttr "eventPhase" 2
        static member bubblingPhase = Interop.mkEventAttr "eventPhase" 3
        static member capturingPhase = Interop.mkEventAttr "eventPhase" 1
        static member none = Interop.mkEventAttr "eventPhase" 0

type animationEvent =
    inherit event
    static member animationName (value: string) = Interop.mkAnimationEventAttr "animationName" value
    static member elapsedTime (value: float) = Interop.mkAnimationEventAttr "elapsedTime" value
    static member pseudoElement (value: string) = Interop.mkAnimationEventAttr "pseudoElement" value

module animationEvent =
    type type' =
        static member animationEnd = Interop.mkAnimationEventAttr "type" "animationend"
        static member animationIteration = Interop.mkAnimationEventAttr "type" "animationiteration"
        static member animationStart = Interop.mkAnimationEventAttr "type" "animationstart"
        
type clipboardEvent =
    inherit event
    static member clipboardData (properties: DataTransfer) = Interop.mkClipboardEventAttr "clipboardData" (createObj !!properties)
    
type hashEvent =
    inherit event
    static member newUrl (value: string) = Interop.mkClipboardEventAttr "newURL" value
    static member oldUrl (value: string) = Interop.mkClipboardEventAttr "oldURL" value

type messageEvent =
    inherit event
    static member data (value: 'T) = Interop.mkClipboardEventAttr "data" value
    static member origin (value: string) = Interop.mkClipboardEventAttr "origin" value
    static member lastEventId (value: string) = Interop.mkClipboardEventAttr "lastEventId" value
    static member source (value: Window) = Interop.mkClipboardEventAttr "source" value
    //static member source (value: Worker) = Interop.mkClipboardEventAttr "source" value
    //static member source (value: AbstractWorker) = Interop.mkClipboardEventAttr "source" value
    //static member ports (value: Worker) = Interop.mkClipboardEventAttr "ports" value
    
type pageTransitionEvent =
    inherit event
    static member persisted (value: bool) = Interop.mkPageTransitionEventAttr "persisted" value
        
type progressEvent =
    inherit event
    static member lengthComputable (value: bool) = Interop.mkProgressEventAttr "lengthComputable" value
    static member loaded (value: int) = Interop.mkPageTransitionEventAttr "loaded" value
    static member total (value: int) = Interop.mkPageTransitionEventAttr "total" value

type storageEvent =
    inherit event
    static member key (value: string) = Interop.mkStorageEventAttr "key" value
    static member newValue (value: string) = Interop.mkStorageEventAttr "newValue" value
    static member oldValue (value: string) = Interop.mkStorageEventAttr "oldValue" value
    static member storageArea (value: Storage) = Interop.mkStorageEventAttr "storageArea" value
    static member url (value: string) = Interop.mkStorageEventAttr "url" value

type transitionEvent =
    inherit event
    static member propertyName (value: string) = Interop.mkTransitionEventAttr "propertyName" value
    static member elapsedTime (value: float) = Interop.mkTransitionEventAttr "elapsedTime" value
    static member pseudoElement (value: string) = Interop.mkTransitionEventAttr "pseudoElement" value

type uiEvent =
    inherit event
    static member detail (value: int) = Interop.mkUIEventAttr "detail" value
    static member view (value: Window) = Interop.mkUIEventAttr "view" value
    
type compositionEvent =
    static member locale (value: string) = Interop.mkCompositionEventAttr "locale" value

module compositionEvent =
    type data =
        static member compositionEnd = Interop.mkCompositionEventAttr "data" "compositionend"
        static member compositionStart = Interop.mkCompositionEventAttr "data" "compositionstart"
        static member compositionUpdate = Interop.mkCompositionEventAttr "data" "compositionupdate"

type focusEvent =
    inherit uiEvent
    static member relatedTarget (value: Element) = Interop.mkFocusEventAttr "relatedTarget" value
    static member relatedTarget (value: Document) = Interop.mkFocusEventAttr "relatedTarget" value
    static member relatedTarget (value: Window) = Interop.mkFocusEventAttr "relatedTarget" value
    static member relatedTarget (value: HTMLElement) = Interop.mkFocusEventAttr "relatedTarget" value
    static member relatedTarget (value: #EventTarget) = Interop.mkFocusEventAttr "relatedTarget" value

type inputEvent =
    inherit uiEvent
    static member inputType (value: string) = Interop.mkInputEventAttr "inputType" value
    static member data (value: string) = Interop.mkInputEventAttr "data" value
    static member dataTransfer (value: DataTransfer) = Interop.mkInputEventAttr "dataTransfer" value
    static member isComposing (value: bool) = Interop.mkInputEventAttr "isComposing" value
    static member ranges (value: seq<Range>) = Interop.mkInputEventAttr "ranges" (ResizeArray value)

type keyboardEvent =
    inherit uiEvent
    static member altKey (value: bool) = Interop.mkKeyboardEventAttr "altKey" value
    static member charCode (value: int) = Interop.mkKeyboardEventAttr "charCode" value
    static member code (value: string) = Interop.mkKeyboardEventAttr "code" value
    static member ctrlKey (value: bool) = Interop.mkKeyboardEventAttr "ctrlKey" value
    static member isComposing (value: bool) = Interop.mkKeyboardEventAttr "isComposing" value
    static member key (value: string) = Interop.mkKeyboardEventAttr "key" value
    static member keyCode (value: int) = Interop.mkKeyboardEventAttr "keyCode" value
    static member locale (value: string) = Interop.mkKeyboardEventAttr "locale" value
    static member location (value: int) = Interop.mkKeyboardEventAttr "location" value
    static member metaKey (value: bool) = Interop.mkKeyboardEventAttr "metaKey" value
    static member repeat (value: bool) = Interop.mkKeyboardEventAttr "repeat" value
    static member shiftKey (value: bool) = Interop.mkKeyboardEventAttr "shiftKey" value
    static member which (value: int) = Interop.mkKeyboardEventAttr "which" value
    
type touchEvent =
    inherit uiEvent
    static member touches (value: #seq<Touch>) = Interop.mkTouchEventAttr "touches" (ResizeArray value)
    static member targetTouches (value: #seq<Touch>) = Interop.mkTouchEventAttr "targetTouches" (ResizeArray value)
    static member changedTouches (value: #seq<Touch>) = Interop.mkTouchEventAttr "changedTouches" (ResizeArray value)
    static member ctrlKey (value: bool) = Interop.mkTouchEventAttr "ctrlKey" value
    static member shiftKey (value: bool) = Interop.mkTouchEventAttr "shiftKey" value
    static member altKey (value: bool) = Interop.mkTouchEventAttr "altKey" value
    static member metaKey (value: bool) = Interop.mkTouchEventAttr "metaKey" value

type mouseEvent =
    inherit uiEvent
    static member altKey (value: bool) = Interop.mkMouseEventAttr "altKey" value
    static member button (value: int) = Interop.mkMouseEventAttr "button" value
    static member buttons (value: int) = Interop.mkMouseEventAttr "buttons" value
    static member clientX (value: int) = Interop.mkMouseEventAttr "clientX" value
    static member clientY (value: int) = Interop.mkMouseEventAttr "clientY" value
    static member ctrlKey (value: bool) = Interop.mkMouseEventAttr "ctrlKey" value
    static member movementX (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member movementY (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member offsetX (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member offsetY (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member pageX (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member pageY (value: bool) = Interop.mkMouseEventAttr "metaKey" value
    static member region (value: string) = Interop.mkMouseEventAttr "region" value
    static member relatedTarget (value: Element) = Interop.mkMouseEventAttr "relatedTarget" value
    static member relatedTarget (value: Document) = Interop.mkMouseEventAttr "relatedTarget" value
    static member relatedTarget (value: Window) = Interop.mkMouseEventAttr "relatedTarget" value
    static member relatedTarget (value: HTMLElement) = Interop.mkMouseEventAttr "relatedTarget" value
    static member relatedTarget (value: #EventTarget) = Interop.mkMouseEventAttr "relatedTarget" value
    static member screenX (value: int) = Interop.mkMouseEventAttr "screenX" value
    static member screenY (value: int) = Interop.mkMouseEventAttr "screenY" value
    static member shiftKey (value: bool) = Interop.mkMouseEventAttr "shiftKey" value

type dragEvent =
    inherit mouseEvent
    static member dataTransfer (value: DataTransfer) = Interop.mkDragEventAttr "dataTransfer" value

type pointerEvent =
    inherit mouseEvent
    static member pointerId (value: int) = Interop.mkPointerEventAttr "pointerId" value
    static member width (value: int) = Interop.mkPointerEventAttr "width" value
    static member height (value: int) = Interop.mkPointerEventAttr "height" value
    static member pressure (value: float) = Interop.mkPointerEventAttr "pressure" value
    static member tangentialPressure (value: float) = Interop.mkPointerEventAttr "tangentialPressure" value
    static member tiltX (value: int) = Interop.mkPointerEventAttr "tiltX" value
    static member tiltY (value: int) = Interop.mkPointerEventAttr "tiltY" value
    static member twist (value: int) = Interop.mkPointerEventAttr "twist" value
    static member pointerType (value: string) = Interop.mkPointerEventAttr "pointerType" value
    static member isPrimary (value: bool) = Interop.mkPointerEventAttr "isPrimary" value
    
