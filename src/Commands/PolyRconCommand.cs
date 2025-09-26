using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin.Models;
using Splatform;
using ValheimRcon;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Commands
{
    public abstract class PolyRconCommand : RconCommand
    {
        public static readonly UserInfo ServerUserInfo = new UserInfo
        {
            Name = string.Empty,
            UserId = new PlatformUserID("Bot", 0, false),
        };

        protected override string OnHandle(CommandArgs args)
        {
            string str = args.GetString(0);
            ZNetPeer peer = ZNet.instance.GetPeerByHostName(str) ?? ZNet.instance.GetPeerByPlayerName(str);
            if (peer == null)
                return "Cannot find user " + str;
            ZDO zdo = peer.GetZDO();
            return zdo == null ? $"Cannot handle command for player {peer.GetPlayerInfo()}. ZDO not found" : this.OnHandle(PlayerWrapper.Create(peer), args);
        }

        protected abstract string OnHandle(PlayerWrapperType player, CommandArgs args);
        public static string FirstArg(CommandArgs args)
        {
            return args.GetString(1);
        }
    }
}