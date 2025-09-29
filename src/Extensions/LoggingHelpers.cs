using System.Collections.Generic;
using System.Linq;

namespace PolyhydraGames.Valheim.Plugin.Extensions
{
    public static class LoggingHelpers
    {

        public static void PrintItems(IList<string> items, string name)
        {
            var result = string.Join(", ", items.Select(x=>"\"" + x  + "\""));
            ZLog.Log($"name ({items.Count}): result");
            ZLog.Log($"Total {name}s: ");
        }


    }
}