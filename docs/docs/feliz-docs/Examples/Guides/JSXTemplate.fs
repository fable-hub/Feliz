module Examples.Guides.JSXTemplate

open Feliz
open Feliz.JSX


[<ReactComponent(true)>]
let TestComponent () =
    let counter, setCounter = React.useState (0)

    let ChildList =
        if counter = 0 then
            Html.jsx
                $"""
            <li>No items</li>
            """
        else
            React.Fragment [
                for i in 1..counter do
                    Html.jsx
                        $"""
                        <li key={i} id={sprintf "item-%d" i}>Item {i}</li>
                    """
            ]

    Html.jsx
        $"""
        <div>
            <h1>Hello from JSX Template!</h1>
            <p>This is a paragraph inside a div.</p>
            <div>
                <h1>Counter - Reactivity Test</h1>
                <button onClick={fun _ -> setCounter (counter + 1)} >Increment</button>
                <ul>
                    {ChildList}
                </ul>
            </div>
        </div>
    """
