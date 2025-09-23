
import { nonSeeded } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Random.js";
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { sleep, startImmediate } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Async.js";
import { singleton } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/AsyncBuilder.js";
import { printf, toText } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/String.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export const rnd = nonSeeded();

export function EffectsUsingDependencies() {
    const patternInput = reactApi.useState(false);
    const setLoading = patternInput[1];
    const patternInput_1 = reactApi.useState("");
    const patternInput_2 = reactApi.useState(0);
    const userId = patternInput_2[0] | 0;
    const patternInput_3 = reactApi.useState("#FF0000");
    const setTextColor = patternInput_3[1];
    const dependencies = [userId];
    reactApi.useEffect(() => {
        startImmediate(singleton.Delay(() => {
            setLoading(true);
            return singleton.Bind(sleep(1500), () => {
                setLoading(false);
                patternInput_1[1](toText(printf("User %d"))(userId));
                return singleton.Zero();
            });
        }));
    }, dependencies);
    const children = ofArray([reactElement("h1", {
        style: {
            color: patternInput_3[0],
        },
        children: patternInput[0] ? "Loading" : patternInput_1[0],
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
    }), reactElement("button", {
        children: "Update User ID",
        onClick: (_arg_3) => {
            patternInput_2[1](rnd.Next2(1, 100));
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default EffectsUsingDependencies;

