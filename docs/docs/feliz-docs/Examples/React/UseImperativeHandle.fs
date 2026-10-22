module Example.UseImperativeHandle

open Feliz

open Fable.Core.JsInterop

type FancyInputController = {| focus: unit -> unit |}

[<ReactComponent>]
let FancyInput (inputRef: IRefValue<FancyInputController option>) =
    let localRef = React.useInputRef ()

    React.useImperativeHandle (
        inputRef,
        (fun () ->
            {|
                focus =
                    fun () ->
                        match localRef.current with
                        | Some el -> el?focus ()
                        | None -> ()
            |}
            |> Some
        ),
        [||]
    )

    Html.input [
        prop.ref localRef
        prop.type'.text
        prop.placeholder "Type something..."
    ]

[<ReactComponent(true)>]
let UseImperativeHandle () =
    let fancyInputRef = React.useRef (None)

    Html.div [
        FancyInput fancyInputRef
        Html.button [
            prop.text "Focus the input"
            prop.onClick (fun _ ->
                match fancyInputRef.current with
                | Some api -> api.focus ()
                | None -> ()
            )
        ]
    ]
