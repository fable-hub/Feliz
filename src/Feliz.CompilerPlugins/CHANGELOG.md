# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

**Types of changes**

-   ✨ `Added` for new features.
-   🔄 `Changed` for changes in existing functionality.
-   🗑️ `Deprecated` for soon-to-be removed features.
-   🔥 `Removed` for now removed features.
-   🐛 `Fixed` for any bug fixes.
-   🔒 `Security` in case of vulnerabilities.

## [Unreleased]

## 3.0.0-rc.4 - 2025-11-18

### 🗑️ Deprecated

- Remove transformation of single input record types for ReactComponent #603 (by @Freymaurer)

### 🐛 Fixed

- Fix equality issue for single input record types for ReactComponent #603  (by @Freymaurer)

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

