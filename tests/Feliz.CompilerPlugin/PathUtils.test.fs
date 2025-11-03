module PathUtilsTests


type private ImportPaths = {
    FSharpPath: string
    ReactComponentImportPath: string
    ExpectedImportPath: string
} with
    static member create(fsharp: string, reactComponentImport: string, expectedImportPath: string) =
        {
            FSharpPath = fsharp
            ReactComponentImportPath = reactComponentImport
            ExpectedImportPath = expectedImportPath
        }

open Expecto

let private createTestResolveReactComponentPaths (fixture: ImportPaths) =
    let actual = Feliz.PathUtils.resolveReactComponentPaths fixture.FSharpPath fixture.ReactComponentImportPath
    let expected = fixture.ExpectedImportPath
    Expect.equal actual expected ""

[<Tests>]
let PathUtilsTests = testList "resolve `[<ReactComponent(member, paths)>]` paths" [
    test "F#-Source: Below, ImportPath: Above" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFolder/NestedFile.fs",
            reactComponentImport = "../Counter",
            expectedImportPath = "./Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Above, ImportPath: Above" {
        let fixture = ImportPaths.create(
            fsharp = "../NestedFile.fs",
            reactComponentImport = "../Counter",
            expectedImportPath = "../../Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: 4 Above, ImportPath: Above" {
        let fixture = ImportPaths.create(
            fsharp = "../../../../NestedFile.fs",
            reactComponentImport = "../Counter",
            expectedImportPath = "../../../../../Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Equal, ImportPath: Above" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFile.fs",
            reactComponentImport = "../Counter",
            expectedImportPath = "../Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Equal, ImportPath: Equal" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFile.fs",
            reactComponentImport = "./Counter",
            expectedImportPath = "./Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Equal, ImportPath: Below" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFile.fs",
            reactComponentImport = "./JsNative/Counter",
            expectedImportPath = "./JsNative/Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Below, ImportPath: Below" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFolder/NestedFile.fs",
            reactComponentImport = "./JsNative/Counter",
            expectedImportPath = "./NestedFolder/JsNative/Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: Above, ImportPath: Below" {
        let fixture = ImportPaths.create(
            fsharp = "../../NestedFile.fs",
            reactComponentImport = "./JsNative/Counter",
            expectedImportPath = "../../JsNative/Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: 3 Below, ImportPath: 2 Above" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFolder1/NestedFolder2/NestedFolder3/NestedFile.fs",
            reactComponentImport = "../../Counter",
            expectedImportPath = "./NestedFolder1/Counter"
        )
        createTestResolveReactComponentPaths fixture
    }

    test "F#-Source: 3 Below, ImportPath: node_module" {
        let fixture = ImportPaths.create(
            fsharp = "./NestedFolder1/NestedFolder2/NestedFolder3/NestedFile.fs",
            reactComponentImport = "my-awesome-lib",
            expectedImportPath = "my-awesome-lib"
        )
        createTestResolveReactComponentPaths fixture
    }
]
