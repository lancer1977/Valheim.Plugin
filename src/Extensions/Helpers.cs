using UnityEngine;
using ValheimRcon;

namespace PolyhydraGames.Valheim.Plugin.Extensions;

using Models;

public static class PlayerWrapper
{
    public static Vector3 GetPosition(this Player player) => player.transform.position;
    public static PlayerWrapperType Create(ZNetPeer peer) => new PlayerWrapperType(peer, peer.GetZDO());
    public static void InvokeRoutedRpcOnWorld(this PlayerWrapperType player, RpcCommand rpc, params object[] args)
    {
        ZRoutedRpc.instance.InvokeRoutedRPC(player.Owner, rpc.GetRpcCommandName(), args);
    }

    public static void InvokeRoutedRpc(this PlayerWrapperType player, ZDOID target, RpcCommand rpc, params object[] args)
    {
        ZRoutedRpc.instance.InvokeRoutedRPC(player.Owner, target, rpc.GetRpcCommandName(), args);
    }

    public static void InvokeRoutedRpcOnSelf(this PlayerWrapperType player, RpcCommand rpc, params object[] args)
    {
        InvokeRoutedRpc(player, player.PlayerId, rpc, args);
    }

    public static ZDO GetZDO(this PlayerWrapperType player) => ZDOMan.instance.GetZDO(player.PlayerId);

    public static string GetSteamId(this PlayerWrapperType player) => player.RPC.GetSocket().GetHostName();

}