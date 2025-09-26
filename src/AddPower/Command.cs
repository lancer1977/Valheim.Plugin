using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.AddPower
{
    internal class AddPower : PolyRconCommand
    {
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < Metadata.MinimumParameters)
                return Metadata.Usage;

            var name = args.GetString(1);
            Metadata.ApplyEffectToPlayer(player.Peer, name);
            return $"Applied status '{name}' to {player.Name}";
        }

        public override string Command => Valheim.Plugin.AddNoise.Metadata.Command;
        public override string Description => Valheim.Plugin.AddNoise.Metadata.Description;
    }
}