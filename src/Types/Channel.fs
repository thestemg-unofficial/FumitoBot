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

type EmbedFooter =
    { text: string
      icon_url: string option
      proxy_icon_url: string option }

type EmbedThumbnail = {
    url: string
    proxy_url: string option
    height: int option
    width: int option
    }

type Embed =
    { title: string option
      [<JsonProperty("type")>]
      type_: string option
      description: string option
      url: string option
      timestamp: DateTime option
      color: Nullable<int>
      thumbnail: EmbedThumbnail option
      footer: EmbedFooter option }

type Emoji =
    { id: string option
      name: string option
      roles: Role[]
      user: User option
      require_colons: bool option
      managed: bool option
      animated: bool option
      available: bool option }

type Reaction = { count: int; me: bool; emoji: Emoji }

type MessageActivity =
    { [<JsonProperty("type")>]
      type_: int
      party_id: string option }

type MessageReference =
    { message_id: string option
      channel_id: string option
      guild_id: string option
      fail_if_not_exists: bool option }

type MessageInteraction =
    { id: string
      [<JsonProperty("type")>]
      type_: int
      name: string
      user: User
      [<JsonProperty("type")>]
      member_: GuildMember option }

type Component =
    { [<JsonProperty("type")>]
      type_: int
      components: Component[] }

type MessageForm = {
    content: string
    }

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
      attachments: Attachment[]
      embeds: Embed[]
      reactions: Reaction[]
      nonce: Choice<int, string> option
      pinned: bool
      webhook_id: string option
      [<JsonProperty("type")>]
      type_: int
      activity: MessageActivity option
      application: ApplicationId option
      application_id: string option
      message_reference: MessageReference option
      flags: Nullable<int>
      referenced_message: Message option
      interaction: MessageInteraction option
      components: Component[]
    }
