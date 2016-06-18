// Pattern matching is available wherever identifiers are
// bound including: Let Binding, Function Args, Match Expressions and Exception Handlers
/// Simplest case, matching over let binding a.k.a destructuring assignment
let (a, b) = (1, 2)

printfn "a = %d" a
printfn "b = %d" b

/// Pattern matching function arguments
let addPair (f, s) = f + s

addPair (2, 3)

/// Pattern matching using a match expression
let addPair' p = 
    match p with
    | (f, 0) -> f
    | (0, s) -> s
    | (f, s) -> f + s

addPair' (0, 2)

/// Pattern matching with guard clauses
let fizzbuzzer i =
    match i with
    | _ when i % 3 = 0 && i % 5 = 0 -> "fizzbuzz"
    | _ when i % 3 = 0 -> "fizz"
    | _ when i % 5 = 0 -> "buzz"
    | _ -> string i

[1..100] |> List.map fizzbuzzer