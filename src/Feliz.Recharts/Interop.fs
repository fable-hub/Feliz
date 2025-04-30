namespace Feliz.Recharts

open Fable.Core

[<Erase;RequireQualifiedAccess>]
module Interop =
    [<Emit("Object.keys($0)")>]
    let internal objectKeys (x: obj) = jsNative
    let objectHas (keys: string list) (x: obj) =
        objectKeys(x)
        |> Seq.toList
        |> (=) keys

    let inline mkLineChartAttr (key: string) (value: obj) : ILineChartProperty = unbox (key, value)
    let inline mkLineAttr (key: string) (value: obj) : ILineProperty = unbox (key, value)
    let inline mkPieAttr (key: string) (value: obj) : IPieProperty = unbox (key, value)
    let inline mkPieChartAttr (key: string) (value: obj) : IPieChartProperty = unbox (key, value)
    let inline mkBarAttr (key: string) (value: obj) : IBarProperty = unbox (key, value)
    let inline mkRadarAttr (key: string) (value: obj) : IRadarProperty = unbox (key, value)
    let inline mkScatterAttr (key: string) (value: obj) : IScatterProperty = unbox (key, value)
    let inline mkScatterChartAttr (key: string) (value: obj): IScatterChartProperty = unbox (key, value)
    let inline mkBarChartAttr (key: string) (value: obj) : IBarChartProperty = unbox (key, value)
    let inline mkAreaAttr (key: string) (value: obj) : IAreaProperty = unbox (key, value)
    let inline mkAreaChartAttr (key: string) (value: obj) : IAreaChartProperty = unbox (key, value)
    let inline mkRadarChartAttr (key: string) (value: obj) : IRadarChartProperty = unbox (key, value)
    let inline mkBrushAttr (key: string) (value: obj) : IBrushProperty = unbox (key, value)
    let inline mkCartesianGridAttr (key: string) (value: obj) : ICartesianGridProperty = unbox (key, value)
    let inline mkCellAttr (key: string) (value: obj) : ICellProperty = unbox (key, value)
    let inline mkComposedChartAttr (key: string) (value: obj) : IComposedChartProperty = unbox (key, value)
    let inline mkLabelAttr (key: string) (value: obj) : ILabelProperty = unbox (key, value)
    let inline mkLabelListAttr (key: string) (value: obj) : ILabelListProperty = unbox (key, value)
    let inline mkLegendAttr (key: string) (value: obj) : ILegendProperty = unbox (key, value)
    let inline mkRadialBarChartAttr (key: string) (value: obj) : IRadialBarChartProperty = unbox (key, value)
    let inline mkRadialBarAttr (key: string) (value: obj) : IRadialBarProperty = unbox (key, value)
    let inline mkReferenceAreaAttr (key: string) (value: obj) : IReferenceAreaProperty = unbox (key, value)
    let inline mkReferenceDotAttr (key: string) (value: obj) : IReferenceDotProperty = unbox (key, value)
    let inline mkReferenceLineAttr (key: string) (value: obj) : IReferenceLineProperty = unbox (key, value)
    let inline mkResponsiveContainerAttr (key: string) (value: obj) : IResponsiveContainerProperty = unbox (key, value)
    let inline mkTextAttr (key: string) (value: obj) : ITextProperty = unbox (key, value)
    let inline mkXAxisAttr (key: string) (value: obj) : IXAxisProperty = unbox (key, value)
    let inline mkYAxisAttr (key: string) (value: obj) : IYAxisProperty = unbox (key, value)
    let inline mkPolarAngleAxisAttr (key: string) (value: obj) : IPolarAngleAxisProperty = unbox (key, value)
    let inline mkPolarRadiusAxisAttr (key: string) (value: obj) : IPolarRadiusAxisProperty = unbox (key, value)
    let inline mkPolarGridAttr (key:string) (value:obj) : IPolarGridProperty = unbox(key, value)
    let inline mkTooltipAttr (key:string) (value:obj) : ITooltipProperty = unbox(key, value)
    let inline mkErrorBarAttr (key:string) (value:obj) : IErrorBarProperty = unbox(key, value)
    let inline mkFunnelAttr (key:string) (value:obj) : IFunnelProperty = unbox(key, value)
