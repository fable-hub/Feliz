module Example.Guides.FelizStyleBindings

open Fable.Core
open Fable.Core.JsInterop
open Feliz

module Helper =
    let inline mkProperty<'t> (key: string, value: obj) : 't = (key, box value) |> unbox<'t>

type FloatingFocusManagerProps = 
    interface end

[<Erase>]
type floatingFocusManager =
    static member inline prop (prop: IReactProperty) = prop |> unbox<FloatingFocusManagerProps>

    static member inline children(value: seq<ReactElement>) =
        Helper.mkProperty<FloatingFocusManagerProps>("children", value)

    static member inline context(value: obj) =
        Helper.mkProperty<FloatingFocusManagerProps>("context", value)

    static member inline disabled(value: bool) =
        Helper.mkProperty<FloatingFocusManagerProps>("disabled", value)

    static member inline initialFocus(obj: obj) =
        Helper.mkProperty<FloatingFocusManagerProps>("initialFocus", obj)
    
    static member inline returnFocus(value: bool) =
        Helper.mkProperty<FloatingFocusManagerProps>("returnFocus", value)

    static member inline guards(v: bool) =
        Helper.mkProperty<FloatingFocusManagerProps>("guards", v)


[<Erase>]
type FloatingUi =

    static member inline FloatingFocusManager(props: seq<FloatingFocusManagerProps>) = ReactLegacy.createElement(unbox<ReactElement> (import "FloatingFocusManager" "@floating-ui/react"), createObj !!props)

    static member inline FloatingFocusManager(children: seq<ReactElement>) = ReactLegacy.createElement(unbox<ReactElement> (import "FloatingFocusManager" "@floating-ui/react"), {|children = children|})

module App =

    [<ReactComponent>]
    let Example() =
        FloatingUi.FloatingFocusManager [
            floatingFocusManager.disabled false
            floatingFocusManager.returnFocus true
            floatingFocusManager.prop <| prop.id "my-focus-manager"
            floatingFocusManager.prop <| prop.key "my-focus-manager"
            floatingFocusManager.guards true
            floatingFocusManager.children [
                Html.div "Hello from Feliz!"
            ]
        ]

    [<ReactComponent>]
    let Example1() =
        FloatingUi.FloatingFocusManager [
            Html.div "Hello from Feliz!"
        ]

