namespace Feliz.Recharts

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type tooltip =
    static member inline separator (value: string) = Interop.mkTooltipAttr "separator" value
    static member inline offset (value: int) = Interop.mkTooltipAttr "offset" value
    static member inline filterNull (value: bool) = Interop.mkTooltipAttr "filterNull" value
    static member inline cursor (value: bool) = Interop.mkTooltipAttr "cursor" value
    /// Specifies how the text in the tooltip should be formatted 
    /// 
    /// ie: tooltip.formatter (fun value _ _ -> $"{value}%%")
    /// ie: tooltip.formatter (fun _ _ _ -> data), as long as "data" is a string
    static member inline formatter(f: 'a->string->'b->'c) = Interop.mkTooltipAttr "formatter" (System.Func<_,_,_,_> f)
    static member inline wrapperStyle (properties: #IStyleAttribute list) = Interop.mkTooltipAttr "wrapperStyle" (createObj !!properties)
    static member inline itemStyle (properties: #IStyleAttribute list) = Interop.mkTooltipAttr "itemStyle" (createObj !!properties)
    static member inline labelStyle (properties: #IStyleAttribute list) = Interop.mkTooltipAttr "labelStyle" (createObj !!properties)
    /// The position of the tooltip in relation to the chart.
    ///
    /// Takes a tuple of (x : int, y : int)
    /// Default value depends on the position of the mouse.
    static member inline position (?x: int, ?y: int) = 
        let position = 
            match x, y with 
            | None, None -> createObj [ "x" ==> 0; "y" ==> 0 ]
            | None, Some _ -> createObj [ "x" ==> 0; "y" ==> 0 ]
            | Some _, None -> createObj [ "x" ==> 0; "y" ==> 0 ]
            | Some x, Some y -> createObj [ "x" ==> x; "y" ==> y ]
        Interop.mkTooltipAttr "position" position

    static member inline cursor(?stroke: string, ?strokeWidth: int) =
        let cursor = createObj [
            "stroke" ==> Option.defaultValue "" stroke
            "strokeWidth" ==> Option.defaultValue 0 strokeWidth
        ]

        Interop.mkTooltipAttr "cursor" cursor
    static member inline active (value: bool) = Interop.mkTooltipAttr "active" value
    static member inline content (render: ITooltipProperty list -> ReactElement) = Interop.mkTooltipAttr "content" render
