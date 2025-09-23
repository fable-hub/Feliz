
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { printf, toText } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/String.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function TabCounter() {
    const patternInput = reactApi.useState(0);
    const count = patternInput[0] | 0;
    reactApi.useEffect(() => {
        document.title = toText(printf("Count = %d"))(count);
    });
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

export default TabCounter;

