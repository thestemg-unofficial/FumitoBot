namespace Discord.Types.Channel

open Newtonsoft.Json

open Discord.Types.User

open System

type Channel =
    { version: int64
      [<JsonProperty("type")>]
      _type: int
      position: int
      permission_overwrites: obj[]
      name: string
      id: string
      flags: int }

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
