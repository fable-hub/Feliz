module TranspileUtils

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions
open System.Threading.Tasks
open Expecto

type SnippetSpec = {
    Name: string
    SourceCode: string
    AdditionalFiles: (string * string) list
}

type TranspileSuccess = {
    WorkspaceDirectory: string
    ProjectFilePath: string
    SourceFilePath: string
    OutputDirectory: string
    SourceOutputPath: string
    EmittedFiles: string list
    StandardOutput: string
    StandardError: string
    CombinedOutput: string
}

type TranspileFailure = {
    WorkspaceDirectory: string
    ProjectFilePath: string
    SourceFilePath: string
    OutputDirectory: string
    ExitCode: int
    StandardOutput: string
    StandardError: string
    CombinedOutput: string
}

type TranspileResult =
    | Success of TranspileSuccess
    | Failure of TranspileFailure

type private ProcessResult = {
    ExitCode: int
    StandardOutput: string
    StandardError: string
    CombinedOutput: string
}

let private transpileLock = obj ()

let createSnippet (name: string) (sourceCode: string) = {
    Name = name
    SourceCode = sourceCode
    AdditionalFiles = []
}

let withAdditionalFile (fileName: string) (fileContents: string) (spec: SnippetSpec) = {
    spec with
        AdditionalFiles = spec.AdditionalFiles @ [ fileName, fileContents ]
}

let private sanitizeName (name: string) =
    if String.IsNullOrWhiteSpace name then
        "snippet"
    else
        let invalidChars = Path.GetInvalidFileNameChars() |> Set.ofArray

        name
        |> Seq.map (fun c ->
            if Char.IsWhiteSpace c || Set.contains c invalidChars then
                '-'
            else
                Char.ToLowerInvariant c
        )
        |> Seq.toArray
        |> String

let private toXmlPath (path: string) = path.Replace("\\", "/")

let private readEnvironmentBool (variableName: string) =
    match Environment.GetEnvironmentVariable(variableName) with
    | null -> false
    | value ->
        value.Equals("1", StringComparison.OrdinalIgnoreCase)
        || value.Equals("true", StringComparison.OrdinalIgnoreCase)

let private shouldKeepArtifacts =
    readEnvironmentBool "FELIZ_TRANSPILE_TESTS_KEEP_ARTIFACTS"

let private combineOutput (standardOutput: string) (standardError: string) =
    [
        if not (String.IsNullOrWhiteSpace standardOutput) then
            standardOutput.TrimEnd()
        if not (String.IsNullOrWhiteSpace standardError) then
            standardError.TrimEnd()
    ]
    |> String.concat Environment.NewLine

let private runProcess (workingDirectory: string) (command: string) (args: string list) =
    use proc = new Process()

    let startInfo = ProcessStartInfo()
    startInfo.FileName <- command
    startInfo.WorkingDirectory <- workingDirectory
    startInfo.UseShellExecute <- false
    startInfo.RedirectStandardOutput <- true
    startInfo.RedirectStandardError <- true

    for argument in args do
        startInfo.ArgumentList.Add(argument)

    proc.StartInfo <- startInfo

    if not (proc.Start()) then
        failwithf "Could not start process '%s'." command

    let standardOutputTask = proc.StandardOutput.ReadToEndAsync()
    let standardErrorTask = proc.StandardError.ReadToEndAsync()

    proc.WaitForExit()
    Task.WaitAll [| standardOutputTask :> Task; standardErrorTask :> Task |]

    let standardOutput = standardOutputTask.Result
    let standardError = standardErrorTask.Result

    {
        ExitCode = proc.ExitCode
        StandardOutput = standardOutput
        StandardError = standardError
        CombinedOutput = combineOutput standardOutput standardError
    }

let private tryFindRepoRoot (startDirectory: string) =
    let rec loop (directory: string) =
        let globalJson = Path.Combine(directory, "global.json")

        if File.Exists(globalJson) then
            Some directory
        else
            let parent = Directory.GetParent(directory)

            if isNull parent then None else loop parent.FullName

    loop startDirectory

let private getRepoRoot () =
    match tryFindRepoRoot AppContext.BaseDirectory with
    | Some root ->
        let transpileTempRoot = Path.Combine(root, "tests", "Transpile.Tests", "temp")
        Directory.CreateDirectory(transpileTempRoot) |> ignore
        root
    | None ->
        failwithf
            "Could not locate repository root from '%s'. Expected to find global.json in one of the parent directories."
            AppContext.BaseDirectory

