open System.IO
open System.Threading

open Discord.Gateway
open Discord.EventTypes
open Discord.HTTP.Client

open Utils.Json
open Websockets.Client
open Newtonsoft.Json
open System


let token = File.ReadAllText "Token.dat"
let identity = 
    { token = token
      properties = { os = ""; browser = ""; device = "" }
      compress = None
      large_threshold = None
      shard = [| 1; 2 |]
      presence = None
      intents = 3665 }


[<EntryPoint>]
let main _ =

    let gateway = Gateway()


    gateway.MsgHandler(fun msg -> printfn "Message: %A\n" (EventParser.parseEvent msg))
    gateway.Start |> ignore
    let i = gateway.Identify identity
    task {
        let httpClient = new HttpClient ("https://discord.com/api/v10", token)
        let! data = httpClient.GetChannel("951452676665794603").GetMessages()
        printfn "%A" data
    } |> ignore

    Thread.Sleep 1000

    0
