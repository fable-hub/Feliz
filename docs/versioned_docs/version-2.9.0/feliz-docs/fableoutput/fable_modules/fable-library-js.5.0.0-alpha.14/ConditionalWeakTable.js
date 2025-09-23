export class ConditionalWeakTable {
    constructor() {
        this.weakMap = new WeakMap();
    }
    delete(key) {
        return this.weakMap.delete(key);
    }
    get(key) {
        return this.weakMap.get(key);
    }
    has(key) {
        return this.weakMap.has(key);
    }
    set(key, value) {
        return this.weakMap.set(key, value);
    }
    clear() {
        this.weakMap = new WeakMap();
    }
}
export default ConditionalWeakTable;
