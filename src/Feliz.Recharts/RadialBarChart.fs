namespace Feliz.Recharts

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Feliz.Recharts

[<Erase>]
type radialBarChart =
  static member inline data (values: 'a list) = Interop.mkRadialBarChartAttr "data" (List.toArray values)
  static member inline children (elements: ReactElement list) = Interop.mkRadialBarChartAttr "children" (prop.children elements)
  static member inline width (value: int) = Interop.mkRadialBarChartAttr "width" value
  static member inline height (value: int) = Interop.mkRadialBarChartAttr "height" value
  static member inline barGap (value: int) = Interop.mkRadialBarChartAttr "barGap" value
  static member inline barGap (value: float) = Interop.mkRadialBarChartAttr "barGap" value
  static member inline barSize (value: int) = Interop.mkRadialBarChartAttr "barSize" value
  static member inline barSize (value: float) = Interop.mkRadialBarChartAttr "barSize" value
  static member inline barCategoryGap (value: int) = Interop.mkRadialBarChartAttr "barCategoryGap" value
  static member inline barCategoryGap (value: float) = Interop.mkRadialBarChartAttr "barCategoryGap" value
  static member inline cy(value: float) = Interop.mkRadialBarChartAttr "cy" value
  static member inline cy(value: int) = Interop.mkRadialBarChartAttr "cy" value
  static member inline cx(value: float) = Interop.mkRadialBarChartAttr "cx" value
  static member inline cx(value: int) = Interop.mkRadialBarChartAttr "cx" value
  static member inline startAngle(value: int) = Interop.mkRadialBarChartAttr "startAngle" value
  static member inline endAngle(value: int) = Interop.mkRadialBarChartAttr "endAngle" value
  static member inline innerRadius(value: int) = Interop.mkRadialBarChartAttr "innerRadius" value
  static member inline innerRadius(value: float) = Interop.mkRadialBarChartAttr "innerRadius" value
  static member inline outerRadius(value: int) = Interop.mkRadialBarChartAttr "outerRadius" value
  static member inline outerRadius(value: float) = Interop.mkRadialBarChartAttr "outerRadius" value
  static member inline clockWise = Interop.mkRadialBarChartAttr "clockWise" true
  static member inline background(value:bool) = Interop.mkRadialBarChartAttr "background" value
  static member inline margin(?top: int, ?right: int, ?left: int, ?bottom: int) =
      let margin = createObj [
          "top" ==> Option.defaultValue 0 top
          "right" ==> Option.defaultValue 0 right
          "left" ==> Option.defaultValue 0 left
          "bottom" ==> Option.defaultValue 0 bottom
      ]
      Interop.mkRadialBarChartAttr "margin" margin
  static member inline onMouseEnter (handler: ChartMouseEvent<'label, 'payload> -> unit) =
      Interop.mkRadialBarChartAttr "onMouseEnter" <|
          fun eventArgs ->
              if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
              then ignore()
              else handler eventArgs
  static member inline onMouseLeave (handler: unit -> unit) = Interop.mkRadialBarChartAttr "onMouseLeave" handler
  static member inline onClick (handler: ChartMouseEvent<'label, 'payload> -> unit) =
      Interop.mkRadialBarChartAttr "onClick" <|
          fun eventArgs ->
              if isNullOrUndefined eventArgs || Interop.objectHas [ "isTooltipActive" ] eventArgs
              then ignore()
              else handler eventArgs

module radialBarChart =

    [<Erase>]
    type cy =
        /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
        static member inline percentage(value: float) = Interop.mkRadialBarChartAttr "cy" (unbox<string> value + "%")
        /// The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container height.
        static member inline percentage(value: int) = Interop.mkRadialBarChartAttr "cy" (unbox<string> value + "%")

    [<Erase>]
    type innerRadius =
        static member inline percentage(value: float) = Interop.mkRadialBarChartAttr "innerRadius" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.mkRadialBarChartAttr "innerRadius" (unbox<string> value + "%")

    [<Erase>]
    type outerRadius =
        static member inline percentage(value: float) = Interop.mkRadialBarChartAttr "outerRadius" (unbox<string> value + "%")
        static member inline percentage(value: int) = Interop.mkRadialBarChartAttr "outerRadius" (unbox<string> value + "%")

    [<Erase>]
    type cx =
        /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
        static member inline percentage(value: float) = Interop.mkRadialBarChartAttr "cx" (unbox<string> value + "%")
        /// The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of container width. Default '50%'.
        static member inline percentage(value: int) = Interop.mkRadialBarChartAttr "cx" (unbox<string> value + "%")

    [<Erase>]
    type legendType =
        static member inline line = Interop.mkRadialBarChartAttr "legendType" "line"
        static member inline square = Interop.mkRadialBarChartAttr "legendType" "square"
        static member inline rect = Interop.mkRadialBarChartAttr "legendType" "rect"
        static member inline circle = Interop.mkRadialBarChartAttr "legendType" "circle"
        static member inline cross = Interop.mkRadialBarChartAttr "legendType" "cross"
        static member inline diamond = Interop.mkRadialBarChartAttr "legendType" "diamond"
        static member inline star = Interop.mkRadialBarChartAttr "legendType" "star"
        static member inline triangle = Interop.mkRadialBarChartAttr "legendType" "triangle"
        static member inline wye = Interop.mkRadialBarChartAttr "legendType" "wye"
        static member inline none = Interop.mkRadialBarChartAttr "legendType" "none"

    /// The type of easing function. Default is `ease`.
    [<Erase>]
    type animationEasing =
        static member inline ease = Interop.mkRadialBarChartAttr "animationEasing" "ease"
        static member inline easeIn = Interop.mkRadialBarChartAttr "animationEasing" "ease-in"
        static member inline easeOut = Interop.mkRadialBarChartAttr "animationEasing" "ease-out"
        static member inline easeInOut = Interop.mkRadialBarChartAttr "animationEasing" "ease-in-out"
        static member inline linear = Interop.mkRadialBarChartAttr "animationEasing" "linear"