namespace Feliz

open Fable.Core
open Feliz.Styles

[<Erase>]
type textDecorationLine =
    static member inline none : ITextDecorationLine = unbox "none"
    static member inline underline : ITextDecorationLine = unbox "underline"
    static member inline overline : ITextDecorationLine = unbox "overline"
    static member inline lineThrough : ITextDecorationLine = unbox "line-through"
    static member inline initial : ITextDecorationLine = unbox "initial"
    static member inline inheritFromParent : ITextDecorationLine = unbox "inherit"