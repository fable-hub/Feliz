namespace Feliz

open Fable.Core

/// Describes an element property
type IReactProperty = interface end
/// This is used to improve typesafety when using lazy components, with the suggested Feliz helpers.
type LazyComponent<'props> = interface end

/// This is used to improve typesafety when using memo components, with the suggested Feliz helpers.
type MemoComponent<'props> = interface end

/// Describes style attribute
type IStyleAttribute = interface end

/// Describes an SVG attribute
type ISvgAttribute = interface end

type ReactElement = Fable.React.ReactElement

type IRefValue<'T> = Fable.React.IRefValue<'T>
