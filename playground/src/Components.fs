module Components 

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Dom


// [<Erase; Mangle(false)>]
// type ReactPlayground =
//     [<Import("lazy", "react")>]
//     static member inline lazy'<'props>(load: unit -> JS.Promise<'props -> ReactElement>): LazyComponent<'props> = jsNative

//     static member inline lazyRender<'props>(lazyComponent: LazyComponent<'props>, props: 'props): ReactElement =
//         ReactLegacy.createElement(
//             unbox<ReactElement> lazyComponent,
//             props
//         )

// module Bulma =

//     module ElementBuilders =

//         module Helpers =
//             let [<Literal>] private ClassName = "className"

//             let internal getClasses (xs:IReactProperty list) =
//                 xs
//                 |> List.choose (unbox<string * obj> >> function
//                     | (k, v) when k = ClassName -> Some (string v)
//                     | _ -> None)

//             let extractClasses (xs:IReactProperty list) =
//                 xs
//                 |> List.rev
//                 |> List.fold (fun (classes, props) x ->
//                     match unbox<string * obj> x with
//                     | (k, v) when k = ClassName -> string v :: classes, props
//                     | _ -> classes, x :: props) ([], [])

//             let combineClasses cn (xs:IReactProperty list) =
//                 xs
//                 |> extractClasses
//                 |> fun (classes, props) -> (cn :: classes |> prop.classes) :: props
                
//         // module Button =
//         //     let inline props (cn:string) (xs:IReactProperty list) = Html.button (Helpers.combineClasses cn xs)
//         //     // let inline children (cn:string) (children:seq<ReactElement>) = Html.button [ prop.className cn; prop.children children ]
//         //     // let inline valueElm (cn:string) (value:ReactElement) = value |> List.singleton |> children cn
//         //     // let inline valueStr (cn:string) (value:string) = Html.button [ prop.className cn; prop.text value ]
//         //     // let inline valueInt (cn:string) (value:int) = Html.button [ prop.className cn; prop.text value ]

//     module Bulma =

//         [<Fable.Core.Erase>]
//         type button =
//             static member inline button (props: JSX.Prop list) = 
//                 JSX.create "button" (ElementBuilders.Helpers.combineClasses "button" props)
//                 |> unbox<ReactElement>
//             // static member inline button (elms:#seq<ReactElement>) = ElementBuilders.Button.children "button" elms
//             // static member inline button elm = ElementBuilders.Button.valueElm "button" elm
//             // static member inline button s = ElementBuilders.Button.valueStr "button" s
//             // static member inline button i = ElementBuilders.Button.valueInt "button" i

//     let inline mkClass (value:string) = Interop.mkAttr "className" value

//     [<Fable.Core.Erase>]
//     type button =
//         static member inline isSmall = mkClass "is-small"
//         static member inline isNormal = mkClass "is-normal"
//         static member inline isMedium = mkClass "is-medium"
//         static member inline isLarge = mkClass "is-large"
//         static member inline isFullWidth = mkClass "is-fullwidth"

// open Bulma

let LazyLoadComponent = 
    React.lazy'(fun () ->
        promise {
            do! Promise.sleep 2000
            return! Fable.Core.JsInterop.importDynamic "./LazyComponent.jsx"
        }
    )

[<Erase; Mangle(false)>]
type Components =


    [<ReactComponent>]
    static member LazyLoadStaticMember() =
        let showPreview, setShowPreview = React.useState(false)
        let text, setText = React.useState("Component loaded after 2 seconds")
        Html.div [
            Html.input [
                prop.testId "input"
                prop.value text
                prop.onChange (fun (e: string) -> setText(e))
            ]
            Html.label [
                Html.input [
                    prop.testId "checkbox"
                    prop.type' "checkbox"
                    prop.onChange (fun (e: bool) -> setShowPreview(e))
                ]
                Html.text "Load Component"
            ]
            if showPreview then
                React.Suspense(
                    fallback = Html.div [ prop.testId "loading"; prop.text "Loading..." ],
                    children = [
                        Html.h1 "Preview"
                        React.lazyRender(LazyLoadComponent, {|text = text|})
                    ]
                )
        ]

    // [<ReactComponent>]
    // static member MyButton(color: string) =
    //     let text, setText = React.useState("Click Me Please!")
    //     Html.button [
    //         prop.style [
    //             style.backgroundColor color
    //         ]
    //         prop.text text
    //         prop.onClick (fun _ -> setText("Button Clicked!"))
    //     ]

    [<ReactComponent>]
    static member Testing() =
        // let text, setText = React.useState("loading finished")
        React.StrictMode [
            // React.Fragment [
            //     Html.h1 "Bulma Playground"
            //     Components.MyButton("blue")
            //     Components.LazyLoadStaticMember()
            // ]
            Components.LazyLoadStaticMember()
        ]
