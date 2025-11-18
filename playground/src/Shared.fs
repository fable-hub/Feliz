module Shared

type AB = A | B
type AbNull = AB | null

type RecordField = { X: string | null }
type TupleField = string * string | null

type NestedGenerics = { Z : List<List<string | null> | null> | null }

type TestRecord =
    {
        Name: string
        Age: string | null
    }

    member this.Greet() =
        sprintf "Hello, my name is %s and I am %s years old." this.Name (this.Age |> function | null -> "unknown" | notNull -> notNull)
