
import { iterate } from "../fable-library-js.5.0.0-alpha.14/Seq.js";
import { some, map, defaultArg, toArray } from "../fable-library-js.5.0.0-alpha.14/Option.js";
import { reactApi } from "./Interop.fs.js";
import { defaultOf, curry2, uncurry2 } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { useLayoutEffect, useEffectWithDeps } from "./ReactInterop.js";
import { optDispose } from "./Helpers.fs.js";
import { cancel, createCancellationToken } from "../fable-library-js.5.0.0-alpha.14/Async.js";

export function propsWithKey(withKey, props) {
    if (withKey == null) {
        return props;
    }
    else {
        const f = withKey;
        props.key = f(props);
        return props;
    }
}

export function functionComponent(renderElement, name, withKey) {
    iterate((name_1) => {
        renderElement.displayName = name_1;
    }, toArray(name));
    return (props) => {
        const props_2 = propsWithKey(withKey, props);
        return reactApi.createElement(renderElement, props_2);
    };
}

export function memo(renderElement, name, areEqual, withKey) {
    const memoElementType = reactApi.memo(renderElement, uncurry2(defaultArg(map(curry2, areEqual), defaultOf())));
    iterate((name_1) => {
        renderElement.displayName = name_1;
    }, toArray(name));
    return (props) => {
        const props_2 = propsWithKey(withKey, props);
        return reactApi.createElement(memoElementType, props_2);
    };
}

export function createDisposable(dispose) {
    return {
        Dispose() {
            dispose();
        },
    };
}

export function useDisposable(dispose) {
    const dependencies_1 = [dispose];
    return reactApi.useMemo(() => createDisposable(dispose), dependencies_1);
}

export function useEffectOnce(effect) {
    const calledOnce = reactApi.useRef(false);
    reactApi.useEffect(() => {
        if (!calledOnce.current) {
            calledOnce.current = true;
            effect();
        }
    }, []);
}

export function useEffectDisposableOnce(effect) {
    const destroyFunc = reactApi.useRef(undefined);
    const calledOnce = reactApi.useRef(false);
    const renderAfterCalled = reactApi.useRef(false);
    if (calledOnce.current) {
        renderAfterCalled.current = true;
    }
    useEffectWithDeps(() => optDispose(calledOnce.current ? undefined : ((calledOnce.current = true, (destroyFunc.current = some(effect()), renderAfterCalled.current ? destroyFunc.current : undefined)))), []);
}

export function useEffectDisposableOptOnce(effect) {
    const destroyFunc = reactApi.useRef(undefined);
    const calledOnce = reactApi.useRef(false);
    const renderAfterCalled = reactApi.useRef(false);
    if (calledOnce.current) {
        renderAfterCalled.current = true;
    }
    useEffectWithDeps(() => optDispose(calledOnce.current ? undefined : ((calledOnce.current = true, (destroyFunc.current = effect(), renderAfterCalled.current ? destroyFunc.current : undefined)))), []);
}

export function createContext(name, defaultValue) {
    const contextObject = reactApi.createContext(defaultArg(defaultValue, void 0));
    iterate((name_1) => {
        contextObject.displayName = name_1;
    }, toArray(name));
    return contextObject;
}

export function useCallbackRef(callback) {
    const lastRenderCallbackRef = reactApi.useRef(callback);
    const callbackRef = reactApi.useCallback((arg) => lastRenderCallbackRef.current(arg), []);
    useLayoutEffect((_arg) => {
        lastRenderCallbackRef.current = callback;
        return createDisposable(() => {
        });
    });
    return callbackRef;
}

export function forwardRef(render) {
    const forwardRefType = reactApi.forwardRef((props, ref) => render([props, ref]));
    return (tupledArg) => {
        const propsObj = Object.assign({}, tupledArg[0]);
        propsObj.ref = tupledArg[1];
        return reactApi.createElement(forwardRefType, propsObj);
    };
}

export function forwardRefWithName(name, render) {
    const forwardRefType = reactApi.forwardRef((props, ref) => render([props, ref]));
    render.displayName = name;
    return (tupledArg) => {
        const propsObj = Object.assign({}, tupledArg[0]);
        propsObj.ref = tupledArg[1];
        return reactApi.createElement(forwardRefType, propsObj);
    };
}

export function useCancellationToken() {
    let cts;
    const initialValue = createCancellationToken();
    cts = (reactApi.useRef(initialValue));
    let token;
    const initialValue_1 = cts.current;
    token = (reactApi.useRef(initialValue_1));
    useEffectDisposableOnce(() => createDisposable(() => {
        cancel(cts.current);
    }));
    return token;
}

