type Person = { name : string; age : int }

let data = 
    [ 
        { name = "Abigail"; age = 6 } 
        { name = "Ben" ;age = 12 }
        { name = "Christine"; age = 18}
        { name = "Daniel"; age = 24}
        { name = "Emily"; age = 30} 
    ]

// F# collection functions
let nameOfAdults =
    data
    |> List.filter (fun p -> p.age >= 18)
    |> List.map (fun p -> p.name)


// LINQ Extension Methods
open System.Linq
let namesOfAdultsLinq = 
    data.Where(fun p -> p.age >= 18)
        .Select(fun p -> p.name)

printfn "%A" namesOfAdultsLinq

// LINQ Query Expressions
let namesOfAdultsLinqQuery =
    query {
        for p in data do
        where (p.age >= 18)
        select p.name
    }

printfn "%A" namesOfAdultsLinqQuery