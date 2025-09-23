import { Union } from "./Types.js";
import { union_type } from "./Reflection.js";
import { equals } from "./Util.js";
import { empty, singleton } from "./List.js";
import { some } from "./Option.js";
export function FSharpResult$2_Ok(ResultValue) {
    return new FSharpResult$2(0, [ResultValue]);
}
export function FSharpResult$2_Error$(ErrorValue) {
    return new FSharpResult$2(1, [ErrorValue]);
}
export class FSharpResult$2 extends Union {
    constructor(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["Ok", "Error"];
    }
}
export function FSharpResult$2_$reflection(gen0, gen1) {
    return union_type("FSharp.Core.FSharpResult`2", [gen0, gen1], FSharpResult$2, () => [[["ResultValue", gen0]], [["ErrorValue", gen1]]]);
}
export function Result_Map(mapping, result) {
    if (result.tag === /* Ok */ 0) {
        return FSharpResult$2_Ok(mapping(result.fields[0]));
    }
    else {
        return FSharpResult$2_Error$(result.fields[0]);
    }
}
export function Result_MapError(mapping, result) {
    if (result.tag === /* Ok */ 0) {
        return FSharpResult$2_Ok(result.fields[0]);
    }
    else {
        return FSharpResult$2_Error$(mapping(result.fields[0]));
    }
}
export function Result_Bind(binder, result) {
    if (result.tag === /* Ok */ 0) {
        return binder(result.fields[0]);
    }
    else {
        return FSharpResult$2_Error$(result.fields[0]);
    }
}
export function Result_IsOk(result) {
    if (result.tag === /* Ok */ 0) {
        return true;
    }
    else {
        return false;
    }
}
export function Result_IsError(result) {
    if (result.tag === /* Ok */ 0) {
        return false;
    }
    else {
        return true;
    }
}
export function Result_Contains(value, result) {
    if (result.tag === /* Ok */ 0) {
        return equals(result.fields[0], value);
    }
    else {
        return false;
    }
}
export function Result_Count(result) {
    if (result.tag === /* Ok */ 0) {
        return 1;
    }
    else {
        return 0;
    }
}
export function Result_DefaultValue(defaultValue, result) {
    if (result.tag === /* Ok */ 0) {
        return result.fields[0];
    }
    else {
        return defaultValue;
    }
}
export function Result_DefaultWith(defThunk, result) {
    if (result.tag === /* Ok */ 0) {
        return result.fields[0];
    }
    else {
        return defThunk(result.fields[0]);
    }
}
export function Result_Exists(predicate, result) {
    if (result.tag === /* Ok */ 0) {
        return predicate(result.fields[0]);
    }
    else {
        return false;
    }
}
export function Result_Fold(folder, state, result) {
    if (result.tag === /* Ok */ 0) {
        return folder(state, result.fields[0]);
    }
    else {
        return state;
    }
}
export function Result_FoldBack(folder, result, state) {
    if (result.tag === /* Ok */ 0) {
        return folder(result.fields[0], state);
    }
    else {
        return state;
    }
}
export function Result_ForAll(predicate, result) {
    if (result.tag === /* Ok */ 0) {
        return predicate(result.fields[0]);
    }
    else {
        return true;
    }
}
export function Result_Iterate(action, result) {
    if (result.tag === /* Ok */ 0) {
        action(result.fields[0]);
    }
}
export function Result_ToArray(result) {
    if (result.tag === /* Ok */ 0) {
        return [result.fields[0]];
    }
    else {
        return [];
    }
}
export function Result_ToList(result) {
    if (result.tag === /* Ok */ 0) {
        return singleton(result.fields[0]);
    }
    else {
        return empty();
    }
}
export function Result_ToOption(result) {
    if (result.tag === /* Ok */ 0) {
        return some(result.fields[0]);
    }
    else {
        return undefined;
    }
}
export function Result_ToValueOption(result) {
    if (result.tag === /* Ok */ 0) {
        return some(result.fields[0]);
    }
    else {
        return undefined;
    }
}
