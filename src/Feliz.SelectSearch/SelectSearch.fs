namespace Feliz.SelectSearch

open System
open Feliz
open Fable.Core
open Fable.Core.JsInterop

type ISelectSearchAttribute = interface end

type SelectItem = { value: string; name: string; disabled: bool }

type SelectGroup = { name: string; items: SelectItem list }

[<RequireQualifiedAccess>]
type SelectOption =
    | Item of SelectItem
    | Group of SelectGroup

module Interop =
    [<Emit "Object.entries($0)">]
    let objectEntries (x: obj) : (string * obj) array = jsNative
    [<Emit "Object.assign({}, $0, $1)">]
    let objectAssign (x: obj) (y: obj) : obj = jsNative
    [<Emit "Array.isArray($0)">]
    let isArray (x: obj) : bool = jsNative
    let createDefaultFilter (predicate: SelectItem -> string -> bool) =
        System.Func<_,_>(fun (selectItems: obj[]) -> fun (searchQuery: string) ->
            if String.IsNullOrWhiteSpace searchQuery then
                selectItems
            else
                selectItems
                |> Array.filter (fun jsItem ->
                    let isGroup = jsItem?``type`` = "group"
                    let item = {
                        name = jsItem?name
                        value = jsItem?value
                        disabled = jsItem?disabled
                    }
                    isGroup || predicate item searchQuery
                )
                |> Array.map (fun jsItem ->
                    let isGroup = jsItem?``type`` = "group"
                    if isGroup then
                        // return a new group with filtered items
                        let groupItems : obj[] = jsItem?items
                        let filteredItems =
                            groupItems
                            |> Array.filter (fun groupItem ->
                                let item = {
                                    name = groupItem?name
                                    value = groupItem?value
                                    disabled = groupItem?disabled
                                }

                                predicate item searchQuery
                            )
                        objectAssign jsItem (createObj [ "items" ==> filteredItems ])
                    else
                        jsItem
                )
        )
    // provide a default filtering option
    // when search is enabled with case-insensitive matching
    // that takes groups into account
    let defaultProps = {|
        filterOptions = createDefaultFilter (fun item query ->
            item.name.ToLower().Contains(query.Trim().ToLower())
        )
    |}

[<Erase>]
type SelectSearch() =
    static member inline selectSearch (properties: ISelectSearchAttribute list) =
        let inputProperties = createObj !!properties
        Interop.reactApi.createElement(importDefault "react-select-search", Interop.objectAssign Interop.defaultProps inputProperties)

type OptionRendererProps = {
    attributes: IReactProperty seq
    className: string
    option: SelectItem
    selected: bool
    highlighted: bool
}

type ValueRendererProps = {
    attributes: IReactProperty seq
    focus: bool
    disabled: bool
    fetching: bool
    search: string
    displayValue: string
    values: string list
}

