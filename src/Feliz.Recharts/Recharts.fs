namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type Recharts =
    static member inline areaChart (properties: IAreaChartProperty list) =
        Interop.reactApi.createElement(import "AreaChart" "recharts", createObj !!properties)
    static member inline lineChart (properties: ILineChartProperty list) =
        Interop.reactApi.createElement(import "LineChart" "recharts", createObj !!properties)
    static member inline barChart (properties: IBarChartProperty list) =
        Interop.reactApi.createElement(import "BarChart" "recharts", createObj !!properties)
    static member inline pieChart (properties: IPieChartProperty list) =
        Interop.reactApi.createElement(import "PieChart" "recharts", createObj !!properties)
    static member inline radarChart (properties: IRadarChartProperty list) =
        Interop.reactApi.createElement(import "RadarChart" "recharts", createObj !!properties)
    static member inline radialBarChart (properties: IRadialBarChartProperty list) =
        Interop.reactApi.createElement(import "RadialBarChart" "recharts", createObj !!properties)
    static member inline funnelChart (properties: IFunnelChartProperty list) = 
        Interop.reactApi.createElement(import "FunnelChart" "recharts", createObj !!properties)
    static member inline composedChart (properties: IComposedChartProperty list) =
        Interop.reactApi.createElement(import "ComposedChart" "recharts", createObj !!properties)
    static member inline scatterChart (properties: IScatterChartProperty list) =
        Interop.reactApi.createElement(import "ScatterChart" "recharts", createObj !!properties)

    static member inline bar (properties: IBarProperty list) =
        Interop.reactApi.createElement(import "Bar" "recharts", createObj !!properties)
    static member inline brush (properties: IBrushProperty list) =
        Interop.reactApi.createElement(import "Brush" "recharts", createObj !!properties)
    static member inline xAxis (properties: IXAxisProperty list) =
        Interop.reactApi.createElement(import "XAxis" "recharts", createObj !!properties)
    static member inline yAxis (properties: IYAxisProperty list) =
        Interop.reactApi.createElement(import "YAxis" "recharts", createObj !!properties)
    static member inline zAxis (properties: IZAxisProperty list) =
        Interop.reactApi.createElement(import "ZAxis" "recharts", createObj !!properties)
    static member inline tooltip (properties: ITooltipProperty list) =
        Interop.reactApi.createElement(import "Tooltip" "recharts", createObj !!properties)
    static member inline legend (properties: ILegendProperty list) =
        Interop.reactApi.createElement(import "Legend" "recharts", createObj !!properties)
    static member inline area (properties: IAreaProperty list) =
        Interop.reactApi.createElement(import "Area" "recharts", createObj !!properties)
    /// Cell can be wrapped by Pie, Bar, or RadialBar to specify attributes of each child. In Pie , for example, we can specify the attributes of each child node through data, but the props of Cell have higher priority
    static member inline cell (properties: ICellProperty list) =
        Interop.reactApi.createElement(import "Cell" "recharts", createObj !!properties)
    static member inline labelList (properties: ILabelListProperty list) = 
        Interop.reactApi.createElement(import "LabelList" "recharts", createObj !!properties)
    static member inline label (properties: ILabelProperty list) = 
        Interop.reactApi.createElement(import "Label" "recharts", createObj !!properties)
    static member inline sector (properties: ISectorProperty list) = 
        Interop.reactApi.createElement(import "Sector" "recharts", createObj !!properties)
    static member inline line (properties: ILineProperty list) =
        Interop.reactApi.createElement(import "Line" "recharts", createObj !!properties)
    static member inline cartesianGrid (properties: ICartesianGridProperty list) =
        Interop.reactApi.createElement(import "CartesianGrid" "recharts", createObj !!properties)
    static member inline cartesianAxis (properties: ICartesianAxisProperty list) =
        Interop.reactApi.createElement(import "CartesianAxis" "recharts", createObj !!properties)
    static member inline responsiveContainer (properties: IResponsiveContainerProperty list) =
        Interop.reactApi.createElement(import "ResponsiveContainer" "recharts", createObj !!properties)
    static member inline referenceLine (properties: IReferenceLineProperty list) =
        Interop.reactApi.createElement(import "ReferenceLine" "recharts", createObj !!properties)
    static member inline referenceArea (properties: IReferenceAreaProperty list) =
        Interop.reactApi.createElement(import "ReferenceArea" "recharts", createObj !!properties)
    static member inline referenceDot (properties: IReferenceDotProperty list) =
        Interop.reactApi.createElement(import "ReferenceDot" "recharts", createObj !!properties)
    static member inline pie (properties: IPieProperty list) =
        Interop.reactApi.createElement(import "Pie" "recharts", createObj !!properties)
    static member inline radar (properties: IRadarProperty list) =
        Interop.reactApi.createElement(import "Radar" "recharts", createObj !!properties)
    static member inline radialBar (properties: IRadialBarProperty list) =
        Interop.reactApi.createElement(import "RadialBar" "recharts", createObj !!properties)
    static member inline scatter (properties: IScatterProperty list) =
        Interop.reactApi.createElement(import "Scatter" "recharts", createObj !!properties)
    static member inline polarAngleAxis (properties: IPolarAngleAxisProperty list) =
        Interop.reactApi.createElement(import "PolarAngleAxis" "recharts", createObj !!properties)
    static member inline polarGrid (properties: IPolarGridProperty list) =
        Interop.reactApi.createElement(import "PolarGrid" "recharts", createObj !!properties)
    static member inline polarRadiusAxis (properties: IPolarRadiusAxisProperty list) =
        Interop.reactApi.createElement(import "PolarRadiusAxis" "recharts", createObj !!properties)
    static member inline funnel (properties: IFunnelProperty list) = 
        Interop.reactApi.createElement(import "Funnel" "recharts", createObj !!properties)
    static member inline errorBar (properties: IErrorBarProperty list) = 
        Interop.reactApi.createElement(import "ErrorBar" "recharts", createObj !!properties)
    static member inline text (properties: ITextProperty list) = 
        Interop.reactApi.createElement(import "Text" "recharts", createObj !!properties)