using System;
using BepInEx;
using HarmonyLib;
using System.Reflection;
using Jotunn.Utils;
using PolyhydraGames.Valheim.Plugin.Extensions;
using ValheimRcon;

namespace PolyhydraGames.Valheim.Plugin
{
    [BepInDependency(ValheimRcon.Plugin.Guid, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(Jotunn.Main.ModGuid)] 
    [BepInPlugin(Guid, Name, Version)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    
        public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(Guid);
        public const string Guid = "com.polyhydragames.rcon";
        public const string Name = "Polyhydra Games Mods";
        public const string Version = "1.0.0";
        private void Awake()
        { 
            _harmony.PatchAll();

            try
            {

                RconCommandsUtil.RegisterAllCommands(Assembly.GetExecutingAssembly());
                Jotunn.Logger.LogInfo("[PolyValheimRcon] Loaded");
                Helpers.ListPrefabs();
                Helpers.GetEnvironmentNames();
                Helpers.GetStatusEffects();
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogWarning($"[PolyValheimRcon] Loading failed, hopefully this isn't the server!\n{ex.Message}");
            }

        }

   
    }
}