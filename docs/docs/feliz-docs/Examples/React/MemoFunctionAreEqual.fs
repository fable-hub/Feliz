module Example.MemoFunctionAreEqual

open Feliz
open Browser.Dom

[<ReactComponent>]
let RenderArrayWithEffect (fruitArray: string []) =
    React.useEffect (fun () -> console.log("Rerender!", fruitArray) )
    Html.div [ 
        prop.text (String.concat ", " fruitArray); 
        prop.testId "memo-attribute" 
    ]

let MemoFunction =
    React.memo<{|fruitArray: string[]|}> (
        (fun props ->
            RenderArrayWithEffect(props.fruitArray)),
        (fun prevProps nextProps ->
            prevProps.fruitArray.Length = nextProps.fruitArray.Length &&
            prevProps.fruitArray |> Array.forall2 (=) nextProps.fruitArray
        )
    )

[<ReactComponent(true)>]
let Main () =
    let isDark, setIsDark = React.useState(false)
    let fruits = [| "Apple"; "Banana"; "Orange" |]
    let fgColor = if isDark then color.white else color.black
    let bgColor = if isDark then color.black else color.white
    Html.div [
        prop.style [style.border(1, borderStyle.solid, fgColor); style.padding 20; style.color fgColor; style.backgroundColor bgColor]
        prop.children [
            Html.h3 "Check the output in the browser console"
            Html.button [
                prop.text "Toggle Dark Mode"
                prop.onClick (fun _ -> setIsDark(not isDark))
            ]
            React.memoRender(MemoFunction, {| fruitArray = fruits |})
        ]
    ]
