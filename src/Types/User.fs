namespace Discord.Types.User

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

