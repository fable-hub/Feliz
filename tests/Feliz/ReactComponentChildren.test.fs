module Tests.ReactComponentChildren

open Feliz
open Vitest

[<ReactComponent>]
let ListChildren (children: ReactElement list) =
    Html.div [
        prop.testId "count"
        prop.text (sprintf "count=%d" (List.length children))
    ]

[<ReactComponent>]
let ArrayChildren (children: ReactElement[]) =
    Html.div [
        prop.testId "count"
        prop.text (sprintf "count=%d" children.Length)
    ]

[<ReactComponent>]
let SeqChildren (children: seq<ReactElement>) =
    Html.div [
        prop.testId "count"
        prop.text (sprintf "count=%d" (Seq.length children))
    ]

[<ReactComponent>]
let Greeting (name: string) = Html.span name

let private childrenTests name (render: ReactElement list -> ReactElement) =
    describe name
    <| fun _ ->
        test "two children"
        <| fun _ ->
            let r = RTL.render (render [ Greeting "a"; Greeting "b" ])
            expect(r.getByTestId "count").toHaveTextContent "count=2"

        test "one child"
        <| fun _ ->
            let r = RTL.render (render [ Greeting "a" ])
            expect(r.getByTestId "count").toHaveTextContent "count=1"

        test "no children"
        <| fun _ ->
            let r = RTL.render (render [])
            expect(r.getByTestId "count").toHaveTextContent "count=0"

        test "children built at runtime"
        <| fun _ ->
            let r = RTL.render (render ([ "a"; "b"; "c" ] |> List.map Greeting))
            expect(r.getByTestId "count").toHaveTextContent "count=3"

childrenTests "ReactComponent children typed as list" ListChildren
childrenTests "ReactComponent children typed as array" (fun xs -> ArrayChildren(Array.ofList xs))
childrenTests "ReactComponent children typed as seq" (fun xs -> SeqChildren(List.toSeq xs))