let private createWorkspace (repoRoot: string) (name: string) =
    let tempRoot = Path.Combine(repoRoot, "tests", "Transpile.Tests", "temp")
    Directory.CreateDirectory(tempRoot) |> ignore

    let folderName = sprintf "%s-%s" (sanitizeName name) (Guid.NewGuid().ToString("N"))
    let workspace = Path.Combine(tempRoot, folderName)
    Directory.CreateDirectory(workspace) |> ignore
    workspace

let private writeFile (path: string) (contents: string) =
    let directory = Path.GetDirectoryName(path)

    if not (String.IsNullOrWhiteSpace directory) then
        Directory.CreateDirectory(directory) |> ignore

    File.WriteAllText(path, contents, Encoding.UTF8)

let private createProjectFileContents (felizProjectPath: string) (compileFiles: string list) =
    let compileEntries =
        compileFiles
        |> List.map (fun file -> sprintf "    <Compile Include=\"%s\" />" (toXmlPath file))
        |> String.concat Environment.NewLine

    [
        "<Project Sdk=\"Microsoft.NET.Sdk\">"
        "  <PropertyGroup>"
        "    <TargetFramework>net10.0</TargetFramework>"
        "  </PropertyGroup>"
        "  <ItemGroup>"
        compileEntries
        "  </ItemGroup>"
        "  <ItemGroup>"
        sprintf "    <ProjectReference Include=\"%s\" />" (toXmlPath felizProjectPath)
        "  </ItemGroup>"
        "</Project>"
    ]
    |> String.concat Environment.NewLine

let private createTranspileWorkspace (repoRoot: string) (spec: SnippetSpec) =
    let workspace = createWorkspace repoRoot spec.Name
    let sourceFileName = "Snippet.fs"
    let projectFileName = "Snippet.fsproj"
    let sourcePath = Path.Combine(workspace, sourceFileName)
    let projectPath = Path.Combine(workspace, projectFileName)
    let outputDirectory = Path.Combine(workspace, "fableoutput")

    writeFile sourcePath spec.SourceCode

    let additionalFileNames =
        spec.AdditionalFiles
        |> List.map (fun (fileName, fileContents) ->
            if Path.IsPathRooted(fileName) then
                invalidArg (nameof fileName) "Additional files must use relative paths."

            let normalizedFileName = fileName.Replace("\\", "/")
            let filePath = Path.Combine(workspace, normalizedFileName)
            writeFile filePath fileContents
            normalizedFileName
        )

    let felizProjectPath = Path.Combine(repoRoot, "src", "Feliz", "Feliz.fsproj")

    let projectContents =
        createProjectFileContents felizProjectPath ([ sourceFileName ] @ additionalFileNames)

    writeFile projectPath projectContents

    workspace, projectPath, sourcePath, outputDirectory

let private tryGetSourceOutputPath (outputDirectory: string) =
    let expectedPath = Path.Combine(outputDirectory, "Snippet.jsx")

    if File.Exists expectedPath then
        Some expectedPath
    elif Directory.Exists outputDirectory then
        Directory.GetFiles(outputDirectory, "Snippet*.jsx", SearchOption.AllDirectories)
        |> Array.tryHead
    else
        None

let private getEmittedFiles (outputDirectory: string) =
    if Directory.Exists outputDirectory then
        Directory.GetFiles(outputDirectory, "*.jsx", SearchOption.AllDirectories)
        |> Array.toList
    else
        []

let transpileSnippet (spec: SnippetSpec) =
    let repoRoot = getRepoRoot ()

    let workspace, projectPath, sourcePath, outputDirectory =
        createTranspileWorkspace repoRoot spec

    let processResult =
        lock
            transpileLock
            (fun () ->
                runProcess repoRoot "dotnet" [
                    "tool"
                    "run"
                    "fable"
                    projectPath
                    "-o"
                    outputDirectory
                    "--exclude"
                    "Feliz.CompilerPlugins"
                    "--noCache"
                    "-e"
                    ".jsx"
                ]
            )

    if processResult.ExitCode = 0 then
        let sourceOutputPath =
            match tryGetSourceOutputPath outputDirectory with
            | Some path -> path
            | None -> Path.Combine(outputDirectory, "Snippet.jsx")

        Success {
            WorkspaceDirectory = workspace
            ProjectFilePath = projectPath
            SourceFilePath = sourcePath
            OutputDirectory = outputDirectory
            SourceOutputPath = sourceOutputPath
            EmittedFiles = getEmittedFiles outputDirectory
            StandardOutput = processResult.StandardOutput
            StandardError = processResult.StandardError
            CombinedOutput = processResult.CombinedOutput
        }
    else
        Failure {
            WorkspaceDirectory = workspace
            ProjectFilePath = projectPath
            SourceFilePath = sourcePath
            OutputDirectory = outputDirectory
            ExitCode = processResult.ExitCode
            StandardOutput = processResult.StandardOutput
            StandardError = processResult.StandardError
            CombinedOutput = processResult.CombinedOutput
        }

