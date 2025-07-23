import React from 'react';
import Layout from '@theme/Layout';

import { useState } from 'react';

export default function MyComponent() {
  const [count, setCount] = useState(0);
  return (
    <div>
      <h1>My React Component</h1>
      <p>This is a React component with state management.</p>
      <button onClick={() => setCount(count + 1)}>
        Click me! Count: {count}
      </button>
    </div>
  );
}
