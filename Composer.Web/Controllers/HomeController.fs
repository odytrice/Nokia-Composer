namespace Composer.Web.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

type HomeController() = 
    inherit Controller()

    member this.Index() = this.View()

    [<HttpPost>]
    member this.Produce(score:string) = 
        match Assembler.assembleToPackedStream score with
        | Choice1Of2 err -> this.Content(err) :> ActionResult
        | Choice2Of2 ms -> 
            //rewind memorystream
            ms.Position <- 0L
            this.File(ms,"audio/x-wav","ringtone.wav") :> ActionResult