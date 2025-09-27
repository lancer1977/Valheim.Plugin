using JetBrains.Annotations;
using Jotunn.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Extensions;

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
        return string.Join(
            "\n",
            items
        );
    }

    public static void ListPrefabs()
    {
        if (ZNetScene.instance == null)
        {
            ZLog.Log("ZNetScene not ready yet.");
            return;
        }

        var names = ZNetScene.instance.GetPrefabNames();
        foreach (var name in names)
        {
            ZLog.Log($"Prefab: {name}");
        }

        ZLog.Log($"Total prefabs: {names.Count}");
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
        foreach (var name in names)
        {
            ZLog.Log($"Environment: {name}");
        }

        ZLog.Log($"Total environments: {names.Count}");
        return names;
    }

    //ZRoutedRpc.instance.m_functions
    //public static List<string> GetEnvironmentNames()
    //{
    //    List<string> items = null;
    //    if (ZRoutedRpc.instance == null)
    //    {
    //        Debug.Log("ZNetScene not ready yet.");
    //        return items;
    //    }

    //    var names = ZRoutedRpc.instance. //m_functions.Select(e => e.m_name).ToList();
    //    foreach (var name in names)
    //    {
    //        Debug.Log($"Environment: {name}");
    //    }

    //    Debug.Log($"Total environments: {names.Count}");
    //    return names;
    //}


}