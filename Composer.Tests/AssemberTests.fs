module AssemberTests

open NUnit.Framework
open Parsing
open Assembler


[<TestFixture>]
type ``When assembling a composition`` () =
    let extractChoice2 v =
        match v with
        | Choice1Of2 s -> sprintf "Unexpected choice value %A" s |> failwith
        | Choice2Of2 s -> s
        
    [<Test>]
    member this.``The result should have the correct length`` () =
        let scoreD = parse "2#d3 2- 2- 8#d3 4c2 4c2 8c1 2- 4c1" |> extractChoice2
        let samples = assemble scoreD
        let expectedSamples = 6.0 * 44100.0
        Assert.AreEqual(expectedSamples, Seq.length samples)