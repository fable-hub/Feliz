module Example.MemoAttributeAreEqualEmitFnName

open Feliz
open Browser.Dom

let areEqualFn prop1 prop2 =
    prop1 = prop2

[<ReactMemoComponent(nameof areEqualFn)>] // or "areEqualFn"
let RenderTextWithEffect (fruits: string []) =
    React.useEffect (fun () -> console.log("Rerender!") )
    Html.div [ 
        prop.text (fruits |> String.concat ", "); 
        prop.testId "memo-attribute" 
    ]

[<ReactComponent(true)>]
let Main () =
    let isDark, setIsDark = React.useState(false)
    let input, setInput = React.useState("")
    // This will stay the same array if it does not change 
    let fruits, setFruits = React.useState([|"apple"; "orange"; "banana"|])
    // This creates a new array reference on every render, triggering a rerender of the child component, without custom equality check
    let sortedFruits = 
        fruits 
        |> Array.sort 
    let isValidInput = System.String.IsNullOrEmpty input |> not && fruits |> Array.contains input |> not
    let fgColor = if isDark then color.white else color.black
    let bgColor = if isDark then color.black else color.white
    Html.div [
        prop.style [style.border(1, borderStyle.solid, fgColor); style.padding 20; style.color fgColor; style.backgroundColor bgColor]
        prop.children [
            Html.h3 "Check the output in the browser console"
            Html.p "The child component below is memoized using the [<ReactMemoComponent>] attribute. It only rerenders when the areEqual function returns false."
            Html.button [
                prop.text "Toggle Dark Mode"
                prop.onClick (fun _ -> setIsDark(not isDark))
            ]
            Html.input [
                prop.value input
                prop.onChange setInput
            ]
            Html.button [
                prop.text "Change Fruits Array"
                prop.disabled (not isValidInput)
                prop.onClick (fun _ ->
                    if isValidInput then
                        [|yield! fruits; input|] |> setFruits
                        setInput ""
                )
            ]
            RenderTextWithEffect(sortedFruits)
        ]
    ]
