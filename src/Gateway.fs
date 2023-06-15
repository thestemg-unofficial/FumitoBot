module Discord.Gateway
open Discord.EventTypes
open Utils.Json
open Websockets.Client
open System
open Newtonsoft.Json

module EventParser =
    type ParsedEvent =
        | HeartbeatEvent of HeartbeatEvent
        | ReadyEvent of ReadyEvent
        | GuildCreateEvent of GuildCreateEvent
        | UnknownEvent of string * string

    let parseEvent (msg : string) : ParsedEvent =
        let aMsg = JsonConvert.DeserializeObject<GatewayEvent<obj>> msg
   
        match aMsg.op, aMsg.t with
            | 10, _ -> HeartbeatEvent <| JsonConvert.DeserializeObject<HeartbeatEvent> msg
            | 0 , "READY" -> ReadyEvent <| JsonConvert.DeserializeObject<ReadyEvent> msg
            | 0, "GUILD_CREATE" -> GuildCreateEvent <| JsonConvert.DeserializeObject<GuildCreateEvent> msg
            | op, t -> UnknownEvent (string op, t)




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
        |> JsonConvert.SerializeObject
        |> ws.SendMessageAsync
        |> Async.AwaitTask
        |> ignore


        
