module Examples.Guides.BrowserTypesEvents

open Browser.Types // for MouseEvent and File types
open Fable.Core.JsInterop // only used for `?` operator

let myButtonOnClick (e: MouseEvent) =
    Browser.Dom.console.log ("Button clicked at coordinates:", e.clientX, e.clientY)

let fileUpload (file: File, setData, setLoading) =
    if isNull file then
        ()
    else
        promise {
            // `.text()` is inherited from the `Blob` type: https://developer.mozilla.org/en-US/docs/Web/API/Blob
            let! (text: string) = file?text ()

            let values: string[][] =
                text.Split([| "\r\n"; "\n" |], System.StringSplitOptions.None)
                |> Array.map (fun line ->
                    line.Split([| "\t" |], System.StringSplitOptions.None)
                    |> Array.map (fun value -> value.Trim())
                )

            do! setData file.name values
        }
        |> Promise.catch (fun ex ->
            Browser.Dom.console.error ex
            setLoading false
        )
        |> Promise.start
