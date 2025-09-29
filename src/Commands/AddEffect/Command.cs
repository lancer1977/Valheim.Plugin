using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.AddEffect
{
    internal class AddEffect : PolyRconCommand
    {
        private string ProcessCommand(PlayerWrapperType player, CommandArgs args)
        {
            var statusName = args.GetString(1);
            InvokeRouted(player,statusName);
            return $"Applied status '{statusName}' to {player.Name}";
        }
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < Metadata.MinimumParameters) return Metadata.Usage;
            return ProcessCommand(player, args);
        }

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
        public override string Method => Metadata.RCPCall;
    }
}