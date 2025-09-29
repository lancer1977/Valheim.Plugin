using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.AddNoise
{
    internal class AddNoise : PolyRconCommand
    {
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < Metadata.MinimumParameters)
                return Metadata.Usage;

            var noiseName = args.GetString(1);
            var pos = args.GetVector3(2);
            ZRoutedRpc.instance.InvokeRoutedRPC(player.ZDOID, Metadata.RCPCall, noiseName, pos);
            return $"Played noise '{noiseName}' at {player.Name}";
        }

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
        public override string Method => Metadata.RCPCall;
    }
}