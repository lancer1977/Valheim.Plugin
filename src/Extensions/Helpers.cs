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