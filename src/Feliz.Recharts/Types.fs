namespace Feliz.Recharts

open Fable.Core

[<Erase>]
type IDotProperties<'a> =
    abstract cy : float
    abstract cx : float
    abstract dataKey : string
    abstract height : float
    abstract key : string
    abstract index : int
    abstract stroke : string
    abstract fill : string
    abstract value : float
    abstract payload : 'a

type IAxisDomain = interface end

[<Erase>]
type domain =
    static member inline min : IAxisDomain = unbox "dataMin"
    static member inline max : IAxisDomain = unbox "dataMax"
    static member inline auto : IAxisDomain = unbox "auto"
    static member inline constant (value: int) : IAxisDomain = unbox value
    static member inline calculate (f: float -> float) : IAxisDomain = unbox f
    static member inline calculate (f: int -> int) : IAxisDomain = unbox f
    static member inline calculate (f: int -> float) : IAxisDomain = unbox f
    static member inline calculate (f: float -> int) : IAxisDomain = unbox f

[<Erase>]
type ILabelProperties =
    abstract index : int
    abstract offset : int
    abstract x : float
    abstract y : float
    abstract value : float

[<Erase>]
type IXAxisTickPayload =
    abstract index : int
    abstract isShow : bool
    abstract coordinate : float
    abstract tickCoord : float
    abstract offset : float

[<Erase>]
type IXAxisTickProperties =
    abstract fill : string
    abstract index : int
    abstract height : float
    abstract stroke  : string
    abstract textAnchor : string
    abstract verticalAnchor : string
    abstract visibleTicksCount : int
    abstract width : float
    abstract x : float
    abstract y : float

[<Erase>]
type ITickItem =
    abstract value : obj
    abstract coordinate : float
    abstract index : int

[<Erase>]
type IPolarAngleAxisTickProperties =
    abstract angleAxisId : string
    abstract cx : float
    abstract cy: float
    abstract radius: float
    abstract axisLineType : string
    abstract orientation : string
    abstract ticks : ITickItem array

[<Erase>]
type IPieLabelProperties =
    abstract cy : float
    abstract cx : float
    abstract midAngle : float
    abstract innerRadius : float
    abstract outerRadius : float
    abstract percent : float
    abstract index : int

[<Erase>]
type ChartCoordinate =
    abstract x : float
    abstract y : float

[<Erase>]
type ChartDataPoint<'payload> =
    abstract payload: 'payload
    abstract color : string
    abstract fill : string
    abstract strokeWidth : float
    abstract value : float
    abstract dataKey : string
    abstract name : string

[<Erase>]
type ChartMouseEvent<'label, 'payload> =
    abstract activeCoordinate : ChartCoordinate
    abstract activeLabel : 'label
    abstract activePayload : ChartDataPoint<'payload> array
    abstract activeTooltipIndex : int
    abstract chartX : int
    abstract chartY : int

[<Erase>]
type IAreaProperty = interface end

[<Erase>]
type IAreaChartProperty = interface end

[<Erase>]
type IBarChartProperty = interface end

[<Erase>]
type IBarProperty = interface end

[<Erase>]
type IBrushProperty = interface end

[<Erase>]
type IXAxisProperty = interface end

[<Erase>]
type IYAxisProperty = interface end

[<Erase>]
type IZAxisProperty = interface end

[<Erase>]
type ITooltipProperty = interface end

[<Erase>]
type ILegendProperty = interface end

[<Erase>]
type ICellProperty = interface end

[<Erase>]
type ILabelListProperty = interface end

[<Erase>]
type ILabelProperty = interface end

[<Erase>]
type ISectorProperty = interface end

[<Erase>]
type ILineProperty = interface end

[<Erase>]
type ILineChartProperty = interface end

[<Erase>]
type ICartesianGridProperty = interface end

[<Erase>]
type ICartesianAxisProperty = interface end

[<Erase>]
type IResponsiveContainerProperty = interface end

[<Erase>]
type IComposedChartProperty = interface end

[<Erase>]
type IReferenceLineProperty = interface end

[<Erase>]
type IReferenceAreaProperty = interface end

[<Erase>]
type IReferenceDotProperty = interface end

[<Erase>]
type IPieProperty = interface end

[<Erase>]
type IPieChartProperty = interface end

[<Erase>]
type IRadarProperty = interface end

[<Erase>]
type IRadarChartProperty = interface end

[<Erase>]
type IRadialBarChartProperty = interface end

[<Erase>]
type IRadialBarProperty = interface end

[<Erase>]
type IScatterChartProperty = interface end

[<Erase>]
type IScatterProperty = interface end

[<Erase>]
type IPolarAngleAxisProperty = interface end

[<Erase>]
type IPolarGridProperty = interface end

[<Erase>]
type IPolarRadiusAxisProperty = interface end

[<Erase>]
type IFunnelChartProperty = interface end

[<Erase>]
type IFunnelProperty = interface end

[<Erase>]
type IErrorBarProperty = interface end

[<Erase>]
type ITextProperty = interface end

