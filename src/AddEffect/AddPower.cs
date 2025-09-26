using System;
using System.Linq;
using PolyhydraGames.Valheim.RconExtensions.Commands;
using PolyhydraGames.Valheim.RconExtensions.Extensions;
using PolyhydraGames.Valheim.RconExtensions.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.AddEffect
{
    internal class AddPower : PolyRconCommand
    {
        public override string Command => "addpower";
        public override string Description => "Gives a guardian power to a player. Usage: addpower <player> <powerName>";

        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return "Usage: power <player> <Eikthyr|Bonemass|Moder|Yagluth>";

            var powerName = args.GetString(1);

            // Build status effect name (internal prefix is GP_)
            var internalName = $"GP_{powerName}";
            var status = ObjectDB.instance.m_StatusEffects
                .FirstOrDefault(se => se.name.Equals(internalName, StringComparison.OrdinalIgnoreCase));

            if (status == null)
                return $"Guardian power '{powerName}' not found.";

            // Invoke the RPC on the target player’s ZDO
            player.InvokeRoutedRpcOnWorld(RpcCommand.SetGuardianPower, status.name);
            player.InvokeRoutedRpcOnWorld(RpcCommand.UseGuardianPower);

            return $"Invoked guardian power '{status.name}' on {player.Name}";
        }
    }
}