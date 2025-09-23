export declare class ConditionalWeakTable<TKey extends object, TValue> {
    private weakMap;
    delete(key: TKey): boolean;
    get(key: TKey): TValue | undefined;
    has(key: TKey): boolean;
    set(key: TKey, value: TValue): WeakMap<TKey, TValue>;
    clear(): void;
}
export default ConditionalWeakTable;
