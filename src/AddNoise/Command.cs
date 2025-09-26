using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.AddNoise
{
    internal class AddNoise : PolyRconCommand
    {
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < Metadata.MinimumParameters)
                return Metadata.Usage;

            var noiseName = args.GetString(0);
            var pos = args.GetVector3(1);
            Metadata.ApplyEffectToPlayer(player.Peer, noiseName, pos);
            return $"Applied status '{noiseName}' to {player.Name}";
        }

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
    }
}