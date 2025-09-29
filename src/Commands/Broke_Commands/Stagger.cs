using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.Broke_Commands
{ //stagger 76561197962914477
    internal class Stagger : PolyRconCommand
    {
        public override string Command => "stagger";
        public override string Description => "stagger the player. Usage: stagger <player>";
        public override string Method => RpcCommand.Stagger.GetRpcCommandName();

        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return Description;
            InvokeRouted(player, player.RefPosition with { x = player.RefPosition.x + 1 });
            return $"Staggered {player.Name}";
        }

    }
}