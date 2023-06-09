open System
open System.Net.WebSockets
open System.Threading

let makeClient (url: string) =
    let socket, uri = new ClientWebSocket(), new Uri(url)

    socket.ConnectAsync(uri, CancellationToken.None)
    |> (Async.RunSynchronously << Async.AwaitTask)

[<EntryPoint>]
let main _ =
    let uri =
        new Uri("wss://demo.piesocket.com/v3/channel_123?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self")

    let ws = new ClientWebSocket()
    ws.ConnectAsync(uri, Unchecked.defaultof<CancellationToken>) |> ignore
    0
