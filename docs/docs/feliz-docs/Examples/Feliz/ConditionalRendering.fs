module Example.ConditionalRendering

open Feliz

Fable.Core.JsInterop.importSideEffects "./conditional-rendering.css"

type ConditionalRendering =

    [<ReactComponent>]
    static member Item(text: string, count: int) =
        let isMany = count > 5

        Html.li [
            prop.style [
                style.display.flex
                style.justifyContent.spaceBetween
                style.alignItems.center
            ]
            prop.children [
                Html.div [
                    Html.text text
                    if not isMany then
                        Html.text " ⚠️"
                ]
                Html.small [
                    prop.className [
                        if isMany then "text-green-500" else "text-red-500"
                    ]
                    prop.textf "%d left in store" count
                ]
            ]
        ]

    [<ReactComponent>]
    static member OutOfStock(text: string) =
        Html.li [
            prop.style [
                style.display.flex
                style.justifyContent.spaceBetween
                style.alignItems.center
            ]
            prop.children [
                Html.div [
                    prop.style [ style.textDecorationLine.lineThrough ]
                    prop.text text
                ]
                Html.small "Out of stock"
            ]
            prop.className "text-gray-500"
        ]

    [<ReactComponent(true)>]
    static member Example() =
        let data = [
            "Apple", Some 1
            "Banana", None
            "Orange", Some 10
            "Grape", Some 3
            "Pineapple", None
            "Mango", Some 7
            "Blueberry", None
            "Raspberry", Some 20
        ]

        Html.ul [
            for text, count in data do
                match count with
                | Some count -> ConditionalRendering.Item(text, count)
                | None -> ConditionalRendering.OutOfStock(text)
        ]
