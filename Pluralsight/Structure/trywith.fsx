try
    failwith "An error message"
with
    | Failure msg -> printfn "Failed with %s" msg
