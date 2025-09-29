using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.Broke_Commands
{
    internal class SetWind : RconCommand
    {
        public override string Command => "setwind";
        public override string Description => "Set wind. Usage: setwind <angle> <intensity>";
        protected override string OnHandle(CommandArgs args)
        {
            if (args.Arguments.Count < 2) return "Usage: setwind <angle> <intensity>";
            if (!float.TryParse(args.GetString(0), out var angle) || !float.TryParse(args.GetString(1), out var intensity))
                return "Invalid numbers";
            EnvMan.instance?.SetDebugWind(angle, intensity);
            ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.Everybody, "RPC_SetDebugWind", angle, intensity);
            return $"Wind forced: {angle}°, {intensity}";
        }
    }
}