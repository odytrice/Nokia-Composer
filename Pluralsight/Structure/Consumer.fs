module Consumer

open System

open CSharpLibrary

type Consumer() = 
    let c1 = Numbers()
    member this.X = c1.FirstCountingNumbers()

    interface ICanAddNumbers with
        member this.Add(a, b) = a + b


System.Double.TryParse("2.3")
|> function
    | (true, value) -> printfn "%f" value
    | (false, _)       -> printfn "could not parse"