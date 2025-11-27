module Example.MemoAttribute

open Feliz
open Browser.Dom

[<ReactMemoComponent>]
let RenderTextWithEffect (text: string) =
    React.useEffect (fun () -> console.log("Rerender!", text) )
    Html.div [ 
        prop.text text; 
        prop.testId "memo-attribute" 
    ]


[<ReactComponent(true)>]
let Main () =
    let isDark, setIsDark = React.useState(false)
    let text, setText = React.useState("Hello, world!")
    let fgColor = if isDark then color.white else color.black
    let bgColor = if isDark then color.black else color.white
    Html.div [
        prop.style [style.border(1, borderStyle.solid, fgColor); style.padding 20; style.color fgColor; style.backgroundColor bgColor]
        prop.children [
            Html.h3 "Check the output in the browser console"
            Html.p "The child component below is memoized using the [<ReactMemoComponent>] attribute. It only rerenders when its props change."
            Html.button [
                prop.text "Toggle Dark Mode"
                prop.onClick (fun _ -> setIsDark(not isDark))
            ]
            Html.input [
                prop.value text
                prop.onChange setText
            ]
            RenderTextWithEffect(text)
        ]
    ]
