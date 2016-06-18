#r @"..\..\packages\FSharp.Data.2.3.0\lib\net40\FSharp.Data.dll"

open FSharp.Data
open System

let landings = CsvProvider<"Meteorite_Landings.csv", Schema=",,,,,,date?">.GetSample()
let landingsWithYears = 
    landings.Rows 
    |> Seq.filter (fun r -> r.Year.HasValue && not (Double.IsNaN(r.``Mass (g)``)) && r.Year.Value.Year > 1770)

landingsWithYears
|> Seq.sortByDescending (fun r -> r.``Mass (g)``)
|> Seq.map (fun r -> (r.Year, r.Name, r.``Mass (g)``))
|> List.ofSeq
|> printfn "%A"

//Or Using LINQ
open System.Linq

let landingQuery = 
    query { 
        for landings in landingsWithYears do
            sortByDescending landings.``Mass (g)``
            select (landings.Year, landings.Name, landings.``Mass (g)``)
    }

landingQuery
|> List.ofSeq
|> printfn "%A"

//Display in Chart
#load @"..\..\packages\FSharp.Charting.0.90.14\FSharp.Charting.fsx"

open FSharp.Charting
// Order Landings by Date and Group Landings by Year
landingsWithYears
|> Seq.sortBy (fun r -> r.Year.Value)
|> Seq.groupBy (fun r -> r.Year.Value.Year)
|> Seq.map (fun (year, group) -> 
       let largestByYear = group |> Seq.maxBy (fun r -> r.``Mass (g)``)
       (year, largestByYear.``Mass (g)`` / 1000.0))
|> Chart.Line


// Or using the Query syntax
let chartQuery = 
    query { 
        for row in landingsWithYears do
        sortBy row.Year.Value.Year
        groupBy row.Year.Value.Year into grp
        let largestByYear = grp |> Seq.maxBy (fun r -> r.``Mass (g)``)
        select (grp.Key, largestByYear.``Mass (g)`` / 1000.0)
    }

chartQuery |> Chart.Line


//Read AppSettings using Type Providers
#r @"..\..\packages\FSharp.Configuration.0.6.1\lib\net40\FSharp.Configuration.dll"
open FSharp.Configuration
open System.IO

type Settings = AppSettings<"../App.config">
(Settings.Name, Settings.Version)