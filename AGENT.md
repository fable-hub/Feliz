# Feliz agent guide

## Purpose and scope

Feliz is an F# DSL and Fable binding for React. Its core package lets applications describe HTML, SVG, properties, styles, components, and React hooks in typed F# while Fable emits JavaScript. The repository also contains optional Feliz packages, Vitest bindings, tests, a playground, and the documentation site.

Use `docs/docs/` for the current Feliz 3 API. `docs/versioned_docs/version-2.9.0/` is a snapshot of the older API; do not copy its examples into current code without checking the migration guide at `docs/docs/api-docs/Upgrade.md`. The core project currently targets React 19 through its npm dependency requirements. Check the project's actual package versions before giving installation advice; some documentation snippets still show Feliz 2.9.0.

## Using Feliz in an application

- Add the `Feliz` NuGet package and install the matching JavaScript `react` and `react-dom` packages. A new application can start from `Feliz.Template`; an existing one can use Femto to install the .NET and npm dependencies together. See `docs/docs/api-docs/GettingStarted.mdx`.
- `open Feliz`. Build elements with `Html.*`, properties with `prop.*`, and typed inline CSS with `prop.style [ style.* ]`. For SVG, use the corresponding `Svg` API. See `docs/docs/api-docs/feliz/Html.mdx` and the examples in `docs/docs/feliz-docs/Examples/Feliz/`.
- An `Html.*` list is either a list of children or a list of properties. When passing properties, place children inside `prop.children [...]`; use `prop.text` for simple text. Do not mix bare children with properties in the same list.
- Use `[<ReactComponent>]` on a function that returns a React element, then call it normally from parent F# code. Its parameters become React props. `[<ReactComponent(true)>]` additionally makes it the module's default export; it is not required for ordinary components. See `docs/docs/api-docs/feliz/react-component.mdx` and `passing-props.mdx`.
- Keep state and effects inside components with `React.useState`, `React.useEffect`, and the other React hooks. Use `React.useStateWithUpdater` when the next state must be computed from the previous state. Clean up subscriptions or timers in effects. See `docs/docs/api-docs/react/hooks/`.
- F# `if`, `match`, `for`, and `List.map` work in element construction. Give dynamic siblings stable `prop.key` values; default Feliz element creation may not produce React's missing-key warning. `Html.none` renders nothing. See `conditional-rendering.mdx`, `rendering-lists.mdx`, and `Html.mdx` under `docs/docs/api-docs/feliz/`.
- Mount the app with `ReactDOM.createRoot` and `root.render`. See `docs/docs/api-docs/react-dom/client-apis/createRoot.mdx`.

```fsharp
open Feliz

[<ReactComponent>]
let Counter() =
    let count, setCount = React.useState(0)
    Html.div [
        Html.button [
            prop.onClick (fun _ -> setCount(count + 1))
            prop.text "Increment"
        ]
        Html.p [ prop.text (string count) ]
    ]
```

For optional integrations, use their own package and documentation: `Feliz.UseElmish` for an Elmish model inside a component, `Feliz.Recharts` and `Feliz.PigeonMaps` for visualizations, and the other packages catalogued in `docs/docs/ecosystem/`. The `Feliz.JSX` module is an alternative output path; it requires `.jsx` Fable output and has documented limitations, so consult `docs/docs/api-docs/guides/output-jsx.mdx` before using it. For JavaScript library interop, start with `docs/docs/api-docs/guides/writing-bindings.mdx`.

## Repository map

- `src/Feliz/`: core public API. `Html.fs`, `Svg.fs`, `Properties.fs`, `Styles.fs`, and `React/` implement the DSL and React bindings. `Feliz.fsproj` defines F# compilation order and references `src/Feliz.CompilerPlugins/`, which implements component-related transforms.
- `src/Feliz.*` and `src/Vitest*`: companion libraries and test bindings. Each package has its own project file and usually a `CHANGELOG.md`.
- `tests/`: F# and npm/Vitest test projects. `tests/README.md` describes the test layout.
- `docs/docs/api-docs/`: current guides and API reference. `docs/docs/feliz-docs/Examples/`: F# examples compiled into live Docusaurus examples by `docs/docs/feliz-docs/Feliz.Docs.fsproj`. `docs/versioned_docs/`: historical docs.
- `playground/`: small application for trying changes. `build/Build.fsproj` and `build/Program.fs`: setup, test, pack, and release commands.

## Working in this repository

- Follow the relevant current guide and its compiled example before changing an API. Keep `src`, matching tests, live examples, and API documentation in sync. Respect `.fsproj` compile ordering when adding F# files.
- Use the shared root `package.json` npm workspaces and `Directory.Packages.props` for dependencies; the repo pins its .NET SDK in `global.json` and local Fable tools in `.config/dotnet-tools.json`.
- Run `dotnet run --project ./build/Build.fsproj setup` for initial setup. Run `dotnet run --project ./build/Build.fsproj test` for the test suite, or append a test folder name to target one project (for example, `test Feliz`).
- For documentation work, run `npm run start` from `docs/` to compile the F# examples and start Docusaurus; run `npm run build` there to verify a production docs build.
- Follow `CONTRIBUTING.md` for formatting, tests, and changelog entries. Avoid editing generated output or dependency directories such as `node_modules/`, `obj/`, `bin/`, and `docs/.docusaurus/` by hand.
