open SimpleExec
open BlackFox.CommandLine


module Tests =

    open System
    open System.IO
    open System.Text.Json

    [<Literal>]
    let TestRoot = "./tests"

    let hasMatchingFsproj dir (filterOpt: string option) =
        let fsprojFiles = Directory.GetFiles(dir, "*.fsproj")
        match filterOpt with
        | Some substr ->
            fsprojFiles
            |> Array.exists (fun path ->
                let projName = Path.GetFileNameWithoutExtension(path)
                projName.Equals(substr, StringComparison.OrdinalIgnoreCase)
            )
        | None -> fsprojFiles.Length > 0

    let hasTestScriptInPackageJson dir =
        let packageJsonPath = Path.Combine(dir, "package.json")
        if File.Exists(packageJsonPath) then
            try
                let json = File.ReadAllText(packageJsonPath)
                let doc = JsonDocument.Parse(json)
                match doc.RootElement.TryGetProperty("scripts") with
                | true, scripts when scripts.TryGetProperty("test") |> fst -> true
                | _ -> false
            with _ -> false
        else false

    let findValidTestFolders root filteropt =
        Directory.GetDirectories(root)
        |> Array.filter (fun dir -> hasMatchingFsproj dir filteropt && hasTestScriptInPackageJson dir)

    let run (workingDir: string) =
        let args =
            CmdLine.Empty
            |> CmdLine.append "test"
            |> CmdLine.toString

        Command.Run(
            "npm",
            args,
            workingDir
        )

    let runAll (filteropt: string option) =
        let testFolders = findValidTestFolders TestRoot filteropt
        for folder in testFolders do
            let folderName = Path.GetFileName(folder)
            printfn "Running tests in %s" folderName
            run folder
            printfn "Finished running tests in %s" folderName

[<EntryPoint>]
let main args =
    let argv = args |> Array.map (fun x -> x.ToLower()) |> Array.toList

    match argv with
    | "test" :: a ->
        match a with
        | [] -> Tests.runAll None
        | filter :: _ ->
            Tests.runAll (Some filter)
    | _ -> 
        printfn "Unknown command."
    0
