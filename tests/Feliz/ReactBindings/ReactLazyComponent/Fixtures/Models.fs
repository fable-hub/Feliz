module Tests.ReactBindings.ReactLazyComponent.Fixtures.Models

type DemoClass(label: string) =
    member _.Label = label

type DemoRecord = {
    Id: int
    Name: string option
    Meta: {| score: int |}
    Owner: DemoClass
}

let createDemoRecord id name score ownerLabel = {
    Id = id
    Name = name
    Meta = {| score = score |}
    Owner = DemoClass(ownerLabel)
}
