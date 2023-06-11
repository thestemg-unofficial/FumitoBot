open Utils.Json
open Discord.EventTypes
open Websockets.Client
open System.IO


[<EntryPoint>]
let main _ =
    let identity = File.ReadAllText("identity.json") 
    let ws = WSClient "wss://gateway.discord.gg/?v=10&encoding=json"
   
    let heartbeat = ws.StartReceive() |> deserialize<HeartbeatEvent>
    printfn "%A" heartbeat
    printfn "%A" (ws.SendRequest identity |> deserialize<ReadyEvent>)
   
  
    0
