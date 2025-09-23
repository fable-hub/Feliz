
import { createElement } from "react";
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { singleton, append, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";
import { fromMilliseconds } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/TimeSpan.js";
import { join } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/String.js";
import { ofArray, singleton as singleton_1 } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function AnimationsOnHover(animationsOnHoverInputProps) {
    const content = animationsOnHoverInputProps.content;
    const patternInput = reactApi.useState(false);
    const setHovered = patternInput[1];
    return reactElement("div", {
        style: createObj(toList(delay(() => append(singleton(["padding", 10]), delay(() => append(singleton(["transitionDuration", fromMilliseconds(1000) + "ms"]), delay(() => append(singleton(["transitionProperty", join(",", ["background-color", "color"])]), delay(() => (patternInput[0] ? append(singleton(["backgroundColor", "#ADD8E6"]), delay(() => singleton(["color", "#000000"]))) : append(singleton(["backgroundColor", "#32CD32"]), delay(() => singleton(["color", "#FFFFFF"]))))))))))))),
        onMouseEnter: (_arg) => {
            setHovered(true);
        },
        onMouseLeave: (_arg_1) => {
            setHovered(false);
        },
        children: reactApi.Children.toArray(Array.from(content)),
    });
}

export function Main() {
    const children = ofArray([createElement(AnimationsOnHover, {
        content: singleton_1(reactElement("span", {
            children: ["Hover me!"],
        })),
    }), createElement(AnimationsOnHover, {
        content: singleton_1(reactElement("p", {
            children: ["So smooth"],
        })),
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Main;

