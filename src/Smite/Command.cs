using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Smite;

internal class Smite : PolyRconCommand

{
    public override string Command => Metadata.Command;
    public override string Description => Metadata.Description;
    public override string Method => Metadata.RCPCall;

    protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
    {
        if (args.Arguments.Count < Metadata.MinimumParameters)
            return Metadata.Usage;

        var name = args.GetString(1);
        InvokeRouted(player, name);
        return $"Smote '{name}'";
    }
}
