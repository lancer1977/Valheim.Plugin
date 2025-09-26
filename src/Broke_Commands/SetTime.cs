using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.Plugin.Broke_Commands
{
    internal class SetTime : RconCommand
    {
        public override string Command => "settime";
        public override string Description => "Set time of day fraction (0=midnight, 0.5=noon).";
        protected override string OnHandle(CommandArgs args)
        {
            if (args.Arguments.Count < 1) return "Usage: settime <0.0-1.0>";
            if (!float.TryParse(args.GetString(0), out var f)) return "Invalid number";
            EnvMan.instance.m_debugTimeOfDay = true;
            EnvMan.instance.m_debugTime = Mathf.Clamp01(f);
            
            return $"Time set to {f}";
        }
    }
}