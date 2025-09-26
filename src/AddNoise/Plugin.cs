using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.AddNoise
{
    [BepInPlugin(Metadata.Guid, Metadata.Name, Metadata.Version)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class AddNoiseRconPlugin : BaseUnityPlugin
    {

        private Harmony _harmony;

        private void Awake()
        {
            _harmony = new Harmony(Metadata.Guid);
            _harmony.PatchAll();
            ZRoutedRpc.instance.Register<string, Vector3>(Metadata.RCPCall, PlayNoise);
            Logger.LogInfo($"{Metadata.Name} loaded.");
        }

        private void PlayNoise(long sender, string effectName, Vector3 position)
        {
            if (effectName.Contains("https:"))
            {
                PlayUrl(effectName, position);
            }
            else
            {
                PlayPrefab(effectName, position);
            }
        }

        private void PlayPrefab(string effectName, Vector3 position)
        {
            var prefab = PrefabManager.Instance.GetPrefab(effectName);
            if (prefab != null)
            {
                Instantiate(prefab, position, Quaternion.identity);
                Logger.LogInfo($"Played {effectName} at {position}");
            }
            else
            {
                Logger.LogWarning($"Effect prefab {effectName} not found!");
            }
        }

        private void PlayUrl(string url, Vector3 position)
        {
            var helper = new AudioHelper();
            StartCoroutine(helper.PlayAudioFromUrl(url, position));
        }

    }
}
