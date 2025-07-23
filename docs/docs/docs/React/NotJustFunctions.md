---
sidebar_position: 1
---

# Not Just Functions

In the previous section, we defined stateless components and used them like other UI elements. You might be wondering: "Well, isn't this `Greeting` component the same as a *function* that just takes a record of type `Greeting` as input and returns `ReactElement`"?

You would be *almost* right, even though the component is used as if it was a function, there is more to it on the React side of things. Since this is a component, React treats it as a single entity in the virtual DOM tree and can cache the output of the render function used in the component if the input properties haven't changed.

This makes a *huge* difference than using a simple functions with Elmish where React is forced to build the entire application tree on every re-render cycle and start diffing the whole thing to compute the required changes, which for some unfortunate applications can be the reason for sluggish or laggy user interface.

Moreover, within components React can make use of React specific functionality such as hooks like `React.useState`, `React.useEffect`, `React.useContext` among others which are tremendously useful as we will see in the sections to follow.

Debugging and optimizing sluggish the UI render cycles usually starts by turning specific pieces of the application into named components and using React profiling tools to optimize for the number of re-renders. Of course, aside from UI diffing you can also identify function calls in your `render` functions which might be doing unnecessary expensive work causing the UI to lag.

I wouldn't say you should always start with building components right off the bat because first of the syntactic overhead compared to simple functions, second because of hooks that although useful, can sometimes be a bit weird in their execution order and third because most common application will likely be plenty fast for a snappy user interface but that really depends on the requirements of your application.
