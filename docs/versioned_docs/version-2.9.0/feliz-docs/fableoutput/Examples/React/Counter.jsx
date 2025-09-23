
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function Counter() {
    const patternInput = reactApi.useState(0);
    const count = patternInput[0] | 0;
    const children = ofArray([reactElement("h1", {
        children: [count],
    }), reactElement("button", {
        children: "Increment",
        onClick: (_arg) => {
            patternInput[1](count + 1);
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Counter;

