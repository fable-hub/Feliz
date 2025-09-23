
import { filter, partition, foldBack, choose, append, iterate, cons, map, concat, empty } from "../fable-library-js.5.0.0-alpha.14/List.js";
import { join } from "../fable-library-js.5.0.0-alpha.14/String.js";
import { compare, disposeSafe } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { ofList, add, contains, empty as empty_1 } from "../fable-library-js.5.0.0-alpha.14/Set.js";

/**
 * None - no subscriptions, also known as `[]`
 */
export function Sub_none() {
    return empty();
}

/**
 * Aggregate multiple subscriptions
 */
export function Sub_batch(subs) {
    return concat(subs);
}

/**
 * When emitting the message, map to another type.
 * To avoid ID conflicts with other components, scope SubIds with a prefix.
 */
export function Sub_map(idPrefix, f, sub) {
    return map((tupledArg) => [cons(idPrefix, tupledArg[0]), (dispatch) => tupledArg[1]((arg) => {
        dispatch(f(arg));
    })], sub);
}

export function Sub_Internal_SubId_toString(subId) {
    return join("/", subId);
}

export function Sub_Internal_Fx_warnDupe(onError, subId) {
    const ex = new Error("Duplicate SubId");
    return onError(["Duplicate SubId: " + Sub_Internal_SubId_toString(subId), ex]);
}

export function Sub_Internal_Fx_tryStop(onError, subId, sub) {
    try {
        disposeSafe(sub);
    }
    catch (ex) {
        onError(["Error stopping subscription: " + Sub_Internal_SubId_toString(subId), ex]);
    }
}

export function Sub_Internal_Fx_tryStart(onError, dispatch, subId, start) {
    try {
        return [subId, start(dispatch)];
    }
    catch (ex) {
        onError(["Error starting subscription: " + Sub_Internal_SubId_toString(subId), ex]);
        return undefined;
    }
}

export function Sub_Internal_Fx_stop(onError, subs) {
    iterate((tupledArg) => {
        Sub_Internal_Fx_tryStop(onError, tupledArg[0], tupledArg[1]);
    }, subs);
}

export function Sub_Internal_Fx_change(onError, dispatch, dupes, toStop, toKeep, toStart) {
    iterate((subId) => {
        Sub_Internal_Fx_warnDupe(onError, subId);
    }, dupes);
    iterate((tupledArg) => {
        Sub_Internal_Fx_tryStop(onError, tupledArg[0], tupledArg[1]);
    }, toStop);
    return append(toKeep, choose((tupledArg_1) => Sub_Internal_Fx_tryStart(onError, dispatch, tupledArg_1[0], tupledArg_1[1]), toStart));
}

export function Sub_Internal_NewSubs_init() {
    return [empty(), empty_1({
        Compare: (x, y) => (compare(x, y) | 0),
    }), empty()];
}

export function Sub_Internal_NewSubs__newSubs() {
    return Sub_Internal_NewSubs_init()[2];
}

export function Sub_Internal_NewSubs__newKeys() {
    return Sub_Internal_NewSubs_init()[1];
}

export function Sub_Internal_NewSubs__dupes() {
    return Sub_Internal_NewSubs_init()[0];
}

export function Sub_Internal_NewSubs_update(subId, start, dupes, newKeys, newSubs) {
    if (contains(subId, newKeys)) {
        return [cons(subId, dupes), newKeys, newSubs];
    }
    else {
        return [dupes, add(subId, newKeys), cons([subId, start], newSubs)];
    }
}

export function Sub_Internal_NewSubs_calculate(subs) {
    return foldBack((tupledArg, tupledArg_1) => Sub_Internal_NewSubs_update(tupledArg[0], tupledArg[1], tupledArg_1[0], tupledArg_1[1], tupledArg_1[2]), subs, Sub_Internal_NewSubs_init());
}

export const Sub_Internal_empty = empty();

export function Sub_Internal_diff(activeSubs, sub) {
    const keys = ofList(map((tuple) => tuple[0], activeSubs), {
        Compare: (x, y) => (compare(x, y) | 0),
    });
    const patternInput = Sub_Internal_NewSubs_calculate(sub);
    const newKeys = patternInput[1];
    const dupes = patternInput[0];
    if (keys.Equals(newKeys)) {
        return [dupes, empty(), activeSubs, empty()];
    }
    else {
        const patternInput_1 = partition((tupledArg) => contains(tupledArg[0], newKeys), activeSubs);
        return [dupes, patternInput_1[1], patternInput_1[0], filter((tupledArg_1) => !contains(tupledArg_1[0], keys), patternInput[2])];
    }
}

