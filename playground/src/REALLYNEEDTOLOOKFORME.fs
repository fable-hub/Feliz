module Counter


open Fable.Core
open Feliz

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<RequireQualifiedAccess>]
[<StringEnum>]
type CounterVariant =
    | Increment
    | Decrement
    | Both

[<Fable.Core.JS.PojoAttribute>]
type CounterConfig(?stepSize: int, ?counterVariant: CounterVariant) = 
    member val stepSize = stepSize with get, set
    member val counterVariant = counterVariant with get, set

/// internal helper
module private CounterConfig =
    let Default = CounterConfig(1, CounterVariant.Both)

[<Mangle(false); Erase>]
type Counter =

    [<ReactComponent(true)>]
    static member Counter(?init: int, ?text: string, ?classNames: ResizeArray<string>, ?config: CounterConfig) =
        let config = defaultArg config CounterConfig.Default
        let init = defaultArg init 0
        let counter, setCounter = React.useState(init)

        let IncrementBtn() =
            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> setCounter(counter + config.stepSize.Value) )
            ]

        let DecrementBtn() =
            Html.button [
                prop.text "Decrement"
                prop.onClick (fun _ -> setCounter(counter - config.stepSize.Value))
            ]

        Html.div [
            prop.className (
                match classNames with
                | Some names when names.Count > 0 ->
                    names
                | _ -> ResizeArray [| "counter" |]
            )
            prop.children [
                Html.h1 "Main component!"
                if text.IsSome then
                    Html.p text.Value
                Html.div [
                    Html.p $"Counter: {counter} - {config.stepSize.Value}"
                    Html.div [
                        match config.counterVariant with
                        | Some CounterVariant.Increment -> IncrementBtn()
                        | Some CounterVariant.Decrement -> DecrementBtn()
                        | Some CounterVariant.Both 
                        | None ->
                            IncrementBtn()
                            DecrementBtn()
                    ]
                ]

            ]
        ]
