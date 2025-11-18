module Components 

open Feliz
open Fable.Core
open Fable.Core.JsInterop
open Shared

[<AttachMembers>]
type private RecordTypeInput = 
    { 
        Name: string; 
        Job: string;  
    }

    member this.Greet() =
        $"Hello, my name is {this.Name} and I work as a {this.Job}."

let private RecordTypeCtx =
    let init = Set.empty<RecordTypeInput>
    let setter = fun (_: Set<RecordTypeInput>) -> () 
    React.createContext({|state = init; setState = setter|})

[<ReactComponent>]
let private SingleRecordTypeInput(recordInput: RecordTypeInput) =
    let ctx = React.useContext RecordTypeCtx
    Html.div [
        Html.div [
            prop.testId "single-greet"
            prop.text (recordInput.Greet())
        ]
        Html.div [
            prop.testId "single-exists"
            prop.text (ctx.state |> Set.contains recordInput |> string)
        ]
    ]

[<ReactComponent>]
let RecordTypeContainer() = 
    let record = React.useMemo (fun () -> { Name = "Alice"; Job = "Engineer" }) 
    let records, setRecords = React.useState(Set [record])
    Html.div [
        RecordTypeCtx.Provider({|state = records; setState = setRecords|}, [
            for record in records do
                SingleRecordTypeInput(record)
        ])
    ]
