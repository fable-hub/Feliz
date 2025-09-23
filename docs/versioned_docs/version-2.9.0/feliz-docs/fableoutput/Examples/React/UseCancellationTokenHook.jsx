
import { createElement } from "react";
import React from "react";
import { useCancellationToken } from "../../fable_modules/Feliz.2.9.0/Internal.fs.js";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { sleep, startImmediate } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Async.js";
import { singleton } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/AsyncBuilder.js";
import { defaultOf } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { empty, singleton as singleton_1, append, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";

function UseToken(useTokenInputProps) {
    const failedCallback = useTokenInputProps.failedCallback;
    const token = useCancellationToken();
    reactApi.useEffect(() => {
        startImmediate(singleton.Delay(() => singleton.Bind(sleep(4000), () => {
            failedCallback();
            return singleton.Zero();
        })), token.current);
    });
    return defaultOf();
}

export function Main() {
    const patternInput = reactApi.useState(true);
    const setRenderChild = patternInput[1];
    const renderChild = patternInput[0];
    const patternInput_1 = reactApi.useState("Pending...");
    const setResultText = patternInput_1[1];
    const resultText = patternInput_1[0];
    const setFailed = reactApi.useCallback(() => {
        setResultText("You didn\'t cancel me in time!");
    }, []);
    const isDisabled = resultText === "Disposed";
    const children = toList(delay(() => append(renderChild ? singleton_1(createElement(UseToken, {
        failedCallback: setFailed,
    })) : empty(), delay(() => append(singleton_1(reactElement("div", {
        children: [resultText],
    })), delay(() => append(singleton_1(reactElement("button", {
        disabled: isDisabled,
        children: "Dispose",
        onClick: (_arg) => {
            startImmediate(singleton.Delay(() => {
                setResultText("Disposed");
                setRenderChild(false);
                return singleton.Zero();
            }));
        },
    })), delay(() => singleton_1(reactElement("button", {
        disabled: renderChild && (resultText === "Pending..."),
        children: "Reset",
        onClick: (_arg_1) => {
            startImmediate(singleton.Delay(() => {
                setResultText("Pending...");
                setRenderChild(true);
                return singleton.Zero();
            }));
        },
    }))))))))));
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Main;

