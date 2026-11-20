namespace Feliz

open System
open System.ComponentModel
open Fable.Core.JsInterop

/// Implementation detail of `React.ErrorBoundary`.
///
/// React only supports error boundaries as class components (there is no hook for `getDerivedStateFromError`),
/// so the boundary is a small JavaScript class. It lives in its own module so it is only imported when used.
[<EditorBrowsable(EditorBrowsableState.Never)>]
module ErrorBoundaryInternal =

    // Props: fallback (element or render function), onError(error, info), onReset(), resetKeys (array).
    // `resetKeys` are compared item by item with Object.is, like hook dependencies.
    let errorBoundaryComponent: obj =
        emitJsExpr
            (import<obj> "Component" "react")
            """class FelizErrorBoundary extends $0 {
    constructor(props) {
        super(props);
        this.state = { hasError: false, error: null };
        this.reset = this.reset.bind(this);
    }

    static getDerivedStateFromError(error) {
        return { hasError: true, error: error };
    }

    componentDidCatch(error, info) {
        if (typeof this.props.onError === "function") {
            this.props.onError(error, info);
        }
    }

    componentDidUpdate(prevProps, prevState) {
        // Only reset when the error was already shown in the previous commit, otherwise a
        // resetKeys change that caused the error would immediately reset the boundary again.
        if (this.state.hasError && prevState.hasError && FelizErrorBoundary.keysChanged(prevProps.resetKeys, this.props.resetKeys)) {
            this.reset();
        }
    }

    static keysChanged(previous, next) {
        if (previous === next) {
            return false;
        }
        if (previous == null || next == null || previous.length !== next.length) {
            return true;
        }
        for (let i = 0; i < next.length; i++) {
            if (!Object.is(previous[i], next[i])) {
                return true;
            }
        }
        return false;
    }

    reset() {
        if (typeof this.props.onReset === "function") {
            this.props.onReset();
        }
        this.setState({ hasError: false, error: null });
    }

    render() {
        if (this.state.hasError) {
            const fallback = this.props.fallback;
            if (typeof fallback === "function") {
                return fallback({ error: this.state.error, reset: this.reset });
            }
            return fallback === undefined ? null : fallback;
        }
        return this.props.children === undefined ? null : this.props.children;
    }
}"""

    /// `onError` is a delegate so the JavaScript class can call it as `onError(error, info)`.
    let createProps
        (fallback: obj)
        (onError: Action<exn, ReactErrorInfo> option)
        (onReset: (unit -> unit) option)
        (resetKeys: obj[] option)
        : obj =
        let props = createEmpty<obj>
        props?fallback <- fallback
        onError |> Option.iter (fun onError -> props?onError <- onError)
        onReset |> Option.iter (fun onReset -> props?onReset <- onReset)
        resetKeys |> Option.iter (fun resetKeys -> props?resetKeys <- resetKeys)
        props
