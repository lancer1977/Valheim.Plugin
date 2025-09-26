using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Broke_Commands
{
    internal class ResetWind : RconCommand
    {
        public override string Command => "resetwind";
        public override string Description => "Reset wind to normal.";
        protected override string OnHandle(CommandArgs args)
        {
            EnvMan.instance?.ResetDebugWind();
            return "Wind reset.";
        }
    }
}