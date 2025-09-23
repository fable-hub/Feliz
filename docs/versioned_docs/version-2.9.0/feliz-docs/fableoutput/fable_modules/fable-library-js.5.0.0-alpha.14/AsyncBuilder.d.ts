import { IDisposable } from "./Util.js";
export interface AsyncReplyChannel<Reply> {
    reply(value: Reply): void;
}
export type Continuation<T> = (x: T) => void;
export type Continuations<T> = [
    Continuation<T>,
    Continuation<Error>,
    Continuation<OperationCanceledError>
];
export declare class CancellationToken implements IDisposable {
    private _id;
    private _cancelled;
    private _listeners;
    constructor(cancelled?: boolean);
    get isCancelled(): boolean;
    cancel(): void;
    addListener(f: () => void): number;
    removeListener(id: number): boolean;
    register(f: (state?: any) => void, state?: any): {
        Dispose(): void;
    };
    Dispose(): void;
}
export declare class OperationCanceledError extends Error {
    constructor();
}
export declare class Trampoline {
    static get maxTrampolineCallCount(): number;
    private callCount;
    constructor();
    incrementAndCheck(): boolean;
    hijack(f: () => void): void;
}
export interface IAsyncContext<T> {
    onSuccess: Continuation<T>;
    onError: Continuation<Error>;
    onCancel: Continuation<OperationCanceledError>;
    cancelToken: CancellationToken;
    trampoline: Trampoline;
}
export type Async<T> = (x: IAsyncContext<T>) => void;
export declare function protectedCont<T>(f: Async<T>): (ctx: IAsyncContext<T>) => void;
export declare function protectedBind<T, U>(computation: Async<T>, binder: (x: T) => Async<U>): (ctx: IAsyncContext<U>) => void;
export declare function protectedReturn<T>(value: T): (ctx: IAsyncContext<T>) => void;
export declare class AsyncBuilder {
    Bind<T, U>(computation: Async<T>, binder: (x: T) => Async<U>): (ctx: IAsyncContext<U>) => void;
    Combine<T>(computation1: Async<void>, computation2: Async<T>): (ctx: IAsyncContext<T>) => void;
    Delay<T>(generator: () => Async<T>): (ctx: IAsyncContext<T>) => void;
    For<T>(sequence: Iterable<T>, body: (x: T) => Async<void>): Async<void>;
    Return<T>(value: T): (ctx: IAsyncContext<T>) => void;
    ReturnFrom<T>(computation: Async<T>): Async<T>;
    TryFinally<T>(computation: Async<T>, compensation: () => void): (ctx: IAsyncContext<T>) => void;
    TryWith<T>(computation: Async<T>, catchHandler: (e: any) => Async<T>): (ctx: IAsyncContext<T>) => void;
    Using<T extends IDisposable, U>(resource: T, binder: (x: T) => Async<U>): (ctx: IAsyncContext<U>) => void;
    While(guard: () => boolean, computation: Async<void>): Async<void>;
    Zero(): (ctx: IAsyncContext<void>) => void;
}
export declare const singleton: AsyncBuilder;
