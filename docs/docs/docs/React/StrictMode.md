---
sidebar_position: 12
---


# Strict Mode

Strict mode is a tool for highlighting potential problems in an application. Like `React.fragment`,
strict mode does not render any visible UI. It activates additional checks and warnings for its descendants.
This can be called via `React.strictMode` which takes a list of child elements.

> Strict mode checks are run in development mode only; *they do not impact the production build*.

In many cases the code you write won't ever cause any issues from strict mode, but it will also tell you
about issues in components that you import. While you may not be able to directly fix those issues,
it can point out potential issues, as well as inform you if your application is [concurrent mode ready].

If you open your console after running the following example code, you will see that there is now a warning.
This is because the created component uses an unsafe method.

```fsharp
type StrictModeWarning () =
    inherit Fable.React.Component<obj,obj>()

    // The unsafe call.
    override _.componentWillMount() = ()

    override _.render () =
        Html.div [
            prop.text "I cause a warning!"
        ]

[<ReactComponent>]
let StrictModeExample() =
    Html.div [
        prop.style [
            style.display.inheritFromParent
        ]
        prop.children [
            React.strictMode [
                Fable.React.Helpers.ofType<StrictModeWarning,obj,obj> "" []
            ]
        ]
    ]
```

See the [React docs] for more information about what checks are done.

[React docs]:https://reactjs.org/docs/strict-mode.html
[concurrent mode ready]:https://reactjs.org/docs/concurrent-mode-adoption.html#enabling-concurrent-mode
