open System
open System.Linq

//[0L..Int64.MaxValue] //Out of Memory

seq {0L..Int64.MaxValue}

seq {0..2..10}

seq {for i in [1..10] -> i * i}

let board = 
    seq {
        for row in [1..8] do
        for col in [1..8] do
        yield pown (-1) (row + col)
    }
    |> Seq.map (fun i -> if i = -1 then "x " else "o ")


let print i v =
    //Line break after every 8 items
    if i > 0 && i % 8 = 0 then
        printfn ""
    //print item
    printf "%s" v

//Display a Chess Board
Seq.iteri print board