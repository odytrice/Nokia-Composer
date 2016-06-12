module WavePackerTests

open NUnit.Framework
open WavePacker
open SignalGenerator
open System.IO

[<TestFixture>]
type ``When packing an audio file`` () =
    
    let getFile milliseconds = 
        generateSamples milliseconds 440.0
        |> Array.ofSeq
        |> pack
        |> (fun ms -> ms.Seek(0L, SeekOrigin.Begin) |> ignore; ms)

    [<Test>]
    member this.``Stream should start with 'RIFF'`` () =
        let file = getFile 200.0
        
        //Create and Read into buffer
        let buffer = Array.zeroCreate 4
        file.Read(buffer, 0, 4) |> ignore
        
        //Read characters from byte buffer
        let first4chars = System.Text.Encoding.ASCII.GetString(buffer)
        Assert.AreEqual("RIFF",first4chars)

    [<Test>]
    member this.``File size is correct`` () =
        let formatOverhead = 44.0
        let audioLengths = [2000.0; 50.0; 1500.0; 3000.0]
        let files = List.zip audioLengths (List.map getFile audioLengths)

        let assertLength (length, file:MemoryStream) =
            Assert.AreEqual((length/1000.0) * 44100.0 * 2.0 + formatOverhead, file.Length)

        List.iter assertLength files