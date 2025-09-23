
import { Record } from "../fable-library-js.5.0.0-alpha.14/Types.js";
import { record_type, bool_type, class_type, string_type, tuple_type, list_type, lambda_type, unit_type } from "../fable-library-js.5.0.0-alpha.14/Reflection.js";
import { Sub_Internal_Fx_change, Sub_Internal_diff, Sub_Internal_Fx_stop, Sub_Internal_empty, Sub_none } from "./sub.fs.js";
import { curry3, curry2, uncurry2 } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { Log_toConsole, Log_onError } from "./prelude.fs.js";
import { Cmd_exec, Cmd_none } from "./cmd.fs.js";
import { map as map_1 } from "../fable-library-js.5.0.0-alpha.14/List.js";
import { RingBuffer$1__Pop, RingBuffer$1__Push_2B595, RingBuffer$1_$ctor_Z524259A4 } from "./ring.fs.js";
import { value as value_2 } from "../fable-library-js.5.0.0-alpha.14/Option.js";
import { printf, toText } from "../fable-library-js.5.0.0-alpha.14/String.js";

export class Program$4 extends Record {
    constructor(init, update, subscribe, view, setState, onError, termination) {
        super();
        this.init = init;
        this.update = update;
        this.subscribe = subscribe;
        this.view = view;
        this.setState = setState;
        this.onError = onError;
        this.termination = termination;
    }
}

export function Program$4_$reflection(gen0, gen1, gen2, gen3) {
    return record_type("Elmish.Program`4", [gen0, gen1, gen2, gen3], Program$4, () => [["init", lambda_type(gen0, tuple_type(gen1, list_type(lambda_type(lambda_type(gen2, unit_type), unit_type))))], ["update", lambda_type(gen2, lambda_type(gen1, tuple_type(gen1, list_type(lambda_type(lambda_type(gen2, unit_type), unit_type)))))], ["subscribe", lambda_type(gen1, list_type(tuple_type(list_type(string_type), lambda_type(lambda_type(gen2, unit_type), class_type("System.IDisposable")))))], ["view", lambda_type(gen1, lambda_type(lambda_type(gen2, unit_type), gen3))], ["setState", lambda_type(gen1, lambda_type(lambda_type(gen2, unit_type), unit_type))], ["onError", lambda_type(tuple_type(string_type, class_type("System.Exception")), unit_type)], ["termination", tuple_type(lambda_type(gen2, bool_type), lambda_type(gen1, unit_type))]]);
}

/**
 * Typical program, new commands are produced by `init` and `update` along with the new state.
 */
export function ProgramModule_mkProgram(init, update, view) {
    return new Program$4(init, update, (_arg) => Sub_none(), view, uncurry2((model) => {
        const f1 = curry2(view)(model);
        return (arg) => {
            f1(arg);
        };
    }), (tupledArg) => {
        Log_onError(tupledArg[0], tupledArg[1]);
    }, [(_arg_1) => false, (value_1) => {
    }]);
}

/**
 * Simple program that produces only new state with `init` and `update`.
 */
export function ProgramModule_mkSimple(init, update, view) {
    return new Program$4((arg) => [init(arg), Cmd_none()], uncurry2((msg) => {
        const f1_1 = curry2(update)(msg);
        return (arg_1) => [f1_1(arg_1), Cmd_none()];
    }), (_arg) => Sub_none(), view, uncurry2((model) => {
        const f1_2 = curry2(view)(model);
        return (arg_2) => {
            f1_2(arg_2);
        };
    }), (tupledArg) => {
        Log_onError(tupledArg[0], tupledArg[1]);
    }, [(_arg_1) => false, (value_1) => {
    }]);
}

/**
 * Subscribe to external source of events, overrides existing subscription.
 * Return the subscriptions that should be active based on the current model.
 * Subscriptions will be started or stopped automatically to match.
 */
export function ProgramModule_withSubscription(subscribe, program) {
    return new Program$4(program.init, program.update, subscribe, program.view, program.setState, program.onError, program.termination);
}

/**
 * Map existing subscription to external source of events.
 */
export function ProgramModule_mapSubscription(map, program) {
    return new Program$4(program.init, program.update, curry2(map)(program.subscribe), program.view, program.setState, program.onError, program.termination);
}

/**
 * Trace all the updates to the console
 */
export function ProgramModule_withConsoleTrace(program) {
    return new Program$4((arg) => {
        const patternInput = program.init(arg);
        const initModel = patternInput[0];
        Log_toConsole("Initial state:", initModel);
        return [initModel, patternInput[1]];
    }, (msg, model) => {
        Log_toConsole("New message:", msg);
        const patternInput_1 = program.update(msg, model);
        const newModel = patternInput_1[0];
        Log_toConsole("Updated state:", newModel);
        return [newModel, patternInput_1[1]];
    }, (model_1) => {
        const sub = program.subscribe(model_1);
        Log_toConsole("Updated subs:", map_1((tuple) => tuple[0], sub));
        return sub;
    }, program.view, program.setState, program.onError, program.termination);
}

/**
 * Trace all the messages as they update the model and subscriptions
 */
