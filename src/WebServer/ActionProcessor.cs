 
namespace PolyhydraGames.Valheim.Plugin.WebServer
{
    public static class ActionProcessor
    {
        public static ValheimAction ResetKeys => ValheimAction.Create("resetkeys", type =>
        {
            ZoneSystem.instance.ResetGlobalKeys();
            return "Global keys reset via REST";
        }, "Resets all the bosses");

        public static ValheimAction Say => ValheimAction.Create("say", type =>
        {
            ZoneSystem.instance.ResetGlobalKeys();
            return "Global keys reset via REST";
        }, "Resets all the bosses");


    }
}