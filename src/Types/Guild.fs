namespace Discord.Types.Guild

open Newtonsoft.Json

open Discord.Types.User
open Discord.Types.Channel

type GuildMembersData =
    { guild_id: string
      query: string option
      limit: int
      presences: bool option
      user_ids: string array option
      nonce: string option }

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

type Guild = { unavailable: bool; id: string }

type Activity =
    { name: string
      [<JsonProperty("type")>]
      _type: int }


type Presence =
    { activities: Activity list
      status: string
      since: int
      afk: bool }
