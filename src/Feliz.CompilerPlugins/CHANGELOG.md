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

## 3.2.0 - 2026-05-12

### ✨ Added

- Added transpile time check for `[<ReactLazyComponent>]`. Ensure that argument names in lazy component call sides match argument names in lazy loaded source component. #712 (by @Freymaurer)

## 3.1.0 - 2026-03-20

### 🔄 Changed

- Update `Fable.AST` to `5.0.0-rc.3` (by @MangelMaxime)

## 3.0.0 - 2025-12-10

## 3.0.0-rc.9 - 2025-12-05

### ✨ Added

- Support for `"use memo"` and `"use no memo"` directive on `[<ReactMemoComponent(bool)>]` to better integrate with React Compiler in annotation mode (by @Freymaurer)

## 3.0.0-rc.8 - 2025-11-28

### ✨ Added

- Support for predefined equality functions for `[<ReactMemoComponent>]` (by @Freymaurer, @melanore)

## 3.0.0-rc.7 - 2025-11-26

### 🗑️ Deprecated

- Removed name setting for memo components, as this would remove the `memo` tag in react dev tools (by @Freymaurer)

## 3.0.0-rc.6 - 2025-11-21

### 🐛 Fixed

- Fix `props` aliasing issue. A `let props` inside the react component also created duplication issues (by @Freymaurer)

## 3.0.0-rc.5 - 2025-11-21

### 🐛 Fixed

- Fix `props` aliasing issue. when passing a arg with the name `props` to a `[<ReactComponent>]` it threw with duplication error (by @Freymaurer)

## 3.0.0-rc.4 - 2025-11-18

### 🗑️ Deprecated

- Remove transformation of single input record types for ReactComponent #603 (by @Freymaurer)

### 🐛 Fixed

- Fix equality issue for single input record types for ReactComponent #603 (by @Freymaurer)

## 3.0.0-rc.3 - 2025-11-03

### 🐛 Fixed

- Correctly call single tuple inputs for ReactComponent #644 by @Freymaurer

## 3.0.0-rc.2 - 2025-11-03

### 🔄 Changed

- Relax validation of record props defined along the react component to allow lower cased record types #463, #666, #667 by @melanore

### 🐛 Fixed

- Resolve relative import paths between call site and reference file for `[<ReactComponent(import="...", from="...")>]` #624 by @Freymaurer

## 3.0.0-rc.1 - 2025-09-18

### ✨ Added

- `[<ReactLazyComponent>]` attribute

### 🔄 Changed

- Make `[<ReactComponent>]` transpile arguments to JavaScript object instead of `any` for better typescript support

## 2.2.0 - 2023-03-21

### ✨ Added

- Last release before start of Changelog
