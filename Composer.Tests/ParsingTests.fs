module ParsingTests

open NUnit.Framework
open Parsing

[<TestFixture>]
type ``When parsing a simple score`` () =
    
    [<Test>]
    member this.``It should parse a simple score`` () =
        let score  = "32.#d3 16-"
        let result = parse score

        let assertFirstToken token = 
            Assert.AreEqual({ Fraction = ThirtySecondth; Extended = true}, token.Length)
            Assert.AreEqual(Tone(DSharp,Three) , token.Sound)

        let assertSecondToken token = 
            Assert.AreEqual({ Fraction = Sixteenth; Extended = false },token.Length)
            Assert.AreEqual(Rest, token.Sound)

        match result with
        | Choice1Of2 errorMsg -> Assert.Fail(errorMsg)
        | Choice2Of2 tokens -> 
            Assert.AreEqual(2, List.length tokens)
            List.head tokens |> assertFirstToken
            List.item 1 tokens |> assertSecondToken
    