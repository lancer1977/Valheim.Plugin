using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands
{
    internal class StartRandomRaid : RconCommand
    {
        public override string Command => "startraid";
        public override string Description => "Start a random raid from eligible events.";

        protected override string OnHandle(CommandArgs args)
        {
            RandEventSystem.instance.ConsoleStartRandomEvent();
            return "Random raid triggered.";
        }
    }
}