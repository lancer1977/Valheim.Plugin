 
namespace PolyhydraGames.Valheim.Plugin.WebServer
{
    public static class ActionProcessor
    {
        public static ValheimAction ResetKeys => ValheimAction.Create("resetkeys", type =>
        {
            ZoneSystem.instance.ResetGlobalKeys();
            return ResponseHelpers.Create(type, "Global keys reset via REST");
        }, "Resets all the bosses");

        public static ValheimAction Say => ValheimAction.Create("say", act =>
        {
            Chat.instance.SendText(Talker.Type.Shout, act.Message);
            return ResponseHelpers.Create(act, "Global keys reset via REST"); 
        }, "Shouts to everyone");

        public static void RegisterActions()
        {
            ActionManager.Instance.AddAction(ResetKeys);
            ActionManager.Instance.AddAction(Say);
        }
    }
}