namespace Fable.ReactTestingLibrary

[<AutoOpen>]
module Types =
    type IConfigureOption = interface end
    type IConfigureOptions = interface end
    type IMutationObserverOption = interface end
    type IPrettyDOMOption = interface end
    type IPrettyDOMOptions = interface end
    type IPrettyDOMThemeOption = interface end
    type IWaitOption = interface end
    type IWaitOptions = interface end
    
    [<AutoOpen>]
    module Queries =
        type IRoleMatcherOption = interface end
        type ITextMatcherOption = interface end
        type ILabelTextMatcherOption = inherit ITextMatcherOption
        type IMatcherOption = 
            inherit ILabelTextMatcherOption
            inherit ITextMatcherOption
            inherit IRoleMatcherOption

    [<AutoOpen>]
    module Events =
        type ICompositionEventProperty = interface end
        type IDragEventProperty = interface end
        type IFocusEventProperty = interface end
        type IInputEventProperty = interface end
        type IKeyboardEventProperty = interface end
        type IPointerEventProperty = interface end
        type IMouseEventProperty = 
            inherit IDragEventProperty
            inherit IPointerEventProperty
        type ITouchEventProperty = interface end
        type IUIEventProperty = 
            inherit ICompositionEventProperty
            inherit IFocusEventProperty
            inherit IInputEventProperty
            inherit IKeyboardEventProperty
            inherit IMouseEventProperty
            inherit ITouchEventProperty
        type ITransitionEventProperty = interface end
        type IStorageEventProperty = interface end
        type IProgressEventProperty = interface end
        type IPageTransitionEventProperty = interface end
        type IMessageEventProperty = interface end
        type IHashEventProperty = interface end
        type IClipboardEventProperty = interface end
        type IAnimationEventProperty = interface end
        type IEventProperty = 
            inherit IAnimationEventProperty
            inherit IClipboardEventProperty
            inherit IHashEventProperty
            inherit IMessageEventProperty
            inherit IPageTransitionEventProperty
            inherit IProgressEventProperty
            inherit IStorageEventProperty
            inherit ITransitionEventProperty
            inherit IUIEventProperty