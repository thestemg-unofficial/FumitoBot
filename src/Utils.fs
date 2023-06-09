namespace Utils
open System
open System.IO
open System.Runtime.Serialization
open System.Runtime.Serialization.Json
open System.Text

module Json =
   
    let serialize<'T> (thing: 'T) =
        use stream = new MemoryStream()
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.WriteObject(stream, thing)
        stream.Position <- 0L
        let reader = new StreamReader(stream)
        reader.ReadToEnd() 

    let deserialize<'T>(json: string) =
        let bytes = Encoding.UTF8.GetBytes(json)
        use stream = new MemoryStream(bytes)
        let ser = new DataContractJsonSerializer(typeof<'T>)
        ser.ReadObject(stream) :?> 'T

  
   

  
 
