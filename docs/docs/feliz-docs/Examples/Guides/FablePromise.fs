module Examples.Guides.FablePromise

let fetchDataMock =
    fun () -> promise {
        do! Promise.sleep 2000
        return [ 1; 2; 3; 4; 5 ]
    }

let fetchData (setLoading: bool -> unit, setErrorMsg: System.Exception option -> unit, setData: list<int> -> unit) =
    // f# computational expression (CE), `promise { ... }`
    promise {
        setLoading true
        // `let!` is alike to `let data = await ...` in JS/TS
        let! data = fetchDataMock ()
        setLoading false // set loading to false AFTER data is fetched
        return data
    }
    |> Promise.map (fun data -> // could have been done inside the CE too, this is just for demonstration
        setData data
    )
    |> Promise.catch (fun err ->
        // handle error here
        setLoading false
        setErrorMsg (Some err)
    )
