exception CountingException of string * int

try 
    raise (CountingException("number", 1))
with 
| CountingException(msg, number) -> printfn "This is number %d" number
