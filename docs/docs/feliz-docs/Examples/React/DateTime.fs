module Example.DateTime

open System
open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Main =

    [<ReactComponent(true)>]
    static member SwitchingBetweenDateAndDateTime() =
        let (date, setDate) = React.useState<DateTime option>(None)
        let (dateAndTime, toggleDateAndTime) = React.useState(false)

        let formattedDate =
            match date with
            | None -> "No date selected yet"
            | Some date -> "Input: " + date.ToString "yyyy-MM-dd hh:mm"

        Html.div [
            Html.h3 formattedDate

            if dateAndTime then
                Html.input [
                    prop.value(date, includeTime=dateAndTime)
                    prop.type'.dateTimeLocal
                    prop.onChange (fun newValue -> setDate(Some newValue))
                ]
            else
                Html.input [
                    prop.value(date, includeTime=dateAndTime)
                    prop.type'.date
                    prop.onChange (fun newValue -> setDate(Some newValue))
                ]

            Html.button [
                prop.text "Reset selected date"
                prop.disabled date.IsNone
                prop.onClick (fun _ -> setDate(None))
            ]

            Html.button [
                prop.text "Toggle date and time"
                prop.disabled date.IsNone
                prop.onClick (fun _ -> toggleDateAndTime(not dateAndTime))
            ]
        ]
