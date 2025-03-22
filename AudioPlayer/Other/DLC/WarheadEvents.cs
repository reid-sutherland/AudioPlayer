using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;
using System.Collections.Generic;
using static AudioPlayer.Plugin;

namespace AudioPlayer.Other.DLC;

internal class WarheadEvents
{
    private static AudioFile currentAudioFile = null;
    public WarheadEvents()
    {
        Exiled.Events.Handlers.Warhead.Starting += OnWarheadStarting;
        Exiled.Events.Handlers.Warhead.Stopping += OnWarheadStopping;
        Exiled.Events.Handlers.Warhead.Detonated += OnWarheadDetonated;
    }

    public void OnWarheadStarting(StartingEventArgs ev)
    {
        if (!Warhead.CanBeStarted)
        {
            return;
        }

        WarheadSoundControl(plugin.Config.WarheadStartingClip, "WarheadStartingClip");
    }

    public void OnWarheadDetonated()
    {
        currentAudioFile?.Stop();
    }

    public void OnWarheadStopping(StoppingEventArgs ev)
    {
        if (plugin.Config.WarheadStopping)
        {
            currentAudioFile?.Stop();
        }

        WarheadSoundControl(plugin.Config.WarheadStoppingClip, "WarheadStoppingClip");
    }

    public static void WarheadSoundControl(List<AudioFile> audiolist, string audioClipsName)
    {
        currentAudioFile = Extensions.PlayRandomAudioFile(audiolist, audioClipsName);
    }
}
