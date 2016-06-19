(*


*)

module Assembler

open SignalGenerator
open Parsing
open WavePacker

let tokenToSound token = 
    generateSamples (durationFromToken token) (frequency token.sound)

let assemble tokens =
    List.map tokenToSound tokens |> Seq.concat

let assembleToPackedStream (score:string) = 
    match parse score with
    | Choice1Of2 errorMsg -> Choice1Of2 errorMsg
    | Choice2Of2 tokens -> 
        assemble tokens 
        |> Array.ofSeq
        |> pack 
        |> Choice2Of2