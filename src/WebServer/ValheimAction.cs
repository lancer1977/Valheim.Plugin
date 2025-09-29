using System; 
using PolyhydraGames.Valheim.Plugin.Models;

namespace PolyhydraGames.Valheim.Plugin.WebServer
{
    public class ValheimAction
    {
        public Func<CommandRequestType, string> OnRequest { get; init; }
        public string Command { get; init; }
        public string Description { get; init; }
        public static ValheimAction Create(string command, Func<CommandRequestType, string> act, string description = "")
        {
            return new ValheimAction()
            {
                OnRequest = act, Command = command, Description = description
            };
        }
    }
}