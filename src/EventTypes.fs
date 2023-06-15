module Discord.EventTypes

open System
open System.Runtime.Serialization
open System.Runtime.Serialization.Json

[<DataContract>]
type GatewayEvent<'T> =
    { [<field: DataMember(Name = "op")>]
      op: int
      [<field: DataMember(Name = "d")>]
      d: 'T
      [<field: DataMember(Name = "s")>]
      s: Nullable<int>
      [<field: DataMember(Name = "t")>]
      t: string }


[<DataContract>]
type HeartbeatData =
    { [<field: DataMember(Name = "heartbeat_interval")>]
      heartbeat_interval: int }

[<DataContract>]
type HeartbeatEvent = GatewayEvent<HeartbeatData>

[<DataContract>]
type Heartbeat =
    { [<field: DataMember(Name = "op")>]
      op: int
      [<field: DataMember(Name = "d")>]
      d: int option }

[<DataContract>]
type GatewayProperties =
    { [<field: DataMember(Name = "os")>]
      os: string
      [<field: DataMember(Name = "browser")>]
      browser: string
      [<field: DataMember(Name = "device")>]
      device: string }




[<DataContract>]
type Activity =
    { [<field: DataMember(Name = "name")>]
      name: string
      [<field: DataMember(Name = "type")>]
      type_: int }

[<DataContract>]
type Presence =
    { [<field: DataMember(Name = "activities")>]
      activities: Activity list
      [<field: DataMember(Name = "status")>]
      status: string
      [<field: DataMember(Name = "since")>]
      since: int
      [<field: DataMember(Name = "afk")>]
      afk: bool }

[<DataContract>]
type IdentifyData =
    { [<field: DataMember(Name = "token")>]
      token: string
      [<field: DataMember(Name = "properties")>]
      properties: GatewayProperties
      [<field: DataMember(Name = "compress")>]
      compress: bool option
      [<field: DataMember(Name = "large_threshold")>]
      large_threshold: int option
      [<field: DataMember(Name = "shard")>]
      shard: int array
      [<field: DataMember(Name = "presence")>]
      presence: Presence option
      [<field: DataMember(Name = "intents")>]
      intents: int }

[<DataContract>]
type IdentifyEvent = GatewayEvent<IdentifyData>


[<DataContract>]
type User =
    { [<field: DataMember(Name = "verified")>]
      verified: bool
      [<field: DataMember(Name = "username")>]
      username: string
      [<field: DataMember(Name = "mfa_enabled")>]
      mfa_enabled: bool
      [<field: DataMember(Name = "id")>]
      id: string
      [<field: DataMember(Name = "global_name")>]
      global_name: string
      [<field: DataMember(Name = "flags")>]
      flags: int
      [<field: DataMember(Name = "email")>]
      email: string
      [<field: DataMember(Name = "discriminator")>]
      discriminator: string
      [<field: DataMember(Name = "bot")>]
      bot: bool
      [<field: DataMember(Name = "avatar")>]
      avatar: string

    }

[<DataContract>]
type Guild =
    { [<field: DataMember(Name = "unavailable")>]
      unavailable: bool
      [<field: DataMember(Name = "id")>]
      id: string }

[<DataContract>]
type Application =
    { [<field: DataMember(Name = "id")>]
      id: string
      [<field: DataMember(Name = "flags")>]
      flags: int }



[<DataContract>]
type ReadyData =
    { [<field: DataMember(Name = "v")>]
      v: int
      [<field: DataMember(Name = "user_settings")>]
      user_settings: obj
      [<field: DataMember(Name = "user")>]
      user: User
      [<field: DataMember(Name = "shard")>]
      shard: int[]
      [<field: DataMember(Name = "session_type")>]
      session_type: string
      [<field: DataMember(Name = "session_id")>]
      session_id: string
      [<field: DataMember(Name = "resume_gateway_url")>]
      resume_gateway_url: string
      [<field: DataMember(Name = "relationships")>]
      relationships: obj[]
      [<field: DataMember(Name = "private_channels")>]
      private_channels: obj[]
      [<field: DataMember(Name = "presences")>]
      presences: obj[]
      [<field: DataMember(Name = "guilds")>]
      guilds: Guild[]
      [<field: DataMember(Name = "guild_join_requests")>]
      guild_join_requests: obj[]
      [<field: DataMember(Name = "geo_ordered_rtc_regions")>]
      geo_ordered_rtc_regions: string[]
      [<field: DataMember(Name = "application")>]
      application: Application
      [<field: DataMember(Name = "_trace")>]
      _trace: string[] }




[<DataContract>]
type ReadyEvent = GatewayEvent<ReadyData>



