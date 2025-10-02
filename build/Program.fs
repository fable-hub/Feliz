module Build

open SimpleExec
open BlackFox.CommandLine

[<AutoOpen>]
module Constants =

    [<Literal>]
    let TestRoot = "./tests"

    [<Literal>]
    let MainSlnFile = "./Feliz.sln"

    [<Literal>]
    let PackSlnFile = "./Feliz.Pack.sln"

    [<Literal>]
    let OutputDir = "./dist"

    [<Literal>]
    let NugetDefaultPushSource = "https://api.nuget.org/v3/index.json"

    [<Literal>]
    let NugetAPIKeyEnvVariable = "NUGET_API_KEY"

[<AutoOpenAttribute>]
module Utility =

    open System

    let inline printGreenfn fmt =
        Printf.kprintf (fun s ->
            let oldColor = Console.ForegroundColor
            Console.ForegroundColor <- ConsoleColor.Green
            Console.WriteLine s
            Console.ForegroundColor <- oldColor
        ) fmt

    let inline printRedfn fmt =
        Printf.kprintf (fun s ->
            let oldColor = Console.ForegroundColor
            Console.ForegroundColor <- ConsoleColor.Red
            Console.WriteLine s
            Console.ForegroundColor <- oldColor
        ) fmt


module Setup = 

    let dotnetToolRestore() =
        let args =
            CmdLine.Empty
            |> CmdLine.append "tool"
            |> CmdLine.append "restore"
            |> CmdLine.toString

        Command.Run(
            "dotnet",
            args
        )

    let npmInstall() =
        let args =
            CmdLine.Empty
            |> CmdLine.append "ci"
            |> CmdLine.toString

        Command.Run(
            "npm",
            args
        )

    let dotnetRestore() =
        let args =
            CmdLine.Empty
            |> CmdLine.append "restore"
            |> CmdLine.append MainSlnFile
            |> CmdLine.toString

        Command.Run(
            "dotnet",
            args
        )

    let all() =
        printGreenfn "Restoring dotnet tools"
        dotnetToolRestore()
        printGreenfn "Restoring npm packages"
        npmInstall()
        printGreenfn "Restoring dotnet packages"
        dotnetRestore()
module Tests =

    open System
    open System.IO
    open System.Text.Json

    let hasMatchingFsproj dir (filterOpt: string option) =
        let fsprojFiles = Directory.GetFiles(dir, "*.fsproj")
        match filterOpt with
        | Some substr ->
            fsprojFiles
            |> Array.exists (fun path ->
                let projName = Path.GetFileNameWithoutExtension(path)
                projName
                    .Replace(".tests", "", StringComparison.OrdinalIgnoreCase) // do this before ".test", or it will keep the "s".abs
                    .Replace(".test", "", StringComparison.OrdinalIgnoreCase)
                    .Equals(substr, StringComparison.OrdinalIgnoreCase)
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
        match filteropt with
        | Some filter ->
            printGreenfn "Running tests in folder matching %s" filter
        | None ->
            printGreenfn "Running tests in all folders"
        let testFolders = findValidTestFolders TestRoot filteropt
        for folder in testFolders do
            let folderName = Path.GetFileName(folder)
            printGreenfn "Running tests in %s" folderName
            run folder
            printGreenfn "Finished running tests in %s" folderName


module Pack =

    open System
    open System.IO
    open System.Text.Json

    

    let cleanOutputDir(path: string) =
        if Directory.Exists(path) then
            printGreenfn "Cleaning output directory: %s" path
            Directory.Delete(path, true)

    let checkPackedFiles() =
        let files = Directory.GetFiles(OutputDir, "*.nupkg")
        if files.Length = 0 then
            failwithf "No .nupkg files found in %s" OutputDir
        else
            printGreenfn "Found %d .nupkg files in %s" files.Length OutputDir

    let pack() =

        let SlnFullPath = Path.GetFullPath PackSlnFile
        let OutputDirFullPath = Path.GetFullPath OutputDir

        printGreenfn "Packing solution: %s" SlnFullPath

        cleanOutputDir(OutputDirFullPath)

        let args =
            CmdLine.Empty
            |> CmdLine.append "pack"
            |> CmdLine.append SlnFullPath
            |> CmdLine.appendPrefix "-o" OutputDirFullPath
            |> CmdLine.toString

        Command.Run(
            "dotnet",
            args
        )


module Release =

    open System
    open System.IO


    let release(apiKey: string) =

        if String.IsNullOrWhiteSpace(apiKey) then
            printRedfn "%s key not found in environment variables" NugetAPIKeyEnvVariable
            failwithf "%s key not found in environment variables" NugetAPIKeyEnvVariable
    
        let files = Directory.GetFiles(OutputDir, "*.nupkg")
        if files.Length = 0 then
            printRedfn "No .nupkg files found in %s" OutputDir
            failwithf "No .nupkg files found in %s" OutputDir

        printGreenfn "Pushing %d packages to Nuget" files.Length

        let args =
            CmdLine.Empty
            |> CmdLine.append "nuget"
            |> CmdLine.append "push"
            |> CmdLine.append ("*.nupkg")
            |> CmdLine.appendPrefix "-k" apiKey
            |> CmdLine.appendPrefix "-s" NugetDefaultPushSource
            |> CmdLine.append "--skip-duplicate"
            |> CmdLine.toString
        
        Command.Run(
            "dotnet",
            args,
            workingDirectory = Path.GetFullPath OutputDir
        )

[<EntryPoint>]
let main args =
    let argv = args |> Array.map (fun x -> x.ToLower()) |> Array.toList

    match argv with
    | "setup" :: _ ->
        Setup.all()
    | "test" :: a ->
        match a with
        | filter :: _ ->
            Tests.runAll (Some filter)
        | [] ->
            Tests.runAll None
    | "pack" :: _ ->
        Pack.pack()
    | "release" :: a ->
        match a with 
        | apiKey :: _ -> 
            Release.release(apiKey)
        | [] ->
            let apiKey = System.Environment.GetEnvironmentVariable(NugetAPIKeyEnvVariable)
            Release.release(apiKey)
    | "release-pipeline" :: a ->
        match a with 
        | apiKey :: _ -> 
            Setup.all()
            Tests.runAll None
            Pack.pack()
            Release.release(apiKey)
        | [] ->
            let apiKey = System.Environment.GetEnvironmentVariable(NugetAPIKeyEnvVariable)
            Setup.all()
            Tests.runAll None
            Pack.pack()
            Release.release(apiKey)
    | "develop" :: _ ->
        // Placeholder for develop command
        printfn "Develop command is not implemented yet."
    | _ -> 
        printfn "Unknown command."
    0
