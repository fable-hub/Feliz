
import { join } from "../fable-library-js.5.0.0-alpha.14/String.js";
import { length, ofArray, map } from "../fable-library-js.5.0.0-alpha.14/List.js";
import { milliseconds, seconds, minutes, hours } from "../fable-library-js.5.0.0-alpha.14/TimeSpan.js";
import { map as map_1 } from "../fable-library-js.5.0.0-alpha.14/Seq.js";

export function PropHelpers_createClockValue(duration) {
    let i_1;
    return (join(":", map((i) => ((i < 10) ? ("0" + i) : i), ofArray([hours(duration), minutes(duration), seconds(duration)]))) + ".") + ((i_1 = (milliseconds(duration) | 0), (i_1 < 10) ? ("0" + i_1) : i_1));
}

export function PropHelpers_createKeySplines(values) {
    return join("; ", map_1((tupledArg) => ((((((tupledArg[0] + " ") + tupledArg[1]) + " ") + tupledArg[2]) + " ") + tupledArg[3]), values));
}

export function PropHelpers_createOnKey(key, handler, ev) {
    const patternInput = key;
    const shift = patternInput[2];
    const pressedKey = patternInput[0];
    let matchResult;
    if (patternInput[1]) {
        if (shift) {
            if (((pressedKey.toLocaleLowerCase() === ev.key.toLocaleLowerCase()) && ev.ctrlKey) && ev.shiftKey) {
                matchResult = 0;
            }
            else {
                matchResult = 4;
            }
        }
        else if ((pressedKey.toLocaleLowerCase() === ev.key.toLocaleLowerCase()) && ev.ctrlKey) {
            matchResult = 1;
        }
        else {
            matchResult = 4;
        }
    }
    else if (shift) {
        if ((pressedKey.toLocaleLowerCase() === ev.key.toLocaleLowerCase()) && ev.shiftKey) {
            matchResult = 2;
        }
        else {
            matchResult = 4;
        }
    }
    else if (pressedKey.toLocaleLowerCase() === ev.key.toLocaleLowerCase()) {
        matchResult = 3;
    }
    else {
        matchResult = 4;
    }
    switch (matchResult) {
        case 0: {
            handler(ev);
            break;
        }
        case 1: {
            handler(ev);
            break;
        }
        case 2: {
            handler(ev);
            break;
        }
        case 3: {
            handler(ev);
            break;
        }
        case 4: {
            break;
        }
    }
}

export function PropHelpers_createPointsFloat(coordinates) {
    return join(" ", map_1((tupledArg) => ((tupledArg[0] + ",") + tupledArg[1]), coordinates));
}

export function PropHelpers_createPointsInt(coordinates) {
    return join(" ", map_1((tupledArg) => ((tupledArg[0] + ",") + tupledArg[1]), coordinates));
}

export function PropHelpers_createSvgPathFloat(path) {
    return join("\n", map_1((tupledArg) => {
        const cmdType = tupledArg[0];
        const cmds = tupledArg[1];
        if (length(cmds) === 0) {
            return cmdType;
        }
        else {
            return (cmdType + " ") + join(" ", map_1((arg) => join(",", arg), cmds));
        }
    }, path));
}

export function PropHelpers_createSvgPathInt(path) {
    return join("\n", map_1((tupledArg) => {
        const cmdType = tupledArg[0];
        const cmds = tupledArg[1];
        if (length(cmds) === 0) {
            return cmdType;
        }
        else {
            return (cmdType + " ") + join(" ", map_1((arg) => join(",", arg), cmds));
        }
    }, path));
}