[<DataContract>]
type GuildMembersData =
    { [<field: DataMember(Name = "guild_id")>]
      guild_id: string

      [<field: DataMember(Name = "query")>]
      query: string option

      [<field: DataMember(Name = "limit")>]
      limit: int

      [<field: DataMember(Name = "presences")>]
      presences: bool option

      [<field: DataMember(Name = "user_ids")>]
      user_ids: string array option

      [<field: DataMember(Name = "nonce")>]
      nonce: string option }

[<DataContract>]
type GuildMembersEvent = GatewayEvent<GuildMembersData>


[<DataContract>]
type Channel =
    { [<field: DataMember(Name = "version")>]
      version: int64
      [<field: DataMember(Name = "type")>]
      type_: int
      [<field: DataMember(Name = "position")>]
      position: int
      [<field: DataMember(Name = "permission_overwrites")>]
      permission_overwrites: obj[]
      [<field: DataMember(Name = "name")>]
      name: string
      [<field: DataMember(Name = "id")>]
      id: string
      [<field: DataMember(Name = "flags")>]
      flags: int }



[<DataContract>]
type GuildMember =
    { [<field: DataMember(Name = "user")>]
      user: User
      [<field: DataMember(Name = "roles")>]
      roles: string[]
      [<field: DataMember(Name = "premium_since")>]
      premium_since: string
      [<field: DataMember(Name = "pending")>]
      pending: bool
      [<field: DataMember(Name = "nick")>]
      nick: string option
      [<field: DataMember(Name = "mute")>]
      mute: bool
      [<field: DataMember(Name = "joined_at")>]
      joined_at: string
      [<field: DataMember(Name = "flags")>]
      flags: int
      [<field: DataMember(Name = "deaf")>]
      deaf: bool
      [<field: DataMember(Name = "communication_disabled_until")>]
      communication_disabled_until: obj option
      [<field: DataMember(Name = "avatar")>]
      avatar: string option }

[<DataContract>]
type Role =
    { [<field: DataMember(Name = "version")>]
      version: int64
      [<field: DataMember(Name = "unicode_emoji")>]
      unicode_emoji: string option
      [<field: DataMember(Name = "tags")>]
      tags: obj
      [<field: DataMember(Name = "position")>]
      position: int
      [<field: DataMember(Name = "permissions")>]
      permissions: string
      [<field: DataMember(Name = "name")>]
      name: string
      [<field: DataMember(Name = "mentionable")>]
      mentionable: bool
      [<field: DataMember(Name = "managed")>]
      managed: bool
      [<field: DataMember(Name = "id")>]
      id: string
      [<field: DataMember(Name = "icon")>]
      icon: string option
      [<field: DataMember(Name = "hoist")>]
      hoist: bool
      [<field: DataMember(Name = "flags")>]
      flags: int
      [<field: DataMember(Name = "color")>]
      color: int }

[<DataContract>]
type ChannelMention =
    { [<field: DataMember(Name = "id")>]
      id: int64
      [<field: DataMember(Name = "guild_id")>]
      guild_id: int64
      [<field: DataMember(Name = "type")>]
      type_: int
      [<field: DataMember(Name = "name")>]
      name: string }

[<DataContract>]
type Attachment = {
      [<field: DataMember(Name = "id")>]
      id: int64
      [<field: DataMember(Name = "filename")>]
      filename: string
      [<field: DataMember(Name = "description")>]
      description: string option
      [<field: DataMember(Name = "content_type")>]
      content_type: string option
      [<field: DataMember(Name = "size")>]
      size: int
      [<field: DataMember(Name = "url")>]
      url: string
      [<field: DataMember(Name = "proxy_url")>]
      proxy_url: string
      [<field: DataMember(Name = "height")>]
      height: int option
      [<field: DataMember(Name = "width")>]
      width: int option
      [<field: DataMember(Name = "ephemeral")>]
      ephemeral: bool option
      [<field: DataMember(Name = "duration_secs")>]
      duration_secs: float option
      [<field: DataMember(Name = "waveform")>]
      waveform: string
    }

[<DataContract>]
type Message =
    { [<field: DataMember(Name = "id")>]
      id: int64
      [<field: DataMember(Name = "channel_id")>]
      channel_id: int64
      [<field: DataMember(Name = "author")>]
      author: User
      [<field: DataMember(Name = "content")>]
      content: string
      [<field: DataMember(Name = "timestamp")>]
      timestamp: DateTime
      [<field: DataMember(Name = "edited_timestamp")>]
      edited_timestamp: DateTime option
      [<field: DataMember(Name = "tts")>]
      tts: bool
      [<field: DataMember(Name = "mention_everyone")>]
      mention_everyone: bool
      [<field: DataMember(Name = "mentions")>]
      mentions: User[]
      [<field: DataMember(Name = "mention_roles")>]
      mention_roles: Role[]
      [<field: DataMember(Name = "mention_channels")>]
      mention_channels: ChannelMention[] option
      [<field: DataMember(Name = "attachments")>]
      attachments: Attachment[]
    }

