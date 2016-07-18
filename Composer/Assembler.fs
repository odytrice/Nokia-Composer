(*
    This module coordinates the score parser, signal generator 
    and wave packer to convert a score into an audio file.
*)

module Assembler

open SignalGenerator
open Parsing
open WavePacker

let tokenToSound token = 
    generateSamples (durationFromToken token) (frequency token.Sound)

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