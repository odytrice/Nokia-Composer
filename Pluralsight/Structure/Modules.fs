module A
let a = 1

module B =
    let b = a * 2

    module C =
        let c = b + 7

module D = 
    let d = B.C.c * 3