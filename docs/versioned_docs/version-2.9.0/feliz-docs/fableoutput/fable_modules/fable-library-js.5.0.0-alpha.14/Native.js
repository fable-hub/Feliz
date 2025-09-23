export function Helpers_allocateArrayFromCons(cons, len) {
    if (cons == null) {
        return new Array(len);
    }
    else {
        const cons_1 = cons;
        if ((typeof cons_1) === "function") {
            return new cons_1(len);
        }
        else {
            return new Array(len);
        }
    }
}
