// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program
open Printer

[<EntryPoint>]
let main argv = 
    printArray "%A" argv
    0 // return an integer exit code
