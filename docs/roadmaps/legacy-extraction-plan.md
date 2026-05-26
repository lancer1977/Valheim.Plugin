# Valheim.Plugin Legacy Extraction Plan

## Summary

`Valheim.Plugin` is the older PolyRcon/RPC-era Valheim project. It should not
receive new public REST contract work, but it remains useful as a source of
legacy command behavior and Harmony/Jotunn implementation ideas.

The modernization plan is to mine any still-valid behavior from this repo,
port it into `Valheim.RestServer` only when it still works against current
Valheim APIs, and then validate it through the shared
`API.GameServerInterop` contracts.

## Verified overlap with `Valheim.RestServer`

These behaviors already exist in the newer stack, so they do **not** need to be
ported again from `Valheim.Plugin`:

- AddEffect
- AddNoise
- Shake
- Smite
- Whisper
- Impersonate
- Raid/event listing and lookup
- RPC mapping patterns

`SetWindRequest` also exists in `Valheim.RestServer`, but the concrete command
wiring still needs a separate check before it can be considered fully migrated.

## Still worth extracting before retirement

These are the plugin behaviors that do **not** yet show up as equivalent source
files in `Valheim.RestServer` and should be ported or explicitly retired before
`Valheim.Plugin` is labeled reference-only:

- `Broke_Commands/SetWeather` — force environment + broadcast change to clients
- `Broke_Commands/SetWind` — set debug wind and broadcast the RPC
- `Broke_Commands/ResetWind` — restore normal wind
- `Broke_Commands/SkipMorning` — advance to the next morning
- `Broke_Commands/Explode` — spawn `vfx_explosion` at the target player

## Extraction Checklist

- [x] Inventory command folders.
- [x] Compare each command with `Valheim.RestServer` equivalents.
- [x] Identify hook/bootstrap code that can help telemetry capture.
- [x] Identify broken commands that should remain retired.
- [ ] Mark commands as keep, port, replace, or retire.
- [ ] Document any current Valheim API changes needed before porting.
- [ ] Move or rewrite any still-useful legacy-only behavior into `Valheim.RestServer`.

## Retired Or Risky Areas

- `/command`-only PolyRcon wrapper pattern.
- PolyRcon-specific assumptions.
- Generated local deploy artifacts.
- `Broke_Commands` until each command is individually revalidated.
- Old log wording / bootstrap quirks that make legacy behavior look newer than it is.

## Target Destination

- New REST endpoints go to `Valheim.RestServer`.
- Shared DTOs/contracts go to `API.GameServerInterop`.
- Stream policy goes to `channel-cheevos`.
- Display state goes to sidecar/play/mobile consumers.

## Definition Of Done

- [x] Legacy command inventory exists.
- [ ] Useful behavior is linked to a `Valheim.RestServer` issue/roadmap item.
- [ ] No new stream-facing work is planned directly in `Valheim.Plugin`.
- [ ] `Valheim.Plugin` docs clearly identify the repo as reference/legacy.
- [ ] Any unique legacy behavior has been either ported or explicitly retired.
