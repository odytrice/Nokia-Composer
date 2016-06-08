#load "../packages/FSharp.Charting.0.90.14/FSharp.Charting.fsx"

open System
open FSharp.Charting

let generateSamples milliseconds frequency = 
    let sampleRate = 44100.0
    let sixteenBitSampleLimit = 32767.0
    let volume = 0.8

    let toAmplitude x =
        x |> (*) (2.0 * Math.PI * frequency / sampleRate)
          |> sin
          |> (*) sixteenBitSampleLimit
          |> (*) volume
          |> int16

    let numOfSamples = milliseconds / 1000.0 * sampleRate
    let requiredSamples = seq { 1.0..numOfSamples }

    Seq.map toAmplitude requiredSamples

let points = generateSamples 150.0 440.0
points |> Chart.Line