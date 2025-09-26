using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using PolyhydraGames.Valheim.Plugin.Models;
using System.Runtime.CompilerServices;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Logger = Jotunn.Logger;
namespace PolyhydraGames.Valheim.Plugin.AddNoise
{


    public static class AddNoiseBootStrap
    {

        public static void Register() =>ZRoutedRpc.instance.Register<string, Vector3>(Metadata.RCPCall, PlayNoise);

        private static void PlayNoise(long sender, string effectName, UnityEngine.Vector3 position)
        {
            var context = CoroutineRunner.Instance;
            if (effectName.Contains("https:"))
            {
                var helper = new AudioHelper();
                context.StartCoroutine(helper.PlayAudioFromUrl(effectName, position));
            }
            else
            {
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
