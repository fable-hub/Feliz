import { replace, format, replicate, substring, isNullOrEmpty, join } from "./String.js";
import { class_type } from "./Reflection.js";
import { toString } from "./Types.js";
import { clear, int32ToString } from "./Util.js";
export class StringBuilder {
    constructor(value, capacity) {
        this.buf = [];
        if (!isNullOrEmpty(value)) {
            void (this.buf.push(value));
        }
    }
    toString() {
        const _ = this;
        return join("", _.buf);
    }
}
export function StringBuilder_$reflection() {
    return class_type("System.Text.StringBuilder", undefined, StringBuilder);
}
export function StringBuilder_$ctor_Z18115A39(value, capacity) {
    return new StringBuilder(value, capacity);
}
export function StringBuilder_$ctor_Z524259A4(capacity) {
    return StringBuilder_$ctor_Z18115A39("", capacity);
}
export function StringBuilder_$ctor_Z721C83C5(value) {
    return StringBuilder_$ctor_Z18115A39(value, 16);
}
export function StringBuilder_$ctor() {
    return StringBuilder_$ctor_Z18115A39("", 16);
}
export function StringBuilder__Append_Z721C83C5(x, s) {
    void (x.buf.push(toString(s)));
    return x;
}
export function StringBuilder__Append_487EF8FB(x, s, startIndex, count) {
    void (x.buf.push(substring(toString(s), startIndex, count)));
    return x;
}
export function StringBuilder__Append_244C7CD6(x, c) {
    void (x.buf.push(c));
    return x;
}
export function StringBuilder__Append_61B1CA(x, c, repeatCount) {
    const s = replicate(repeatCount, c);
    void (x.buf.push(s));
    return x;
}
export function StringBuilder__Append_Z524259A4(x, o) {
    void (x.buf.push(int32ToString(o)));
    return x;
}
export function StringBuilder__Append_5E38073B(x, o) {
    void (x.buf.push(o.toString()));
    return x;
}
export function StringBuilder__Append_Z1FBCCD16(x, o) {
    void (x.buf.push(toString(o)));
    return x;
}
export function StringBuilder__Append_4E60E31B(x, o) {
    void (x.buf.push(toString(o)));
    return x;
}
export function StringBuilder__Append_Z372E4D23(x, cs) {
    void (x.buf.push(cs.join('')));
    return x;
}
export function StringBuilder__Append_43A65C09(x, s) {
    void (x.buf.push(s.toString()));
    return x;
}
export function StringBuilder__AppendFormat_433E080(x, fmt, o) {
    void (x.buf.push(format(fmt, o)));
    return x;
}
export function StringBuilder__AppendFormat_Z3B30EC65(x, fmt, o1, o2) {
    void (x.buf.push(format(fmt, o1, o2)));
    return x;
}
export function StringBuilder__AppendFormat_10D165E0(x, fmt, o1, o2, o3) {
    void (x.buf.push(format(fmt, o1, o2, o3)));
    return x;
}
export function StringBuilder__AppendFormat_Z17053F5(x, fmt, arr) {
    void (x.buf.push(format(fmt, ...arr)));
    return x;
}
export function StringBuilder__AppendFormat_Z696D8D1B(x, provider, fmt, o) {
    void (x.buf.push(format(provider, fmt, o)));
    return x;
}
export function StringBuilder__AppendFormat_26802C9E(x, provider, fmt, o1, o2) {
    void (x.buf.push(format(provider, fmt, o1, o2)));
    return x;
}
export function StringBuilder__AppendFormat_Z471ADCBB(x, provider, fmt, o1, o2, o3) {
    void (x.buf.push(format(provider, fmt, o1, o2, o3)));
    return x;
}
export function StringBuilder__AppendFormat_6C2E3E6E(x, provider, fmt, arr) {
    void (x.buf.push(format(provider, fmt, ...arr)));
    return x;
}
export function StringBuilder__AppendLine(x) {
    void (x.buf.push("\n"));
    return x;
}
export function StringBuilder__AppendLine_Z721C83C5(x, s) {
    void (x.buf.push(s));
    void (x.buf.push("\n"));
    return x;
}
export function StringBuilder__Clear(x) {
    clear(x.buf);
    return x;
}
export function StringBuilder__get_Chars_Z524259A4(x, index) {
    let len = 0;
    let i = -1;
    while (((i + 1) < x.buf.length) && (len < index)) {
        i = ((i + 1) | 0);
        len = ((len + x.buf[i].length) | 0);
    }
    if (((index < 0) ? true : (i < 0)) ? true : (i >= x.buf.length)) {
        throw new Error("Index was outside the bounds of the array");
    }
    else {
        const pos = ((len - index) - 1) | 0;
        return x.buf[i][pos];
    }
}
export function StringBuilder__set_Chars_413E0D0A(x, index, value) {
    let len = 0;
    let i = -1;
    while (((i + 1) < x.buf.length) && (len < index)) {
        i = ((i + 1) | 0);
        len = ((len + x.buf[i].length) | 0);
    }
    if (((index < 0) ? true : (i < 0)) ? true : (i >= x.buf.length)) {
        throw new Error("Index was outside the bounds of the array");
    }
    else {
        const pos = ((len - index) - 1) | 0;
        x.buf[i] = ((x.buf[i].slice(0, (pos - 1) + 1) + value) + x.buf[i].slice(pos + 1, x.buf[i].length));
    }
}
export function StringBuilder__Replace_Z766F94C0(x, oldValue, newValue) {
    for (let i = x.buf.length - 1; i >= 0; i--) {
        x.buf[i] = replace(x.buf[i], oldValue, newValue);
    }
    return x;
}
export function StringBuilder__Replace_Z384F8060(x, oldValue, newValue) {
    const str = replace(x.toString(), oldValue, newValue);
    return StringBuilder__Append_Z721C83C5(StringBuilder__Clear(x), str);
}
export function StringBuilder__get_Length(x) {
    let len = 0;
    for (let i = x.buf.length - 1; i >= 0; i--) {
        len = ((len + x.buf[i].length) | 0);
    }
    return len | 0;
}
export function StringBuilder__ToString_Z37302880(x, firstIndex, length) {
    return substring(x.toString(), firstIndex, length);
}
