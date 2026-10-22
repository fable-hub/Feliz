module Example.ReactComponentTransform.RecordType

type Props = { text: string; count: int }

open Feliz
open Feliz.JSX

[<ReactComponent>]
let Component (recordType: Props) =
    Html.div [ Html.text recordType.text; Html.text recordType.count ]
