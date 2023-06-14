open System
open System.IO
open System.Net.Http
open Utils.Json
open Discord.EventTypes
open Websockets.Client

let token = File.ReadAllText "Token.dat"

let identityData: IdentifyData =
    { token = token
      properties =
        { os = "linux"
          browser = ""
          device = "" }
      compress = Some false
      large_threshold = None
      shard = [| 0; 1 |]
      presence = None
      intents = 3665

    }

let identity: IdentifyEvent =
    { op = 2
      d = identityData
      s = Nullable()
      t = "" }



[<EntryPoint>]
let main _ =
    let identity = serialize<IdentifyEvent> identity

    let ws = WSClient "wss://gateway.discord.gg/?v=10&encoding=json"

    let heartbeat = ws.StartReceive() |> deserialize<HeartbeatEvent>
    let readyEvent = identity |> ws.SendRequest |> deserialize<ReadyEvent>

    0
