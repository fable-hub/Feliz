module Example.MemoFunction

open Feliz
open Browser.Dom

[<ReactComponent>]
let RenderTextWithEffect (text: string) =
    React.useEffect (fun () -> console.log("Rerender!", text) )
    Html.div [ 
        prop.text text; 
        prop.testId "memo-attribute" 
    ]

let MemoFunction =
    React.memo<{|text: string|}> (fun props ->
        RenderTextWithEffect(props.text)
    )

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
            Html.button [
                prop.text "Toggle Dark Mode"
                prop.onClick (fun _ -> setIsDark(not isDark))
            ]
            Html.input [
                prop.value text
                prop.onChange setText
            ]
            React.memoRender(MemoFunction, {| text = text |})
        ]
    ]
