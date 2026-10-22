namespace Feliz

/// Contains a list of HTML5 colors from https://htmlcolorcodes.com/color-names/
module color =
    /// Creates a color from components [hue](https://en.wikipedia.org/wiki/Hue), [saturation](https://en.wikipedia.org/wiki/Colorfulness) and [lightness](https://en.wikipedia.org/wiki/Lightness) where hue is a number that goes from 0 to 360 and both
    /// the `saturation` and `lightness` go from 0 to 100 as they are percentages.
    let hsl (hue: float, saturation: float, lightness: float) =
        "hsl("
        + (unbox<string> hue)
        + ","
        + (unbox<string> saturation)
        + "%,"
        + (unbox<string> lightness)
        + "%)"

    let rgb (r: int, g: int, b: int) =
        "rgb("
        + (unbox<string> r)
        + ","
        + (unbox<string> g)
        + ","
        + (unbox<string> b)
        + ")"

    let rgba (r: int, g: int, b: int, a) =
        "rgba("
        + (unbox<string> r)
        + ","
        + (unbox<string> g)
        + ","
        + (unbox<string> b)
        + ","
        + (unbox<string> a)
        + ")"

    [<Literal>]
    let indianRed = "#CD5C5C"

    [<Literal>]
    let lightCoral = "#F08080"

    [<Literal>]
    let salmon = "#FA8072"

    [<Literal>]
    let darkSalmon = "#E9967A"

    [<Literal>]
    let lightSalmon = "#FFA07A"

    [<Literal>]
    let crimson = "#DC143C"

    [<Literal>]
    let red = "#FF0000"

    [<Literal>]
    let fireBrick = "#B22222"

    [<Literal>]
    let darkRed = "#8B0000"

    [<Literal>]
    let pink = "#FFC0CB"

    [<Literal>]
    let lightPink = "#FFB6C1"

    [<Literal>]
    let hotPink = "#FF69B4"

    [<Literal>]
    let deepPink = "#FF1493"

    [<Literal>]
    let mediumVioletRed = "#C71585"

    [<Literal>]
    let paleVioletRed = "#DB7093"

    [<Literal>]
    let coral = "#FF7F50"

    [<Literal>]
    let tomato = "#FF6347"

    [<Literal>]
    let orangeRed = "#FF4500"

    [<Literal>]
    let darkOrange = "#FF8C00"

    [<Literal>]
    let orange = "#FFA500"

    [<Literal>]
    let gold = "#FFD700"

    [<Literal>]
    let yellow = "#FFFF00"

    [<Literal>]
    let lightYellow = "#FFFFE0"

    [<Literal>]
    let limonChiffon = "#FFFACD"

    [<Literal>]
    let lightGoldenRodYellow = "#FAFAD2"

    [<Literal>]
    let papayaWhip = "#FFEFD5"

    [<Literal>]
    let moccasin = "#FFE4B5"

    [<Literal>]
    let peachPuff = "#FFDAB9"

    [<Literal>]
    let paleGoldenRod = "#EEE8AA"

    [<Literal>]
    let khaki = "#F0E68C"

    [<Literal>]
    let darkKhaki = "#BDB76B"

    [<Literal>]
    let lavender = "#E6E6FA"

    [<Literal>]
    let thistle = "#D8BFD8"

    [<Literal>]
    let plum = "#DDA0DD"

    [<Literal>]
    let violet = "#EE82EE"

    [<Literal>]
    let orchid = "#DA70D6"

    [<Literal>]
    let fuchsia = "#FF00FF"

    [<Literal>]
    let magenta = "#FF00FF"

    [<Literal>]
    let mediumOrchid = "#BA55D3"

    [<Literal>]
    let mediumPurple = "#9370DB"

    [<Literal>]
    let rebeccaPurple = "#663399"

    [<Literal>]
    let blueViolet = "#8A2BE2"

    [<Literal>]
    let darkViolet = "#9400D3"

    [<Literal>]
    let darkOrchid = "#9932CC"

    [<Literal>]
    let darkMagenta = "#8B008B"

    [<Literal>]
    let purple = "#800080"

    [<Literal>]
    let indigo = "#4B0082"

    [<Literal>]
    let slateBlue = "#6A5ACD"

    [<Literal>]
    let darkSlateBlue = "#483D8B"

    [<Literal>]
    let mediumSlateBlue = "#7B68EE"

    [<Literal>]
    let greenYellow = "#ADFF2F"

    [<Literal>]
    let chartreuse = "#7FFF00"

    [<Literal>]
    let lawnGreen = "#7CFC00"

    [<Literal>]
    let lime = "#00FF00"

    [<Literal>]
    let limeGreen = "#32CD32"

    [<Literal>]
    let paleGreen = "#98FB98"

    [<Literal>]
    let lightGreen = "#90EE90"

    [<Literal>]
    let mediumSpringGreen = "#00FA9A"

    [<Literal>]
    let springGreen = "#00FF7F"

    [<Literal>]
    let mediumSeaGreen = "#3CB371"

    [<Literal>]
    let seaGreen = "#2E8B57"

    [<Literal>]
    let forestGreen = "#228B22"

    [<Literal>]
    let green = "#008000"

    [<Literal>]
    let darkGreen = "#006400"

    [<Literal>]
    let yellowGreen = "#9ACD32"

    [<Literal>]
    let oliveDrab = "#6B8E23"

    [<Literal>]
    let olive = "#808000"

    [<Literal>]
    let darkOliveGreen = "#556B2F"

    [<Literal>]
    let mediumAquamarine = "#66CDAA"

    [<Literal>]
    let darkSeaGreen = "#8FBC8B"

    [<Literal>]
    let lightSeaGreen = "#20B2AA"

    [<Literal>]
    let darkCyan = "#008B8B"

    [<Literal>]
    let teal = "#008080"

    [<Literal>]
    let aqua = "#00FFFF"

    [<Literal>]
    let cyan = "#00FFFF"

    [<Literal>]
    let lightCyan = "#E0FFFF"

    [<Literal>]
    let paleTurqouise = "#AFEEEE"

    [<Literal>]
    let aquaMarine = "#7FFFD4"

    [<Literal>]
    let turqouise = "#AFEEEE"

    [<Literal>]
    let mediumTurqouise = "#48D1CC"

    [<Literal>]
    let darkTurqouise = "#00CED1"

    [<Literal>]
    let cadetBlue = "#5F9EA0"

    [<Literal>]
    let steelBlue = "#4682B4"

    [<Literal>]
    let lightSteelBlue = "#B0C4DE"

    [<Literal>]
    let powederBlue = "#B0E0E6"

    [<Literal>]
    let lightBlue = "#ADD8E6"

    [<Literal>]
    let skyBlue = "#87CEEB"

    [<Literal>]
    let lightSkyBlue = "#87CEFA"

    [<Literal>]
    let deepSkyBlue = "#00BFFF"

    [<Literal>]
    let dodgerBlue = "#1E90FF"

    [<Literal>]
    let cornFlowerBlue = "#6495ED"

    [<Literal>]
    let royalBlue = "#4169E1"

    [<Literal>]
    let blue = "#0000FF"

    [<Literal>]
    let mediumBlue = "#0000CD"

    [<Literal>]
    let darkBlue = "#00008B"

    [<Literal>]
    let navy = "#000080"

    [<Literal>]
    let midnightBlue = "#191970"

    [<Literal>]
    let cornSilk = "#FFF8DC"

    [<Literal>]
    let blanchedAlmond = "#FFEBCD"

    [<Literal>]
    let bisque = "#FFE4C4"

    [<Literal>]
    let navajoWhite = "#FFDEAD"

    [<Literal>]
    let wheat = "#F5DEB3"

    [<Literal>]
    let burlyWood = "#DEB887"

    [<Literal>]
    let tan = "#D2B48C"

    [<Literal>]
    let rosyBrown = "#BC8F8F"

    [<Literal>]
    let sandyBrown = "#F4A460"

    [<Literal>]
    let goldenRod = "#DAA520"

    [<Literal>]
    let darkGoldenRod = "#B8860B"

    [<Literal>]
    let peru = "#CD853F"

    [<Literal>]
    let chocolate = "#D2691E"

    [<Literal>]
    let saddleBrown = "#8B4513"

    [<Literal>]
    let sienna = "#A0522D"

    [<Literal>]
    let brown = "#A52A2A"

    [<Literal>]
    let maroon = "#A52A2A"

    [<Literal>]
    let white = "#FFFFFF"

    [<Literal>]
    let snow = "#FFFAFA"

    [<Literal>]
    let honeyDew = "#F0FFF0"

    [<Literal>]
    let mintCream = "#F5FFFA"

    [<Literal>]
    let azure = "#F0FFFF"

    [<Literal>]
    let aliceBlue = "#F0F8FF"

    [<Literal>]
    let ghostWhite = "#F8F8FF"

    [<Literal>]
    let whiteSmoke = "#F5F5F5"

    [<Literal>]
    let seaShell = "#FFF5EE"

    [<Literal>]
    let beige = "#F5F5DC"

    [<Literal>]
    let oldLace = "#FDF5E6"

    [<Literal>]
    let floralWhite = "#FFFAF0"

    [<Literal>]
    let ivory = "#FFFFF0"

    [<Literal>]
    let antiqueWhite = "#FAEBD7"

    [<Literal>]
    let linen = "#FAF0E6"

    [<Literal>]
    let lavenderBlush = "#FFF0F5"

    [<Literal>]
    let mistyRose = "#FFE4E1"

    [<Literal>]
    let gainsBoro = "#DCDCDC"

    [<Literal>]
    let lightGray = "#D3D3D3"

    [<Literal>]
    let silver = "#C0C0C0"

    [<Literal>]
    let darkGray = "#A9A9A9"

    [<Literal>]
    let gray = "#808080"

    [<Literal>]
    let dimGray = "#696969"

    [<Literal>]
    let lightSlateGray = "#778899"

    [<Literal>]
    let slateGray = "#708090"

    [<Literal>]
    let darkSlateGray = "#2F4F4F"

    [<Literal>]
    let black = "#000000"

    [<Literal>]
    let transparent = "transparent"
