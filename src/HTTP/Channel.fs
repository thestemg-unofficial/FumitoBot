namespace Discord.HTTP.Channel

open Discord.Types.Channel

open Newtonsoft.Json

open FsHttp

open FSharpPlus

type ClientChannel(uri, token, chan_id) =
    let url = $"{uri}/channels/{chan_id}"

    let get route =
        let route =
            match route with
            | "" -> ""
            | xs -> "/" + xs

        http {
            GET(url + route)
            header "Authorization" $"Bot {token}"
        }

    let post route obj = 
        let route =
            match route with
            | "" -> ""
            | xs -> "/" + xs

        http {
            POST (url + route)
            header "Authorization" $"Bot {token}"
            body
            json (JsonConvert.SerializeObject obj)
        }

    let channel () =
        let response = Request.send (get "")

        response.content.ReadAsStringAsync()
        |> map JsonConvert.DeserializeObject<Channel>

    let getMessages () =
        let response = Request.send (get "messages")

        response.content.ReadAsStringAsync()
        |> map JsonConvert.DeserializeObject<Message List>

    let getMessage messageId = 
        let response = Request.send (get $"messages/{messageId}")
        
        response.content.ReadAsStringAsync()
        |> map JsonConvert.DeserializeObject<Message>

    let createMessage (content : MessageForm) = 
        let response = Request.send (post "messages" content)
        response.content.ReadAsStringAsync()
        |> map JsonConvert.DeserializeObject<Message>

    member this.Channel = channel
    member this.Messages = getMessages
    member this.Message = getMessage
    member this.CreateMessage = createMessage
