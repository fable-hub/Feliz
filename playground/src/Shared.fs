module Shared

type TestRecord =
    {
        Name: string
        Age: int
    }

    member this.Greet() =
        sprintf "Hello, my name is %s and I am %i years old." this.Name this.Age
