
using System;
using HarmonyLib;
using UnityEngine;
using Logger = Jotunn.Logger;
namespace PolyhydraGames.Valheim.Plugin.Smite;
[HarmonyPatch(typeof(Game))]
public static class SmiteRPC
{
    [HarmonyPostfix]
    [HarmonyPatch("Start")]
    private static void RegisterRpc()
    {
        Logger.LogInfo("Registered " + nameof(SmiteRPC));

        ZRoutedRpc.instance.Register(Metadata.RCPCall, SmiteAction);
    }
    private static void SmiteAction(long _)
    {
        Logger.LogInfo($"Received request to {Metadata.RCPCall}");

        // Use the global scene to spawn prefabs
        var zns = ZNetScene.instance;
        if (zns == null)
        {
            Logger.LogWarning("No ZNetScene available yet!");
            return;
        }

        var pos = Player.m_localPlayer.transform.position;
        var candidates = new[]
        {
                "lightningAOE",
                "vfx_lightning_hit",
                "fx_thunder"
        };

        var (ok, used, reason) = TrySpawnFirstNetworked(zns, pos, Quaternion.identity, candidates);

        if (ok)
            Logger.LogInfo($"Smite spawned prefab {used}");
        else
            Logger.LogWarning($"Smite failed: {reason}");

    }

    private static (bool ok, string used, string reason) TrySpawnFirstNetworked(ZNetScene zns, Vector3 pos, Quaternion rot, string[] names)
    {
        foreach (var name in names)
        {
            var prefab = zns.GetPrefab(name);
            if (prefab == null) continue;

            var znv = prefab.GetComponent<ZNetView>();
            if (znv == null) continue; // not networked

            var go = UnityEngine.Object.Instantiate(prefab, pos, rot);
            var td = go.GetComponent<TimedDestruction>();
            if (td == null) UnityEngine.Object.Destroy(go, 5f);

            return (true, name, "");
        }

        return (false, "", $"no networked prefabs among: {string.Join(", ", names)}");
    }
}
