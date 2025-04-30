namespace Feliz.Recharts

open Feliz
open Fable.Core
open Feliz.Styles

[<Erase>]
type responsiveContainer =
    /// The percentage value of the chart's width or a fixed width. Default is 100%.
    static member inline width (value: int) = Interop.mkResponsiveContainerAttr "width" value
    /// The percentage value of the chart's width or a fixed width. Default is 100%.
    static member inline width (value: float) = Interop.mkResponsiveContainerAttr "width" value
    /// The percentage value of the chart's width or a fixed width. Default is 100%.
    static member inline width (value: ICssUnit) =
        if value = length.percent(100) || value = length.perc(100.0) then
            Interop.mkResponsiveContainerAttr "width" (length.percent(99))
        else
            Interop.mkResponsiveContainerAttr "width" value
    /// The percentage value of the chart's width or a fixed height. Default is 100%.
    static member inline height (value: int) = Interop.mkResponsiveContainerAttr "height" value
    /// The percentage value of the chart's width or a fixed height. Default is 100%.
    static member inline height (value: float) = Interop.mkResponsiveContainerAttr "height" value
    /// The percentage value of the chart's width or a fixed height. Default is 100%.
    static member inline height (value: ICssUnit) = Interop.mkResponsiveContainerAttr "height" value
    /// Width / height. If specified, the height will be calculated by width / aspect.
    static member inline aspect (value: float) = Interop.mkResponsiveContainerAttr "aspect" value
    /// width / height. If specified, the height will be calculated by width / aspect.
    static member inline aspect (value: int) = Interop.mkResponsiveContainerAttr "aspect" value
    /// The chart that should become responsive
    static member inline chart (chart: ReactElement) = Interop.mkResponsiveContainerAttr "children" chart
    /// The minimum width of the container
    static member inline minWidth (value: int) = Interop.mkResponsiveContainerAttr "minWidth" value
    /// The minimum width of the container
    static member inline minWidth (value: float) = Interop.mkResponsiveContainerAttr "minWidth" value
    /// The minimum width of the container
    static member inline minWidth (value: ICssUnit) = Interop.mkResponsiveContainerAttr "minWidth" value
    /// The minimum height of the container.
    static member inline minHeight (value: int) = Interop.mkResponsiveContainerAttr "minHeight" value
    /// The minimum height of the container.
    static member inline minHeight (value: float) = Interop.mkResponsiveContainerAttr "minHeight" value
    /// The minimum height of the container.
    static member inline minHeight (value: ICssUnit) = Interop.mkResponsiveContainerAttr "minHeight" value
    /// If specified a positive number, debounced function will be used to handle the resize event.
    static member inline debounce (value: int) = Interop.mkResponsiveContainerAttr "debounce" value
    /// If specified a positive number, debounced function will be used to handle the resize event.
    static member inline debounce (value: float) = Interop.mkResponsiveContainerAttr "debounce" value
    /// If specified a positive number, debounced function will be used to handle the resize event.
    static member inline debounce (value: ICssUnit) = Interop.mkResponsiveContainerAttr "debounce" value