namespace Websockets

open System
open System.Threading
open System.Net.WebSockets

module Client =
    type MsgResponse = { Message: string; EOM: bool }

    type WSClient(url) =
        let ws = new ClientWebSocket()


        let timeout (x: int) =
            async {
                System.Threading.Thread.Sleep x
                failwith "Timeout"
            }
            |> Async.Start



        let connect () =
            match ws.State with
            | WebSocketState.Open -> printfn "Tried to connect a websocket client that was already open!"
            | _ ->
                ws.ConnectAsync(Uri(url), CancellationToken.None)
                |> (Async.RunSynchronously << Async.AwaitTask)


        let receive () =
            let buffer = ArraySegment(Array.zeroCreate<byte> 1024)

            let result =
                ws.ReceiveAsync(buffer, CancellationToken.None)
                |> (Async.RunSynchronously << Async.AwaitTask)

            let msg = Text.Encoding.UTF8.GetString(buffer.Array |> Array.take result.Count)

            Some(
                { Message = msg
                  EOM = result.EndOfMessage }
            )

        let send (json: string) =
            let bytes = Text.Encoding.UTF8.GetBytes(json)
            let msg = ArraySegment(bytes, 0, bytes.Length)

            ws.SendAsync(msg, WebSocketMessageType.Text, true, CancellationToken.None)
            |> (Async.RunSynchronously << Async.AwaitTask)

        let startReceive () =
            if not (ws.State = WebSocketState.Open) then
                connect ()

            let rec readMsg oldMsg =
                let response = receive().Value
                let msg = oldMsg + response.Message
                if response.EOM then msg else readMsg msg

            timeout 1000

            let msg = readMsg ""
            msg

        let sendRequest jsonMsg =
            if not (ws.State = WebSocketState.Open) then
                connect ()

            send jsonMsg
            startReceive ()




        member this.CloseStatus = (ws.CloseStatus, ws.CloseStatusDescription)
        member this.SendRequest request = sendRequest request
        member this.StartReceive = startReceive
