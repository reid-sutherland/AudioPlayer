﻿using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using AudioPlayer.Other;

namespace AudioPlayer;

public class Config : IConfig
{
    [Description("Plugin Enabled?")]
    public bool IsEnabled { get; set; } = true;

    [Description("Enable developer mode? (AudioPlayer debug)")]
    public bool Debug { get; set; } = false;
    [Description("Command to use AudioPlayer")]
    public string[] CommandName { get; private set; } = ["audio", "au"];
    [Description("Enable developer mode SCPSLAudioApi?")]
    public bool ScpslAudioApiDebug { get; private set; } = false;
    [Description("Create a bot automatically when the server starts?")]
    public bool SpawnBot { get; private set; } = false;

    [Description("The name of the bot when the file will sound. (Bot with ID 99 is better not to touch, he is responsible for commands on the server)")]
    public List<BotsList> BotsList { get; private set; } = new() { new BotsList() { BotName = "Dedicated Server", BotId = 99 } };

    [Description("Turn all special events on or off?")]
    public bool SpecialEventsEnable { get; private set; } = false;

    public List<AudioFile> LobbyPlaylist { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> PlayerConnectedServer { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> RoundStartClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> RoundEndClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    [Description("Play CASSIE when the MTF arrives?")]
    public bool CassieMtfSpawn { get; private set; } = true;

    public List<AudioFile> MtfSpawnClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> ChaosSpawnClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> PlayerDiedTargetClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> PlayerDiedKillerClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> WarheadStartingClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    [Description("Stop audio playback if the warhead has been disabled? (true = yes, false = no)")]
    public bool WarheadStopping { get; private set; } = false;

    public List<AudioFile> WarheadStoppingClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };

    public List<AudioFile> CandyTakenClip { get; private set; } = new()
    {
        new AudioFile()
        {
            Path = "/my/path/to/file.ogg",
            BotId = 100,
            Loop = false,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Intercom,
            Volume = 100,
        },
        new AudioFile()
        {
            Path = "/my/path/to/file1.ogg",
            BotId = 101,
            Loop = true,
            VoiceChatChannel = VoiceChat.VoiceChatChannel.Proximity,
            Volume = 100,
        },
    };
}
