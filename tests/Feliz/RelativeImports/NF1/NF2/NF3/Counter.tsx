import { useState } from "react";

export function Counter() {
  const [count, setCount] = useState(0);
  return <div data-testid="counter">
    <div>Counter Component: {count}</div>
    <button onClick={() => setCount(count + 1)}>Increment</button>
    <button onClick={() => setCount(count - 1)}>Decrement</button>
  </div> 
}


export default Counter;
