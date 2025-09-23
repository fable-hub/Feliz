import { TypeInfo } from "./Reflection.js";
import { FSharpList } from "./List.js";
export declare class ListCollector$1<T> {
    readonly collector: T[];
    constructor();
}
export declare function ListCollector$1_$reflection(gen0: TypeInfo): TypeInfo;
export declare function ListCollector$1_$ctor<T>(): ListCollector$1<T>;
export declare function ListCollector$1__Add_2B595<T>(this$: ListCollector$1<T>, value: T): void;
export declare function ListCollector$1__AddMany_BB573A<T>(this$: ListCollector$1<T>, values: Iterable<T>): void;
export declare function ListCollector$1__AddManyAndClose_BB573A<T>(this$: ListCollector$1<T>, values: Iterable<T>): FSharpList<T>;
export declare function ListCollector$1__Close<T>(this$: ListCollector$1<T>): FSharpList<T>;
