
import React from "react";
import { reactApi, reactElement } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { defaultArg } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Option.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function Greeting(greetingInputProps) {
    const name = greetingInputProps.name;
    const children = ofArray([reactElement("span", {
        children: ["Hello, "],
    }), reactElement("span", {
        children: [defaultArg(name, "World")],
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

