using PolyhydraGames.Valheim.RconExtensions.Commands;
using PolyhydraGames.Valheim.RconExtensions.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.AddEffect
{
    internal class AddEffect : PolyRconCommand
    {
        private string ProcessCommand(PlayerWrapperType player, CommandArgs args)
        {

            var statusName = FirstArg(args);
            Metadata.ApplyEffectToPlayer(player.Peer, statusName);
            return $"Applied status '{statusName}' to {player.Name}";
        }
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < Metadata.MinimumParameters) return Metadata.Usage;
            return ProcessCommand(player, args);
        }

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
    }
}