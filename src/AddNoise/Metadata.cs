using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.AddNoise
{
    public static class Metadata
    {
        public const string Guid = "com.polyhydragames.addnoisercon";
        public const string Name = "AddNoise RCon Bridge";
        public const string Version = "1.0.0";
        public const string RCPCall = "AddNoise";
        public const string Command = "addnoise";
        public const string Description = "Plays a noise in the vicinity of the player.";
        public const string Usage = "Usage: addnoise <player> <noiseName> <position>";
        public const int MinimumParameters = 2;
        /// <summary>
        /// Called from server (via RCon or internal event).
        /// </summary>
        public static void ApplyEffectToPlayer(ZNetPeer peer, string noiseName, Vector3 position)
        {
            peer.m_rpc.Invoke(RCPCall, noiseName, position);
        }
    }
}
