export declare function count<T>(col: Iterable<T>): number;
export declare function isReadOnly<T>(col: Iterable<T>): boolean;
export declare function copyTo<T>(col: Iterable<T>, array: T[], arrayIndex: number): void;
export declare function contains<T>(col: Iterable<T>, item: T): boolean;
export declare function add<T>(col: Iterable<T>, item: T): void;
export declare function remove<T>(col: Iterable<T>, item: T): boolean;
export declare function clear<T>(col: Iterable<T>): void;
