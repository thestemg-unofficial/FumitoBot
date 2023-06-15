namespace Discord.HTTP.Channel

open Discord.EventTypes
open Utils

open FsHttp

open FSharpPlus

type ClientChannel(uri, token, chan_id) =
    let url = $"{uri}/channels/{chan_id}/"

    let get route =
        http {
            GET(url + route)
            header "Authorization" $"Bot {token}"
        }

    let channelData () =
        let response = Request.send(get "")
        response.content.ReadAsStringAsync()
        |> map (Json.deserialize<Channel>)

    let getMessages () = 
        let response = Request.send(get "messages")
        printfn "%A" response
        response.content.ReadAsStringAsync()
        |> map id

    member this.ChannelData = channelData
    member this.GetMessages = getMessages
