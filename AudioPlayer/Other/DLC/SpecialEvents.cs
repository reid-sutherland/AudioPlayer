using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using static AudioPlayer.Plugin;

namespace AudioPlayer.Other.DLC;

internal class SpecialEvents
{
    public SpecialEvents()
    {
        Exiled.Events.Handlers.Player.Died += OnDied;
        Exiled.Events.Handlers.Player.Verified += OnVerified;

        Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
        Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;

        Exiled.Events.Handlers.Map.AnnouncingNtfEntrance += OnAnnouncingNtfEntrance;
    }

    public void OnRoundStarted()
    {
        Log.Debug("Round started - playing random round start clip");
        Log.Debug("Round start clips:");
        foreach (var clip in plugin.Config.RoundStartClip)
        {
            Log.Debug($"-- {clip.Path}");
        }
        Extensions.PlayRandomAudioFile(plugin.Config.RoundStartClip, "RoundStartClip");
    }

    public void OnRoundEnded(RoundEndedEventArgs ev) => Extensions.PlayRandomAudioFile(plugin.Config.RoundEndClip, "RoundEndClip");

    public void OnVerified(VerifiedEventArgs ev) => Extensions.PlayRandomAudioFileFromPlayer(plugin.Config.PlayerConnectedServer, ev.Player, "PlayerConnectedServer");

    public void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev) => ev.IsAllowed = plugin.Config.CassieMtfSpawn;

    public void OnDied(DiedEventArgs ev)
    {
        if (ev.Player == null || ev.Attacker == null || ev.DamageHandler.Type == Exiled.API.Enums.DamageType.Unknown) return;

        Extensions.PlayRandomAudioFileFromPlayer(plugin.Config.PlayerDiedTargetClip, ev.Player, "PlayerDiedTargetClip");
        Extensions.PlayRandomAudioFileFromPlayer(plugin.Config.PlayerDiedKillerClip, ev.Attacker, "PlayerDiedKillerClip");
    }

    public void OnRespawningTeam(RespawningTeamEventArgs ev)
    {
        Log.Debug($"Team is respawning: {ev.NextKnownTeam}");
        Log.Debug(ev.ToString());
        if (ev.NextKnownTeam == Faction.FoundationStaff)
        {
            Extensions.PlayRandomAudioFile(plugin.Config.MtfSpawnClip, "MtfSpawnClip");
        }
        else if (ev.NextKnownTeam == Faction.FoundationEnemy)
        {
            Extensions.PlayRandomAudioFile(plugin.Config.ChaosSpawnClip, "ChaosSpawnClip");
        }
    }
}
