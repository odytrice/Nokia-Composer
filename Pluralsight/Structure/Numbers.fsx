#r @"..\..\CSharpLibrary\bin\Debug\CSharpLibrary.dll"

open CSharpLibrary
open System

// Instantiate C# Objects and Call C# Methods
let n = Numbers()

n.FirstCountingNumbers()
{ // Implement Interfaces with Object Expressions
  new ICanAddNumbers with
      member this.Add(a, b) = a + b }

// The compiler cleans up out params
let (isSuccess, value) = Double.TryParse("3.14159")

// You can then pipe the tuple to a lambda containing a match expression
Double.TryParse("3.14159") 
|> (fun result -> 
        match result with
        | (true, value) -> printfn "%f" value
        | (false, _) -> printfn "could not parse")

// Or simply
Double.TryParse("3.14159") 
|> (function
    | (true, value) -> printfn "%f" value
    | (false, _) -> printfn "could not parse")