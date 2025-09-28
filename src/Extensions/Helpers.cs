using JetBrains.Annotations; 
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Extensions;

using global::PolyhydraGames.Valheim.Plugin.Models;
 
    public static class PlayerWrapper
    {
        public static Vector3 GetPosition(this Player player) => player.transform.position;
        public static PlayerWrapperType Create(ZNetPeer peer) => new PlayerWrapperType(peer, peer.GetZDO());
        public static void InvokeRoutedRpcOnWorld(this PlayerWrapperType player, RpcCommand rpc, params object[] args)
        {
            ZRoutedRpc.instance.InvokeRoutedRPC(player.Owner, rpc.GetRpcCommandName(), args);
        }
        a

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
}
public static class Helpers
{
    public static void ShowPopup(MessageHud.MessageType msgType, string message)
    {
        MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, message);
    }

    [CanBeNull]
    public static StatusEffect GetEffect(string statusName)
    {
        var hash = statusName.GetStableHashCode();
        var statusEffect = ObjectDB.instance.GetStatusEffect(hash);
        if (statusEffect == null)
        {
            statusEffect = ObjectDB.instance.m_StatusEffects.FirstOrDefault(se => se.name.Equals(statusName, StringComparison.OrdinalIgnoreCase));
            if (statusEffect == null)
            {
                var message = "No effect found for " + statusName + "Effects: " + string.Join(", ", ObjectDB.instance.m_StatusEffects.Select(x => x.name));
                Jotunn.Logger.LogWarning(message);
            }
        }

        return statusEffect;
    }

    public static bool IsDedicatedServer()
    {
        var isDedicated = ZNet.instance && ZNet.instance.IsDedicated();
        Jotunn.Logger.LogInfo("[IsDedicated] " + isDedicated);
        return isDedicated;
    }

    public static string GetRpcCommandName(this RpcCommand command)
    {
        return RpcCommandMap.Names.TryGetValue(command, out var name) ? name : "RPC_Unknown";
    }

    public static string GetRemainingString(this CommandArgs args, int index)
    {
        return string.Join(" ", args.Arguments.Skip(index)); // Everything else is message
    }

    public static string GetPlayerInfo()
    {
        var items = Player.GetAllPlayers().Select(x => x.GetPlayerID() + " - " + x.GetPlayerName()).ToArray();
        return string.Join("\n", items);
    }

    public static List<string> GetItems()
     => ObjectDB.instance.m_items.OrderBy(x => x).Select(x => x.name).ToList();
    public static List<string> GetStatusEffects()
    => ObjectDB.instance.m_StatusEffects.OrderBy(x => x).Select(x => x.name).ToList();
    public static List<string> GetPrefabNames()
    { 
        var items = ZNetScene.instance.GetPrefabNames();
        return items;
    } 

    public static List<string> GetAllPlayerNames()
    {
        var items = Player.GetAllPlayers().Select(x => x.GetPlayerName()).ToList();
        return items;
    }

    public static string FormatStatusEffects()
    {
        var items = GetStatusEffects();
        var result = PrintItems(items, "StatusEffects");
        return result;
    }
    public static void ListPrefabs()
    {
        if (ZNetScene.instance == null)
        {
            ZLog.Log("ZNetScene not ready yet.");
            return;
        }

        PrintItems(GetPrefabNames(), "Prefab");

    }

    public static List<string> GetEnvironmentNames()
    {
        List<string> items = null;
        if (EnvMan.instance == null)
        {
            ZLog.Log("ZNetScene not ready yet.");
            return items;
        }
        var names = EnvMan.instance.m_environments.Select(e => e.m_name).ToList();
        PrintItems(names, "Environment");
        return names;
    }

    public static string PrintItems(IList<string> items, string name)
    {
        var result = string.Join("\", \"", items);
        ZLog.Log(name + ": " + result);

        ZLog.Log($"Total {name}s: {items.Count}");
        return result;
    }


}