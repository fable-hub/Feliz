module Example.UseCallback

open Feliz


[<ReactMemoComponent>] // memoizes component to prevent rerender whenever parent rerenders
let ChildComponent(onClick: unit -> unit) = 
    let renderCount = React.useRef(0)
    React.useEffect(fun () ->
        renderCount.current <- renderCount.current + 1
    )
    Html.div [
        Html.button [
            prop.text "Child Button"
            prop.onClick (fun _ -> onClick())
        ]
        Html.p [ prop.text $"Child rendered {renderCount.current} times" ]
    ]


[<ReactComponent(true)>]
let UseCallback() =
    let count, setCount = React.useState(0)
    let theme, setTheme = React.useState("light")
    // Memoize the callback so ChildComponent only rerenders when count changes
    let increment = React.useCallback((fun () -> setCount(count + 1)), [| box count |])

    Html.div [
        Html.button [
            prop.text "Toggle Theme"
            prop.onClick (fun _ -> 
                if theme = "light" then setTheme("dark")
                else setTheme("light"))
        ]
        Html.div theme
        Html.button [
            prop.text $"Increment"
            prop.onClick (fun _ -> increment())
        ]
        Html.div count
        Html.p [ prop.text "The increment function is memoized using useCallback and passed to the child." ]
        ChildComponent increment
    ]
