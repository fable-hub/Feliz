module Feliz.PathUtils


open System
open System.IO

let isRelativeImport (path: string) =
    path.StartsWith(".")

/// Resolve relative import path based on F# source file path.
/// 
/// This function is used on [<ReactComponent(importMember, importPath)>] to resolve the relative importPath
/// based on the F# source file location.
let resolveReactComponentPaths (fsharpPath: string) (reactImport: string) =

    if isRelativeImport(reactImport) |> not then
        reactImport
    else
        let norm (s:string) = if String.IsNullOrEmpty(s) then s else s.Replace("\\", "/")
        let original = norm fsharpPath
        let dir =
            match Path.GetDirectoryName(original) with
            | null | "" -> "."
            | d -> norm d

        /// Append import path to f# source file directory, some examples:
        /// Exmp1: "../.././JsNative/Counter"
        /// Exmp2: "./NestedFolder/./JsNative/Counter"
        /// Exmp3: "./NestedFolder/../Counter"
        /// Exmp4: "./NestedFolder1/NestedFolder2/NestedFolder3/../../Counter"
        let combined = sprintf "%s/%s" (dir.TrimEnd('/')) ((norm reactImport).TrimStart('/'))
        let parts = combined.Split([| '/' |], StringSplitOptions.RemoveEmptyEntries) |> Array.toList

        /// Core logic:
        /// 1. Remove all "." segments
        /// 2. For ".." segments, pop the last valid segment from the stack if possible; otherwise, keep the ".." 
        /// Example:
        /// combined path: "./NestedFolder1/NestedFolder2/NestedFolder3/../../Counter"
        /// stack: [], segments: ["."; "NestedFolder1"; "NestedFolder2"; "NestedFolder3"; ".."; ".."; "Counter"] # rmv "."
        /// stack: [], segments: ["NestedFolder1"; "NestedFolder2"; "NestedFolder3"; ".."; ".."; "Counter"] # push "NestedFolder1"
        /// stack: ["NestedFolder1"], segments: ["NestedFolder2"; "NestedFolder3"; ".."; ".."; "Counter"] # push "NestedFolder2"
        /// stack: ["NestedFolder1"; "NestedFolder2"], segments: ["NestedFolder3"; ".."; ".."; "Counter"] # push "NestedFolder3"
        /// stack: ["NestedFolder1"; "NestedFolder2"; "NestedFolder3"], segments: [".."; ".."; "Counter"] # pop "NestedFolder3"
        /// stack: ["NestedFolder1"; "NestedFolder2"], segments: [".."; "Counter"] # pop "NestedFolder2"
        /// stack: ["NestedFolder1"], segments: ["Counter"] # push "Counter"
        /// stack: ["NestedFolder1"; "Counter"], segments: []
        let rec normalize stack segments =
            match segments with
            | [] -> stack
            | "."::xs -> normalize stack xs
            | ".."::xs ->
                match List.rev stack with
                | [] -> normalize (".."::stack) xs
                | h::_ when h = ".." -> normalize (".."::stack) xs // last stack is also "..", cannot pop
                | _ -> // last stack is path segment, can pop
                    let popped = List.rev stack |> List.tail |> List.rev 
                    normalize popped xs
            | x::xs -> normalize (stack @ [x]) xs

        let normalized = normalize [] parts
        let result = String.Join("/", normalized)

        // Not sure what to expect here, just trying to resolve some maybe errors:
        // If original started with "./" then preserve a leading "./" when the result
        // doesn't start with ".."; otherwise return as-is.
        let startedWithDot = original.StartsWith("./")

        if result = "" then if startedWithDot then "./" else "."
        elif result.StartsWith("..") then result
        elif startedWithDot then "./" + result
        else result