[<DataContract>]
type GuildData =
    { [<field: DataMember(Name = "stickers")>]
      stickers: obj[]
      [<field: DataMember(Name = "hub_type")>]
      hub_type: string option
      [<field: DataMember(Name = "max_video_channel_users")>]
      max_video_channel_users: int
      [<field: DataMember(Name = "latest_onboarding_question_id")>]
      latest_onboarding_question_id: string option
      [<field: DataMember(Name = "channels")>]
      channels: Channel[]
      [<field: DataMember(Name = "features")>]
      features: string[]
      [<field: DataMember(Name = "emojis")>]
      emojis: obj[]
      [<field: DataMember(Name = "embedded_activities")>]
      embedded_activities: obj[]
      [<field: DataMember(Name = "application_command_counts")>]
      application_command_counts: obj
      [<field: DataMember(Name = "joined_at")>]
      joined_at: string
      [<field: DataMember(Name = "vanity_url_code")>]
      vanity_url_code: string option
      [<field: DataMember(Name = "default_message_notifications")>]
      default_message_notifications: int
      [<field: DataMember(Name = "stage_instances")>]
      stage_instances: obj[]
      [<field: DataMember(Name = "description")>]
      description: string option
      [<field: DataMember(Name = "nsfw")>]
      nsfw: bool
      [<field: DataMember(Name = "member_count")>]
      member_count: int
      [<field: DataMember(Name = "id")>]
      id: string
      [<field: DataMember(Name = "guild_hashes")>]
      guild_hashes: obj
      [<field: DataMember(Name = "application_id")>]
      application_id: string option
      [<field: DataMember(Name = "presences")>]
      presences: obj[]
      [<field: DataMember(Name = "unavailable")>]
      unavailable: bool
      [<field: DataMember(Name = "splash")>]
      splash: string option
      [<field: DataMember(Name = "premium_progress_bar_enabled")>]
      premium_progress_bar_enabled: bool
      [<field: DataMember(Name = "incidents_data")>]
      incidents_data: obj option
      [<field: DataMember(Name = "max_members")>]
      max_members: int
      [<field: DataMember(Name = "home_header")>]
      home_header: obj option
      [<field: DataMember(Name = "threads")>]
      threads: obj[]
      [<field: DataMember(Name = "max_stage_video_channel_users")>]
      max_stage_video_channel_users: int
      [<field: DataMember(Name = "premium_tier")>]
      premium_tier: int
      [<field: DataMember(Name = "premium_subscription_count")>]
      premium_subscription_count: int
      [<field: DataMember(Name = "system_channel_id")>]
      system_channel_id: string option
      [<field: DataMember(Name = "afk_channel_id")>]
      afk_channel_id: string option
      [<field: DataMember(Name = "members")>]
      members: GuildMember[]
      [<field: DataMember(Name = "lazy")>]
      _lazy: bool
      [<field: DataMember(Name = "nsfw_level")>]
      nsfw_level: int
      [<field: DataMember(Name = "large")>]
      large: bool
      [<field: DataMember(Name = "rules_channel_id")>]
      rules_channel_id: string option
      [<field: DataMember(Name = "system_channel_flags")>]
      system_channel_flags: int
      [<field: DataMember(Name = "banner")>]
      banner: string option
      [<field: DataMember(Name = "verification_level")>]
      verification_level: int
      [<field: DataMember(Name = "public_updates_channel_id")>]
      public_updates_channel_id: string option
      [<field: DataMember(Name = "afk_timeout")>]
      afk_timeout: int
      [<field: DataMember(Name = "roles")>]
      roles: Role[]
      [<field: DataMember(Name = "voice_states")>]
      voice_states: obj[]
      [<field: DataMember(Name = "explicit_content_filter")>]
      explicit_content_filter: int
      [<field: DataMember(Name = "discovery_splash")>]
      discovery_splash: string option
      [<field: DataMember(Name = "name")>]
      name: string
      [<field: DataMember(Name = "region")>]
      region: string
      [<field: DataMember(Name = "icon")>]
      icon: string option
      [<field: DataMember(Name = "owner_id")>]
      owner_id: string
      [<field: DataMember(Name = "preferred_locale")>]
      preferred_locale: string
      [<field: DataMember(Name = "safety_alerts_channel_id")>]
      safety_alerts_channel_id: string option
      [<field: DataMember(Name = "guild_scheduled_events")>]
      guild_scheduled_events: obj[]
      [<field: DataMember(Name = "mfa_level")>]
      mfa_level: int }

[<DataContract>]
type GuildCreateEvent = GatewayEvent<GuildData>
