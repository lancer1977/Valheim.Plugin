using System.Reflection;
using BepInEx;
using Jotunn.Configs;
using PolyhydraGames.Valheim.RconExtensions.Extensions;
using ValheimRcon;
using Jotunn.Managers;
namespace PolyhydraGames.Valheim.RconExtensions
{
    [BepInDependency(ValheimRcon.Plugin.Guid)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInPlugin(Guid, Name, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Guid = "com.polyhydragames.rcon";
        public const string Name = "Poly Valheim Rcon";
        public const string Version = "1.0.0";
        private void Awake()
        { 
            RconCommandsUtil.RegisterAllCommands(Assembly.GetExecutingAssembly());
            Helpers.GetFunctions();
            Jotunn.Managers.SkillManager.Instance.AddSkill(
                new SkillConfig()
                {
                    Name = "Pissing",
                    Description = "How good is your aim?"
                });
            Jotunn.StatusEffectExtension.
        }
    }
}