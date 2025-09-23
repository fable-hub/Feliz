

function key_create(key) {
    return [key, false, false];
}

export const key_enter = key_create("Enter");

export const key_escape = key_create("Escape");

export const key_one = key_create("1");

export const key_two = key_create("2");

export const key_three = key_create("3");

export const key_four = key_create("4");

export const key_five = key_create("5");

export const key_six = key_create("6");

export const key_seven = key_create("7");

export const key_eight = key_create("8");

export const key_nine = key_create("9");

export const key_zero = key_create("0");

export const key_backspace = key_create("Backspace");

export const key_plus = key_create("+");

export const key_minus = key_create("-");

export const key_space = key_create(" ");

export const key_tilde = key_create("~");

export const key_backtick = key_create("`");

export const key_a = key_create("a");

export const key_b = key_create("b");

export const key_c = key_create("c");

export const key_d = key_create("d");

export const key_e = key_create("e");

export const key_f = key_create("f");

export const key_g = key_create("g");

export const key_h = key_create("h");

export const key_i = key_create("i");

export const key_j = key_create("j");

export const key_k = key_create("k");

export const key_l = key_create("l");

export const key_m = key_create("m");

export const key_n = key_create("n");

export const key_o = key_create("o");

export const key_p = key_create("p");

export const key_q = key_create("q");

export const key_r = key_create("r");

export const key_s = key_create("s");

export const key_t = key_create("t");

export const key_u = key_create("u");

export const key_v = key_create("v");

export const key_w = key_create("w");

export const key_x = key_create("x");

export const key_y = key_create("y");

export const key_z = key_create("z");

export function key_ctrl(key) {
    const patternInput = key;
    return [patternInput[0], true, patternInput[2]];
}

export function key_shift(key) {
    const patternInput = key;
    return [patternInput[0], patternInput[1], true];
}

export function key_ctrlAndShift(key) {
    return [key[0], true, true];
}

