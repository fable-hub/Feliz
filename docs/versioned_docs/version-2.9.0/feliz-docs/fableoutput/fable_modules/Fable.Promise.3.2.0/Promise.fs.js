
import { Result_MapError, Result_Map, FSharpResult$2 } from "../fable-library-js.5.0.0-alpha.14/Result.js";
import { class_type } from "../fable-library-js.5.0.0-alpha.14/Reflection.js";
import { disposeSafe, getEnumerator } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { Operators_IsNull } from "../fable-library-js.5.0.0-alpha.14/FSharp.Core.js";

/**
 * This is an identity function, it calls the given function and return the promise value untouched.
 * <example>
 * <code lang="fsharp">
 * fetchUser ()
 * |> Promise.tap (fun user ->
 * // Do something
 * console.log "The user has been received"
 * )
 * |> Promise.map (fun user ->
 * // user value is available here untouched
 * )
 * </code>
 * </example>
 */
export function tap(fn, a) {
    return a.then((x) => {
        fn(x);
        return x;
    });
}

/**
 * Map the <c>Promise</c> result into a <c>Result</c> type.
 * <example>
 * <code lang="fsharp">
 * Success example
 * Promise.lift 42
 * |> Promise.result
 * |> Promise.map (fun value ->
 * // value = Ok 42
 * )
 * 
 * // Fail example
 * Promise.reject "Invalid value"
 * |> Promise.result
 * |> Promise.map (fun value ->
 * // value = Error "Invalid value"
 * )
 * </code>
 * </example>
 */
export function result(a) {
    return a.then((ResultValue) => (new FSharpResult$2(0, [ResultValue]))).catch((ErrorValue) => (new FSharpResult$2(1, [ErrorValue])));
}

/**
 * Evaluates to `myPromise |> Promise.map (Result.map fn)`
 * <example>
 * <code lang="fsharp">
 * Promise.lift 42
 * |> Promise.result
 * |> Promise.mapResult (fun value ->
 * value + 10
 * )
 * |> Promise.map (fun value ->
 * // value = Ok 52
 * )
 * </code>
 * </example>
 */
export function mapResult(fn, a) {
    return a.then((result_1) => Result_Map(fn, result_1));
}

/**
 * Transform the success part of a result promise into another promise.
 * <example>
 * <code lang="fsharp">
 * let multiplyBy2 (value : int) =
 * Promise.create (fun resolve reject ->
 * resolve (value * 2)
 * )
 * 
 * Promise.lift 42
 * |> Promise.result
 * |> Promise.bindResult (fun value ->
 * multiplyBy2 value
 * )
 * |> Promise.map (fun value ->
 * // value = Ok 84
 * )
 * </code>
 * </example>
 */
export function bindResult(fn, a) {
    return a.then((a_1) => {
        if (a_1.tag === 1) {
            return Promise.resolve(new FSharpResult$2(1, [a_1.fields[0]]));
        }
        else {
            const pr = fn(a_1.fields[0]);
            return pr.then((ResultValue) => (new FSharpResult$2(0, [ResultValue])));
        }
    });
}

/**
 * Evaluates to <c>myPromise |> Promise.map (Result.map fn)</c>
 * <example>
 * <code lang="fsharp">
 * Promise.reject -1
 * |> Promise.result
 * |> Promise.mapResultError (fun value ->
 * $"%s{value} is not a valid value"
 * )
 * |> Promise.map (fun value ->
 * // value = Error "-1 is not a valid value"
 * )
 * </code>
 * </example>
 */
export function mapResultError(fn, a) {
    return a.then((result_1) => Result_MapError(fn, result_1));
}

export class PromiseBuilder {
    constructor() {
    }
}

export function PromiseBuilder_$reflection() {
    return class_type("Promise.PromiseBuilder", undefined, PromiseBuilder);
}

export function PromiseBuilder_$ctor() {
    return new PromiseBuilder();
}

export function PromiseBuilder__For_1565554B(_, seq, body) {
    let p = Promise.resolve(undefined);
    const enumerator = getEnumerator(seq);
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            let pr;
            const a = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            p = ((pr = p, pr.then(() => body(a))));
        }
    }
    finally {
        disposeSafe(enumerator);
    }
    return p;
}

export function PromiseBuilder__While_2044D34(this$, guard, p) {
    if (guard()) {
        return p.then(() => PromiseBuilder__While_2044D34(this$, guard, p));
    }
    else {
        return Promise.resolve(undefined);
    }
}

export function PromiseBuilder__TryFinally_7D49A2FD(_, p, compensation) {
    return p.then((x) => {
        compensation();
        return x;
    }).catch((er) => {
        compensation();
        throw er;
    });
}

export function PromiseBuilder__Delay_62FBFDE1(_, generator) {
    return {
        then: (onSuccess, onError) => {
            try {
                return generator().then(onSuccess, onError);
            }
            catch (er) {
                if (Operators_IsNull(onError)) {
                    return Promise.reject(er);
                }
                else {
                    try {
                        const a = onError(er);
                        return Promise.resolve(a);
                    }
                    catch (er_1) {
                        return Promise.reject(er_1);
                    }
                }
            }
        },
        catch: (onError_1) => {
            try {
                return generator().catch(onError_1);
            }
            catch (er_2) {
                try {
                    const a_1 = onError_1(er_2);
                    return Promise.resolve(a_1);
                }
                catch (er_3) {
                    return Promise.reject(er_3);
                }
            }
        },
    };
}

export function PromiseBuilder__Run_212F1D4B(_, p) {
    return p.then((x) => x);
}

export function PromiseBuilder__Using_74F7E79D(this$, resource, binder) {
    return PromiseBuilder__TryFinally_7D49A2FD(this$, binder(resource), () => {
        let copyOfStruct = resource;
        disposeSafe(copyOfStruct);
    });
}

