using System.Linq;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Broke_Commands
{
    internal class SetWeather : RconCommand
    {
        public override string Command => "setweather";
        public override string Description => "Forces the environment/weather. Usage: setweather <name>";
        private string Usage()
        {
            var all = string.Join(", ", Helpers.GetEnvironmentNames());
            return $"Usage: setweather <envName> ({all})";
        }
        protected override string OnHandle(CommandArgs args)
        {
            if (EnvMan.instance == null)
                return "EnvMan not initialized";

            if (args.Arguments.Count < 1)
            {
                return Usage();
            }

            var envName = args.GetString(0);
            var names = Helpers.GetEnvironmentNames();
            if (names.All(x => x != envName))
            {
                return Usage();
            }
            // Force environment on server (affects spawns, biome checks)
            EnvMan.instance.SetForceEnvironment(envName);

            // Tell all clients to update their weather
            ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.Everybody, "RPC_SetEnvironment", envName, 0f);

            return $"Forced environment set to {envName}";
        }
    }

}
