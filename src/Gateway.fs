module Discord.Gateway
open Discord.EventTypes
open Utils.Json
open Websockets.Client
open System

module EventParser =
    type ParsedEvent =
        | HeartbeatEvent of HeartbeatEvent
        | ReadyEvent of ReadyEvent
        | GuildCreateEvent of GuildCreateEvent
        | UnknownEvent of string * string

    let parseEvent (msg : string) : ParsedEvent =
        let aMsg = deserialize<GatewayEvent<obj>> msg
   
        match aMsg.op, aMsg.t with
            | 10, _ -> HeartbeatEvent <| deserialize<HeartbeatEvent> msg
            | 0 , "READY" -> ReadyEvent <| deserialize<ReadyEvent> msg
            | 0, "GUILD_CREATE" -> GuildCreateEvent <| deserialize<GuildCreateEvent> msg
            | op, t -> UnknownEvent (string op, t)



let Identity : IdentifyData = {
      token = ""
      properties = {os = ""; browser = ""; device = ""}
      compress = Some false
      large_threshold = None
      shard = [|0 ; 1|]
      presence = None
      intents = 0 }

let withToken token identifyData =
    { identifyData with token = token }

let withProperties properties identifyData =
    { identifyData with properties = properties }

let withCompress compress identifyData =
    { identifyData with compress = Some compress }

let withLargeThreshold largeThreshold identifyData =
    { identifyData with large_threshold = Some largeThreshold }

//let withShard shard identifyData =
//    { identifyData with shard = shard }

let withPresence presence identifyData =
    { identifyData with presence = Some presence }

let withIntents intents identifyData =
    { identifyData with intents = intents }

type Gateway(identity) =
    let ws = WSClient "wss://gateway.discord.gg/?v=10&encoding=json"
    let timeout = 5000

    let start () =
        ws.Connect()
        ws.StartReceive timeout
    
    member this.Start = start ()
      

    member this.MsgHandler fn = ws.OnMsgReceived.Add fn
    
    member this.Identify identity =
        {op = 2; d = identity; s = Nullable(); t = ""}
        |> serialize<IdentifyEvent>
        |> ws.SendMessageAsync
        |> Async.AwaitTask
        |> ignore


        
