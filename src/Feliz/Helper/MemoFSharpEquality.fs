// This module provides a function used by Feliz compilerplugins to perform basic fsharp equality checks. It should not be easy discoverable by end users.
module Feliz.MemoFSharpEquality

let GenericFSharpEqualFn<'T when 'T : equality> (prevProps: 'T) (nextProps: 'T) =
    prevProps = nextProps
