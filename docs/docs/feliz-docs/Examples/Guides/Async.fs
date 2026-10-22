module Examples.Guides.Async

let nativeJsPromiseMock () = promise {
    do! Promise.sleep 2000
    return [ 1; 2; 3; 4; 5 ]
}

open Fable.Core // contains `Async.AwaitPromise` and `Async.StartAsPromise`

let fetchData (setLoading: bool -> unit, setErrorMsg: System.Exception option -> unit, setData: list<int> -> unit) =
    async {
        setLoading true

        try
            let! data = nativeJsPromiseMock () |> Async.AwaitPromise // transform js promise to f# async
            setLoading false // set loading to false AFTER data is fetched
            setData data
        with err ->
            // handle error here
            setLoading false
            setErrorMsg (Some err)
    }
    |> Async.StartAsPromise // return async to promise
