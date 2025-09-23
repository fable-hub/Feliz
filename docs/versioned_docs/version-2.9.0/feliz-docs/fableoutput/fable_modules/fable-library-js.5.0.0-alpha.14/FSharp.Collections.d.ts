import { IComparer, IEqualityComparer, Nullable } from "./Util.js";
import { int32 } from "./Int32.js";
export declare function HashIdentity_FromFunctions<T>(hash: ((arg0: T) => int32), eq: ((arg0: Nullable<T>, arg1: Nullable<T>) => boolean)): IEqualityComparer<T>;
export declare function HashIdentity_Structural<T>(): IEqualityComparer<T>;
export declare function HashIdentity_Reference<T>(): IEqualityComparer<T>;
export declare function ComparisonIdentity_FromFunction<T>(comparer: ((arg0: Nullable<T>, arg1: Nullable<T>) => int32)): IComparer<T>;
export declare function ComparisonIdentity_Structural<T>(): IComparer<T>;
