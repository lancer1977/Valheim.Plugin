using BepInEx;
using HarmonyLib;
using Jotunn.Utils;
using PolyhydraGames.Valheim.Plugin.Extensions;
using PolyhydraGames.Valheim.Plugin.WebServer;
using System;
using System.Reflection;
using UnityEngine;
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
        public const string LogHeader = "[PolyValheimRcon]";
        private void Awake()
        { 
            _harmony.PatchAll();
            RegisterHttpCalls();
            try
            {

                RconCommandsUtil.RegisterAllCommands(Assembly.GetExecutingAssembly());
                Jotunn.Logger.LogInfo(" Loaded");
                DatabaseHelpers.ListPrefabs();
                DatabaseHelpers.GetEnvironmentNames();
                DatabaseHelpers.GetStatusEffects();
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogWarning($"[PolyValheimRcon] Loading failed, hopefully this isn't the server!\n{ex.Message}");
            }

        }

        private void RegisterHttpCalls()
        {
            var go = new GameObject(nameof(HttpCommandServer));
            DontDestroyOnLoad(go); // keep it across scene loads
            go.AddComponent<HttpCommandServer>();
            ActionProcessor.RegisterActions();
        }


    }
}