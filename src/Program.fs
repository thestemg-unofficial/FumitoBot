open System.IO
<<<<<<< HEAD
open System.Threading
open Discord.Gateway
=======
open Utils.Json
open Discord.EventTypes
open Websockets.Client
>>>>>>> origin/master





[<EntryPoint>]
let main _ =
    let identity =
        Identity
        |> withToken (File.ReadAllText "Token.dat")
        |> withIntents 3665
    
    let gateway = Gateway ()

    gateway.MsgHandler (fun msg -> printfn "Message: %A\n" (EventParser.parseEvent msg))
    gateway.Start |> ignore
    gateway.Identify identity
    
   

    Thread.Sleep 1000

    

    
   
   
       

    0
