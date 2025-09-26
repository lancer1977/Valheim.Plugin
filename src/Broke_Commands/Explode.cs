using PolyhydraGames.Valheim.Plugin.Commands;
using PolyhydraGames.Valheim.Plugin.Models;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Broke_Commands
{
    internal class Explode : PolyRconCommand
    {
        public override string Command => "explode";
        public override string Description => "Explode a player. Usage: explode <player>";

        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 1) return "Usage: explode <player>";
            Object.Instantiate(ZNetScene.instance.GetPrefab("vfx_explosion"), player.RefPosition, Quaternion.identity);
            return $"Boom! Exploded {player.Name}.";
        }
    }


}