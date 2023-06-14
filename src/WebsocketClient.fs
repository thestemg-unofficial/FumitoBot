namespace Websockets


open System
open System.Text
open FSharp.Core
open System.Threading
open System.Threading.Tasks
open System.Net.WebSockets
open FSharpPlus

module Task =
    let unit = async { return () } |> Async.StartAsTask

module Client =
    type MsgResponse = { Message: string; EOM : bool }
  
    type WSClient (url) =
        let ws = new ClientWebSocket()

        let onMsgReceived = new Event<string>()
        let onConnect = new Event<WebSocket>()

     
                
            
        
        let connect() =
            match ws.State with
                | WebSocketState.Open ->
                    printfn "Tried to connect a websocket client that was already open!"
                | WebSocketState.Connecting ->
                    printfn "Tried to connect a websocket client that is already in the process of connecting!"
                | _ ->
                    async {
                      do! ws.ConnectAsync(Uri(url), CancellationToken.None) |> Async.AwaitTask
                      printfn "WebSocket connection established."
                      onConnect.Trigger(ws)
                    } |> Async.RunSynchronously

        let sendMessageAsync (message : string) =
            async {
              let encodedMessage = Text.Encoding.UTF8.GetBytes(message)
              let segment = ArraySegment(encodedMessage)
              do! ws.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None) |> Async.AwaitTask
            } |> Async.StartAsTask

        
       


        let receiveAsync() =
            async {
              let buffer = ArraySegment(Array.zeroCreate<byte> 1024)
              let! result = ws.ReceiveAsync(buffer, CancellationToken.None) |> Async.AwaitTask
              let msg = Text.Encoding.UTF8.GetString(buffer.Array |> Array.take result.Count)
              return {Message=msg; EOM=result.EndOfMessage}
            }  |> Async.StartAsTask

           
        let rec startReceive (timeoutMs : int) =
            let timeoutDuration = TimeSpan.FromMilliseconds(float timeoutMs)
            use cts = new CancellationTokenSource(timeoutDuration)
            let timeoutTask : Task = Task.Delay(timeoutDuration, cts.Token)


            let rec readMsg (acc : StringBuilder) =
                receiveAsync() >>= fun resp ->
                    acc.Append(resp.Message) |> ignore
                    let msg = acc.ToString()
                    match resp.EOM with
                    | true ->
                        onMsgReceived.Trigger msg
                      
                        Task.FromResult msg
                    | false -> readMsg acc
                    
            let resultTask = readMsg (StringBuilder ())
          
            Task.WhenAny(timeoutTask, resultTask)
            >>= function
            | completedTask when completedTask = timeoutTask ->
                printfn "Timeout occurred. No message received within %dms." timeoutMs
                Task.FromResult ()
            | _ -> startReceive timeoutMs
            |> Async.AwaitTask
            |> Async.StartAsTask
             

                           
        member this.State = ws.State
        member this.OnMsgReceived = onMsgReceived.Publish
        member this.Connect = connect
        member this.SendMessageAsync = sendMessageAsync
        member this.CloseStatus = (ws.CloseStatus, ws.CloseStatusDescription)

        member this.IsConnected =
            match ws.State with
            | WebSocketState.Open -> true
            | _ -> false
       
     
        member this.StartReceive = startReceive
