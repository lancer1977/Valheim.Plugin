using PolyhydraGames.Valheim.RconExtensions.Extensions;
using PolyhydraGames.Valheim.RconExtensions.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.RconExtensions.Commands
{ //stagger 76561197962914477
    internal class Stagger : PolyRconCommand
    {
        public override string Command => "stagger";

        public override string Description => "stagger the player. Usage: stagger <player>";


        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return Description; 

            player.InvokeRoutedRpcOnSelf(RpcCommand.AddNoise, player.RefPosition with {x = player.RefPosition.x + 1});

            return $"Staggered {player.Name}";
        }
    }
}