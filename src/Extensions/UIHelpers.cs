namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class UIHelpers
    {
        public static void ShowPopup(MessageHud.MessageType msgType, string message)
        {
            MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, message);
        }

    }
}