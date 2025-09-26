using PolyhydraGames.Valheim.Plugin.Models;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands;

internal class RaidCommand : PolyRconCommand
{
    public override string Command => "raid";
    public override string Description => "Start a raid. Usage: raid <eventName> [player]";

    protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
    {
        if (args.Arguments.Count < 1)
            return "Usage: raid [playerId] <eventName>";

        var eventName = FirstArg(args);
        var pos = player.RefPosition;

        if (!RandEventSystem.instance.HaveEvent(eventName))
            return $"No such event: {eventName}";

        RandEventSystem.instance.SetRandomEventByName(eventName, pos);
        return $"Raid started: {eventName} {(pos != Vector3.zero ? "at player" : "globally")}";
    }
}
