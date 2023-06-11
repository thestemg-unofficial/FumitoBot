namespace Utils
open System
open System.IO
open System.Runtime.Serialization
open System.Runtime.Serialization.Json

module Json =
    let serialize<'T> thing =
        let stream = new MemoryStream()
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.WriteObject(stream, thing)
        stream.ToArray() 

    let deserialize<'T>(json: string) =
        let bytes = Text.Encoding.UTF8.GetBytes(json)
        let stream = new MemoryStream(bytes)
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.ReadObject(stream) :?> 'T
