
import { ProgramModule_map, ProgramModule_withSetState, ProgramModule_runWith, ProgramModule_init } from "../Fable.Elmish.4.0.0/program.fs.js";
import { clear, getEnumerator, equals, disposeSafe, uncurry2, uncurry3, isDisposable } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { Cmd_none } from "../Fable.Elmish.4.0.0/cmd.fs.js";
import { class_type } from "../fable-library-js.5.0.0-alpha.14/Reflection.js";
import { useEffect, useState } from "react";
import { useSyncExternalStore } from "use-sync-external-store/shim";

class Util_ElmishState$3 {
    constructor(program, arg, dependencies) {
        this.arg = arg;
        this.dependencies = dependencies;
        const program_1 = program();
        const queuedMessages = [];
        this.finalDispatch = undefined;
        let patternInput_1;
        const patternInput = ProgramModule_init(program_1)(this.arg);
        let model = patternInput[0];
        let cmd = patternInput[1];
        patternInput_1 = [[model, (msg) => {
            const matchValue = this.finalDispatch;
            if (matchValue == null) {
                void (queuedMessages.push(msg));
            }
            else {
                matchValue(msg);
            }
        }, false, queuedMessages], cmd];
        this.state = patternInput_1[0];
        this.cmd = patternInput_1[1];
        this.subscribe = ((callback) => {
            let dispose = false;
            const needsDispose = isDisposable(this.state[0]);
            ProgramModule_runWith(this.arg, ProgramModule_withSetState((model_5, dispatch_1) => {
                const patternInput_5 = this.state;
                this.finalDispatch = dispatch_1;
                this.state = [model_5, patternInput_5[1], true, queuedMessages];
                if (!(model_5 === patternInput_5[0])) {
                    callback();
                }
            }, ProgramModule_map((_init, _arg) => {
                const cmd$0027 = this.cmd;
                this.cmd = Cmd_none();
                return [this.state[0], cmd$0027];
            }, (update, msg_2, model_4) => update(msg_2)(this.state[0]), uncurry3((x) => x), uncurry3((x_1) => x_1), uncurry2((x_2) => x_2), (tupledArg) => [(msg_1) => (tupledArg[0](msg_1) ? true : (needsDispose && dispose)), (model_3) => {
                const matchValue_2 = model_3;
                if (isDisposable(matchValue_2)) {
                    const disp = matchValue_2;
                    disposeSafe(disp);
                }
                else {
                    tupledArg[1](model_3);
                }
            }], program_1)));
            return () => {
                dispose = true;
            };
        });
    }
}

function Util_ElmishState$3_$reflection(gen0, gen1, gen2) {
    return class_type("Feliz.UseElmish.Util.ElmishState`3", [gen0, gen1, gen2], Util_ElmishState$3);
}

function Util_ElmishState$3_$ctor_Z29FF63CF(program, arg, dependencies) {
    return new Util_ElmishState$3(program, arg, dependencies);
}

function Util_ElmishState$3__get_State(_) {
    return _.state;
}

function Util_ElmishState$3__get_Subscribe(_) {
    return _.subscribe;
}

function Util_ElmishState$3__IsOutdated_1954DBC6(_, arg$0027, dependencies$0027) {
    if (!equals(_.arg, arg$0027)) {
        return true;
    }
    else {
        return !equals(_.dependencies, dependencies$0027);
    }
}

export function React_useElmish_Z6C327F2E(program, arg, dependencies) {
    const patternInput = useState(() => Util_ElmishState$3_$ctor_Z29FF63CF(program, arg, dependencies));
    const state = patternInput[0];
    if (Util_ElmishState$3__IsOutdated_1954DBC6(state, arg, dependencies)) {
        patternInput[1](Util_ElmishState$3_$ctor_Z29FF63CF(program, arg, dependencies));
    }
    const patternInput_1 = useSyncExternalStore(Util_ElmishState$3__get_Subscribe(state), () => Util_ElmishState$3__get_State(state));
    const subscribed = patternInput_1[2];
    const queuedMessages = patternInput_1[3];
    const dispatch = patternInput_1[1];
    useEffect(() => {
        if (subscribed && (queuedMessages.length > 0)) {
            let enumerator = getEnumerator(queuedMessages);
            try {
                while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
                    const msg = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
                    setTimeout(() => {
                        dispatch(msg);
                    });
                }
            }
            finally {
                disposeSafe(enumerator);
            }
            clear(queuedMessages);
        }
    }, [subscribed, queuedMessages]);
    return [patternInput_1[0], dispatch];
}

