---
title: Feliz.UseDeferred
---

# Feliz.UseDeferred [![Nuget](https://img.shields.io/nuget/v/Feliz.UseDeferred.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.UseDeferred)

Dead-simple data fetching hook for React component. It turns an asynchronous operation `Async<'T>` into a state variable that describes the current status of that operation. It comes in the following flavours:

- `React.useDeferred`
- `React.useDeferredCallback`
- `React.useDeferredParallel`

### `React.useDeferred` and `React.useDeferredCallback`

The first variant `React.useDeferred` is the simplest one as it takes an asynchronous operations and a list of dependencies (similar to `React.useEffect`) and returns you a `Deferred<'T>` that you can use right away:

```fsharp
open Feliz
open Feliz.UseDeferred

[<ReactComponent>]
let BasicDeferred() =
    let loadData = async {
        do! Async.Sleep 1000
        return "Hello!"
    }

    let data = React.useDeferred(loadData, [| |])

    match data with
    | Deferred.HasNotStartedYet -> Html.none
    | Deferred.InProgress -> Html.i [ prop.className [ "fa"; "fa-refresh"; "fa-spin"; "fa-2x" ] ]
    | Deferred.Failed error -> Html.div error.Message
    | Deferred.Resolved content -> Html.h1 content
```

The operation is executed immediately as soon as the component mounts. This makes an easy way to build components that only to fetch and present the data right away. However, when more control is required that is where `React.useDeferredCallback` comes into play as it allows you to control when the operation is executed and what you want to do with the data after it has finished loading. For example, the same component above can be reweritten in a more explicit fashion using `React.useDeferredCallback`:

```fsharp
[<ReactComponent>]
let BasicDeferred() =
    let loadData = async {
        do! Async.Sleep 1000
        return "Hello!"
    }

    let (data, setData) = React.useState(Deferred.HasNotStartedYet)

    let startLoadingData = React.useDeferredCallback((fun () -> loadData), setData)

    React.useEffect(startLoadingData, [| |])

    match data with
    | Deferred.HasNotStartedYet -> Html.none
    | Deferred.InProgress -> Html.i [ prop.className [ "fa"; "fa-refresh"; "fa-spin"; "fa-2x" ] ]
    | Deferred.Failed error -> Html.div error.Message
    | Deferred.Resolved content -> Html.h1 content
```

### Advanced example with `React.useDeferredCallback`

Here is a more complicated sample where it uses `React.useDeferredCallback` hook to implement a login form

```fsharp
open Feliz
open Feliz.UseDeferred

let login username password = async {
    do! Async.Sleep 1500
    if username = "admin" && password = "admin"
    then return Ok "admin"
    else return Error "Credentials incorrect"
}

[<ReactComponent>]
let LoginForm() =
    let (loginState, setLoginState) = React.useState(Deferred.HasNotStartedYet)
    let usernameRef = React.useInputRef()
    let passwordRef = React.useInputRef()

    let login() =
        match usernameRef.current, passwordRef.current with
        | Some username, Some password -> login username.value password.value
        | _ -> failwith "Component hasn't been initialized"

    let startLogin = React.useDeferredCallback(login, setLoginState)

    let message =
        match loginState with
        | Deferred.HasNotStartedYet -> Html.none
        | Deferred.InProgress -> Html.none
        | Deferred.Failed error ->
            Html.p [
                prop.style [ style.color.red ]
                prop.text (sprintf "Internal error: %s" error.Message)
            ]

        | Deferred.Resolved (Ok user) ->
            Html.p [
                prop.style [ style.color.green ]
                prop.text (sprintf "User %s logged in" user)
            ]

        | Deferred.Resolved (Error error) ->
            Html.p [
                prop.style [ style.color.red ]
                prop.text (sprintf "Login error: %s" error)
            ]

    Html.div [
        Html.div [
            prop.className "field"
            prop.children [
                Html.label [ prop.className "label"; prop.text "Username" ]
                Html.div [
                    prop.className "control"
                    prop.children [
                        Html.input [
                            prop.className "input"
                            prop.ref usernameRef
                            prop.placeholder "Username"
                            prop.disabled (Deferred.inProgress loginState)
                        ]
                    ]
                ]
            ]
        ]

        Html.div [
            prop.className "field"
            prop.children [
                Html.label [ prop.className "label"; prop.text "Password" ]
                Html.div [
                    prop.className "control"
                    prop.children [
                        Html.input [
                            prop.className "input"
                            prop.ref passwordRef
                            prop.placeholder "Password"
                            prop.disabled (Deferred.inProgress loginState)
                            prop.type'.password
                        ]
                    ]
                ]
            ]
        ]

        message

        Html.button [
            prop.className [
                "button is-primary";
                if Deferred.inProgress loginState
                then "is-loading"
            ]

            prop.text "Login"
            prop.disabled (Deferred.inProgress loginState)
            prop.onClick(fun _ -> startLogin())
        ]
    ])
```

### `React.useDeferredParallel`

You can use `Async.Parallel` to create a single parallel asynchronous operation made from multiple operations. Combine that with the `React.useDeferred` hook and you can control the state of the entire operation in one `Deferred<'T>` variable. However, if you want to take control of the state of each individual operation, then `React.useDeferredParallel` is your friend.

The hook `React.useDeferredParallel` allows you to load multiple asynchronous operations in parallel while giving you fine-grained access to the state of _each_ operation separately! The following example demonstrates how to load data that is dependent on another asynchronous operation which is common when you need to run requests that depend on each other:

```fsharp
[<ReactComponent>]
let ParallelDeferred() =
    let loadIds = async {
        do! Async.Sleep 1000
        return [ 1 .. 5 ]
    }

    let loadItem itemId = async {
        do! Async.Sleep (itemId * 1000)
        return sprintf "Loaded item %d" itemId
    }

    let itemIds = React.useDeferred(loadIds, [|  |])

    let items = React.useDeferredParallel(itemIds, fun ids -> [ for itemId in ids -> itemId, loadItem itemId ])

    match itemIds with
    | Deferred.HasNotStartedYet -> Html.none
    | Deferred.InProgress -> Html.i [ prop.className [ "fa"; "fa-refresh"; "fa-spin"; "fa-2x" ] ]
    | Deferred.Failed error -> Html.h1 "oops"
    | Deferred.Resolved ids ->
        Html.ul [
            for (id, item) in items ->
            React.keyedFragment(id, [
                match item with
                | Deferred.HasNotStartedYet -> Html.none
                | Deferred.InProgress -> Html.li [ Html.i [ prop.className [ "fa"; "fa-refresh"; "fa-spin" ] ] ]
                | Deferred.Failed error -> Html.h1 "Oops"
                | Deferred.Resolved item -> Html.li item
            ])
        ]
```
