# Tests

Feliz uses vitest as test runner.


## Run tests

To run all test projects; in **project root**, run:

```bash
npm run test
```

To run a specific test project; in the **test project root**, run:

```bash
npm run test
```

or in watch mode:
```bash
npm run test:watch
```

## Run specific tests

### Use `f`ocused tests

You can find a helper function binding to vitest `only` test in tests/Globals:

```fsharp
let inline ftestPromise (name: string) (fn: unit -> Fable.Core.JS.Promise<unit>) = Vitest.Test.only(name, fn)
```

If you use `ftestPromise` only this test will be run, and you can adjust the focused tests during watch mode.

### Use vitest test filtering

To run a specific test file(s); in either **project root** or **test project root** add the filename (partial match) you want to run:

For example, appending memo will check all files containing `memo`, see Vitest docs: <https://vitest.dev/guide/filtering>


```bash
npm run test memo
```

or in watch mode (only in test project root):
```bash
npm run test:watch memo
```