type selectSearch =
    /// <summary>Sets the options of the select control</summary>
    static member options (items: seq<SelectItem>) =
        let selectOptions = [|
            for item in items -> createObj [
                "value" ==> item.value
                "name" ==> item.name
                "disabled" ==> item.disabled
            ]
        |]

        unbox<ISelectSearchAttribute> ("options", selectOptions)

    /// <summary>Sets the options of the select control</summary>
    static member options (groups: seq<SelectGroup>) =
        let selectOptions = [|
            for group in groups -> createObj [
                "type" ==> "group"
                "name" ==> group.name
                "items" ==> [|
                    for item in group.items -> createObj [
                        "value" ==> item.value
                        "name" ==> item.name
                    ]
                |]
            ]
        |]

        unbox<ISelectSearchAttribute> ("options", selectOptions)

    /// <summary>Sets the options of the select control</summary>
    static member options (mixedOptions: seq<SelectOption>) =
        let selectOptions = [|
            for option in mixedOptions ->
                match option with
                | SelectOption.Item item ->
                    createObj [
                        "value" ==> item.value
                        "name" ==> item.name
                        "disabled" ==> item.disabled
                    ]
                | SelectOption.Group group ->
                    createObj [
                        "type" ==> "group"
                        "name" ==> group.name
                        "items" ==> [|
                            for item in group.items -> createObj [
                                "value" ==> item.value
                                "name" ==> item.name
                                "disabled" ==> item.disabled
                            ]
                        |]
                    ]
        |]

        unbox<ISelectSearchAttribute> ("options", selectOptions)

    /// <summary>Number of ms to wait until calling get options when searching</summary>
    static member inline debounce(debounceValue: int) = unbox<ISelectSearchAttribute> ("debounce", debounceValue)
    /// <summary>Sets the currently selected value when in controlled mode</summary>
    static member inline value(currentValue: string) = unbox<ISelectSearchAttribute> ("value", currentValue)
    /// <summary>Sets the currently selected values when in controlled mode and multiple is enabled</summary>
    static member inline value(currentValues: string[]) = unbox<ISelectSearchAttribute> ("value", currentValues)
    /// <summary>Sets the currently selected values when in controlled mode and multiple is enabled</summary>
    static member inline value(currentValues: string list) = unbox<ISelectSearchAttribute> ("value", Array.ofList currentValues)
    /// <summary>Set to true if you want to allow multiple selected options. False by default</summary>
    static member inline multiple(selectingMultipleValues: bool) = unbox<ISelectSearchAttribute> ("multiple", selectingMultipleValues)
    /// <summary>Set to true to enable search functionality. False by default</summary>
    static member inline search(searchable: bool) = unbox<ISelectSearchAttribute> ("search", searchable)
    /// <summary>Disables all functionality</summary>
    static member inline disabled(disableControl: bool) = unbox<ISelectSearchAttribute> ("disabled", disableControl)
    /// <summary>The selectbox will blur by default when selecting an option. Set this to false to prevent this behavior. True by default</summary>
    static member inline closeOnSelect(closeMenuOnSelect: bool) = unbox<ISelectSearchAttribute> ("closeOnSelect", closeMenuOnSelect)
    /// <summary>Displayed if no option is selected and/or when search field is focused with empty value.</summary>
    static member inline placeholder (text: string) = unbox<ISelectSearchAttribute> ("placeholder", text)
    /// <summary>HTML ID on the top level element</summary>
    static member inline id (elementIdentifier: string) = unbox<ISelectSearchAttribute> ("id", elementIdentifier)
    /// <summary>Autofocus on select</summary>
    static member inline autoFocus (autoFocusOnSelect: bool) = unbox<ISelectSearchAttribute>("authoFocus", autoFocusOnSelect)
    /// <summary>Set empty message for empty options list</summary>
    static member inline emptyMessage (message: string) = unbox<ISelectSearchAttribute> ("emptyMessage", message)
    /// <summary>Set empty message for empty options list</summary>
    static member inline emptyMessage (message: unit -> ReactElement) = unbox<ISelectSearchAttribute> ("emptyMessage", message)
    /// <summary>Function to receive and handle value changes.</summary>
    static member inline onChange (handler: string -> unit) =
        let internalHandler (values: obj) =
            if Interop.isArray values then
                let unboxed = unbox<string[]> values
                if (unboxed.Length > 0)
                then handler unboxed.[0]
            else
                let unboxed = unbox<string> values
                if not (String.IsNullOrWhiteSpace unboxed)
                then handler unboxed
        unbox<ISelectSearchAttribute> ("onChange", handler)
    /// <summary>Function to receive and handle value changes. Use this overload when multiple is set to true</summary>
    static member inline onChange (handler: string list -> unit) =
        let internalHandler (values: obj) =
            if Interop.isArray values then
                handler(Array.toList (unbox<string[]> values))
            else
                handler([ unbox<string> values ])
        unbox<ISelectSearchAttribute> ("onChange", internalHandler)
    /// <summary>Focus callback.</summary>
    static member inline onFocus(handler: unit -> unit) = unbox<ISelectSearchAttribute> ("onFocus", handler)
    /// <summary>Blur callback.</summary>
    static member inline onBlur(handler: unit -> unit) = unbox<ISelectSearchAttribute> ("onBlur", handler)
    /// <summary>Allows you to customize how each option is rendered</summary>
    static member inline renderOption (renderer: OptionRendererProps -> ReactElement) =
        let internalHandler = System.Func<obj, obj, obj, string, ReactElement>(fun props option snapshot classname ->
            let entries = Interop.objectEntries props
            renderer {
                attributes = unbox (Seq.toArray entries)
                className = classname
                option = { name = option?name; value = option?value; disabled = option?disabled }
                selected = unbox (snapshot?selected)
                highlighted = unbox (snapshot?highlighted)
            }
        )

        unbox<ISelectSearchAttribute> ("renderOption", internalHandler)

    /// <summary>Allows you to customize how the group header is render using the group name</summary>
    static member inline renderGroupHeader(renderer : string -> ReactElement) =
        unbox<ISelectSearchAttribute> ("renderGroupHeader", renderer)

    /// <summary>Allows you to customize how the search bar is rendered</summary>
    static member inline renderValue(renderer: ValueRendererProps -> ReactElement) =
        let internalHandler = System.Func<obj, obj, obj, ReactElement>(fun props snapshot selectedValue ->
            let entries = Interop.objectEntries props
            let values =
                if Interop.isArray (unbox(snapshot?value)) then
                    Array.toList (unbox<string[]> (snapshot?value))
                elif String.IsNullOrWhiteSpace (unbox(snapshot?value)) then
                    []
                else
                    [unbox<string> (snapshot?value)]

            renderer {
                attributes = unbox entries
                focus = unbox(snapshot?focus)
                disabled = unbox(snapshot?disabled)
                fetching = unbox(snapshot?fetching)
                search = unbox(snapshot?search)
                displayValue = unbox(snapshot?displayValue)
                values = values
            }
        )

        unbox<ISelectSearchAttribute> ("renderValue", internalHandler)

    /// <summary>
    /// When search is enabled, this function allows to define how items are filtered.
    /// By default, the built-in filtering checks whether the name of the select item contains input query (case-insensitive)
    /// </summary>
    static member filterOptions (predicate: SelectItem -> string -> bool) =
        unbox<ISelectSearchAttribute> ("filterOptions", Interop.createDefaultFilter predicate)

module selectSearch =
    importSideEffects "./SelectSearch.css"
    /// <summary>This property controls when the options list should be rendered.</summary>
    type printOptions =
        static member inline auto = unbox<ISelectSearchAttribute> ("printOptions", "auto")
        static member inline always = unbox<ISelectSearchAttribute> ("printOptions", "always")
        static member inline never = unbox<ISelectSearchAttribute> ("printOptions", "never")
        static member inline onFocus = unbox<ISelectSearchAttribute> ("printOptions", "on-focus")
    /// <summary>Disables/Enables autoComplete functionality in search field.</summary>
    type autoComplete =
        static member inline on = unbox<ISelectSearchAttribute> ("autoComplete", "on")
        static member inline off = unbox<ISelectSearchAttribute> ("autoComplete", "off")

