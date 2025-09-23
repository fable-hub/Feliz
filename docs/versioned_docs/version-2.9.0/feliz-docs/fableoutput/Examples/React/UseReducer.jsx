
import { Union, Record } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Types.js";
import { union_type, record_type, int32_type } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Reflection.js";
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

export class State extends Record {
    constructor(Count) {
        super();
        this.Count = (Count | 0);
    }
}

export function State_$reflection() {
    return record_type("Example.UseReducer.State", [], State, () => [["Count", int32_type]]);
}

export class Msg extends Union {
    constructor(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["Increment", "Decrement"];
    }
}

export function Msg_$reflection() {
    return union_type("Example.UseReducer.Msg", [], Msg, () => [[], []]);
}

export const initialState = new State(0);

export function update(state, _arg) {
    if (_arg.tag === 1) {
        return new State(state.Count - 1);
    }
    else {
        return new State(state.Count + 1);
    }
}

export function Counter() {
    const patternInput = reactApi.useReducer(update, initialState);
    const dispatch = patternInput[1];
    const children = ofArray([reactElement("button", {
        onClick: (_arg_1) => {
            dispatch(new Msg(0, []));
        },
        children: "Increment",
    }), reactElement("button", {
        onClick: (_arg_2) => {
            dispatch(new Msg(1, []));
        },
        children: "Decrement",
    }), reactElement("h1", {
        children: [patternInput[0].Count],
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Counter;

