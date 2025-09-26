using System.Linq;
using PolyhydraGames.Valheim.Plugin.Models;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands
{
    internal class Whisper : PolyRconCommand
    {
        public override string Command => "whisper";
        public override string Description => "Sends a message to a specific user. Usage: whisper <longId> <message>";
 
        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (args.Arguments.Count < 2)
                return "Usage: whisper <longId> <message>";


            var message = string.Join(" ", args.Arguments.Skip(1)); // Everything else is message
            var senderId = player.PlayerId;                // your UID
            var pos = player.RefPosition;                           // position, usually player’s pos
            var type = (int)Talker.Type.Whisper;                                         // 2 = whisper
            var senderName = "Server";       // your name


            ZRoutedRpc.instance.InvokeRoutedRPC(player.ZDOID,
                "ChatMessage",
                pos,
                (int)Talker.Type.Whisper,
                ServerUserInfo,
                message);

                //player.PeerInvoke("ChatMessage", senderId, pos, type, senderName, message);
            //player.WorldInvoke("ChatMessage", senderId, pos, type, senderName, message);
            return "Sent message to " + player.Name;
        }
    }
}
