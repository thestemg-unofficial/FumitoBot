open System.IO
open System.Threading

open Discord.Gateway
open Discord.Types.Gateway

open Discord.HTTP.Client

open Newtonsoft.Json

open FSharpPlus
open Discord.Types.Channel

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

    let httpTask =
        task {
            let httpClient = new HttpClient("https://discord.com/api/v10", token)
            let channel = httpClient.GetChannel("951452676665794603")

            Tasks.Task.WaitAll
            <| List.toArray
                [ channel.Channel() >>= (result << printfn "data\n\n\n%A")
                  channel.CreateMessage
                      { content = "test" }
                  >>= (result << printfn "data\n\n\n%A")
                  ]
        }

    httpTask.Wait()

    Thread.Sleep 1000

    0
