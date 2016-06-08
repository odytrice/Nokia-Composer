let rec length = 
    function 
    | [] -> 0
    | x :: xs -> 1 + length xs

// factorial n = n * (n - 1) * (n - 2)
let rec factorial n = 
    if n < 2 then 1
    else n * factorial (n - 1)
