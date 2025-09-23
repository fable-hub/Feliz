
import { singleton } from "../fable-library-js.5.0.0-alpha.14/List.js";
import { singleton as singleton_1 } from "../fable-library-js.5.0.0-alpha.14/AsyncBuilder.js";

/**
 * Command to issue a specific message
 */
export function OfFunc_result(msg) {
    return singleton((dispatch) => {
        dispatch(msg);
    });
}

/**
 * Command that will evaluate an async block to the message
 */
export function OfAsyncWith_result(start, task) {
    return singleton((arg) => {
        start(singleton_1.Delay(() => singleton_1.Bind(task, (_arg) => {
            arg(_arg);
            return singleton_1.Zero();
        })));
    });
}

/**
 * Command to dispatch the `promise` result
 */
export function OfPromise_result(task) {
    return singleton((dispatch) => {
        task.then(dispatch);
    });
}

