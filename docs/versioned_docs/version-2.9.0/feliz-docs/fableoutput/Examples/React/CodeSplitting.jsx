
import { reactApi, reactElement } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import React from "react";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { empty, singleton, append, delay as delay_1, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";
import { value as value_5 } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Option.js";
import { PromiseBuilder__Delay_62FBFDE1, PromiseBuilder__Run_212F1D4B } from "../../fable_modules/Fable.Promise.3.2.0/Promise.fs.js";
import { promise } from "../../fable_modules/Fable.Promise.3.2.0/PromiseImpl.fs.js";
import { singleton as singleton_1 } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function MyNonCodeSplitComponent() {
    return reactElement("div", {
        children: "I was loaded synchronously!",
    });
}

export const asyncComponent = import("./Counter.jsx");

export function CodeSplitting(codeSplittingInputProps) {
    let elems;
    const delay = codeSplittingInputProps.delay;
    return reactElement("div", createObj(singleton_1((elems = toList(delay_1(() => append(singleton(MyNonCodeSplitComponent()), delay_1(() => append((delay != null) ? singleton(reactElement("div", {
        children: `I will be loaded after ${value_5(delay)} milliseconds!`,
    })) : empty(), delay_1(() => {
        let children_2, children, fallback, o;
        return singleton((children_2 = singleton_1((children = singleton_1(reactApi.createElement(reactApi.lazy(() => PromiseBuilder__Run_212F1D4B(promise, PromiseBuilder__Delay_62FBFDE1(promise, () => (((delay != null) ? ((new Promise(resolve => setTimeout(resolve, value_5(delay)))).then(() => (Promise.resolve(undefined)))) : (Promise.resolve())).then(() => PromiseBuilder__Delay_62FBFDE1(promise, () => (asyncComponent))))))), undefined)), reactElement("div", {
            children: reactApi.Children.toArray(Array.from(children)),
        }))), (fallback = reactElement("div", {
            children: "Loading...",
        }), reactApi.createElement(reactApi.Suspense, (o = {
            fallback: fallback,
        }, Object.assign({}, o)), ...children_2))));
    })))))), ["children", reactApi.Children.toArray(Array.from(elems))]))));
}

export default CodeSplitting;

