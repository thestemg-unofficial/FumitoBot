namespace Discord

open System
open System.Runtime.Serialization
open System.Runtime.Serialization.Json

module EventTypes =
    [<DataContract>]
    type OpCode = {
       [<field: DataMember(Name = "op")>]
       op:int }
    [<DataContract>]
    type GatewayEvent<'T> = {
       [<field: DataMember(Name = "op")>]
       op: int
       [<field: DataMember(Name = "d")>]
       d: 'T
       [<field: DataMember(Name = "s")>]
       s: Nullable<int>
       [<field: DataMember(Name = "t")>]
       t: string }

    [<DataContract>]
    type HeartbeatData = {
       [<field: DataMember(Name = "heartbeat_interval")>]
    heartbeat_interval:int }
    [<DataContract>]
    type HeartbeatEvent = GatewayEvent<HeartbeatData>

    [<DataContract>]
    type IdentifyProperties = {
        [<field: DataMember(Name = "os")>]
        os: string
        [<field: DataMember(Name = "browser")>]
        browser: string
        [<field: DataMember(Name = "device")>]
        device: string }
    [<DataContract>]
    type IdentifyData = {
        [<field: DataMember(Name = "token")>]
        token: string
        [<field: DataMember(Name = "properties")>]
        properties: IdentifyProperties
        [<field: DataMember(Name = "intents")>]
        intents: int
        }
    [<DataContract>]
    type IdentifyEvent = GatewayEvent<IdentifyData>
        

