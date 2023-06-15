namespace Discord.Types.Gateway

open Discord.Types.User
open Discord.Types.Guild
open Discord.Types.Event

open System

type HeartbeatData =
    { heartbeat_interval: int }

type Heartbeat =
    { op: int
      d: int option }
type HeartbeatEvent = GatewayEvent<HeartbeatData>

type GatewayProperties =
    { os: string
      browser: string
      device: string }

type IdentifyData =
    { token: string
      properties: GatewayProperties
      compress: bool option
      large_threshold: int option
      shard: int array
      presence: Presence option
      intents: int }

type IdentifyEvent = GatewayEvent<IdentifyData>
