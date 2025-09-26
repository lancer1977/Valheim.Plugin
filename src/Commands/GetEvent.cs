using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.RconExtensions.Commands
{
    internal class GetEvent : RconCommand
    {
        public override string Command => "getevent";
        public override string Description => "Get current active/random raid event.";

        protected override string OnHandle(CommandArgs args)
        {
            var active = RandEventSystem.instance.GetActiveEvent();
            var current = RandEventSystem.instance.GetCurrentRandomEvent();
            if (active == null && current == null) return "No active raid.";
            return $"Active: {active?.m_name ?? "none"} | Random: {current?.m_name ?? "none"}";
        }
    }
}