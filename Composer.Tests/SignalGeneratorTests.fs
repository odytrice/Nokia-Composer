module SignalGeneratorTests

open NUnit.Framework
open SignalGenerator

[<TestFixture>]
type ``When generating 2 seconds at 440Hz`` () =

    [<Test>]
    member this.``There should be 88200 samples`` () =
        let samples = generateSamples 2000.0 440.0
        Assert.AreEqual(88200, Seq.length samples)

    [<Test>]
    member this.``All samples should be in range`` () =
        let sixteenBitSampleLimit = 32767s
        let samples = generateSamples 2000.0 440.0

        let isInRange s = s > (-1s * sixteenBitSampleLimit) 
                          && s < sixteenBitSampleLimit

        samples 
        |> Seq.iter (fun s -> Assert.IsTrue(isInRange s))

[<TestFixture>]
type ``When generating 2 seconds at 0Hz`` () =
    
    [<Test>]
    member this.``The samples should all be 0`` () =
        let samples = generateSamples 2000.0 0.0
        Assert.AreEqual(Seq.init 88200 (fun i -> int16 0) , samples)