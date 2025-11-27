#if !NET7_0_OR_GREATER

namespace System.Diagnostics.CodeAnalysis

open System

/// <summary>Specifies the syntax used in a string.</summary>
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
