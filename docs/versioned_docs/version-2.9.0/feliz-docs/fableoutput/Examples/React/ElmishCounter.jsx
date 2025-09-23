
import { Record, Union } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Types.js";
import { record_type, int32_type, union_type } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Reflection.js";
import { Cmd_none } from "../../fable_modules/Fable.Elmish.4.0.0/cmd.fs.js";
import React from "react";
import { React_useElmish_Z6C327F2E } from "../../fable_modules/Feliz.UseElmish.2.5.0/UseElmish.fs.js";
import { ProgramModule_mkProgram } from "../../fable_modules/Fable.Elmish.4.0.0/program.fs.js";
import { reactApi, reactElement } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { ofArray } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/List.js";

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
    return union_type("Example.ElmishCounter.Msg", [], Msg, () => [[], []]);
}

export class State extends Record {
    constructor(Count) {
        super();
        this.Count = (Count | 0);
    }
}

export function State_$reflection() {
    return record_type("Example.ElmishCounter.State", [], State, () => [["Count", int32_type]]);
}

export function init() {
    return [new State(0), Cmd_none()];
}

export function update(msg, state) {
    if (msg.tag === 1) {
        return [new State(state.Count - 1), Cmd_none()];
    }
    else {
        return [new State(state.Count + 1), Cmd_none()];
    }
}

export function Main() {
    const patternInput = React_useElmish_Z6C327F2E(() => ProgramModule_mkProgram(init, update, (_arg, _arg_1) => {
    }), undefined, []);
    const dispatch = patternInput[1];
    const children = ofArray([reactElement("h1", {
        children: [patternInput[0].Count],
    }), reactElement("button", {
        children: "Increment",
        onClick: (_arg_2) => {
            dispatch(new Msg(0, []));
        },
    }), reactElement("button", {
        children: "Decrement",
        onClick: (_arg_3) => {
            dispatch(new Msg(1, []));
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Main;

