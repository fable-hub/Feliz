
import { forwardRef } from "../../fable_modules/Feliz.2.9.0/Internal.fs.js";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { toArray, map } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Option.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";
import React from "react";
import { iterate } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";

export const ForwardRefImperativeChild = forwardRef((tupledArg) => {
    const patternInput = reactApi.useState("");
    const inputRef = reactApi.useRef(undefined);
    reactApi.useImperativeHandle(tupledArg[1], (() => map((innerRef) => ({
        focus: () => {
            patternInput[1](innerRef.className);
        },
    }), inputRef.current)));
    const children = ofArray([reactElement("input", {
        className: "Howdy!",
        type: "text",
        ref: inputRef,
    }), reactElement("div", {
        children: patternInput[0],
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
});

export function ForwardRefImperativeParent() {
    const ref = reactApi.useRef(undefined);
    const children = ofArray([ForwardRefImperativeChild([undefined, ref]), reactElement("button", {
        children: "Focus Input",
        onClick: (ev) => {
            iterate((elem) => {
                elem.focus();
            }, toArray(ref.current));
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default ForwardRefImperativeParent;

