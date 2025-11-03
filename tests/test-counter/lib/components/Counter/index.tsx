import * as React from 'react';

export function Counter({init = 42, testId = "counter", ...props}: {init?: number, testId?: string} & React.HTMLAttributes<HTMLDivElement>) {
  const [count, setCount] = React.useState(init);
  return (
    <div {...props}>
      <button onClick={() => setCount(count + 1)} data-testid={testId}>
        Count: {count}  
      </button>
    </div>
  );
}