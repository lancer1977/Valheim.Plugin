using System.Linq;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class StringUtils
    {
        public static bool IsDedicatedServer()
        {
            var isDedicated = ZNet.instance && ZNet.instance.IsDedicated();
            Jotunn.Logger.LogInfo("[IsDedicated] " + isDedicated);
            return isDedicated;
        }

        public static string GetRpcCommandName(this RpcCommand command)
        {
            return RpcCommandMap.Names.TryGetValue(command, out var name) ? name : "RPC_Unknown";
        }

        public static string GetRemainingString(this CommandArgs args, int index)
        {
            return string.Join(" ", args.Arguments.Skip(index)); // Everything else is message
        }

        public static int GetStableHashCode(this string str)
        {
            unchecked
            {
                int hash = 5381;
                foreach (char c in str)
                    hash = (hash * 33) ^ c;
                return hash;
            }
        }
    }
}
