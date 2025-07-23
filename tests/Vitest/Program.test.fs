module Vitest.Tests 


module Examples =

    open Fable.Core
    let sum (a: int) (b: int) = a + b

    [<AttachMembers>]
    type MyClass() =
        member this.Value = 42

        member this.buy(item: string, ?quantity: int) =
            printfn "Buying %d of %s" (defaultArg quantity 1) item

    type Testing =
        {
            Value: int
            Test: string
        }

open Fable.Core.JsInterop

Vitest.describe("Vitest basics", fun () ->

    Vitest.test("sum adds two numbers", fun () ->
        let result = Examples.sum 2 3
        Vitest.expect(result).toBe(5)
    )

    Vitest.test("TestOptions timeout", TestOptions(timeout = 1000), fun () ->
        let result = Examples.sum 2 3
        Vitest.expect(result).toBe(5)
    )

    Vitest.test("TestOptions skip", TestOptions(skip = true), fun () ->
        failwith "This test should be skipped"
    )

    Vitest.test("TestOptions fails", TestOptions(fails=true), fun () ->
        failwith "This test should be skipped"
    )

    Vitest.test("TestOptions todo", TestOptions(todo=true), fun () ->
        failwith "This test should be skipped"
    )

    Vitest.test("not.tobe", fun () ->
        Vitest.expect(2 + 3).not.toBe(42)
    )

    Vitest.test("toBeCloseTo", fun () ->
        Vitest.expect(0.1 + 0.2).toBeCloseTo(0.3)
    )
    Vitest.test("toBeOneOf", fun () ->
        Vitest.expect(12).toBeOneOf(ResizeArray[1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12])
    )

    Vitest.test("toBeTypeOf", fun () ->
        Vitest.expect(fun () -> 1 + 3).toBeTypeOf TypeOf.Function
    )

    Vitest.test("toContain", fun () ->
        Vitest.expect([0 ..12]).toContain(5)
        Vitest.expect([|0 ..12|]).toContain(5)
        Vitest.expect("Test").toContain('T')
        Vitest.expect(ResizeArray([0..14])).toContain(0)
    )

    Vitest.test("toHaveProperty", fun () ->
        let obj = {|
            Value = 42
            Nested = {|
                Name = "Kevin"
            |}
        |}
        Vitest.expect(obj).toHaveProperty("Value")
        Vitest.expect(obj).toHaveProperty("Value", 42)
        Vitest.expect(obj).toHaveProperty(ResizeArray(["Nested"; "Name"]))
        Vitest.expect(obj).toHaveProperty(ResizeArray(["Nested"; "Name"]), "Kevin")
    )

    Vitest.test("toMatch", fun () ->
        let regex: System.Text.RegularExpressions.Regex = System.Text.RegularExpressions.Regex("^[A-Z][a-z]+$")
        let testString = "Hello"
        Vitest.expect(testString).toMatch(regex)
    )

    Vitest.test("toMatchObject", fun () ->
        let actual = {| name = "John"; age = 30 |}
        let expected = {| name = "John" |}
        Vitest.expect(actual).toMatchObject(expected)
    )

    Vitest.test("toThrowError", fun () ->
        let fn = fun () -> failwith "This is an error"
        Vitest.expect(fn).toThrowError("This is an error")
    )

    Vitest.test("toHaveBeenCalled", fun () ->

        let testobj = Examples.MyClass()

        let exampleSpy = Vitest.vi.spyOn(testobj, "Value", accessType = AccessType.Get)

        Vitest.expect(exampleSpy).not.toHaveBeenCalled()

        testobj.Value |> ignore

        Vitest.expect(exampleSpy).toHaveBeenCalled()
    )

    Vitest.test("toHaveBeenCalledWith", fun () ->

        let testobj = Examples.MyClass()

        let exampleSpy = Vitest.vi.spyOn(testobj, "buy")

        testobj.buy("apple", 3)
        testobj.buy("banana", 20)

        Vitest.expect(exampleSpy).toHaveBeenCalledWith([|"apple"; 3|])
        Vitest.expect(exampleSpy).toHaveBeenCalledWith([|"banana"; 20|])
    )

    Vitest.test("toSatisfy", fun () ->
        let isOdd x = x % 2 <> 0
        Vitest.expect(1).toSatisfy(isOdd)
    )

    Vitest.test("promise", fun () -> promise {
        let promise = fun () -> promise {
            do! Promise.sleep 2000
            return Examples.sum 2 3
        }

        let! result = promise()
        Vitest.expect(result).toBe(5)
    })

    Vitest.test("Expect.anything", fun () ->
        let actual = {|name = "Kevin"; number = 42|}
        Vitest.expect(actual).toEqual({|name = Vitest.Expect.anything(); number = Vitest.Expect.anything()|})
    )

    Vitest.test("Expect.any", fun () ->
        Vitest.expect(12).toEqual(Vitest.Expect.any(any.Number))
        Vitest.expect("Test string").toEqual(Vitest.Expect.any(any.String))
        Vitest.expect(ResizeArray [|1; 2; 3|]).toEqual(Vitest.Expect.any(any.Array))
        Vitest.expect({| key = "value" |}).toEqual(Vitest.Expect.any(any.Object))
        Vitest.expect(Examples.MyClass()).toEqual(Vitest.Expect.any(any.Object))
        Vitest.expect(fun () -> 1 + 3).toEqual(Vitest.Expect.any(any.Function))
    )

    Vitest.test("Expect.arrayContaining", fun () ->
        let actual = {|name = "Kevin"; strings = [|"Empire"; "Fuji"; "Gala"|]|}
        Vitest.expect(actual).toEqual({|name = "Kevin"; strings = Vitest.Expect.arrayContaining [|"Fuji"|]|})
    )

    Vitest.test("Expect.objectContaining", fun () ->
        let actual = {|name = "Kevin"; strings = [|"Empire"; "Fuji"; "Gala"|]|}
        Vitest.expect(actual).toEqual(Vitest.Expect.objectContaining {|name = "Kevin"|})
    )

    Vitest.test("Expect.stringContaining", fun () ->
        let actual = {|name = "Kevin"|}
        Vitest.expect(actual).toEqual({|name = Vitest.Expect.stringContaining("Kev")|})
    )

    Vitest.test("Expect.stringContaining", fun () ->
        let actual = {|name = "129381723897102938"|}
        Vitest.expect(actual).toEqual({|name = Vitest.Expect.stringMatching(System.Text.RegularExpressions.Regex("^[0-9]+$"))|})
    )

    Vitest.test("Expect.extend tobeFoo", fun () ->
        Vitest.Expect.extend({|
            toBeFoo = fun (received: string) (expected: obj) ->
                if received <> "foo" then
                    {|
                        message = fun () -> sprintf "Expected '%s' to be 'foo'" received
                        pass = false
                    |}
                else
                    {|
                        message = fun () -> "Nice"
                        pass = true
                    |}
        |})
        Vitest.expect("foo")?toBeFoo()
        Vitest.expect({|foo = "foo"|}).toEqual({|foo = Vitest.Expect?toBeFoo()|})
    )
)

