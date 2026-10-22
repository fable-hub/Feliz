namespace Feliz.Kawaii

open Feliz
open Fable.Core

[<StringEnum; RequireQualifiedAccess>]
type Mood =
    | [<CompiledName "sad">] Sad
    | [<CompiledName "shocked">] Shocked
    | [<CompiledName "happy">] Happy
    | [<CompiledName "blissful">] Blissful
    | [<CompiledName "lovestruck">] Lovestruck
    | [<CompiledName "excited">] Excited
    | [<CompiledName "ko">] KO

type Kawaii =
    [<ReactComponent(import = "Backpack", from = "react-kawaii")>]
    static member Backpack(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Browser", from = "react-kawaii")>]
    static member Browser(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Cat", from = "react-kawaii")>]
    static member Cat(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Chocolate", from = "react-kawaii")>]
    static member Chocolate(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "CreditCard", from = "react-kawaii")>]
    static member CreditCard(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "File", from = "react-kawaii")>]
    static member File(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Folder", from = "react-kawaii")>]
    static member Folder(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Ghost", from = "react-kawaii")>]
    static member Ghost(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "IceCream", from = "react-kawaii")>]
    static member IceCream(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Mug", from = "react-kawaii")>]
    static member Mug(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "Planet", from = "react-kawaii")>]
    static member Planet(?size: int, ?color: string, ?mood: Mood) = React.Imported()

    [<ReactComponent(import = "SpeechBubble", from = "react-kawaii")>]
    static member SpeechBubble(?size: int, ?color: string, ?mood: Mood) = React.Imported()
