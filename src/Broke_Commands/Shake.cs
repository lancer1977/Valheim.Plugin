using PolyhydraGames.Valheim.RconExtensions.Commands;
using PolyhydraGames.Valheim.RconExtensions.Extensions;
using PolyhydraGames.Valheim.RconExtensions.Models;
using System;
using ValheimRcon.Commands;
using static Attack;

namespace PolyhydraGames.Valheim.Plugin.Broke_Commands
{
    //shake 76561197962914477
    internal class Shake : PolyRconCommand
    {
        private Player player;
        public override string Command => "shake";

        public override string Description => "Shake the player. Usage: shake <player>";


        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return "Usage: shake <player> <force>";
            var force = args.GetFloat(2); 
            player.InvokeRoutedRpcOnSelf(RpcCommand.Shake, player.RefPosition, force);

            return $"Shook {player.Name}";
        }
    }
}
