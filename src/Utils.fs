namespace Utils
open System
open System.IO
open System.Runtime.Serialization
open System.Runtime.Serialization.Json
open System.Text






module Json =
   
    let serialize<'T> (thing: 'T) =
        let stream = new MemoryStream()
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.WriteObject(stream, thing)
        stream.Position <- 0L
        let reader = new StreamReader(stream)
        reader.ReadToEnd() //|> Encoding.UTF8.GetString

    let deserialize<'T>(json: string) =
        let bytes = Encoding.UTF8.GetBytes(json)
        let stream = new MemoryStream(bytes)
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.ReadObject(stream) :?> 'T

  
   

  
 
