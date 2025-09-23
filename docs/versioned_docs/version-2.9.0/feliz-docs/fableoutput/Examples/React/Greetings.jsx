
import { createElement } from "react";
import React from "react";
import { reactApi, reactElement } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { Greeting } from "./Greeting.jsx";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function Greetings() {
    let elems;
    return reactElement("div", createObj(ofArray([["className", "content"], (elems = [createElement(Greeting, {
        name: "John",
    }), createElement(Greeting, {})], ["children", reactApi.Children.toArray(Array.from(elems))])])));
}

export default Greetings;

