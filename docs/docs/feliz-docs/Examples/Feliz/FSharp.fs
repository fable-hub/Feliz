module Example.FSharp

open Feliz

Fable.Core.JsInterop.importSideEffects "./fsharp.css"

type ISize =
    | Small
    | Medium
    | Large

type Button =

    [<ReactComponent>]
    static member Example(text: string, onClick: Browser.Types.MouseEvent -> unit, ?size: ISize) =
        let size = defaultArg size Medium

        let sizeClass =
            match size with
            | Small -> "sm"
            | Medium -> ""
            | Large -> "lg"

        Html.button [
            prop.text text
            prop.onClick onClick
            prop.className [ "fsharp-btn"; sizeClass ]
        ]

    [<ReactComponent(true)>]
    static member Example() =
        let fn = fun _ -> Browser.Dom.console.log ("Button clicked!")

        Html.div [
            prop.style [
                style.display.flex
                style.flexDirection.column
                style.alignItems.center
                style.justifyContent.center
                style.gap 10
            ]
            prop.children [
                Button.Example("Submit", fn, size = Large)
                Html.br []
                Button.Example("Submit", fn, size = Medium)
                Html.br []
                Button.Example("Submit", fn, size = Small)
            ]

        ]
