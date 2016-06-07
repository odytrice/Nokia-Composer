#load "../packages/FSharp.Charting.0.90.14/FSharp.Charting.fsx"

open FSharp.Charting

let linear x = 2.0 * x

let quadratic x = x ** 2.

//[for x in 1.0 .. 100.0 -> (x, linear x)] |> Chart.Line

//[for x in -10.0..0.1..10.0 -> x, quadratic x] |> Chart.Line

[for x in -10.0..0.1..10.0 -> x, sin x] |> Chart.Line