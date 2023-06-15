module Discord.EventTypes

open System.Runtime.Serialization
open System.Runtime.Serialization.Json

open System
open Newtonsoft.Json


type GatewayEvent<'T> =
    { op: int
      d: 'T
      s: Nullable<int>
      t: string }



type HeartbeatData =
    { heartbeat_interval: int }


type HeartbeatEvent = GatewayEvent<HeartbeatData>


type Heartbeat =
    { op: int
      d: int option }


type GatewayProperties =
    { os: string
      browser: string
      device: string }





type Activity =
    { name: string
      [<JsonProperty("type")>]
      _type: int }


type Presence =
    { activities: Activity list
      status: string
      since: int
      afk: bool }


type IdentifyData =
    { token: string
      properties: GatewayProperties
      compress: bool option
      large_threshold: int option
      shard: int array
      presence: Presence option
      intents: int }


type IdentifyEvent = GatewayEvent<IdentifyData>

type User =
    { verified: bool
      username: string
      mfa_enabled: bool
      id: string
      global_name: string
      flags: int
      email: string
      discriminator: string
      bot: bool
      avatar: string }


type Guild =
    { unavailable: bool
      id: string }

type Application =
    { id: string
      flags: int }


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


type GuildMembersData =
    { guild_id: string
      query: string option
      limit: int
      presences: bool option
      user_ids: string array option
      nonce: string option }

type GuildMembersEvent = GatewayEvent<GuildMembersData>


type Channel =
    { version: int64
      [<JsonProperty("type")>]
      _type: int
      position: int
      permission_overwrites: obj[]
      name: string
      id: string
      flags: int }

type GuildMember =
    { user: User
      roles: string[]
      premium_since: string
      pending: bool
      nick: string option
      mute: bool
      joined_at: string
      flags: int
      deaf: bool
      communication_disabled_until: obj option
      avatar: string option }

type Role =
    { version: int64
      unicode_emoji: string option
      tags: obj
      position: int
      permissions: string
      name: string
      mentionable: bool
      managed: bool
      id: string
      icon: string option
      hoist: bool
      flags: int
      color: int }



type ChannelMention =
    { id: int64
      guild_id: int64
      [<JsonProperty("type")>]
      _type: int
      name: string }

type Attachment =
    { id: int64
      filename: string
      description: string option
      content_type: string option
      size: int
      url: string
      proxy_url: string
      height: int option
      width: int option
      ephemeral: bool option
      duration_secs: float option
      waveform: string }

type Message =
    { id: int64
      channel_id: int64
      author: User
      content: string
      timestamp: DateTime
      edited_timestamp: DateTime option
      tts: bool
      mention_everyone: bool
      mentions: User[]
      mention_roles: Role[]
      mention_channels: ChannelMention[] option
      attachments: Attachment[] }

type GuildData =
    { stickers: obj[]
      hub_type: string option
      max_video_channel_users: int
      latest_onboarding_question_id: string option
      channels: Channel[]
      features: string[]
      emojis: obj[]
      embedded_activities: obj[]
      application_command_counts: obj
      joined_at: string
      vanity_url_code: string option
      default_message_notifications: int
      stage_instances: obj[]
      description: string option
      nsfw: bool
      member_count: int
      id: string
      guild_hashes: obj
      application_id: string option
      presences: obj[]
      unavailable: bool
      splash: string option
      premium_progress_bar_enabled: bool
      incidents_data: obj option
      max_members: int
      home_header: obj option
      threads: obj[]
      max_stage_video_channel_users: int
      premium_tier: int
      premium_subscription_count: int
      system_channel_id: string option
      afk_channel_id: string option
      members: GuildMember[]
      [<JsonProperty("lazy")>]
      _lazy: bool
      nsfw_level: int
      large: bool
      rules_channel_id: string option
      system_channel_flags: int
      banner: string option
      verification_level: int
      public_updates_channel_id: string option
      afk_timeout: int
      roles: Role[]
      voice_states: obj[]
      explicit_content_filter: int
      discovery_splash: string option
      name: string
      region: string
      icon: string option
      owner_id: string
      preferred_locale: string
      safety_alerts_channel_id: string option
      guild_scheduled_events: obj[]
      mfa_level: int }

type GuildCreateEvent = GatewayEvent<GuildData>
