import { class_type } from "./Reflection.js";
import { addRangeInPlace } from "./Array.js";
import { toList } from "./Seq.js";
export class ListCollector$1 {
    constructor() {
        this.collector = [];
    }
}
export function ListCollector$1_$reflection(gen0) {
    return class_type("Microsoft.FSharp.Core.CompilerServices.ListCollector`1", [gen0], ListCollector$1);
}
export function ListCollector$1_$ctor() {
    return new ListCollector$1();
}
export function ListCollector$1__Add_2B595(this$, value) {
    void (this$.collector.push(value));
}
export function ListCollector$1__AddMany_BB573A(this$, values) {
    addRangeInPlace(values, this$.collector);
}
export function ListCollector$1__AddManyAndClose_BB573A(this$, values) {
    addRangeInPlace(values, this$.collector);
    return toList(this$.collector);
}
export function ListCollector$1__Close(this$) {
    return toList(this$.collector);
}
