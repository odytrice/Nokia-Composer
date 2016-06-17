#I "../../packages/FParsec.1.0.2/lib/net40-client"

#r "FParsec.dll"
#r "FParsecCS.dll"

open FParsec

//Domain
type MeasureFraction = Half | Quarter | Eighth | Sixteenth | ThirtySecondth
type Length = {fraction: MeasureFraction; extended: bool}
type Note = A | ASharp | B | C | CSharp | D | DSharp | E | F | FSharp | G | GSharp
type Octave = One | Two | Three
type Sound = Rest | Tone of Note * Octave
type Token = {length: Length; sound: Sound}


// Test Function
let test p str = 
    match run p str with
    | Success (result, _, _) -> printfn "Success: %A" result
    | Failure (errorMsg,_,_) -> printfn "Error: %s" errorMsg

let aspiration = "32.#d3"

/// 'Choice Combinator' Combines two parsers such that if one fails, it will try the other
let combine = (<|>)

/// Try parse 2 and if it fails try 4, 8, 16, 32
let pmeasurefraction = 
    (stringReturn "2" Half)
    <|> (stringReturn "4" Quarter)
    <|> (stringReturn "8" Eighth)
    <|> (stringReturn "16" Sixteenth)
    <|> (stringReturn "32" ThirtySecondth)

/// Parses extended lenght which is a .
let pextendedparser = (stringReturn "." true) <|> (stringReturn "" false)

/// Parses the length of the note e.g. 16 16. 32 2. etc produces a Length record
let plength = 
    pipe2 
        pmeasurefraction 
        pextendedparser 
        (fun f e -> {fraction = f; extended = e})

/// Applies function to parser and returns new parser
let pipe = (|>>)

/// Parses for Notes that are not Sharpable i.e. B and E
let pnotsharpable = 
    anyOf "be" 
    |>> (function 
        | 'b' -> B 
        | 'e' -> E 
        | unknown -> failwith(sprintf "Unknown note %c" unknown))

/// Parses for a Sharp
let psharp = (stringReturn "#" true) <|> (stringReturn "" false)

/// Parses Notes that could have # i.e. a, #a, c, #c, d, #d, f, #f, g, #g
let psharpnote = 
    pipe2
        psharp
        (anyOf "acdfg")
        (fun isSharp note -> 
            match(isSharp,note) with
            | (false,'a') -> A
            | (true, 'a') -> ASharp
            | (false, 'c') -> C
            | (true, 'c') -> CSharp
            | (false, 'd') -> D
            | (true, 'd') -> DSharp
            | (false, 'f') -> F
            | (true, 'f') -> FSharp
            | (false, 'g') -> G
            | (true, 'g') -> GSharp
            | (_, unknown) -> failwith(sprintf "Unknown note %c" unknown))

/// Parses a note e.g. #b, #c a note is either a sharp note or non-sharp note
let pnote = psharpnote <|> pnotsharpable

test pnote "#b"

/// Finally parses for Octaves e.g. 1, 2, or 3
let poctave = 
    anyOf "123" 
    |>> (function 
        | '1' -> One
        | '2' -> Two
        | '3' -> Three
        | unknown -> failwith (sprintf "Unknown octave %c" unknown))

/// Parses a Tone - #d3 b2 a Tone is note followed by an octave
let ptone = pipe2 pnote poctave (fun n o -> Tone(n,o))

/// Parses a Rest Tone
let prest = stringReturn "-" Rest

/// Parses a complete token - e.g. 32.#d3 16.- 8a1 a token is a length followed by a tone or a rest
let ptoken = pipe2 plength (prest <|> ptone) (fun l s -> {length = l; sound = s} )

/// Parses tokens separated by spaces
let pscore = sepBy ptoken (pstring " ")

test plength "8."
test pnote "b"
test poctave "2"
test prest "-"
test ptone "#c2"
test ptoken "16.-"
test ptoken "32.#d3"
test pscore "32.#d3 8a1 16-"
test pscore "2- 16a1 16- 16a1 16- 8a1 16- 4a2 16g2 16- 2g2 16- 4- 8- 16g2 16- 16g2 16- 16g2 8g2 16- 4c2 16#a1 16- 4a2 8g2 4f2 4g2 8d2 8f2 16- 16f2 16- 16c2 8c2 16- 4a2 8g2 16f2 16- 8f2 16- 16c2 16- 4g2 4f2"
