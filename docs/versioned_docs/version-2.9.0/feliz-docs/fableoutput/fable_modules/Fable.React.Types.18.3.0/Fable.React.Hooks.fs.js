

function HookBindings_makeDummyStateHook(value) {
    return {
        current: value,
        update(x) {
        },
        update(f) {
        },
    };
}

function HookBindings_makeDummyReducerHook(state) {
    return {
        current: state,
        update(msg) {
        },
    };
}

function HookBindings_makeDummyTransitionHook() {
    return {
        isPending: false,
        startTransition(callback) {
        },
    };
}