Vitest.describe("TextContext", fun () -> 

    Vitest.test("sum adds two numbers with context", fun (ctx: TestContext) -> 
        let result = Examples.sum 2 3
        ctx.expect(result).toBe(5)
    )

    Vitest.test("sum adds two numbers with context", fun (ctx: TestContext) -> 
        ctx.skip()
        failwith "This test should be skipped"
    )

    Vitest.test("sum adds two numbers with context", fun (ctx: TestContext) -> 
        ctx.onTestFinished(fun x ->
            console.log(x.task.result.state)
        )
        let result = Examples.sum 2 3
        ctx.expect(result).toBe(5)
    )
)

Vitest.test("expect.soft", fun () ->
    let result = Examples.sum 2 3
    // Vitest.Expect.soft(result).toBe(6)
    // Vitest.expect(result).toBe(9)
    Vitest.expect(result).toEqual(5)
)

Vitest.describe("Nested Describe", fun () ->
    Vitest.test("sum adds two numbers in nested describe", fun (ctx: TestContext) -> 
        let result = Examples.sum 2 3
        ctx.expect(result).toBe(5)
    )

    Vitest.describe("Inner Describe", fun () -> 
        Vitest.test("sum adds two numbers in inner describe", fun (ctx: TestContext) -> 
            let result = Examples.sum 2 3
            ctx.expect(result).toBe(5)
        )
    )
)

Vitest.describe("Descripe TestOptions", fun () ->
    Vitest.describe("TestOptions with skip", TestOptions(skip = true), fun () ->
        Vitest.test("fails", fun (ctx: TestContext) -> 
            failwith "This test should be skipped"
        )
    )
)

Vitest.describe("Chain logic", fun () ->

    Vitest.Test.todo("skip", fun () ->
        let result = Examples.sum 2 3
        Vitest.expect(result).toBe(5)
    )

    Vitest.Test.Skip.concurrent("skip", fun () ->
        let result = Examples.sum 2 3
        Vitest.expect(result).toBe(5)
    )

    // Vitest.Test.Only.concurrent("only", fun () ->
    //     let result = Examples.sum 2 3
    //     Vitest.expect(result).toBe(5)
    // )

    Vitest.Test.Todo.concurrent("todo", fun () ->
        let result = Examples.sum 2 3
        Vitest.expect(result).toBe(5)
    )

    Vitest.Describe.concurrent("shuffle", fun () ->
    
        Vitest.test("suffle1", fun () ->
            let result = Examples.sum 2 3
            Vitest.expect(result).toBe(5) // This will fail
        )

        Vitest.test("suffle2", fun () ->
            let result = Examples.sum 2 3
            Vitest.expect(result).toBe(5) // This will also fail
        )

    )
)

Vitest.Describe.concurrent("async", fun () -> 

    Vitest.test("async test", fun () -> async {
        let! result = async {
            do! Async.Sleep 1000
            return Examples.sum 2 3
        }
        Vitest.expect(result).toBe(5)
    })

    Vitest.test("async test", async {
        let! result = async {
            do! Async.Sleep 1000
            return Examples.sum 2 3
        }
        Vitest.expect(result).toBe(5)
    })
)

describe "vi" <| fun _ ->
    testPromise "vi.waitFor" <| fun () -> promise {
        let mutable called = false
        let timer = 
            Fable.Core.JS.setTimeout (fun () ->
                called <- true
            ) 500

        do! Vitest.vi.waitFor (fun () -> 
            expect(called).toBeTruthy()
        )

        Fable.Core.JS.clearTimeout timer

        Vitest.expect(called).toBe true
    }

    testPromise "vi.waitFor above default" <| fun () -> promise {
        let mutable called = false
        let timer = 
            Fable.Core.JS.setTimeout (fun () ->
                called <- true
            ) 1500

        do! Vitest.vi.waitFor ((fun () -> 
            expect(called).toBeTruthy()), ViWaitForOptions(timeout = 2000)
        )

        Fable.Core.JS.clearTimeout timer

        Vitest.expect(called).toBe true
    }
