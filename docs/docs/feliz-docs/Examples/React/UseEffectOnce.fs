module Example.UseEffectOnce

open Feliz

[<ReactComponent(true)>]
let EffectWithAsyncOnce () =
    let (isLoading, setLoading) = React.useState (false)
    let (content, setContent) = React.useState ("")

    let loadData () = async {
        setLoading true
        do! Async.Sleep 1500
        setLoading false
        setContent "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
    }

    React.useEffectOnce (loadData >> Async.StartImmediate)

    Html.div [
        Html.p "Refresh this component to see the load effect run once"
        Html.p "This simulates loading data on mount"
        if isLoading then Html.h1 "Loading..." else Html.h1 content
    ]
