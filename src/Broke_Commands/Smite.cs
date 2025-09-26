using PolyhydraGames.Valheim.RconExtensions.Models;
using UnityEngine;
using ValheimRcon.Commands;

namespace PolyhydraGames.Valheim.RconExtensions.Commands
{
    
 
    internal class Smite : PolyRconCommand
    {
        public override string Command => "smite";
        public override string Description => "Strike a player with lightning. Usage: smite <player>";

        protected override string OnHandle(PlayerWrapperType player, CommandArgs args)
        {
            if (player == null) return "No player found.";
            if (args.Arguments.Count < 1) return "Usage: smite <player>";

            var zns = ZNetScene.instance;
            if (zns == null) return "ZNetScene not ready on server.";

            var pos = player.RefPosition;

            // Prefer networked/replicated prefabs. Order is a best-guess; adjust after listing your prefabs.
            var candidates = new[]
            {
                "lightningAOE",          // often networked AOE with ZNetView
                "vfx_lightning_hit",     // sometimes networked VFX
                "fx_thunder"             // pure VFX; usually NOT networked (last resort - won't replicate)
            };

            var (ok, used, reason) = TrySpawnFirstNetworked(zns, pos, Quaternion.identity, candidates);

            if (!ok)
            {
                // Give a *useful* error back via RCON so you can fix fast
                return $"Smite failed: {reason}. Tip: use /listprefabs lightning and pick one with ZNetView.";
            }

            return $"Smote {player.Name} with {used} ⚡";
        }

        private static (bool ok, string used, string reason) TrySpawnFirstNetworked(
            ZNetScene zns, Vector3 pos, Quaternion rot, string[] names)
        {
            foreach (var name in names)
            {
                var prefab = zns.GetPrefab(name);
                if (prefab == null) continue;

                var znv = prefab.GetComponent<ZNetView>();
                if (znv == null)
                {
                    // Not networked; spawning on a headless server won't show on clients.
                    continue;
                }

                var go = Object.Instantiate(prefab, pos, rot);
                // If it doesn't self-clean, destroy after a short time
                var td = go.GetComponent<TimedDestruction>();
                if (td == null) Object.Destroy(go, 5f);

                return (true, name, "");
            }

            // Nothing networked found; report why.
            var missing = string.Join(", ", names);
            return (false, "", $"no networked prefabs among: {missing}");
        }
    }
}
