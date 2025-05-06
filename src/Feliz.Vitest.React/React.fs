namespace Feliz.Vitest

// module React =

//     open System
//     open Feliz
//     open Browser.Types
//     open Browser.Dom
//     open Fable.Core
//     open Fable.ReactTestingLibrary

//     type IRenderer =
//         inherit IDisposable
//         abstract Container : unit -> HTMLElement

//     let renderReact (element: ReactElement) =
//         let id = Guid.NewGuid().ToString()
//         let container = document.createElement("div")
//         container.setAttribute("id", id)
//         document.body.appendChild(container) |> ignore
//         let root = ReactDOM.createRoot container
//         root.render element
//         { new IRenderer with
//             member this.Container() = container
//             member this.Dispose() = document.getElementById(id).remove() }

//     let inline testReact name testFunc =
//         test name <| fun _ ->
//             use rtl = { new IDisposable with member this.Dispose() = RTL.cleanup() }
//             testFunc()

//     let inline testReactAsync name test =
//         testPromise name <| fun () -> promise {
//             use rtl = { new IDisposable with member this.Dispose() = RTL.cleanup() }
//             let! _ = test
//             return ()
//         }

//     let inline ftestReact name test =
//         testOnly name <| fun _ ->
//             use rtl = { new IDisposable with member this.Dispose() = RTL.cleanup() }
//             test()

//     let inline ftestReactAsync name test =
//         testOnlyPromise name <| fun () -> promise {
//             use rtl = { new IDisposable with member this.Dispose() = RTL.cleanup() }
//             let! _ = test
//             return ()
//         }

//     [<Emit("$1['style'][$0]")>]
//     let getStyle<'t> (key: string) (x: HTMLElement) : 't = jsNative
