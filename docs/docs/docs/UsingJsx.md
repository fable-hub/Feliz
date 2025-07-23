---
title: Using JSX
sidebar_position: 7
---

# Using JSX

The DSL provided by Feliz makes it possible to write HTML code in a way that fits nicely with F#: using lists. However, it takes a bit of time to get used to it and sometimes it can get verbose compared to its plain old HTML equivalent especially in parts of the application where there is a lot of rich-formatted text using `<span>`, `<a>`, `<strong>` etc.

In these cases, using JSX is an option for you. Feliz provides a simple interop mechanism to easily consume components written in JSX inside your Fable application by means of the `[<ReactComponent>]` attribute. It goes as follows. Consider the following component written in JSX in a file called `About.jsx`:

```jsx
import React from "react";

export const About = ({ title }) => {
  return (
    <div style={{ padding: 10 }}>
      <h1>{title}</h1>
      <p>
        This component is written in JSX and can be easily imported from Feliz
        applications.
      </p>
      <p>
        It accepts parameters or props like{" "}
        <strong style={{ color: "red" }}>title</strong> that come from F#
      </p>
      <p>
        You can learn all about Feliz{" "}
        <a href="https://zaid-ajaj.github.io/Feliz">here</a>
      </p>
    </div>
  );
};
```

This file _exports_ a React component called `About` and it expects a properties object containing a property called `title`.

To use this component like any other component from your application, import it using either function in a module:

```fsharp
open Feliz

[<ReactComponent(import="About", from="./About.jsx")>]
let About (title: string) = React.imported()
```

Or using a static function in a static class

```fsharp
open Feliz

type Components =
    [<ReactComponent(import="About", from="./About.jsx")>]
    static member About (title: string) = React.imported()
```

It is up to you which way you choose. Personally I lean towards the second approach because you can use named arguments at call-site and you can also use optional parameters easily:

```fsharp
Html.div [
    Html.h1 "Content"
    Components.About(title="Feliz")
]
```

In the syntax of the `[<ReactComponent>]` attribute, the `import` parameter value takes the name of the value that was _exported_ from the module that contains the component. The `from` parameter takes the module path that contains the exported component whether it is a relative path to a file or a third-party installed module.

### Input properties syntax

There are a couple of things to think about when writing these imports.

First of all, the input properties of the component in JSX can be _destructured_ form. The following component is an example of that where `title` is the destructured or unpacked property of the input object.

```js
export const About = ({ title }) => {
  // ...
};
```

It is equivalent to the following in _non-destructured_ form:

```js
export const About = (properties) => {
  const title = properties.title;
  // ...
};
```

When you have multiple input properties for the component, you can provide them as function parameters:

```js
export const About = ({ title, description }) => {
  return; /* some jsx code */
};

// same as
export const About = (properties) => {
  const title = properties.title;
  const description = properties.description;
  return; /* some jsx code */
};
```

Imported in F# as follows:

```fsharp
open Feliz

// using a static function
type Components =
    [<ReactComponent(import="About", from="./About.jsx")>]
    static member About (title: string, description: string) = React.imported()

// or using a function module
[<ReactComponent(import="About", from="./About.jsx")>]
let About (title: string, description: string) = React.imported()
```

When the imported component doesn't have any input properties, you can use `unit` on the F# side of things.

### Using (anonymous) records as input

Besides using primitive values as input parameters to imported components. You can instead use a record or anonymous record as input. Take this code:

```fsharp
open Feliz

[<ReactComponent(import="About", from="./About.jsx")>]
let About (title: string, description: string) = React.imported()
```

can be rewritten as:

```fsharp
open Feliz

// using an anonymous record is input
[<ReactComponent(import="About", from="./About.jsx")>]
let About (props: {| title: string; description: string |}) = React.imported()
```

or

```fsharp
open Feliz

type AboutProps = {
    title: string
    description: string
}

// or using a function module
[<ReactComponent(import="About", from="./About.jsx")>]
let About (props: AboutProps) = React.imported()
```
