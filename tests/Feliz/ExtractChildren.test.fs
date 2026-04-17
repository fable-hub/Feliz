module ExtractChildrenTests

open Feliz
open Fable.Core.JsInterop
open System
open Vitest

describe "HtmlHelper.createElement" <| fun _ ->

    test "extract from seq" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            seq {
                "id", box "my-div"
                "children", box child
                "className", box "container"
                "data-test", box true
                "style", box {| color = "red" |}
                "onClick", box (fun _ -> ())
                "tabIndex", box 0
            }
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "extract from list" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            [
                "id", box "my-div"
                "children", box child
                "className", box "container"
                "data-test", box true
                "style", box {| color = "red" |}
                "onClick", box (fun _ -> ())
                "tabIndex", box 0
            ]
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "extract from array" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            [|
                "id", box "my-div"
                "children", box child
                "className", box "container"
                "data-test", box true
                "style", box {| color = "red" |}
                "onClick", box (fun _ -> ())
                "tabIndex", box 0
            |]
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "extract from ResizeArray" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            ResizeArray [
                "id", box "my-div"
                "children", box child
                "className", box "container"
                "data-test", box true
                "style", box {| color = "red" |}
                "onClick", box (fun _ -> ())
                "tabIndex", box 0
            ]
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "extract as last" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            [
                "id", box "my-div"
                "data-test", box true
                "style", box {| color = "red" |}
                "onClick", box (fun _ -> ())
                "tabIndex", box 0
                "className", box "container"
                "children", box child
            ]
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "extract as exactlyOne" <| fun _ ->
        let child = [ Html.span []; Html.div [] ] 
        let props = 
            [
                "children", box child
            ]
        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" props
        expect(child).toBeTruthy()
        let key, child =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"
        expect(key).toBe("children")
        expect(child).toEqual(child)
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe((props |> Seq.length) - 1)

    test "prop.spread converts object entries" <| fun _ ->
        let dynamicProps =
            createObj [
                "id" ==> "spread-div"
                "title" ==> "Spread Title"
                "data-test" ==> true
                "onClick" ==> (fun _ -> ())
            ]

        let spreadProps = prop.spread dynamicProps
        let tupleProps = spreadProps |> Array.map unbox<string * obj>

        expect(tupleProps.Length).toBe(4)
        expect(tupleProps |> Array.exists (fun (k, _) -> k = "id")).toBeTruthy()
        expect(tupleProps |> Array.exists (fun (k, _) -> k = "title")).toBeTruthy()
        expect(tupleProps |> Array.exists (fun (k, _) -> k = "data-test")).toBeTruthy()
        expect(tupleProps |> Array.exists (fun (k, _) -> k = "onClick")).toBeTruthy()

    test "prop.spread output supports children extraction" <| fun _ ->
        let child = [ Html.span []; Html.div [] ]
        let dynamicProps =
            createObj [
                "id" ==> "spread-div"
                "children" ==> child
                "title" ==> "Spread Title"
            ]

        let tupleProps =
            dynamicProps
            |> prop.spread
            |> Array.map unbox<string * obj>

        let extractedProps, childOption = HtmlHelper.extractByKeyFast "children" tupleProps

        let key, extractedChildrenObj =
            match childOption with
            | Some kvp -> kvp
            | None -> failwith "Expected to find 'children' key"

        let extractedChildren = unbox<ReactElement list> extractedChildrenObj
        let propsContainChildren: bool = extractedProps |> Array.exists (fun (k, _) -> k = "children")

        expect(key).toBe("children")
        expect(extractedChildren).toEqual(child)
        expect(propsContainChildren).toBeFalsy()
        expect(extractedProps.Length).toBe(2)
