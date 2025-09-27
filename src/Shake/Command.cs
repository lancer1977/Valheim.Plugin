using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Shake
{
    internal class Shake : PolyRconCommand
    {
        private string ProcessCommand(PlayerWrapperType player, CommandArgs args)
        {
            var strength = args.GetString(1);
            InvokeRouted(player, strength);
            return $"Applied shake {strength} to {player.Name}";
        }
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)=>
            args.Arguments.Count < Metadata.MinimumParameters ? Metadata.Usage : ProcessCommand(player, args);
        

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
        public override string Method => Metadata.RCPCall;
    }
}