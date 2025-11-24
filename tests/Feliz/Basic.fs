module Tests.Basic

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Components =

    [<ReactComponent>]
    static member DivWithClassesAndChildren() =
        Html.div [
            prop.className "simple-div"
            prop.style [ style.backgroundColor "lightblue" ]
            prop.id "simpleDiv"
            prop.testId "simpleDiv"
            prop.onClick (fun _ -> Browser.Dom.console.log ("Div clicked!"))
            prop.children [ Html.h1 "Hello, World!"; Html.p "This is a simple div component." ]
        ]

    [<ReactComponent>]
    static member ConditionalHtmlNode(show: bool) =
        Html.div [
            if show then
                Html.h1 [ prop.testId "conditional"; prop.text "Hello, World!" ]
            Html.p [ prop.text "This is a simple div component." ]
        ]


    [<ReactComponent>]
    static member DisplayConditionalHtmlNodeTrue() =
        Html.div [ Components.ConditionalHtmlNode(true) ]

    [<ReactComponent>]
    static member DisplayConditionalHtmlNodeFalse() =
        Html.div [ Components.ConditionalHtmlNode(false) ]

    [<ReactComponent>]
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

    [<ReactComponent>]
    static member ComponentWithArgs(idBase: string, initCount: int, ?text: string, ?onClick: unit -> unit) =
        let count, setCount = React.useStateWithUpdater (initCount)
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
                        setCount (fun c -> c + 1)
                        onClick ())
                ]
                Html.p $"Count: {count}"
            ]
        ]

    [<ReactComponent>]
    static member DisplayComponentWithArgs() =
        Html.div [
            Components.ComponentWithArgs("no_optional", 0)
            Components.ComponentWithArgs(
                "with_optional",
                0,
                text = "Hello, World!",
                onClick = fun () -> Browser.Dom.console.log ("Button clicked!")
            )
        ]

    [<ReactComponent>]
    static member SVGElement() =
        Svg.svg [
            svg.viewBox (0, 0, 100, 100)
            svg.children [ Svg.circle [ svg.cx 50; svg.cy 50; svg.r 40; svg.fill "red" ] ]
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
    [<ReactComponent>]
    static member NestedSVGElement() =
        Svg.svg [
            Svg.g [
                svg.testId "test-combined-translate"
                svg.transform [
                    transform.translateX 1
                    transform.translateY 2
                    transform.translateZ (length.px 3)
                    transform.translate (11, 22)
                    transform.translate3D (111, 222, 333)
                ]
            ]
        ]

    [<ReactComponent>]
    static member SingleTupleInput1(testing: (int * string * System.Guid)) =
        let (a, b, c) = testing

        Html.div [
            Html.div [ prop.testId "int"; prop.text a ]
            Html.div [ prop.testId "string"; prop.text b ]
            Html.div [ prop.testId "guid"; prop.text c ]
        ]

    [<ReactComponent>]
    static member SingleTupleInput2(notTestingInsteadSomethingElse: (int * string * System.Guid)) =
        let (a, b, c) = notTestingInsteadSomethingElse

        Html.div [
            Html.div [ prop.testId "int"; prop.text a ]
            Html.div [ prop.testId "string"; prop.text b ]
            Html.div [ prop.testId "guid"; prop.text c ]
        ]


module PropsAliasingTesting =

    [<ReactComponent>]
    let private PropsAliasingInner (props: IReactProperty list, test: string) =
        Html.div [
            yield! props
            prop.children [
                Html.h1 "Welcome to the Fable Playground!"
                Html.p "This is a simple playground for experimenting with Fable and Feliz."
            ]
        ]

    [<ReactComponent>]
    let ArgsPropsAliasing (props: IReactProperty list) =
        Html.div [
            yield! props
            prop.children [
                PropsAliasingInner(props, "test")
                Html.h1 "Welcome to the Fable Playground!"
                Html.p "This is a simple playground for experimenting with Fable and Feliz."
            ]
        ]

    [<ReactComponent>]
    let InnerLetBindingPropsAliasing (test: string, counter: int) =

        let props = [
            prop.testId "props-aliasing"
            prop.id "props-aliasing"
            prop.style [ style.backgroundColor "lightblue" ]
        ]

        Html.div [
            yield! props
            prop.children [
                Html.h1 "Welcome to the Fable Playground!"
                Html.p "This is a simple playground for experimenting with Fable and Feliz."
            ]
        ]

module RecordTypeInputTesting =

    [<AttachMembers>]
    type private RecordTypeInput = {
        Name: string
        Job: string
    } with

        member this.Greet() =
            $"Hello, my name is {this.Name} and I work as a {this.Job}."

    let private RecordTypeCtx =
        let init = Set.empty<RecordTypeInput>
        let setter = fun (_: Set<RecordTypeInput>) -> ()
        React.createContext ({| state = init; setState = setter |})

    [<ReactComponent>]
    let private SingleRecordTypeInput (recordInput: RecordTypeInput) =
        let ctx = React.useContext RecordTypeCtx

        Html.div [
            Html.div [ prop.testId "single-greet"; prop.text (recordInput.Greet()) ]
            Html.div [
                prop.testId "single-exists"
                prop.text (ctx.state |> Set.contains recordInput |> string)
            ]
        ]

    [<ReactComponent>]
    let RecordTypeContainer () =
        let record = React.useMemo (fun () -> { Name = "Alice"; Job = "Developer" })
        let records, setRecords = React.useState (Set [ record ])

        Html.div [
            RecordTypeCtx.Provider(
                {|
                    state = records
                    setState = setRecords
                |},
                [
                    for record in records do
                        SingleRecordTypeInput(record)
                ]
            )
        ]
