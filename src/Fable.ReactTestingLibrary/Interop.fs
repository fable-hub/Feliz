namespace Fable.ReactTestingLibrary

[<RequireQualifiedAccess>]
module Interop =
    let mkConfigureOption (key: string) (value: obj) : IConfigureOption = unbox (key, value)
    let mkMutationObserverOption (key: string) (value: obj) : IMutationObserverOption = unbox (key, value)
    let mkPrettyDOMOption (key: string) (value: obj) : IPrettyDOMOption = unbox (key, value)
    let mkPrettyDOMOThemeption (key: string) (value: obj) : IPrettyDOMThemeOption = unbox (key, value)
    let mkWaitOption (key: string) (value: obj) : IWaitOption = unbox (key, value)

    // Queries
    let mkLabelTextMatcherOption (key: string) (value: obj) : ILabelTextMatcherOption = unbox (key, value)
    let mkRoleMatcherOption (key: string) (value: obj) : IRoleMatcherOption = unbox (key, value)
    let mkTextMatcherOption (key: string) (value: obj) : ITextMatcherOption = unbox (key, value)
    let mkMatcherOption (key: string) (value: obj) : IMatcherOption = unbox (key, value)

    // Events
    let mkAnimationEventAttr (key: string) (value: obj) : IAnimationEventProperty = unbox (key, value)
    let mkClipboardEventAttr (key: string) (value: obj) : IClipboardEventProperty = unbox (key, value)
    let mkCompositionEventAttr (key: string) (value: obj) : ICompositionEventProperty = unbox (key, value)
    let mkDragEventAttr (key: string) (value: obj) : IDragEventProperty = unbox (key, value)
    let mkEventAttr (key: string) (value: obj) : IEventProperty = unbox (key, value)
    let mkFocusEventAttr (key: string) (value: obj) : IFocusEventProperty = unbox (key, value)
    let mkHashEventAttr (key: string) (value: obj) : IHashEventProperty = unbox (key, value)
    let mkInputEventAttr (key: string) (value: obj) : IInputEventProperty = unbox (key, value)
    let mkKeyboardEventAttr (key: string) (value: obj) : IKeyboardEventProperty = unbox (key, value)
    let mkMessageEventAttr (key: string) (value: obj) : IMessageEventProperty = unbox (key, value)
    let mkMouseEventAttr (key: string) (value: obj) : IMouseEventProperty = unbox (key, value)
    let mkPageTransitionEventAttr (key: string) (value: obj) : IPageTransitionEventProperty = unbox (key, value)
    let mkPointerEventAttr (key: string) (value: obj) : IPointerEventProperty = unbox (key, value)
    let mkProgressEventAttr (key: string) (value: obj) : IProgressEventProperty = unbox (key, value)
    let mkStorageEventAttr (key: string) (value: obj) : IStorageEventProperty = unbox (key, value)
    let mkTouchEventAttr (key: string) (value: obj) : ITouchEventProperty = unbox (key, value)
    let mkTransitionEventAttr (key: string) (value: obj) : ITransitionEventProperty = unbox (key, value)
    let mkUIEventAttr (key: string) (value: obj) : IUIEventProperty = unbox (key, value)
        