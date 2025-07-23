module Example.EffectfulOnce

open Feliz

[<ReactComponent(true)>]
let EffectWithAsyncOnce() =
    let (isLoading, setLoading) = React.useState(false)
    let (content, setContent) = React.useState("")

    let loadData() = async {
        setLoading true
        do! Async.Sleep 1500
        setLoading false
        setContent "Content"
    }

    React.useEffect(loadData >> Async.StartImmediate, [| |])

    Html.div [
        if isLoading
        then Html.h1 "Loading..."
        else Html.h1 content
    ]
