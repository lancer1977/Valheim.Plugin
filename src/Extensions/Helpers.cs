using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PolyhydraGames.Valheim.RconExtensions.Extensions;

using System;
using System.Collections.Generic;
using UnityEngine;

public enum RpcCommand
{
    SetGuardianPower,
    UseGuardianPower,
    // Core networking / admin
    PeerInfo,              // (ZRpc rpc, ZPackage pkg)
    NetTime,               // (ZRpc rpc, ZPackage pkg)
    ServerHandshake,       // (ZRpc rpc, ZPackage pkg)
    ClientHandshake,       // (ZRpc rpc, ZPackage pkg)
    ServerSyncedPlayerData,// (ZRpc rpc, ZPackage pkg)
    Disconnect,            // (ZRpc rpc)
    Error,                 // (ZRpc rpc, int code)
    Kick,                  // (long uid)
    Kicked,                // ()
    Ban,                   // (string name, long uid)
    Unban,                 // (string name)
    AdminList,             // (ZPackage pkg)
    Save,                  // ()
    SavePlayerProfile,     // (ZDOID characterID, ZPackage pkg)
    PlayerList,            // (ZPackage pkg)
    PrintBanned,           // ()
    RemoteCommand,         // (string command)
    RemotePrint,           // (string message)

    // World & ZDO
    SpawnObject,           // (ZDOID objID, int prefab, Vector3 pos, Quaternion rot)
    DestroyZDO,            // (ZDOID id)
    RequestZDO,            // (ZDOID id)
    ZDOData,               // (ZDOID id, ZPackage pkg)
    RoutedRPC,             // (ZDOID target, int methodHash, ZPackage pkg)
    SetTrigger,            // (string triggerName)

    // Player
    Heal,                  // (float health, bool showText)
    Damage,                // (HitData hit)
    Stagger,               // ()
    UseStamina,            // (float v)
    OnDeath,               // ()
    OnTargeted,            // (bool enable)
    FlashShield,           // ()
    AddStatusEffect,       // (string name, bool add)
    Controls,              // (ZDOID controlledObject)
    ReleaseControl,        // ()
    RequestControl,        // (ZDOID id)
    RequestRespons,        // (ZDOID id, bool granted)

    // Chat / comms
    ChatMessage,           // (long senderID, Vector3 pos, int type, string text, string sender)
    TeleportPlayer,        // (Vector3 pos, Quaternion rot, bool distantTeleport)
    Say,                   // (string text)

    // Items / containers
    DropItem,              // (ZDOID item, Vector3 pos, int amount)
    DropItemByName,        // (string name, int amount)
    RequestOwn,            // (ZDOID id)
    SetPose,               // (int pose)
    SetVisualItem,         // (string name, int variant, int quality, int stack)
    OpenRespons,           // (bool granted)
    RequestStack,          // (ZDOID item)
    StackResponse,         // (bool ok)
    RequestOpen,           // (long playerID)
    RequestTakeAll,        // ()
    TakeAllRespons,        // (bool ok)
    AddFuel,               // (int amount)
    AddItem,               // (ZDOID item)
    RemoveDoneItem,        // (ZDOID item)
    SetSlotVisual,         // (int slot, string name)
    AddFuelAmount,         // (int amount)
    SetFuelAmount,         // (int amount)
    ToggleOn,              // (bool on)
    Pickup,                // (ZDOID id)
    RequestPickup,         // (ZDOID id)

    // Structures
    UseDoor,               // (bool open)
    Repair,                // ()
    Remove,                // ()
    HealthChanged,         // (float health)
    UpdateMaterial,        // (int index)
    SetAreaHealth,         // (float health)

    // Events / bosses
    SetEvent,              // (string name)
    BossSpawnInitiated,    // ()
    RemoveBossSpawnInventoryItems, // ()
    SpawnBoss,             // (Vector3 pos)

    // Creatures / AI
    SetTamed,              // (bool tamed)
    ResetCloth,            // ()
    FreezeFrame,           // ()
    OnHit,                 // (HitData hit)
    Attach,                // (ZDOID parent, Vector3 pos)
    TeleportTo,            // (Vector3 pos, Quaternion rot, bool distant)
    StaggerCreature,       // ()
    OnEat,                 // (string foodName)
    TryEat,                // (string foodName)
    EatConfirmation,       // (bool success)
    Nibble,                // ()
    Step,                  // ()
    Wakeup,                // ()
    Grow,                  // ()
    Shake,                 // ()
    Command,               // (string cmd)
    UnSummon,              // ()
    SetName,               // (string name)

