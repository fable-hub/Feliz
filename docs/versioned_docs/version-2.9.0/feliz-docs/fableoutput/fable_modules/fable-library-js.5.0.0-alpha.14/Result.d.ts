import { Union } from "./Types.js";
import { TypeInfo } from "./Reflection.js";
import { int32 } from "./Int32.js";
import { FSharpList } from "./List.js";
import { Option } from "./Option.js";
export type FSharpResult$2_$union<T, TError> = FSharpResult$2<T, TError, 0> | FSharpResult$2<T, TError, 1>;
export type FSharpResult$2_$cases<T, TError> = {
    0: ["Ok", [T]];
    1: ["Error", [TError]];
};
export declare function FSharpResult$2_Ok<T, TError>(ResultValue: T): FSharpResult$2<T, TError, 0>;
export declare function FSharpResult$2_Error$<T, TError>(ErrorValue: TError): FSharpResult$2<T, TError, 1>;
export declare class FSharpResult$2<T, TError, Tag extends keyof FSharpResult$2_$cases<T, TError>> extends Union<Tag, FSharpResult$2_$cases<T, TError>[Tag][0]> {
    readonly tag: Tag;
    readonly fields: FSharpResult$2_$cases<T, TError>[Tag][1];
    constructor(tag: Tag, fields: FSharpResult$2_$cases<T, TError>[Tag][1]);
    cases(): string[];
}
export declare function FSharpResult$2_$reflection(gen0: TypeInfo, gen1: TypeInfo): TypeInfo;
export declare function Result_Map<a, b, c>(mapping: ((arg0: a) => b), result: FSharpResult$2_$union<a, c>): FSharpResult$2_$union<b, c>;
export declare function Result_MapError<a, b, c>(mapping: ((arg0: a) => b), result: FSharpResult$2_$union<c, a>): FSharpResult$2_$union<c, b>;
export declare function Result_Bind<a, b, c>(binder: ((arg0: a) => FSharpResult$2_$union<b, c>), result: FSharpResult$2_$union<a, c>): FSharpResult$2_$union<b, c>;
export declare function Result_IsOk<a, b>(result: FSharpResult$2_$union<a, b>): boolean;
export declare function Result_IsError<a, b>(result: FSharpResult$2_$union<a, b>): boolean;
export declare function Result_Contains<a, b>(value: a, result: FSharpResult$2_$union<a, b>): boolean;
export declare function Result_Count<a, b>(result: FSharpResult$2_$union<a, b>): int32;
export declare function Result_DefaultValue<a, b>(defaultValue: a, result: FSharpResult$2_$union<a, b>): a;
export declare function Result_DefaultWith<b, a>(defThunk: ((arg0: b) => a), result: FSharpResult$2_$union<a, b>): a;
export declare function Result_Exists<a, b>(predicate: ((arg0: a) => boolean), result: FSharpResult$2_$union<a, b>): boolean;
export declare function Result_Fold<a, b, s>(folder: ((arg0: s, arg1: a) => s), state: s, result: FSharpResult$2_$union<a, b>): s;
export declare function Result_FoldBack<a, b, s>(folder: ((arg0: a, arg1: s) => s), result: FSharpResult$2_$union<a, b>, state: s): s;
export declare function Result_ForAll<a, b>(predicate: ((arg0: a) => boolean), result: FSharpResult$2_$union<a, b>): boolean;
export declare function Result_Iterate<a, b>(action: ((arg0: a) => void), result: FSharpResult$2_$union<a, b>): void;
export declare function Result_ToArray<a, b>(result: FSharpResult$2_$union<a, b>): a[];
export declare function Result_ToList<a, b>(result: FSharpResult$2_$union<a, b>): FSharpList<a>;
export declare function Result_ToOption<a, b>(result: FSharpResult$2_$union<a, b>): Option<a>;
export declare function Result_ToValueOption<a, b>(result: FSharpResult$2_$union<a, b>): Option<a>;
