

/**
 * Creates a color from components [hue](https://en.wikipedia.org/wiki/Hue), [saturation](https://en.wikipedia.org/wiki/Colorfulness) and [lightness](https://en.wikipedia.org/wiki/Lightness) where hue is a number that goes from 0 to 360 and both
 * the `saturation` and `lightness` go from 0 to 100 as they are percentages.
 */
export function hsl(hue, saturation, lightness) {
    return ((((("hsl(" + hue) + ",") + saturation) + "%,") + lightness) + "%)";
}

export function rgb(r, g, b) {
    return ((((("rgb(" + r) + ",") + g) + ",") + b) + ")";
}

export function rgba(r, g, b, a) {
    return ((((((("rgba(" + r) + ",") + g) + ",") + b) + ",") + a) + ")";
}

