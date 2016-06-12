#I "../packages/FParsec.1.0.2/lib/net40-client"

#r "FParsec.dll"
#r "FParsecCS.dll"

open FParsec

run anyChar "abcdef"
|> sprintf "%+A"

let parsesA data = pchar 'a' data

//parse 1.2, 2.3, 2.2, 1.7, 1.9 into float list

let plistoffloats = (sepBy pfloat (pchar ',' .>> spaces))

let parse = run plistoffloats "1.2, 2.3, 2.2, 1.7, 1.9"


match parse with
| Success(result,_,_) -> result
| Failure(errorMsg,_,_)-> []

type Point = {x: float; y: float}

//Parse 1.1, 3.7 in Point record
let plistoffloats' =
    pipe3 pfloat (pchar ',' .>> spaces) pfloat (fun x z y -> {x = x; y = y})

let p1 = run plistoffloats' "1.2, 2.3"

let ppoint' =
    between
        (pchar '(')
        (pchar ')')
        plistoffloats'

run ppoint' "(1.2, 2.5)"