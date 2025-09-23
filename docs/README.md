# Website

This website is built using [Docusaurus](https://docusaurus.io/), a modern static website generator.
## Local Development

```bash
npm start
```

- transpiles `docs/feliz-docs/Feliz.Docs.fsproj` to jsx files for live examples
- starts a local development server and opens up a browser window. Most changes are reflected live without having to restart the server.

## Build

```bash
npm build
```

This command generates static content into the `build` directory and can be served using any static contents hosting service.

## Deployment

Using Github actions!

## Create new major version

Docosaurus offers a version command, which will transfer all current docs from `docs/` into a versioned_docs folder. This will also include the feliz-docs project PLUS the transpiled files IF EXISTING!

1. Transpile the latest changes with `npm run start` (you can stop the server after the transpilation is done)
2. Run `npm run docusaurus docs:version x.x.x` (Only do this for the last version before a major version change)
3. Verify that all `.js`/`.jsx` files in the new versioned_docs are tracked by git.

  For example i had some issues due to a fable generated .gitignore in `docs\versioned_docs\version-2.9.0\feliz-docs\fableoutput\fable_modules\.gitignore`.
  Please check this file for some .gitignore rules that somewhat worked for me. (it was kind of muddled, so please confirm correct behavior)

4. Commit and push the changes
