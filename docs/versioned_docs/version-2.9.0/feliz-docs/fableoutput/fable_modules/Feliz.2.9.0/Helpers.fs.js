
import { iterate } from "../fable-library-js.5.0.0-alpha.14/Seq.js";
import { disposeSafe } from "../fable-library-js.5.0.0-alpha.14/Util.js";
import { toArray } from "../fable-library-js.5.0.0-alpha.14/Option.js";

export function optDispose(disposeOption) {
    return {
        Dispose() {
            iterate((d) => {
                let copyOfStruct = d;
                disposeSafe(copyOfStruct);
            }, toArray(disposeOption));
        },
    };
}

