using System.Text;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.RconExtensions.Commands
{
    internal class ListEvents : RconCommand
    {
        public override string Command => "listevents";
        public override string Description => "List all available random events.";

        protected override string OnHandle(CommandArgs args)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Available events:");
            foreach (var ev in RandEventSystem.instance.m_events)
            {
                sb.AppendLine($"- {ev.m_name} (enabled={ev.m_enabled})");
            }
            return sb.ToString();
        }
    }
}