let private getWorkspaceDirectory =
    function
    | Success result -> result.WorkspaceDirectory
    | Failure result -> result.WorkspaceDirectory

let cleanupArtifacts (result: TranspileResult) =
    if shouldKeepArtifacts then
        ()
    else
        let workspace = getWorkspaceDirectory result

        if Directory.Exists workspace then
            try
                Directory.Delete(workspace, true)
            with _ ->
                ()

let private withTranspileResultInternal
    (cleanupAfterAssertion: bool)
    (spec: SnippetSpec)
    (assertion: TranspileResult -> unit)
    =
    let result = transpileSnippet spec

    try
        assertion result
    finally
        if cleanupAfterAssertion then
            cleanupArtifacts result

let withTranspileResult (spec: SnippetSpec) (assertion: TranspileResult -> unit) =
    withTranspileResultInternal true spec assertion

let withTranspileResultKeepArtifacts (spec: SnippetSpec) (assertion: TranspileResult -> unit) =
    withTranspileResultInternal false spec assertion

let private assertTranspileSuccess (assertion: TranspileSuccess -> unit) (result: TranspileResult) =
    match result with
    | Success success ->
        if not (File.Exists success.SourceOutputPath) then
            let emittedFiles =
                if List.isEmpty success.EmittedFiles then
                    "<none>"
                else
                    String.concat Environment.NewLine success.EmittedFiles

            failtestf
                "Transpilation succeeded but expected output file was not found at '%s'. Emitted files:%s%s"
                success.SourceOutputPath
                Environment.NewLine
                emittedFiles

        assertion success

    | Failure failure ->
        failtestf
            "Expected transpilation success but transpilation failed with exit code %d.%s%s"
            failure.ExitCode
            Environment.NewLine
            failure.CombinedOutput

let withTranspileSuccess (spec: SnippetSpec) (assertion: TranspileSuccess -> unit) =
    withTranspileResult spec (assertTranspileSuccess assertion)

let withTranspileSuccessKeepArtifacts (spec: SnippetSpec) (assertion: TranspileSuccess -> unit) =
    withTranspileResultKeepArtifacts spec (assertTranspileSuccess assertion)

let withTranspileFailure (spec: SnippetSpec) (assertion: TranspileFailure -> unit) =
    withTranspileResult
        spec
        (fun result ->
            match result with
            | Failure failure ->
                Expect.isTrue
                    (not (String.IsNullOrWhiteSpace failure.CombinedOutput))
                    "Transpilation failed but no error diagnostics were captured."

                assertion failure

            | Success success ->
                failtestf
                    "Expected transpilation failure but transpilation succeeded. Output file: %s"
                    success.SourceOutputPath
        )

let readSourceOutput (success: TranspileSuccess) =
    if File.Exists success.SourceOutputPath then
        File.ReadAllText(success.SourceOutputPath, Encoding.UTF8)
    else
        failtestf "Expected transpiled source output at '%s' but file does not exist." success.SourceOutputPath

let expectDiagnosticContains (expectedFragment: string) (failure: TranspileFailure) =
    Expect.stringContains
        failure.CombinedOutput
        expectedFragment
        (sprintf "Expected transpile diagnostics to contain '%s'." expectedFragment)

let expectDiagnosticMentionsSourceFile (failure: TranspileFailure) =
    let sourceFileName = Path.GetFileName(failure.SourceFilePath)

    Expect.stringContains
        failure.CombinedOutput
        sourceFileName
        (sprintf "Expected transpile diagnostics to mention source file '%s'." sourceFileName)

let tryFindDiagnosticLocation (failure: TranspileFailure) =
    let locationPattern =
        Regex(@"(?<file>[^\r\n()]+\.fs)\((?<line>\d+),(?<column>\d+)\)")

    let location = locationPattern.Match(failure.CombinedOutput)

    if location.Success then
        let fileName = location.Groups["file"].Value
        let line = int location.Groups["line"].Value
        let column = int location.Groups["column"].Value
        Some(fileName, line, column)
    else
        None

let expectDiagnosticHasLocation (failure: TranspileFailure) =
    match tryFindDiagnosticLocation failure with
    | Some _ -> ()
    | None ->
        failtestf
            "Expected transpile diagnostics to include a source location in the form file.fs(line,column). Diagnostics:%s%s"
            Environment.NewLine
            failure.CombinedOutput
