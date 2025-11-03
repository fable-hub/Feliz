module RelativePathImportsTests

open Feliz
open Vitest

describe "[<ReactComponent(module, path)>], resolved relative path" <| fun _ ->

    describe "Root Level" <| fun _ ->
    
        test "Equal" <| fun _ ->
            RTL.render(
                NativeCounterRoot.Equal()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below1" <| fun _ ->
            RTL.render(
                NativeCounterRoot.Below1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below2" <| fun _ ->
            RTL.render(
                NativeCounterRoot.Below2()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below3" <| fun _ ->
            RTL.render(
                NativeCounterRoot.Below3()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

    describe "NF1 Level" <| fun _ ->

        test "Equal" <| fun _ ->
            RTL.render(
                NativeCounter1.Equal()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below1" <| fun _ ->
            RTL.render(
                NativeCounter1.Below1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below2" <| fun _ ->
            RTL.render(
                NativeCounter1.Below2()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above1" <| fun _ ->
            RTL.render(
                NativeCounter1.Above1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

    describe "NF2 Level" <| fun _ ->

        test "Equal" <| fun _ ->
            RTL.render(
                NativeCounter2.Equal()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Below1" <| fun _ ->
            RTL.render(
                NativeCounter2.Below1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above2" <| fun _ ->
            RTL.render(
                NativeCounter2.Above2()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above1" <| fun _ ->
            RTL.render(
                NativeCounter2.Above1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

    describe "NF3 Level" <| fun _ ->

        test "Equal" <| fun _ ->
            RTL.render(
                NativeCounter3.Equal()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above3" <| fun _ ->
            RTL.render(
                NativeCounter3.Above3()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above2" <| fun _ ->
            RTL.render(
                NativeCounter3.Above2()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        test "Above1" <| fun _ ->
            RTL.render(
                NativeCounter3.Above1()
            ) |> ignore

            let div = RTL.screen.getByTestId "counter"

            expect(div).toBeInTheDocument()

        
