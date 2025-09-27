using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using PolyhydraGames.Valheim.Plugin.Extensions;
using UnityEngine;
using Logger = Jotunn.Logger;

namespace PolyhydraGames.Valheim.Plugin.AddEffect
{
    [HarmonyPatch(typeof(Game))]
    public static class AddEffectBootStrap
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        public static void Register()
        {
            Logger.LogInfo("Registered " + nameof(AddEffectBootStrap));
            ZRoutedRpc.instance.Register<string>(Metadata.RCPCall, OnApplyStatusEffect);
        }

        /// <summary>
        /// Runs on the client side: actually applies the buff/FX.
        /// </summary>
        private static void OnApplyStatusEffect(long sender, string effectName)
        {
            Logger.LogInfo($"Client received request to apply {effectName}");

            var player = Player.m_localPlayer;
            if (player == null) return;

            var statusEffect = Helpers.GetEffect(effectName);
   

            if (statusEffect != null)
            {
                player.GetSEMan().AddStatusEffect(statusEffect, true);
                Chat.instance.AddString($"[Odin] You are blessed with {statusEffect.m_name}!");
            }
            else
            {
                Logger.LogWarning($"StatusEffect {effectName} not found in ObjectDB");
            }
        }
    }
}
