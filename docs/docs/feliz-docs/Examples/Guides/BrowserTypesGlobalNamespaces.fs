module Examples.Guides.BrowserTypesGlobalNamespaces

open Browser.Dom

let getandSetWindowDimensions () =
    let width = window.innerWidth
    let height = window.innerHeight
    console.log ("Window dimensions:", width, height)
    let newDiv = document.createElement ("div")
    newDiv.textContent <- sprintf "Window dimensions: %A x %A" width height
    document.body.appendChild newDiv |> ignore
