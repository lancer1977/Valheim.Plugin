using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class DatabaseHelpers
    {

        [CanBeNull]
        public static StatusEffect GetEffect(string statusName)
        {
            var hash = statusName.GetStableHashCode();
            var statusEffect = ObjectDB.instance.GetStatusEffect(hash);
            if (statusEffect == null)
            {
                statusEffect = ObjectDB.instance.m_StatusEffects.FirstOrDefault(se => se.name.Equals(statusName, StringComparison.OrdinalIgnoreCase));
                if (statusEffect == null)
                {
                    var message = "No effect found for " + statusName + "Effects: " + string.Join(", ", ObjectDB.instance.m_StatusEffects.Select(x => x.name));
                    Jotunn.Logger.LogWarning(message);
                }
            }

            return statusEffect;
        }
        public static List<string> GetItems()
            => ObjectDB.instance.m_items.OrderBy(x => x).Select(x => x.name).ToList();
        public static List<string> GetStatusEffects()
            => ObjectDB.instance.m_StatusEffects.OrderBy(x => x).Select(x => x.name).ToList();
        public static List<string> GetPrefabNames()
        {
            var items = ZNetScene.instance.GetPrefabNames();
            return items;
        }
        public static List<string> GetAllPlayerNames()
        {
            var items = Player.GetAllPlayers().Select(x => x.GetPlayerName()).ToList();
            return items;
        }

        public static string FormatStatusEffects()
        {
            var items = GetStatusEffects();
              LoggingHelpers.PrintItems(items, "StatusEffects");
            return "";
        }
        public static void ListPrefabs()
        {
            if (ZNetScene.instance == null)
            {
                ZLog.Log("ZNetScene not ready yet.");
                return;
            }

            LoggingHelpers.PrintItems(GetPrefabNames(), "Prefab");

        }

        public static List<string> GetEnvironmentNames()
        {
            List<string> items = null;
            if (EnvMan.instance == null)
            {
                ZLog.Log("ZNetScene not ready yet.");
                return items;
            }
            var names = EnvMan.instance.m_environments.Select(e => e.m_name).ToList();
            LoggingHelpers.PrintItems(names, "Environment");
            return names;
        }

    }
}