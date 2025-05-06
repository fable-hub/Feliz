import {
    useEffect as useEffectReact,
    useLayoutEffect as useLayoutEffectReact,
    useDebugValue as useDebugValueReact } from 'react'

export const useEffect = getDisposable => {
    useEffectReact(() => {
        const disposable = getDisposable()
        return () => {
            disposable.Dispose();
        }
    })
}

export const useEffectWithDeps = (getDisposable, deps) => {
    useEffectReact(() => {
        const disposable = getDisposable()
        return () => {
            disposable.Dispose();
        }
    }, deps)
}

export const useLayoutEffect = getDisposable => {
    useLayoutEffectReact(() => {
        const disposable = getDisposable()
        return () => {
            disposable.Dispose();
        }
    })
}

export const useLayoutEffectWithDeps = (getDisposable, deps) => {
    useLayoutEffectReact(() => {
        const disposable = getDisposable()
        return () => {
            disposable.Dispose();
        }
    }, deps)
}

export const useDebugValue = (value, formatter) => useDebugValueReact(value, formatter)