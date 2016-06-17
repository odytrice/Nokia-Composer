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