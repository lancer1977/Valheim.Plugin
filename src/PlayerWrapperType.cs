using UnityEngine;
using ValheimRcon;

namespace PolyhydraGames.Valheim.Plugin
{

    public record PlayerWrapperType(ZNetPeer Peer, ZDO Zdo)
    {
        public void PeerInvoke(string method, params object[] args)
        {
            RPC.Invoke(method, args);            
        }

        // --- From Peer ---
        public ZRpc RPC => Peer.m_rpc;                       // Their RPC channel 
        public long ZDOID => Peer.m_uid;                       // The ZDOID of this peer
        public string Name => Peer.m_playerName;           // Player’s in-game name
        public ZDOID PlayerId => Peer.m_characterID;            // Unique player ZDOID
        public string Info => Peer.GetPlayerInfo();           // Usually "Name (SteamID)"
        public Vector3 RefPosition => Peer.GetRefPos();            // Last known ref position
        public string SocketEndpoint => Peer.m_socket?.GetEndPointString(); // IP/port as string 
        // --- From ZDO ---
        public ZDOID ZdoUid => Zdo.m_uid;                    // Unique object ID
        public Vector3 WorldPosition => Zdo.GetPosition();         // World position
        public Quaternion Rotation => Zdo.GetRotation();      // Orientation
        public long UnderlyingUid => Zdo.GetLong(ZDOVars.s_playerID); // Internal UID

        public long Owner => Zdo.GetOwner();
        // --- Helpers ---
        public override string ToString()
        {
            return $"{Name} [{ZDOID}] at {RefPosition}";
        }
    }
}
