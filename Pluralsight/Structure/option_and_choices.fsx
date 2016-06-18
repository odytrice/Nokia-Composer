open System

let firstOdd xs = 
    List.tryPick (fun x -> 
        if x % 2 = 1 then Some x
        else None) xs

firstOdd [ 2; 4; 6 ]
firstOdd [ 2; 4; 5; 6; 7 ]

// Due to partial application, this also works. Its known as the point free style
let firstOdd' xs = 
    List.tryPick (fun x -> 
        if x % 2 = 1 then Some x
        else None) xs

let print = 
    function 
    | Some v -> sprintf "%A" v
    | None -> "nothing"

let toNumberAndSquare o = 
    Option.bind (fun s -> 
        let (succeeded, value) = Double.TryParse(s)
        if succeeded then Some value
        else None) o
    |> Option.bind (fun n -> n * n |> Some)

Some "5"
|> toNumberAndSquare
|> print
|> Console.WriteLine
Some "foo"
|> toNumberAndSquare
|> print
|> Console.WriteLine

type Option'<'a> = 
    | Some of 'a
    | None

/// Choices
open System

let div num den = num / den

div 15 3
// div 15 0         //Raises an Exception

let safeDiv num den = 
    match den with
    | 0.0 -> Choice1Of2 "divide by zero is undefined"
    | _ -> Choice2Of2(num / den)

safeDiv 15.0 3.0
safeDiv 15.0 0.0