export function ProgramModule_withTrace(trace, program) {
    return new Program$4(program.init, (msg, model) => {
        const patternInput = program.update(msg, model);
        const state = patternInput[0];
        trace(msg, state, map_1((tuple) => tuple[0], program.subscribe(state)));
        return [state, patternInput[1]];
    }, program.subscribe, program.view, program.setState, program.onError, program.termination);
}

/**
 * Handle dispatch loop exceptions
 */
export function ProgramModule_withErrorHandler(onError, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, onError, program.termination);
}

/**
 * Exit criteria and the handler, overrides existing.
 */
export function ProgramModule_withTermination(predicate, terminate, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, program.onError, [predicate, terminate]);
}

/**
 * Map existing criteria and the handler.
 */
export function ProgramModule_mapTermination(map, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, program.onError, map(program.termination));
}

/**
 * Map existing error handler and return new `Program`
 */
export function ProgramModule_mapErrorHandler(map, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, curry2(map)(program.onError), program.termination);
}

/**
 * Get the current error handler
 */
export function ProgramModule_onError(program) {
    return program.onError;
}

/**
 * Function to render the view with the latest state
 */
export function ProgramModule_withSetState(setState, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, setState, program.onError, program.termination);
}

/**
 * Return the function to render the state
 */
export function ProgramModule_setState(program) {
    return curry2(program.setState);
}

/**
 * Return the view function
 */
export function ProgramModule_view(program) {
    return curry2(program.view);
}

/**
 * Return the init function
 */
export function ProgramModule_init(program) {
    return program.init;
}

/**
 * Return the update function
 */
export function ProgramModule_update(program) {
    return curry2(program.update);
}

/**
 * Map the program type
 */
export function ProgramModule_map(mapInit, mapUpdate, mapView, mapSetState, mapSubscribe, mapTermination, program) {
    const init = curry2(mapInit)(program.init);
    const update = curry3(mapUpdate)(curry2(program.update));
    const view = curry3(mapView)(curry2(program.view));
    const setState = curry3(mapSetState)(curry2(program.setState));
    return new Program$4(init, uncurry2(update), curry2(mapSubscribe)(program.subscribe), uncurry2(view), uncurry2(setState), program.onError, mapTermination(program.termination));
}

/**
 * Start the program loop.
 * syncDispatch: specify how to serialize dispatch calls.
 * arg: argument to pass to the init() function.
 * program: program created with 'mkSimple' or 'mkProgram'.
 */
export function ProgramModule_runWithDispatch(syncDispatch, arg, program) {
    let tupledArg_1;
    const patternInput = program.init(arg);
    const model = patternInput[0];
    const sub = program.subscribe(model);
    const patternInput_1 = program.termination;
    const rb = RingBuffer$1_$ctor_Z524259A4(10);
    let reentered = false;
    let state = model;
    let activeSubs = Sub_Internal_empty;
    let terminated = false;
    const dispatch = (msg) => {
        if (!terminated) {
            RingBuffer$1__Push_2B595(rb, msg);
            if (!reentered) {
                reentered = true;
                processMsgs();
                reentered = false;
            }
        }
    };
    const dispatch$0027 = curry2(syncDispatch)(dispatch);
    const processMsgs = () => {
        let nextMsg = RingBuffer$1__Pop(rb);
        while (!terminated && (nextMsg != null)) {
            let tupledArg;
            const msg_1 = value_2(nextMsg);
            if (patternInput_1[0](msg_1)) {
                Sub_Internal_Fx_stop(program.onError, activeSubs);
                patternInput_1[1](state);
                terminated = true;
            }
            else {
                const patternInput_2 = program.update(msg_1, state);
                const model$0027 = patternInput_2[0];
                const sub$0027 = program.subscribe(model$0027);
                program.setState(model$0027, dispatch$0027);
                Cmd_exec((ex) => {
                    program.onError([toText(printf("Error handling the message: %A"))(msg_1), ex]);
                }, dispatch$0027, patternInput_2[1]);
                state = model$0027;
                activeSubs = ((tupledArg = Sub_Internal_diff(activeSubs, sub$0027), Sub_Internal_Fx_change(program.onError, dispatch$0027, tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3])));
                nextMsg = RingBuffer$1__Pop(rb);
            }
        }
    };
    reentered = true;
    program.setState(model, dispatch$0027);
    Cmd_exec((ex_1) => {
        program.onError([toText(printf("Error intitializing:")), ex_1]);
    }, dispatch$0027, patternInput[1]);
    activeSubs = ((tupledArg_1 = Sub_Internal_diff(activeSubs, sub), Sub_Internal_Fx_change(program.onError, dispatch$0027, tupledArg_1[0], tupledArg_1[1], tupledArg_1[2], tupledArg_1[3])));
    processMsgs();
    reentered = false;
}

/**
 * Start the single-threaded dispatch loop.
 * arg: argument to pass to the 'init' function.
 * program: program created with 'mkSimple' or 'mkProgram'.
 */
export function ProgramModule_runWith(arg, program) {
    ProgramModule_runWithDispatch(uncurry2((x) => x), arg, program);
}

/**
 * Start the dispatch loop with `unit` for the init() function.
 */
export function ProgramModule_run(program) {
    ProgramModule_runWith(undefined, program);
}

