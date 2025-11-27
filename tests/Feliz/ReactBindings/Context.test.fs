module Tests.ReactBindings.ContextTests

open Fable.Core
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser
open Vitest

[<Erase; Mangle(false)>]
module TestContext =

    let MyContext = React.createContext<{|state: string; setState: string -> unit|}>()

type Components =

    [<ReactComponent>]
    static member ComponentContextConsumer() =
        let value = React.useContext(TestContext.MyContext)

        Html.div [
            Html.div [
                prop.testId "context-value"
                prop.text value.state
            ]
            Html.button [
                prop.onClick (fun _ -> value.setState "Updated value")
                prop.testId "update-context"
                prop.text "Update Context"
            ]
        ]

    [<ReactComponent>]
    static member ComponentContextProvider() =
        let value, setValue = React.useState "Provided value"

        TestContext.MyContext.Provider(
            {| state = value; setState = setValue|}, 
            [
                Components.ComponentContextConsumer()
            ]
        )

describe "React Context" <| fun _ ->
    testPromise "provides and consumes context value" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        expect(valueDiv).toHaveTextContent "Provided value"
    }

    testPromise "updates context via consumer interaction" <| fun _ -> promise {
        RTL.render (Components.ComponentContextProvider())
        |> ignore

        let valueDiv = RTL.screen.getByTestId "context-value"
        let button = RTL.screen.getByTestId "update-context"

        expect(valueDiv).toHaveTextContent "Provided value"

        do! userEvent.click(button)

        expect(valueDiv).toHaveTextContent "Updated value"
    }
