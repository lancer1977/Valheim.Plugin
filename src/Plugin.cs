using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using PolyhydraGames.Valheim.Plugin.Extensions;
using System.Reflection;
using Jotunn.Utils;
using PolyhydraGames.Valheim.Plugin.AddNoise;
using ValheimRcon;

namespace PolyhydraGames.Valheim.Plugin
{
    [BepInDependency(ValheimRcon.Plugin.Guid)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInPlugin(Guid, Name, Version)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    [BepInDependency("cinnabun.backpacks-v1.0.0", BepInDependency.DependencyFlags.SoftDependency)]
        public class Plugin : BaseUnityPlugin
    {
        private Harmony _harmony;
        public const string Guid = "com.polyhydragames.rcon";
        public const string Name = "Poly Valheim Rcon";
        public const string Version = "1.0.0";
        private void Awake()
        {
            _harmony = new Harmony(Guid);
            _harmony.PatchAll();
            RconCommandsUtil.RegisterAllCommands(Assembly.GetExecutingAssembly());
            AddNoiseBootStrap.Register();

        }
    }
}