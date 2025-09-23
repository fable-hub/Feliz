
import { singleton, concat, map, empty, iterate } from "../fable-library-js.5.0.0-alpha.14/List.js";
import { singleton as singleton_1 } from "../fable-library-js.5.0.0-alpha.14/AsyncBuilder.js";
import { startImmediate, catchAsync } from "../fable-library-js.5.0.0-alpha.14/Async.js";
import { Timer_delay } from "./prelude.fs.js";

/**
 * Execute the commands using the supplied dispatcher
 */
export function Cmd_exec(onError, dispatch, cmd) {
    iterate((call) => {
        try {
            call(dispatch);
        }
        catch (ex) {
            onError(ex);
        }
    }, cmd);
}

/**
 * None - no commands, also known as `[]`
 */
export function Cmd_none() {
    return empty();
}

/**
 * When emitting the message, map to another type
 */
export function Cmd_map(f, cmd) {
    return map((g) => ((arg_1) => {
        g((arg) => {
            arg_1(f(arg));
        });
    }), cmd);
}

/**
 * Aggregate multiple commands
 */
export function Cmd_batch(cmds) {
    return concat(cmds);
}

/**
 * Command to call the effect
 */
export function Cmd_ofEffect(effect) {
    return singleton(effect);
}

/**
 * Command to evaluate a simple function and map the result
 * into success or error (of exception)
 */
export function Cmd_OfFunc_either(task, arg, ofSuccess, ofError) {
    return singleton((dispatch) => {
        try {
            dispatch(ofSuccess(task(arg)));
        }
        catch (x) {
            dispatch(ofError(x));
        }
    });
}

/**
 * Command to evaluate a simple function and map the success to a message
 * discarding any possible error
 */
export function Cmd_OfFunc_perform(task, arg, ofSuccess) {
    return singleton((dispatch) => {
        try {
            dispatch(ofSuccess(task(arg)));
        }
        catch (x) {
        }
    });
}

/**
 * Command to evaluate a simple function and map the error (in case of exception)
 */
export function Cmd_OfFunc_attempt(task, arg, ofError) {
    return singleton((dispatch) => {
        try {
            task(arg);
        }
        catch (x) {
            dispatch(ofError(x));
        }
    });
}

/**
 * Command that will evaluate an async block and map the result
 * into success or error (of exception)
 */
export function Cmd_OfAsyncWith_either(start, task, arg, ofSuccess, ofError) {
    return singleton((arg_1) => {
        start(singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg) => {
            const r = _arg;
            arg_1((r.tag === 1) ? ofError(r.fields[0]) : ofSuccess(r.fields[0]));
            return singleton_1.Zero();
        })));
    });
}

/**
 * Command that will evaluate an async block and map the success
 */
export function Cmd_OfAsyncWith_perform(start, task, arg, ofSuccess) {
    return singleton((arg_1) => {
        start(singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg) => {
            const r = _arg;
            if (r.tag === 0) {
                arg_1(ofSuccess(r.fields[0]));
                return singleton_1.Zero();
            }
            else {
                return singleton_1.Zero();
            }
        })));
    });
}

/**
 * Command that will evaluate an async block and map the error (of exception)
 */
export function Cmd_OfAsyncWith_attempt(start, task, arg, ofError) {
    return singleton((arg_1) => {
        start(singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg) => {
            const r = _arg;
            if (r.tag === 1) {
                arg_1(ofError(r.fields[0]));
                return singleton_1.Zero();
            }
            else {
                return singleton_1.Zero();
            }
        })));
    });
}

export function Cmd_OfAsync_start(x) {
    Timer_delay(1, (_arg) => {
        startImmediate(x);
    });
}

/**
 * Command to call `promise` block and map the results
 */
export function Cmd_OfPromise_either(task, arg, ofSuccess, ofError) {
    return singleton((dispatch) => {
        task(arg).then((arg_3) => {
            dispatch(ofSuccess(arg_3));
        }).catch((arg_2) => {
            dispatch(ofError(arg_2));
        });
    });
}

/**
 * Command to call `promise` block and map the success
 */
export function Cmd_OfPromise_perform(task, arg, ofSuccess) {
    return singleton((dispatch) => {
        task(arg).then((arg_1) => dispatch(ofSuccess(arg_1)));
    });
}

/**
 * Command to call `promise` block and map the error
 */
export function Cmd_OfPromise_attempt(task, arg, ofError) {
    return singleton((dispatch) => {
        task(arg).catch((arg_2) => {
            dispatch(ofError(arg_2));
        });
    });
}

