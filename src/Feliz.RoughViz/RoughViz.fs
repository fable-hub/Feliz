namespace Feliz.RoughViz

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Types

type IResizeObserver =
    abstract observe : HTMLElement -> unit
    abstract unobserve : HTMLElement -> unit

type IContentRect =
    abstract width : float
    abstract height : float

type IObserverEntry =
    abstract contentRect : IContentRect

module internal Interop =
    [<Emit("Object.assign({}, $0, $1)")>]
    let objectAssign (x: obj) (y: obj) = jsNative
    let createBarChart (config: obj) : unit = import "createBarChart" "./createChart.js"
    let createHorizontalBarChart (config: obj) : unit = import "createHorizontalBarChart" "./createChart.js"
    let createPieChart (config: obj) : unit = import "createPieChart" "./createChart.js"
    [<Emit("new ResizeObserver($0)")>]
    let createResizeObserver(handler: IObserverEntry array -> unit) : IResizeObserver = jsNative

[<RequireQualifiedAccess>]
module RoughViz =
    [<StringEnum>]
    type private ChartType =
        | Bar
        | HorizontalBar
        | Pie

    let private buildChart = React.functionComponent("RoughViz", fun (props: {| chartType: ChartType; config: obj list |}) ->
        let elementId = React.useRef("RoughViz" + (Guid.NewGuid().ToString().Substring(10)))
        let rerendered, setRerendered = React.useState(false)
        let elementRef = React.useElementRef()
        let parentWidth, setParentWidth = React.useState(None)
        let observer = React.useRef(Interop.createResizeObserver(fun entries ->
                for entry in entries do setParentWidth(Some entry.contentRect.width)
            )
        )

        React.useEffect((fun () ->
            match elementRef.current with
            | None -> ()
            | Some element ->
                let emptyData = toPlainJsObj {| labels = [||]; values = [||] |}
                let defaultConfig = toPlainJsObj {| element = "#" + elementId.current; data = emptyData; width = element.clientWidth |}
                let config = Interop.objectAssign defaultConfig (createObj (unbox props.config))

                match props.chartType with
                | Bar -> Interop.createBarChart config
                | HorizontalBar -> Interop.createHorizontalBarChart config
                | Pie -> Interop.createPieChart config

                observer.current.observe element

            React.createDisposable(fun () ->
                match elementRef.current with
                | None -> ()
                | Some element ->
                    observer.current.unobserve element
                    while not (isNullOrUndefined element.firstChild) do 
                        element.removeChild(element.firstChild)
                        |> ignore
                )
            ),

            [| box rerendered; box props |]
        )

        React.useEffect((fun () ->
                parentWidth |> Option.iter (fun _ -> setRerendered(not rerendered))
            ),
            [| box parentWidth |]
        )

        React.useEffect((fun () ->
            match elementRef.current with
            | None -> ()
            | Some _ ->
                let pairs = unbox<(string * obj) list> props.config
                let barClickedHandler = pairs |> List.tryFind (fun (key, value) -> key = "barClicked")
                match barClickedHandler with 
                | None -> () 
                | Some (key, barClicked) -> 
                    let handler = unbox<int -> unit> barClicked
                    let bars = Browser.Dom.document.getElementsByClassName(elementId.current)
                    for barIndex in [0 .. bars.length - 1] do
                        let barHtml = unbox<HTMLElement> bars.[barIndex]
                        barHtml.addEventListener("click", fun _ -> handler barIndex)

            React.createDisposable(fun () -> 
                let bars = Browser.Dom.document.getElementsByClassName(elementId.current)
                for barIndex in [0 .. bars.length - 1] do
                    let barHtml = unbox<HTMLElement> bars.[barIndex]
                    barHtml.removeEventListener("click", fun _ -> ()) |> ignore
            )),

            [| box rerendered; box props |]
        );

        Html.div [
            prop.id elementId.current
            prop.ref elementRef
            prop.style [ style.width (length.percent 100) ]
        ])

    let barChart (properties: IBarChartProperty list) = buildChart {| chartType = Bar; config = unbox properties |}

    let horizontalBarChart (properties: IBarChartProperty list) = buildChart {| chartType = HorizontalBar; config = unbox properties |}

    let pieChart (properties: IPieChartProperty list) = buildChart {| chartType = Pie; config = unbox properties |}
