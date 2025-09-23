/**
 * DateTimeOffset functions.
 *
 * Note: Date instances are always DateObjects in local
 * timezone (because JS dates are all kinds of messed up).
 * A local date returns UTC epoch when `.getTime()` is called.
 *
 * Basically; invariant: date.getTime() always return UTC time.
 */
import { toInt64, toFloat64 } from "./BigInt.js";
import { compareDates, dateOffset, padWithZeros } from "./Util.js";
const shortDays = [
    "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"
];
const longDays = [
    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
];
const shortMonths = [
    "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
];
const longMonths = [
    "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
];
function parseRepeatToken(format, pos, patternChar) {
    let tokenLength = 0;
    let internalPos = pos;
    while (internalPos < format.length && format[internalPos] === patternChar) {
        internalPos++;
        tokenLength++;
    }
    return tokenLength;
}
function parseNextChar(format, pos) {
    if (pos >= format.length - 1) {
        return -1;
    }
    return format.charCodeAt(pos + 1);
}
function parseQuotedString(format, pos) {
    let beginPos = pos;
    // Get the character used to quote the string
    const quoteChar = format[pos];
    let result = "";
    let foundQuote = false;
    while (pos < format.length) {
        pos++;
        const currentChar = format[pos];
        if (currentChar === quoteChar) {
            foundQuote = true;
            break;
        }
        else if (currentChar === "\\") {
            if (pos < format.length) {
                pos++;
                result += format[pos];
            }
            else {
                // This means that '\' is the last character in the string.
                throw new Error("Invalid string format");
            }
        }
        else {
            result += currentChar;
        }
    }
    if (!foundQuote) {
        // We could not find the matching quote
        throw new Error(`Invalid string format could not find matching quote for ${quoteChar}`);
    }
    return [result, pos - beginPos + 1];
}
function dateToStringWithCustomFormat(date, format, utc) {
    let cursorPos = 0;
    let tokenLength = 0;
    let result = "";
    const localizedDate = utc ? DateTime(date.getTime(), 1 /* DateKind.UTC */) : date;
    while (cursorPos < format.length) {
        const token = format[cursorPos];
        switch (token) {
            case "d":
                tokenLength = parseRepeatToken(format, cursorPos, "d");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += day(localizedDate);
                        break;
                    case 2:
                        result += padWithZeros(day(localizedDate), 2);
                        break;
                    case 3:
                        result += shortDays[dayOfWeek(localizedDate)];
                        break;
                    case 4:
                    default:
                        result += longDays[dayOfWeek(localizedDate)];
                        break;
                }
                break;
            case "f":
                tokenLength = parseRepeatToken(format, cursorPos, "f");
                cursorPos += tokenLength;
                if (tokenLength <= 3) {
                    const precision = 10 ** (3 - tokenLength);
                    result += padWithZeros(Math.floor(millisecond(localizedDate) / precision), tokenLength);
                }
                else if (tokenLength <= 7) {
                    // JavaScript Date only support precision to the millisecond
                    // so we fill the rest of the precision with 0 as if the date didn't have
                    // milliseconds provided to it.
                    // This is to have the same behavior as .NET when doing:
                    // DateTime(1, 2, 3, 4, 5, 6, DateTimeKind.Utc).ToString("fffff") => 00000
                    result += ("" + millisecond(localizedDate)).padEnd(tokenLength, "0");
                }
                else {
                    throw "Input string was not in a correct format.";
                }
                break;
            case "F":
                tokenLength = parseRepeatToken(format, cursorPos, "F");
                cursorPos += tokenLength;
                if (tokenLength <= 3) {
                    const precision = 10 ** (3 - tokenLength);
                    const value = Math.floor(millisecond(localizedDate) / precision);
                    if (value != 0) {
                        result += padWithZeros(value, tokenLength);
                    }
                }
                else if (tokenLength <= 7) {
                    // JavaScript Date only support precision to the millisecond
                    // so we can't go beyond that.
                    // We also need to pad start with 0 if the value is not 0
                    const value = millisecond(localizedDate);
                    if (value != 0) {
                        result += padWithZeros(value, 3);
                    }
                }
                else {
                    throw "Input string was not in a correct format.";
                }
                break;
            case "g":
                tokenLength = parseRepeatToken(format, cursorPos, "g");
                cursorPos += tokenLength;
                result += "A.D.";
                break;
            case "h":
                tokenLength = parseRepeatToken(format, cursorPos, "h");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        const h1Value = hour(localizedDate) % 12;
                        result += h1Value ? h1Value : 12;
                        break;
                    case 2:
                    default:
                        const h2Value = hour(localizedDate) % 12;
                        result += padWithZeros(h2Value ? h2Value : 12, 2);
                        break;
                }
                break;
            case "H":
                tokenLength = parseRepeatToken(format, cursorPos, "H");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += hour(localizedDate);
                        break;
                    case 2:
                    default:
                        result += padWithZeros(hour(localizedDate), 2);
                        break;
                }
                break;
            case "K":
                tokenLength = parseRepeatToken(format, cursorPos, "K");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        switch (kind(localizedDate)) {
                            case 1 /* DateKind.UTC */:
                                result += "Z";
                                break;
                            case 2 /* DateKind.Local */:
                                result += dateOffsetToString(localizedDate.getTimezoneOffset() * -60000);
                                break;
                            case 0 /* DateKind.Unspecified */:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case "m":
                tokenLength = parseRepeatToken(format, cursorPos, "m");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += minute(localizedDate);
                        break;
                    case 2:
                    default:
                        result += padWithZeros(minute(localizedDate), 2);
                        break;
                }
                break;
            case "M":
                tokenLength = parseRepeatToken(format, cursorPos, "M");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += month(localizedDate);
                        break;
                    case 2:
                        result += padWithZeros(month(localizedDate), 2);
                        break;
                    case 3:
                        result += shortMonths[month(localizedDate) - 1];
                        break;
                    case 4:
                    default:
                        result += longMonths[month(localizedDate) - 1];
                        break;
                }
                break;
            case "s":
                tokenLength = parseRepeatToken(format, cursorPos, "s");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += second(localizedDate);
                        break;
                    case 2:
                    default:
                        result += padWithZeros(second(localizedDate), 2);
                        break;
                }
                break;
            case "t":
                tokenLength = parseRepeatToken(format, cursorPos, "t");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += localizedDate.getHours() < 12 ? "A" : "P";
                        break;
                    case 2:
                    default:
                        result += localizedDate.getHours() < 12 ? "AM" : "PM";
                        break;
                }
                break;
            case "y":
                tokenLength = parseRepeatToken(format, cursorPos, "y");
                cursorPos += tokenLength;
                switch (tokenLength) {
                    case 1:
                        result += localizedDate.getFullYear() % 100;
                        break;
                    case 2:
                        result += padWithZeros(localizedDate.getFullYear() % 100, 2);
                        break;
                    default:
                        result += padWithZeros(localizedDate.getFullYear(), tokenLength);
                        break;
                }
                break;
            case "z":
                tokenLength = parseRepeatToken(format, cursorPos, "z");
                cursorPos += tokenLength;
                let utcOffsetText = "";
                switch (kind(localizedDate)) {
                    case 1 /* DateKind.UTC */:
                        utcOffsetText = "+00:00";
                        break;
                    case 2 /* DateKind.Local */:
                        utcOffsetText = dateOffsetToString(localizedDate.getTimezoneOffset() * -60000);
                        break;
                    case 0 /* DateKind.Unspecified */:
                        utcOffsetText = dateOffsetToString(toLocalTime(localizedDate).getTimezoneOffset() * -60000);
                        break;
                }
                const sign = utcOffsetText[0] === "-" ? "-" : "+";
                const hours = parseInt(utcOffsetText.substring(1, 3), 10);
                const minutes = parseInt(utcOffsetText.substring(4, 6), 10);
                switch (tokenLength) {
                    case 1:
                        result += `${sign}${hours}`;
                        break;
                    case 2:
                        result += `${sign}${padWithZeros(hours, 2)}`;
                        break;
                    default:
                        result += `${sign}${padWithZeros(hours, 2)}:${padWithZeros(minutes, 2)}`;
                        break;
                }
                break;
            case ":":
                result += ":";
                cursorPos++;
                break;
            case "/":
                result += "/";
                cursorPos++;
                break;
            case "'":
            case '"':
                const [quotedString, quotedStringLenght] = parseQuotedString(format, cursorPos);
                result += quotedString;
                cursorPos += quotedStringLenght;
                break;
            case "%":
                const nextChar = parseNextChar(format, cursorPos);
                if (nextChar >= 0 && nextChar !== "%".charCodeAt(0)) {
                    cursorPos += 2;
                    result += dateToStringWithCustomFormat(localizedDate, String.fromCharCode(nextChar), utc);
                }
                else {
                    throw new Error("Invalid format string");
                }
                break;
            case "\\":
                const nextChar2 = parseNextChar(format, cursorPos);
                if (nextChar2 >= 0) {
                    cursorPos += 2;
                    result += String.fromCharCode(nextChar2);
                }
                else {
                    throw new Error("Invalid format string");
                }
                break;
            default:
                cursorPos++;
                result += token;
                break;
        }
    }
    return result;
}
export function kind(value) {
    return value.kind || 0;
}
export function unixEpochMillisecondsToTicks(ms, offset) {
    return toInt64(((BigInt(ms) + 62135596800000n) + BigInt(offset)) * 10000n);
}
export function ticksToUnixEpochMilliseconds(ticks) {
    return Number(((BigInt(ticks) / 10000n) - 62135596800000n));
}
export function dateOffsetToString(offset) {
    const isMinus = offset < 0;
    offset = Math.abs(offset);
    const hours = ~~(offset / 3600000);
    const minutes = (offset % 3600000) / 60000;
    return (isMinus ? "-" : "+") +
        padWithZeros(hours, 2) + ":" +
        padWithZeros(minutes, 2);
}
function dateToISOString(d, utc) {
    if (utc) {
        return d.toISOString();
    }
    else {
        // JS Date is always local
        const printOffset = d.kind == null ? true : d.kind === 2 /* DateKind.Local */;
        return padWithZeros(d.getFullYear(), 4) + "-" +
            padWithZeros(d.getMonth() + 1, 2) + "-" +
            padWithZeros(d.getDate(), 2) + "T" +
            padWithZeros(d.getHours(), 2) + ":" +
            padWithZeros(d.getMinutes(), 2) + ":" +
            padWithZeros(d.getSeconds(), 2) + "." +
            padWithZeros(d.getMilliseconds(), 3) +
            (printOffset ? dateOffsetToString(d.getTimezoneOffset() * -60000) : "");
    }
}
function dateToISOStringWithOffset(dateWithOffset, offset) {
    const str = dateWithOffset.toISOString();
    return str.substring(0, str.length - 1) + dateOffsetToString(offset);
}
function dateToStringWithOffset(date, format) {
    const d = new Date(date.getTime() + (date.offset ?? 0));
    if (typeof format !== "string") {
        return d.toISOString().replace(/\.\d+/, "").replace(/[A-Z]|\.\d+/g, " ") + dateOffsetToString((date.offset ?? 0));
    }
    else if (format.length === 1) {
        switch (format) {
            case "D": return dateToString_D(d);
            case "d": return dateToString_d(d);
            case "T": return dateToString_T(toUniversalTime(d));
            case "t": return dateToString_t(toUniversalTime(d));
            case "O":
            case "o": return dateToISOStringWithOffset(d, (date.offset ?? 0));
            default: throw new Error("Unrecognized Date print format");
        }
    }
    else {
        return dateToStringWithCustomFormat(d, format, true);
    }
}
function dateToString_D(date) {
    return longDays[dayOfWeek(date)]
        + ", " + padWithZeros(day(date), 2)
        + " " + longMonths[month(date) - 1]
        + " " + year(date);
}
function dateToString_d(date) {
    return padWithZeros(month(date), 2)
        + "/" + padWithZeros(day(date), 2)
        + "/" + year(date);
}
function dateToString_T(date) {
    return padWithZeros(hour(date), 2)
        + ":" + padWithZeros(minute(date), 2)
        + ":" + padWithZeros(second(date), 2);
}
function dateToString_t(date) {
    return padWithZeros(hour(date), 2)
        + ":" + padWithZeros(minute(date), 2);
}
function dateToStringWithKind(date, format) {
    const utc = date.kind === 1 /* DateKind.UTC */;
    if (typeof format !== "string") {
        return utc ? date.toUTCString() : date.toLocaleString();
    }
    else if (format.length === 1) {
        switch (format) {
            case "D": return dateToString_D(date);
            case "d": return dateToString_d(date);
            case "T": return dateToString_T(date);
            case "t": return dateToString_t(date);
            case "O":
            case "o":
                return dateToISOString(date, utc);
            default:
                throw new Error("Unrecognized Date print format");
        }
    }
    else {
        return dateToStringWithCustomFormat(date, format, utc);
    }
}
export function toString(date, format, _provider) {
    return date.offset != null
        ? dateToStringWithOffset(date, format)
        : dateToStringWithKind(date, format);
}
export function DateTime(value, kind) {
    const d = new Date(value);
    d.kind = (kind == null ? 0 /* DateKind.Unspecified */ : kind) | 0;
    return d;
}
export function fromTicks(ticks, kind) {
    kind = kind != null ? kind : 2 /* DateKind.Local */; // better default than Unspecified
    let date = DateTime(ticksToUnixEpochMilliseconds(ticks), kind);
    // Ticks are local to offset (in this case, either UTC or Local/Unknown).
    // If kind is anything but UTC, that means that the tick number was not
    // in utc, thus getTime() cannot return UTC, and needs to be shifted.
    if (kind !== 1 /* DateKind.UTC */) {
        date = DateTime(date.getTime() - dateOffset(date), kind);
    }
    return date;
}
export function fromDateTimeOffset(date, kind) {
    switch (kind) {
        case 1 /* DateKind.UTC */: return DateTime(date.getTime(), 1 /* DateKind.UTC */);
        case 2 /* DateKind.Local */: return DateTime(date.getTime(), 2 /* DateKind.Local */);
        default:
            const d = DateTime(date.getTime() + (date.offset ?? 0), kind);
            return DateTime(d.getTime() - dateOffset(d), kind);
    }
}
export function getTicks(date) {
    return unixEpochMillisecondsToTicks(date.getTime(), dateOffset(date));
}
export function minValue() {
    // This is "0001-01-01T00:00:00.000Z", actual JS min value is -8640000000000000
    return DateTime(-62135596800000, 1 /* DateKind.UTC */);
}
export function maxValue() {
    // This is "9999-12-31T23:59:59.999Z", actual JS max value is 8640000000000000
    return DateTime(253402300799999, 1 /* DateKind.UTC */);
}
export function parseRaw(input) {
    function fail() {
        throw new Error(`The string is not a valid Date: ${input}`);
    }
    if (input == null || input.trim() === "") {
        fail();
    }
    // ISO dates without TZ are parsed as UTC. Adding time without TZ keeps them local.
    if (input.length === 10 && input[4] === "-" && input[7] === "-") {
        input += "T00:00:00";
    }
    let date = new Date(input);
    let offset = null;
    if (isNaN(date.getTime())) {
        // Try to check strings JS Date cannot parse (see #1045, #1422)
        const m = /^\s*(\d+[^\w\s:]\d+[^\w\s:]\d+)?\s*(\d+:\d+(?::\d+(?:\.\d+)?)?)?\s*([AaPp][Mm])?\s*(Z|[+-]([01]?\d):?([0-5]?\d)?)?\s*$/.exec(input);
        if (m != null) {
            let baseDate;
            let timeInSeconds = 0;
            if (m[2] != null) {
                const timeParts = m[2].split(":");
                const hourPart = parseInt(timeParts[0], 10);
                timeInSeconds =
                    hourPart * 3600 +
                        parseInt(timeParts[1] || "0", 10) * 60 +
                        parseFloat(timeParts[2] || "0");
                if (m[3] != null && m[3].toUpperCase() === "PM" && hourPart < 12) {
                    timeInSeconds += 720;
                }
            }
            if (m[4] != null) { // There's an offset, parse as UTC
                if (m[1] != null) {
                    baseDate = new Date(m[1] + " UTC");
                }
                else {
                    const d = new Date();
                    baseDate = new Date(d.getUTCFullYear() + "/" + (d.getUTCMonth() + 1) + "/" + d.getUTCDate());
                }
                if (m[4] === "Z") {
                    offset = "Z";
                }
                else {
                    let offsetInMinutes = parseInt(m[5], 10) * 60 + parseInt(m[6] || "0", 10);
                    if (m[4][0] === "-") {
                        offsetInMinutes *= -1;
                    }
                    offset = offsetInMinutes;
                    timeInSeconds -= offsetInMinutes * 60;
                }
            }
            else {
                if (m[1] != null) {
                    baseDate = new Date(m[1]);
                }
                else {
                    const d = new Date();
                    baseDate = new Date(d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate());
                }
            }
            date = new Date(baseDate.getTime() + timeInSeconds * 1000);
            // correct for daylight savings time
            date = new Date(date.getTime() + (date.getTimezoneOffset() - baseDate.getTimezoneOffset()) * 60000);
        }
        else {
            fail();
        }
        // Check again the date is valid after transformations, see #2229
        if (isNaN(date.getTime())) {
            fail();
        }
    }
    return [date, offset];
}
export function parse(str, detectUTC = false) {
    const [date, offset] = parseRaw(str);
    // .NET always parses DateTime as Local if there's offset info (even "Z")
    // Newtonsoft.Json uses UTC if the offset is "Z"
    const kind = offset != null
        ? (detectUTC && offset === "Z" ? 1 /* DateKind.UTC */ : 2 /* DateKind.Local */)
        : 0 /* DateKind.Unspecified */;
    return DateTime(date.getTime(), kind);
}
export function tryParse(v, defValue) {
    try {
        defValue.contents = parse(v);
        return true;
    }
    catch (_err) {
        return false;
    }
}
export function create(year, month, day, h = 0, m = 0, s = 0, ms = 0, kind) {
    const date = kind === 1 /* DateKind.UTC */
        ? new Date(Date.UTC(year, month - 1, day, h, m, s, ms))
        : new Date(year, month - 1, day, h, m, s, ms);
    if (year <= 99) {
        if (kind === 1 /* DateKind.UTC */) {
            date.setUTCFullYear(year, month - 1, day);
        }
        else {
            date.setFullYear(year, month - 1, day);
        }
    }
    const dateValue = date.getTime();
    if (isNaN(dateValue)) {
        throw new Error("The parameters describe an unrepresentable Date.");
    }
    return DateTime(dateValue, kind);
}
export function now() {
    return DateTime(Date.now(), 2 /* DateKind.Local */);
}
export function utcNow() {
    return DateTime(Date.now(), 1 /* DateKind.UTC */);
}
export function today() {
    return date(now());
}
export function isLeapYear(year) {
    return year % 4 === 0 && year % 100 !== 0 || year % 400 === 0;
}
export function daysInMonth(year, month) {
    return month === 2
        ? (isLeapYear(year) ? 29 : 28)
        : (month >= 8 ? (month % 2 === 0 ? 31 : 30) : (month % 2 === 0 ? 30 : 31));
}
export function toUniversalTime(date) {
    return date.kind === 1 /* DateKind.UTC */ ? date : DateTime(date.getTime(), 1 /* DateKind.UTC */);
}
export function toLocalTime(date) {
    return date.kind === 2 /* DateKind.Local */ ? date : DateTime(date.getTime(), 2 /* DateKind.Local */);
}
export function specifyKind(d, kind) {
    return create(year(d), month(d), day(d), hour(d), minute(d), second(d), millisecond(d), kind);
}
export function timeOfDay(d) {
    return hour(d) * 3600000
        + minute(d) * 60000
        + second(d) * 1000
        + millisecond(d);
}
export function date(d) {
    return create(year(d), month(d), day(d), 0, 0, 0, 0, d.kind);
}
export function day(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCDate() : d.getDate();
}
export function hour(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCHours() : d.getHours();
}
export function millisecond(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCMilliseconds() : d.getMilliseconds();
}
export function minute(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCMinutes() : d.getMinutes();
}
export function month(d) {
    return (d.kind === 1 /* DateKind.UTC */ ? d.getUTCMonth() : d.getMonth()) + 1;
}
export function second(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCSeconds() : d.getSeconds();
}
export function year(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCFullYear() : d.getFullYear();
}
export function dayOfWeek(d) {
    return d.kind === 1 /* DateKind.UTC */ ? d.getUTCDay() : d.getDay();
}
export function dayOfYear(d) {
    const _year = year(d);
    const _month = month(d);
    let _day = day(d);
    for (let i = 1; i < _month; i++) {
        _day += daysInMonth(_year, i);
    }
    return _day;
}
export function add(d, ts) {
    const newDate = DateTime(d.getTime() + ts, d.kind);
    if (d.kind !== 1 /* DateKind.UTC */) {
        const oldTzOffset = d.getTimezoneOffset();
        const newTzOffset = newDate.getTimezoneOffset();
        return oldTzOffset !== newTzOffset
            ? DateTime(newDate.getTime() + (newTzOffset - oldTzOffset) * 60000, d.kind)
            : newDate;
    }
    else {
        return newDate;
    }
}
export function addDays(d, v) {
    return add(d, v * 86400000);
}
export function addHours(d, v) {
    return add(d, v * 3600000);
}
export function addMinutes(d, v) {
    return add(d, v * 60000);
}
export function addSeconds(d, v) {
    return add(d, v * 1000);
}
export function addMilliseconds(d, v) {
    return add(d, v);
}
export function addTicks(d, v) {
    return add(d, toFloat64(v / 10000n));
}
export function addYears(d, v) {
    const newMonth = month(d);
    const newYear = year(d) + v;
    const _daysInMonth = daysInMonth(newYear, newMonth);
    const newDay = Math.min(_daysInMonth, day(d));
    return create(newYear, newMonth, newDay, hour(d), minute(d), second(d), millisecond(d), d.kind);
}
export function addMonths(d, v) {
    let newMonth = month(d) + v;
    let newMonth_ = 0;
    let yearOffset = 0;
    if (newMonth > 12) {
        newMonth_ = newMonth % 12;
        yearOffset = Math.floor(newMonth / 12);
        newMonth = newMonth_;
    }
    else if (newMonth < 1) {
        newMonth_ = 12 + newMonth % 12;
        yearOffset = Math.floor(newMonth / 12) + (newMonth_ === 12 ? -1 : 0);
        newMonth = newMonth_;
    }
    const newYear = year(d) + yearOffset;
    const _daysInMonth = daysInMonth(newYear, newMonth);
    const newDay = Math.min(_daysInMonth, day(d));
    return create(newYear, newMonth, newDay, hour(d), minute(d), second(d), millisecond(d), d.kind);
}
export function subtract(d, that) {
    return typeof that === "number"
        ? add(d, -that)
        : d.getTime() - that.getTime();
}
export function toLongDateString(d) {
    return d.toDateString();
}
export function toShortDateString(d) {
    return d.toLocaleDateString();
}
export function toLongTimeString(d) {
    return d.toLocaleTimeString();
}
export function toShortTimeString(d) {
    return d.toLocaleTimeString().replace(/:\d\d(?!:)/, "");
}
export function equals(d1, d2) {
    return d1.getTime() === d2.getTime();
}
export const compare = compareDates;
export const compareTo = compareDates;
export function op_Addition(x, y) {
    return add(x, y);
}
export function op_Subtraction(x, y) {
    return subtract(x, y);
}
export function isDaylightSavingTime(x) {
    const jan = new Date(x.getFullYear(), 0, 1);
    const jul = new Date(x.getFullYear(), 6, 1);
    return isDST(jan.getTimezoneOffset(), jul.getTimezoneOffset(), x.getTimezoneOffset());
}
function isDST(janOffset, julOffset, tOffset) {
    return Math.min(janOffset, julOffset) === tOffset;
}
export default DateTime;
