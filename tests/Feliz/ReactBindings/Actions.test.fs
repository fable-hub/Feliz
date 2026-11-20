module Tests.ReactBindings.ActionsTests

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types
open Vitest
open Vitest.PromiseTest

let private formValue (formData: FormData) (name: string) : string = !!(formData?get (name))

type Components =
    [<ReactComponent>]
    static member FormWithAction(onSubmit: string -> unit) =
        Html.form [
            prop.action (fun (formData: FormData) -> onSubmit (formValue formData "name"))
            prop.children [
                Html.input [ prop.testId "name"; prop.name "name" ]
                Html.button [
                    prop.testId "submit"
                    prop.type'.submit
                    prop.text "Submit"
                ]
            ]
        ]

    [<ReactComponent>]
    static member ActionStateCounter() =
        let count, increment, _ =
            React.useActionState ((fun (previous: int) (_: FormData) -> previous + 1), 0)

        Html.form [
            prop.action increment
            prop.children [
                Html.p [ prop.testId "count"; prop.text count ]
                Html.button [
                    prop.testId "submit"
                    prop.type'.submit
                    prop.text "Increment"
                ]
            ]
        ]

    [<ReactComponent>]
    static member AsyncActionState(reply: JS.Promise<string>) =
        let message, submit, isPending =
            React.useActionState (
                (fun (_: string) (formData: FormData) -> promise {
                    let! reply = reply
                    return formValue formData "name" + ": " + reply
                }),
                "none"
            )

        Html.form [
            prop.action submit
            prop.children [
                Html.input [ prop.name "name"; prop.defaultValue "Ada" ]
                Html.p [ prop.testId "message"; prop.text message ]
                Html.p [ prop.testId "pending"; prop.text (string isPending) ]
                Html.button [
                    prop.testId "submit"
                    prop.type'.submit
                    prop.text "Send"
                ]
            ]
        ]

    [<ReactComponent>]
    static member ManualDispatch() =
        let total, add, _ =
            React.useActionState ((fun (total: int) (amount: int) -> total + amount), 0)

        Html.button [
            prop.testId "add"
            prop.onClick (fun _ -> React.startTransition (fun () -> add 5))
            prop.text (string total)
        ]

    [<ReactComponent>]
    static member SubmitButton() =
        let status = ReactDOM.useFormStatus ()

        Html.button [
            prop.testId "submit"
            prop.type'.submit
            prop.disabled status.pending
            prop.text (
                match status.data with
                | Some data when status.pending -> "Submitting " + formValue data "name"
                | _ -> "Submit"
            )
        ]

    [<ReactComponent>]
    static member FormWithStatus(work: JS.Promise<unit>) =
        Html.form [
            prop.action (fun (_: FormData) -> work)
            prop.children [
                Html.input [ prop.name "name"; prop.defaultValue "Grace" ]
                Components.SubmitButton()
            ]
        ]

    [<ReactComponent>]
    static member OptimisticMessages(send: JS.Promise<unit>) =
        let messages, setMessages = React.useState ([]: string list)

        let optimisticMessages, addOptimistic =
            React.useOptimistic (messages, fun current (pending: string) -> current @ [ pending + " (sending)" ])

        let sendAction (formData: FormData) = promise {
            let text = formValue formData "message"
            addOptimistic text
            do! send
            React.startTransition (fun () -> setMessages (messages @ [ text ]))
        }

        Html.form [
            prop.action sendAction
            prop.children [
                Html.ul [
                    prop.testId "messages"
                    prop.children [
                        for message in optimisticMessages -> Html.li [ prop.key message; prop.text message ]
                    ]
                ]
                Html.input [ prop.name "message"; prop.defaultValue "hi" ]
                Html.button [ prop.testId "send"; prop.type'.submit; prop.text "Send" ]
            ]
        ]

    [<ReactComponent>]
    static member OptimisticValue(save: JS.Promise<unit>) =
        let liked, setLiked = React.useState false
        let optimisticLiked, setOptimisticLiked = React.useOptimistic liked

        Html.form [
            prop.action (fun (_: FormData) -> promise {
                setOptimisticLiked true
                do! save
                React.startTransition (fun () -> setLiked true)
            })
            prop.children [
                Html.p [ prop.testId "liked"; prop.text (string optimisticLiked) ]
                Html.button [ prop.testId "like"; prop.type'.submit; prop.text "Like" ]
            ]
        ]

    [<ReactComponent>]
    static member TwoSubmitButtons(onSave: unit -> unit, onDraft: unit -> unit) =
        Html.form [
            prop.action (fun (_: FormData) -> onSave ())
            prop.children [
                Html.button [ prop.testId "save"; prop.type'.submit; prop.text "Save" ]
                Html.button [
                    prop.testId "draft"
                    prop.type'.submit
                    prop.formAction (fun (_: FormData) -> onDraft ())
                    prop.text "Draft"
                ]
            ]
        ]

    [<ReactComponent>]
    static member ManualReset() =
        Html.form [
            prop.onSubmit (fun ev ->
                ev.preventDefault ()
                let form = unbox<HTMLFormElement> ev.currentTarget
                React.startTransition (fun () -> ReactDOM.requestFormReset form)
            )
            prop.children [
                Html.input [
                    prop.testId "field"
                    prop.name "field"
                    prop.defaultValue "initial"
                ]
                Html.button [
                    prop.testId "submit"
                    prop.type'.submit
                    prop.text "Submit"
                ]
            ]
        ]

describe "form actions"
<| fun _ ->
    testPromise "prop.action receives the form data"
    <| fun _ -> promise {
        let onSubmit: string -> unit = vi.fn (fun _ -> ())
        RTL.render (Components.FormWithAction(onSubmit)) |> ignore

        do! userEvent.``type`` (RTL.screen.getByTestId "name", "Ada")
        do! userEvent.click (RTL.screen.getByTestId "submit")

        do! RTL.waitFor (fun () -> expect(onSubmit).toHaveBeenCalledWith [| "Ada" |])
        // React resets uncontrolled fields after a form action.
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "name").toHaveValue "")
    }

    testPromise "prop.formAction overrides the form action"
    <| fun _ -> promise {
        let onSave: unit -> unit = vi.fn (fun () -> ())
        let onDraft: unit -> unit = vi.fn (fun () -> ())
        RTL.render (Components.TwoSubmitButtons(onSave, onDraft)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "draft")

        do! RTL.waitFor (fun () -> expect(onDraft).toHaveBeenCalledTimes 1)
        expect(onSave).toHaveBeenCalledTimes 0
    }

    testPromise "requestFormReset resets uncontrolled fields"
    <| fun _ -> promise {
        RTL.render (Components.ManualReset()) |> ignore
        let field = RTL.screen.getByTestId "field"

        do! userEvent.clear field
        do! userEvent.``type`` (field, "changed")
        expect(field).toHaveValue "changed"

        do! userEvent.click (RTL.screen.getByTestId "submit")

        do! RTL.waitFor (fun () -> expect(field).toHaveValue "initial")
    }

describe "useActionState"
<| fun _ ->
    testPromise "updates state from a sync action"
    <| fun _ -> promise {
        RTL.render (Components.ActionStateCounter()) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "submit")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "count").toHaveTextContent "1")

        do! userEvent.click (RTL.screen.getByTestId "submit")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "count").toHaveTextContent "2")
    }

    testPromise "is pending until an async action settles"
    <| fun _ -> promise {
        let reply = deferred<string>()
        RTL.render (Components.AsyncActionState(reply.promise)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "submit")

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "pending").toHaveTextContent "true")
        expect(RTL.screen.getByTestId "message").toHaveTextContent "none"

        reply.resolve "hello"

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "message").toHaveTextContent "Ada: hello")
        expect(RTL.screen.getByTestId "pending").toHaveTextContent "false"
    }

    testPromise "can be dispatched with a custom payload inside a transition"
    <| fun _ -> promise {
        RTL.render (Components.ManualDispatch()) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "add")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "add").toHaveTextContent "5")
    }

