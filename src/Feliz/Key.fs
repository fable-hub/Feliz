namespace Feliz

type IKeyboardKey = interface end

[<RequireQualifiedAccess>]
module key =
    let private create (key: string) =
        unbox<IKeyboardKey> (key, false, false)

    let enter = create "Enter"
    let escape = create "Escape"
    let one = create "1"
    let two = create "2"
    let three = create "3"
    let four = create "4"
    let five = create "5"
    let six = create "6"
    let seven = create "7"
    let eight = create "8"
    let nine = create "9"
    let zero = create "0"
    let backspace = create "Backspace"
    let plus = create "+"
    let minus = create "-"
    let space = create " "
    let tilde = create "~"
    let backtick = create "`"
    let a = create "a"
    let b = create "b"
    let c = create "c"
    let d = create "d"
    let e = create "e"
    let f = create "f"
    let g = create "g"
    let h = create "h"
    let i = create "i"
    let j = create "j"
    let k = create "k"
    let l = create "l"
    let m = create "m"
    let n = create "n"
    let o = create "o"
    let p = create "p"
    let q = create "q"
    let r = create "r"
    let s = create "s"
    let t = create "t"
    let u = create "u"
    let v = create "v"
    let w = create "w"
    let x = create "x"
    let y = create "y"
    let z = create "z"

    let ctrl(key: IKeyboardKey) =
        let (a, _, c) = unbox key
        unbox<IKeyboardKey> (a, true, c)

    let shift(key: IKeyboardKey) =
        let (a, b, _) = unbox key
        unbox<IKeyboardKey> (a, b, true)

    let ctrlAndShift(key: IKeyboardKey) =
        let (a, _, _) = unbox key
        unbox<IKeyboardKey> (a, true, true)
