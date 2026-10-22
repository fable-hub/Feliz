namespace App

open Feliz

module ComponentsHelper =

    open Fable.Core
    open Fable.Core.JsInterop

    let Logo: string = importDefault "./img/felizlogo.svg"

type Components =

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let (count, setCount) = React.useState (0)

        Html.div [
            prop.className "flex min-h-screen bg-gray-100"
            prop.children [
                Html.div [
                    prop.className "container flex flex-col gap-2 [&_h1]:text-4xl items-center mx-auto pt-12"
                    prop.children [
                        Html.img [
                            prop.src ComponentsHelper.Logo
                            prop.className "w-48 h-48"
                        ]
                        Html.h1 [ prop.testId "counter-display"; prop.text count ]
                        Html.button [
                            prop.testId "inc-btn"
                            prop.className
                                "rounded bg-blue-500 text-white px-4 py-2 shadow cursor-pointer hover:bg-blue-600 transition-colors active:scale-95 text-lg"
                            prop.onClick (fun _ -> setCount (count + 1))
                            prop.text "Increment"
                        ]
                    ]
                ]
            ]
        ]