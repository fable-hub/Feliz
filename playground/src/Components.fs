module Components

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Browser.Dom
open Shared

type jsx = JSX.Html

let private areEqualFn = fun prop1 prop2 -> prop1 = prop2

[<Emit("\"use memo\"")>]
let use_memo: unit = jsNative

[<ReactMemoComponent(areEqual="(a,b) => a.fruitArray === b.fruitArray")>]
let private MemoAttributeAreEqualJsEqual (fruitArray: string []) =
    use_memo
    React.useEffect (fun () -> console.log("MemoAttributeAreEqualJsEqual rendered"))
    Html.div [ 
        prop.text (String.concat ", " fruitArray); 
        prop.testId "memo-attribute" 
    ]

        
[<ReactComponent>]
let Main () =
    let fruitArray, setFruitArray = React.useState ([| "Apple"; "Banana"; "Orange" |]) // This stays the same array
    let sortedFruits = Array.sort fruitArray // this creates a new array instance on each render
    let theme, setTheme = React.useState "light"
    Html.div [
        prop.style [ 
            if theme = "light" then 
                style.backgroundColor "white"
                style.color "black"
            else 
                style.backgroundColor "black"
                style.color "white"
        ]
        prop.children [
            Html.button [
                prop.testId "change-fruit-array"
                prop.text "Change Fruit Array"
                prop.onClick (fun _ -> setFruitArray [| "Apple"; "Banana"; "Orange"; "Cherry" |])
            ]
            Html.button [
                prop.testId "change-theme"
                prop.text "Change Theme"
                prop.onClick (fun _ -> 
                    if theme = "light" then 
                        setTheme "dark" 
                    else 
                        setTheme "light")
            ]
            MemoAttributeAreEqualJsEqual (sortedFruits)
        ]
    ]
