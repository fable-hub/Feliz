
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function MultipleVariables() {
    const patternInput = reactApi.useState(0);
    const count = patternInput[0] | 0;
    const patternInput_1 = reactApi.useState("#FF0000");
    const setTextColor = patternInput_1[1];
    const children = ofArray([reactElement("h1", {
        style: {
            color: patternInput_1[0],
        },
        children: count,
    }), reactElement("button", {
        children: "Increment",
        onClick: (_arg) => {
            patternInput[1](count + 1);
        },
    }), reactElement("button", {
        children: "Red",
        onClick: (_arg_1) => {
            setTextColor("#FF0000");
        },
    }), reactElement("button", {
        children: "Blue",
        onClick: (_arg_2) => {
            setTextColor("#0000FF");
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default MultipleVariables;

