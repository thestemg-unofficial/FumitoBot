namespace Discord.HTTP.Api

open Discord.HTTP.Channel

type HttpClient (url,token) = 
    let getChannel chan_id = new ApiChannel(url,token,chan_id)
    member this.GetChannel = getChannel
