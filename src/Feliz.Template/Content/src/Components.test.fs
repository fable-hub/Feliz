module Tests.Components

open Vitest
open Feliz

Vitest.describe (
    "Counter",
    fun () ->
        Vitest.test (
            "increments the counter when button is clicked",
            fun () -> promise {

                let ele = RTL.render (App.Components.Counter())

                let text = ele.getByTestId ("counter-display")

                Vitest.expect(text).toBeInTheDocument()
                Vitest.expect(text).toHaveTextContent("0")

                let btn = ele.getByTestId ("inc-btn")

                do! UserEvent.userEvent.click (btn)

                Vitest.expect(text).toHaveTextContent("1")
            }
        )
)