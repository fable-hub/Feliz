module Examples.Feliz.ReactMemoComponentAreEqualFn

open Feliz

// Memo using F# equality but ignoring function properties
[<ReactMemoComponent(AreEqualFn.FsEqualsButFunctions)>]
let MemoFsEqualsButFunctions (values: int list, fn: int -> int) =
    let renderCount = React.useRef 0
    renderCount.current <- renderCount.current + 1
    Html.div [ 
        prop.testId "memo-fs-bf-count"; 
        prop.text (string renderCount.current) 
    ]

// This will rerender when parent renders due to function property change
[<ReactMemoComponent(AreEqualFn.FsEquals)>]
let MemoFsEquals (values: int list, fn: int -> int) =
    let renderCount = React.useRef 0
    renderCount.current <- renderCount.current + 1
    Html.div [ 
        prop.testId "memo2-fs-bf-count"; 
        prop.text (string renderCount.current) 
    ]

// This will alway rerender when parent renders
[<ReactComponent>]
let ComparisonComponent (values: int list, fn: int -> int) =
    let renderCount = React.useRef 0
    renderCount.current <- renderCount.current + 1
    Html.div [ 
        prop.testId "fs-bf-count"; 
        prop.text (string renderCount.current) 
    ]

[<ReactComponent(true)>]
let ParentWithFnFsButFunctions() =
    let state, setState = React.useState 0
    let fn = fun x -> x + state // New function instance on each render
    let values = [ 1; 2 ] // New list instance on each render
    Html.div [
        Html.button [ 
            prop.testId "btn-fn-bf"; 
            prop.onClick (fun _ -> setState(state + 1)); 
            prop.text "Trigger Rerender by changing state of parent!" 
        ]
        MemoFsEqualsButFunctions (values, fn)
        MemoFsEquals (values, fn)
        ComparisonComponent (values, fn)
    ]
