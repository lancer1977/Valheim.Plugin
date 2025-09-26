using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands
{
    internal class StopRaid : RconCommand
    {
        public override string Command => "stopraid";
        public override string Description => "Stop the current raid/event.";

        protected override string OnHandle(CommandArgs args)
        {
            RandEventSystem.instance.ConsoleResetRandomEvent();
            return "Raid/event stopped.";
        }
    }

    
}