module Example.UseOptimistic

open Fable.Core
open Browser.Types
open Feliz

type ChatMessage = { Text: string; Sending: bool }

/// Pretends to send the message to a server.
let deliverMessage (text: string) : JS.Promise<string> = promise {
    do! Promise.sleep 1500
    return text
}

[<ReactComponent(true)>]
let UseOptimistic () =
    let messages, setMessages =
        React.useStateWithUpdater [ { Text = "Hello there!"; Sending = false } ]

    // While an action runs, show the messages plus the ones that are still being sent.
    let optimisticMessages, addOptimisticMessage =
        React.useOptimistic (messages, fun current (text: string) -> current @ [ { Text = text; Sending = true } ])

    let sendMessage (formData: FormData) = promise {
        let text = unbox<string> (formData.get "message")
        addOptimisticMessage text
        let! delivered = deliverMessage text
        React.startTransition (fun () -> setMessages (fun current -> current @ [ { Text = delivered; Sending = false } ]))
    }

    Html.div [
        Html.ul [
            for index, message in List.indexed optimisticMessages ->
                Html.li [
                    prop.key index
                    prop.style [ style.opacity (if message.Sending then 0.5 else 1.0) ]
                    prop.text (if message.Sending then message.Text + " (sending...)" else message.Text)
                ]
        ]
        Html.form [
            prop.action sendMessage
            prop.children [
                Html.input [ prop.name "message"; prop.placeholder "Say something" ]
                Html.button [ prop.type'.submit; prop.text "Send" ]
            ]
        ]
    ]
