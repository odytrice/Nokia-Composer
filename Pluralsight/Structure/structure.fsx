
(* Require Qualified Access *)
List.map ((*) 2) [ 1; 2; 3 ]

//open List                         //Can't do this because List has a RequireQualifiedAccess
//map ((*) 2) [ 1; 2; 3 ]



(* Try With *)
try
    failwith "An error message"
with
    | Failure msg -> printfn "Failed with %s" msg



(* Try Finally *)
try
    try
        failwith "This is an Exception"
    with
    | Failure msg -> printfn "Failed with %s" msg
finally
    printfn "This always evaluates"


try
    try
        failwith "This is an Exception"    
    finally
        printfn "This always evaluates"
with
    | Failure msg -> printfn "Failed with %s" msg



(* Custom Exceptions *)
exception CountingException of string * int

try 
    raise (CountingException("number", 1))
with 
| CountingException(msg, number) -> printfn "This is number %d" number



(* DotNet Exceptions *)
try
    raise (new System.Exception("General Error"))
    //1 / 0
with
| :? System.DivideByZeroException as ex -> 
    printfn "Don't do that %s" ex.Message
    0
| :? System.Exception as ex when ex.Message = "General Error" -> 
    printfn "Some other error %s" ex.Message
    0


(* Use Statement *)

open System.IO

let readFile() =
    use reader = new StreamReader(__SOURCE_DIRECTORY__ + "\\text.txt")
    reader.ReadToEnd()

readFile();