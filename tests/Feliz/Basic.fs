module Tests.Basic

open Fable.Core
open Feliz


[<Erase; Mangle(false)>]
type Components =

    [<JSX.Component>]
    static member DivWithClassesAndChildren() =
        Html.div [
            prop.className "simple-div"
            prop.style [ style.backgroundColor "lightblue" ]
            prop.id "simpleDiv"
            prop.testId "simpleDiv"
            prop.onClick (fun _ -> Browser.Dom.console.log("Div clicked!"))
            prop.children [
                Html.h1 "Hello, World!"
                Html.p "This is a simple div component."
            ]
        ]

    [<JSX.Component>]
    static member ConditionalHtmlNode(show: bool) =
        Html.div [
            if show then    
                Html.h1 [
                    prop.testId "conditional"
                    prop.text "Hello, World!"
                ] 
            Html.p [
                prop.text "This is a simple div component."
            ]
        ]


    [<JSX.Component>]
    static member DisplayConditionalHtmlNodeTrue() =
        Html.div [
            Components.ConditionalHtmlNode(true)
        ]

    [<JSX.Component>]
    static member DisplayConditionalHtmlNodeFalse() =
        Html.div [
            Components.ConditionalHtmlNode(false)
        ]

    [<JSX.Component>]
    static member ComponentWithSubcomponent() =
        Html.div [
            prop.id "simpleDiv"
            prop.testId "simpleDiv"
            prop.children [
                Html.h1 "Hello, World!"
                Html.p "This is a simple div component."
                Components.DivWithClassesAndChildren()
            ]
        ]

    [<JSX.Component>]
    static member ComponentWithArgs(idBase: string, initCount: int, ?text: string, ?onClick: unit -> unit) =
        let count, setCount = React.useStateWithUpdater(initCount)
        let text = defaultArg text "Default Text"
        let onClick = defaultArg onClick (fun () -> ())
        Html.div [
            prop.id (idBase + "simpleDiv")
            prop.testId (idBase + "simpleDiv")
            prop.children [
                Html.h1 text
                Html.button [
                    prop.text "Increment"
                    prop.onClick (fun _ ->
                        setCount(fun c -> c + 1)
                        onClick())
                ]
                Html.p $"Count: {count}"
            ]
        ]

    [<JSX.Component>]
    static member DisplayComponentWithArgs() =
        Html.div [
            Components.ComponentWithArgs("no_optional", 0)
            Components.ComponentWithArgs("with_optional", 0, text = "Hello, World!", onClick = fun () -> Browser.Dom.console.log("Button clicked!"))
        ]

    [<JSX.Component>]
    static member SVGElement() =
        Svg.svg [
            svg.viewBox (0, 0, 100, 100)
            svg.children [
                Svg.circle [
                    svg.cx 50
                    svg.cy 50
                    svg.r 40
                    svg.fill "red"
                ]
            ]
        ]

    /// ```fsharp
    /// // This is allowed:
    /// static member inline transform (transforms: seq<ITransformProperty>) =
    ///     transforms
    ///     |> unbox<seq<string>>
    ///     |> Seq.map (fun transform -> transform.Replace("px", "").Replace("deg", ""))
    ///     |> String.concat " "
    ///     |> Interop.svgAttribute "transform" 
    /// ```
    /// 
    /// ```fsharp
    /// // This fails:
    /// static member inline transform (transforms: seq<ITransformProperty>) =
    ///     let removedUnits =
    ///         transforms
    ///         |> unbox<seq<string>>
    ///         |> Seq.map (fun transform -> transform.Replace("px", "").Replace("deg", ""))
    ///         |> String.concat " "
    ///
    ///     Interop.svgAttribute "transform" removedUnits
    /// ```
    /// 
    [<JSX.Component>]
    static member NestedSVGElement() =
        Svg.svg [
            Svg.g [
                svg.testId "test-combined-translate"
                svg.transform [
                    transform.translateX 1
                    transform.translateY 2
                    transform.translateZ (length.px 3)
                    transform.translate(11, 22)
                    transform.translate3D(111, 222, 333)
                ]
            ]
        ]

    // [<JSX.Component>]
    // static member ConditionalProperty(?condition: bool) =
    //     Html.div [
    //         if condition.IsSome && condition.Value then
    //             prop.className "conditional-class"
    //             prop.onClick (fun _ -> Browser.Dom.console.log("Div clicked!"))
    //         prop.children [
    //             Html.div "Hello, World!"
    //         ]
    //     ]
