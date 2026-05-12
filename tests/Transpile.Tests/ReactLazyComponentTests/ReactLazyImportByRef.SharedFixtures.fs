module ReactLazyImportByRefFixtures

open System
open TranspileUtils

module TupledInput =

    let sourceCode =
        """
module Source

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent
        (text: string, ?testId: string, ?className: string, ?onClick: Browser.Types.MouseEvent -> unit)
        =
        Html.div [
            prop.testId (defaultArg testId "none")
            prop.text text

            if className.IsSome then
                prop.className className.Value

            if onClick.IsSome then
                prop.onClick onClick.Value
        ]
"""

    let primitiveSourceCode =
        """
module Source

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent (x: int, y: float) =
        Html.div [ prop.text (sprintf "%i-%f" x y) ]
"""


module CurriedInput =

    let sourceCode =
        """
    module Source

    open Fable.Core
    open Feliz

    [<Erase; Mangle(false)>]
    type Source =

        [<ReactComponent(true)>]
        static member MyCodeSplitComponent (text: string) (testId: string option) =
            Html.div [
                prop.testId (defaultArg testId "none")
                prop.text text
            ]
    """

    let primitiveSourceCode =
        """
module Source

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent (x: int) (y: int) =
        Html.div [ prop.text (string (x + y)) ]
"""

module RecordTypeInput =

    let types =
        """
module Types

type PayloadClass(label: string) =
    member _.Label = label

type PayloadRecord = {
    Id: int
    Name: string option
    Meta: {| Flag: bool |}
    Owner: PayloadClass
}
"""

    let sourceCode =
        """
module Source

open Fable.Core
open Feliz
open Types

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent(props: PayloadRecord) =
        let name = defaultArg props.Name "none"

        Html.div [
            prop.text (sprintf "%i:%s:%s:%b" props.Id name props.Owner.Label props.Meta.Flag)
        ]
"""

module ClassInput =

    let types =
        """
module Types


type PayloadClass(label: string) =
    member _.Label = label

"""

    let sourceCode =
        """
module Source

open Fable.Core
open Feliz
open Types

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent(owner: PayloadClass) =
        Html.div [ prop.text owner.Label ]
"""

module AnonRecordTypeInput =

    let sourceCode =
        """
module Source

open Fable.Core
open Feliz

[<Erase; Mangle(false)>]
type Source =

    [<ReactComponent(true)>]
    static member MyCodeSplitComponent(props: {| id: int |}) =
        Html.div [ prop.text (string props.id) ]
"""
