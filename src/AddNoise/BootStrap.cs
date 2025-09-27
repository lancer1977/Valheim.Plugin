using System;
using HarmonyLib;
using Jotunn.Managers;
using PolyhydraGames.Valheim.Plugin.AddEffect;
using PolyhydraGames.Valheim.Plugin.Models;
using System.Runtime.CompilerServices;
using PolyhydraGames.Valheim.Plugin.Extensions;
using UnityEngine;
using Logger = Jotunn.Logger;
using Vector3 = UnityEngine.Vector3;
namespace PolyhydraGames.Valheim.Plugin.AddNoise
{

    [HarmonyPatch(typeof(Game))]
    public static class AddNoiseBootStrap
    {

        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        private static void Register()
        {
            Logger.LogInfo("Registered " + nameof(AddNoiseBootStrap));
            ZRoutedRpc.instance.Register<string, Vector3>(Metadata.RCPCall, PlayNoise);
        }

        private static void PlayNoise(long sender, string effectName, Vector3 _)
        {
            var position = Player.m_localPlayer.GetPosition();
            //Were going to ignore position for now
            if (effectName.Contains("https:"))
            {
                Logger.LogInfo("Received URL request to playNoise " + effectName);
                try
                {
                    
                    var helper = new AudioHelper();
                    CoroutineRunner.Instance.StartCoroutine(helper.PlayAudioFromUrl(effectName, position));
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                }
                
            }
            else
            {
                Logger.LogInfo("Received URL request to playNoise " + effectName);
                var prefab = PrefabManager.Instance.GetPrefab(effectName);
                if (prefab != null)
                {
                    Component.Instantiate(prefab, position, Quaternion.identity);
                    Logger.LogWarning($"Played {effectName} at {position}");
                }
                else
                {
                    Logger.LogWarning($"Effect prefab {effectName} not found!");
                }
            }
        }


    }
}