    // Ships & saddles
    Forward,               // ()
    Backward,              // ()
    Rudder,                // (float value)
    Stop,                  // ()
    AddSaddle,             // (ZDOID saddle)
    RemoveSaddle,          // ()
    SetSaddle,             // (ZDOID saddle)
    RequestControlShip,    // (ZDOID shipID)
    ReleaseControlShip,    // (ZDOID shipID)

    // World keys / locations
    SetGlobalKey,          // (string key)
    RemoveGlobalKey,       // (string key)
    GlobalKeys,            // (ZPackage pkg)
    LocationIcons,         // (ZPackage pkg)
    AddNoise
}

public static class RpcCommandMap
{
    public static readonly Dictionary<RpcCommand, string> Names = new()
    {
        {
            RpcCommand.SetGuardianPower,"RPC_SetGuardianPower" },
        {RpcCommand.UseGuardianPower,"RPC_UseGuardianPower" },
        { RpcCommand.PeerInfo, "RPC_PeerInfo" },
        { RpcCommand.NetTime, "RPC_NetTime" },
        { RpcCommand.ServerHandshake, "RPC_ServerHandshake" },
        { RpcCommand.ClientHandshake, "RPC_ClientHandshake" },
        { RpcCommand.ServerSyncedPlayerData, "RPC_ServerSyncedPlayerData" },
        { RpcCommand.Disconnect, "RPC_Disconnect" },
        { RpcCommand.Error, "RPC_Error" },
        { RpcCommand.Kick, "RPC_Kick" },
        { RpcCommand.Kicked, "RPC_Kicked" },
        { RpcCommand.Ban, "RPC_Ban" },
        { RpcCommand.Unban, "RPC_Unban" },
        { RpcCommand.AdminList, "RPC_AdminList" },
        { RpcCommand.Save, "RPC_Save" },
        { RpcCommand.SavePlayerProfile, "RPC_SavePlayerProfile" },
        { RpcCommand.PlayerList, "RPC_PlayerList" },
        { RpcCommand.PrintBanned, "RPC_PrintBanned" },
        { RpcCommand.RemoteCommand, "RPC_RemoteCommand" },
        { RpcCommand.RemotePrint, "RPC_RemotePrint" },

        { RpcCommand.SpawnObject, "RPC_SpawnObject" },
        { RpcCommand.DestroyZDO, "RPC_DestroyZDO" },
        { RpcCommand.RequestZDO, "RPC_RequestZDO" },
        { RpcCommand.ZDOData, "RPC_ZDOData" },
        { RpcCommand.RoutedRPC, "RPC_RoutedRPC" },
        { RpcCommand.SetTrigger, "RPC_SetTrigger" },

        { RpcCommand.Heal, "RPC_Heal" },
        { RpcCommand.Damage, "RPC_Damage" },
        { RpcCommand.Stagger, "RPC_Stagger" },
        { RpcCommand.UseStamina, "RPC_UseStamina" },
        { RpcCommand.OnDeath, "RPC_OnDeath" },
        { RpcCommand.OnTargeted, "RPC_OnTargeted" },
        { RpcCommand.FlashShield, "RPC_FlashShield" },
        { RpcCommand.AddStatusEffect, "RPC_AddStatusEffect" },
        { RpcCommand.Controls, "RPC_Controls" },
        { RpcCommand.ReleaseControl, "RPC_ReleaseControl" },
        { RpcCommand.RequestControl, "RPC_RequestControl" },
        { RpcCommand.RequestRespons, "RPC_RequestRespons" },

        { RpcCommand.ChatMessage, "RPC_ChatMessage" },
        { RpcCommand.TeleportPlayer, "RPC_TeleportPlayer" },
        { RpcCommand.Say, "RPC_Say" },

        { RpcCommand.DropItem, "RPC_DropItem" },
        { RpcCommand.DropItemByName, "RPC_DropItemByName" },
        { RpcCommand.RequestOwn, "RPC_RequestOwn" },
        { RpcCommand.SetPose, "RPC_SetPose" },
        { RpcCommand.SetVisualItem, "RPC_SetVisualItem" },
        { RpcCommand.OpenRespons, "RPC_OpenRespons" },
        { RpcCommand.RequestStack, "RPC_RequestStack" },
        { RpcCommand.StackResponse, "RPC_StackResponse" },
        { RpcCommand.RequestOpen, "RPC_RequestOpen" },
        { RpcCommand.RequestTakeAll, "RPC_RequestTakeAll" },
        { RpcCommand.TakeAllRespons, "RPC_TakeAllRespons" },
        { RpcCommand.AddFuel, "RPC_AddFuel" },
        { RpcCommand.AddItem, "RPC_AddItem" },
        { RpcCommand.RemoveDoneItem, "RPC_RemoveDoneItem" },
        { RpcCommand.SetSlotVisual, "RPC_SetSlotVisual" },
        { RpcCommand.AddFuelAmount, "RPC_AddFuelAmount" },
        { RpcCommand.SetFuelAmount, "RPC_SetFuelAmount" },
        { RpcCommand.ToggleOn, "RPC_ToggleOn" },
        { RpcCommand.Pickup, "RPC_Pickup" },
        { RpcCommand.RequestPickup, "RPC_RequestPickup" },

        { RpcCommand.UseDoor, "RPC_UseDoor" },
        { RpcCommand.Repair, "RPC_Repair" },
        { RpcCommand.Remove, "RPC_Remove" },
        { RpcCommand.HealthChanged, "RPC_HealthChanged" },
        { RpcCommand.UpdateMaterial, "RPC_UpdateMaterial" },
        { RpcCommand.SetAreaHealth, "RPC_SetAreaHealth" },

        { RpcCommand.SetEvent, "RPC_SetEvent" },
        { RpcCommand.BossSpawnInitiated, "RPC_BossSpawnInitiated" },
        { RpcCommand.RemoveBossSpawnInventoryItems, "RPC_RemoveBossSpawnInventoryItems" },
        { RpcCommand.SpawnBoss, "RPC_SpawnBoss" },

        { RpcCommand.SetTamed, "RPC_SetTamed" },
        { RpcCommand.ResetCloth, "RPC_ResetCloth" },
        { RpcCommand.FreezeFrame, "RPC_FreezeFrame" },
        { RpcCommand.OnHit, "RPC_OnHit" },
        { RpcCommand.Attach, "RPC_Attach" },
        { RpcCommand.TeleportTo, "RPC_TeleportTo" },
        { RpcCommand.StaggerCreature, "RPC_Stagger" },
        { RpcCommand.OnEat, "RPC_OnEat" },
        { RpcCommand.TryEat, "RPC_TryEat" },
        { RpcCommand.EatConfirmation, "RPC_EatConfirmation" },
        { RpcCommand.Nibble, "RPC_Nibble" },
        { RpcCommand.Step, "RPC_Step" },
        { RpcCommand.Wakeup, "RPC_Wakeup" },
        { RpcCommand.Grow, "RPC_Grow" },
        { RpcCommand.Shake, "RPC_Shake" },
        { RpcCommand.Command, "RPC_Command" },
        { RpcCommand.UnSummon, "RPC_UnSummon" },
        { RpcCommand.SetName, "RPC_SetName" },

        { RpcCommand.Forward, "RPC_Forward" },
        { RpcCommand.Backward, "RPC_Backward" },
        { RpcCommand.Rudder, "RPC_Rudder" },
        { RpcCommand.Stop, "RPC_Stop" },
        { RpcCommand.AddSaddle, "RPC_AddSaddle" },
        { RpcCommand.RemoveSaddle, "RPC_RemoveSaddle" },
        { RpcCommand.SetSaddle, "RPC_SetSaddle" },
        { RpcCommand.RequestControlShip, "RPC_RequestControl" },
        { RpcCommand.ReleaseControlShip, "RPC_ReleaseControl" },

        { RpcCommand.SetGlobalKey, "RPC_SetGlobalKey" },
        { RpcCommand.RemoveGlobalKey, "RPC_RemoveGlobalKey" },
        { RpcCommand.GlobalKeys, "RPC_GlobalKeys" },
        { RpcCommand.LocationIcons, "RPC_LocationIcons" },
        { RpcCommand.AddNoise, "RPC_AddNoise" }
    };
}


public static class Helpers
{
    public static string GetRpcCommandName(this RpcCommand command)
    {
        return RpcCommandMap.Names.TryGetValue(command, out var name) ? name : "RPC_Unknown";
    }


    public static List<string> GetFunctions()
    {
        ZLog.Log($"Log RPC Functions:");
        var names = new List<string>();
        foreach (var kvp in ZRoutedRpc.instance.m_functions)
        {
            ZLog.Log($"RPC: {kvp.Key}");
            names.Add(kvp.Value.ToString());
        }

        return names;
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

    public static class Strings
    {
        public static string[] Statuses =>
        [
            "Rested",
                "Poison",
                "Burning",
                "Wet",
                "Cold",
                "SoftDeath"
        ];
    }

}
