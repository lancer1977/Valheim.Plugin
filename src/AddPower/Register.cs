using System;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.AddPower;

[HarmonyPatch(typeof(Game))]
public static class GuardianPowerRpc
{
    [HarmonyPostfix]
    [HarmonyPatch("Start")]
    private static void RegisterRpc()
    {
        ZRoutedRpc.instance.Register(Metadata.RCPCall, (long sender, string statusName) =>
        {
            var status = ObjectDB.instance.m_StatusEffects.FirstOrDefault(se => se.name.Equals(statusName, StringComparison.OrdinalIgnoreCase));

            if (status == null)
            {
                Debug.LogWarning($"[GuardianPowerRpc] Could not find guardian power: {statusName}");
                return;
            }

            // Apply and trigger the guardian power
            Player.m_localPlayer.SetGuardianPower(status.name);
            Player.m_localPlayer.ActivateGuardianPower();
        });
    }
}