namespace Discord.Types.Event

open Discord.Types.User
open Discord.Types.Guild

open System

type Application = { id: string; flags: int }

type GatewayEvent<'T> =
    { op: int
      d: 'T
      s: Nullable<int>
      t: string }

type ReadyData =
    { v: int
      user_settings: obj
      user: User
      shard: int[]
      session_type: string
      session_id: string
      resume_gateway_url: string
      relationships: obj[]
      private_channels: obj[]
      presences: obj[]
      guilds: Guild[]
      guild_join_requests: obj[]
      geo_ordered_rtc_regions: string[]
      application: Application
      _trace: string[] }

type ReadyEvent = GatewayEvent<ReadyData>
type GuildMembersEvent = GatewayEvent<GuildMembersData>
type GuildCreateEvent = GatewayEvent<GuildData>
