namespace PolyhydraGames.Valheim.Plugin.AddEffect
{
    public static class Metadata
    {
        public const string Guid = "com.polyhydragames.effectrcon";
        public const string Name = "Effect RCon Bridge";
        public const string Version = "1.0.0";
        public const string RCPCall = "ApplyStatusEffect";
        public const string Command = "addeffect";
        public const string Description = "Adds a status to the player. Usage: addstatus <player> <statusName>";
        public const string Usage = "Usage: addstatus <player> <statusName>";
        public const int MinimumParameters = 2;
        /// <summary>
        /// Called from server (via RCon or internal event).
        /// </summary>
        public static void ApplyEffectToPlayer(ZNetPeer peer, string effectName)
        {
            var pkg = new ZPackage();
            pkg.Write(effectName);

            // send directly to peer's socket
            peer.m_rpc.Invoke(RCPCall, new object[] { pkg });
        }
    }
}
