open Utils.Json
open Discord.EventTypes
open Websockets.Client
open System.IO






[<EntryPoint>]
let main _ =
    let identity = File.ReadAllText("identity.json") 
    let ws = WSClient "wss://gateway.discord.gg/?v=10&encoding=json"
    ws.OnResponse.Add (fun data ->
                       printfn "Data: %A\n\n" data)
    (ws.StartReceive())
    identity |> ws.Send
    (ws.StartReceive())
    0
