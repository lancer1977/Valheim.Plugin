using System.Linq;

namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class WorldHelpers
    {
        public static string GetPlayerInfo()
        {
            var items = Player.GetAllPlayers().Select(x => x.GetPlayerID() + " - " + x.GetPlayerName()).ToArray();
            return string.Join("\n", items);
        }
    }
}