open System.IO
open System.Threading

open Discord.Gateway
open Discord.EventTypes
open Discord.HTTP.Api

open Utils.Json
open Websockets.Client


[<EntryPoint>]
let main _ =
    let token = File.ReadAllText "Token.dat"
    let identity =
        Identity |> withToken token |> withIntents 3665

    let gateway = Gateway()

    gateway.MsgHandler(fun msg -> printfn "Message: %A\n" (EventParser.parseEvent msg))
    gateway.Start |> ignore
    gateway.Identify identity

    task {
        let httpClient = new HttpClient ("https://discord.com/api/v10", token)
        let! data = httpClient.GetChannel("951452676665794603").GetMessages()
        printfn "%A" data
    } |> ignore

    Thread.Sleep 1000

    0
