module Example.UseLayoutEffect

open Feliz


[<ReactComponent(true)>]
let Tooltip () =
    let tooltipRef = React.useElementRef ()
    let tooltipHeight, setTooltipHeight = React.useState (0)
    let padding, setPadding = React.useState (10)

    React.useLayoutEffect (
        (fun () ->
            match tooltipRef.current with
            | Some el ->
                let rect = el.getBoundingClientRect ()
                setTooltipHeight (int rect.height)
            | None -> ()
        ),
        [| box padding |]
    )

    Html.div [
        Html.div [
            prop.ref tooltipRef
            prop.style [
                style.backgroundColor.lightYellow
                style.color.black
                style.padding padding
            ]
            prop.text "This is a tooltip."
        ]
        Html.p [ prop.text $"Measured tooltip height: {tooltipHeight}px" ]
        Html.input [
            prop.type'.number
            prop.value padding
            prop.onChange setPadding
            prop.placeholder "Set tooltip padding"
        ]
    ]
