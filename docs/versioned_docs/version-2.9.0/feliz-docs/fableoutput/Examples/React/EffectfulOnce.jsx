
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { sleep, startImmediate } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Async.js";
import { singleton } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/AsyncBuilder.js";
import { singleton as singleton_1, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";

export function EffectWithAsyncOnce() {
    const patternInput = reactApi.useState(false);
    const setLoading = patternInput[1];
    const patternInput_1 = reactApi.useState("");
    reactApi.useEffect(() => {
        startImmediate(singleton.Delay(() => {
            setLoading(true);
            return singleton.Bind(sleep(1500), () => {
                setLoading(false);
                patternInput_1[1]("Content");
                return singleton.Zero();
            });
        }));
    }, []);
    const children = toList(delay(() => (patternInput[0] ? singleton_1(reactElement("h1", {
        children: ["Loading..."],
    })) : singleton_1(reactElement("h1", {
        children: [patternInput_1[0]],
    })))));
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default EffectWithAsyncOnce;

