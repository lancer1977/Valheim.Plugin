using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.AddPower
{
    public static class Metadata
    {
        public const string Guid = "com.polyhydragames.AddPower";
        public const string Name = "AddPower RCon Bridge";
        public const string Version = "1.0.0";
        public const string RCPCall = "AddPower";
        public const string Command = "addpower";
        public const string Description = "Add Power a   player.";
        public const string Usage = "Usage: addpower <player> <powerName> ";
        public const int MinimumParameters = 2;
        /// <summary>
        /// Called from server (via RCon or internal event).
        /// </summary>
        public static void ApplyEffectToPlayer(ZNetPeer peer, string noiseName )
        {
            peer.m_rpc.Invoke(RCPCall, noiseName);
        }
    }
}
