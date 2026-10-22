module Example.ReactComponentTransform.Curried

open Feliz
open Feliz.JSX

[<ReactComponent>]
let Component (text: string) (count: int) =
    Html.div [ Html.text text; Html.text count ]
