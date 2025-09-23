
import { Record, Union } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Types.js";
import { record_type, int32_type, union_type } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Reflection.js";
import { Cmd_none } from "../../fable_modules/Fable.Elmish.4.0.0/cmd.fs.js";
import React from "react";
import { reactElement, reactApi } from "../../fable_modules/Feliz.2.9.0/Interop.fs.js";
import { React_useElmish_Z6C327F2E } from "../../fable_modules/Feliz.UseElmish.2.5.0/UseElmish.fs.js";
import { ProgramModule_mkProgram } from "../../fable_modules/Fable.Elmish.4.0.0/program.fs.js";
import { useEffectWithDeps } from "../../fable_modules/Feliz.2.9.0/ReactInterop.js";
import { some } from "../../fable_modules/fable-library-js.5.0.0-alpha.14/Option.js";
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
    return union_type("Example.ElmishCounterSubscription.Msg", [], Msg, () => [[], []]);
}

export class State extends Record {
    constructor(Count) {
        super();
        this.Count = (Count | 0);
    }
}

export function State_$reflection() {
    return record_type("Example.ElmishCounterSubscription.State", [], State, () => [["Count", int32_type]]);
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
    const patternInput = reactApi.useState(0);
    const localCount = patternInput[0] | 0;
    const patternInput_1 = React_useElmish_Z6C327F2E(() => ProgramModule_mkProgram(init, update, (_arg, _arg_1) => {
    }), undefined, []);
    const dispatch = patternInput_1[1];
    const subscriptionId = reactApi.useRef(0);
    useEffectWithDeps(() => {
        const loop = () => {
            dispatch(new Msg(0, []));
            console.log(some("Incremented count"));
            const id = setTimeout(loop, 1000) | 0;
            subscriptionId.current = id;
        };
        loop();
        return {
            Dispose() {
                clearTimeout(subscriptionId.current);
            },
        };
    }, []);
    const children = ofArray([reactElement("h1", {
        children: [patternInput_1[0].Count + localCount],
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
    }), reactElement("button", {
        children: "Increment local state",
        onClick: (_arg_4) => {
            patternInput[1](localCount + 1);
        },
    })]);
    return reactElement("div", {
        children: reactApi.Children.toArray(Array.from(children)),
    });
}

export default Main;

