# Transpile.Tests

`Transpile.Tests` is a pure .NET test project for validating Fable transpilation behavior.

This project is meant for tests that need to verify:

- transpilation succeeds and emits expected JS/JSX patterns
- transpilation fails and returns the expected diagnostics

Each test transpiles a generated mini-project instead of checked-in fixture projects.

Benefits:

- minimal per-test boilerplate (usually one snippet string)

> [!TIP]
> Set `FELIZ_TRANSPILE_TESTS_KEEP_ARTIFACTS=true` (or `1`) to keep artifacts for debugging.
> For per-test retention without a global env var, use `withTranspileSuccessKeepArtifacts`.

## Annotated example test

The success test in `JSXHtmlTranspile.test.fs` uses this pattern:

```fsharp

let private jsxHtmlSnippet =
    """
module Snippet

open Fable.Core
open Feliz
open Feliz.JSX

[<Erase; Mangle(false)>]
type Components =

    [<JSX.Component>]
    static member SimpleDiv() =
        Html.div [
            prop.className "simple-div"
            prop.testId "simpleDiv"
            prop.text "Hello from JSX"
        ]
"""

test "transpiles minimal JSX component and emits stable code markers" {
    // 1) Define generated project input (name + snippet source)
    let spec = createSnippet "jsx-html-success" jsxHtmlSnippet

    // 2) Run transpilation and fail immediately if transpilation fails
    withTranspileSuccess
        spec
        (fun success ->
            // 3) Read generated Snippet.jsx output
            let output = readSourceOutput success

            // 4) Assert stable output markers
            Expect.stringContains output "export function SimpleDiv(" "Expected exported JSX component function."
            Expect.stringContains output "className=\"simple-div\"" "Expected className assignment in transpiled JSX."
            Expect.stringContains output "data-testid=\"simpleDiv\"" "Expected test id assignment in transpiled JSX."
            Expect.stringContains output "<div" "Expected JSX div node in transpiled output."

            // 5) Assert that transpilation did not fall back to helper-based shape
            Expect.isFalse
                (output.Contains("HtmlHelper_createElement"))
                "Expected direct JSX output instead of HtmlHelper_createElement fallback."
        )
}
```

What each part does:

- `createSnippet`: packages the source into a test input model.
- `withTranspileSuccess`: runs full temp-project generation + transpile + cleanup and guarantees success path.
- `withTranspileSuccessKeepArtifacts`: same as `withTranspileSuccess`, but skips cleanup for that specific test call.
- `readSourceOutput`: reads the generated transpiled source file for assertions.
- `Expect.stringContains`: checks stable output patterns instead of brittle full snapshots.
- `Expect.isFalse (...)`: verifies unwanted transpilation patterns are absent.

## Failure test pattern

For failure scenarios, use `withTranspileFailure`:

- assert non-empty overall diagnostics (already enforced by helper)
- add case-specific fragment checks with `expectDiagnosticContains`
- optionally assert source-file and location with `expectDiagnosticMentionsSourceFile` and `expectDiagnosticHasLocation`

## Running this test project

From repository root:

```bash
dotnet test ./tests/Transpile.Tests/Transpile.Tests.fsproj
```

Or through the build project filter:

```bash
dotnet run --project ./build/Build.fsproj test Transpile
```

## Temp project setup flow

The setup is implemented in `TranspileUtils.fs` and follows this flow:

1. Build snippet input
- Use `createSnippet` to create a `SnippetSpec` with a name and source code.
- Optional: use `withAdditionalFile` to add extra files to the generated test project.

2. Resolve repository root
- `transpileSnippet` finds the repository root by walking up from `AppContext.BaseDirectory` until `global.json` is found.
- `getRepoRoot` ensures the workspace target folder exists at `tests/Transpile.Tests/temp`.

3. Create isolated workspace
- A unique folder is created under `tests/Transpile.Tests/temp/<name>-<guid>`.
- This prevents conflicts between concurrent test runs.

4. Write generated files
- `Snippet.fs` is written with your source.
- `Snippet.fsproj` is generated and references `src/Feliz/Feliz.fsproj`.
- Any additional files from `SnippetSpec.AdditionalFiles` are also written.

5. Run Fable transpilation
- Command used:

```bash
dotnet tool run fable <repo>/tests/Transpile.Tests/temp/<name>-<guid>/Snippet.fsproj -o <repo>/tests/Transpile.Tests/temp/<name>-<guid>/fableoutput --exclude Feliz.CompilerPlugins --noCache -e .jsx
```

- A lock is used around process invocation to avoid cross-process contention.
- stdout/stderr are captured and stored in the result.

6. Return rich result type
- `Success` includes output paths, emitted files, and captured logs.
- `Failure` includes exit code and combined diagnostics.

7. Auto-cleanup (optional retention)
- Temp workspace is deleted after assertion by default.
- The workspace root `tests/Transpile.Tests/temp` is kept, but test-specific subfolders are cleaned.
- `withTranspileSuccessKeepArtifacts` keeps the generated test-specific subfolder for that invocation.

