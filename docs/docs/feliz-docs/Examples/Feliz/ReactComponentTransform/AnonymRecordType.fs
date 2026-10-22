module Example.ReactComponentTransform.AnonymRecordType

open Feliz
open Feliz.JSX

type Props = {| text: string; count: int |}

[<ReactComponent>]
let Component (anoRecordType: Props) =
    Html.div [
        Html.text anoRecordType.text
        Html.text anoRecordType.count
    ]
