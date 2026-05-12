# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

**Types of changes**

- ✨ `Added` for new features.
- 🔄 `Changed` for changes in existing functionality.
- 🗑️ `Deprecated` for soon-to-be removed features.
- 🔥 `Removed` for now removed features.
- 🐛 `Fixed` for any bug fixes.
- 🔒 `Security` in case of vulnerabilities.

## [Unreleased]

## 3.3.2 - 2026-05-12

### 🔄 Fixed

- Update for new Feliz.CompilerPlugins, including transpile time check for `[<ReactLazyComponent>]` to ensure that argument names in lazy component call sides match argument names in lazy loaded source component. #712 (by @Freymaurer)

## 3.3.1 - 2026-04-20

### 🐛 Fixed

- Fix missing argument passing in `prop.points` #709 (by @ConradRoesch)

## 3.3.0 - 2026-04-17

### ✨ Added

- Support for `prop.spread` helper to spread object-based props #704 (by @Freymaurer)

### 🐛 Fixed

- Fix `useLayoutEffect` unmount calls #705 (by @Freymaurer)

## 3.2.0 - 2026-03-20

### 🔄 Changed

- Update `Feliz.CompilerPlugins` version to support `Fable.AST` to `5.0.0-rc.3` (by @MangelMaxime)

## 3.1.1 - 2026-01-01

### ✨ Added

- Support for `svg.viewBox` property overload accepting raw string (by @Freymaurer)

### 🐛 Fixed

- Changes `alignment-baseline` to `alignmentBaseline` (by @njlr)

### ✨ Added

- Support for the [autocorrect attribute](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Global_attributes/autocorrect) (by @kerams)
- Support for `svg.key` property #698 (by @Freymaurer)

## 3.1.0 - 2025-12-15

### ✨ Added

- Added `useSyncExternalStore` hook support (by @mjblacker)

### 🐛 Fixed

- Fix `spellCheck` html prop naming convention from lowercase to camelCase, causing React warning "Invalid DOM property" (by @mjblacker)

## 3.0.0 - 2025-12-10

### ✨ Added

- Added `onTransitionStart` event handler support (by @Freymaurer)

## 3.0.0-rc.16 - 2025-12-05

### ✨ Added

- Added `[<StringSyntax("jsx")>]` support for `Feliz.JSX.Html.jsx` function (by @Freymaurer)
- Support for `"use memo"` and `"use no memo"` directive on `[<ReactMemoComponent(bool)>]` to better integrate with React Compiler in annotation mode (by @Freymaurer)

## 3.0.0-rc.15 - 2025-12-01

### ✨ Added

- Support for the [menu HTML element](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/menu) (by @laurentpayot)
- Support for the [Popover API HTML attributes](https://developer.mozilla.org/en-US/docs/Web/API/Popover_API#html_attributes) (by @laurentpayot)

## 3.0.0-rc.14 - 2025-11-28

### ✨ Added

- Support for predefined equality functions for `[<ReactMemoComponent>]` via the `areEqualFn` parameter #665 (by @Freymaurer, @melanore)

## 3.0.0-rc.13 - 2025-11-26

### ✨ Added

- Added support for custom equality functions in `[<ReactMemoComponent>]` via the `areEqual` parameter #665
. (by @melanore)

### 🔄 Changed

- Updated `React.memo` to require a corresponding `React.memoRender` call when rendering the component. This leads to more native behavior for the memoized components. (by @Freymaurer)

### 🗑️ Deprecated

- Removed name setting for memo components, as this would remove the `memo` tag in react dev tools (by @Freymaurer)

## 3.0.0-rc.12 - 2025-11-21

### 🐛 Fixed

- Fix `props` aliasing issue. A `let props` inside the react component also created duplication issues (by @Freymaurer)

## 3.0.0-rc.11 - 2025-11-21

### 🐛 Fixed

- Fix `props` aliasing issue. when passing a arg with the name `props` to a `[<ReactComponent>]` it threw with duplication error (by @Freymaurer)

## 3.0.0-rc.10 - 2025-11-18

### 🗑️ Deprecated

- Remove transformation of single input record types for ReactComponent #603 (by @Freymaurer)

### 🐛 Fixed

- Fix equality issue for single input record types for ReactComponent #603 (by @Freymaurer)

## 3.0.0-rc.9 - 2025-11-03

### 🔄 Changed

- Moved `IDisposable` helper into `FsReact` type. This type will be home for any future custom hooks. by @Freymaurer

## 3.0.0-rc.8 - 2025-11-03

### 🐛 Fixed

- Update Feliz `/fable` content after packing to include all `**/*.fs` files not only `*.fs` by @Freymaurer

## 3.0.0-rc.7 - 2025-11-03

### 🐛 Fixed

- Trying to fix issues with fsproj setup 😞 by @Freymaurer

## 3.0.0-rc.6 - 2025-11-03

### 🐛 Fixed

- Correctly call single tuple inputs for ReactComponent #644 by @Freymaurer

## 3.0.0-rc.5 - 2025-11-07

### 🐛 Fixed

- Fixed an issue in which some .fs files were not being included as compile sources.

## 3.0.0-rc.4 - 2025-11-03

### ✨ Added

- `style.fontsize._` module with `smaller`, `larger`, ... styles. By @Linschlager #613

### 🔄 Changed

- Refactored project structure, sorting related files into dedicated folders for better organization.

## 3.0.0-rc.3 - 2025-09-18

### 🔄 Changed

- Improved performance for createElement used for `seq<IReactProperty>`

## 3.0.0-rc.2 - 2025-09-18

### 🐛 Fixed

- Added missing Femto support

## 3.0.0-rc.1 - 2025-09-18

### ✨ Added

- Feliz.JSX module
- Test suite

### 🔄 Changed

- Make React hooks align closer to React API
- Change React.lazy' API (see docs)

## 2.9.0 - 2024-10-26

### ✨ Added

- Last release before start of Changelog
