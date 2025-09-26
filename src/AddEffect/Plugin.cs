using BepInEx;
using HarmonyLib;
using Jotunn.Managers;

namespace PolyhydraGames.Valheim.Plugin.AddEffect
{
    [BepInPlugin(Metadata.Guid, Metadata.Name, Metadata.Version)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class EffectRconPlugin : BaseUnityPlugin
    {


        /// <summary>
        /// Runs on the client side: actually applies the buff/FX.
        /// </summary>
        private void OnApplyStatusEffect(long sender, string effectName)
        {
            Logger.LogInfo($"Client received request to apply {effectName}");

            var player = Player.m_localPlayer;
            if (player == null) return;

            var prefab = PrefabManager.Instance.GetPrefab(effectName);
            if (prefab != null)
            {
                var effect = prefab.GetComponent<StatusEffect>();
                if (effect != null)
                {
                    player.m_seman.AddStatusEffect(effect, true);
                    Chat.instance.AddString($"[Odin] You are blessed with undead herpes, aka {effectName}!");
                }
            }
        }
        private void Awake()
        {
            _harmony = new Harmony(Metadata.Guid);
            _harmony.PatchAll();
            ZRoutedRpc.instance.Register<string>(Metadata.RCPCall, OnApplyStatusEffect);
            Logger.LogInfo($"{Metadata.Name} loaded.");
        }

        private Harmony _harmony;
    }
}
