using System.Collections.Generic;
using JetBrains.Annotations;
using PolyhydraGames.Valheim.Plugin.Models;

namespace PolyhydraGames.Valheim.Plugin.WebServer
{
    public class ActionManager
    {
        public PostResponse ProcessCommand(CommandRequestType request)
        {
            var action = GetAction(request.Command);
            if (action == null) return ResponseHelpers.Create(false, request, "Command {request.Command] was not found");
            return action.OnRequest(request);
        }
        public Dictionary<string, ValheimAction> Actions { get; } = new Dictionary<string, ValheimAction>();
        [CanBeNull] public ValheimAction GetAction(string commandName) => Actions.ContainsKey(commandName) ? Actions[commandName] : null;
        public bool AddAction(ValheimAction action)
        {
            if (Actions.ContainsKey(action.Command))
            {
                return false;

            }

            Actions[action.Command] = action;
            return true;
        }
        private static ActionManager _instance;
        private ActionManager()
        {

        }
        public static ActionManager Instance => _instance ??= new ActionManager();

    }
}