describe "useFormStatus"
<| fun _ ->
    testPromise "reports the pending submission of the parent form"
    <| fun _ -> promise {
        let work = deferred<unit>()
        RTL.render (Components.FormWithStatus(work.promise)) |> ignore
        let button = RTL.screen.getByTestId "submit"

        expect(button).toBeEnabled()
        do! userEvent.click button

        do! RTL.waitFor (fun () -> expect(button).toHaveTextContent "Submitting Grace")
        expect(button).toBeDisabled()

        work.resolve ()

        do! RTL.waitFor (fun () -> expect(button).toHaveTextContent "Submit")
        expect(button).toBeEnabled()
    }

describe "useOptimistic"
<| fun _ ->
    testPromise "shows the optimistic state while the action runs"
    <| fun _ -> promise {
        let send = deferred<unit>()
        RTL.render (Components.OptimisticMessages(send.promise)) |> ignore

        do! userEvent.click (RTL.screen.getByTestId "send")

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "messages").toHaveTextContent "hi (sending)")

        send.resolve ()

        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "messages").not.toHaveTextContent "sending")
        expect(RTL.screen.getByTestId "messages").toHaveTextContent "hi"
    }

    testPromise "sets an optimistic value without an update function"
    <| fun _ -> promise {
        let save = deferred<unit>()
        RTL.render (Components.OptimisticValue(save.promise)) |> ignore
        expect(RTL.screen.getByTestId "liked").toHaveTextContent "false"

        do! userEvent.click (RTL.screen.getByTestId "like")
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "liked").toHaveTextContent "true")

        save.resolve ()
        do! RTL.waitFor (fun () -> expect(RTL.screen.getByTestId "liked").toHaveTextContent "true")
    }
