namespace Discord.HTTP.Client

open Discord.HTTP.Channel

type HttpClient (url,token) = 
    let getChannel chan_id = new ClientChannel(url,token,chan_id)
    member this.GetChannel = getChannel
