namespace Feliz.Delay.Templates

open Fable.Core
open Feliz
open Feliz.Delay

[<Erase;RequireQualifiedAccess>]
module React =
    type Templates =
        /// <summary>
        /// Helper function that allows you to create a custom React.delay component via currying.
        /// </summary>
        /// <param name='properties'>The properties for the React.delay component.</param>
        /// <param name='children'>
        /// The components to render inside the React.delay component.
        /// 
        /// This will override a declaration of delay.children in the template.
        /// </param>
        static member inline delay (properties: IDelayProperty list) (children: ReactElement list) =
            React.delay [
                yield! properties

                delay.children children
            ]

        /// <summary>
        /// Helper function that allows you to create a custom React.delaySuspense component via currying.
        /// </summary>
        /// <param name='properties'>The properties for the React.delay component.</param>
        /// <param name='children'>The components to render inside the React.suspense component.</param>
        static member inline delaySuspense (delayProperties: IDelayProperty list) (children: ReactElement list) = 
            React.delaySuspense [
                delaySuspense.children children

                delaySuspense.delay delayProperties
            ]
