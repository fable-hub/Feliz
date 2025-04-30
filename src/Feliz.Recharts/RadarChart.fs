namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type radarChart =
  static member inline data (values: seq<'a>) = Interop.mkRadarChartAttr "data" (Seq.toArray values)
  static member inline data (values: 'a list) = Interop.mkRadarChartAttr "data" (List.toArray values)
  static member inline children (elements: ReactElement list) = unbox<IRadarChartProperty> (prop.children elements)
  static member inline width (value: int) = Interop.mkRadarChartAttr "width" value
  static member inline height (value: int) = Interop.mkRadarChartAttr "height" value
  static member inline cy(value: float) = Interop.mkRadarChartAttr "cy" value
  static member inline cy(value: int) = Interop.mkRadarChartAttr "cy" value
  static member inline cx(value: float) = Interop.mkRadarChartAttr "cx" value
  static member inline cx(value: int) = Interop.mkRadarChartAttr "cx" value
  static member inline startAngle(value: int) = Interop.mkRadarChartAttr "startAngle" value
  static member inline endAngle(value: int) = Interop.mkRadarChartAttr "endAngle" value
  static member inline innerRadius(value: int) = Interop.mkRadarChartAttr "innerRadius" value
  static member inline innerRadius(value: float) = Interop.mkRadarChartAttr "innerRadius" value
  static member inline outerRadius(value: int) = Interop.mkRadarChartAttr "outerRadius" value
  static member inline outerRadius(value: float) = Interop.mkRadarChartAttr "outerRadius" value
  static member inline margin(?top: int, ?right: int, ?left: int, ?bottom: int) =
      let margin = createObj [
          "top" ==> Option.defaultValue 0 top
          "right" ==> Option.defaultValue 0 right
          "left" ==> Option.defaultValue 0 left
          "bottom" ==> Option.defaultValue 0 bottom
      ]
      Interop.mkRadarChartAttr "margin" margin
  static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
      Interop.mkRadarChartAttr "onMouseEnter" <|
          fun eventArgs ->
              if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
              then ignore()
              else handler eventArgs
  static member inline onMouseLeave (handler: unit -> unit) = Interop.mkRadarChartAttr "onMouseLeave" handler
  static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
      Interop.mkRadarChartAttr "onClick" <|
          fun eventArgs ->
              if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
              then ignore()
              else handler eventArgs
