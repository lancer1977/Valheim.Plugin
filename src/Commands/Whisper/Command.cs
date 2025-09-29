using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin.Models;
using System.Linq;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.Whisper
{
    internal class Whisper : PolyRconCommand
    {

        public override string Command => Metadata.Command;
        public override string Description => Metadata.Description;
        public override string Method => Metadata.RCPCall;

        private string ProcessCommand(PlayerWrapperType player, CommandArgs args)
        {
            var name = args.GetString(1);
            var message = args.GetRemainingString(2);
            InvokeRouted(player, name,message);
            return $"Applied {Metadata.RCPCall} to {player.Name}";
        }

        protected override string OnHandle(PlayerWrapperType player, CommandArgs args) =>
            args.Arguments.Count < Metadata.MinimumParameters ? Metadata.Usage : ProcessCommand(player, args);


    }
}
