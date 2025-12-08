namespace System.Diagnostics.CodeAnalysis
#if !NET7_0_OR_GREATER

open System
/// <summary>
/// Backport of StringSyntaxAttribute from .NET 7+ for use in earlier framework versions.
/// Specifies the syntax used in a string for enhanced IDE support (e.g., syntax highlighting, autocomplete).
/// </summary>
[<AttributeUsage(AttributeTargets.Parameter ||| AttributeTargets.Field ||| AttributeTargets.Property, AllowMultiple = false, Inherited = false)>]
type internal StringSyntaxAttribute

    /// <summary>
    /// Initializes a new instance of the <see cref="StringSyntaxAttribute"/> class with the identifier of the syntax used.
    /// </summary>
    /// <param name="syntax">The syntax identifier.</param>
    /// <param name="arguments">Optional arguments associated with the specific syntax employed.</param>
    (syntax: string, [<ParamArray>] arguments: obj[]) =

    inherit Attribute()

    /// <summary>
    /// Initializes a new instance of the <see cref="StringSyntaxAttribute"/> class with the identifier of the syntax used.
    /// </summary>
    /// <param name="syntax">The syntax identifier.</param>
    new (syntax: string) = StringSyntaxAttribute(syntax, [||])

    /// <summary>Gets the identifier of the syntax used.</summary>
    member val public Syntax = syntax with get

    /// <summary>Gets optional arguments associated with the specific syntax employed.</summary>
    member val public Arguments = arguments with get

#endif
