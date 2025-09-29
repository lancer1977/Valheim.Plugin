using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands.Broke_Commands
{
    internal class SkipMorning : RconCommand
    {
        public override string Command => "skipmorning";
        public override string Description => "Skips to next morning.";
        protected override string OnHandle(CommandArgs args)
        {
            EnvMan.instance?.SkipToMorning();
            return "Skipped to morning.";
        }
    }
}