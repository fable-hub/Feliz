module Examples.Feliz.ReactComponent

open Feliz

[<ReactComponent>]
let Component (text: string, count: int) =
    Html.div [
        for i in 1 .. count do
            Html.p [
                prop.key i
                prop.text (sprintf "%d: %s" i text)
            ]
    ]


[<ReactMemoComponent>]
let ComponentMemo (text: string) (count: int) =
    Html.div [
        for i in 1 .. count do
            Html.p [
                prop.key i
                prop.text (sprintf "%d: %s" i text)
            ]
    ]

