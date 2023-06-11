module Discord.EventTypes
open System
open System.Runtime.Serialization
open System.Runtime.Serialization.Json


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
type GatewayProperties = {
    [<field: DataMember(Name = "os")>]
    os: string
    [<field: DataMember(Name = "browser")>]
    browser: string
    [<field: DataMember(Name = "device")>]
    device: string }

[<DataContract>]
type Activity = {
    [<field: DataMember(Name = "name")>]
    name: string
    [<field: DataMember(Name = "type")>]
    type_: int }

[<DataContract>]
type Presence = {
    [<field: DataMember(Name = "activities")>]
    activities: Activity list
    [<field: DataMember(Name = "status")>]
    status: string
    [<field: DataMember(Name = "since")>]
    since: int
    [<field: DataMember(Name = "afk")>]
    afk: bool }

[<DataContract>]
type IdentifyData = {
    [<field: DataMember(Name = "token")>]
    token: string
    [<field: DataMember(Name = "properties")>]
    properties: GatewayProperties
    [<field: DataMember(Name = "compress")>]
    compress: bool
    [<field: DataMember(Name = "large_threshold")>]
    large_threshold: int
    [<field: DataMember(Name = "shard")>]
    shard: int list
    [<field: DataMember(Name = "presence")>]
    presence: Presence
    [<field: DataMember(Name = "intents")>]
    intents: int }

[<DataContract>]
type IdentifyEvent = GatewayEvent<IdentifyData>


[<DataContract>]
type User = {
    [<field: DataMember(Name = "verified")>]
    verified: bool
    [<field: DataMember(Name = "username")>]
    username: string
    [<field: DataMember(Name = "mfa_enabled")>]
    mfa_enabled: bool
    [<field: DataMember(Name = "id")>]
    id: string
    [<field: DataMember(Name = "global_name")>]
    global_name: string option
    [<field: DataMember(Name = "flags")>]
    flags: int
    [<field: DataMember(Name = "email")>]
    email: string option
    [<field: DataMember(Name = "discriminator")>]
    discriminator: string
    [<field: DataMember(Name = "bot")>]
    bot: bool
    [<field: DataMember(Name = "avatar")>]
    avatar: string option }

[<DataContract>]
type Guild = {
    [<field: DataMember(Name = "unavailable")>]
    unavailable: bool
    [<field: DataMember(Name = "id")>]
    id: string }

[<DataContract>]
type Application = {
    [<field: DataMember(Name = "id")>]
    id: string
    [<field: DataMember(Name = "flags")>]
    flags: int }


[<DataContract>]
type ReadyData = {
    [<field: DataMember(Name = "v")>]
    v: int
    [<field: DataMember(Name = "user_settings")>]
    user_settings: obj
    [<field: DataMember(Name = "user")>]
    user: User
    [<field: DataMember(Name = "session_type")>]
    session_type: string
    [<field: DataMember(Name = "session_id")>]
    session_id: string
    [<field: DataMember(Name = "resume_gateway_url")>]
    resume_gateway_url: string
    [<field: DataMember(Name = "relationships")>]
    relationships: obj []
    [<field: DataMember(Name = "private_channels")>]
    private_channels: obj []
    [<field: DataMember(Name = "presences")>]
    presences: obj []
    [<field: DataMember(Name = "guilds")>]
    guilds: Guild []
    [<field: DataMember(Name = "guild_join_requests")>]
    guild_join_requests: obj []
    [<field: DataMember(Name = "geo_ordered_rtc_regions")>]
    geo_ordered_rtc_regions: string []
    [<field: DataMember(Name = "application")>]
    application: Application }

[<DataContract>]
type ReadyEvent = GatewayEvent<ReadyData>
        

