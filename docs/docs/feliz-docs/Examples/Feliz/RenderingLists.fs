module Examples.Feliz.RenderingLists

open Feliz

type RenderingLists =

    [<ReactComponent(true)>]
    static member Example(?list: int list) =

        let items = defaultArg list [ 0 .. 5 ] //any list/seq/array

        Html.div [
            Html.h2 "List rendering using for loop"
            Html.ul [
                Html.li "Static item 1"
                for item in items do // f# for loop, nicely combinable with other children
                    Html.li [
                        prop.key item
                        prop.text (sprintf "Item %i" item)
                    ]
            ]

            Html.h2 "List rendering using List.map"
            items // f# pipe style
            |> List.map (fun item ->
                Html.li [
                    prop.key item
                    prop.text (sprintf "Item %i" item)
                ])
            |> Html.ol

        ]
