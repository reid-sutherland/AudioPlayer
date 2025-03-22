using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils.NonAllocLINQ;
using static AudioPlayer.Plugin;

namespace AudioPlayer.Other;
public static class Extensions
{
    internal static void CreateDirectory()
    {
        if (Directory.Exists(plugin.AudioPath))
        {
            Log.Debug($"Audio directory exists: {plugin.AudioPath}");
            return;
        }

        Directory.CreateDirectory(plugin.AudioPath);
        Log.Debug($"Created audio directory: {plugin.AudioPath}");
    }

    public static AudioFile EmptyClip;

    public static void LogError(string msg)
    {
        if (plugin.Config.Debug)
        {
            Log.Error(msg);
        }
        else
        {
            Log.Debug(msg);
        }
    }

    public static AudioFile GetRandomAudioClip(List<AudioFile> audioClips, string audioClipsName)
    {
        if (audioClips == null || audioClips.IsEmpty())
        {
            Log.Debug($"No clips found in: {audioClipsName}");
            return EmptyClip;
        }

        foreach (AudioFile audioFile in audioClips.Where(clip => !AudioPlayerList.ContainsKey(clip.BotId)).ToArray())
        {
            audioClips.Remove(audioFile);
            LogError($"Removed AudioClip from {audioClipsName} because AudioPlayerBot is not present on the server");
        }

        if (!audioClips.Any())
        {
            LogError($"I didn't find any available AudioClips in {audioClipsName}, maybe you didn't specify AudioPlayerBot in the config or didn't spawn an AudioPlayerBot");
            return EmptyClip;
        }

        return audioClips.RandomItem();
    }

    public static AudioFile PlayRandomAudioFile(List<AudioFile> audioClips, string audioClipsName = "")
    {
        AudioFile randomClip = GetRandomAudioClip(audioClips, audioClipsName);
        randomClip.Play();

        return randomClip;
    }

    public static AudioFile PlayRandomAudioFileFromPlayer(List<AudioFile> audioClips, Player player, string audioClipsName = "")
    {
        AudioFile randomClip = GetRandomAudioClip(audioClips, audioClipsName);
        randomClip.PlayFromFilePlayer([player.Id]);

        return randomClip;
    }

    public static string PathCheck(string path)
    {
        if (File.Exists(path))
        {
            Log.Debug("Absolute path given, found file");
            return path;
        }
        else if (File.Exists(Path.Combine(plugin.AudioPath, path)))
        {
            path = Path.Combine(plugin.AudioPath, path);
            Log.Debug("Relative path given, found file in audio folder");
            return path;
        }
        else
        {
            Log.Debug($"File was not found: {path}");
            return path;
        }
    }
}