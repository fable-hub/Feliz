
import { createElement } from "react";
import React from "react";
import { createPortal } from "react-dom";
import { reactApi, reactElement } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";
import { empty, singleton, append, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";

export function Portal(portalInputProps) {
    const content = portalInputProps.content;
    return createPortal(content, document.body);
}

export function PortalsPopup() {
    let elems;
    return reactElement("div", createObj(ofArray([["style", {
        position: "fixed",
        top: 10,
        right: 10,
        padding: 10,
        backgroundColor: "#90EE90",
        zIndex: 1000,
    }], (elems = [reactElement("p", {
        children: "Portals can be used to escape the parent component.",
    })], ["children", reactApi.Children.toArray(Array.from(elems))])])));
}

export function PortalsContainer() {
    let elems;
    const patternInput = reactApi.useState(true);
    const showBanner = patternInput[0];
    return reactElement("div", createObj(ofArray([["style", {
        padding: 10,
        overflow: "hidden",
    }], (elems = toList(delay(() => append(singleton(reactElement("button", {
        children: "Toggle Popup",
        onClick: (_arg) => {
            patternInput[1](!showBanner);
        },
    })), delay(() => (showBanner ? singleton(createElement(Portal, {
        content: createElement(PortalsPopup, null),
    })) : empty()))))), ["children", reactApi.Children.toArray(Array.from(elems))])])));
}

export default PortalsContainer;

