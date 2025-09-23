import { compare, physicalHash, nullableEquals, structuralHash } from "./Util.js";
export function HashIdentity_FromFunctions(hash, eq) {
    return {
        Equals(x, y) {
            return eq(x, y);
        },
        GetHashCode(x_1) {
            return hash(x_1) | 0;
        },
    };
}
export function HashIdentity_Structural() {
    return HashIdentity_FromFunctions((obj) => (structuralHash(obj) | 0), nullableEquals);
}
export function HashIdentity_Reference() {
    return HashIdentity_FromFunctions((obj) => (physicalHash(obj) | 0), nullableEquals);
}
export function ComparisonIdentity_FromFunction(comparer) {
    return {
        Compare(x, y) {
            return comparer(x, y) | 0;
        },
    };
}
export function ComparisonIdentity_Structural() {
    return ComparisonIdentity_FromFunction((e, e_1) => (compare(e, e_1) | 0));
}
