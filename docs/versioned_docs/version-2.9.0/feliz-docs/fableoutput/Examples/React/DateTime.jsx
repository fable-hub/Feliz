
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { toString } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Date.js";
import { iterate, singleton, append, delay, toList } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Seq.js";
import { createObj } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Util.js";
import { toArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Option.js";
import { parse } from "../../fable_modules/Feliz.2.9.0/DateParsing.fs.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export function SwitchingBetweenDateAndDateTime() {
    const patternInput = reactApi.useState(undefined);
    const setDate = patternInput[1];
    const date = patternInput[0];
    const patternInput_1 = reactApi.useState(false);
    const dateAndTime = patternInput_1[0];
    const formattedDate = (date != null) ? ("Input: " + toString(date, "yyyy-MM-dd hh:mm")) : "No date selected yet";
    const children = toList(delay(() => append(singleton(reactElement("h3", {
        children: [formattedDate],
    })), delay(() => {
        let value_1, date_2, value_8, date_3;
        return append(dateAndTime ? singleton(reactElement("input", createObj(ofArray([(value_1 = date, (value_1 != null) ? ((date_2 = value_1, dateAndTime ? ["value", toString(date_2, "yyyy-MM-ddThh:mm")] : ["value", toString(date_2, "yyyy-MM-dd")])) : ["value", ""]), ["type", "datetime-local"], ["onChange", (ev) => {
            iterate((newValue) => {
                setDate(newValue);
            }, toArray(parse(ev.target.value)));
        }]])))) : singleton(reactElement("input", createObj(ofArray([(value_8 = date, (value_8 != null) ? ((date_3 = value_8, dateAndTime ? ["value", toString(date_3, "yyyy-MM-ddThh:mm")] : ["value", toString(date_3, "yyyy-MM-dd")])) : ["value", ""]), ["type", "date"], ["onChange", (ev_1) => {
            iterate((newValue_1) => {
                setDate(newValue_1);
            }, toArray(parse(ev_1.target.value)));
        }]])))), delay(() => append(singleton(reactElement("button", {
            children: "Reset selected date",
            disabled: date == null,
            onClick: (_arg) => {
                setDate(undefined);
            },
        })), delay(() => singleton(reactElement("button", {
            children: "Toggle date and time",
            disabled: date == null,
            onClick: (_arg_1) => {
                patternInput_1[1](!dateAndTime);
            },
        }))))));
    }))));
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default SwitchingBetweenDateAndDateTime;

