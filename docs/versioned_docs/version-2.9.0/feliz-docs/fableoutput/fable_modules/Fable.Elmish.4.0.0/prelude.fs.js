
import { some } from "../fable-library-js.5.0.0-alpha.14/Option.js";
import Timer from "../fable-library-js.5.0.0-alpha.14/Timer.js";
import { add } from "../fable-library-js.5.0.0-alpha.14/Observable.js";

export function Log_onError(text, ex) {
    console.error(some(text), ex);
}

export function Log_toConsole(text, o) {
    console.log(some(text), o);
}

export function Timer_delay(interval, callback) {
    let t;
    let returnVal = new Timer(interval);
    returnVal.AutoReset = false;
    t = returnVal;
    add(callback, t.Elapsed());
    t.Enabled = true;
    t.Start();
}

