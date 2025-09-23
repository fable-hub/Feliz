
import { useState } from "react";
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { useEffectWithDeps } from "../../fable_modules/Feliz.2.9.0/ReactInterop.js";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { singleton, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function EffectfulTimer() {
    const patternInput = reactApi.useState(false);
    const paused = patternInput[0];
    const patternInput_1 = useState(0);
    useEffectWithDeps(() => {
        const subscriptionId = setInterval(() => {
            if (!paused) {
                patternInput_1[1]((prev) => ((prev + 1) | 0));
            }
        }, 1000) | 0;
        return {
            Dispose() {
                clearInterval(subscriptionId);
            },
        };
    }, [paused]);
    const children = ofArray([reactElement("h1", {
        children: [patternInput_1[0]],
    }), reactElement("button", {
        style: createObj(toList(delay(() => (paused ? singleton(["backgroundColor", "yellow"]) : singleton(["backgroundColor", "green"]))))),
        onClick: (_arg_1) => {
            patternInput[1](!paused);
        },
        children: paused ? "Resume" : "Pause",
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default EffectfulTimer;

