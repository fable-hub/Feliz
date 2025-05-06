namespace Feliz.Delay

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open System.ComponentModel

[<AutoOpen>]
module Delay =
    [<AutoOpen;EditorBrowsable(EditorBrowsableState.Never);Erase>]
    module Types =
        type IDelayProperty = interface end
        type IDelaySuspenseProperty = interface end

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        type DelayProps =
            abstract children: ReactElement
            abstract waitFor: int option
            abstract fallback: ReactElement option
    
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        type DelaySuspenseProps =
            abstract children: ReactElement list
            abstract delay: DelayProps option

    [<Erase;EditorBrowsable(EditorBrowsableState.Never);RequireQualifiedAccess>]
    module Interop =
        [<EditorBrowsable(EditorBrowsableState.Never)>]
        let inline mkDelayAttr (key: string) (value: obj) = unbox<IDelayProperty>(key, value)

        [<EditorBrowsable(EditorBrowsableState.Never)>]
        let inline mkDelaySuspenseAttr (key: string) (value: obj) = unbox<IDelaySuspenseProperty>(key, value)
    
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    let delayComp = React.functionComponent(fun (input: DelayProps) ->
        let ct = React.useCancellationToken()
        let timeElapsed,setTimeElapsed = React.useState false
        let setTimeElapsed = React.useCallbackRef(setTimeElapsed)

        React.useEffectOnce(fun () ->
            async {
                do! Async.Sleep (Option.defaultValue 100 input.waitFor)

                setTimeElapsed true
            }
            |> fun a -> Async.StartImmediate(a, ct.current)
        )

        if timeElapsed then input.children
        else Option.defaultValue Html.none input.fallback)
    
    [<EditorBrowsable(EditorBrowsableState.Never)>]
    #if FABLE_COMPILER
    let inline delaySuspenseComp (input: DelaySuspenseProps) =
    #else
    let delaySuspenseComp (input: DelaySuspenseProps) =
    #endif
        #if DEBUG
        if input.children.IsEmpty then 
            JS.console.error("No elements provided to React.delayedSuspense!", input)
        #endif

        Option.defaultValue  (unbox {| children = Html.none |}) input.delay
        |> fun delayProps -> React.suspense(input.children, fallback = delayComp delayProps)

    [<Erase>]
    type delay =
        /// Element that will be displayed after the delay.
        static member inline children (element: ReactElement) = Interop.mkDelayAttr "children" element
        /// Elements that will be displayed after the delay.
        static member inline children (elements: ReactElement list) = Interop.mkDelayAttr "children" (React.fragment elements)
        
        /// Time in ms to wait before displaying the children.
        ///
        /// Defaults to 100 ms.
        static member inline waitFor (value: int) = Interop.mkDelayAttr "waitFor" value
        
        /// Element to render for the duration of the delay.
        ///
        /// Defaults to Html.none.
        static member inline fallback (element: ReactElement) = Interop.mkDelayAttr "fallback" element
        /// Elements to render for the duration of the delay.
        ///
        /// Defaults to Html.none.
        static member inline fallback (elements: ReactElement list) = Interop.mkDelayAttr "fallback" (React.fragment elements)

    [<Erase>]
    type delaySuspense =
        /// The elements to render when the suspense and delay resolves.
        static member inline children (elements: ReactElement list) = Interop.mkDelaySuspenseAttr "children" elements
        
        /// Properties to forward to the delay fallback component.
        static member inline delay (properties: IDelayProperty list) = Interop.mkDelaySuspenseAttr "delay" (createObj !!properties)
        /// Properties to forward to the delay fallback component.
        static member inline delay (elements: ReactElement list) = delaySuspense.delay [ delay.children elements ]

    type React with
        /// <summary>
        /// Delays rendering the children of this component for a given period of time.
        /// 
        /// Optionally renders a provided component instead for that duration.
        /// </summary>
        /// <param name='properties'>The properties for the React.delay component.</param>
        static member inline delay (properties: IDelayProperty list) = delayComp (unbox<DelayProps>(createObj !!properties))
        /// <summary>
        /// Delays rendering the children of this component for 100ms, rendering nothing for the duration.
        /// </summary>
        /// <param name='children'>The components to render inside the React.delay component.</param>
        static member inline delay (children: ReactElement list) = React.delay [ delay.children children ]
    
        /// <summary>
        /// React.suspense that uses the React.delay component as the fallback.
        /// </summary>
        /// <param name='properties'>The properties for the React.delaySuspense component.</param>
        static member inline delaySuspense (properties: IDelaySuspenseProperty list) = delaySuspenseComp (unbox<DelaySuspenseProps>(createObj !!properties))
        /// <summary>
        /// React.suspense that uses the React.delay component as the fallback.
        /// </summary>
        /// <param name='children'>The components to render inside the React.suspense component.</param>
        static member inline delaySuspense (children: ReactElement list) =
            React.delaySuspense [ delaySuspense.children children ]
        /// <summary>
        /// React.suspense that uses the React.delay component as the fallback.
        /// </summary>
        /// <param name='children'>The components to render inside the React.suspense component.</param>
        /// <param name='fallback'>The fallback component to render *after* the delay.</param>
        static member inline delaySuspense (children: ReactElement list, fallback: ReactElement) =
            React.delaySuspense [
                delaySuspense.children children 

                delaySuspense.delay [
                    fallback
                ]
            ]
