# Minimal native counter component

This project is used to create a minimal native counter component. Its only purpose is creating a single `.tgz` file which can be used to `node_modules` resoltion import testing in the other test projects.

It is installed in root package.json as a dev dependency using a file path reference.

## How to build

1. Run `npm install` to install dependencies.
2. Run `npm run build` to build the project. This will generate the output files in the `dist` folder.
3. Run `npm pack` to create a `.tgz` package file for distribution.
