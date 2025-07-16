---
sidebar_position: 5
---

# Context Propagation

A lot of the times there are pieces of information from the state that we want to make available for many components. The best example of that is a dark/light mode theme, a boolean flag that by usual means has to be passed from parent components all the way down to deeply nested children. Another example is that of the current user who is logged in: you want to propagate the user information from the application root component to the login/logout button in your navigation bar.

This process of propagating context information usually goes like this:

```fsharp
type Theme = Dark | Light

type State = { Theme : Theme }

let init() = { Theme = Light }

let update msg state = (* . . . *)

let renderNavbar (theme: Theme) =
    Html.nav [ ]

let renderSidebar (theme: Theme) =
    Html.aside [ ]

let renderContent (theme: Theme) =
    Html.div [
        renderNavbar theme
        renderSidebar theme
    ]

let render (state: State) (dispatch: Msg -> unit) =
    renderContent state.Theme
```

### A different solution from React

Since this is a common scenario in the React world, the folks from React have thought of a nice way to pass these pieces of information down to deep children without explicitly passing each and every parameter by hand: enter React context.

Using a React context, we can propagate global information down to deeply nested children implicitly without using function parameters but instead with a combination of React hooks and a **Context Provider** component following these steps:

- Creating a Context of some type `'t` with a default value of `'t`
- Creating a Context provider that makes that `'t` implicitly available to children
- Requiring the value of `'t` from the context within children

### Creating a React Context

```fsharp
let themeContext = React.createContext(name="Theme", defaultValue=Theme.Light)
```

### Creating a Context provider

```fsharp
[<ReactComponent>]
let render (state: State, dispatch: Msg -> unit) =
    React.contextProvider(themeContext, state.Theme, React.fragment [
        RenderContent()
    ])
```

### Requiring the value from within children:

To get the value that was implicitly passed down from parent components, we use the `React.useContext` hook as follows:

```fsharp
[<ReactComponent>]
let RenderNavbar() =
    // theme : Theme
    let theme = React.useContext(themeContext)
    Html.nav [
        // render navbar
    ]

[<ReactComponent>]
let RenderSidebar() =
    let theme = React.useContext(themeContext)
    Html.aside [
        // render sidebar
    ]

[<ReactComponent>]
let RenderContent() =
    let theme = React.useContext(themeContext)
    Html.div [
        RenderNavbar()
        RenderSidebar()
    ]
```

### Where to define these React contexts?

Since the order matters in which F# source files are compiled, it is necessary to define these contexts before the definition of the child components themselves to make them usable from these components:

```fsharp
App.fsproj
  |
  | -- Types.fs
  | -- Contexts.fs // <-- Contexts have to be defined at this point to access them
  | -- About.fs    //     But also to make them usable from the About, Home or App components
  | -- Home.fs
  | -- App.fs
```
