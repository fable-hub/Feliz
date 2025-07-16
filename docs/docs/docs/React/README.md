# Standalone React Applications

Feliz aims to fully support the React API so that it can be used to build React applications standalone with or without Elmish which is mostly responsible for the state and effect management. You get the best of the both worlds when you combine Elmish patterns with those from React using Feliz.

The React API provided by Feliz should feel very familiar to those who already know React and we try as much as possible to map the concepts one-to-one from React and Javascript over to F# so that you can use all the knowledge you have from React in Feliz.

Here follows a full React example with a stateful component using a state variable hook.

```fsharp
module App

open Feliz

[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        Html.h1 count
        Html.button [
            prop.text "Increment"
            prop.onClick (fun _ -> setCount(count + 1))
        ]
    ]

open Browser.Dom

ReactDOM.render(Counter(), document.getElementById "root")
```

This example is a direct mapping from the Javascript and React equivalent:

```js
import ReactDOM from "react-dom";
import React, { useState } from "react";

function Counter() {
  // Declare a new state variable, which we'll call "count"
  const [count, setCount] = useState(0);

  return (
    <div>
      <h1>{count}</h1>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}

ReactDOM.render(<Counter />, document.getElementById("root"));
```
